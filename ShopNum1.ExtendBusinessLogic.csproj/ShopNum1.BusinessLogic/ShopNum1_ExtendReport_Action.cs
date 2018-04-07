using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ExtendReport_Action : IShopNum1_ExtendReport_Action
	{
		public int Add()
		{
			return 0;
		}
		public DataTable Search(int productCategoryID, string brandGuid, decimal shopPrice1, decimal shopPrice2, decimal costPrice1, decimal costPrice2, decimal marketPrice1, decimal marketPrice2)
		{
			string text = string.Empty;
			text = "SELECT \tName\t, \tRepertoryNumber\t, \tSaleNumber,\t\tRepertoryCount\t  FROM ShopNum1_Product  WHERE 0=0 ";
			if (productCategoryID != -1)
			{
				text = text + " AND ProductCategoryID=" + productCategoryID;
			}
			if (Operator.FormatToEmpty(brandGuid) != string.Empty && brandGuid != "-1")
			{
				text = text + " AND BrandGuid='" + brandGuid + "'";
			}
			if (shopPrice1 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND ShopPrice>=",
					shopPrice1,
					" "
				});
			}
			if (shopPrice2 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND shopPrice<=",
					shopPrice2,
					" "
				});
			}
			if (costPrice1 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND CostPrice>=",
					costPrice1,
					" "
				});
			}
			if (costPrice2 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND CostPrice<=",
					costPrice2,
					" "
				});
			}
			if (marketPrice1 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND MarketPrice>=",
					marketPrice1,
					" "
				});
			}
			if (marketPrice2 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND MarketPrice<=",
					marketPrice2,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSeeBuyRate(int productCategoryID, string brandGuid, decimal shopPrice1, decimal shopPrice2, decimal costPrice1, decimal costPrice2, decimal marketPrice1, decimal marketPrice2)
		{
			string text = string.Empty;
			text = "SELECT \tName\t, \tRepertoryNumber\t, \tSaleNumber,\t\tClickCount\t,     round(cast(SaleNumber*10*0.1/ClickCount as decimal(20,2)),2) as BuyRate    FROM ShopNum1_Product     WHERE 0=0 AND ClickCount!=0";
			if (productCategoryID != -1)
			{
				text = text + " AND ProductCategoryID=" + productCategoryID;
			}
			if (Operator.FormatToEmpty(brandGuid) != string.Empty && brandGuid != "-1")
			{
				text = text + " AND BrandGuid='" + brandGuid + "'";
			}
			if (shopPrice1 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND ShopPrice>=",
					shopPrice1,
					" "
				});
			}
			if (shopPrice2 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND shopPrice<=",
					shopPrice2,
					" "
				});
			}
			if (costPrice1 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND CostPrice>=",
					costPrice1,
					" "
				});
			}
			if (costPrice2 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND CostPrice<=",
					costPrice2,
					" "
				});
			}
			if (marketPrice1 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND MarketPrice>=",
					marketPrice1,
					" "
				});
			}
			if (marketPrice2 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND MarketPrice<=",
					marketPrice2,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellDetail(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT \tB.Name\t, \tA.OrderNumber\t, \tSum(B.BuyNumber) AS BuyNumber\t, \tA.DispatchTime\t, \tsum(round(cast(B.BuyPrice*B.BuyNumber as   decimal(20,2)),2)) AS BuyPrice\tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid  AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2)";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += "Group By \tB.Name\t\t, \tA.OrderNumber\t, \tA.DispatchTime ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchAgentSellDetail(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT \tB.Name\t, \tA.OrderNumber\t, \tSum(B.BuyNumber) AS BuyNumber\t, \tA.DispatchTime\t, \tsum(round(cast(B.BuyPrice*B.BuyNumber as   decimal(20,2)),2)) AS BuyPrice\tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE 0=0\tAND B.OrderInfoGuid=A.Guid  AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2)";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += "Group By \tB.Name\t\t, \tA.OrderNumber\t, \tA.DispatchTime ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT \tB.Name\t, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice*B.BuyNumber) AS BuyPrice,  round(cast(sum(B.BuyPrice*B.BuyNumber)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid   AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2) ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += "Group By \tB.Name\t, \tRepertoryNumber\t ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchMemberBuyReport(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT \tA.MemloginID\t, \tB.Realname\t, \tcount(A.OrderNumber) AS OrderCount, \tsum(AlreadPayPrice) AS AlreadPayPrice\tfrom \tShopNum1_OrderInfo A, \tShopNum1_member B\t\tWHERE \tB.Memloginid=A.Memloginid   AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2) ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += "Group by \tA.MemloginID\t, \tB.Realname\t ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchAgentMemberBuyReport(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT \tA.MemloginID\t, \tB.Realname\t, \tcount(A.OrderNumber) AS OrderCount, \tsum(AlreadPayPrice) AS AlreadPayPrice\tfrom \tShopNum1_OrderInfo A, \tShopNum1_member B\t\tWHERE 0=0\tAND B.Memloginid=A.Memloginid   AND (A.ShipmentStatus=1 OR A.ShipmentStatus=2) ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += "Group by \tA.MemloginID\t, \tB.Realname\t ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellGuideLineMemberBuyRate(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT   round(cast((select count(distinct MemLoginID) from ShopNum1_OrderInfo  where ShipmentStatus=1 ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += " )*10*0.1   /(select count(*) from ShopNum1_Member) as decimal(20,2)),2) as BuyRate\t, \t(select count(*) as Member from ShopNum1_Member) as MemberNumber, \tcount(distinct MemLoginID) as BuyMemberNumber\tfrom \tShopNum1_OrderInfo \tWHERE \tShipmentStatus=1 OR ShipmentStatus=2 ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellGuideLineMemberOrderNumber(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT    round(cast((select count(*) from ShopNum1_OrderInfo  where ShipmentStatus=1 ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += " )*10*0.1 /   (select count(*) from ShopNum1_Member) as decimal(20,2)),2) as AverageMemberOrderRate, \t(select count(*) as Member from ShopNum1_Member) as MemberNumber, \tcount(*) as OrderNum\tfrom \tShopNum1_OrderInfo \tWHERE \tShipmentStatus=1 OR ShipmentStatus=2  ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellGuideLineMemberOrderMoney(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT  round(cast((select sum(ShouldPayPrice) from ShopNum1_OrderInfo where ShipmentStatus=1 ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += ")*10*0.1/   (select Count(OrderNumber) from ShopNum1_OrderInfo where ShipmentStatus=1 ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += ") as decimal(20,2)),2) as  AverageOrderRate,  Count(OrderNumber) as OrderNum,   sum(ShouldPayPrice)  as AllOrderMoney\tfrom \tShopNum1_OrderInfo \tWHERE \tShipmentStatus=1 OR ShipmentStatus=2 ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellOrders(string dispatchTime1, string dispatchTime2, int intTop)
		{
			string text = string.Empty;
			if (intTop > 0)
			{
				text = "SELECT    top " + intTop + " \te.Name,\te.ProductGuid,\te.BuyNumber, \te.BuyPrice, \td.SmallImage\t, \td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
			}
			else
			{
				text = "SELECT  \te.Name,\te.ProductGuid,\te.BuyNumber, \te.BuyPrice, \td.SmallImage,\td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
			}
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += " ) AS c ON a.OrderInfoGuid = c.Guid group by a.Name, a.ProductGuid )  AS e ON d.Guid = e.ProductGuid WHERE 1=1 ";
			text += "  order by BuyNumber desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchAgentSellOrder(string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT \tB.Name\t, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice*B.BuyNumber) AS BuyPrice,  round(cast(sum(B.BuyPrice*B.BuyNumber)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid   AND A.ShipmentStatus=1 AND  0=0   ";
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + "  AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "'  ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + "  AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "'  ";
			}
			text += "   Group By \tB.Name\t, \tRepertoryNumber\t";
			text += " ORDER BY BuyPrice DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop)
		{
			string text = string.Empty;
			if (intTop > 0)
			{
				text = "SELECT    top " + intTop + " \te.Name,\te.ProductGuid,\te.BuyNumber, \td.ShopPrice, \te.BuyPrice, \td.SmallImage\t, \td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
			}
			else
			{
				text = "SELECT  \te.Name,\te.ProductGuid,\te.BuyNumber, \td.ShopPrice, \te.BuyPrice, \td.SmallImage,\td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
			}
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += " ) AS c ON a.OrderInfoGuid = c.Guid group by a.Name, a.ProductGuid ) AS e";
			text += "  ON d.Guid = e.ProductGuid ";
			text += "  Order by BuyNumber desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop, string isNew, string isHot, string isRecommend, string isBest)
		{
			string text = string.Empty;
			if (intTop > 0)
			{
				text = "SELECT    top " + intTop + " \te.Name,\te.ProductGuid,\te.BuyNumber, \tShopPrice, \tMarketPrice, \te.BuyPrice,  d.OriginalImge, \td.SmallImage\t, \td.ThumbImage\t\tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
			}
			else
			{
				text = "SELECT  \te.Name,\te.ProductGuid,\te.BuyNumber, \tShopPrice, \tMarketPrice, \te.BuyPrice, \td.SmallImage,\td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber ,sum(a.BuyPrice) AS BuyPrice  FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
			}
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += " ) AS c ON a.OrderInfoGuid = c.Guid group by a.Name, a.ProductGuid ) AS e";
			text += "  ON d.Guid = e.ProductGuid ";
			if (isBest != "-1")
			{
				text += "  AND d.IsBest=1";
			}
			if (isHot != "-1")
			{
				text += "  AND d.IsHot=1";
			}
			if (isNew != "-1")
			{
				text += "  AND d.IsNew=1";
			}
			if (isRecommend != "-1")
			{
				text += "  AND d.IsRecommend=1";
			}
			text += "  Order by BuyNumber desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetCategoryByParam(string param)
		{
			string strSql = string.Empty;
			strSql = "select ShopNum1_ProductCategory.[Name], ShopNum1_ProductCategory.ID from ShopNum1_ProductCategory,ShopNum1_Product where fatherID in( select ID from ShopNum1_ProductCategory where fatherID = 0) and " + param + "= 1 and ShopNum1_ProductCategory.ID = ShopNum1_Product.ProductCategoryID Group by ShopNum1_ProductCategory.[Name], ShopNum1_ProductCategory.ID";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchSellProduct(int intTop, int ProductCategoryID)
		{
			string text = string.Empty;
			if (intTop > 0)
			{
				text = "SELECT    top " + intTop + " \td.Name,\td.Guid,  a.BuyNumber, \td.ShopPrice, \td.MarketPrice, \ta.BuyPrice, \td.SmallImage\t, \td.ThumbImage\t,\td.OriginalImge\t,\td.ProductCategoryID\t,\ti.Name AS CategoryName\t,\tb.ShipmentStatus\t,\ta.ProductGuid\t,\ta.OrderInfoGuid\t,  b.Guid ,\ti.ID\t\tfrom \tShopNum1_Product AS d ,ShopNum1_ProductCategory AS i,ShopNum1_OrderProduct  AS a,ShopNum1_OrderInfo AS b\tWHERE   b.ShipmentStatus = 1 AND d.ProductCategoryID = i.ID AND b.Guid = a.OrderInfoGuid AND d.Guid = a.ProductGuid";
			}
			else
			{
				text = "SELECT    top " + intTop + " \td.Name,\td.Guid,  a.BuyNumber, \td.ShopPrice, \td.MarketPrice, \ta.BuyPrice, \td.SmallImage, \td.OriginalImge\t,\td.ThumbImage\t,\td.ProductCategoryID\t,\ti.Name AS CategoryName\t,\tb.ShipmentStatus\t,\ta.ProductGuid\t,\ta.OrderInfoGuid\t,  b.Guid ,\ti.ID\t\tfrom \tShopNum1_Product AS d ,ShopNum1_ProductCategory AS i,ShopNum1_OrderProduct  AS a,ShopNum1_OrderInfo AS b\tWHERE   b.ShipmentStatus = 1 AND d.ProductCategoryID = i.ID AND b.Guid = a.OrderInfoGuid AND d.Guid = a.ProductGuid";
			}
			if (ProductCategoryID != -1)
			{
				text = text + "  AND d.ProductCategoryID = " + ProductCategoryID;
			}
			text += "  Order by a.BuyNumber desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
