using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Refund_Action
	{
		int Add(ShopNum1_Refund shopNum1_Refund);
		int Update(ShopNum1_Refund shopNum1_Refund);
		DataTable SelectRefundInfo(string strId, string strMeloginId, string strIsShop);
		int Delete(string string_0);
		DataTable GetRefundList(int ID);
		DataTable GetRefundList(string memloginid, string orderid, string productguid);
		bool CheckIsRefundApply(string memloginid, string orderid, string productguid);
		DataTable GetRefundStatus(string shopid, string orderguid, string productguid);
		DataTable GetProductPriceAndShopID(string memloginid, string orderingoGuid, string productguid);
		DataTable GetRefundListByShopID(string shopID, string orderid, string productguid);
		DataTable GetProductPriceAndMemLoginID(string shopid, string orderingoGuid, string productguid);
		int ShopOnPassRefund(ShopNum1_Refund shopNum1_Refund);
		DataTable GetOnPassRefund(string shopid, string orderingoGuid, string productguid);
		string GetOrderStatus(string orderguid);
		int UpdateRefundStatus(string MemloginId, string onPassreason, string productguid, string status);
		int UpdateRefundStatus(string orderingoGuid, string productguid, string status, string adressName, string adressValue);
		int UpdateProductGroupPrice(string ProductGuid, string OrderInfoGuid, string MemLoginID, string ShopID);
		DataTable Search(string orderID, string ModifyUser, string ShopID, string MemLoginID, string ShouldPayPrice1, string ShouldPayPrice2, string OrderCreateTime1, string OrderCreateTime2, string isAdmin);
		DataTable GetOrderRefundInfo(int int_0);
		int AdminUpdateRefundStatus(string string_0, string status, string content, string CreateUser);
		int UpdateRefundStatusIsAdmin(string orderingoGuid, string productguid, string status);
		string IsCheckRefund(string orderingoGuid);
		DataTable GetRefund(string orderingoGuid);
		int RefundUpdateAdvancePaymentMem(string memloginid, string shopid, decimal payprice, string orderguid, string productguid, int status);
		DataTable SelectRefundList(string pagesize, string currentpage, string condition, string resultnum);
		int DeleteRefundByOrId(string strOrderId);
	}
}
