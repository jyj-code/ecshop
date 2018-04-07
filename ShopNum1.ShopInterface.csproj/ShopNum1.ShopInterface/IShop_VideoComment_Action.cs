using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_VideoComment_Action
	{
		DataTable Search(string MemLoginID, string VideoTitle, int IsAudit, string SendTime1, string SendTime2);
		int Delete(string guids);
		DataTable Search(string guid);
		DataTable SearchByGuid(string guid);
		int UpdateAudit(string StrGuids);
		int UpdateAuditNot(string StrGuids);
		DataTable GetVideoCommentList(string guid);
		int Add(ShopNum1_Shop_VideoComment videoComment_Action);
	}
}
