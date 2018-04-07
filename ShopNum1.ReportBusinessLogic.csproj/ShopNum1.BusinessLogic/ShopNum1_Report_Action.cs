using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Report_Action : IShopNum1_Report_Action
	{
		public DataTable Search(string productCategoryCode, decimal shopPrice1, decimal shopPrice2, decimal marketPrice1, decimal marketPrice2)
		{
			string text = string.Empty;
			text = "SELECT \tName\t, \tProductNum\t, \tSaleNumber,\t\tRepertoryCount\t  FROM ShopNum1_Shop_Product  WHERE 0=0 ";
			if (productCategoryCode != "-1")
			{
				text = text + " AND ProductCategoryCode like '" + productCategoryCode + "%'";
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
		public DataTable SearchSeeBuyRate(string name, string productCategoryCode1, string productCategoryCode2, string productCategoryCode3, string brandGuid, decimal shopPrice1, decimal shopPrice2, decimal marketPrice1, decimal marketPrice2)
		{
			string text = string.Empty;
			text = "SELECT \tName\t, \tProductNum\t, \tSaleNumber,\t\tClickCount\t,     round(cast(SaleNumber*10*0.1/ClickCount as decimal(20,2)),2) as BuyRate,    productcategoryname,    brandname    FROM ShopNum1_Shop_Product     WHERE 0=0 AND ClickCount!=0  ";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name like '%" + name + "%'";
			}
			if (productCategoryCode3 != "-1")
			{
				text = text + " AND productCategoryCode like '" + productCategoryCode3.Split(new char[]
				{
					'/'
				})[0] + "%'";
			}
			if (productCategoryCode2 != "-1")
			{
				text = text + " AND productCategoryCode like '" + productCategoryCode2.Split(new char[]
				{
					'/'
				})[0] + "%'";
			}
			if (productCategoryCode1 != "-1")
			{
				text = text + " AND productCategoryCode like '" + productCategoryCode1.Split(new char[]
				{
					'/'
				})[0] + "%'";
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
			text += " order by SaleNumber desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSeeBuyRate(string name, string productCategoryCode1, string productCategoryCode2, string productCategoryCode3, string brandGuid, decimal shopPrice1, decimal shopPrice2, decimal marketPrice1, decimal marketPrice2, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT \tName\t, \t SubstationID\t, \tProductNum\t, \tSaleNumber,\t\tClickCount\t,     round(cast(SaleNumber*10*0.1/ClickCount as decimal(20,2)),2) as BuyRate,    productcategoryname,    brandname    FROM ShopNum1_Shop_Product     WHERE 0=0 AND ClickCount!=0  ";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name like '%" + name + "%'";
			}
			if (productCategoryCode3 != "-1")
			{
				text = text + " AND productCategoryCode like '" + productCategoryCode3.Split(new char[]
				{
					'/'
				})[0] + "%'";
			}
			if (productCategoryCode2 != "-1")
			{
				text = text + " AND productCategoryCode like '" + productCategoryCode2.Split(new char[]
				{
					'/'
				})[0] + "%'";
			}
			if (productCategoryCode1 != "-1")
			{
				text = text + " AND productCategoryCode like '" + productCategoryCode1.Split(new char[]
				{
					'/'
				})[0] + "%'";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  SubstationID='" + SubstationID + "' ";
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
			text += " order by SaleNumber desc";
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
		public DataTable SearchSellOrder(string Name, string shopName, string dispatchTime1, string dispatchTime2)
		{
			string text = string.Empty;
			text = "SELECT \tB.ProductName\t,   A.ShopName,sum(A.dispatchprice)dispatchprice, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice) AS BuyPrice,  round(cast(sum(B.BuyPrice)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid   AND A.OderStatus=3 ";
			if (Operator.FormatToEmpty(Name) != string.Empty)
			{
				text = text + " AND b.ProductName like '%" + Operator.FilterString(Name) + "%' ";
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				text = text + " AND A.shopName like '%" + Operator.FilterString(shopName) + "%' ";
			}
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += "Group By \tB.ProductName\t, \tRepertoryNumber\t,  A.ShopName,A.dispatchprice  order by buyprice desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchSellOrder(string Name, string shopName, string dispatchTime1, string dispatchTime2, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT \tB.ProductName\t,   A.ShopName,sum(A.dispatchprice)dispatchprice, \tRepertoryNumber\t, \tsum(B.BuyNumber) AS BuyNumber, \tsum(B.BuyPrice) AS BuyPrice,  round(cast(sum(B.BuyPrice)*10*0.1/sum(B.BuyNumber)  as   decimal(20,2)),2) AS AveragePrice \tfrom \tShopNum1_OrderInfo A, \tShopNum1_OrderProduct B\t\tWHERE \tB.OrderInfoGuid=A.Guid   AND A.OderStatus=3 ";
			if (Operator.FormatToEmpty(Name) != string.Empty)
			{
				text = text + " AND b.ProductName like '%" + Operator.FilterString(Name) + "%' ";
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				text = text + " AND A.shopName like '%" + Operator.FilterString(shopName) + "%' ";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND A.SubstationID = '" + SubstationID + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += "Group By \tB.ProductName\t, \tRepertoryNumber\t,  A.ShopName,A.dispatchprice  order by buyprice desc";
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
			text += " )*10*0.1 /   (select count(*) from ShopNum1_Member) as decimal(20,2)),2) as AverageMemberOrderRate, \t(select count(*) as Member from ShopNum1_Member) as MemberNumber, \tcount(*) as OrderNum\tfrom \tShopNum1_OrderInfo \tWHERE \tShipmentStatus=1 OR ShipmentStatus=2 ";
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
		public DataTable SearchSellOrder(string dispatchTime1, string dispatchTime2, int intTop)
		{
			string text = string.Empty;
			if (intTop > 0)
			{
				text = "SELECT    top " + intTop + " \te.Name,\te.ProductGuid,\te.BuyNumber, \td.SmallImage\t, \td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Shop_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber   FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
			}
			else
			{
				text = "SELECT  \te.Name,\te.ProductGuid,\te.BuyNumber, \td.SmallImage,\td.ThumbImage\t, \td.OriginalImge \tfrom \tShopNum1_Shop_Product AS d   INNER JOIN\t(SELECT   a.Name, a.ProductGuid, sum(a.BuyNumber) as BuyNumber   FROM    ShopNum1_OrderProduct  AS a INNER JOIN  (SELECT   DispatchTime, Guid    FROM   ShopNum1_OrderInfo\tWHERE   ShipmentStatus = 1";
			}
			if (Operator.FormatToEmpty(dispatchTime1) != string.Empty)
			{
				text = text + " AND A.DispatchTime>='" + Operator.FilterString(dispatchTime1) + "' ";
			}
			if (Operator.FormatToEmpty(dispatchTime2) != string.Empty)
			{
				text = text + " AND A.DispatchTime<='" + Operator.FilterString(dispatchTime2) + "' ";
			}
			text += " ) AS c ON a.OrderInfoGuid = c.Guid group by a.Name, a.ProductGuid )  AS e ON d.Guid = e.ProductGuid order by BuyNumber desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchRegionSales(string startdate, string enddate, string regioncecode)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@startdate";
			array2[0] = startdate;
			array[1] = "@enddate";
			array2[1] = enddate;
			array[2] = "@regioncecode";
			array2[2] = regioncecode;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchProvinceSales", array, array2);
		}
		public DataTable SearchRegionSalesDetail(string ordernumber, string productName, string shopname, string startdate, string enddate, string regioncecode, string sPayPrice, string ePayPrice, string ProductCategoryCode)
		{
			string[] array = new string[9];
			string[] array2 = new string[9];
			array[0] = "@productName";
			array2[0] = productName;
			array[1] = "@shopname";
			array2[1] = shopname;
			array[2] = "@startdate";
			array2[2] = startdate;
			array[3] = "@enddate";
			array2[3] = enddate;
			array[4] = "@regioncecode";
			array2[4] = regioncecode;
			array[5] = "@sPayPrice";
			array2[5] = sPayPrice;
			array[6] = "ProductCategoryCode";
			array2[6] = ProductCategoryCode;
			array[7] = "@ordernumber";
			array2[7] = ordernumber;
			array[8] = "@ePayPrice";
			array2[8] = ePayPrice;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchProvinceSalesDetail", array, array2);
		}
		public DataTable SearchShopIncome(string memloginid, string shopname)
		{
			string text = string.Empty;
			text = "SELECT * FROM   (SELECT TOP 1000    memloginid\t,   (select shopname from shopnum1_shopinfo where memloginid=t.memloginid)shopname\t,   sum(operatemoney)moneycount\t  from ShopNum1_AdvancePaymentModifyLog t   WHERE 1=1 and operatetype=4  ";
			if (Operator.FormatToEmpty(memloginid) != string.Empty)
			{
				text = text + " AND memloginid like '" + memloginid.Trim().ToString() + "%'";
			}
			text += " group by memloginid order by moneycount desc) AS Tab ";
			if (Operator.FormatToEmpty(shopname) != string.Empty)
			{
				text = text + " WHERE  shopname like '" + shopname.Trim().ToString() + "%' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchShopDailysales(string memloginid, string date1, string date2, string shopname)
		{
			string text = string.Empty;
			text = "select * from( \tselect CONVERT(varchar(100), date, 23)date\t, \tmemloginid\t, \t(select shopname from shopnum1_shopinfo where memloginid=t.memloginid)shopname\t, \tsum(operatemoney)moneycount    from ShopNum1_AdvancePaymentModifyLog t    WHERE 1=1 and operatetype=4 ";
			if (Operator.FormatToEmpty(memloginid) != string.Empty)
			{
				text = text + "  AND  MemLoginID like '" + memloginid + "%'";
			}
			if (Operator.FormatToEmpty(date1) != string.Empty)
			{
				text = text + " AND Date>='" + Operator.FilterString(date1) + "' ";
			}
			if (Operator.FormatToEmpty(date2) != string.Empty)
			{
				text = text + " AND Date<='" + Operator.FilterString(date2) + "' ";
			}
			text += " group by memloginid,CONVERT(varchar(100), date, 23)) AS Tab ";
			if (Operator.FormatToEmpty(shopname) != string.Empty)
			{
				text = text + " WHERE shopname  like '" + shopname + "%'";
			}
			text += " ORDER BY  Date Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SelectMonthChart(string strMemloginId)
		{
			string strSql = "select x 月份,count(*)订单数量,\r\n(select count(*) from shopnum1_orderinfo where CONVERT(varchar(6), createtime, 112)=tab.x and Oderstatus=0 )未付款,\r\n(select count(*) from shopnum1_orderinfo where CONVERT(varchar(6), createtime, 112)=tab.x and Oderstatus=1 )已付款,\r\n(select count(*) from shopnum1_orderinfo where CONVERT(varchar(6), createtime, 112)=tab.x and Oderstatus=3 )已消费, \r\n(select count(*) from shopnum1_orderinfo where CONVERT(varchar(6), createtime, 112)=tab.x and Oderstatus>3 )已关闭\r\nfrom (select CONVERT(varchar(6), createtime, 112)x  \r\nfrom shopnum1_orderinfo )as tab group by x order by x asc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
