using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class MemberRegProtocol : BaseWebControl
	{
		private string string_0 = "MemberRegProtocol.ascx";
		private Label label_0;
		public MemberRegProtocol()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_0 = (Label)skin.FindControl("labelRegProtocol");
			if (!this.Page.IsPostBack)
			{
				this.GetRegProtocolInfo();
			}
		}
		protected void GetRegProtocolInfo()
		{
			this.label_0.Text = this.Page.Server.HtmlDecode(ShopSettings.GetValue("RegProtocol"));
		}
	}
}
