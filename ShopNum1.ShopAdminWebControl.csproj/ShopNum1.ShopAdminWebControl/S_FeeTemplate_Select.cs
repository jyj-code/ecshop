using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopFactory;
using ShopNum1.ShopFeeTemplate;
using ShopNum1.ShopInterface;
using System;
using System.Data;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_FeeTemplate_Select : BaseShopWebControl
	{
		private string string_0 = "S_FeeTemplate_Select.ascx";
		public static DataTable dt_FeeTemplate = null;
		public S_FeeTemplate_Select()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			Shop_FeeTemplate_Action shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
			IShop_ShopInfo_Action shop_ShopInfo_Action = LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopIDAndOpenTimeByMemLoginID = shop_ShopInfo_Action.GetShopIDAndOpenTimeByMemLoginID(this.MemLoginID);
			if (shopIDAndOpenTimeByMemLoginID != null && shopIDAndOpenTimeByMemLoginID.Rows.Count > 0)
			{
				string text = DateTime.Parse(shopIDAndOpenTimeByMemLoginID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
				string text2 = shopIDAndOpenTimeByMemLoginID.Rows[0]["ShopID"].ToString();
				string text3 = text.Split(new char[]
				{
					'-'
				})[0];
				string text4 = text.Split(new char[]
				{
					'-'
				})[1];
				string text5 = text.Split(new char[]
				{
					'-'
				})[2];
				string path = string.Concat(new string[]
				{
					"~/Shop/Shop/",
					text3,
					"/",
					text4,
					"/",
					text5,
					"/shop",
					text2,
					"/xml/PostageTemplate.xml"
				});
				string empty = string.Empty;
				DataTable feesByIDRegion = shop_FeeTemplate_Action.GetFeesByIDRegion(this.Page.Server.MapPath(path), "-1", "000", "-1", out empty);
				if (feesByIDRegion != null)
				{
					DataView dataView = new DataView(feesByIDRegion);
					S_FeeTemplate_Select.dt_FeeTemplate = dataView.ToTable(true, new string[]
					{
						"templateid",
						"templatename",
						"createtime"
					});
				}
			}
		}
	}
}
