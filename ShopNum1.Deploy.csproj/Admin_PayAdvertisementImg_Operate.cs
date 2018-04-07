using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_PayAdvertisementImg_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected TextBox TextBoxSubstationIdOnline;
	protected TextBox TextBoxID;
	protected DropDownList DropDownListAdType;
	protected TextBox TextBoxName;
	protected RequiredFieldValidator RequiredFieldValidatorFileName;
	protected TextBox TextBoxHref;
	protected TextBox TextBoxDefaultImage;
	protected Image ImageDefaultImage;
	protected TextBox TextBoxpath;
	protected Image ImageMaps;
	protected TextBox TextBoxWidth;
	protected RequiredFieldValidator RegularExpressionValidatorWidth;
	protected RegularExpressionValidator RequiredFieldValidatorWidth;
	protected HtmlTableRow adwidth;
	protected TextBox TextBoxHeight;
	protected RequiredFieldValidator RequiredFieldValidatorHeight;
	protected RegularExpressionValidator RegularExpressionValidatorHeight;
	protected HtmlTableRow adheight;
	protected TextBox TextBoxMoney;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected HtmlTableRow Tr1;
	protected TextBox TextBoxDate;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected HtmlTableRow Tr2;
	protected CheckBox CheckBoxIsRun;
	protected HtmlTableRow Tr3;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	private DefaultAdvertPayOperate defaultAdvertPayOperate_0 = new DefaultAdvertPayOperate();
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
		if (base.Request.QueryString["SubstationID"] != null)
		{
			this.defaultAdvertPayOperate_0.SubstationID = base.Request.QueryString["SubstationID"].ToString();
		}
		else
		{
			this.defaultAdvertPayOperate_0.SubstationID = base.SubstationID;
		}
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"].Replace("'", ""));
		this.TextBoxID.Text = this.defaultAdvertPayOperate_0.GetMaxId().ToString();
		if (!this.Page.IsPostBack)
		{
			this.ShowSub();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑广告";
				this.GetEditInfo();
			}
		}
	}
	public string GetSubName(string SubstationID)
	{
		string result;
		if (SubstationID == "all")
		{
			result = "全国站";
		}
		else
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
			if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
			{
				result = dataBySubstationID.Rows[0]["Name"].ToString();
			}
			else
			{
				result = "分站不存在或者已经被删除";
			}
		}
		return result;
	}
	public void ShowSub()
	{
		if (base.Request.QueryString["guid"] != null)
		{
			if (base.Request.QueryString["SubstationID"] != null)
			{
				this.TextBoxSubstationIdOnline.Text = this.GetSubName(base.Request.QueryString["SubstationID"].ToString());
			}
			else
			{
				this.TextBoxSubstationIdOnline.Text = "全国";
			}
		}
		else
		{
			this.TextBoxSubstationIdOnline.Text = "全国";
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
	public void Add()
	{
		if (this.DropDownListAdType.SelectedValue == "-1")
		{
			MessageBox.Show("请选择广告类型");
		}
		else
		{
			this.TextBoxID.Text.Trim();
			string title = this.TextBoxName.Text.Trim();
			string selectedValue = this.DropDownListAdType.SelectedValue;
			string map = this.TextBoxpath.Text.Trim();
			string href = this.TextBoxHref.Text.Trim();
			string width = this.TextBoxWidth.Text.Trim();
			string height = this.TextBoxHeight.Text.Trim();
			string money = this.TextBoxMoney.Text.Trim();
			string showDay = this.TextBoxDate.Text.Trim();
			string defaultImage = this.TextBoxDefaultImage.Text.Trim();
			int num;
			if (this.CheckBoxIsRun.Checked)
			{
				num = 1;
			}
			else
			{
				num = 0;
			}
			int num2 = 0;
			try
			{
				num2 = this.defaultAdvertPayOperate_0.Add(title, selectedValue, map, href, width, height, money, showDay, defaultImage, num.ToString());
			}
			catch (Exception)
			{
			}
			if (num2 > 0)
			{
				base.Response.Redirect("PayAdvertisementImg_List.aspx");
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	public void Edit()
	{
		string string_ = this.hiddenFieldGuid.Value.Replace("'", "");
		string title = this.TextBoxName.Text.Trim();
		string selectedValue = this.DropDownListAdType.SelectedValue;
		string map = this.TextBoxpath.Text.Trim();
		string href = this.TextBoxHref.Text.Trim();
		string width = this.TextBoxWidth.Text.Trim();
		string height = this.TextBoxHeight.Text.Trim();
		string money = this.TextBoxMoney.Text.Trim();
		string showDay = this.TextBoxDate.Text.Trim();
		string defaultImage = this.TextBoxDefaultImage.Text.Trim();
		int num;
		if (this.CheckBoxIsRun.Checked)
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		int num2 = this.defaultAdvertPayOperate_0.Update(string_, title, selectedValue, map, href, width, height, money, showDay, defaultImage, num.ToString());
		if (num2 > 0)
		{
			base.Response.Redirect("PayAdvertisementImg_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void GetEditInfo()
	{
		DataTable dataTable = this.defaultAdvertPayOperate_0.SelecByID(this.hiddenFieldGuid.Value.Replace("'", ""));
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			DataRow dataRow = dataTable.Rows[0];
			this.TextBoxID.Text = this.hiddenFieldGuid.Value;
			this.DropDownListAdType.SelectedValue = dataRow["type"].ToString();
			this.TextBoxName.Text = dataRow["title"].ToString();
			this.TextBoxHref.Text = dataRow["Href"].ToString();
			this.TextBoxpath.Text = dataRow["Map"].ToString();
			this.ImageMaps.ImageUrl = dataRow["Map"].ToString();
			this.TextBoxWidth.Text = dataRow["width"].ToString();
			this.TextBoxHeight.Text = dataRow["height"].ToString();
			this.TextBoxMoney.Text = dataRow["money"].ToString();
			this.TextBoxDate.Text = dataRow["showDay"].ToString();
			this.TextBoxDefaultImage.Text = dataRow["DefaultImage"].ToString();
			this.ImageDefaultImage.ImageUrl = dataRow["DefaultImage"].ToString();
			try
			{
				if (dataRow["IsRun"].ToString() == "1")
				{
					this.CheckBoxIsRun.Checked = true;
				}
				else if (dataRow["IsRun"].ToString() == "0")
				{
					this.CheckBoxIsRun.Checked = false;
				}
				else
				{
					this.CheckBoxIsRun.Checked = false;
				}
			}
			catch (Exception)
			{
				this.CheckBoxIsRun.Checked = false;
			}
		}
	}
}
