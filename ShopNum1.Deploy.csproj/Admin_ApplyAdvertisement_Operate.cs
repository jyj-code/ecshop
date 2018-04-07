using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ApplyAdvertisement_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelMemLoginID;
	protected Label LabelAdId;
	protected Label LabelRemarks;
	protected Label LabelHref;
	protected Panel PanelShow1;
	protected Label LabelMoney;
	protected Label LabelCreateTime;
	protected Label LabelIsExamine;
	protected Label LabelApplyState;
	protected Label LabelIsCancel;
	protected Label LabelBeginDate;
	protected HtmlTableRow adwidth;
	protected Label LabelEndDate;
	protected HtmlTableRow Tr3;
	protected System.Web.UI.WebControls.Image ImageAd;
	protected Panel PanelShow2;
	protected Label LabelName1;
	protected Label LabelName2;
	protected Label LabelName3;
	protected System.Web.UI.WebControls.Image ImageAd1;
	protected System.Web.UI.WebControls.Image ImageAd2;
	protected System.Web.UI.WebControls.Image ImageAd3;
	protected Label LabelWeb1;
	protected Label LabelWeb2;
	protected Label LabelWeb3;
	protected Panel PanelShow3;
	protected HtmlTableRow adheight;
	protected System.Web.UI.WebControls.Image ImageMap;
	protected HtmlTableRow Tr1;
	protected Label LabelShowDay;
	protected HtmlTableRow Tr2;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldCityCode;
	protected HiddenField HiddenFieldADid;
	protected HiddenField HiddenFieldSubstationID;
	protected HtmlForm form1;
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"].ToString());
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.LabelPageTitle.Text = "审核会员申请广告";
			this.GetEditInfo();
			this.GetXml();
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.LabelApplyState.Text == "已预定")
		{
			MessageBox.Show("该广告尚未付费，不能进行审核！");
		}
		else if (this.LabelIsCancel.Text == "已撤销")
		{
			MessageBox.Show("该广告已经撤销，不能进行审核！");
		}
		else if (this.LabelIsExamine.Text == "已审核")
		{
			MessageBox.Show("该广告已经审核，不能重复审核！");
		}
		else
		{
			ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
			int num = shopNum1_AdvertPay_Action.UpdateIsExamine(this.hiddenFieldGuid.Value, 1);
			if (num > 0)
			{
				string text = shopNum1_AdvertPay_Action.GetMaxDate(this.HiddenFieldSubstationID.Value, this.HiddenFieldADid.Value).Rows[0][0].ToString();
				try
				{
					if (Convert.ToDateTime(text) == Convert.ToDateTime("1900-1-1"))
					{
						shopNum1_AdvertPay_Action.UpdateEndDate(this.hiddenFieldGuid.Value, DateTime.Now.ToString(), DateTime.Now.AddDays(Convert.ToDouble(this.LabelShowDay.Text)).ToString());
					}
					else
					{
						shopNum1_AdvertPay_Action.UpdateEndDate(this.hiddenFieldGuid.Value, text, Convert.ToDateTime(text).AddDays(Convert.ToDouble(this.LabelShowDay.Text)).ToString());
					}
					MessageBox.Show("审核成功！");
					this.GetEditInfo();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
	public void GetEditInfo()
	{
		ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
		DataTable dataTable = shopNum1_AdvertPay_Action.SearchAll(this.hiddenFieldGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			if (dataTable.Rows[0]["AdType"].ToString() == "1")
			{
				this.PanelShow1.Visible = true;
				this.LabelRemarks.Text = dataTable.Rows[0]["Remarks"].ToString();
				this.LabelHref.Text = dataTable.Rows[0]["Website"].ToString();
				this.PanelShow2.Visible = true;
			}
			else if (dataTable.Rows[0]["AdType"].ToString() == "2")
			{
				this.PanelShow3.Visible = true;
				this.LabelName1.Text = dataTable.Rows[0]["Remarks"].ToString();
				this.LabelName2.Text = dataTable.Rows[0]["Remarks1"].ToString();
				this.LabelName3.Text = dataTable.Rows[0]["Remarks2"].ToString();
				if (!string.IsNullOrEmpty(dataTable.Rows[0]["Image"].ToString()))
				{
					string[] array = dataTable.Rows[0]["Image"].ToString().Split(new char[]
					{
						'|'
					});
					this.ImageAd1.ImageUrl = array[0].ToString();
					this.ImageAd2.ImageUrl = array[1].ToString();
					this.ImageAd3.ImageUrl = array[2].ToString();
				}
				this.LabelWeb1.Text = dataTable.Rows[0]["Website"].ToString();
				this.LabelWeb2.Text = dataTable.Rows[0]["Website1"].ToString();
				this.LabelWeb3.Text = dataTable.Rows[0]["Website2"].ToString();
			}
			this.LabelMemLoginID.Text = dataTable.Rows[0]["MemLoginID"].ToString();
			this.HiddenFieldADid.Value = dataTable.Rows[0]["AdId"].ToString();
			this.LabelMoney.Text = dataTable.Rows[0]["PayMoney"].ToString();
			this.LabelApplyState.Text = dataTable.Rows[0]["ApplyState"].ToString();
			if (dataTable.Rows[0]["ApplyState"].ToString() == "1")
			{
				this.LabelApplyState.Text = "已申请";
				this.LabelMoney.Text = dataTable.Rows[0]["PayMoney"].ToString() + "(已付费)";
			}
			else if (dataTable.Rows[0]["ApplyState"].ToString() == "2")
			{
				this.LabelApplyState.Text = "已预定";
				this.LabelMoney.Text = dataTable.Rows[0]["PayMoney"].ToString() + "(未付费)";
			}
			this.LabelCreateTime.Text = dataTable.Rows[0]["CreateTime"].ToString();
			this.LabelIsExamine.Text = dataTable.Rows[0]["IsExamine"].ToString();
			if (dataTable.Rows[0]["IsExamine"].ToString() == "1")
			{
				this.LabelIsExamine.Text = "已审核";
			}
			else if (dataTable.Rows[0]["IsExamine"].ToString() == "0")
			{
				this.LabelIsExamine.Text = "未审核";
				this.LabelIsExamine.ForeColor = Color.Red;
			}
			if (dataTable.Rows[0]["IsCancel"].ToString() == "0")
			{
				this.LabelIsCancel.Text = "未撤销";
			}
			else if (dataTable.Rows[0]["IsCancel"].ToString() == "1")
			{
				this.LabelIsCancel.Text = "已撤销";
				this.LabelIsCancel.ForeColor = Color.Red;
			}
			this.LabelBeginDate.Text = dataTable.Rows[0]["BeginDate"].ToString();
			if (Convert.ToDateTime(dataTable.Rows[0]["BeginDate"].ToString()) == Convert.ToDateTime("1900-1-1"))
			{
				this.LabelBeginDate.Text = "未审核";
				this.LabelBeginDate.ForeColor = Color.Red;
			}
			this.LabelEndDate.Text = dataTable.Rows[0]["EndDate"].ToString();
			if (Convert.ToDateTime(dataTable.Rows[0]["EndDate"].ToString()) == Convert.ToDateTime("1900-1-1"))
			{
				this.LabelEndDate.Text = "未审核";
				this.LabelEndDate.ForeColor = Color.Red;
			}
			this.ImageAd.ImageUrl = dataTable.Rows[0]["Image"].ToString();
			this.HiddenFieldCityCode.Value = dataTable.Rows[0]["CityCode"].ToString();
			this.HiddenFieldSubstationID.Value = dataTable.Rows[0]["SubstationID"].ToString();
		}
	}
	public void GetXml()
	{
		DefaultAdvertPayOperateNoPath defaultAdvertPayOperateNoPath = new DefaultAdvertPayOperateNoPath();
		if (this.HiddenFieldSubstationID.Value == "all")
		{
			defaultAdvertPayOperateNoPath.Path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml";
		}
		else
		{
			defaultAdvertPayOperateNoPath.Path = "~/City/" + this.HiddenFieldSubstationID.Value + "/Themes/Skin_Default/Xml/PayAdImage.xml";
		}
		DataTable dataTable = defaultAdvertPayOperateNoPath.SelecByID(this.HiddenFieldADid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.ImageMap.ImageUrl = dataTable.Rows[0]["Map"].ToString();
			this.LabelAdId.Text = dataTable.Rows[0]["title"].ToString();
			this.LabelShowDay.Text = dataTable.Rows[0]["showDay"].ToString();
		}
	}
}
