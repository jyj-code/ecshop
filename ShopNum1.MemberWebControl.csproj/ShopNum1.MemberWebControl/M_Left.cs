using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_Left : BaseMemberWebControl
	{
		private string string_0 = "M_Left.ascx";
		public M_Left()
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
