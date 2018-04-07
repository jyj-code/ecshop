using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class AgentAdmin_LoginExit : PageBase, IRequiresSessionState
{
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
		if (this.Page.Request.Cookies["AdminLoginCookie"] != null)
		{
			this.Page.Request.Cookies["AdminLoginCookie"].Expires = DateTime.Now.AddDays(-5.0);
			this.Page.Response.Cookies.Add(this.Page.Request.Cookies["AdminLoginCookie"]);
			base.Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
		}
	}
}
