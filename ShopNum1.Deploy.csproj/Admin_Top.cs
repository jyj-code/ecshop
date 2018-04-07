using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Top : Page, IRequiresSessionState
{
	protected TextBox TextBoxSearch;
	protected Button ButtonSearch;
	protected Panel panel;
	protected HtmlForm ctl00;
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
		if (!this.Page.IsPostBack && this.Page.Request.Cookies["AdminLoginCookie"] == null)
		{
			base.Response.Write("<script>window.top.location.href='Login.aspx'</script>");
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		string str = this.TextBoxSearch.Text.ToString();
		if (this.TextBoxSearch.Text.ToString() != null)
		{
			this.Page.Response.Redirect("SearchFeature.aspx?name=" + str);
		}
	}
}
