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
public class Main_Admin_MemberActualAuthentication_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected TextBox TextBoxName;
	protected TextBox TextBoxRealName;
	protected TextBox TextBoxCardNum;
	protected TextBox TextBoxTime;
	protected Image ImageIdentityCard;
	protected Image ImageIdentityCardBack;
	protected Label LabelAuditStatus;
	protected DropDownList DropDownListAuditStatus;
	protected HtmlTableRow trID;
	protected Label LabelAuditFailedReason;
	protected HtmlTextArea TextBoxAuditFailedReason;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxAuditFailedReason;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxAuditFailedReason;
	protected Button ButtonConfiirm;
	protected HtmlInputReset inputReset;
	protected Button ButtonBank;
	protected MessageShow MessageShow;
	protected HtmlForm form1;
	public string strstate = string.Empty;
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
		if (!this.Page.IsPostBack)
		{
			this.method_5();
		}
	}
	private void method_5()
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataTable dataTable = shopNum1_Member_Action.SearchMemberInfoByGuid(this.guid);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxAuditFailedReason.Value = dataTable.Rows[0]["auditfailedreason"].ToString();
			this.TextBoxName.Text = dataTable.Rows[0]["MemLoginID"].ToString();
			this.TextBoxRealName.Text = dataTable.Rows[0]["RealName"].ToString();
			this.TextBoxCardNum.Text = dataTable.Rows[0]["IdentityCard"].ToString();
			this.TextBoxTime.Text = dataTable.Rows[0]["IdentificationTime"].ToString();
			this.DropDownListAuditStatus.Items[this.DropDownListAuditStatus.SelectedIndex].Text = this.Is(dataTable.Rows[0]["IdentificationIsAudit"].ToString());
			if (dataTable.Rows[0]["IdentificationIsAudit"].ToString() != "0")
			{
				this.DropDownListAuditStatus.Enabled = false;
				this.ButtonConfiirm.Visible = false;
				this.LabelPageTitle.Text = "查看会员实名认证";
			}
			if (!(dataTable.Rows[0]["IdentificationIsAudit"].ToString() == "0"))
			{
				this.strstate = this.Is(dataTable.Rows[0]["IdentificationIsAudit"].ToString());
			}
			this.ImageIdentityCard.ImageUrl = "~/ImgUpload/ShopCertification/" + dataTable.Rows[0]["IdentityCardImg"].ToString();
			this.ImageIdentityCardBack.ImageUrl = "~/ImgUpload/ShopCertification/" + dataTable.Rows[0]["IdentityCardBackImg"].ToString();
		}
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "1")
		{
			result = "审核已通过";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected void ButtonBank_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MemberActualAuthentication_List.aspx");
	}
	protected void ButtonConfiirm_Click(object sender, EventArgs e)
	{
		if (this.DropDownListAuditStatus.SelectedItem.Selected)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			if (shopNum1_Member_Action.UpdateIdentificationIsAudit(this.guid, this.DropDownListAuditStatus.SelectedItem.Value, this.TextBoxAuditFailedReason.Value) > 0)
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
		this.method_5();
	}
}
