using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ProuductChecked_Action
	{
		DataTable Search(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend);
		DataTable SearchNew(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID, string shopName, string sName);
		DataTable SearchPerPage(int startRowIndex, int maximumRows, string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID);
		DataTable SearchPerPageNew(int startRowIndex, int maximumRows, string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName, string isSell, string isShopNew, string isShopHot, string isShopGood, string isShopRecommend);
		int SearchAllCount(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string shopID);
		int SearchAllCountNew(string productName, string productNum, string productCategory, string price1, string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID, string shopName, string sName);
		int Update(string guids, string intState);
		int Delete(string guids);
		DataTable GetList(string categoryID);
		DataSet SearchProductList(string pageindex, string pagesize, string addresscode, string mainproductcategoryguid, string name, string startdate, string enddate, string brandguid, string keywords, string startShopPrice, string endShopPrice);
		DataSet SearchProductList(string pageindex, string pagesize, string addresscode, string mainproductcategoryguid, string name, string startdate, string enddate, string brandguid);
		int UpdateProduct(string guids, string strName, string strValue);
		DataTable SearchProductByMemLoginID(string MemLoginID, string ProductCount);
		DataTable GetShopInfoByGuid(string guid);
		DataTable GetProductByCategoryCode(string categorycode, string pagesize, string current_page);
		DataTable GetPanceProductByCategoryCode(string categorycode, string pagesize, string current_page);
		DataTable GetProductByCategoryID(string categoryid, string showcount);
		DataTable SearchGroupProduct(string categorycode, string Sort, string SortType, string pagesize, string current_page);
		DataSet GetFurnitureProduct(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue);
		DataTable SearchRelatedProduct(string productname, string memberid, int pageindex, int pagesize, string isreturcount);
		DataTable SearchProductOrder(string pagesize, string field);
		DataSet GetFurnitureProduct1(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue, string strName);
		DataSet GetFurnitureProduct2(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue, int IsShopNew, int IsshopHot, int IsShopGood, int IsShopRecommend);
		DataTable GetOrderID(string guid);
		DataSet V8_2_GetFurnitureProductNew(string addresscode, string address, string productCategoryCode, string ordername, string soft, string startprice, string endprice, string productName, string brandguid, string perpagenum, string current_page, string isreturcount, Dictionary<string, string> Pvalue, string strSaleType);
	}
}
