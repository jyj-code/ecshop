using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_VideoComment_Action
	{
		int Delete(string guids);
		DataTable Search(string guid);
		DataTable SearchByGuid(string guid);
		DataTable Search(string MemLoginID, string VideoTitle, int IsAudit, string SendTime1, string SendTime2);
		int UpdateAudit(string StrGuids);
		int UpdateAuditNot(string StrGuids);
		DataTable GetVideoCommentList(string guid);
		DataTable GetVideoCommentList(string guid, int isAudit);
		int Add(ShopNum1_VideoComment videoComment_Action);
		DataSet GetPageVideoComment(string VideoGuid, string perpagenum, string current_page, string isreturcount);
	}
}
