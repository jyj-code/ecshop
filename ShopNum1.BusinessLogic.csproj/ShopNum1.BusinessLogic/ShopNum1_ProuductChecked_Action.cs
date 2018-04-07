using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ProuductChecked_Action : IShopNum1_ProuductChecked_Action
	{
		public DataTable Search(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string ShopName, string isSpellBuy, string MemLoginID, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("B.ShopName");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID");
			stringBuilder.Append(" WHERE 0=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(ShopName) != "")
			{
				stringBuilder.Append(" AND B.ShopName  LIKE '%" + ShopName + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND B.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder.Append(" AND A.IsSell =" + isSell);
			}
			if (Operator.FormatToEmpty(isShopNew) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopNew =" + isShopNew);
			}
			if (Operator.FormatToEmpty(isShopHot) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopHot =" + isShopHot);
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopGood =" + isShopGood);
			}
			if (Operator.FormatToEmpty(isShopRecommend) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopRecommend =" + isShopRecommend);
			}
			stringBuilder.Append(" ORDER BY A.OrderID ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string ShopName, string isSpellBuy, string MemLoginID, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("B.SubstationID,");
			stringBuilder.Append("B.ShopName");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID");
			stringBuilder.Append(" WHERE 0=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(ShopName) != "")
			{
				stringBuilder.Append(" AND B.ShopName  LIKE '%" + ShopName + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND B.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder.Append(" AND A.IsSell =" + isSell);
			}
			if (Operator.FormatToEmpty(isShopNew) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopNew =" + isShopNew);
			}
			if (Operator.FormatToEmpty(isShopHot) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopHot =" + isShopHot);
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopGood =" + isShopGood);
			}
			if (Operator.FormatToEmpty(isShopRecommend) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopRecommend =" + isShopRecommend);
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND  B.SubstationID='" + SubstationID + "' ");
			}
			stringBuilder.Append(" ORDER BY A.OrderID ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchNew(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.starttime,");
			stringBuilder.Append("A.endtime,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("B.ShopName");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID");
			stringBuilder.Append(" WHERE 0=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			stringBuilder.Append(" AND A.ProductState =1");
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND B.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder.Append(" AND B.ShopName like'%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(sName) != string.Empty)
			{
				stringBuilder.Append(" AND B.Name like'%" + sName + "%' ");
			}
			stringBuilder.Append(" ORDER BY A.OrderID ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchNew(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.starttime,");
			stringBuilder.Append("A.endtime,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("B.SubstationID,");
			stringBuilder.Append("B.ShopName");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID");
			stringBuilder.Append(" WHERE 0=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			stringBuilder.Append(" AND A.ProductState =1");
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND B.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder.Append(" AND B.ShopName like'%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(sName) != string.Empty)
			{
				stringBuilder.Append(" AND B.Name like'%" + sName + "%' ");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND B.SubstationID ='" + SubstationID + "' ");
			}
			stringBuilder.Append(" ORDER BY A.OrderID ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchPerPage(int startRowIndex, int maximumRows, string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("B.ShopName");
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("  0=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder2.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder2.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder2.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
			{
				stringBuilder2.Append(" AND A.IsPanicBuy =" + isPanicBuy);
			}
			if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
			{
				stringBuilder2.Append(" AND A.IsSpellBuy =" + isSpellBuy);
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
			}
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@startnum";
			array2[0] = startRowIndex.ToString();
			array[1] = "@count";
			array2[1] = "10";
			array[2] = "@tablename";
			array2[2] = " ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID";
			array[3] = "@columnnames";
			array2[3] = stringBuilder.ToString();
			array[4] = "@ordername";
			array2[4] = "A.OrderID";
			array[5] = "@searchname";
			array2[5] = stringBuilder2.ToString();
			array[6] = "@sdesc";
			array2[6] = "desc";
			array[7] = "@isreturcount";
			array2[7] = "0";
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPageGetByRowNum", array, array2);
		}
		public DataTable SearchPerPageNew(int startRowIndex, int maximumRows, string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.CreateTime,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("B.ShopName,");
			stringBuilder.Append("B.Name AS SName");
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("  0=0 And A.productstate=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder2.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSaled = " + isSaled);
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder2.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder2.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
			{
				stringBuilder2.Append(" AND A.IsPanicBuy =" + isPanicBuy);
			}
			if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
			{
				stringBuilder2.Append(" AND A.IsSpellBuy =" + isSpellBuy);
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder2.Append(" AND B.ShopName like '%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(sName) != string.Empty)
			{
				stringBuilder2.Append(" AND B.SName like '%" + sName + "%' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSell ='" + isSell + "'");
			}
			if (Operator.FormatToEmpty(isShopNew) != "-1")
			{
				stringBuilder2.Append(" AND A.IsshopNew ='" + isShopNew + "'");
			}
			if (Operator.FormatToEmpty(isShopHot) != "-1")
			{
				stringBuilder2.Append(" AND A.IsshopHot ='" + isShopHot + "'");
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder2.Append(" AND A.IsShopGood ='" + isShopGood + "'");
			}
			if (Operator.FormatToEmpty(isShopRecommend) != "-1")
			{
				stringBuilder2.Append(" AND A.IsshopRecommend ='" + isShopRecommend + "'");
			}
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@startnum";
			array2[0] = startRowIndex.ToString();
			array[1] = "@count";
			array2[1] = maximumRows.ToString();
			array[2] = "@tablename";
			array2[2] = " ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID";
			array[3] = "@columnnames";
			array2[3] = stringBuilder.ToString();
			array[4] = "@ordername";
			array2[4] = "A.OrderID";
			array[5] = "@searchname";
			array2[5] = stringBuilder2.ToString();
			array[6] = "@sdesc";
			array2[6] = "desc";
			array[7] = "@isreturcount";
			array2[7] = "0";
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPageGetByRowNum", array, array2);
		}
		public DataTable SearchPerPageNew(int startRowIndex, int maximumRows, string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsSystemHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsSystemRecommend,");
			stringBuilder.Append("A.IsRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.CreateTime,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.SystemOrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("B.ShopName,");
			stringBuilder.Append("B.SubstationID,");
			stringBuilder.Append("B.Name AS SName");
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("  0=0 And A.productstate=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder2.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSaled = " + isSaled);
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder2.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder2.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
			{
				stringBuilder2.Append(" AND A.IsPanicBuy =" + isPanicBuy);
			}
			if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
			{
				stringBuilder2.Append(" AND A.IsSpellBuy =" + isSpellBuy);
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder2.Append(" AND B.ShopName like '%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(sName) != string.Empty)
			{
				stringBuilder2.Append(" AND B.SName like '%" + sName + "%' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSell ='" + isSell + "'");
			}
			if (Operator.FormatToEmpty(isShopNew) != "-1")
			{
				stringBuilder2.Append(" AND A.IsshopNew ='" + isShopNew + "'");
			}
			if (Operator.FormatToEmpty(isShopHot) != "-1")
			{
				if (SubstationID == "-1" || SubstationID == "all")
				{
					stringBuilder2.Append(" AND A.IsSystemHot ='" + isShopHot + "'");
				}
				else
				{
					stringBuilder2.Append(" AND A.IsHot ='" + isShopHot + "'");
				}
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder2.Append(" AND A.IsShopGood ='" + isShopGood + "'");
			}
			if (Operator.FormatToEmpty(isShopRecommend) != "-1")
			{
				if (SubstationID == "-1" || SubstationID == "all")
				{
					stringBuilder2.Append(" AND A.IsSystemRecommend ='" + isShopRecommend + "'");
				}
				else
				{
					stringBuilder2.Append(" AND A.IsRecommend ='" + isShopRecommend + "'");
				}
			}
			if (SubstationID != "-1")
			{
				stringBuilder2.Append(" AND B.SubstationID='" + SubstationID + "'");
			}
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@startnum";
			array2[0] = startRowIndex.ToString();
			array[1] = "@count";
			array2[1] = maximumRows.ToString();
			array[2] = "@tablename";
			array2[2] = " ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID";
			array[3] = "@columnnames";
			array2[3] = stringBuilder.ToString();
			array[4] = "@ordername";
			array2[4] = "A.OrderID";
			array[5] = "@searchname";
			array2[5] = stringBuilder2.ToString();
			array[6] = "@sdesc";
			array2[6] = "desc";
			array[7] = "@isreturcount";
			array2[7] = "0";
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPageGetByRowNum", array, array2);
		}
		public int SearchAllCount(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" 0=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder.Append(" AND [Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder.Append(" AND ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder.Append(" AND ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder.Append(" AND MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder.Append(" AND MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder.Append(" AND IsSaled LIKE '%" + isSaled + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
			{
				stringBuilder.Append(" AND IsPanicBuy =" + isPanicBuy);
			}
			if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
			{
				stringBuilder.Append(" AND IsSpellBuy =" + isSpellBuy);
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND MemLoginID ='" + MemLoginID + "' ");
			}
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@tablename";
			array2[0] = "ShopNum1_Shop_Product";
			array[1] = "@searchname";
			array2[1] = stringBuilder.ToString();
			array[2] = "@isreturcount";
			array2[2] = ((array2[1] == " 0=0") ? "2" : "1");
			return Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_CommonPageGetByRowNum", array, array2));
		}
		public int SearchAllCountNew(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" 0=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
			{
				stringBuilder.Append(" AND A.IsPanicBuy =" + isPanicBuy);
			}
			if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
			{
				stringBuilder.Append(" AND A.IsSpellBuy =" + isSpellBuy);
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder.Append(" AND B.ShopName like'%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(sName) != string.Empty)
			{
				stringBuilder.Append(" AND B.SName like'%" + sName + "%' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder.Append(" AND A.IsshopSell ='" + isSell + "'");
			}
			if (Operator.FormatToEmpty(isShopNew) != "-1")
			{
				stringBuilder.Append(" AND A.IsshopNew ='" + isShopNew + "'");
			}
			if (Operator.FormatToEmpty(isShopHot) != "-1")
			{
				stringBuilder.Append(" AND A.IsshopHot ='" + isShopHot + "'");
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopGood ='" + isShopGood + "'");
			}
			if (Operator.FormatToEmpty(isShopRecommend) != "-1")
			{
				stringBuilder.Append(" AND A.IsshopRecommend ='" + isShopRecommend + "'");
			}
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@tablename";
			array2[0] = " ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID";
			array[1] = "@searchname";
			array2[1] = stringBuilder.ToString();
			array[2] = "@isreturcount";
			array2[2] = ((array2[1] == " 0=0") ? "2" : "1");
			return Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_CommonPageGetByRowNum", array, array2));
		}
		public int SearchAllCountNew(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" 0=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productNum) != string.Empty)
			{
				stringBuilder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
			{
				stringBuilder.Append(" AND A.IsPanicBuy =" + isPanicBuy);
			}
			if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
			{
				stringBuilder.Append(" AND A.IsSpellBuy =" + isSpellBuy);
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder.Append(" AND B.ShopName like'%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(sName) != string.Empty)
			{
				stringBuilder.Append(" AND B.SName like'%" + sName + "%' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder.Append(" AND A.IsshopSell ='" + isSell + "'");
			}
			if (Operator.FormatToEmpty(isShopNew) != "-1")
			{
				stringBuilder.Append(" AND A.IsshopNew ='" + isShopNew + "'");
			}
			if (Operator.FormatToEmpty(isShopHot) != "-1")
			{
				if (SubstationID == "-1" || SubstationID == "all")
				{
					stringBuilder.Append(" AND A.IsSystemHot ='" + isShopHot + "'");
				}
				else
				{
					stringBuilder.Append(" AND A.IsHot ='" + isShopHot + "'");
				}
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder.Append(" AND A.IsShopGood ='" + isShopGood + "'");
			}
			if (Operator.FormatToEmpty(isShopRecommend) != "-1")
			{
				if (SubstationID == "-1" || SubstationID == "all")
				{
					stringBuilder.Append(" AND A.IsSystemRecommend ='" + isShopRecommend + "'");
				}
				else
				{
					stringBuilder.Append(" AND A.IsRecommend ='" + isShopRecommend + "'");
				}
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND B.SubstationID='" + SubstationID + "'");
			}
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@tablename";
			array2[0] = " ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID";
			array[1] = "@searchname";
			array2[1] = stringBuilder.ToString();
			array[2] = "@isreturcount";
			array2[2] = ((array2[1] == " 0=0") ? "2" : "1");
			return Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_CommonPageGetByRowNum", array, array2));
		}
		public int Update(string guids, string intState)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_Shop_Product");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("IsAudit = " + intState);
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] in (" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int UpdateProduct(string guids, string strName, string strValue)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Shop_Product SET ",
				strName,
				"=",
				strValue,
				" WHERE Guid IN (",
				guids,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_Shop_Product ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("[Guid] IN ");
			stringBuilder.Append("(" + guids + ") ");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetList(string categoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("[ID],");
			stringBuilder.Append("[Name],");
			stringBuilder.Append("[code]");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_ProductCategory");
			stringBuilder.Append(" WHERE FatherID=" + categoryID);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetShopInfoByGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_Shop_Product WHERE 1=1";
			if (!string.IsNullOrEmpty(guid))
			{
				text = text + " and Guid=" + guid;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataSet SearchProductList(string pageindex, string pagesize, string addresscode, string mainproductcategoryguid, string name, string startdate, string enddate, string brandguid, string keywords, string startshopprice, string endshopprice)
		{
			string[] array = new string[11];
			string[] array2 = new string[11];
			array[0] = "@pageindex";
			array2[0] = pageindex;
			array[1] = "@pagesize";
			array2[1] = pagesize;
			array[2] = "@addresscode";
			array2[2] = addresscode;
			array[3] = "@mainproductcategoryguid";
			array2[3] = mainproductcategoryguid;
			array[4] = "@name";
			array2[4] = name;
			array[5] = "@startdate";
			array2[5] = startdate;
			array[6] = "@enddate";
			array2[6] = enddate;
			array[7] = "@brandguid";
			array2[7] = brandguid;
			array[8] = "@keywords";
			array2[8] = keywords;
			array[9] = "@startshopprice";
			array2[9] = startshopprice;
			array[10] = "@endshopprice";
			array2[10] = endshopprice;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchProductList2", array, array2);
		}
		public DataSet SearchProductList(string pageindex, string pagesize, string addresscode, string mainproductcategoryguid, string name, string startdate, string enddate, string brandguid)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pageindex";
			array2[0] = pageindex;
			array[1] = "@pagesize";
			array2[1] = pagesize;
			array[2] = "@addresscode";
			array2[2] = addresscode;
			array[3] = "@mainproductcategoryguid";
			array2[3] = mainproductcategoryguid;
			array[4] = "@name";
			array2[4] = name;
			array[5] = "@startdate";
			array2[5] = startdate;
			array[6] = "@enddate";
			array2[6] = enddate;
			array[7] = "@brandguid";
			array2[7] = brandguid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchProductList", array, array2);
		}
		public DataTable SearchEspecialProduct(string pagesize, string field)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@field";
			array2[1] = field;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialProduct", array, array2);
		}
		public DataTable SearchEspecialProduct(string pagesize, string field, string OrderID, string SubstationID)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@field";
			array2[1] = field;
			array[2] = "@orderfield";
			array2[2] = OrderID;
			array[3] = "@SubstationID";
			array2[3] = SubstationID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialProduct1", array, array2);
		}
		public DataTable SearchEspecialProduct(string pagesize, string field, string OrderID)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@field";
			array2[1] = field;
			array[2] = "@orderfield";
			array2[2] = OrderID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialProduct2", array, array2);
		}
		public DataTable SearchProductByMemLoginID(string MemLoginID, string ProductCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top " + ProductCount + " ");
			stringBuilder.Append("[Name], ");
			stringBuilder.Append("[Guid], ");
			stringBuilder.Append("[MemLoginID] ");
			stringBuilder.Append("From ShopNum1_Shop_Product");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("MemLoginID ='" + MemLoginID + "'  AND IsAudit=1 AND IsDeleted = 0");
			stringBuilder.Append("Order By ModifyTime Desc");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetProductByCategoryCode(string categorycode, string pagesize, string current_page)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@categorycode";
			array2[0] = categorycode;
			array[1] = "@pagesize";
			array2[1] = pagesize;
			array[2] = "@current_page";
			array2[2] = current_page;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductByCategoryCode", array, array2);
		}
		public DataTable GetPanceProductByCategoryCode(string categorycode, string pagesize, string current_page)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@categorycode";
			array2[0] = categorycode;
			array[1] = "@pagesize";
			array2[1] = pagesize;
			array[2] = "@current_page";
			array2[2] = current_page;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetPanceProductByCategoryCode", array, array2);
		}
		public DataTable ProductCommentCount(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ProductCommentCount", array, array2);
		}
		public DataSet ProductComment(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ProductComment", array, array2);
		}
		public int SearchAllCountNew(int startRowIndex, int maximumRows, string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.Search(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.SearchNew(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID, string shopName, string sName)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.SearchPerPage(int startRowIndex, int maximumRows, string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.SearchPerPageNew(int startRowIndex, int maximumRows, string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName, string isSell, string isShopNew, string isShopHot, string isShopGood, string IsShopRecommend)
		{
			throw new NotImplementedException();
		}
		int IShopNum1_ProuductChecked_Action.SearchAllCount(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID)
		{
			throw new NotImplementedException();
		}
		int IShopNum1_ProuductChecked_Action.SearchAllCountNew(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName)
		{
			throw new NotImplementedException();
		}
		int IShopNum1_ProuductChecked_Action.Update(string guids, string intState)
		{
			throw new NotImplementedException();
		}
		int IShopNum1_ProuductChecked_Action.Delete(string guids)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.GetList(string categoryID)
		{
			throw new NotImplementedException();
		}
		DataSet IShopNum1_ProuductChecked_Action.SearchProductList(string pageindex, string pagesize, string addresscode, string mainproductcategoryguid, string name, string startdate, string enddate, string brandguid, string keywords, string startShopPrice, string endShopPrice)
		{
			throw new NotImplementedException();
		}
		DataSet IShopNum1_ProuductChecked_Action.SearchProductList(string pageindex, string pagesize, string addresscode, string mainproductcategoryguid, string name, string startdate, string enddate, string brandguid)
		{
			throw new NotImplementedException();
		}
		int IShopNum1_ProuductChecked_Action.UpdateProduct(string guids, string strName, string strValue)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.SearchProductByMemLoginID(string MemLoginID, string ProductCount)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.GetShopInfoByGuid(string guid)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.GetProductByCategoryCode(string categorycode, string pagesize, string current_page)
		{
			throw new NotImplementedException();
		}
		DataTable IShopNum1_ProuductChecked_Action.GetPanceProductByCategoryCode(string categorycode, string pagesize, string current_page)
		{
			throw new NotImplementedException();
		}
		public DataTable GetProductByCategoryID(string code, string showcount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT TOP " + showcount);
			stringBuilder.Append(" [Guid],[Name],OriginalImage,ThumbImage,SmallImage,AddressCode,ShopName,CreateTime,MarketPrice,ShopPrice,ProductCategoryCode,AddressValue,MemLoginID ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_Product");
			stringBuilder.Append(" WHERE 0=0 AND isdeleted=0 and issell=1 and issaled=1 and isaudit=1 And productstate=0 ");
			if (Operator.FormatToEmpty(code) != string.Empty)
			{
				if (code.IndexOf(",") != -1)
				{
					string[] array = code.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (i == 0)
						{
							stringBuilder.Append(" AND ProductCategoryCode LIKE '" + array[i] + "%'");
						}
						else
						{
							stringBuilder.Append(" or ProductCategoryCode LIKE '" + array[i] + "%'");
						}
					}
				}
				else
				{
					stringBuilder.Append(" AND ProductCategoryCode LIKE '" + code + "%'");
				}
			}
			stringBuilder.Append(" ORDER BY OrderID Desc,Modifytime desc");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetProductByCategoryID(string code, string showcount, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("     SELECT TOP " + showcount);
			stringBuilder.Append("     B.SubstationID,B.ShopName, A.[Guid],A.[Name],A.OriginalImage,A.ThumbImage,A.SmallImage,A.AddressCode,A.ShopName,A.MarketPrice,A.ShopPrice,A.ProductCategoryCode,A.AddressValue,A.MemLoginID       ");
			stringBuilder.Append("     FROM  ShopNum1_Shop_Product AS A LEFT JOIN ShopNum1_ShopInfo AS B ON A.MemLoginID=B.MemLoginID   ");
			stringBuilder.Append("     WHERE 0=0 AND A.isdeleted=0 and A.issell=1 and A.issaled=1 and A.isaudit=1 And A.productstate=0     ");
			if (Operator.FormatToEmpty(code) != string.Empty)
			{
				if (code.IndexOf(",") != -1)
				{
					string[] array = code.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (i == 0)
						{
							stringBuilder.Append(" AND A.ProductCategoryCode LIKE '" + array[i] + "%'");
						}
						else
						{
							stringBuilder.Append(" or A.ProductCategoryCode LIKE '" + array[i] + "%'");
						}
					}
				}
				else
				{
					stringBuilder.Append(" AND A.ProductCategoryCode LIKE '" + code + "%'");
				}
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND    B.SubstationID    = '" + SubstationID + "'");
			}
			stringBuilder.Append(" ORDER BY A.OrderID Desc,A.Modifytime desc");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchGroupProduct(string categorycode, string Sort, string SortType, string pagesize, string current_page)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@categorycode";
			array2[0] = categorycode;
			array[1] = "@Sort";
			array2[1] = Sort;
			array[2] = "@SortType";
			array2[2] = SortType;
			array[3] = "@pagesize";
			array2[3] = pagesize;
			array[4] = "@current_page";
			array2[4] = current_page;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchGroupProduct", array, array2);
		}
		public DataSet GetFurnitureProduct(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue)
		{
			int num = 0;
			string text = "";
			if (ordername == "-1")
			{
				ordername = "A.orderid";
			}
			if (ordername.ToLower() == "shopreputation")
			{
				ordername = "C.ShopReputation";
			}
			else
			{
				ordername = "A." + ordername;
			}
			if (productCategoryCode != "-1")
			{
				if (productCategoryCode.IndexOf(",") != -1)
				{
					string[] array = productCategoryCode.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (i == 0)
						{
							text = text + " A.ProductCategoryCode like '" + array[i] + "%'";
						}
						else
						{
							text = text + " or A.ProductCategoryCode LIKE '" + array[i] + "%'";
						}
					}
				}
				else
				{
					text = " A.ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
				}
			}
			else
			{
				text = "1=1";
			}
			if (addresscode != "-1" && addresscode != "000")
			{
				text = text + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
			}
			if (address != "-1")
			{
				text = text + " AND A.AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
			}
			text += " AND A.IsSaled =1 And A.isaudit=1 and A.issell=1 ";
			if (string.IsNullOrEmpty(soft))
			{
				soft = "desc";
			}
			if (startprice != string.Empty)
			{
				text = text + " And A.ShopPrice >=" + Operator.FilterString(startprice);
			}
			if (endprice != string.Empty)
			{
				text = text + " And A.ShopPrice <=" + Operator.FilterString(endprice);
			}
			if (productName != "-1" && !string.IsNullOrEmpty(productName))
			{
				text = text + " And A.Name like '%" + Operator.FilterString(productName) + "%' ";
			}
			if (brandguid != "-1")
			{
				text = text + "And A.BrandGuid='" + Operator.FilterString(brandguid) + "'";
			}
			if (Pvalue != null)
			{
				string text2 = string.Empty;
				bool flag = true;
				foreach (KeyValuePair<string, string> current in Pvalue)
				{
					if (current.Value != "0")
					{
						num++;
						if (flag)
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" AND (( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
							flag = false;
						}
						else
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" OR ( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
						}
					}
				}
				if (text2 != string.Empty)
				{
					text2 += "  )  ";
					text += text2;
				}
			}
			string[] array2 = new string[8];
			string[] array3 = new string[8];
			array2[0] = "@perpagenum";
			array3[0] = perpagenum;
			array2[1] = "@current_page";
			array3[1] = current_page;
			array2[2] = "@columnnames";
			array3[2] = "A.Guid,A.ShopName,A.Name,A.FeeType,A.ThumbImage,A.OriginalImage,A.MemLoginID,A.ShopPrice,A.AddressValue,A.AddressCode,A.SaleNumber ";
			array2[3] = "@ordername";
			array3[3] = ordername;
			array2[4] = "@searchname";
			array3[4] = text;
			array2[5] = "@sdesc";
			array3[5] = soft;
			array2[6] = "@propcount";
			array3[6] = num.ToString();
			array2[7] = "@isreturcount";
			array3[7] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProducts", array2, array3);
		}
		public DataSet GetFurnitureProduct1(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue, string strName)
		{
			int num = 0;
			string text = string.Empty;
			if (ordername == "-1")
			{
				ordername = "A.orderid";
			}
			if (ordername.ToLower() == "shopreputation")
			{
				ordername = "C.ShopReputation";
			}
			else
			{
				ordername = "A." + ordername;
			}
			if (productCategoryCode != "-1")
			{
				if (productCategoryCode.IndexOf(",") != -1)
				{
					string[] array = productCategoryCode.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (i == 0)
						{
							text = text + " A.ProductCategoryCode like '" + array[i] + "%'";
						}
						else
						{
							text = text + " or A.ProductCategoryCode LIKE '" + array[i] + "%'";
						}
					}
				}
				else
				{
					text = " A.ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
				}
			}
			else
			{
				text = "1=1";
			}
			if (addresscode != "-1" && addresscode != "000")
			{
				text = text + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
			}
			if (address != "-1")
			{
				text = text + " AND A.AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
			}
			text += " AND A.IsSaled =1 And A.isaudit=1 and A.issell=1 ";
			if (string.IsNullOrEmpty(soft))
			{
				soft = "desc";
			}
			if (strName != string.Empty)
			{
				text = text + " And A.Name like  '" + Operator.FilterString(strName) + "%'";
			}
			if (startprice != string.Empty)
			{
				text = text + " And A.ShopPrice >=" + Operator.FilterString(startprice);
			}
			if (endprice != string.Empty)
			{
				text = text + " And A.ShopPrice <=" + Operator.FilterString(endprice);
			}
			if (productName != "-1" && !string.IsNullOrEmpty(productName))
			{
				text = text + " And A.Name like '%" + Operator.FilterString(productName) + "%' ";
			}
			if (brandguid != "-1")
			{
				text = text + "And A.BrandGuid='" + Operator.FilterString(brandguid) + "'";
			}
			if (Pvalue != null)
			{
				string text2 = string.Empty;
				bool flag = true;
				foreach (KeyValuePair<string, string> current in Pvalue)
				{
					if (current.Value != "0")
					{
						num++;
						if (flag)
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" AND (( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
							flag = false;
						}
						else
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" OR ( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
						}
					}
				}
				if (text2 != string.Empty)
				{
					text2 += "  )  ";
					text += text2;
				}
			}
			string[] array2 = new string[8];
			string[] array3 = new string[8];
			array2[0] = "@perpagenum";
			array3[0] = perpagenum;
			array2[1] = "@current_page";
			array3[1] = current_page;
			array2[2] = "@columnnames";
			array3[2] = "A.Guid,A.ShopName,A.Name,A.FeeType,A.OriginalImage,A.MemLoginID,A.ShopPrice,A.AddressValue,A.AddressCode,C.ShopReputation,A.SaleNumber";
			array2[3] = "@ordername";
			array3[3] = ordername;
			array2[4] = "@searchname";
			array3[4] = text;
			array2[5] = "@sdesc";
			array3[5] = soft;
			array2[6] = "@propcount";
			array3[6] = num.ToString();
			array2[7] = "@isreturcount";
			array3[7] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProducts", array2, array3);
		}
		public DataSet GetFurnitureProduct2(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue, int IsShopNew, int IsshopHot, int IsShopGood, int IsShopRecommend)
		{
			int num = 0;
			string text = string.Empty;
			if (ordername == "-1")
			{
				ordername = "A.orderid";
			}
			if (ordername.ToLower() == "shopreputation")
			{
				ordername = "C.ShopReputation";
			}
			else
			{
				ordername = "A." + ordername;
			}
			if (productCategoryCode != "-1")
			{
				if (productCategoryCode.IndexOf(",") != -1)
				{
					string[] array = productCategoryCode.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (i == 0)
						{
							text = text + " A.ProductCategoryCode like '" + array[i] + "%'";
						}
						else
						{
							text = text + " or A.ProductCategoryCode LIKE '" + array[i] + "%'";
						}
					}
				}
				else
				{
					text = " A.ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
				}
			}
			else
			{
				text = "1=1";
			}
			if (addresscode != "-1" && addresscode != "000")
			{
				text = text + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
			}
			if (address != "-1")
			{
				text = text + " AND A.AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
			}
			text += " AND A.IsSaled =1 And A.isaudit=1 and A.issell=1 ";
			if (string.IsNullOrEmpty(soft))
			{
				soft = "desc";
			}
			if (IsShopNew == 1)
			{
				text = text + " And A.IsNew =" + IsShopNew;
			}
			if (IsshopHot == 1)
			{
				text = text + " And A.IsSystemHot =" + IsshopHot;
			}
			if (IsShopGood == 1)
			{
				text = text + " And A.IsShopGood =" + IsShopGood;
			}
			if (IsShopRecommend == 1)
			{
				text = text + " And A.IsRecommend =" + IsShopRecommend;
			}
			if (startprice != string.Empty)
			{
				text = text + " And A.ShopPrice >=" + Operator.FilterString(startprice);
			}
			if (endprice != string.Empty)
			{
				text = text + " And A.ShopPrice <=" + Operator.FilterString(endprice);
			}
			if (productName != "-1" && !string.IsNullOrEmpty(productName))
			{
				text = text + " And A.Name like '%" + Operator.FilterString(productName) + "%' ";
			}
			if (brandguid != "-1")
			{
				text = text + "And A.BrandGuid='" + Operator.FilterString(brandguid) + "'";
			}
			if (Pvalue != null)
			{
				string text2 = string.Empty;
				bool flag = true;
				foreach (KeyValuePair<string, string> current in Pvalue)
				{
					if (current.Value != "0")
					{
						num++;
						if (flag)
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" AND (( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
							flag = false;
						}
						else
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" OR ( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
						}
					}
				}
				if (text2 != string.Empty)
				{
					text2 += "  )  ";
					text += text2;
				}
			}
			string[] array2 = new string[8];
			string[] array3 = new string[8];
			array2[0] = "@perpagenum";
			array3[0] = perpagenum;
			array2[1] = "@current_page";
			array3[1] = current_page;
			array2[2] = "@columnnames";
			array3[2] = "A.Guid,A.ShopName,A.Name,A.FeeType,A.OriginalImage,A.MemLoginID,A.ShopPrice,A.AddressValue,A.AddressCode,C.ShopReputation,A.SaleNumber ";
			array2[3] = "@ordername";
			array3[3] = ordername;
			array2[4] = "@searchname";
			array3[4] = text;
			array2[5] = "@sdesc";
			array3[5] = soft;
			array2[6] = "@propcount";
			array3[6] = num.ToString();
			array2[7] = "@isreturcount";
			array3[7] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProducts", array2, array3);
		}
		public DataSet GetFurnitureProduct2(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue, int IsShopNew, int IsshopHot, int IsShopGood, int IsShopRecommend, string SubstationID)
		{
			int num = 0;
			string text = string.Empty;
			if (ordername == "-1")
			{
				ordername = "A.orderid";
			}
			if (ordername.ToLower() == "shopreputation")
			{
				ordername = "C.ShopReputation";
			}
			else
			{
				ordername = "A." + ordername;
			}
			if (productCategoryCode != "-1")
			{
				if (productCategoryCode.IndexOf(",") != -1)
				{
					string[] array = productCategoryCode.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (i == 0)
						{
							text = text + " A.ProductCategoryCode like '" + array[i] + "%'";
						}
						else
						{
							text = text + " or A.ProductCategoryCode LIKE '" + array[i] + "%'";
						}
					}
				}
				else
				{
					text = " A.ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
				}
			}
			else
			{
				text = "1=1";
			}
			if (addresscode != "-1" && addresscode != "000")
			{
				text = text + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
			}
			if (address != "-1")
			{
				text = text + " AND A.AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
			}
			text += " AND A.IsSaled =1 And A.isaudit=1 and A.issell=1 ";
			if (string.IsNullOrEmpty(soft))
			{
				soft = "desc";
			}
			if (IsShopNew == 1)
			{
				text = text + " And A.IsNew =" + IsShopNew;
			}
			if (IsshopHot == 1)
			{
				text = text + " And A.IsHot =" + IsshopHot;
			}
			if (IsShopGood == 1)
			{
				text = text + " And A.IsShopGood =" + IsShopGood;
			}
			if (IsShopRecommend == 1)
			{
				text = text + " And A.IsRecommend =" + IsShopRecommend;
			}
			if (startprice != string.Empty)
			{
				text = text + " And A.ShopPrice >=" + Operator.FilterString(startprice);
			}
			if (endprice != string.Empty)
			{
				text = text + " And A.ShopPrice <=" + Operator.FilterString(endprice);
			}
			if (productName != "-1" && !string.IsNullOrEmpty(productName))
			{
				text = text + " And A.Name like '%" + Operator.FilterString(productName) + "%' ";
			}
			if (brandguid != "-1")
			{
				text = text + "And A.BrandGuid='" + Operator.FilterString(brandguid) + "'";
			}
			if (SubstationID != "all")
			{
				text = text + "And A.SubstationID='" + Operator.FilterString(SubstationID) + "'";
			}
			if (Pvalue != null)
			{
				string text2 = string.Empty;
				bool flag = true;
				foreach (KeyValuePair<string, string> current in Pvalue)
				{
					if (current.Value != "0")
					{
						num++;
						if (flag)
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" AND (( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
							flag = false;
						}
						else
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" OR ( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
						}
					}
				}
				if (text2 != string.Empty)
				{
					text2 += "  )  ";
					text += text2;
				}
			}
			string[] array2 = new string[8];
			string[] array3 = new string[8];
			array2[0] = "@perpagenum";
			array3[0] = perpagenum;
			array2[1] = "@current_page";
			array3[1] = current_page;
			array2[2] = "@columnnames";
			array3[2] = "A.Guid,A.ShopName,A.Name,A.FeeType,A.OriginalImage,A.MemLoginID,A.ShopPrice,A.AddressValue,A.AddressCode,C.ShopReputation,A.SaleNumber ";
			array2[3] = "@ordername";
			array3[3] = ordername;
			array2[4] = "@searchname";
			array3[4] = text;
			array2[5] = "@sdesc";
			array3[5] = soft;
			array2[6] = "@propcount";
			array3[6] = num.ToString();
			array2[7] = "@isreturcount";
			array3[7] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProducts", array2, array3);
		}
		public DataTable SearchRelatedProduct(string productname, string memberid, int pageindex, int pagesize, string isreturcount)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@ProductName";
			array2[0] = productname;
			array[1] = "@MemberID";
			array2[1] = memberid;
			array[2] = "@pageindex";
			array2[2] = pageindex.ToString();
			array[3] = "@pagesize";
			array2[3] = pagesize.ToString();
			array[4] = "@isreturcount";
			array2[4] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchRelatedProduct", array, array2);
		}
		public DataTable SearchProductOrder(string pagesize, string field)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@field";
			array2[1] = field;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchProductOrder", array, array2);
		}
		public DataTable SearchProductOrder(string pagesize, string field, string SubstationID)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@field";
			array2[1] = field;
			array[2] = "@SubstationID";
			array2[2] = SubstationID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchProductOrder1", array, array2);
		}
		public DataTable GetOrderID(string guid)
		{
			guid = guid.Replace("'", "");
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT OrderID from  ShopNum1_Shop_Product where");
			stringBuilder.Append(" guid ='" + guid + "' ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetSystemOrderID(string guid)
		{
			guid = guid.Replace("'", "");
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT SystemOrderID  from  ShopNum1_Shop_Product where");
			stringBuilder.Append(" guid ='" + guid + "' ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataSet V8_2_GetFurnitureProductNew(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue, string strSaleType)
		{
			int num = 0;
			string text = "";
			if (ordername == "-1")
			{
				ordername = "orderid";
			}
			if (ordername.ToLower() == "shopreputation")
			{
				ordername = "ShopReputation";
			}
			if (productCategoryCode != "-1")
			{
				if (productCategoryCode.IndexOf(",") != -1)
				{
					string[] array = productCategoryCode.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (i == 0)
						{
							text = text + " And ProductCategoryCode like '" + array[i] + "%'";
						}
						else
						{
							text = text + " or ProductCategoryCode LIKE '" + array[i] + "%'";
						}
					}
				}
				else
				{
					text = " And ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
				}
			}
			if (addresscode != "-1" && addresscode != "000")
			{
				text = text + " AND AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
			}
			if (address != "-1")
			{
				text = text + " AND AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
			}
			if (startprice != string.Empty)
			{
				text = text + " And ShopPrice >=" + Operator.FilterString(startprice);
			}
			if (endprice != string.Empty)
			{
				text = text + " And ShopPrice <=" + Operator.FilterString(endprice);
			}
			if (productName != "-1" && !string.IsNullOrEmpty(productName))
			{
				text = text + " And Name like '%" + Operator.FilterString(productName) + "%' ";
			}
			if (brandguid != "-1")
			{
				text = text + "And BrandGuid='" + Operator.FilterString(brandguid) + "'";
			}
			string text2 = string.Empty;
			if (Pvalue != null)
			{
				bool flag = true;
				foreach (KeyValuePair<string, string> current in Pvalue)
				{
					if (current.Value != "0")
					{
						num++;
						if (flag)
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" AND (( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
							flag = false;
						}
						else
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" OR ( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
						}
					}
				}
				if (text2 != string.Empty)
				{
					text2 += "  )  ";
				}
			}
			if (strSaleType != null)
			{
				if (!(strSaleType == "1"))
				{
					if (!(strSaleType == "2"))
					{
						if (!(strSaleType == "3"))
						{
							if (strSaleType == "4")
							{
								text += " And zh!=''";
							}
						}
						else
						{
							text += " And qg=1";
						}
					}
					else
					{
						text += " And zk!=''";
					}
				}
				else
				{
					text += " And tg!=''";
				}
			}
			string[] array2 = new string[8];
			string[] array3 = new string[8];
			array2[0] = "@pagesize";
			array3[0] = perpagenum;
			array2[1] = "@currentpage";
			array3[1] = current_page;
			array2[2] = "@condition";
			array3[2] = text;
			array2[3] = "@ordercolumn";
			array3[3] = ordername;
			array2[4] = "@sortvalue";
			array3[4] = soft;
			array2[5] = "@propcount";
			array3[5] = num.ToString();
			array2[6] = "@propvalue";
			array3[6] = text2;
			array2[7] = "@resultnum";
			array3[7] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProduct_V82", array2, array3);
		}
		public DataSet V8_2_GetFurnitureProductNew(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue, string strSaleType, string strSubstationID)
		{
			int num = 0;
			string text = "";
			if (ordername == "-1")
			{
				ordername = "orderid";
			}
			if (ordername.ToLower() == "shopreputation")
			{
				ordername = "ShopReputation";
			}
			if (productCategoryCode != "-1")
			{
				if (productCategoryCode.IndexOf(",") != -1)
				{
					string[] array = productCategoryCode.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (i == 0)
						{
							text = text + " And ProductCategoryCode like '" + array[i] + "%'";
						}
						else
						{
							text = text + " or ProductCategoryCode LIKE '" + array[i] + "%'";
						}
					}
				}
				else
				{
					text = " And ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
				}
			}
			if (addresscode != "-1" && addresscode != "000")
			{
				text = text + " AND AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
			}
			if (address != "-1")
			{
				text = text + " AND AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
			}
			if (startprice != string.Empty)
			{
				text = text + " And ShopPrice >=" + Operator.FilterString(startprice);
			}
			if (endprice != string.Empty)
			{
				text = text + " And ShopPrice <=" + Operator.FilterString(endprice);
			}
			if (productName != "-1" && !string.IsNullOrEmpty(productName))
			{
				text = text + " And Name like '%" + Operator.FilterString(productName) + "%' ";
			}
			if (brandguid != "-1")
			{
				text = text + "And BrandGuid='" + Operator.FilterString(brandguid) + "'";
			}
			if (!string.IsNullOrEmpty(strSubstationID))
			{
				text = text + " And SubstationID='" + strSubstationID + "'";
			}
			string text2 = string.Empty;
			if (Pvalue != null)
			{
				bool flag = true;
				foreach (KeyValuePair<string, string> current in Pvalue)
				{
					if (current.Value != "0")
					{
						num++;
						if (flag)
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" AND (( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
							flag = false;
						}
						else
						{
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								" OR ( PropID=",
								current.Key,
								" AND PropValueID=",
								current.Value,
								")"
							});
						}
					}
				}
				if (text2 != string.Empty)
				{
					text2 += "  )  ";
				}
			}
			if (strSaleType != null)
			{
				if (!(strSaleType == "1"))
				{
					if (!(strSaleType == "2"))
					{
						if (!(strSaleType == "3"))
						{
							if (strSaleType == "4")
							{
								text += " And zh!=''";
							}
						}
						else
						{
							text += " And qg=1";
						}
					}
					else
					{
						text += " And zk!=''";
					}
				}
				else
				{
					text += " And tg!=''";
				}
			}
			string[] array2 = new string[8];
			string[] array3 = new string[8];
			array2[0] = "@pagesize";
			array3[0] = perpagenum;
			array2[1] = "@currentpage";
			array3[1] = current_page;
			array2[2] = "@condition";
			array3[2] = text;
			array2[3] = "@ordercolumn";
			array3[3] = ordername;
			array2[4] = "@sortvalue";
			array3[4] = soft;
			array2[5] = "@propcount";
			array3[5] = num.ToString();
			array2[6] = "@propvalue";
			array3[6] = text2;
			array2[7] = "@resultnum";
			array3[7] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProduct_V821", array2, array3);
		}
		public DataTable GetSystemRecommendProduct(string string_0, string IsAudit, string IsSell, string IsDeleted, string IsSaled, string IsSystemRecommend, string orderWord, string orderType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("   SELECT TOP " + string_0 + "  B.ShopName,B.SubstationID ,A.*     ");
			stringBuilder.Append("   FROM ShopNum1_Shop_Product AS A LEFT  JOIN ShopNum1_ShopInfo AS B     ");
			stringBuilder.Append("   ON A.MemLoginID=B.MemLoginID    ");
			stringBuilder.Append("   WHERE 1=1    ");
			if (IsAudit != "-1")
			{
				stringBuilder.Append("   AND A.IsAudit=" + IsAudit + "    ");
			}
			if (IsSell != "-1")
			{
				stringBuilder.Append("   AND A.IsSell=" + IsSell + "    ");
			}
			if (IsDeleted != "-1")
			{
				stringBuilder.Append("   AND A.IsDeleted=" + IsDeleted + "    ");
			}
			if (IsSaled != "-1")
			{
				stringBuilder.Append("   AND A.IsSaled=" + IsSaled + "    ");
			}
			if (IsSystemRecommend != "-1")
			{
				stringBuilder.Append("   AND A.IsSystemRecommend=" + IsSystemRecommend + "    ");
			}
			stringBuilder.Append(string.Concat(new string[]
			{
				"   ORDER BY ",
				orderWord,
				"   ",
				orderType,
				"      "
			}));
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetAgentRecommendProduct(string string_0, string IsAudit, string IsSell, string IsDeleted, string IsSaled, string IsRecommend, string orderWord, string orderType, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("   SELECT TOP " + string_0 + "  B.ShopName,B.SubstationID ,A.*     ");
			stringBuilder.Append("   FROM ShopNum1_Shop_Product AS A LEFT  JOIN ShopNum1_ShopInfo AS B     ");
			stringBuilder.Append("   ON A.MemLoginID=B.MemLoginID    ");
			stringBuilder.Append("   WHERE 1=1    ");
			if (IsAudit != "-1")
			{
				stringBuilder.Append("   AND A.IsAudit=" + IsAudit + "    ");
			}
			if (IsSell != "-1")
			{
				stringBuilder.Append("   AND A.IsSell=" + IsSell + "    ");
			}
			if (IsDeleted != "-1")
			{
				stringBuilder.Append("   AND A.IsDeleted=" + IsDeleted + "    ");
			}
			if (IsSaled != "-1")
			{
				stringBuilder.Append("   AND A.IsSaled=" + IsSaled + "    ");
			}
			if (IsRecommend != "-1")
			{
				stringBuilder.Append("   AND A.IsRecommend=" + IsRecommend + "    ");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append("   AND B.SubstationID='" + SubstationID + "'    ");
			}
			stringBuilder.Append(string.Concat(new string[]
			{
				"   ORDER BY ",
				orderWord,
				"   ",
				orderType,
				"      "
			}));
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetSystemHotProduct(string string_0, string IsAudit, string IsSell, string IsDeleted, string IsSaled, string IsSystemHot, string orderWord, string orderType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("   SELECT TOP " + string_0 + "  B.ShopName,B.SubstationID ,A.*     ");
			stringBuilder.Append("   FROM ShopNum1_Shop_Product AS A LEFT  JOIN ShopNum1_ShopInfo AS B     ");
			stringBuilder.Append("   ON A.MemLoginID=B.MemLoginID    ");
			stringBuilder.Append("   WHERE 1=1    ");
			if (IsAudit != "-1")
			{
				stringBuilder.Append("   AND A.IsAudit=" + IsAudit + "    ");
			}
			if (IsSell != "-1")
			{
				stringBuilder.Append("   AND A.IsSell=" + IsSell + "    ");
			}
			if (IsDeleted != "-1")
			{
				stringBuilder.Append("   AND A.IsDeleted=" + IsDeleted + "    ");
			}
			if (IsSaled != "-1")
			{
				stringBuilder.Append("   AND A.IsSaled=" + IsSaled + "    ");
			}
			if (IsSystemHot != "-1")
			{
				stringBuilder.Append("   AND A.IsSystemHot=" + IsSystemHot + "    ");
			}
			stringBuilder.Append(string.Concat(new string[]
			{
				"   ORDER BY ",
				orderWord,
				"   ",
				orderType,
				"      "
			}));
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetAgentHotProduct(string string_0, string IsAudit, string IsSell, string IsDeleted, string IsSaled, string IsHot, string orderWord, string orderType, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("   SELECT TOP " + string_0 + "  B.ShopName,B.SubstationID ,A.*     ");
			stringBuilder.Append("   FROM ShopNum1_Shop_Product AS A LEFT  JOIN ShopNum1_ShopInfo AS B     ");
			stringBuilder.Append("   ON A.MemLoginID=B.MemLoginID    ");
			stringBuilder.Append("   WHERE 1=1    ");
			if (IsAudit != "-1")
			{
				stringBuilder.Append("   AND A.IsAudit=" + IsAudit + "    ");
			}
			if (IsSell != "-1")
			{
				stringBuilder.Append("   AND A.IsSell=" + IsSell + "    ");
			}
			if (IsDeleted != "-1")
			{
				stringBuilder.Append("   AND A.IsDeleted=" + IsDeleted + "    ");
			}
			if (IsSaled != "-1")
			{
				stringBuilder.Append("   AND A.IsSaled=" + IsSaled + "    ");
			}
			if (IsHot != "-1")
			{
				stringBuilder.Append("   AND A.IsHot=" + IsHot + "    ");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append("   AND  B.SubstationID='" + SubstationID + "'    ");
			}
			stringBuilder.Append(string.Concat(new string[]
			{
				"   ORDER BY ",
				orderWord,
				"   ",
				orderType,
				"      "
			}));
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable V8_2_SearchPerPageNew(string resultnum, string pagesize, string currentpage, string productName, string productCategory, string price1, string price2, string isSaled, string isAudit, string MemLoginID, string shopName, string isSell, string isNew, string isHot, string isShopGood, string isRecommend)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.CreateTime,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("A.ModifyTime,");
			stringBuilder.Append("B.ShopName");
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("  0=0 And A.productstate=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSaled = " + isSaled);
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder2.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder2.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder2.Append(" AND B.ShopName like '%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSell ='" + isSell + "'");
			}
			if (Operator.FormatToEmpty(isNew) != "-1")
			{
				stringBuilder2.Append(" AND A.IsNew ='" + isNew + "'");
			}
			if (Operator.FormatToEmpty(isHot) != "-1")
			{
				stringBuilder2.Append(" AND A.IsHot ='" + isHot + "'");
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder2.Append(" AND A.IsShopGood ='" + isShopGood + "'");
			}
			if (Operator.FormatToEmpty(isRecommend) != "-1")
			{
				stringBuilder2.Append(" AND A.IsRecommend ='" + isRecommend + "'");
			}
			string text = "Select " + stringBuilder.ToString() + " From ShopNum1_Shop_Product A Inner Join ShopNum1_ShopInfo B on B.memloginId=A.memloginId WHERE " + stringBuilder2.ToString();
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
			array2[4] = "";
			array[5] = "@ordercolumn";
			array2[5] = "ModifyTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable V8_2_SearchPerPageNew(string resultnum, string pagesize, string currentpage, string productName, string productCategory, string price1, string price2, string isSaled, string isAudit, string MemLoginID, string shopName, string isSell, string isNew, string isHot, string isShopGood, string isRecommend, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsSystemHot,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsSystemRecommend,");
			stringBuilder.Append("A.IsRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.CreateTime,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.SystemOrderID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("A.ModifyTime,");
			stringBuilder.Append("B.SubstationID as strSubstationID,");
			stringBuilder.Append("B.ShopName");
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("  0=0 And A.productstate=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSaled = " + isSaled);
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder2.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder2.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder2.Append(" AND B.ShopName like '%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSell ='" + isSell + "'");
			}
			if (Operator.FormatToEmpty(isNew) != "-1")
			{
				stringBuilder2.Append(" AND A.IsNew ='" + isNew + "'");
			}
			if (Operator.FormatToEmpty(isHot) != "-1")
			{
				stringBuilder2.Append(" AND   A.IsHot='" + isHot + "'");
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder2.Append(" AND A.IsShopGood ='" + isShopGood + "'");
			}
			if (Operator.FormatToEmpty(isRecommend) != "-1")
			{
				stringBuilder2.Append(" AND  A.IsRecommend='" + isRecommend + "'");
			}
			if (SubstationID != "-1")
			{
				stringBuilder2.Append(" AND    B.SubstationID='" + SubstationID + "'");
			}
			string text = "Select " + stringBuilder.ToString() + " From ShopNum1_Shop_Product A Inner Join ShopNum1_ShopInfo B on B.memloginId=A.memloginId WHERE " + stringBuilder2.ToString();
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
			array2[4] = "";
			array[5] = "@ordercolumn";
			array2[5] = "ModifyTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable V8_2_SearchPerPageNew1(string resultnum, string pagesize, string currentpage, string productName, string productCategory, string price1, string price2, string isSaled, string isAudit, string MemLoginID, string shopName, string isSell, string isNew, string isHot, string isShopGood, string isRecommend, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("A.[Guid],");
			stringBuilder.Append("A.[Name],");
			stringBuilder.Append("A.ProductNum,");
			stringBuilder.Append("A.MemLoginID,");
			stringBuilder.Append("A.RepertoryCount,");
			stringBuilder.Append("A.IsNew,");
			stringBuilder.Append("A.IsSystemHot,");
			stringBuilder.Append("A.IsHot,");
			stringBuilder.Append("A.IsPromotion,");
			stringBuilder.Append("A.IsShopNew,");
			stringBuilder.Append("A.IsShopHot,");
			stringBuilder.Append("A.IsShopRecommend,");
			stringBuilder.Append("A.IsSystemRecommend,");
			stringBuilder.Append("A.IsRecommend,");
			stringBuilder.Append("A.IsShopGood,");
			stringBuilder.Append("A.SaleNumber,");
			stringBuilder.Append("A.CreateTime,");
			stringBuilder.Append("A.IsAudit,");
			stringBuilder.Append("A.MarketPrice,");
			stringBuilder.Append("A.Shopprice,");
			stringBuilder.Append("A.OriginalImage,");
			stringBuilder.Append("A.ProductCategoryName,");
			stringBuilder.Append("B.ShopID,");
			stringBuilder.Append("A.SystemOrderID,");
			stringBuilder.Append("A.OrderID,");
			stringBuilder.Append("A.IsSell,");
			stringBuilder.Append("A.IsSaled,");
			stringBuilder.Append("A.ModifyTime,");
			stringBuilder.Append("B.SubstationID as strSubstationID,");
			stringBuilder.Append("B.ShopName");
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.Append("  0=0 And A.productstate=0");
			if (Operator.FormatToEmpty(productName) != string.Empty)
			{
				stringBuilder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
			}
			if (Operator.FormatToEmpty(productCategory) != "-1")
			{
				stringBuilder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
			}
			if (Operator.FormatToEmpty(price1) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice  >= " + price1);
			}
			if (Operator.FormatToEmpty(price2) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MarketPrice <= " + price2);
			}
			if (Operator.FormatToEmpty(isSaled) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSaled = " + isSaled);
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder2.Append(" AND A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder2.Append(" AND A.IsAudit =" + isAudit);
				}
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				stringBuilder2.Append(" AND B.ShopName like '%" + shopName + "%' ");
			}
			if (Operator.FormatToEmpty(isSell) != "-1")
			{
				stringBuilder2.Append(" AND A.IsSell ='" + isSell + "'");
			}
			if (Operator.FormatToEmpty(isNew) != "-1")
			{
				stringBuilder2.Append(" AND A.IsNew ='" + isNew + "'");
			}
			if (Operator.FormatToEmpty(isHot) != "-1")
			{
				stringBuilder2.Append(" AND    A.IsHot='" + isHot + "'");
			}
			if (Operator.FormatToEmpty(isShopGood) != "-1")
			{
				stringBuilder2.Append(" AND A.IsShopGood ='" + isShopGood + "'");
			}
			if (Operator.FormatToEmpty(isRecommend) != "-1")
			{
				stringBuilder2.Append(" AND    A.IsRecommend='" + isRecommend + "'");
			}
			if (SubstationID != "-1")
			{
				stringBuilder2.Append(" AND    B.SubstationID='" + SubstationID + "'");
			}
			string text = "Select " + stringBuilder.ToString() + " From ShopNum1_Shop_Product A Inner Join ShopNum1_ShopInfo B on B.memloginId=A.memloginId WHERE " + stringBuilder2.ToString();
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
			array2[4] = "";
			array[5] = "@ordercolumn";
			array2[5] = "ModifyTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
