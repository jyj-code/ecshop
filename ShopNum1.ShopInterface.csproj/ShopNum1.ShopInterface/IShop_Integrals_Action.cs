using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Integrals_Action
	{
		int AddShopIntegral(ShopNum1_Shop_Integral shop_Integral);
		int DeleteIntegral(string guid, string isaudit);
		DataTable GetIntegralInfo(string guid);
		DataTable GetIntegralList(string memloginid, string isaudit);
		DataTable SearchIntegralCostList(string shopid, string scorestate);
	}
}
