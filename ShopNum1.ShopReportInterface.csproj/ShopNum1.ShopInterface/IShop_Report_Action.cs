using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Report_Action
	{
		DataTable SearchShopSellOrder(string MemLoginID, string dispatchTime1, string dispatchTime2, string ProductName);
		DataTable SearchClickCount(string ShopID, string SaleNumber1, string SaleNumber2, string ClickCount1, string ClickCount2, string ProductName);
		DataTable Search(string MemLoginID, string productCategoryCode, string SaleNumber1, string SaleNumber2, string RepertoryCount1, string RepertoryCount2, string productname);
	}
}
