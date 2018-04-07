using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopActualAuthentication_Detai : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected TextBox TextBoxShopID;
	protected TextBox TextBoxShopName;
	protected TextBox TextBoxLegalPerson;
	protected TextBox TextBoxRegistrationNum;
	protected Image ImageIdentityCard;
	protected Label LabelAuditFailedReason;
	protected TextBox TextBoxAuditFailedReason;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxAuditFailedReason;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxAuditFailedReason;
	protected HtmlGenericControl divShowHide;
	protected Label LabelAuditStatus;
	protected DropDownList DropDownListAuditStatus;
	protected HtmlTableRow trID;
	protected TextBox TextBox;
	protected Button ButtonConfiirm;
	protected HtmlInputReset inputReset;
	protected Button ButtonBank;
	protected MessageShow MessageShow;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_5;
	public string guid
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
		base.CheckLogin();
		this.guid = this.Page.Request.QueryString["Guid"].ToString();
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable allShopInfoByGuid = shopNum1_ShopInfoList_Action.GetAllShopInfoByGuid(this.guid);
		if (allShopInfoByGuid != null && allShopInfoByGuid.Rows.Count > 0)
		{
			this.TextBoxShopName.Text = allShopInfoByGuid.Rows[0]["ShopName"].ToString();
			this.TextBoxShopID.Text = "shop" + allShopInfoByGuid.Rows[0]["ShopID"].ToString();
			this.TextBoxRegistrationNum.Text = allShopInfoByGuid.Rows[0]["RegistrationNum"].ToString();
			this.TextBoxLegalPerson.Text = allShopInfoByGuid.Rows[0]["LegalPerson"].ToString();
			this.ImageIdentityCard.ImageUrl = "~/ImgUpload/ShopCertification/" + allShopInfoByGuid.Rows[0]["BusinessLicense"].ToString();
		}
	}
	protected void ButtonBank_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopActualAuthentication_Audit.aspx");
	}
	protected void ButtonConfiirm_Click(object sender, EventArgs e)
	{
		if (this.DropDownListAuditStatus.SelectedItem.Selected)
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			if (shop_ShopInfo_Action.UpdateCompanAudit(this.guid.Replace("'", ""), this.DropDownListAuditStatus.SelectedItem.Value, this.TextBoxAuditFailedReason.Text.Trim().Replace("'", "")) > 0)
			{
				this.MessageShow.ShowMessage("Audit2Yes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("Audit2No");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void DropDownListAuditStatus_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListAuditStatus.SelectedItem.Value == "1")
		{
			this.divShowHide.Visible = false;
		}
		else
		{
			this.divShowHide.Visible = true;
		}
	}
}
