using ShopNum1.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
public class Admin_Index : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected HtmlAnchor htmlAnchor_0;
	protected HtmlGenericControl box_leftidSub2;
	protected HtmlGenericControl seosz;
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
			try
			{
				base.CheckNoPowerLogin();
			}
			catch (Exception)
			{
				base.Response.Redirect("Login.aspx");
			}
		}
		if (!(ShopSettings.GetValue("SubstationCityMode") == "1"))
		{
		}
	}
}
