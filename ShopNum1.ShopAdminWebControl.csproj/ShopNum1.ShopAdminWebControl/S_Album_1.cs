using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using System;
using System.Data;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Album_1 : BaseShopWebControl
	{
		private string string_0 = "S_Album_1.ascx";
		public static DataTable dt_Album = null;
		private string string_1 = null;
		public S_Album_1()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.string_1 = ShopNum1.Common.Common.ReqStr("sort");
			if (!this.Page.IsPostBack)
			{
				if (ShopNum1.Common.Common.ReqStr("typeid") != "")
				{
					this.method_0();
				}
				this.method_1();
			}
		}
		private void method_0()
		{
			Shop_ImageCategory_Action shop_ImageCategory_Action = new Shop_ImageCategory_Action();
			shop_ImageCategory_Action.Delete(ShopNum1.Common.Common.ReqStr("typeid"));
		}
		private void method_1()
		{
			Shop_ImageCategory_Action shop_ImageCategory_Action = new Shop_ImageCategory_Action();
			S_Album_1.dt_Album = shop_ImageCategory_Action.Select(this.string_1, this.MemLoginID);
		}
	}
}
