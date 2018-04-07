using System;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Collect_Action
	{
		int AddShopCollect(string memloginid, string shopid);
		int AddProductCollect(string memloginid, string productguid, string shopID, string isAttention, string shopPrice, string productName, string sellLoginID);
		int ProductCollectNum(string guid);
		int ShopCollectNum(string memLoginID);
	}
}
