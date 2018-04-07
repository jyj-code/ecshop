using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Common_Action : IShop_Common_Action
	{
		public int ReturnMaxID(string columnName, string tableName)
		{
			return DatabaseExcetue.ReturnMaxID(columnName, tableName);
		}
		public int ReturnMaxID(string columnName, string shopID, string shopIDValue, string tableName)
		{
			return DatabaseExcetue.ReturnMaxID(columnName, shopID, shopIDValue, tableName);
		}
		public int ReturnMaxIDByMemLoginID(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "SELECT Max(OrderID) AS NUM FROM ShopNum1_shop_ProductCategory WHERE MemLoginID = '" + MemLoginID + "' ";
			DataTable dataTable = null;
			try
			{
				dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			}
			catch (Exception ex)
			{
				ErrorShow.Show("Error_" + ex.Message);
				throw ex;
			}
			if (dataTable.Rows[0]["NUM"].ToString() != "" && dataTable.Rows.Count > 0)
			{
				return int.Parse(dataTable.Rows[0]["NUM"].ToString());
			}
			return 0;
		}
		public string ComputeDispatchPrice(string formula)
		{
			string strSql = string.Empty;
			strSql = "SELECT " + formula + " AS DispatchPrice";
			decimal d = Convert.ToDecimal(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["DispatchPrice"].ToString());
			return Convert.ToString(Math.Round(d, 2));
		}
		public string ComputeOderPrice(string orderPrice)
		{
			string strSql = string.Empty;
			strSql = "SELECT " + orderPrice + " AS OrderPrice";
			decimal d = Convert.ToDecimal(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["OrderPrice"].ToString());
			return Convert.ToString(Math.Round(d, 2));
		}
		public string ComputeInvoicePrice(string invoiceTax)
		{
			string strSql = string.Empty;
			strSql = "SELECT " + invoiceTax + " AS InvoiceTax";
			decimal d = Convert.ToDecimal(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["InvoiceTax"].ToString());
			return Convert.ToString(Math.Round(d, 2));
		}
		public string ComputeDiscountPrice(string discount)
		{
			string strSql = string.Empty;
			strSql = "SELECT " + discount + " AS Discount";
			decimal d = Convert.ToDecimal(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Discount"].ToString());
			return Convert.ToString(Math.Round(d, 2));
		}
		public static string GetShopPath(string memLoginID)
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = new Shop_ShopInfo_Action();
			DataTable shopIDAndOpenTimeByMemLoginID = shop_ShopInfo_Action.GetShopIDAndOpenTimeByMemLoginID(memLoginID);
			if (shopIDAndOpenTimeByMemLoginID != null && shopIDAndOpenTimeByMemLoginID.Rows.Count > 0)
			{
				string text = shopIDAndOpenTimeByMemLoginID.Rows[0]["ShopID"].ToString();
				string text2 = DateTime.Parse(shopIDAndOpenTimeByMemLoginID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
				return string.Concat(new string[]
				{
					"~/Shop/Shop/",
					text2.Replace("-", "/"),
					"/shop",
					text,
					"/"
				});
			}
			return "";
		}
		public static string GetShopImgPath(string memlogid)
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = new Shop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(memlogid);
			string text = memLoginInfo.Rows[0]["ShopID"].ToString();
			DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			return string.Concat(new string[]
			{
				"/ImgUpload/shopImage/",
				DateTime.Now.ToString("yyyy"),
				"/shop",
				text,
				"/"
			});
		}
	}
}
