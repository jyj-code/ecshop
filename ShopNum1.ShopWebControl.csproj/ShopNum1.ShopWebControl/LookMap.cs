using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class LookMap : BaseWebControl
	{
		private string string_0 = "LookMap.ascx";
		public LookMap()
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
