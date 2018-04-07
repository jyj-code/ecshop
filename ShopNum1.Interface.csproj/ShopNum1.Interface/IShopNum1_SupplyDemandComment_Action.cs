using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SupplyDemandComment_Action
	{
		DataTable GetSupplyDemandCommentAll(string commentTitle, string SupplyDemandName, string SupplyDemandGuid, string createMember, string isAudit, string CreateTime1, string CreateTime2);
		DataTable GetSupplyDemandCommentAll(string commentTitle, string SupplyDemandName, string SupplyDemandGuid, string createMember, string isAudit, string createTime1, string createTime2, string createMerber);
		int DeleteSupplyDemandComment(string guids);
		int ReplySupplyDemandComment(string guid, string content);
		int UpdateSupplyDemandCommentAudit(string guids, string state);
		string GetSupplyDemandGuid(string guid);
		DataSet GetSupplyDemandCommentList(string perpagenum, string current_page, string guid, string ordername, string isreturcount);
		DataTable GetSupplyDemandAssociatedMemberID(string guid);
		int AddSupplyDemandComment(ShopNum1_SupplyDemandComment shopNum1_SupplyDemandComment);
		DataTable GetSupplyDemandCommentList(string guid);
		DataTable MemberSupplyDemandComment(string memberloginid, string commenttitle, string supplydemandname, string publishMemLoginID, string isaudit, string createtime1, string createtime2);
	}
}
