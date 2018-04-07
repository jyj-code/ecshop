using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_ShopApplyRank_Action
	{
		DataTable Add(ShopNum1_Shop_ApplyShopRank shopNum1_Shop_ApplyShopRank);
		int Check(string ID, string isaudit);
		int Delete(string ID);
		DataTable GetShopRankApply(string memLoginID, int isAudit);
		int UpdataShopRank(string ID);
		DataTable CheckIsApply(string guid, string memloginID);
		DataTable GetShopRankByGuid(string guid);
		DataTable ShopRankPayInfoByGuid(string guid);
		int UpdataShopRankPayStatusByID(string string_0);
		int UpdataShopRankPayMentByID(string string_0, string PayMentType, string PayMentName);
		int CheckIsPayMentByID(string string_0);
	}
}
