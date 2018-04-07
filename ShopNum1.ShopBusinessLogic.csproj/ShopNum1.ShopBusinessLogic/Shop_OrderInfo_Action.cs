using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_OrderInfo_Action : IShop_OrderInfo_Action
	{
		public DataTable Search(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid,Name,Memo,Charge,IsPercent  FROM ShopNum1_Payment  WHERE 1=1 ";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += "Order By OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus, string timebegin, string timeend, string PaymentTypeGuid)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@ordernumber";
			array2[1] = ordernumber;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			array[3] = "@oderstatus";
			array2[3] = oderstatus;
			array[4] = "@timebegin";
			array2[4] = timebegin;
			array[5] = "@timeend";
			array2[5] = timeend;
			array[6] = "@paymentGuid";
			array2[6] = PaymentTypeGuid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchOrderInfoList", array, array2);
		}
		public DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus, string ordertype, string timebegin, string timeend, string PaymentTypeGuid)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@ordernumber";
			array2[1] = ordernumber;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			array[3] = "@oderstatus";
			array2[3] = oderstatus;
			array[4] = "@timebegin";
			array2[4] = timebegin;
			array[5] = "@timeend";
			array2[5] = timeend;
			array[6] = "@paymentGuid";
			array2[6] = PaymentTypeGuid;
			array[7] = "@ordertype";
			array2[7] = ordertype;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchOrderInfoList2", array, array2);
		}
		public int DeleteOrderInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteOrderInfo", array, array2);
		}
		public DataTable GetOrderInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfo", array, array2);
		}
		public DataTable GetOrderInfo(string guid, string paymentmemloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@paymentmemloginid";
			array2[1] = paymentmemloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfo", array, array2);
		}
		public int UpdateOrderInfoStatus(string guid, string statusname, string statusvalues)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@statusname";
			array2[1] = statusname;
			array[2] = "@statusvalues";
			array2[2] = statusvalues;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderInfoStatus", array, array2);
		}
		public int CancelOrder(string guid, string cancelreason, int oderstatus)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@cancelreason";
			array2[1] = cancelreason;
			array[2] = "@oderstatus";
			array2[2] = oderstatus.ToString();
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_CancelOrder", array, array2);
		}
		public int UpdateOrderMessage(string guid, string message, string messagetype)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@message";
			array2[1] = message;
			array[2] = "@messagetype";
			array2[2] = messagetype;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderMessage", array, array2);
		}
		public DataSet getProductOrderRecord(string ProductGuid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ProductGuid";
			array2[0] = ProductGuid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", array, array2);
		}
		public DataSet getProductOrderRecord(string ProductGuid, string OderStatus)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@ProductGuid";
			array2[0] = ProductGuid;
			array[1] = "@OderStatus";
			array2[1] = OderStatus;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", array, array2);
		}
		public DataSet getProductOrderRecord(string productguid, string oderstatus, string memloginid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@productguid";
			array2[0] = productguid;
			array[1] = "@oderstatus";
			array2[1] = oderstatus;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", array, array2);
		}
		public DataTable SearchOrderInfoByGuid(string guids)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,SellIsDeleted  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guids != "-1")
			{
				text = text + " AND Guid in (" + guids + ")";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchOrderInfoByProductGuid(string productguid)
		{
			string text = string.Empty;
			text = "SELECT MemLoginID  FROM ShopNum1_OrderProduct  WHERE 0=0 ";
			if (productguid != "-1")
			{
				text = text + " AND ProductGuid in ('" + productguid + "')";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SelectOrderList(string pagesize, string currentpage, string condition, string resultnum)
		{
			string text = "select A.Guid,A.memloginid,A.ordernumber,A.oderstatus,A.shipmentstatus,";
			text += "A.paymentstatus,A.refundstatus,A.ordertype,A.shopid,A.shopname,A.createtime,";
			text += "B.productname from shopnum1_orderinfo A left join shopnum1_orderproduct B on B.orderinfoguid=a.guid";
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = text;
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = "createtime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
