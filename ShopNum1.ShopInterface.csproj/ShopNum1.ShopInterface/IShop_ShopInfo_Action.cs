using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_ShopInfo_Action
	{
		DataTable GetShopInfo(string memloginid);
		int UpdateShopInfo(ShopNum1_ShopInfo companyInfo);
		int UpdateLoginDate(string memloginid);
		DataTable GetShopNameByMemloginID(string memLoginID);
		DataTable GetMemLoginInfo(string memloginid);
		int UpdateShopCategory(string shopcategory, string memloginid, string brandguid, string brandname);
		DataSet GetWelcome(string memberloginid);
		DataTable GetShopRank(string memberloginid);
		string GetMemberLoginidByShopid(string shopid);
		DataTable GetMemSimpleByShopID(string shopid);
		DataTable GetShopMetaInfo(string memloginid);
		DataTable GetCateGoryNameBycode(string code);
		DataTable GetCatetoryNamebycode(string code);
		int AddApplyCateGory(ShopNum1_Shop_ApplyCateGory shopApplyCateGory);
		DataTable GetApplyCatetoryList(string shopid, string state, string audtitetime1, string audtitetime2);
		int DelApplyCatetoryByGuid(string guid, string shopid);
		DataTable GetShopRankImage(string shopRank);
		DataTable GetStarGuide(string shopid, int int_0);
		int UpdateCompanyIsAudit(string guid);
		DataTable GetMemInfoByShopID(string shopid);
		DataTable GetShopSimpleByMemID(string memloginid);
		DataTable GetShopRankScoreScope();
		DataTable GetShopRankByMemLoginID(string MemLoginID);
		string IsAllowToAddProduct(string memloginid, string rankguid, string type);
		DataTable GetMaxCountByShopRank(string shoprank, string file);
		DataTable GetOpenTimeByShopID(string shopid);
		DataTable GetShopIDAndOpenTimeByMemLoginID(string memloginid);
		DataTable GetShopCategoryInfoByMemLoginID(string memloginid);
		int UploadingCardPic(ShopNum1_ShopInfo shopNum1_ShopInfo);
		DataTable SearchIsAudit(string shopID, string shopName, string legalPerson, string registrationNum);
		int UpdateCompanAudit(string Guid, string CompanIsAudit, string strCompanAuditFailedReason);
		DataTable GetShopUrlByAddressCode(string AddressCode);
		int UpdateLongLat(string Longitude, string Latitude, string MemberLoginID);
		int UpdateClickCount(string strShopId);
		DataTable GetShopOpentimeByProductGuid(string ProductGuid);
	}
}
