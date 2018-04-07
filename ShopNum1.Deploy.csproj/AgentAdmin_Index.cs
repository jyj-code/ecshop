using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
public class AgentAdmin_Index : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected HtmlAnchor Aweb;
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
	public new string SubstationID
	{
		get;
		set;
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.Page.Request.Cookies["AdminLoginCookie"] != null)
		{
			HttpCookie cookie = this.Page.Request.Cookies["AdminLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			this.SubstationID = httpCookie.Values["SubstationID"].ToString();
		}
		else
		{
			base.Response.Redirect("Login.aspx");
		}
		if (this.SubstationID != "all")
		{
			this.Page.Request.Url.Host.Split(new char[]
			{
				'/'
			})[0].ToString().Substring(3);
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			string domainNameBySubstationID = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(this.SubstationID);
			string str = domainNameBySubstationID + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.ToString().IndexOf('.')) + "/Default.aspx";
			this.Aweb.Attributes["href"] = "http://" + str;
		}
		else
		{
			this.Aweb.Attributes["href"] = "http://" + this.Page.Request.Url.Host;
		}
	}
}
