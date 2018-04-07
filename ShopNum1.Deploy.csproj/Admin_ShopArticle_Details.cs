using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ShopArticle_Details : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected Label LabelPageTitle;
	protected Localize LocalizeAssociatedCategoryGuid;
	protected TextBox TextBoxCategoryGuid;
	protected Localize LocalizeTitle;
	protected TextBox TextBoxTitle;
	protected Localize LocalizeCreateTime;
	protected TextBox TextBoxCreateTime;
	protected Localize LocalizeMember;
	protected TextBox TextBoxMemberLoginID;
	protected Localize LocalizeKeywords;
	protected TextBox TextBoxKeywords;
	protected Localize LocalizeContent;
	protected TextBox FCKeditorConten;
	protected Button LinkButton1;
	protected Button ButtonCancelAudit;
	protected Button ButtonGoBack;
	protected MessageShow MessageShow;
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
		string guid = base.Request.QueryString["guid"];
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)LogicFactory.CreateShopNum1_ArticleCheck_Action();
		DataTable dataTable = shopNum1_ArticleCheck_Action.SearchDetailsByGuid(guid);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxCreateTime.Text = dataTable.Rows[0]["CreateTime"].ToString();
			this.TextBoxTitle.Text = dataTable.Rows[0]["Title"].ToString();
			this.FCKeditorConten.Text = this.Page.Server.HtmlDecode(dataTable.Rows[0]["Content"].ToString());
			this.TextBoxKeywords.Text = dataTable.Rows[0]["Keywords"].ToString();
			this.TextBoxCategoryGuid.Text = dataTable.Rows[0]["name"].ToString();
			this.TextBoxMemberLoginID.Text = dataTable.Rows[0]["MemLoginID"].ToString();
			if (dataTable.Rows[0]["isAudit"].ToString() == "1" || dataTable.Rows[0]["isAudit"].ToString() == "2")
			{
				this.LinkButton1.Visible = false;
				this.ButtonCancelAudit.Visible = false;
			}
		}
	}
	protected void ButtonGoBack_Click(object sender, EventArgs e)
	{
		if (this.Page.Request.QueryString["type"] != null && this.Page.Request.QueryString["type"].ToString() == "check")
		{
			this.Page.Response.Redirect("ShopArticle_Check.aspx");
		}
		else
		{
			this.Page.Response.Redirect("ShopArticle_List.aspx");
		}
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)LogicFactory.CreateShopNum1_ArticleCheck_Action();
		if (shopNum1_ArticleCheck_Action.UpdateAudit(this.Page.Request.QueryString["guid"].ToString(), 1) > 0)
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
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)LogicFactory.CreateShopNum1_ArticleCheck_Action();
		if (shopNum1_ArticleCheck_Action.UpdateAudit(this.Page.Request.QueryString["guid"].ToString(), 2) > 0)
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
