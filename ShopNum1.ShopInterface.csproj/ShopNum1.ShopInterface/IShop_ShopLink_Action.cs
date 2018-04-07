using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_ShopLink_Action
	{
		int Add(ShopNum1_Shop_Link shopNum1_Shop_Link);
		DataTable Edit(string guid);
		int Updata(ShopNum1_Shop_Link shopNum1_Shop_Link);
		int Delete(string guids);
		DataTable Search(string showCount);
		DataTable GetAllShopMemLoginID();
		DataTable CheckMemLoginID(string memLoginID);
		DataTable Show(string MemLoginID, string showCount);
	}
}
