using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_SellGoods1 : BaseShopWebControl
	{
		private string string_0 = "S_SellGoods1.ascx";
		public static DataTable dt_ParentType = null;
		public S_SellGoods1()
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
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			S_SellGoods1.dt_ParentType = shopNum1_ProductCategory_Action.Select_ProductCategory();
		}
	}
}
