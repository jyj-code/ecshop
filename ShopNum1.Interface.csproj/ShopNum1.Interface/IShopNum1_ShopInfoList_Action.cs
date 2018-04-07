using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopInfoList_Action
	{
		int Add(ShopNum1_ShopInfo shopNum1_ShopInfo);
		int UpdateShopInfo(ShopNum1_ShopInfo shopNum1_ShopInfo);
		int UpdateShopInfoDetail(ShopNum1_ShopInfo shopNum1_ShopInfo);
		void UpdateDate(string guid, string time);
		int Delete(string guids);
		int Update(string guid, ShopNum1_ShopInfo shopNum1_ShopInfo);
		DataTable Search(string ShopName, string Name, string memberLoginID, string type, string addressCode, string Ishot, string IsVisits, string IsRecommend, string IsExpires, string IdentityIsAudit, string CompanIsAudit, string shoprank, string shoprepution, string shopensure, string IsAudit, string startTime, string endTime);
		DataTable GetEditInfo(string memberLoginId);
		DataTable SearchInfoList2(string ShopName, string Name, string memberLoginID, string type, string addressCode, string Ishot, string IsVisits, string IsRecommend, string IsExpires, string IdentityIsAudit, string CompanIsAudit, string shoprank, string shoprepution, string shopensure, string IsAudit, string startTime, string endTime, string SubstationID);
		int Update(string guid, string string_0, string field);
		int RegistShopMember(ShopNum1_ShopInfo shopNum1_ShopInfo);
		int CheckShopName(string name);
		DataSet SearchShopList(string pageindex, string pagesize, string regioncode, string shopcategoryid, string name, string memberloginid);
		DataTable SearchEspecialShopList(string pagesize, string field);
		DataTable SearchNewsShopList(string pagesize);
		DataTable SearchShopClickCount(string shophost, string shopname, string startdate, string enddate);
		DataTable SearchShopAmount(string startdate, string enddate);
		int UpdateShopState(string guid, string field, string string_0);
		int GetShopIdMax();
		string GetOpenTime(string memLoginID);
		string GetMemberType(string memLoginID);
		DataTable GetShopInfoByGuid(string guid);
		DataTable GetShopIDByMemLoginID(string MemLoginID);
		int UpdateMemberType(string guids, int memberType);
		DataTable GetEnsureImagePathBymemberLoginID(string memberLoginID);
		DataTable GetAllShopInfoByGuid(string guid);
		DataTable GetNewShopInfoByShowCount(string ShowCount);
		int UpdateShopReputationByMemLoginID(string MemLoginID, int score);
		DataTable GetMemberInfoByGuid(string guid);
		DataTable CheckShopURLIsRepeat(string shopurl);
		int UpdataShopURLByGuid(string guid, string shopurl);
		DataTable GetShopCategoryApplyInfo(string ShopName, string memberLoginID, string ShopCategoryCode, string IsAudit, string StartTime, string EndTime);
		int DeleteShopCategoryApply(string guids);
		int UpdataShopCategoryApplyIsAudit(string guids, string isAudit);
		DataTable GetShopCategoryInfoByGuid(string guid);
		int UpdateShopCategoryAndBrandByGuids(string guids, string ShopCategoryName, string ShopCategoryCode, string BrandName, string BrandGuid);
		string GetShopURLByShopID(string shopid);
		string GetShopPayMentType(string memloginid);
		int InsertShopNav(string shopid);
		string GetShopGuid(string memLoginID);
		int Delete(string guid, string memLoginID);
		int GetShopCountByCode(string code);
		DataTable Search(string memberLoginID);
		DataTable GetShopOpentimeByMemLoginID(string MemLoginID);
		string GetShopURLByAddressCode(string addressCode);
		DataSet SearchShopList(string addresscode, string ShopCategoryID, string ordername, string soft, string shopName, string memberid, string perpagenum, string current_page, string isreturcount);
		DataTable SearchEspecialShop(string pagesize, string field);
		string GetShopid(string memLoginID);
		DataTable GetShopUrlByAddressCode(string AddressCode);
		DataTable GetShopRankByMemLoginID(string MemLoginID);
		DataTable GetOpenTimeByShopID(string shopid);
		DataTable SearchShopSalesClickCount(string shophost, string shopname, string startdate, string enddate);
		DataTable SearchAllMemID(int IsDeleted);
	}
}
