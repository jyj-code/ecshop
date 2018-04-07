using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class DefaultAdminCheck : BaseWebControl
	{
		private string string_0 = "DefaultAdminCheck";
		public DefaultAdminCheck()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.Cookies["AdminLoginCookie"] == null)
			{
				this.Page.Response.Write("<script type=\"text/javascript\">window.location.href='/Main/admin/login.aspx';</script>");
			}
		}
	}
}
