using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopArticleComment_Operate : PageBase, IRequiresSessionState
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
	protected TextBox TextBoxArticle;
	protected Label Label1;
	protected TextBox TextBoxMember;
	protected Label LabelRemark;
	protected TextBox TextBoxContent;
	protected Label LabelReply;
	protected TextBox TextBoxReply;
	protected Button ButtonConfirm;
	protected HtmlInputReset inputReset;
	protected Button ButtonIsAudit1;
	protected Button ButtonIsAudit0;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
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
	private string GoBack
	{
		get;
		set;
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		this.GoBack = ((base.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"].ToString());
		ShopNum1_ShopArticleComment_Action shopNum1_ShopArticleComment_Action = (ShopNum1_ShopArticleComment_Action)LogicFactory.CreateShopNum1_ShopArticleComment_Action();
		DataTable dataTable = shopNum1_ShopArticleComment_Action.SearchByGuid(this.hiddenFieldGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxContent.Text = dataTable.Rows[0]["Content"].ToString();
			this.TextBoxTitle.Text = dataTable.Rows[0]["Title"].ToString();
			this.TextBoxTime.Text = dataTable.Rows[0]["CommentTime"].ToString();
			this.TextBoxUser.Text = dataTable.Rows[0]["MemLoginID"].ToString();
			this.TextBoxIP.Text = dataTable.Rows[0]["IPAddress"].ToString();
			this.TextBoxArticle.Text = dataTable.Rows[0]["ArticleTitle"].ToString();
			string nameById = Common.GetNameById("MemLoginID", "ShopNum1_ShopInfo", "    AND  ShopID='" + dataTable.Rows[0]["ShopID"].ToString() + "'");
			if (!string.IsNullOrEmpty(nameById))
			{
				this.TextBoxMember.Text = nameById;
			}
			this.TextBoxReply.Text = dataTable.Rows[0]["ReplyContent"].ToString();
			if (dataTable.Rows[0]["IsReply"].ToString() == "1")
			{
				this.TextBoxReply.ReadOnly = true;
				this.ButtonConfirm.Enabled = false;
			}
		}
		if (this.GoBack == "Audit")
		{
			this.ButtonConfirm.Visible = false;
			this.inputReset.Visible = false;
			this.TextBoxReply.Visible = false;
			this.LabelReply.Visible = false;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleComment shopNum1_ArticleComment = new ShopNum1_ArticleComment();
		shopNum1_ArticleComment.ReplyUser = base.ShopNum1LoginID;
		shopNum1_ArticleComment.ReplyTime = new DateTime?(DateTime.Now);
		shopNum1_ArticleComment.ReplyContent = this.TextBoxReply.Text.Trim();
		shopNum1_ArticleComment.IsReply = 1;
		ShopNum1_ShopArticleComment_Action shopNum1_ShopArticleComment_Action = (ShopNum1_ShopArticleComment_Action)LogicFactory.CreateShopNum1_ShopArticleComment_Action();
		int num = shopNum1_ShopArticleComment_Action.Update(shopNum1_ArticleComment);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.GoBack == "Audit")
		{
			base.Response.Redirect("ShopArticleCommentAudit_List.aspx");
		}
		else if (this.GoBack == "List")
		{
			base.Response.Redirect("ShopArticleComment_List.aspx");
		}
	}
	protected void ButtonIsAudit1_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopArticleComment_Action shopNum1_ShopArticleComment_Action = (ShopNum1_ShopArticleComment_Action)LogicFactory.CreateShopNum1_ShopArticleComment_Action();
		int num = shopNum1_ShopArticleComment_Action.UpdateAuditNew(this.Page.Request.QueryString["guid"].ToString(), 1);
		if (num > 0)
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
	protected void ButtonIsAudit0_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopArticleComment_Action shopNum1_ShopArticleComment_Action = (ShopNum1_ShopArticleComment_Action)LogicFactory.CreateShopNum1_ShopArticleComment_Action();
		int num = shopNum1_ShopArticleComment_Action.UpdateAuditNew(this.Page.Request.QueryString["guid"].ToString(), 2);
		if (num > 0)
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
