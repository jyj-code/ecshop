using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_MemberActualAuthentication_Detai : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected TextBox TextBoxName;
	protected TextBox TextBoxRealName;
	protected TextBox TextBoxCardNum;
	protected TextBox TextBoxTime;
	protected Image ImageIdentityCard;
	protected Image ImageIdentityCardBack;
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
	public string guid
	{
		get;
		set;
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		this.guid = this.Page.Request.QueryString["Guid"].Replace("'", "");
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataTable dataTable = shopNum1_Member_Action.SearchMemberInfoByGuid(this.guid);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxName.Text = dataTable.Rows[0]["MemLoginID"].ToString();
			this.TextBoxRealName.Text = dataTable.Rows[0]["RealName"].ToString();
			this.TextBoxCardNum.Text = dataTable.Rows[0]["IdentityCard"].ToString();
			this.TextBoxTime.Text = dataTable.Rows[0]["IdentificationTime"].ToString();
			this.ImageIdentityCard.ImageUrl = "~/ImgUpload/ShopCertification/" + dataTable.Rows[0]["IdentityCardImg"].ToString();
			this.ImageIdentityCardBack.ImageUrl = "~/ImgUpload/ShopCertification/" + dataTable.Rows[0]["IdentityCardBackImg"].ToString();
		}
	}
	protected void ButtonBank_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MemberActualAuthentication_Audit.aspx");
	}
	protected void ButtonConfiirm_Click(object sender, EventArgs e)
	{
		if (this.DropDownListAuditStatus.SelectedItem.Selected)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			if (shopNum1_Member_Action.UpdateIdentificationIsAudit(this.guid, this.DropDownListAuditStatus.SelectedItem.Value, this.TextBoxAuditFailedReason.Text, this.TextBoxName.Text.Trim().Replace("'", "")) > 0)
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
