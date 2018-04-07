using ShopNum1.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_IisManager : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Button ButtonIISRest;
	protected Button ButtonIisRecycle;
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
	}
	protected void ButtonIISRest_Click(object sender, EventArgs e)
	{
		Utils.RestartIISProcess();
		this.method_5();
	}
	protected void ButtonIisRecycle_Click(object sender, EventArgs e)
	{
		Utils.RestartIISProcess();
		this.method_5();
	}
	private void method_5()
	{
		Utils.RestartIISProcess();
		base.RegisterStartupScript("PAGE", "window.location.href=window.location.href ;");
	}
}
