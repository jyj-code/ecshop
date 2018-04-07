using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ExtendQutation_Action : IShopNum1_ExtendQutation_Action
	{
		public int Add()
		{
			return 0;
		}
		public DataTable Search(int productCategoryID, string brandguid, string name)
		{
			string text = string.Empty;
			text += " Create TABLE #Temp(ID INT) ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" INSERT #Temp SELECT ID  FROM ShopNum1_ProductCategory WHERE FatherID=",
				productCategoryID,
				" OR ID=",
				productCategoryID,
				" "
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" INSERT #Temp SELECT ID  FROM ShopNum1_ProductCategory WHERE FatherID IN (SELECT ID FROM ShopNum1_ProductCategory WHERE FatherID=",
				productCategoryID,
				") "
			});
			text += "SELECT \tGuid\t, \tName\t, \tOriginalImge\t, \tThumbImage\t, \tSmallImage\t, \tRepertoryNumber\t, \tWeight\t, \tRepertoryCount\t, \tUnitName\t, \tRepertoryAlertCount\t, \tPresentScore\t, \tPresentRankScore\t, \tSocreIntegral\t, \tLimitBuyCount\t, \tCostPrice\t, \tMarketPrice\t, \tShopPrice\t, \tBrief\t, \tClickCount\t, \tCollectCount\t, \tBuyCount\t, \tCommentCount\t, \tReferCount\t, \tIsSaled\t, \tIsBest\t, \tIsNew\t, \tIsHot\t, \tIsRecommend\t, \tIsReal\t, \tIsOnlySaled\t, \tTitle\t, \tDescription\t, \tKeywords\t, \tOrderID\t, \tSupplierGuid\t, \tBrandGuid\t, \tProductCategoryID\t, \tProductTypeGuid\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted FROM ShopNum1_Product  WHERE  IsSaled=1 AND  ProductCategoryID IN(SELECT * FROM  #Temp)";
			if (!string.IsNullOrEmpty(name))
			{
				text = text + " AND Name='" + Operator.FilterString(name) + "'";
			}
			if (!string.IsNullOrEmpty(brandguid))
			{
				text = text + " AND BrandGuid='" + brandguid + "'";
			}
			text += "  DROP TABLE #Temp";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchProduct(int productCategoryID, string brandguid, string name, int IsDeleted)
		{
			string text = string.Empty;
			text += "SELECT \tA.Guid, \tB.Name, \tC.Name AS CaregoryName, \tA.Name AS ProductName,  \tA.OriginalImge\t, \tA.ThumbImage\t, \tA.SmallImage\t, \tA.RepertoryNumber\t, \tA.Weight\t, \tA.RepertoryCount\t, \tA.UnitName\t, \tA.RepertoryAlertCount\t, \tA.PresentScore\t, \tA.PresentRankScore\t, \tA.SocreIntegral\t, \tA.LimitBuyCount\t, \tA.CostPrice\t, \tA.MarketPrice\t, \tA.ShopPrice\t, \tA.Brief\t, \tA.ClickCount\t, \tA.CollectCount\t, \tA.BuyCount\t, \tA.CommentCount\t, \tReferCount\t, \tA.IsSaled\t, \tA.IsBest\t, \tA.IsNew\t, \tA.IsHot\t, \tA.IsRecommend\t, \tA.IsReal\t, \tA.IsOnlySaled\t, \tA.Title\t, \tA.Description\t, \tA.Keywords\t, \tA.OrderID\t, \tA.SupplierGuid\t, \tA.BrandGuid\t, \tA.ProductCategoryID\t, \tA.ProductTypeGuid\t, \tA.CreateUser\t, \tA.CreateTime\t, \tA.ModifyUser\t, \tA.ModifyTime\t, \tA.IsDeleted FROM ShopNum1_Product AS A,ShopNum1_Brand AS B,ShopNum1_ProductCategory AS C  WHERE  A.IsSaled=1 AND A.IsDeleted =0 AND A.BrandGuid =B.Guid AND A.ProductCategoryID = C.ID";
			if (!string.IsNullOrEmpty(name))
			{
				text = text + " AND A.Name='" + Operator.FilterString(name) + "'";
			}
			if (!string.IsNullOrEmpty(brandguid))
			{
				text = text + " AND A.BrandGuid='" + brandguid + "'";
			}
			if (productCategoryID != -1)
			{
				text = text + " AND A.ProductCategoryID=" + productCategoryID;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
