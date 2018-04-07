using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Report_Action : IShop_Report_Action
	{
		public DataTable SearchShopSellOrder(string MemLoginID, string dispatchTime1, string dispatchTime2, string ProductName)
		{
			string text = string.Empty;
			text = "SELECT \tB.ProductName\t, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice) AS BuyPrice,  round(cast(sum(B.BuyPrice)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B  \tWHERE \tB.OrderInfoGuid=A.Guid   AND A.Oderstatus>0 and A.Oderstatus<4    AND A.ShopID='" + MemLoginID + "'";
			if (Operator.FormatToEmpty(dispatchTime1) != "")
			{
				text = text + " AND A.confirmtime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != "")
			{
				text = text + " AND A.confirmtime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			if (Operator.FormatToEmpty(ProductName) != "")
			{
				text = text + " AND B.ProductName ='" + Operator.FilterString(ProductName) + "' ";
			}
			text += " Group By \tB.ProductName\t, \tRepertoryNumber\torder by BuyNumber desc ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchClickCount(string ShopID, string SaleNumber1, string SaleNumber2, string ClickCount1, string ClickCount2, string ProductName)
		{
			string text = string.Empty;
			text = "SELECT   Name, ClickCount,  ProductNum,  SaleNumber,  round(cast(salenumber*10*0.1/ClickCount as decimal(20,2)),2) as BuyRate FROM ShopNum1_Shop_Product  WHERE 0=0 and ClickCount!=0  ";
			if (ShopID != "")
			{
				text = text + " and MemLoginID='" + ShopID + "'";
			}
			if (SaleNumber1 != "-1")
			{
				text = text + " and SaleNumber>=" + SaleNumber1;
			}
			if (SaleNumber2 != "-1")
			{
				text = text + " and SaleNumber<=" + SaleNumber2;
			}
			if (ClickCount1 != "-1")
			{
				text = text + " and ClickCount>=" + ClickCount1;
			}
			if (ClickCount2 != "-1")
			{
				text = text + " and ClickCount<=" + ClickCount2;
			}
			if (ProductName != "-1")
			{
				text = text + " and Name ='" + ProductName + "'";
			}
			text += " Order By ClickCount desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string MemLoginID, string ProductSeriesCode, string SaleNumber1, string SaleNumber2, string RepertoryCount1, string RepertoryCount2, string productname)
		{
			string text = string.Empty;
			text = "SELECT \tName\t, \tProductNum\t, \tSaleNumber,\t\tProductSeriesName,\t\tRepertoryCount\t  FROM ShopNum1_Shop_Product  WHERE MemLoginID='" + MemLoginID + "'";
			if (ProductSeriesCode != "-1")
			{
				text = text + " AND ProductSeriesCode like '" + ProductSeriesCode + "%'";
			}
			if (SaleNumber1 != "-1")
			{
				text = text + " AND SaleNumber>=" + SaleNumber1 + " ";
			}
			if (SaleNumber2 != "-1")
			{
				text = text + " AND SaleNumber<=" + SaleNumber2 + " ";
			}
			if (RepertoryCount1 != "-1")
			{
				text = text + " AND RepertoryCount>=" + RepertoryCount1 + " ";
			}
			if (RepertoryCount2 != "-1")
			{
				text = text + " AND RepertoryCount<=" + RepertoryCount2 + " ";
			}
			if (productname != "-1")
			{
				text = text + " AND Name ='" + productname + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
