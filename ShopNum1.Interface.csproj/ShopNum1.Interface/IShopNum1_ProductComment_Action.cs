using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ProductComment_Action
	{
		DataTable GetProductAll(string ProductName, string ShopID, string createMember, string isaudit, string createTime1, string createTime2);
		DataTable GetProductAll(string ProductName, string ProductGuid, string createMember, string isAudit, string createTime1, string createTime2, string memLoginID);
		DataTable GetProductCommentMemberID(string guid);
		int DeleteProduct(string guids);
		int DeleteProductComment(string guids);
		int UpdateProductAudit(string guids, string state);
		DataTable MemberProductComment(string memloginid, string commenttitle, string productname, string shopid, string isaudit, string createtime1, string createtime2);
		DataTable ShopProductComment(string shopid, string commenttitle, string productname, string productguid, string createmember, string isaudit, string createtime1, string createtime2);
		DataTable ShopProductCommentList(string shopid, string commenttitle, string productname, string isreply, string createmember, string isaudit, string createtime1, string createtime2);
		int Add(ShopNum1_Shop_ProductComment productcomment);
		int Add(List<ShopNum1_Shop_ProductComment> listProductComment);
		int Search(string orderguid, string menlogin);
		DataTable Search(string guid);
		int UpdateComment(string guid, string reply, string replytime, string BuyerAttitude);
		DataTable GetCommentTypeByGuid(string guid);
		int UpdateComment(string guid, string reply, string replytime, string BuyerAttitude, bool IsContinueComment);
		int UpdateProductComment(string guid, string content);
		DataTable CheckIsComment(string orderguid, string menlogin);
		string GetShopIDByName(string name);
	}
}
