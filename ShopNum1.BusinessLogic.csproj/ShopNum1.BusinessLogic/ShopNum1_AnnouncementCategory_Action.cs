using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_AnnouncementCategory_Action : IShopNum1_AnnouncementCategory_Action
	{
		public int GetMaxID()
		{
			return DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_AnnouncementCategory") + 1;
		}
		public int Add(ShopNum1_AnnouncementCategory AnnouncementCategory)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_AnnouncementCategory( \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  ) VALUES (  '",
				Operator.FilterString(AnnouncementCategory.Name),
				"',  '",
				Operator.FilterString(AnnouncementCategory.Keywords),
				"',  '",
				Operator.FilterString(AnnouncementCategory.Description),
				"',  ",
				AnnouncementCategory.OrderID,
				",  ",
				AnnouncementCategory.IsShow,
				",  ",
				AnnouncementCategory.CategoryLevel,
				",  ",
				AnnouncementCategory.FatherID,
				",  '",
				AnnouncementCategory.Family,
				"',  '",
				AnnouncementCategory.CreateUser,
				"', '",
				AnnouncementCategory.CreateTime,
				"',  '",
				AnnouncementCategory.ModifyUser,
				"' , '",
				AnnouncementCategory.ModifyTime,
				"',  ",
				AnnouncementCategory.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string string_0)
		{
			string strSql = string.Empty;
			strSql = "Select  Title, Guid  from ShopNum1_Announcement where AnnouncementCategoryID IN(" + string_0 + ")";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int result;
			if (dataTable.Rows.Count > 0)
			{
				result = -1;
			}
			else
			{
				string strSql2 = "Delete from ShopNum1_AnnouncementCategory where ID in (" + string_0 + ")";
				try
				{
					DatabaseExcetue.RunNonQuery(strSql2);
					result = 1;
				}
				catch
				{
					result = 0;
				}
			}
			return result;
		}
		public DataTable Search(int fatherID, int isDeleted)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_AnnouncementCategory  WHERE FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted
			});
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tID AS GUID, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_AnnouncementCategory WHERE IsDeleted =" + isDeleted;
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(ShopNum1_AnnouncementCategory AnnouncementCategory)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_AnnouncementCategory   SET    [Name]\t='",
				Operator.FilterString(AnnouncementCategory.Name),
				"', \tKeywords\t='",
				Operator.FilterString(AnnouncementCategory.Keywords),
				"',\tDescription\t='",
				Operator.FilterString(AnnouncementCategory.Description),
				"',\tOrderID\t='",
				AnnouncementCategory.OrderID,
				"',\tIsShow\t=",
				AnnouncementCategory.IsShow,
				",\tCategoryLevel\t=",
				AnnouncementCategory.CategoryLevel,
				",\tFatherID\t=",
				AnnouncementCategory.FatherID,
				",\tFamily\t='",
				AnnouncementCategory.Family,
				"',\tModifyUser='",
				AnnouncementCategory.ModifyUser,
				"' ,\tModifyTime\t='",
				AnnouncementCategory.ModifyTime,
				"', \tIsDeleted =",
				AnnouncementCategory.IsDeleted,
				"   WHERE ID=",
				AnnouncementCategory.ID
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string strID)
		{
			string text = "SELECT \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_AnnouncementCategory  Where 0=0";
			if (Operator.FormatToEmpty(strID) != string.Empty)
			{
				text = text + " AND  ID= " + strID + " ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetAnnouncementCategoryMeto(string strID)
		{
			string strSql = string.Empty;
			strSql = "SELECT \tID, \tName\t, \tKeywords,\tDescription\t FROM ShopNum1_AnnouncementCategory WHERE ID ='" + strID + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetNameByID(int int_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT \tID\t, \tName\t  FROM ShopNum1_AnnouncementCategory  WHERE 1=1 And ID =" + int_0;
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Name"].ToString();
		}
		public DataTable SearchShow(int fatherID, int isDeleted)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_AnnouncementCategory  WHERE IsShow=1 AND FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted
			});
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetAnnouncementCategory(string FatherId)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@FatherID";
			array2[0] = FatherId;
			return DatabaseExcetue.RunProcedureReturnDataTable("ShopNum1_AnnouncementCategory", array, array2);
		}
		public DataTable SearchID(int int_0)
		{
			string strSql = string.Empty;
			strSql = "select [ID] from ShopNum1_AnnouncementCategory where FatherID=" + int_0;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
