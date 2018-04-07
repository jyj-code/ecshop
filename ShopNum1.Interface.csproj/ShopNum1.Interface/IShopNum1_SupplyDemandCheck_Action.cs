using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SupplyDemandCheck_Action
	{
		DataTable Search(string addressCode, string associatedMemberID, string isAudit);
		int Update(string guids, string state);
		int Delete(string guids);
		DataSet SearchSupply(string perpagenum, string current_page, string supplyName, string supplyCategoryCode, string supplyAddressCode, string ordername, string isreturcount);
		DataTable GetSupplyDemandNewList(string guid, string showCount, string code);
		DataTable GetSupplyDemandDetail(string guid);
		int AddSupplyDemandComment(ShopNum1_SupplyDemandComment shopNum1_SupplyDemandComment);
		DataTable GetSupplyDemandCommentList(string guid);
		DataTable SearchByType(string code, string showCount);
		DataTable GetTitleByCodeTrade(int TradeType, string code, string cout);
		DataTable GetTitleByCodeRecommend(string code, string cout);
		DataTable GetSupplyDemandDetailOnAndNext(string guid, string onSupplyDemandName, string nextSupplyDemandName);
		DataTable GetSupplyDemandNewList(string showcount);
		DataTable GetSupplyDemandRecommendList(string showcount, string TradeType);
		DataTable SearchList(string codes, string associatedMemberIDs, string titles, string types, string startTimes, string endtimes, string isAudits);
		DataTable Search(int fatherID, int isDeleted, string ShowCount);
		DataTable SearchByCategoryIDFrist(string CategoryCode);
		DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount);
		DataTable Search1(string code, string associatedMemberID, int IsAudit);
	}
}
