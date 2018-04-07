using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ShopCategory_Action : IShopNum1_ShopCategory_Action
	{
		private static DataTable dataTable_0 = null;
		public static DataTable ShopCategoryTable
		{
			get
			{
				if (ShopNum1_ShopCategory_Action.dataTable_0 == null)
				{
					string strSql = "select ID,Name,Code,IsRecommend,OrderID,FatherID from ShopNum1_ShopCategory where IsDeleted=0 and IsShow=1 ORDER BY OrderID DESC";
					ShopNum1_ShopCategory_Action.dataTable_0 = DatabaseExcetue.ReturnDataTable(strSql);
				}
				return ShopNum1_ShopCategory_Action.dataTable_0;
			}
			set
			{
				ShopNum1_ShopCategory_Action.dataTable_0 = null;
			}
		}
		public int Add(ShopNum1_ShopCategory shopCategory)
		{
			ShopNum1_ShopCategory_Action.ShopCategoryTable = null;
			string text = this.method_0(shopCategory.CategoryLevel, shopCategory.FatherID);
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_ShopCategory(  Name  , Keywords  , Description  , OrderID  , IsShow  , CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code  , IsDeleted   ) VALUES (  '",
				Operator.FilterString(shopCategory.Name),
				"',  '",
				Operator.FilterString(shopCategory.Keywords),
				"',  '",
				Operator.FilterString(shopCategory.Description),
				"',  ",
				shopCategory.OrderID,
				",  ",
				shopCategory.IsShow,
				",  ",
				shopCategory.CategoryLevel,
				",  ",
				shopCategory.FatherID,
				",  '",
				shopCategory.Family,
				"',  '",
				shopCategory.CreateUser,
				"', '",
				shopCategory.CreateTime,
				"',  '",
				shopCategory.ModifyUser,
				"' , '",
				shopCategory.ModifyTime,
				"',  '",
				text,
				"',  ",
				shopCategory.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			ShopNum1_ShopCategory_Action.ShopCategoryTable = null;
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "delete from ShopNum1_ShopCategory  WHERE ID IN (" + guids + ") ";
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
		public int Update(string guid, ShopNum1_ShopCategory shopCategory)
		{
			ShopNum1_ShopCategory_Action.ShopCategoryTable = null;
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ShopCategory SET  Name  ='",
				Operator.FilterString(shopCategory.Name),
				"', Keywords  ='",
				Operator.FilterString(shopCategory.Keywords),
				"', Description  ='",
				Operator.FilterString(shopCategory.Description),
				"', OrderID  =",
				shopCategory.OrderID,
				", IsShow  ='",
				shopCategory.IsShow,
				"', CategoryLevel  ='",
				shopCategory.CategoryLevel,
				"', FatherID  ='",
				shopCategory.FatherID,
				"', Family  ='",
				shopCategory.Family,
				"', CreateUser  ='",
				shopCategory.CreateUser,
				"', CreateTime  ='",
				shopCategory.CreateTime,
				"', ModifyUser  ='",
				shopCategory.ModifyUser,
				"', ModifyTime  ='",
				shopCategory.ModifyTime,
				"', IsDeleted  ='",
				shopCategory.IsDeleted,
				"' WHERE id=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchShopCategory(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Name,Keywords,Description,OrderID,IsShow,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_ShopCategory where 1=1 and CategoryLevel<3 ");
			stringBuilder.Append("and FatherID=" + fatherID);
			if (isDeleted == 0 || isDeleted == 1)
			{
				stringBuilder.Append(" and isDeleted=" + isDeleted);
			}
			stringBuilder.Append(" ORDER BY OrderID DESC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetShopCategoryByID(string ID)
		{
			string strSql = string.Empty;
			strSql = "select ID,Name,Keywords,Description,OrderID,IsShow,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_ShopCategory where ID=" + ID;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetShopCategoryName()
		{
			string strSql = string.Empty;
			strSql = "select ID,Name,Code from ShopNum1_ShopCategory ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetList(string categoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("[ID],");
			stringBuilder.Append("[Name],");
			stringBuilder.Append("[Code]");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_ShopCategory");
			stringBuilder.Append(" WHERE FatherID=" + categoryID + "  AND  IsDeleted=0   ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetShopCategoryMeto(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopCategoryMeto", array, array2);
		}
		public DataTable GetShopCategoryCount(string showcount)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ShowCount";
			array2[0] = showcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CategoryCount", array, array2);
		}
		public DataTable GetShopCategoryCount(string showcount, string SubstationID)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@ShowCount";
			array2[0] = showcount;
			array[1] = "@SubstationID";
			array2[1] = SubstationID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CategoryCountNew", array, array2);
		}
		public DataTable Search(int fatherID, int isDeleted, string showCount)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT  TOP ",
				showCount,
				"\tID\t,  Name  , Code , Keywords  , Description  , OrderID  , IsShow  , CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , IsDeleted   FROM ShopNum1_ShopCategory  WHERE 1 =1   AND  IsDeleted =",
				isDeleted
			});
			if (!string.IsNullOrEmpty(fatherID.ToString()))
			{
				text = text + " AND FatherID =" + fatherID;
			}
			text += " ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchtProductCategory(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Name,OrderID,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,code,isshow,(select top 1 id from  ShopNum1_ShopCategory where fatherid=''+t.id+'' and isDeleted='0')v,(select TOP 1 id from ShopNum1_ShopInfo where shopcategoryid=''+t.id+'')m from ShopNum1_ShopCategory t where 1=1 ");
			if (fatherID != -1)
			{
				stringBuilder.Append("and FatherID=" + fatherID);
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				stringBuilder.Append(" and isDeleted=" + isDeleted);
			}
			stringBuilder.Append(" ORDER BY OrderID DESC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchShopIsCategoryID(int fatherID, int isDeleted, string showCount)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT  TOP ",
				showCount,
				"\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tCode\t, \tIsDeleted   FROM ShopNum1_ShopCategory  WHERE 1 =1   AND  IsDeleted =",
				isDeleted
			});
			if (!string.IsNullOrEmpty(fatherID.ToString()))
			{
				text = text + " AND FatherID =" + fatherID;
			}
			text += " ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetShopIsCategoryByCategoryID(string ShopCategoryID, string showcount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT TOP " + showcount);
			stringBuilder.Append(" [Guid],[Name],ShopName,ShopUrl,Banner,ShopID ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_ShopInfo");
			stringBuilder.Append(" WHERE 0=0");
			if (Operator.FormatToEmpty(ShopCategoryID) != string.Empty)
			{
				stringBuilder.Append(" AND ShopCategoryID  like  '" + ShopCategoryID + "%'");
			}
			stringBuilder.Append(" ORDER BY ShopID ASC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		private string method_0(int int_0, int int_1)
		{
			string code = "0";
			if (int_0 != 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("select ID,Name,code from ShopNum1_ShopCategory WHERE ID=" + int_1);
				code = DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0]["code"].ToString();
			}
			string result;
			if (int_0 == 1)
			{
				result = this.GetCfCode();
			}
			else if (int_0 == 2)
			{
				result = this.GetCsCode(code);
			}
			else if (int_0 == 3)
			{
				result = this.GetCtCode(code);
			}
			else
			{
				result = this.GetCmCode(code);
			}
			return result;
		}
		public string GetCfCode()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ShopCategory) = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(Code) FROM ShopNum1_ShopCategory WHERE LEN(Code)=3 ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public string GetCsCode(string code)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ShopCategory WHERE SUBSTRING(Code,1,3) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ELSE ");
			stringBuilder.Append("BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM ShopNum1_ShopCategory WHERE SUBSTRING(Code,1,3) = '" + code + "'  ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("IF(LEN(@code) <> 3) ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + code + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public string GetCtCode(string code)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ShopCategory WHERE substring(Code,1,6) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM ShopNum1_ShopCategory WHERE SUBSTRING(Code,1,6) = '" + code + "' ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + code + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public string GetCmCode(string code)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(12) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ShopCategory WHERE substring(Code,1,9) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT @code = Max(SUBSTRING(Code,10,3)) FROM ShopNum1_ShopCategory WHERE SUBSTRING(Code,1,9) = '" + code + "' ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + code + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public int UpdateIsshow(string strIsshow, string strId)
		{
			string strSql = string.Format("update ShopNum1_ShopCategory set isshow='{0}' where id='{1}'", strIsshow, strId);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateOrderName(string strID, string strName, string strOrderId)
		{
			string strSql = string.Format("update ShopNum1_ShopCategory set orderid='{0}',name='{1}' where id='{2}'", strOrderId, strName, strID);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteTypeC(string strID)
		{
			string strSql = string.Format("delete from ShopNum1_ShopCategory where id='{0}'", strID);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchtTypeId(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID from ShopNum1_ShopCategory t where 1=1 ");
			if (fatherID != -1)
			{
				stringBuilder.Append("and FatherID=" + fatherID);
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				stringBuilder.Append(" and isDeleted=" + isDeleted);
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int MaxOrderId()
		{
			return DatabaseExcetue.ReturnMaxID("orderid", "ShopNum1_ShopCategory");
		}
		public DataTable GetByCode(string Code)
		{
			string text = string.Empty;
			text += "  SELECT * FROM  ShopNum1_ShopCategory  ";
			text = text + "  WHERE    Code='" + Code + "'        ";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
	}
}
