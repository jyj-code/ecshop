using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Region_Action : IShopNum1_Region_Action
	{
		[CompilerGenerated]
		private string string_0;
		public string TableName
		{
			get;
			set;
		}
		public DataTable SearchByCategoryLevel(string lever, string showcount)
		{
			string text = "SELECT ";
			if (!string.IsNullOrEmpty(showcount))
			{
				text = text + " TOP " + showcount;
			}
			text += " ID,NAME,CODE FROM ShopNum1_Region WHERE 1=1 AND IsDeleted=0  ";
			if (!string.IsNullOrEmpty(lever.Replace("'", "")))
			{
				text = text + " AND CategoryLevel=" + lever;
			}
			text += " ORDER BY OrderID ASC ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_Region shopNum1_Region)
		{
			string text = this.method_0(shopNum1_Region.CategoryLevel, shopNum1_Region.FatherID);
			string text2 = string.Empty;
			text2 = "INSERT INTO ShopNum1_Region(Name ,OrderID, CategoryLevel  , FatherID  , Family  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code  , IsDeleted   ) VALUES (  '" + Operator.FilterString(shopNum1_Region.Name) + "', ";
			text2 = string.Concat(new object[]
			{
				text2,
				" ",
				shopNum1_Region.OrderID,
				",  ",
				shopNum1_Region.CategoryLevel,
				",  ",
				shopNum1_Region.FatherID,
				",  '",
				shopNum1_Region.Family,
				"',  '",
				shopNum1_Region.CreateUser,
				"', '",
				shopNum1_Region.CreateTime,
				"',  '",
				shopNum1_Region.ModifyUser,
				"' , '",
				shopNum1_Region.ModifyTime,
				"',  '",
				text,
				"',  ",
				shopNum1_Region.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(text2);
		}
		public DataTable SearchtRegionCategory(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Name,OrderID,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,code from ShopNum1_Region where 1=1 ");
			if (fatherID != -1)
			{
				stringBuilder.Append("and FatherID=" + fatherID);
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				stringBuilder.Append(" and isDeleted=" + isDeleted);
			}
			stringBuilder.Append(" ORDER BY OrderID ASC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetRegionCategoryByID(string ID)
		{
			string strSql = string.Empty;
			strSql = "select ID,Name,OrderID,code,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_Region where ID=" + ID;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		private string method_0(int int_0, int int_1)
		{
			string string_ = "0";
			if (int_0 != 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("select ID,Name,code from ShopNum1_Region WHERE ID=" + int_1);
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Region) = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(Code) FROM ShopNum1_Region WHERE LEN(Code)=3 ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		private string method_2(string string_1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Region WHERE SUBSTRING(Code,1,3) = '" + string_1 + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ELSE ");
			stringBuilder.Append("BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM ShopNum1_Region WHERE SUBSTRING(Code,1,3) = '" + string_1 + "'  ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("IF(LEN(@code) <> 3) ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + string_1 + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		private string method_3(string string_1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Region WHERE substring(Code,1,6) = '" + string_1 + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM ShopNum1_Region WHERE SUBSTRING(Code,1,6) = '" + string_1 + "' ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + string_1 + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		private string method_4(string string_1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(12) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Region WHERE substring(Code,1,9) = '" + string_1 + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT @code = Max(SUBSTRING(Code,10,3)) FROM ShopNum1_Region WHERE SUBSTRING(Code,1,9) = '" + string_1 + "' ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + string_1 + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public int Update(string guid, ShopNum1_Region shopNum1_Region)
		{
			string text = string.Empty;
			text = "UPDATE  ShopNum1_Region SET  Name  ='" + Operator.FilterString(shopNum1_Region.Name) + "',";
			text = string.Concat(new object[]
			{
				text,
				" OrderID  =",
				shopNum1_Region.OrderID,
				", CategoryLevel  ='",
				shopNum1_Region.CategoryLevel,
				"', FatherID  ='",
				shopNum1_Region.FatherID,
				"', Family  ='",
				shopNum1_Region.Family,
				"', CreateUser  ='",
				shopNum1_Region.CreateUser,
				"', CreateTime  ='",
				shopNum1_Region.CreateTime,
				"', ModifyUser  ='",
				shopNum1_Region.ModifyUser,
				"', ModifyTime  ='",
				shopNum1_Region.ModifyTime,
				"', IsDeleted  ='",
				shopNum1_Region.IsDeleted,
				"'  WHERE id=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable GetRegionByCode(string Code)
		{
			string strSql = string.Empty;
			strSql = "select *  from ShopNum1_Region where Code='" + Code + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetAreaByRegionCode(string Code)
		{
			string strSql = string.Empty;
			strSql = "DECLARE @pri NVARCHAR(25)\r\n                       DECLARE @City NVARCHAR(25)\r\n                       DECLARE @area NVARCHAR(25)\r\n                       DECLARE @strsql VARCHAR(120)\r\n                       DECLARE @tempID int\r\n                       SELECT @area=Name,@tempID=FatherID FROM ShopNum1_Region WHERE code=@RegionCode \r\n                       SELECT @City=Name,@tempID=FatherID FROM ShopNum1_Region WHERE ID=@tempID\r\n                       SELECT @pri=Name FROM ShopNum1_Region WHERE ID=@tempID\r\n                       SELECT @pri+' '+@City+' '+@area";
			string[] paraName = new string[]
			{
				"@RegionCode"
			};
			string[] paraValue = new string[]
			{
				Code
			};
			return DatabaseExcetue.ReturnObject(strSql, paraName, paraValue).ToString();
		}
	}
}
