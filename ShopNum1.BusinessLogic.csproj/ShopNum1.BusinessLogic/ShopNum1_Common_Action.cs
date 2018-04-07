using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Common_Action : IShopNum1_Common_Action
	{
		public static int ReturnMaxID(string columnName, string tableName)
		{
			return DatabaseExcetue.ReturnMaxID(columnName, tableName);
		}
		public static int ReturnMaxID(string columnName, string shopID, string shopIDValue, string tableName)
		{
			return DatabaseExcetue.ReturnMaxID(columnName, shopID, shopIDValue, tableName);
		}
		public DataTable CommonGetPageContent(string perpagenum, string current_page, string tablename, string columnnames, string ordername, string searchname, int sdesc)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@tablename";
			array2[2] = tablename;
			array[3] = "@columnnames";
			array2[3] = ((columnnames == "-1") ? "*" : columnnames);
			array[4] = "@ordername";
			array2[4] = ordername;
			array[5] = "@searchname";
			array2[5] = ((searchname == "-1") ? "1=1" : searchname);
			array[6] = "@sdesc";
			array2[6] = ((sdesc == 1) ? "desc" : "asc");
			array[7] = "@isreturcount";
			array2[7] = "0";
			return DatabaseExcetue.ReturnDataTable("Pro_CommonPage", array, array2);
		}
		public DataSet CommonGetPageCount(string perpagenum, string tablename, string searchname)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@tablename";
			array2[1] = tablename;
			array[2] = "@searchname";
			array2[2] = ((searchname == "-1") ? "1=1" : searchname);
			array[3] = "@isreturcount";
			array2[3] = "1";
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPage", array, array2);
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
		public int DeleteAllFromTables(string tables)
		{
			string[] array = tables.Split(new char[]
			{
				';'
			});
			List<string> list = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string str = array2[i];
				string text = "truncate table " + str + ";";
				list.Add(text);
				stringBuilder.Append(text);
			}
			int result;
			if (list.Count > 0)
			{
				try
				{
					DatabaseExcetue.RunTransactionSql(list);
					result = 1;
					return result;
				}
				catch
				{
					result = 0;
					return result;
				}
			}
			result = 0;
			return result;
		}
		public int Insert(string strTab, string strColumn, string strInsertValue)
		{
			string strSql = string.Concat(new string[]
			{
				"INSERT INTO ",
				strTab,
				" (",
				strColumn,
				")VALUES(",
				strInsertValue,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
