using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ArticleCategory_Action : IShopNum1_ArticleCategory_Action
	{
		private static DataTable dataTable_0 = null;
		public static DataTable ArticleCategoryTable
		{
			get
			{
				if (ShopNum1_ArticleCategory_Action.dataTable_0 == null)
				{
					string strSql = "SELECT ID,Name,OrderID,FatherID FROM ShopNum1_ArticleCategory where IsShow =1 and IsDeleted=0 ORDER BY OrderID DESC";
					ShopNum1_ArticleCategory_Action.dataTable_0 = DatabaseExcetue.ReturnDataTable(strSql);
				}
				return ShopNum1_ArticleCategory_Action.dataTable_0;
			}
			set
			{
				ShopNum1_ArticleCategory_Action.dataTable_0 = value;
			}
		}
		public int GetMaxID()
		{
			return DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_ArticleCategory") + 1;
		}
		public int Add(ShopNum1_ArticleCategory articleCategory)
		{
			ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_ArticleCategory( \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  ) VALUES (  '",
				Operator.FilterString(articleCategory.Name),
				"',  '",
				Operator.FilterString(articleCategory.Keywords),
				"',  '",
				Operator.FilterString(articleCategory.Description),
				"',  ",
				articleCategory.OrderID,
				",  ",
				articleCategory.IsShow,
				",  ",
				articleCategory.CategoryLevel,
				",  ",
				articleCategory.FatherID,
				",  '",
				articleCategory.Family,
				"',  '",
				articleCategory.CreateUser,
				"', '",
				articleCategory.CreateTime,
				"',  '",
				articleCategory.ModifyUser,
				"' , '",
				articleCategory.ModifyTime,
				"',  ",
				articleCategory.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string string_0)
		{
			ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
			string strSql = "Select Count(*) from ShopNum1_ArticleCategory where fatherid =" + string_0;
			int result;
			if (DatabaseExcetue.CheckExists(strSql))
			{
				result = 2;
			}
			else
			{
				string strSql2 = string.Empty;
				strSql2 = "Select  Count(*)  from ShopNum1_Article where ArticleCategoryID =" + string_0;
				if (DatabaseExcetue.CheckExists(strSql2))
				{
					result = -1;
				}
				else
				{
					string strSql3 = "Delete from ShopNum1_ArticleCategory where ID = " + string_0;
					try
					{
						DatabaseExcetue.RunNonQuery(strSql3);
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
		public DataTable Search(int fatherID, int isDeleted)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ArticleCategory  WHERE FatherID =",
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
			text = "SELECT \tID AS GUID, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ArticleCategory WHERE IsDeleted =" + isDeleted;
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(ShopNum1_ArticleCategory articleCategory)
		{
			ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ArticleCategory   SET    [Name]\t='",
				Operator.FilterString(articleCategory.Name),
				"', \tKeywords\t='",
				Operator.FilterString(articleCategory.Keywords),
				"',\tDescription\t='",
				Operator.FilterString(articleCategory.Description),
				"',\tOrderID\t='",
				articleCategory.OrderID,
				"',\tIsShow\t=",
				articleCategory.IsShow,
				",\tCategoryLevel\t=",
				articleCategory.CategoryLevel,
				",\tFatherID\t=",
				articleCategory.FatherID,
				",\tFamily\t='",
				articleCategory.Family,
				"',\tModifyUser='",
				articleCategory.ModifyUser,
				"' ,\tModifyTime\t='",
				articleCategory.ModifyTime,
				"', \tIsDeleted =",
				articleCategory.IsDeleted,
				"   WHERE ID=",
				articleCategory.ID
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string strID)
		{
			string text = "SELECT \t[Name]\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_ArticleCategory  Where 0=0";
			if (Operator.FormatToEmpty(strID) != string.Empty)
			{
				text = text + " AND  ID= " + strID + " ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetArticleCategoryMeto(string strID)
		{
			string strSql = string.Empty;
			strSql = "SELECT \tID, \tName\t, \tKeywords,\tDescription\t FROM ShopNum1_ArticleCategory WHERE ID ='" + strID + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetNameByID(int int_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT \tID\t, \tName\t  FROM ShopNum1_ArticleCategory  WHERE 1=1 And ID =" + int_0;
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Name"].ToString();
		}
		public DataTable SearchShow(int fatherID, int isDeleted)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ArticleCategory  WHERE IsShow=1 AND FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted
			});
			text += " ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetArticleCategory(string FatherId)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@FatherID";
			array2[0] = FatherId;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetArticleCategory", array, array2);
		}
		public DataTable SearchID(int int_0)
		{
			string strSql = string.Empty;
			strSql = "select [ID] from ShopNum1_ArticleCategory where FatherID=" + int_0;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetArticleInfoByID(string string_0)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@id";
			array2[0] = string_0;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetArticleInfoByID", array, array2);
		}
		public DataTable SearchByFatherID(string fatherID, string showcount, string isDeleted)
		{
			string text = string.Empty;
			text = "SELECT ";
			if (!string.IsNullOrEmpty(showcount))
			{
				text = text + " TOP   " + showcount;
			}
			text += "\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_ArticleCategory  WHERE 1=1 ";
			if (!string.IsNullOrEmpty(fatherID))
			{
				text = text + " AND FatherID =" + fatherID;
			}
			if (!string.IsNullOrEmpty(isDeleted))
			{
				text = text + " AND isDeleted =" + isDeleted;
			}
			text += " AND IsShow=1  ORDER BY OrderID DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
