using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Comment_Action
	{
		int AddComment(ShopNum1_Comment comment);
		int DeleteComment(string guid);
		DataTable CommentListStatReport(string memberid);
		DataTable SearchCommentList(string memberid, string membertype, string commenttype);
	}
}
