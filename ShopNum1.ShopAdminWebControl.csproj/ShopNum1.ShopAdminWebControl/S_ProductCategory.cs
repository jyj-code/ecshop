using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using System;
using System.Data;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ProductCategory : BaseShopWebControl
	{
		private string string_0 = "S_ProductCategory.ascx";
		public static DataTable dt_ProdcutCategory = null;
		public S_ProductCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (!this.Page.IsPostBack)
			{
				Shop_ProductCategory_Action shop_ProductCategory_Action = new Shop_ProductCategory_Action();
				S_ProductCategory.dt_ProdcutCategory = shop_ProductCategory_Action.Search(0, this.MemLoginID);
			}
		}
	}
}
