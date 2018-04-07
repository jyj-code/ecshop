using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopInfo_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected TextBox TextBoxSubstationID;
	protected TextBox TextBoxShopType;
	protected TextBox TextBoxName;
	protected TextBox TextBoxShopName;
	protected TextBox TextBoxShopCategory;
	protected TextBox TextBoxShopID;
	protected TextBox TextBoxShopUrl;
	protected TextBox TextBoxOpenTime;
	protected TextBox TextBoxSalesRange;
	protected TextBox TextBoxEmail;
	protected RegularExpressionValidator RegularExpressionValidatorTitle9;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected TextBox TextBoxTel;
	protected TextBox TextBoxPhone;
	protected RegularExpressionValidator RegularExpressionValidator4;
	protected TextBox TextBoxPostalCode;
	protected RegularExpressionValidator RegularExpressionValidatorTitle10;
	protected TextBox TextBoxIdentityCard;
	protected TextBox TextBoxRegistrationNum;
	protected TextBox TextBoxCompanName;
	protected TextBox TextBoxLegalPerson;
	protected TextBox TextBoxRegisteredCapital;
	protected TextBox TextBoxBusinessTerm;
	protected TextBox TextBoxBusinessScope;
	protected TextBox TextBoxAddress;
	protected DropDownList DropDownListIsExpires;
	protected Repeater RepeaterEnsure;
	protected DropDownList DropDownListIsClose;
	protected TextBox TextBoxMainGoods;
	protected TextBox TextBoxShopIntroduce;
	protected TextBox TextBoxCompanyIntroduce;
	protected HtmlTableCell thYyzz;
	protected Image ImageBanner;
	protected HtmlAnchor aBanner;
	protected Image ImageCardImage1;
	protected HtmlAnchor aCardImage1;
	protected Image ImageCardImage2;
	protected HtmlAnchor aCardImage2;
	protected Image ImageBusinessLicense;
	protected HtmlAnchor aBusinessLicense;
	protected HtmlTableCell tdYyzz;
	protected Button ButtonConfirm;
	protected Button ButtonBank;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldMemLoginID;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_5;
	private string ShopID
	{
		get;
		set;
	}
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
		if (!this.Page.IsPostBack)
		{
			this.method_5();
		}
	}
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	private void method_5()
	{
		this.CheckGuid.Value = base.Request.QueryString["guid"];
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable allShopInfoByGuid = shopNum1_ShopInfoList_Action.GetAllShopInfoByGuid(this.CheckGuid.Value);
		if (allShopInfoByGuid.Rows[0]["ShopType"].ToString() == "0")
		{
			this.TextBoxShopType.Text = "个人店铺";
			this.thYyzz.Visible = false;
			this.tdYyzz.Visible = false;
		}
		else
		{
			this.TextBoxShopType.Text = "企业店铺";
		}
		this.TextBoxSubstationID.Text = this.GetSubstationIDname(allShopInfoByGuid.Rows[0]["SubstationID"].ToString());
		if (string.IsNullOrEmpty(allShopInfoByGuid.Rows[0]["ShopCategory"].ToString()))
		{
			string text = string.Empty;
			string text2 = allShopInfoByGuid.Rows[0]["ShopCategoryID"].ToString().Trim();
			if (text2.Length == 3)
			{
				text = Common.GetNameById("Name", "ShopNum1_ShopCategory", "  and  Code='" + text2 + "'   ");
			}
			else if (text2.Length == 6)
			{
				text = Common.GetNameById("Name", "ShopNum1_ShopCategory", "  and  Code='" + text2.Substring(0, 3) + "'   ");
				text = text + "/" + Common.GetNameById("Name", "ShopNum1_ShopCategory", "  and  Code='" + text2 + "'   ");
			}
			else if (text2.Length == 9)
			{
				text = Common.GetNameById("Name", "ShopNum1_ShopCategory", "  and  Code='" + text2.Substring(0, 3) + "'   ");
				text = Common.GetNameById("Name", "ShopNum1_ShopCategory", "  and  Code='" + text2.Substring(0, 6) + "'   ");
				text = text + "/" + Common.GetNameById("Name", "ShopNum1_ShopCategory", "  and  Code='" + text2 + "'   ");
			}
			this.TextBoxShopCategory.Text = text;
		}
		else
		{
			this.TextBoxShopCategory.Text = allShopInfoByGuid.Rows[0]["ShopCategory"].ToString();
		}
		this.HiddenFieldMemLoginID.Value = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString();
		this.TextBoxName.Text = allShopInfoByGuid.Rows[0]["Name"].ToString();
		this.TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["ShopName"].ToString();
		this.TextBoxSalesRange.Text = allShopInfoByGuid.Rows[0]["SalesRange"].ToString();
		this.TextBoxEmail.Text = allShopInfoByGuid.Rows[0]["Email"].ToString();
		this.TextBoxTel.Text = allShopInfoByGuid.Rows[0]["Tel"].ToString();
		this.TextBoxPhone.Text = allShopInfoByGuid.Rows[0]["Phone"].ToString();
		this.TextBoxPostalCode.Text = allShopInfoByGuid.Rows[0]["PostalCode"].ToString();
		this.TextBoxAddress.Text = allShopInfoByGuid.Rows[0]["Address"].ToString();
		this.TextBoxShopUrl.Text = ShopUrlOperate.GetShopUrlNew(allShopInfoByGuid.Rows[0]["ShopID"].ToString());
		this.TextBoxOpenTime.Text = allShopInfoByGuid.Rows[0]["OpenTime"].ToString();
		this.TextBoxCompanyIntroduce.Text = allShopInfoByGuid.Rows[0]["CompanyIntroduce"].ToString();
		this.TextBoxShopIntroduce.Text = allShopInfoByGuid.Rows[0]["Memo"].ToString();
		this.TextBoxCompanyIntroduce.Text = allShopInfoByGuid.Rows[0]["ShopIntroduce"].ToString();
		this.ShopID = ShopSettings.GetValue("PersonShopUrl") + allShopInfoByGuid.Rows[0]["ShopID"].ToString();
		this.TextBoxRegistrationNum.Text = allShopInfoByGuid.Rows[0]["RegistrationNum"].ToString();
		this.TextBoxCompanName.Text = allShopInfoByGuid.Rows[0]["CompanName"].ToString();
		this.TextBoxLegalPerson.Text = allShopInfoByGuid.Rows[0]["LegalPerson"].ToString();
		this.TextBoxRegisteredCapital.Text = allShopInfoByGuid.Rows[0]["RegisteredCapital"].ToString();
		this.TextBoxBusinessTerm.Text = allShopInfoByGuid.Rows[0]["BusinessTerm"].ToString();
		this.TextBoxBusinessScope.Text = allShopInfoByGuid.Rows[0]["BusinessScope"].ToString();
		this.TextBoxShopID.Text = allShopInfoByGuid.Rows[0]["ShopID"].ToString();
		this.TextBoxMainGoods.Text = allShopInfoByGuid.Rows[0]["MainGoods"].ToString();
		this.DropDownListIsExpires.SelectedValue = allShopInfoByGuid.Rows[0]["IsExpires"].ToString();
		this.DropDownListIsClose.SelectedValue = allShopInfoByGuid.Rows[0]["IsClose"].ToString();
		this.TextBoxIdentityCard.Text = allShopInfoByGuid.Rows[0]["IdentityCard"].ToString();
		this.ImageBanner.ImageUrl = allShopInfoByGuid.Rows[0]["Banner"].ToString();
		this.aBanner.HRef = allShopInfoByGuid.Rows[0]["Banner"].ToString();
		this.ImageCardImage1.ImageUrl = (allShopInfoByGuid.Rows[0]["CardImage"].ToString() ?? "");
		this.aCardImage1.HRef = (allShopInfoByGuid.Rows[0]["CardImage"].ToString() ?? "");
		this.ImageCardImage2.ImageUrl = (allShopInfoByGuid.Rows[0]["CardImage"].ToString() ?? "");
		this.aCardImage2.HRef = (allShopInfoByGuid.Rows[0]["CardImage"].ToString() ?? "");
		this.aBusinessLicense.HRef = allShopInfoByGuid.Rows[0]["BusinessLicense"].ToString();
		this.ImageBusinessLicense.ImageUrl = allShopInfoByGuid.Rows[0]["BusinessLicense"].ToString();
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
		DataTable dataTable = shop_Ensure_Action.SearchEnsureApply(this.ShopID);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.RepeaterEnsure.DataSource = dataTable.DefaultView;
			this.RepeaterEnsure.DataBind();
		}
		else
		{
			this.RepeaterEnsure.DataSource = null;
			this.RepeaterEnsure.DataBind();
		}
	}
	protected void ButtonBank_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopInfoList_Manage.aspx");
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfo shopNum1_ShopInfo = new ShopNum1_ShopInfo();
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		shopNum1_ShopInfo.Name = this.TextBoxName.Text;
		shopNum1_ShopInfo.ShopName = this.TextBoxShopName.Text;
		shopNum1_ShopInfo.SalesRange = this.TextBoxSalesRange.Text;
		shopNum1_ShopInfo.Email = this.TextBoxEmail.Text;
		shopNum1_ShopInfo.Tel = this.TextBoxTel.Text;
		shopNum1_ShopInfo.Phone = this.TextBoxPhone.Text;
		shopNum1_ShopInfo.PostalCode = this.TextBoxPostalCode.Text;
		shopNum1_ShopInfo.IdentityCard = this.TextBoxIdentityCard.Text;
		shopNum1_ShopInfo.RegistrationNum = this.TextBoxRegistrationNum.Text;
		shopNum1_ShopInfo.CompanName = this.TextBoxCompanName.Text;
		shopNum1_ShopInfo.LegalPerson = this.TextBoxLegalPerson.Text;
		shopNum1_ShopInfo.RegisteredCapital = Convert.ToDecimal(this.TextBoxRegisteredCapital.Text.ToString());
		shopNum1_ShopInfo.BusinessTerm = this.TextBoxBusinessTerm.Text;
		shopNum1_ShopInfo.BusinessScope = this.TextBoxBusinessScope.Text;
		shopNum1_ShopInfo.Address = this.TextBoxAddress.Text;
		shopNum1_ShopInfo.IsExpires = new int?(Convert.ToInt32(this.DropDownListIsExpires.SelectedValue.ToString()));
		shopNum1_ShopInfo.IsClose = new int?(Convert.ToInt32(this.DropDownListIsClose.SelectedValue.ToString()));
		shopNum1_ShopInfo.CompanyIntroduce = this.TextBoxCompanyIntroduce.Text;
		shopNum1_ShopInfo.ShopIntroduce = this.TextBoxCompanyIntroduce.Text;
		shopNum1_ShopInfo.Memo = this.TextBoxShopIntroduce.Text;
		shopNum1_ShopInfo.MemLoginID = this.HiddenFieldMemLoginID.Value;
		shopNum1_ShopInfo.MainGoods = this.TextBoxMainGoods.Text;
		int num = shopNum1_ShopInfoList_Action.UpdateShopInfoDetail(shopNum1_ShopInfo);
		if (num > 0)
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("编辑成功!");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("编辑失败!");
		}
	}
}
