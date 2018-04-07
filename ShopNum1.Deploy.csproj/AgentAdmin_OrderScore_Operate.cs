using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_OrderScore_Operate : PageBase, IRequiresSessionState
{
	protected Label Label18;
	protected Repeater RepeaterData;
	protected Label LabelPageTitle;
	protected Label LabelShopID;
	protected Label LabelShopIDValue;
	protected Label LabelShopName;
	protected Label LabelShopNameValue;
	protected Label LabelOrderNumber;
	protected Label LabelOrderNumberValue;
	protected Label LabelNameMemLoginID;
	protected Label LabelMemLoginIDValue;
	protected Label LabelMemLoginIDValueShow;
	protected Label LabelOderStatus;
	protected Label LabelOderStatusValue;
	protected Label LabelCreateTime;
	protected Label LabelCreateTimeValue;
	protected Label LabelNameDispatchModeName;
	protected Label LabelConfirmTimeValue;
	protected Label LabelTotalScore;
	protected Label LabelTotalScoreValue;
	protected Label Label1;
	protected Label LabelName;
	protected Label LabelNameValue;
	protected Label LabelEmail;
	protected Label LabelEmailValue;
	protected Label LabelAddress;
	protected Label LabelAddressValue;
	protected Label LabelPostalcode;
	protected Label LabelPostalcodeValue;
	protected Label LabelMobile;
	protected Label LabelMobileValue;
	protected Button ButtonOderStatus;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
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
		if (!this.Page.IsPostBack)
		{
			if (base.Request.QueryString["guid"] != null)
			{
				this.hiddenFieldGuid.Value = base.Request.QueryString["guid"].ToString();
			}
			this.BindOrderMessage();
			if (base.Request.QueryString["OrderNumber"] != null)
			{
				this.BindProduct(base.Request.QueryString["OrderNumber"].ToString());
			}
		}
		if (this.LabelOderStatusValue.Text == "已处理")
		{
			this.ButtonOderStatus.Visible = false;
		}
	}
	public void BindOrderMessage()
	{
		ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
		DataTable infoByGuid = shopNum1_ScoreOrderInfo_Action.GetInfoByGuid(this.hiddenFieldGuid.Value);
		if (infoByGuid != null && infoByGuid.Rows.Count > 0)
		{
			this.LabelShopIDValue.Text = infoByGuid.Rows[0]["ShopMemLoginID"].ToString();
			this.LabelOrderNumberValue.Text = infoByGuid.Rows[0]["OrderNumber"].ToString();
			this.LabelMemLoginIDValue.Text = infoByGuid.Rows[0]["MemLoginID"].ToString();
			this.LabelShopNameValue.Text = this.GetShopName(infoByGuid.Rows[0]["ShopMemLoginID"].ToString());
			if (infoByGuid.Rows[0]["OderStatus"].ToString() == "1")
			{
				this.LabelOderStatusValue.Text = "已处理";
			}
			else
			{
				this.LabelOderStatusValue.Text = "未处理";
			}
			this.LabelCreateTimeValue.Text = infoByGuid.Rows[0]["CreateTime"].ToString();
			if (Convert.ToDateTime(infoByGuid.Rows[0]["ConfirmTime"].ToString()) == Convert.ToDateTime("1900-1-1"))
			{
				this.LabelConfirmTimeValue.Text = "未处理";
			}
			else
			{
				this.LabelConfirmTimeValue.Text = infoByGuid.Rows[0]["ConfirmTime"].ToString();
			}
			this.LabelTotalScoreValue.Text = infoByGuid.Rows[0]["TotalScore"].ToString();
			this.LabelNameValue.Text = infoByGuid.Rows[0]["Name"].ToString();
			this.LabelEmailValue.Text = infoByGuid.Rows[0]["Email"].ToString();
			string text = string.Empty;
			string str = string.Empty;
			string str2 = string.Empty;
			if (!string.IsNullOrEmpty(infoByGuid.Rows[0]["Address"].ToString()))
			{
				string[] array = infoByGuid.Rows[0]["Address"].ToString().Split(new char[]
				{
					'|'
				});
				if (array.Length > 0)
				{
					text = array[0].ToString();
					str = array[1].ToString();
				}
				string text2 = string.Empty;
				if (!string.IsNullOrEmpty(text))
				{
					string[] array2 = text.Split(new char[]
					{
						'/'
					});
					if (array2.Length > 0)
					{
						text2 = array2[0].ToString();
					}
				}
				if (text2.Length == 9)
				{
					DataTable adressNameByCode = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2.Substring(0, 3));
					if (adressNameByCode != null && adressNameByCode.Rows.Count > 0)
					{
						str2 += adressNameByCode.Rows[0]["Name"].ToString();
					}
					DataTable adressNameByCode2 = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2.Substring(0, 6));
					if (adressNameByCode2 != null && adressNameByCode2.Rows.Count > 0)
					{
						str2 += adressNameByCode2.Rows[0]["Name"].ToString();
					}
					DataTable adressNameByCode3 = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2);
					if (adressNameByCode3 != null && adressNameByCode3.Rows.Count > 0)
					{
						str2 += adressNameByCode3.Rows[0]["Name"].ToString();
					}
				}
				else if (text2.Length == 6)
				{
					DataTable adressNameByCode = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2.Substring(0, 3));
					if (adressNameByCode != null && adressNameByCode.Rows.Count > 0)
					{
						str2 += adressNameByCode.Rows[0]["Name"].ToString();
					}
					DataTable adressNameByCode3 = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2);
					if (adressNameByCode3 != null && adressNameByCode3.Rows.Count > 0)
					{
						str2 += adressNameByCode3.Rows[0]["Name"].ToString();
					}
				}
				else if (text2.Length == 3)
				{
					DataTable adressNameByCode3 = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2);
					if (adressNameByCode3 != null && adressNameByCode3.Rows.Count > 0)
					{
						str2 += adressNameByCode3.Rows[0]["Name"].ToString();
					}
				}
			}
			this.LabelAddressValue.Text = str2 + str;
			this.LabelPostalcodeValue.Text = infoByGuid.Rows[0]["Postalcode"].ToString();
			this.LabelMobileValue.Text = infoByGuid.Rows[0]["Mobile"].ToString();
		}
	}
	public void BindProduct(string OrderNumber)
	{
		ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
		DataTable productByOrderNumber = shopNum1_ScoreOrderInfo_Action.GetProductByOrderNumber(OrderNumber);
		if (productByOrderNumber != null && productByOrderNumber.Rows.Count > 0)
		{
			this.RepeaterData.DataSource = productByOrderNumber.DefaultView;
			this.RepeaterData.DataBind();
		}
	}
	protected void ButtonOderStatus_Click(object sender, EventArgs e)
	{
		ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
		try
		{
			int num = shopNum1_ScoreOrderInfo_Action.ChangeOderStatus(this.hiddenFieldGuid.Value, "1");
			if (num > 0)
			{
				this.BindOrderMessage();
				MessageBox.Show("处理成功，请及时发货！");
				if (this.LabelOderStatusValue.Text == "已处理")
				{
					this.ButtonOderStatus.Visible = false;
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show("操作失败！");
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderScore_List.aspx");
	}
	public string GetShopName(string user)
	{
		Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
		DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(user);
		string result;
		if (memLoginInfo != null && memLoginInfo.Rows.Count > 0)
		{
			result = memLoginInfo.Rows[0]["ShopName"].ToString();
		}
		else
		{
			result = "店铺已经不存在了";
		}
		return result;
	}
}
