using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_OrderInfo_Action
	{
		DataTable Search(int isDeleted);
		DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus, string timebegin, string timeend, string PaymentTypeGuid);
		DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus, string ordertype, string timebegin, string timeend, string PaymentTypeGuid);
		int DeleteOrderInfo(string guid);
		int CancelOrder(string guid, string cancelreason, int oderstatus);
		int UpdateOrderMessage(string guid, string message, string messagetype);
		DataSet getProductOrderRecord(string guid);
		DataSet getProductOrderRecord(string guid, string OderStatus);
		DataSet getProductOrderRecord(string productguid, string oderstatus, string memloginid);
		DataTable SearchOrderInfoByGuid(string guids);
		DataTable SearchOrderInfoByProductGuid(string productguid);
		DataTable GetOrderInfo(string guid, string paymentmemloginid);
		DataTable SelectOrderList(string pagesize, string currentpage, string condition, string resultnum);
	}
}
