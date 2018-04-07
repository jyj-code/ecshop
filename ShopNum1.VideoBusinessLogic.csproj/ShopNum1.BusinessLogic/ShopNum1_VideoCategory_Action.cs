using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_VideoCategory_Action : IShopNum1_VideoCategory_Action
	{
		public int GetMaxID()
		{
			return DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_VideoCategory") + 1;
		}
		public DataTable Search(int isDeleted)
		{
			string strSql = string.Empty;
			strSql = "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_VideoCategory WHERE IsDeleted =" + isDeleted + " ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(int fatherID, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_VideoCategory  WHERE FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				" ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add(ShopNum1_VideoCategory productCategory)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_VideoCategory( \t[ID]\t, \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted, \tBackgroundImage, \tIsDownload  ) VALUES (  ",
				productCategory.ID,
				",  '",
				Operator.FilterString(productCategory.Name),
				"',  '",
				Operator.FilterString(productCategory.Keywords),
				"',  '",
				Operator.FilterString(productCategory.Description),
				"',  ",
				productCategory.OrderID,
				",  ",
				productCategory.IsShow,
				",  ",
				productCategory.CategoryLevel,
				",  ",
				productCategory.FatherID,
				",  '",
				productCategory.Family,
				"',  '",
				productCategory.CreateUser,
				"', '",
				productCategory.CreateTime,
				"',  '",
				productCategory.ModifyUser,
				"' , '",
				productCategory.ModifyTime,
				"',  ",
				productCategory.IsDeleted,
				", '",
				productCategory.BackgroundImage,
				"',  ",
				0,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string string_0)
		{
			List<string> list = new List<string>();
			string text = string.Empty;
			text = "select count(guid)  from ShopNum1_Video where CategoryID in (" + string_0 + ")";
			int result;
			if (int.Parse(DatabaseExcetue.ReturnString(text)) > 0)
			{
				result = -1;
			}
			else
			{
				text = "select count(1) from ShopNum1_VideoCategory where FatherID in (" + string_0 + ")";
				if (int.Parse(DatabaseExcetue.ReturnString(text)) > 0)
				{
					result = -2;
				}
				else
				{
					text = "Delete from ShopNum1_VideoCategory where ID in (" + string_0 + ")";
					list.Add(text);
					text = "delete from  dbo.ShopNum1_Video where CategoryID in (" + string_0 + ")";
					list.Add(text);
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
			}
			return result;
		}
		public int Update(ShopNum1_VideoCategory productCategory)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_VideoCategory   SET    [Name]\t='",
				Operator.FilterString(productCategory.Name),
				"', \tKeywords\t='",
				Operator.FilterString(productCategory.Keywords),
				"',\tDescription\t='",
				Operator.FilterString(productCategory.Description),
				"',\tOrderID\t='",
				productCategory.OrderID,
				"',\tIsShow\t=",
				productCategory.IsShow,
				",\tCategoryLevel\t=",
				productCategory.CategoryLevel,
				",\tFatherID\t=",
				productCategory.FatherID,
				",\tFamily\t='",
				productCategory.Family,
				"',\tModifyUser='",
				productCategory.ModifyUser,
				"' ,\tModifyTime\t='",
				productCategory.ModifyTime,
				"', \tIsDeleted =",
				productCategory.IsDeleted,
				",\tBackgroundImage\t='",
				productCategory.BackgroundImage,
				"',  IsDownload=",
				0,
				"   WHERE ID=",
				productCategory.ID
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchInfoByID(string strID)
		{
			string text = string.Empty;
			text = "SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tBackgroundImage\t, \tIsDeleted   FROM ShopNum1_VideoCategory  WHERE 1=1 ";
			if (Operator.FormatToEmpty(strID) != string.Empty)
			{
				text = text + "And ID =" + Operator.FilterString(strID);
			}
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(int fatherID, int isDeleted, int count)
		{
			string text = string.Empty;
			if (count > 0)
			{
				text = "SELECT top " + count;
			}
			else
			{
				text = "SELECT ";
			}
			text = string.Concat(new object[]
			{
				text,
				"\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_VideoCategory  WHERE IsShow=1 AND FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				" ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search2(int fatherID, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_VideoCategory  WHERE  IsShow = 1 AND FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				"  ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
