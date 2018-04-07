using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Refund_Action : IShopNum1_Refund_Action
	{
		public int Add(ShopNum1_Refund shopNum1_Refund)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into ShopNum1_Refund(");
			stringBuilder.Append("OrderID,ProductGuid,RefundID,ApplyTime,RefundType,RefundStatus,RefundMoney,RefundContent,RefundReason,RefundImg,MemLoginID,ShopID,IsReceive ");
			stringBuilder.Append(")");
			stringBuilder.Append(" values (");
			stringBuilder.Append("'" + shopNum1_Refund.OrderID + "',");
			stringBuilder.Append("'" + shopNum1_Refund.ProductGuid + "',");
			stringBuilder.Append("'" + shopNum1_Refund.RefundID + "',");
			stringBuilder.Append("'" + shopNum1_Refund.ApplyTime + "',");
			stringBuilder.Append(shopNum1_Refund.RefundType + ",");
			stringBuilder.Append(shopNum1_Refund.RefundStatus + ",");
			stringBuilder.Append(shopNum1_Refund.RefundMoney + ",");
			stringBuilder.Append("'" + shopNum1_Refund.RefundContent + "',");
			stringBuilder.Append("'" + shopNum1_Refund.RefundReason + "',");
			stringBuilder.Append("'" + shopNum1_Refund.RefundImg + "',");
			stringBuilder.Append("'" + shopNum1_Refund.MemLoginID + "',");
			stringBuilder.Append("'" + shopNum1_Refund.ShopID + "',");
			stringBuilder.Append(" " + shopNum1_Refund.IsReceive + " ");
			stringBuilder.Append(")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable SelectRefundInfo(string strId, string strMeloginId, string strIsShop)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@Id";
			array2[0] = strId;
			array[1] = "@MeloginId";
			array2[1] = strMeloginId;
			array[2] = "@IsShop";
			array2[2] = strIsShop;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderRefundInfo", array, array2);
		}
		public int Update(ShopNum1_Refund shopNum1_Refund)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_Refund set ");
			stringBuilder.Append("RefundStatus=" + shopNum1_Refund.RefundStatus + ",");
			stringBuilder.Append("RefundMoney=" + shopNum1_Refund.RefundMoney + ",");
			stringBuilder.Append("RefundContent='" + shopNum1_Refund.RefundContent + "',");
			stringBuilder.Append("RefundReason='" + shopNum1_Refund.RefundReason + "',");
			stringBuilder.Append("IsReceive=" + shopNum1_Refund.IsReceive + ",");
			stringBuilder.Append("RefundImg='" + shopNum1_Refund.RefundImg + "' ");
			stringBuilder.Append(string.Concat(new object[]
			{
				" where OrderID='",
				shopNum1_Refund.OrderID,
				"' AND ProductGuid='",
				shopNum1_Refund.ProductGuid,
				"'"
			}));
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from ShopNum1_Refund ");
			stringBuilder.Append(" where ID IN(" + string_0 + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetRefundList(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" ID,OrderID,ProductGuid,RefundID,ApplyTime,RefundType,RefundStatus,RefundMoney,RefundContent,RefundReason,OnPassReason,ModifyTime,RefundImg,OnPassImg,IsAdmin,AdminContent,AddressName,AddressValue,MemLoginID,ShopID,IsReceive ");
			stringBuilder.Append(" from ShopNum1_Refund ");
			if (ID != -1)
			{
				stringBuilder.Append(" where ID=" + ID);
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetRefundList(string memloginid, string orderid, string productguid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" A.ID,A.OrderID,A.ProductGuid,A.RefundID,A.ApplyTime,A.RefundType,A.RefundStatus,A.RefundMoney,A.RefundContent,A.RefundReason,A.OnPassReason,A.ModifyTime,A.RefundImg,A.OnPassImg,A.IsAdmin,A.AdminContent,A.AddressName,A.AddressValue,A.MemLoginID,A.ShopID,A.IsReceive,B.Name AS ProductName ");
			stringBuilder.Append(" from ShopNum1_Refund AS A LEFT JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid where 0=0");
			if (memloginid != "-1")
			{
				stringBuilder.Append(" and A.MemLoginID='" + memloginid + "'");
			}
			if (orderid != "-1")
			{
				stringBuilder.Append(" and A.OrderID='" + orderid + "'");
			}
			if (productguid != "-1")
			{
				stringBuilder.Append(" and A.ProductGuid='" + productguid + "'");
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetRefundListByShopID(string shopID, string orderid, string productguid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" A.ID,A.OrderID,A.ProductGuid,A.RefundID,A.ApplyTime,A.RefundType,A.RefundStatus,A.RefundMoney,A.RefundContent,A.RefundReason,A.OnPassReason,A.ModifyTime,A.RefundImg,A.OnPassImg,A.IsAdmin,A.AdminContent,A.AddressName,A.AddressValue,A.MemLoginID,A.ShopID,A.IsReceive,B.Name AS ProductName ");
			stringBuilder.Append(" from ShopNum1_Refund AS A LEFT JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid where 0=0");
			if (shopID != "-1")
			{
				stringBuilder.Append(" and A.ShopID='" + shopID + "'");
			}
			if (orderid != "-1")
			{
				stringBuilder.Append(" and A.OrderID='" + orderid + "'");
			}
			if (productguid != "-1")
			{
				stringBuilder.Append(" and A.ProductGuid='" + productguid + "'");
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public bool CheckIsRefundApply(string memloginid, string orderid, string productguid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT COUNT(*) FROM ShopNum1_Refund WHERE MemLoginID='",
				memloginid,
				"' and OrderID='",
				orderid,
				"' and ProductGuid='",
				productguid,
				"'"
			});
			int num = int.Parse(DatabaseExcetue.ReturnString(strSql));
			return num <= 0;
		}
		public DataTable GetRefundStatus(string shopid, string orderguid, string productguid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@orderguid";
			array2[1] = orderguid;
			array[2] = "@productguid";
			array2[2] = productguid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetRefundStatus", array, array2);
		}
		public DataTable GetProductPriceAndShopID(string memloginid, string orderingoGuid, string productguid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT BuyPrice*BuyNumber AS TotalPrice ,ShopID,Name FROM ShopNum1_OrderProduct WHERE MemLoginID='",
				memloginid,
				"' and OrderInfoGuid='",
				orderingoGuid,
				"' and ProductGuid='",
				productguid,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetProductPriceAndMemLoginID(string shopid, string orderingoGuid, string productguid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT RefundMoney ,MemLoginID FROM ShopNum1_Refund WHERE ShopID='",
				shopid,
				"' and OrderID='",
				orderingoGuid,
				"' and ProductGuid='",
				productguid,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int ShopOnPassRefund(ShopNum1_Refund shopNum1_Refund)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_Refund set ");
			stringBuilder.Append("OnPassImg='" + shopNum1_Refund.OnPassImg + "',");
			stringBuilder.Append("OnPassReason='" + shopNum1_Refund.OnPassReason + "',");
			stringBuilder.Append("ModifyTime='" + DateTime.Now + "',");
			stringBuilder.Append("RefundStatus=" + shopNum1_Refund.RefundStatus + " ");
			stringBuilder.Append(string.Concat(new object[]
			{
				" where OrderID='",
				shopNum1_Refund.OrderID,
				"' AND ProductGuid='",
				shopNum1_Refund.ProductGuid,
				"'"
			}));
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetOnPassRefund(string shopid, string orderingoGuid, string productguid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" RefundStatus,OnPassReason,OnPassImg,ModifyTime,AddressName ");
			stringBuilder.Append(string.Concat(new string[]
			{
				" from ShopNum1_Refund WHERE ShopID='",
				shopid,
				"' and OrderID='",
				orderingoGuid,
				"' and ProductGuid='",
				productguid,
				"'"
			}));
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public string GetOrderStatus(string orderguid)
		{
			string strSql = string.Empty;
			strSql = "SELECT OderStatus FROM ShopNum1_OrderInfo WHERE Guid='" + orderguid + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public int UpdateRefundStatus(string MemloginId, string onPassreason, string productguid, string status)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Refund SET RefundStatus=",
				status,
				",onPassreason='",
				onPassreason,
				"',ModifyTime='",
				DateTime.Now,
				"' WHERE  ProductGuid='",
				productguid,
				"' and shopID='",
				MemloginId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateRefundStatus(string orderingoGuid, string productguid, string status, string adressName, string adressValue)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Refund SET RefundStatus=",
				status,
				", AddressName='",
				adressName,
				"',AddressValue='",
				adressValue,
				"',ModifyTime='",
				DateTime.Now,
				"' WHERE OrderID='",
				orderingoGuid,
				"' AND ProductGuid='",
				productguid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateProductGroupPrice(string ProductGuid, string OrderInfoGuid, string MemLoginID, string ShopID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_OrderProduct SET GroupPrice=0.00 WHERE ProductGuid='",
				ProductGuid,
				"' AND OrderInfoGuid='",
				OrderInfoGuid,
				"' AND MemLoginID='",
				MemLoginID,
				"' AND ShopID='",
				ShopID,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string orderID, string ModifyUser, string ShopID, string MemLoginID, string ShouldPayPrice1, string ShouldPayPrice2, string OrderCreateTime1, string OrderCreateTime2, string isAdmin)
		{
			string text = string.Empty;
			text = "SELECT A.ID,A.MemLoginID,A.ShopID,A.ModifyUser,A.RefundMoney,A.IsAdmin,A.RefundStatus,A.RefundType,A.IsReceive,B.OrderNumber,B.CreateTime,B.ProductPrice FROM ShopNum1_Refund AS A,ShopNum1_OrderInfo AS B WHERE A.OrderID=B.Guid ";
			if (Operator.FilterString(orderID) != "-1")
			{
				text = text + " AND B.OrderNumber='" + orderID + "'";
			}
			if (Operator.FilterString(ModifyUser) != "-1")
			{
				text = text + " AND A.ModifyUser='" + ModifyUser + "'";
			}
			if (Operator.FilterString(ShopID) != "-1")
			{
				text = text + " AND A.ShopID='" + ShopID + "'";
			}
			if (Operator.FilterString(MemLoginID) != "-1")
			{
				text = text + " AND A.MemLoginID='" + MemLoginID + "'";
			}
			if (Operator.FilterString(ShouldPayPrice1) != "-1")
			{
				text = text + " AND A.RefundMoney>='" + ShouldPayPrice1 + "'";
			}
			if (Operator.FilterString(ShouldPayPrice2) != "-1")
			{
				text = text + " AND A.RefundMoney<='" + ShouldPayPrice2 + "'";
			}
			if (Operator.FilterString(OrderCreateTime1) != "-1")
			{
				text = text + " AND B.CreateTime>='" + OrderCreateTime1 + "'";
			}
			if (Operator.FilterString(OrderCreateTime2) != "-1")
			{
				text = text + " AND B.CreateTime<='" + OrderCreateTime2 + "'";
			}
			if (Operator.FilterString(isAdmin) != "-1")
			{
				text = text + " AND A.IsAdmin=" + isAdmin + " ";
			}
			text += " ORDER BY A.ApplyTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetOrderRefundInfo(int int_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT C.OrderNumber,A.[Name],B.OrderID,B.ModifyUser,B.RefundID,B.MemLoginID,B.ShopID,B.RefundMoney,B.ApplyTime,B.RefundType,B.RefundReason,B.IsReceive,B.RefundContent,B.RefundImg,B.AddressName,B.OnPassReason,B.OnPassImg,C.CreateTime,C.ShipmentStatus FROM ShopNum1_OrderProduct AS A,ShopNum1_Refund AS B, ShopNum1_OrderInfo AS C WHERE A.OrderInfoGuid=B.OrderID AND A.ProductGuid=B.ProductGuid AND A.OrderInfoGuid=C.Guid AND B.ID=" + int_0;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int AdminUpdateRefundStatus(string string_0, string status, string content, string CreateUser)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Refund SET RefundStatus=",
				status,
				" , AdminContent='",
				content,
				"' , ModifyUser='",
				CreateUser,
				"' WHERE ID=",
				string_0
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateRefundStatusIsAdmin(string orderingoGuid, string productguid, string status)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Refund SET IsAdmin=",
				status,
				" WHERE OrderID='",
				orderingoGuid,
				"' AND ProductGuid='",
				productguid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public string IsCheckRefund(string orderingoGuid)
		{
			string strSql = "select refundstatus from ShopNum1_Refund where 1=1 and orderid='" + orderingoGuid + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable GetRefund(string orderingoGuid)
		{
			string strSql = "select RefundMoney,refundstatus,ReFundContent,OnPassReason,RefundImg,OnPassImg,ProductGuid,RefundType from ShopNum1_Refund where 1=1 and orderid='" + orderingoGuid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int RefundUpdateAdvancePaymentMem(string memloginid, string shopid, decimal payprice, string orderguid, string productguid, int status)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Member SET AdvancePayment\t=AdvancePayment+",
				payprice,
				" WHERE MemLoginID='",
				memloginid,
				"'"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Refund SET RefundStatus=",
				status,
				" WHERE OrderID='",
				orderguid,
				"' AND ProductGuid='",
				productguid,
				"' AND ShopID='",
				shopid,
				"'"
			});
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable SelectRefundList(string pagesize, string currentpage, string condition, string resultnum)
		{
			string text = "select A.*,b.ordernumber,b.shouldpayprice,b.paymentname from shopnum1_refund A \r\ninner join shopnum1_orderinfo B ON B.guid=a.orderid ";
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
			array2[5] = "applytime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int DeleteRefundByOrId(string strOrderId)
		{
			string strSql = "DELETE FROM shopnum1_refund WHERE orderid='" + strOrderId + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
