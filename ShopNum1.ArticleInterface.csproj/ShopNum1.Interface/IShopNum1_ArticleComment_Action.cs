using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ArticleComment_Action
	{
		int Add(ShopNum1_ArticleComment articleComment);
		DataTable Search(string guid, string ArticleTitle, string memLoginID, string title, string sendTime1, string sendTime2, string replyTime1, string replyTime2, int isReply, int isAudit, int isDeleted, string IP);
		DataTable SearchByGuid(string guid);
		int Update(ShopNum1_ArticleComment articleComment);
		int UpdateAudit(string guids, int isAudit);
		int Delete(string guids);
		DataTable Search(string memLoginID, int isDeleted);
		DataTable Search(string articleGuid, int isReply, int isAudit, int count);
		int UpdateScoreByCommentArticle(string memloginid, string rankscore, string score);
		DataTable GetArticleCommentInfoByGuid(string guid);
		DataTable SearchArticleCommentInfo(string memberloginid, string commenttitle, string articletitle, string isaudit, string createtime1, string createtime2);
	}
}
