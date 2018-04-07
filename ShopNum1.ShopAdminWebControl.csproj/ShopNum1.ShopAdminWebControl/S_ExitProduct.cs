using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ExitProduct : BaseShopWebControl
	{
		private string string_0 = "S_ExitProduct.ascx";
		public S_ExitProduct()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.IsPostBack)
			{
			}
		}
	}
}
