using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ArticleCheck_Action
	{
		DataTable Search(string title, string shopID, string startdate, string enddate, int IsAudit, int isDeleted);
		DataTable GetEditInfo(string guid);
		int Delete(string guids);
		int UpdateAudit(string guids, int isAudit);
		DataTable SearchDetailsByGuid(string guid);
	}
}
