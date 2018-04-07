using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Rank_Action
	{
		DataTable Search(int isDeleted);
		DataTable ShopRankSearch(string name);
		DataTable Search(string guid, int isDeleted);
		int Add(ShopNum1_ShopRank shopRank);
		int Update(ShopNum1_ShopRank shopRank);
		int Delete(string guids);
		DataTable GetDefaultRank();
		int EditIsDefault();
		DataTable GetShopRankByGuid(string guid);
		DataTable GetShopRank();
		DataTable GetTemplateByRankGuid(string guid);
		DataTable GetShopRankInfoByMemLoginID(string memloginid);
	}
}
