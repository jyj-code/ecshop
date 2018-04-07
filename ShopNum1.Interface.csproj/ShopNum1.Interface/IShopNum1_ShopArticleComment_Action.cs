using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopArticleComment_Action
	{
		int Add(ShopNum1_ArticleComment articleComment);
		DataTable Search(string title, string memLoginID, string name, string CommentTime1, string CommentTime2, string replyTime1, string replyTime2, int isReply, int isAudit, string iPAddress, string shopID);
		DataTable SearchByGuid(string guid);
		int Update(ShopNum1_ArticleComment articleComment);
		int UpdateAudit(string guids, int isAudit);
		int Delete(string guids);
		DataTable Search(string memLoginID, int isDeleted);
		DataTable Search(string articleGuid, int isReply, int isAudit, int count);
		DataTable MemberShopArticleComment(string memloginid);
		int DeleteShopArticleComment(string guid);
		DataTable GetMemloginIDByGuid(string guid);
		DataTable SearchShopArticleComment(string memberloginid, string commenttitle, string articletitle, string articlememloginid, string isaudit, string createtime1, string createtime2);
		int Shop_NewsCommentAdd(ShopNum1_Shop_NewsComment Shop_NewsComment);
		DataTable GetShopArticleCommentByGuid(string articleguid);
	}
}
