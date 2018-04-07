using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_ProductComment_Action
	{
		DataTable CommentListStatReport(string shopid, string guid);
		DataTable CommentList(string memberid, string commenttype, string guid);
		DataSet ProductCommentList(string productguid);
		DataSet ProductCommentListByGuidAndMemLoginID(string productguid, string memloginid, string strType);
		int ReplyComment(string guid, string reply);
		DataTable ShopCommentInfo(string guid);
		DataTable ShopComment(string type, string timetype, string shopid);
		DataTable ShopComment(string type, string shopid);
		string GetShopIDByName(string name);
		DataSet ShopCommentNew(string shopid, string type, string ordertype, string sort, string perpagenum, string current_page, string isreturcount);
		DataTable GetShopCommentCount(string strMemloginId, string strIsShop);
		DataTable SelectShopComment(string strPageSize, string strCurrentPage, string strCondition, string strResultnum);
		string GetGoodRate(string strShopLoginId, string strType);
		DataTable SelectShopDetailComment(string strPageSize, string strCurrentPage, string strCondition, string strResultnum, string strShopID, string strType, string strProductGuID);
		DataTable GetCommentDetail(string strOrderguId, string strMemloingId);
		int UpdateContinueComment(string strOrderguId, string strMemloingId, string strComment, string strProductGuID);
	}
}
