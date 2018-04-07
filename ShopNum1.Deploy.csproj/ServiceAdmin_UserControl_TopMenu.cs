using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class ServiceAdmin_UserControl_TopMenu : UserControl
{
	protected HtmlAnchor htmlAnchor_0;
	protected HtmlAnchor A1;
	protected LinkButton LinkButtonIsExite;
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
	}
	protected void LinkButtonIsExite_Click(object sender, EventArgs e)
	{
		HttpContext.Current.Request.Cookies.Remove("LoginCookie");
		base.Response.Write("<script>window.top.location.href='../ServiceAdmin/Login.aspx';</script>");
	}
}
