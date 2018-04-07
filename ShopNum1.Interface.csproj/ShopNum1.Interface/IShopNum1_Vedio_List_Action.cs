using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Vedio_List_Action
	{
		int UpdateAudit(string guids, int isAudit);
		int Delete(string guids);
		DataTable Search(string title, string memLoginID, string commentTime1, string commentTime2, int isAudit);
		DataTable GetVedioAll(string commentTitle, string VedioName, string createMember, string isAudit, string createTime1, string createTime2, string memLoginID);
	}
}
