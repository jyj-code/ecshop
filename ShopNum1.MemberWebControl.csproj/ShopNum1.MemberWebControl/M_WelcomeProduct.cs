using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_WelcomeProduct : BaseMemberWebControl
	{
		private string string_0 = "M_WelcomeProduct.ascx";
		public M_WelcomeProduct()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
		}
	}
}
