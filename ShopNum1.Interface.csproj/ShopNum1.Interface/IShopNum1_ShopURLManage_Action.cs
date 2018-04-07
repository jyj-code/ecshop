using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopURLManage_Action
	{
		DataTable SelectGoUrl(string domain);
		int Add(ShopNum1_ShopURLManage shopNum1_ShopURLManage);
		int Update(ShopNum1_ShopURLManage shopNum1_ShopURLManage);
		int UpdateIsAudit(string strID, string isAudit);
		DataTable UpdateSearch(string MemLoginID);
		DataTable Search(string MemLoginID, string isAudit);
		DataTable CheckDoMain(string strDoMain);
		int Delete(string strID);
		DataTable GetEditInfo(string strID);
		int Update(string strID, string strDoMain, string siteNumber);
		DataTable GetShopLoginID(string guids);
		DataTable GetShopValidity(string MemLoginID);
		DataTable Search(string MemLoginID);
		DataTable SearchByID(string string_0);
		DataTable UrlWriteShopDoMain(string domain);
	}
}
