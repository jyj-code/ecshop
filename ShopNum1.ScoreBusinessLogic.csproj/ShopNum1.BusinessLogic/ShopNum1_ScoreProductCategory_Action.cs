using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ScoreProductCategory_Action : IShopNum1_ScoreProductCategory_Action
	{
		public int Add(ShopNum1_ScoreProductCategory ScoreProductCategory)
		{
			int int_ = Convert.ToInt32(ScoreProductCategory.CategoryLevel);
			string text = this.method_0(int_, ScoreProductCategory.FatherID);
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO  ShopNum1_ScoreProductCategory  (  Name  , Keywords  , Description  , OrderID  , IsShow  , CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , IsDeleted  , Code   ) VALUES (  '",
				ScoreProductCategory.Name,
				"',  '",
				ScoreProductCategory.Keywords,
				"',  '",
				ScoreProductCategory.Description,
				"',  '",
				ScoreProductCategory.OrderID,
				"',  '",
				ScoreProductCategory.IsShow,
				"',  '",
				ScoreProductCategory.CategoryLevel,
				"',  '",
				ScoreProductCategory.FatherID,
				"',  '",
				ScoreProductCategory.Family,
				"',  '",
				ScoreProductCategory.CreateUser,
				"', '",
				ScoreProductCategory.CreateTime,
				"',  '",
				ScoreProductCategory.ModifyUser,
				"' , '",
				ScoreProductCategory.ModifyTime,
				"',  '",
				ScoreProductCategory.IsDeleted,
				"',  '",
				text,
				"'  )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		private string method_0(int int_0, int int_1)
		{
			string code = "0";
			if (int_0 != 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("select ID,Name,Code from  ShopNum1_ScoreProductCategory   WHERE ID=" + int_1);
				code = DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0]["Code"].ToString();
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ScoreProductCategory) = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(Code) FROM   ShopNum1_ScoreProductCategory   WHERE LEN(Code)=3 ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM    ShopNum1_ScoreProductCategory     WHERE SUBSTRING(Code,1,3) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ELSE ");
			stringBuilder.Append("BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM ShopNum1_ScoreProductCategory WHERE SUBSTRING(Code,1,3) = '" + code + "'  ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM  ShopNum1_ScoreProductCategory   WHERE substring(Code,1,6) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM ShopNum1_ScoreProductCategory WHERE SUBSTRING(Code,1,6) = '" + code + "' ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM  ShopNum1_ScoreProductCategory   WHERE substring(Code,1,9) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT @code = Max(SUBSTRING(Code,10,3)) FROM ShopNum1_ScoreProductCategory WHERE SUBSTRING(Code,1,9) = '" + code + "' ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + code + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "  delete ShopNum1_ScoreProductCategory  where ID='" + guids + "'  ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetDataInfo(int IsDeleted)
		{
			string strSql = string.Empty;
			strSql = "   select * from  ShopNum1_ScoreProductCategory  where  IsDeleted='" + IsDeleted + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(ShopNum1_ScoreProductCategory ScoreProductCategory)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ScoreProductCategory     SET      Name\t='",
				ScoreProductCategory.Name,
				"', \t    Keywords\t='",
				ScoreProductCategory.Keywords,
				"',     Description\t='",
				ScoreProductCategory.Description,
				"',\t    OrderID\t='",
				ScoreProductCategory.OrderID,
				"', \tIsShow\t=",
				ScoreProductCategory.IsShow,
				",\t    CategoryLevel\t=",
				ScoreProductCategory.CategoryLevel,
				",  \tFatherID\t=",
				ScoreProductCategory.FatherID,
				", \tFamily\t='",
				ScoreProductCategory.Family,
				"', \tModifyUser='",
				ScoreProductCategory.ModifyUser,
				"' , \tModifyTime\t='",
				ScoreProductCategory.ModifyTime,
				"', \t    IsDeleted =",
				ScoreProductCategory.IsDeleted,
				"      WHERE ID=",
				ScoreProductCategory.ID
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetCategory(string fatherID)
		{
			string text = string.Empty;
			text = "   SELECT  *   FROM    ShopNum1_ScoreProductCategory     WHERE  IsDeleted=0   ";
			if (!string.IsNullOrEmpty(fatherID))
			{
				text = text + "   AND  FatherID=" + fatherID + "  ";
			}
			text += "   ORDER BY  OrderID  ASC      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchtProductCategory(int FatherID, int IsDeleted)
		{
			string text = string.Empty;
			text = "   SELECT  *   FROM    ShopNum1_ScoreProductCategory     WHERE  IsDeleted=" + IsDeleted + "   ";
			if (FatherID != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   AND  FatherID=",
					FatherID,
					"  "
				});
			}
			text += "   ORDER BY  OrderID  ASC      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProductCategoryByID(string ID)
		{
			string strSql = string.Empty;
			strSql = "   SELECT  *   FROM    ShopNum1_ScoreProductCategory     WHERE  ID='" + ID + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetDataInfoByCode(string Code)
		{
			string strSql = string.Empty;
			strSql = "   SELECT  * FROM       ShopNum1_ScoreProductCategory        WHERE   Code='" + Code + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
