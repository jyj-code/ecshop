using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SupplyDemandCategory_Action : IShopNum1_SupplyDemandCategory_Action
	{
		public int Add(ShopNum1_SupplyDemandCategory shopNum1_SupplyDemandCategory)
		{
			string text = this.method_0(shopNum1_SupplyDemandCategory.CategoryLevel, shopNum1_SupplyDemandCategory.FatherID);
			string text2 = string.Empty;
			text2 = "INSERT INTO shopNum1_SupplyDemandCategory(Name ,OrderID, CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Keywords  , Description  , Code  , IsDeleted   ) VALUES (  '" + Operator.FilterString(shopNum1_SupplyDemandCategory.Name) + "', ";
			text2 = string.Concat(new object[]
			{
				text2,
				" ",
				shopNum1_SupplyDemandCategory.OrderID,
				",  ",
				shopNum1_SupplyDemandCategory.CategoryLevel,
				",  ",
				shopNum1_SupplyDemandCategory.FatherID,
				",  '",
				shopNum1_SupplyDemandCategory.Family,
				"',  '",
				shopNum1_SupplyDemandCategory.CreateUser,
				"', '",
				shopNum1_SupplyDemandCategory.CreateTime,
				"',  '",
				shopNum1_SupplyDemandCategory.ModifyUser,
				"' , '",
				shopNum1_SupplyDemandCategory.ModifyTime,
				"',  '",
				shopNum1_SupplyDemandCategory.Keywords,
				"',  '",
				shopNum1_SupplyDemandCategory.Description,
				"',  '",
				text,
				"',  ",
				shopNum1_SupplyDemandCategory.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(text2);
		}
		public DataTable SearchtSupplyDemandCategory(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Name,OrderID,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,code from shopNum1_SupplyDemandCategory where 1=1 ");
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
		public DataTable GetSupplyCategoryByID(string ID)
		{
			string strSql = string.Empty;
			strSql = "select ID,Name,OrderID,keywords,IsShow,description,code,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from shopNum1_SupplyDemandCategory where ID=" + ID;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		private string method_0(int int_0, int int_1)
		{
			string string_ = "0";
			if (int_0 != 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("select ID,Name,code from shopNum1_SupplyDemandCategory WHERE ID=" + int_1);
				string_ = DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0]["code"].ToString();
			}
			string result;
			if (int_0 == 1)
			{
				result = this.method_1();
			}
			else if (int_0 == 2)
			{
				result = this.method_2(string_);
			}
			else if (int_0 == 3)
			{
				result = this.method_3(string_);
			}
			else
			{
				result = this.method_4(string_);
			}
			return result;
		}
		private string method_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM shopNum1_SupplyDemandCategory) = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(Code) FROM shopNum1_SupplyDemandCategory WHERE LEN(Code)=3 ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		private string method_2(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM shopNum1_SupplyDemandCategory WHERE SUBSTRING(Code,1,3) = '" + string_0 + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ELSE ");
			stringBuilder.Append("BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM shopNum1_SupplyDemandCategory WHERE SUBSTRING(Code,1,3) = '" + string_0 + "'  ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("IF(LEN(@code) <> 3) ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + string_0 + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		private string method_3(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM shopNum1_SupplyDemandCategory WHERE substring(Code,1,6) = '" + string_0 + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM shopNum1_SupplyDemandCategory WHERE SUBSTRING(Code,1,6) = '" + string_0 + "' ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + string_0 + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		private string method_4(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(12) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM shopNum1_SupplyDemandCategory WHERE substring(Code,1,9) = '" + string_0 + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT @code = Max(SUBSTRING(Code,10,3)) FROM shopNum1_SupplyDemandCategory WHERE SUBSTRING(Code,1,9) = '" + string_0 + "' ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + string_0 + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public int Update(string guid, ShopNum1_SupplyDemandCategory shopNum1_SupplyDemandCategory)
		{
			string text = string.Empty;
			text = "UPDATE  shopNum1_SupplyDemandCategory SET  Name  ='" + Operator.FilterString(shopNum1_SupplyDemandCategory.Name) + "',";
			text = string.Concat(new object[]
			{
				text,
				" OrderID  =",
				shopNum1_SupplyDemandCategory.OrderID,
				", CategoryLevel  ='",
				shopNum1_SupplyDemandCategory.CategoryLevel,
				"', FatherID  ='",
				shopNum1_SupplyDemandCategory.FatherID,
				"', Family  ='",
				shopNum1_SupplyDemandCategory.Family,
				"', Keywords  ='",
				shopNum1_SupplyDemandCategory.Keywords,
				"', Description  ='",
				shopNum1_SupplyDemandCategory.Description,
				"', CreateUser  ='",
				shopNum1_SupplyDemandCategory.CreateUser,
				"', CreateTime  ='",
				shopNum1_SupplyDemandCategory.CreateTime,
				"', ModifyUser  ='",
				shopNum1_SupplyDemandCategory.ModifyUser,
				"', ModifyTime  ='",
				shopNum1_SupplyDemandCategory.ModifyTime,
				"', IsDeleted  ='",
				shopNum1_SupplyDemandCategory.IsDeleted,
				"'  WHERE id=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable GetDataByFatherID(string FatherID)
		{
			string text = string.Empty;
			text = text + "    SELECT * FROM  ShopNum1_SupplyDemandCategory  WHERE   FatherID =" + FatherID + "  AND  IsDeleted=0 AND  IsShow=1           ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDataByCode(string Code)
		{
			string text = string.Empty;
			text = text + "    SELECT * FROM  ShopNum1_SupplyDemandCategory  WHERE   Code ='" + Code + "'  AND  IsDeleted=0 AND  IsShow=1           ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "    DELETE  ShopNum1_SupplyDemandCategory  WHERE  ID IN  (" + guids + ")     ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
