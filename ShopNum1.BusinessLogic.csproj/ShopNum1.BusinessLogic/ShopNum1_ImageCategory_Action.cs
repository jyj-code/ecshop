using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ImageCategory_Action : IShopNum1_ImageCategory_Action
	{
		public int GetMaxID()
		{
			return DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_ImageCategory") + 1;
		}
		public DataTable Search(int fatherid)
		{
			string strSql = string.Empty;
			strSql = "SELECT ID,Name,CategoryLevel,FatherID,Family FROM ShopNum1_ImageCategory WHERE FatherID=" + fatherid + " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Delete(string string_0)
		{
			List<string> list = new List<string>();
			string strSql = string.Empty;
			strSql = "Select count(*) from ShopNum1_Image where ImageCategoryID=" + string_0;
			int result;
			if (DatabaseExcetue.CheckExists(strSql))
			{
				result = -1;
			}
			else
			{
				string item = "Delete from ShopNum1_ImageCategory where ID in(" + string_0 + ")";
				list.Add(item);
				try
				{
					DatabaseExcetue.RunTransactionSql(list);
					result = 1;
				}
				catch
				{
					result = 0;
				}
			}
			return result;
		}
		public int Insert(string name, string description, string categoryLevel, string fatherID, string family, string user)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_ImageCategory(");
			stringBuilder.Append("ID,");
			stringBuilder.Append("Name,");
			stringBuilder.Append("Description,");
			stringBuilder.Append("CategoryLevel,");
			stringBuilder.Append("FatherID,");
			stringBuilder.Append("Family,");
			stringBuilder.Append("CreateUser,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("ModifyUser,");
			stringBuilder.Append("ModifyTime)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + this.GetMaxID() + "',");
			stringBuilder.Append("'" + Operator.FilterString(name) + "',");
			stringBuilder.Append("'" + Operator.FilterString(description) + "',");
			stringBuilder.Append(categoryLevel + ",");
			stringBuilder.Append(fatherID + ",");
			stringBuilder.Append("'" + Operator.FilterString(family) + "',");
			stringBuilder.Append("'" + user + "',");
			stringBuilder.Append("getdate(),");
			stringBuilder.Append("'" + user + "',");
			stringBuilder.Append("getdate())");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Update(string strid, string name, string description, string categoryLevel, string fatherID, string family, string user)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_ImageCategory");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("Name = '" + Operator.FilterString(name) + "',");
			stringBuilder.Append("Description = '" + Operator.FilterString(description) + "',");
			stringBuilder.Append("CategoryLevel = " + categoryLevel + ",");
			stringBuilder.Append("FatherID = " + fatherID + ",");
			stringBuilder.Append("Family = '" + family + "',");
			stringBuilder.Append("ModifyUser = '" + user + "',");
			stringBuilder.Append("ModifyTime = getdate()");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ID = '" + strid + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable SearchInfoByID(string strID)
		{
			string text = string.Empty;
			text = "SELECT \tID\t, \tName\t, \tDescription\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t  FROM ShopNum1_ImageCategory  WHERE 1=1 ";
			if (Operator.FormatToEmpty(strID) != string.Empty)
			{
				text = text + "And ID =" + Operator.FilterString(strID);
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable ImageCategoryGetAllByFatherID(string fatherid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@fatherid";
			array2[0] = fatherid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ImageCategoryGetAllByFatherID", array, array2);
		}
		public DataTable GetIdByName(string name, string fatherID)
		{
			string text = string.Empty;
			text = "SELECT \tID\t, \tName FROM ShopNum1_ImageCategory  WHERE Name='{0}' AND FatherID={1} ";
			text = string.Format(text, name, fatherID);
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int DeleteType(string strId)
		{
			List<string> list = new List<string>();
			string item = "Delete from ShopNum1_ImageCategory where ID in(" + strId + ") and id!='1'";
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
	}
}
