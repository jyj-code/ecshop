using FredCK.FCKeditorV2;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_CategoryComment_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxTitle;
	protected Label LabelWebSite;
	protected TextBox TextBoxTime;
	protected Label LabelOrderID;
	protected TextBox TextBoxUser;
	protected Label LabelLogo;
	protected TextBox TextBoxIP;
	protected Label LabelKeywords;
	protected FCKeditor FCKeditorContent;
	protected Label Label1;
	protected TextBox TextBoxMember;
	protected Label LabelRemark;
	protected TextBox TextBoxContent;
	protected Label Label2;
	protected TextBox TextBoxReplyContent;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	private ShopNum1_CategoryComment_Action shopNum1_CategoryComment_Action_0 = (ShopNum1_CategoryComment_Action)LogicFactory.CreateShopNum1_CategoryComment_Action();
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack)
		{
			this.DataBind();
		}
	}
	public new void DataBind()
	{
		DataTable categoryCommentByGuid = this.shopNum1_CategoryComment_Action_0.GetCategoryCommentByGuid(this.hiddenFieldGuid.Value);
		this.TextBoxContent.Text = categoryCommentByGuid.Rows[0]["Content"].ToString();
		this.TextBoxTitle.Text = categoryCommentByGuid.Rows[0]["Title"].ToString();
		this.TextBoxTime.Text = categoryCommentByGuid.Rows[0]["CreateTime"].ToString();
		this.TextBoxUser.Text = categoryCommentByGuid.Rows[0]["CreateMember"].ToString();
		this.TextBoxIP.Text = categoryCommentByGuid.Rows[0]["CreateIP"].ToString();
		this.FCKeditorContent.Value = HttpContext.Current.Server.HtmlDecode(categoryCommentByGuid.Rows[0]["CategoryInfo"].ToString());
		this.TextBoxMember.Text = categoryCommentByGuid.Rows[0]["AssociatedMemberID"].ToString();
		this.TextBoxReplyContent.Text = categoryCommentByGuid.Rows[0]["Reply"].ToString();
		if (categoryCommentByGuid.Rows[0]["Reply"].ToString() != string.Empty)
		{
			this.TextBoxReplyContent.ReadOnly = true;
			this.ButtonConfirm.Enabled = false;
		}
		string a = (this.Page.Request.QueryString["type"] == null) ? "-1" : this.Page.Request.QueryString["type"];
		if (a == "audit")
		{
			this.TextBoxReplyContent.ReadOnly = true;
			this.ButtonConfirm.Visible = false;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		int num = this.shopNum1_CategoryComment_Action_0.CategoryCommentReply(this.hiddenFieldGuid.Value.Replace("'", ""), this.TextBoxReplyContent.Text.Trim());
		if (num > 0)
		{
			this.Page.Response.Redirect("CategoryComment_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		string a = (this.Page.Request.QueryString["type"] == null) ? "-1" : this.Page.Request.QueryString["type"];
		if (a == "audit")
		{
			this.Page.Response.Redirect("CategoryCommentAudit_List.aspx");
		}
		else if (a == "list")
		{
			this.Page.Response.Redirect("CategoryComment_List.aspx");
		}
	}
}
