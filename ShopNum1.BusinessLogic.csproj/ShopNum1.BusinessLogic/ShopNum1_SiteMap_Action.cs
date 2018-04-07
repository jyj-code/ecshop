using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SiteMap_Action : IShopNum1_SiteMap_Action
	{
		public string Search(string table, string guid)
		{
			string text = string.Empty;
			text = "SELECT Guid,Name  FROM " + table + " WHERE 0=0";
			guid = guid.Replace("'", "");
			if (Operator.FormatToEmpty(guid) != "-1")
			{
				text = text + " AND  Guid='" + guid + "'";
			}
			string result;
			if (DatabaseExcetue.ReturnDataTable(text).Rows.Count > 0)
			{
				result = DatabaseExcetue.ReturnDataTable(text).Rows[0]["Name"].ToString();
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public string SearchNameByID(string table, string string_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT ID,Name  FROM " + table + " WHERE ID=" + string_0;
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Name"].ToString();
		}
		public string SearchOrganizBuyInfoName(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid,ProductGuid FROM ShopNum1_OrganizBuyInfo WHERE Guid='" + guid + "'";
			string str = DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["ProductGuid"].ToString();
			string strSql2 = "SELECT Guid,Name From ShopNum1_Product  WHERE guid='" + str + "'";
			return DatabaseExcetue.ReturnDataTable(strSql2).Rows[0]["Name"].ToString();
		}
		public string SearchTitle(string table, string guid)
		{
			string strSql = string.Empty;
			if (Operator.FormatToEmpty(guid) != string.Empty)
			{
				strSql = string.Concat(new string[]
				{
					"SELECT Guid,Title  FROM ",
					table,
					" WHERE Guid='",
					guid,
					"'"
				});
			}
			string result;
			if (DatabaseExcetue.ReturnDataTable(strSql).Rows.Count > 0)
			{
				result = DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Title"].ToString();
			}
			else
			{
				result = "-1";
			}
			return result;
		}
	}
}
