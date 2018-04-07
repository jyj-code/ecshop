using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.ThirdInterDAL
{
	public class OrderService
	{
		private ShopNum1_OrderInfo_Action orderaction
		{
			get
			{
				return new ShopNum1_OrderInfo_Action();
			}
		}
		public DataTable GetOrders(string shopid, string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, string oderStatus, decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted, int pagesize, int currentpage, string sign)
		{
			DataTable result = new DataTable();
			try
			{
				string strText = shopid + orderNumber + memLoginID;
				string a = this.MD5Encrypt(strText);
				if (a == sign)
				{
					string strSql = this.SearchStr(shopid, orderNumber, memLoginID, name, address, postalcode, string_0, mobile, email, oderStatus, shouldPayPrice1, shouldPayPrice2, createTime1, createTime2, isDeleted, pagesize, currentpage);
					result = DatabaseExcetue.ReturnDataTable(strSql);
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
		public int GetCountOrders(string shopid, string fisttime, string lasttime, string sign, string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, string oderStatus, decimal shouldPayPrice1, decimal shouldPayPrice2, int isDeleted)
		{
			int result = 0;
			try
			{
				string strText = shopid + fisttime + lasttime;
				string a = this.MD5Encrypt(strText);
				if (a == sign)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("Select count(*) from shopNum1_orderinfo as a where shopid=");
					stringBuilder.Append("'" + shopid + "'");
					stringBuilder.Append(" And a.createtime>'" + fisttime + "'");
					stringBuilder.Append(" And a.createtime<'" + lasttime + "'");
					string nomalString;
					if ((nomalString = this.GetNomalString(orderNumber)) != string.Empty)
					{
						stringBuilder.Append(" AND a.OrderNumber LIKE '%" + nomalString + "%'");
					}
					if ((nomalString = this.GetNomalString(memLoginID)) != string.Empty)
					{
						stringBuilder.Append(" AND a.MemLoginID LIKE '%" + nomalString + "%'");
					}
					if (this.GetNomalString(name) != string.Empty)
					{
						stringBuilder.Append(" AND a.Name LIKE '%" + name + "%'");
					}
					if ((nomalString = this.GetNomalString(address)) != string.Empty)
					{
						stringBuilder.Append(" AND a.Address LIKE '%" + nomalString + "%'");
					}
					if ((nomalString = this.GetNomalString(postalcode)) != string.Empty)
					{
						stringBuilder.Append("AND  a.Postalcode LIKE '%" + nomalString + "%'");
					}
					if ((nomalString = this.GetNomalString(string_0)) != string.Empty)
					{
						stringBuilder.Append(" AND a.Tel LIKE '%" + nomalString + "%'");
					}
					if ((nomalString = this.GetNomalString(mobile)) != string.Empty)
					{
						stringBuilder.Append(" AND a.Mobile LIKE '%" + nomalString + "%'");
					}
					if ((nomalString = this.GetNomalString(email)) != string.Empty)
					{
						stringBuilder.Append(" AND a.Email LIKE '%" + nomalString + "%'");
					}
					if (oderStatus != "-1")
					{
						stringBuilder.Append(" AND a.OderStatus=" + oderStatus);
					}
					if (shouldPayPrice1 != 0m)
					{
						stringBuilder.Append(" AND a.ShouldPayPrice>=" + shouldPayPrice1 + " ");
					}
					if (shouldPayPrice2 != 0m)
					{
						stringBuilder.Append(" AND a.ShouldPayPrice<=" + shouldPayPrice2 + " ");
					}
					if (isDeleted == 0 || isDeleted == 1)
					{
						stringBuilder.Append(" AND a.IsDeleted=" + isDeleted + " ");
					}
					string text = DatabaseExcetue.ReturnString(stringBuilder.ToString());
					result = ((text.Length > 0) ? Convert.ToInt32(text) : 0);
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
		public DataTable GetNewOrders(string shopid, string fisttime, string lasttime, string sign)
		{
			DataTable result = new DataTable();
			try
			{
				string strText = shopid + fisttime + lasttime;
				string a = this.MD5Encrypt(strText);
				if (a == sign)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(string.Concat(new string[]
					{
						"SELECT  b.OrderInfoGuid ,\r\n        b.CreateUser ,\r\n        b.CurrentStateMsg\r\nFROM    ShopNum1_OrderOperateLog AS b\r\n        LEFT JOIN ShopNum1_orderinfo AS a ON a.Guid = b.OrderInfoGuid\r\nWHERE   a.ShopID = '",
						shopid,
						"' AND b.OperateDateTime > '",
						fisttime,
						"' AND OperateDateTime < '",
						lasttime,
						"'"
					}));
					result = DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
		public string SearchStr(string shopid, string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, string oderStatus, decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted, int pagesize, int currentpage)
		{
			int num;
			int num2;
			if (currentpage == 1)
			{
				num = 1;
				num2 = pagesize;
			}
			else
			{
				num = (currentpage - 1) * pagesize + 1;
				num2 = currentpage * pagesize;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("  SELECT OrderNumber,MemLoginID, ");
			stringBuilder.Append(" dbo.GetNameByTypeID(0,OderStatus) AS OderStatusa,");
			stringBuilder.Append(" dbo.GetNameByTypeID(1,PaymentStatus) AS PaymentStatusa ,");
			stringBuilder.Append(" dbo.GetNameByTypeID(2,ShipmentStatus) as ShipmentStatus,paymentname,ProductPrice,ShouldPayPrice,Name,Email,Address,postalcode,tel,mobile,createtime,BuyPrice");
			stringBuilder.Append(" FROM (");
			stringBuilder.Append("SELECT  ROW_NUMBER() OVER ( ORDER BY a.createtime ) AS rowId ,\r\n        a.MemLoginID ,\r\n        OderStatus ,\r\n        PaymentStatus ,\r\n        ShipmentStatus ,\r\n        a.OrderNumber ,\r\n        a.Name ,\r\n        a.Email ,\r\n        a.Address ,\r\n        a.Postalcode ,\r\n        a.Tel ,\r\n        a.Mobile ,\r\n        ClientToSellerMsg ,\r\n        SellerToClientMsg ,\r\n        PaymentName ,\r\n        OutOfStockOperate ,\r\n        PackName ,\r\n        BlessCardName ,\r\n        BlessCardContent ,\r\n        InvoiceTitle ,\r\n        InvoiceContent ,\r\n        ProductPrice ,\r\n        DispatchPrice ,\r\n        PaymentPrice ,\r\n        PackPrice ,\r\n        BlessCardPrice ,\r\n        AlreadPayPrice ,\r\n        SurplusPrice ,\r\n        UseScore ,\r\n        ScorePrice ,\r\n        ShouldPayPrice ,\r\n        FromUrl ,\r\n        a.CreateTime ,\r\n        ConfirmTime ,\r\n        PayTime ,\r\n        DispatchTime ,\r\n        ShipmentNumber ,\r\n        BuyType ,\r\n        PayMemo ,\r\n        InvoiceType ,\r\n        InvoiceTax ,\r\n        Discount ,\r\n        a.IsDeleted ,\r\n         b.shopPrice*b.BuyNumber AS 'BuyPrice'\r\nFROM    ShopNum1_OrderInfo AS a LEFT JOIN \r\nShopNum1_OrderProduct AS b ON a.Guid=b.OrderInfoGuid");
			stringBuilder.Append(" WHERE a.ShopID='" + shopid + "'");
			string nomalString;
			if ((nomalString = this.GetNomalString(orderNumber)) != string.Empty)
			{
				stringBuilder.Append(" AND a.OrderNumber LIKE '%" + nomalString + "%'");
			}
			if ((nomalString = this.GetNomalString(memLoginID)) != string.Empty)
			{
				stringBuilder.Append(" AND  a.MemLoginID LIKE '%" + nomalString + "%'");
			}
			if (this.GetNomalString(name) != string.Empty)
			{
				stringBuilder.Append(" AND a.Name LIKE '%" + name + "%'");
			}
			if ((nomalString = this.GetNomalString(address)) != string.Empty)
			{
				stringBuilder.Append(" AND Address LIKE '%" + nomalString + "%'");
			}
			if ((nomalString = this.GetNomalString(postalcode)) != string.Empty)
			{
				stringBuilder.Append("AND  Postalcode LIKE '%" + nomalString + "%'");
			}
			if ((nomalString = this.GetNomalString(string_0)) != string.Empty)
			{
				stringBuilder.Append(" AND Tel LIKE '%" + nomalString + "%'");
			}
			if ((nomalString = this.GetNomalString(mobile)) != string.Empty)
			{
				stringBuilder.Append(" AND Mobile LIKE '%" + nomalString + "%'");
			}
			if ((nomalString = this.GetNomalString(email)) != string.Empty)
			{
				stringBuilder.Append(" AND Email LIKE '%" + nomalString + "%'");
			}
			if (oderStatus != "-1")
			{
				stringBuilder.Append(" AND OderStatus=" + oderStatus);
			}
			if ((nomalString = this.GetNomalString(createTime1)) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateTime>='" + nomalString + "'");
			}
			if ((nomalString = this.GetNomalString(createTime2)) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateTime<='" + Convert.ToDateTime(nomalString).AddDays(1.0).ToString() + "' ");
			}
			if (shouldPayPrice1 != 0m)
			{
				stringBuilder.Append(" AND ShouldPayPrice>=" + shouldPayPrice1 + " ");
			}
			if (shouldPayPrice2 != 0m)
			{
				stringBuilder.Append(" AND ShouldPayPrice<=" + shouldPayPrice2 + " ");
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				stringBuilder.Append(" AND IsDeleted=" + isDeleted + " ");
			}
			stringBuilder.Append(" ) as t");
			stringBuilder.Append(string.Concat(new object[]
			{
				" where rowId between ",
				num,
				" and ",
				num2,
				"  order by createtime desc"
			}));
			return stringBuilder.ToString();
		}
		public string GetNomalString(string string_0)
		{
			return string_0.ToString().Trim();
		}
		public bool CancelOrders(string oderinfoguid)
		{
			bool result = false;
			try
			{
				List<string> list = new List<string>();
				list.Add("UPDATE ShopNum1_OrderInfo SET OderStatus=4 WHERE guid='" + oderinfoguid + "'");
				DataTable rebackProductCount = this.GetRebackProductCount(oderinfoguid);
				if (rebackProductCount.Rows.Count > 0)
				{
					foreach (DataRow dataRow in rebackProductCount.Rows)
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append(" UPDATE  ShopNum1_Shop_Product");
						stringBuilder.Append(" SET     RepertoryCount = RepertoryCount +" + dataRow[1].ToString());
						stringBuilder.Append(" WHERE   Guid = '" + dataRow[0].ToString() + "'");
						list.Add(stringBuilder.ToString());
					}
				}
				DatabaseExcetue.RunTransactionSql(list);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		public bool CancelOrders()
		{
			bool flag = true;
			try
			{
				DataTable cancelOrders = this.GetCancelOrders();
				foreach (DataRow dataRow in cancelOrders.Rows)
				{
					flag &= this.CancelOrders(dataRow[0].ToString());
				}
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}
		public DataTable GetCancelOrders()
		{
			DataTable result = new DataTable();
			try
			{
				int num = Convert.ToInt32(ShopSettings.GetValue("DefaultCancelOrderDays")) * 24;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" SELECT  guid");
				stringBuilder.Append(" FROM    ShopNum1_OrderInfo");
				stringBuilder.Append(" WHERE   OderStatus = 0");
				stringBuilder.Append(" AND DATEDIFF(hour, CreateTime, GETDATE()) >= @hour");
				string[] paraName = new string[]
				{
					"@hour"
				};
				string[] paraValue = new string[]
				{
					num.ToString()
				};
				result = DatabaseExcetue.ReturnDataTable(stringBuilder.ToString(), paraName, paraValue);
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
		public DataTable GetRebackProductCount(string orderinfoGuid)
		{
			DataTable result = new DataTable();
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" SELECT  Productguid ,");
				stringBuilder.Append("        BuyNumber");
				stringBuilder.Append(" FROM    ShopNum1_OrderProduct");
				stringBuilder.Append(" WHERE OrderInfoGuid=@Guid");
				string[] paraName = new string[]
				{
					"@Guid"
				};
				string[] paraValue = new string[]
				{
					orderinfoGuid
				};
				result = DatabaseExcetue.ReturnDataTable(stringBuilder.ToString(), paraName, paraValue);
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
		public ShopNum1_OrderInfo GetOrderInfoByOrderNumber(string orderNumber)
		{
			ShopNum1_OrderInfo result = new ShopNum1_OrderInfo();
			try
			{
				DataTable dataTable = this.orderaction.SearchOrder(orderNumber);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					result = EvalData<ShopNum1_OrderInfo>.GetData(dataTable).First<ShopNum1_OrderInfo>();
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
		public List<string> GetPrintOrderNumbersByShopID(string shopid)
		{
			List<string> list = new List<string>();
			try
			{
				DataTable printOrderNumbersByShopID = this.orderaction.GetPrintOrderNumbersByShopID(shopid);
				if (printOrderNumbersByShopID != null && printOrderNumbersByShopID.Rows.Count > 0)
				{
					foreach (DataRow dataRow in printOrderNumbersByShopID.Rows)
					{
						list.Add(dataRow[0].ToString());
					}
				}
			}
			catch (Exception)
			{
			}
			return list;
		}
		public string MD5Encrypt(string strText)
		{
			byte[] bytes = Encoding.Default.GetBytes(strText);
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] value = mD.ComputeHash(bytes);
			return BitConverter.ToString(value).Replace("-", "");
		}
		public DataTable GetOrderDetail(string guid)
		{
			string strSql = "SELECT A.Guid,A.OrderInfoGuid,A.ProductGuid,A.ProductName,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.IsShipment,A.IsReal,A.ExtensionAttriutes,A.IsJoinActivity,A.CreateTime,B.memloginid  FROM ShopNum1_OrderProduct AS A,ShopNum1_Shop_Product AS B  WHERE A.ProductGuid=B.Guid\r\nAND A.orderinfoguid='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
