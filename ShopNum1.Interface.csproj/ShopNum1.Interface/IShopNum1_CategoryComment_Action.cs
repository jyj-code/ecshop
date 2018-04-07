using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_CategoryComment_Action
	{
		DataTable GetCategoryCommentAll(string commentTitle, string CategoryTitle, string CategoryInfoGuid, string createMember, string isAudit, string CreateTime1, string CreateTime2);
		DataTable GetCategoryCommentAll(string commentTitle, string CategoryTitle, string CategoryInfoGuid, string createMember, string isAudit, string createTime1, string createTime2, string CreateMember);
		int DeleteCategoryComment(string guids);
		int UpdateCategoryCommentAudit(string guids, string state);
		string GetCategoryGuid(string guid);
		DataTable GetCategoryCommentByGuid(string guid);
		DataSet GetCommentList(string perpagenum, string current_page, string guid, string ordername, string isreturcount);
		DataTable GetCateGoryAssociatedMemberID(string guid);
		int Add(ShopNum1_CategoryComment categoryComment);
		DataTable GetCommentList(string guid);
		DataTable MemberCategoryComment(string memberloginid, string commenttitle, string categorytitle, string createmember, string isaudit, string createtime1, string createtime2);
		int CategoryCommentReply(string guid, string content);
	}
}
