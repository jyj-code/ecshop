using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_RecommendUserLink : BaseMemberWebControl
	{
		private string string_0 = "M_RecommendUserLink.ascx";
		private HtmlInputText htmlInputText_0;
		private HtmlInputHidden htmlInputHidden_0;
		public M_RecommendUserLink()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("inputShopurl");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidMemLoginId");
			this.htmlInputHidden_0.Value = this.MemLoginID;
			this.htmlInputText_0.Value = ShopSettings.siteDomain + "/MemberRegister.aspx?memberid=";
		}
	}
}
