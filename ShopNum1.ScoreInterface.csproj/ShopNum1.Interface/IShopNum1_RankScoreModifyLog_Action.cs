using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_RankScoreModifyLog_Action
	{
		int OperateScore(ShopNum1_RankScoreModifyLog rankScoreModifyLog);
		string GetMemberRankGuidByRankScore(int rankScore);
		string GetMemberRankGuidByCostMoney(decimal costMoney);
		string GetMemberRankGuidByTradeCount(int tradeCount);
		DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted);
		DataTable Search(string memLoginID, int isDeleted);
	}
}
