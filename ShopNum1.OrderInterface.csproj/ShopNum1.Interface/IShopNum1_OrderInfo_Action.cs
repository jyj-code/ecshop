using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_OrderInfo_Action
	{
		int Add(ShopNum1_OrderInfo oderInfo, List<ShopNum1_OrderProduct> listOrderProduct);
		int Add(List<ShopNum1_OrderInfo> listoderinfo, List<ShopNum1_OrderProduct> listOrderProduct);
		DataTable SearchOrderInfoByGuid(string guids, string OrderType);
		DataSet GetOrderDetail(string strOrderGuId, string strMemloginId, string strOrderType, string strIsShop);
		DataTable SearchStatus(string guid);
		DataTable SearchAddressByGuid(string guid);
		DataTable GetOrderCountByOrderNumber(string orderNumber);
		int UpdateAddressByGuid(string guid, string name, string email, string address, string postalcode, string string_0, string mobile);
		DataTable SearchOtherByGuid(string guid);
		int UpdateOtherInfo(string guid, string blessCardPrice, string blessCardGuid, string blessCardName, string blessCardContent, string invoiceType, string invoic, string invoiceTitle, string invoiceContent, string clientToSellerMsg, string outOfStockOperate, string sellerToClientMsg);
		DataTable SearchPriceByGuid(string guid);
		string ComputeInvoicePrice(string invoiceTax);
		string ComputeOderPrice(string orderPrice);
		string ComputeShouldPayPrice(string shouldPayPrice);
		int UpdateDispatchInfo(string guid, string dispatchModeGuid, string dispatchModeName, string dispatchPrice, string insurePrice, string regionCode);
		int UpdatePaymentInfo(string guid, string paymentGuid, string paymentName, decimal pPrice, int ispercent);
		int UpdateProduct(string guid, string productPrice, string shopSettingPath, List<ShopNum1_OrderProduct> listOrderProduct);
		int UpdateOrderPrice(string guid, string productPrice, string dispatchPrice, string insurePrice, string paymentPrice, string packPrice, string blessCardPrice, string alreadPayPrice, string surplusPrice, string useScore, string scorePrice, string invoiceTax, string discount, string shouldPayPrice);
		DataTable Search(string guid);
		DataTable SearchOrderPayInfo(string guid);
		DataTable SearchOrderShouldPrice(string guid);
		DataTable SearchOrderSimpleProduct(string guid);
		DataTable SearchOrderSimpleProduct(string guid, string shopid);
		int SetOderStatus1(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime confirmTime);
		int SetPaymentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime payTime, decimal alreadPayPrice, decimal shouldPayPrice);
		int SetPaymentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime payTime, decimal alreadPayPrice, decimal shouldPayPrice, string strTrade_no);
		int SetPaymentStatus0(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice, decimal shouldPayPrice);
		int SetShipmentStatus3(string guid, int oderStatus, int paymentStatus, int shipmentStatus);
		int SetShipmentStatus1(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime dispatchTime, string shipmentNumber);
		int SetShipmentStatus0(string guid, int oderStatus, int paymentStatus, int shipmentStatus, string shipmentNumber);
		int SetShipmentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus);
		int SetOderStatus4(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber);
		int SetOderStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber);
		int SetOderStatus3(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber);
		int Delete(string guid);
		int UpdateDelete(string guid);
		DataTable SearchOrder(string orderNumber);
		DataTable SearchShipmentStatus1(string dispatchTime);
		DataTable SearchByMemLoginID(string memLoginID, int type);
		DataTable GetAllStatus(string guid);
		DataTable GetOrderProductGuidAndByNumber(string orderNumber);
		DataTable SearchOrderInfoByGuid(string guids);
		string GetOrderNumberByGuid(string guid);
		DataTable SearchOrderInfo(string orderNumber);
		DataTable SearchNewOrderByMemLoginID(string memloginID, string showcount);
		int UserDelete(string guids);
		DataTable OrderInfoApplyCheck(string guid);
		DataTable GetMemberBuyProductCount(string strmemberLoginID, string productguid);
		int BackNormalProudctRepertoryCount(string productguid, string buycount);
		int BackSpecificationProudctRepertoryCount(string productguid, string detail, string buycount);
		int BackUsedFavourTicket(string usercode, string memberloginid);
		int UpdateAddress(ShopNum1_OrderInfo orderInfo, string orderguid);
		DataTable SearchOrderProductByOrderGuid(string orderguid);
		DataTable GetOrderCountByGuid(string guid);
		DataTable GetProductTypeByOrderGuid(string guid);
		DataSet CheckOrderState(string ordernumber, string memloginid);
		DataSet CheckTradeState(string TradeID, string memloginid);
		int UpdatePostFee(string postFee, string orderguid);
		DataTable GetOrderInfoByGuid(string guid);
		DataTable GetOrderInfoByMemloginID(string memloginid);
		DataTable GetOrderGuidAndTypeByOrderNum(string string_0);
		DataSet OrderInfoGetSimpleByTradeID(string tradeid, string memloginid);
		int AddOtherOrderInfo(ShopNum1_Shop_OtherOrderInfo shopNum1_Shop_OtherOrderInfo);
		DataTable GetOtherOrderInfoByTradeID(string tradeid, string memloginid);
		DataTable GetOrderGuidByTradeIDAndMemloginid(string tradeid, string memloginid);
		DataSet SingleTradePayMent(string OrderNumber, string memloginid);
		DataTable GetOrderGuidByOrderNumberAndMemloginid(string ordernumber, string memloginid);
		DataTable SearchOrderPayInfo(string guid, string memLoginID);
		DataTable Search1(string guid);
		string GetShopIDByOrderGuid(string orderguid);
		string GetPayMentMemLoginIDByOrderGuid(string orderguid);
		DataTable Search(int isDeleted);
		DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus, string timebegin, string timeend, string PaymentTypeGuid);
		DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus, string ordertype, string timebegin, string timeend, string PaymentTypeGuid);
		int DeleteOrderInfo(string guid);
		int CancelOrder(string guid, string cancelreason, int oderstatus);
		int UpdateOrderMessage(string guid, string message, string messagetype);
		DataSet getProductOrderRecord(string guid);
		DataSet getProductOrderRecord(string guid, string OderStatus);
		DataSet getProductOrderRecord(string productguid, string oderstatus, string memloginid);
		DataTable GetOrderInfoByGuidShop(string guid, string shopid);
		DataTable SearchOrderInfoByProductGuid(string productguid);
		DataTable GetOrderInfo(string guid, string paymentmemloginid);
		int AddOrderCode(ShopNum1_MemberActivate MemberActivate);
		DataTable GetCode(string member, int isinvalid, string code);
		int AddOrder(ShopNum1_OrderInfo orderInfo);
		DataTable GetGroupPriceTotalByOrderInfoGuid(string orderinfoguid);
		DataTable GetProductInfoAndOrderProductInfo(string guid, string shopid);
		DataTable GetOrderInfoAndProductInfo(string guid);
		int UpdataOrderInfoIsMinus(ShopNum1_OrderInfo shopNum1_OrderInfo);
		int UpdateFeePriceByGuid(string dispatchprice, string ispercent, string guid, string IsMinus);
		int OrderInfoLogistics(string guid, string islogistics, string logisticscompany, string logisticscompanycode, string shipmentnumber);
		int UpdatePaymentInfo(string guid, string paymentGuid, string paymentName, decimal pPrice);
		DataTable GetCommentInfoAndSaleNumber(string guid, string shopid, string datatime);
		int UpdateSaleNumAndRepertCtByOrderGuid(string OrderGuid);
		DataTable GetProductGuidAndBuyNum(string orderGuid);
		DataTable GetOrderStatusAndNumberByGuid(string guids);
		int MemberDelete(string guids, string filedName, string filedvalue);
		DataTable SearchByMemLoginID(string productname, string orderstatus, string ordernumber, string timestart, string timeend, string shopid, string memLoginID, int type);
		int UpdataReceivedDays(string orderguid, string shopid, string ismember, string days);
		int UpdataOrderInfoIsMinus(string IsMinus, string DispatchType, string ShouldPayPrice, string Guid, string DispatchPrice);
		DataTable GetRestoreOrderByMemLoginID(string memLoginID);
		DataSet SearchProductOrderRecord(string productguid, string memloginid);
		int SetWaitBuyerPay(string strOderStatus, string ShipmentStatus, string PaymentStatus, string strGuid);
		DataTable Search(string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted, string shopID, string shopName, string orderStatus, string orderType);
		DataTable Search(string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted, string shopID, string shopName, string orderStatus, string orderType, string paymentStatus, string shipmentStatus);
		DataTable SelectList(string strcondition);
		DataTable SelectList(string pagesize, string currentpage, string condition, string resultnum, string strOrderColumn, string strSortV);
		int UpdateByConfirmPay(string strordernum, string strname);
		string SearchOrderInfoByOrderId(string strorderId, string strcolumn);
		DataTable SearchOrderInfoByOrdernum(string ordernum, string orderType);
		int DeleteOrderInfoByOrdernum(string ordernum, int Type, string memloginId);
		int DeleteOrderInfoByAdminOrdernum(string ordernum, int Type, string memloginId);
		DataTable SelectOrderList(string pagesize, string currentpage, string condition, string resultnum, string strProName);
		int UpdateOrderState(string strOrderGuId, string MemlogInId, string strOrderState, string strShipState, string strPayState, string strRefundState, string strIsShop);
		DataTable GetOrderGuIdByTradeId(string strTradeid);
		int UpdateOrderPrice(string strOrderNumber, string strMemloginId, string strNewPrice);
		int GetOrderIdentifyCodeIsEqual(string strOrderNumber, string strIdentifyCode);
		int UpdateCancelOrderInfo(string strCanDate);
		string GetCode(string strOrderGuId);
		DataTable GetLifeOrderCount(string strMemLoginID);
		DataTable GetOrderInfoByCode(string strMemLoginID, string strCode);
		DataTable GetPrintOrderNumbersByShopID(string shopID);
	}
}
