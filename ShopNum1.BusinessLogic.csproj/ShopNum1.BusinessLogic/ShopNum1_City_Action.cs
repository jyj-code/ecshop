using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_City_Action : IShopNum1_City_Action
	{
		public string TableName = "ShopNum1_City";
		public int GetMaxID()
		{
			return DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_City") + 1;
		}
		public DataTable Search(int isDeleted)
		{
			string strSql = string.Empty;
			strSql = "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City WHERE IsDeleted =" + isDeleted + " ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(int fatherID, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE  FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				" ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add(ShopNum1_City city)
		{
			string codeBylevel = this.GetCodeBylevel(Convert.ToInt32(city.CategoryLevel), city.FatherID);
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_City( \tCityName \t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  ) VALUES (  '",
				Operator.FilterString(city.CityName),
				"',  '",
				Operator.FilterString(city.ShortName),
				"',  ",
				city.CategoryLevel,
				",  ",
				city.FatherID,
				",  ",
				city.OrderID,
				",  '",
				Operator.FilterString(city.Letter),
				"',  ",
				city.IsHot,
				",  ",
				city.IsShow,
				",  '",
				codeBylevel,
				"',  '",
				city.CreateUser,
				"', '",
				city.CreateTime,
				"',  '",
				city.ModifyUser,
				"' , '",
				city.ModifyTime,
				"',  ",
				0,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string string_0)
		{
			string strSql = "Delete from ShopNum1_City where ID in (" + string_0 + ")";
			int result;
			try
			{
				DatabaseExcetue.RunNonQuery(strSql);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Update(ShopNum1_City city)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_City   SET    CityName\t='",
				Operator.FilterString(city.CityName),
				"',    ShortName\t='",
				Operator.FilterString(city.ShortName),
				"', \tCategoryLevel\t=",
				city.CategoryLevel,
				",\tFatherID\t=",
				city.FatherID,
				",\tOrderID\t=",
				city.OrderID,
				",\tLetter='",
				city.Letter,
				"' ,\tIsHot\t=",
				city.IsHot,
				",\tIsShow\t=",
				city.IsShow,
				",\tAddressCode='",
				city.AddressCode,
				"' ,\tModifyUser='",
				city.ModifyUser,
				"' ,\tModifyTime\t='",
				city.ModifyTime,
				"', \tIsDeleted =",
				city.IsDeleted,
				"   WHERE ID=",
				city.ID
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchInfoByID(string strID)
		{
			string text = string.Empty;
			text = "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 ";
			if (Operator.FormatToEmpty(strID) != string.Empty)
			{
				text = text + "And ID =" + Operator.FilterString(strID);
			}
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProductCategoryMeto(string strID)
		{
			string text = string.Empty;
			text = "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 and  IsShow=1  ";
			if (Operator.FormatToEmpty(strID) != string.Empty)
			{
				text = text + "And ID =" + Operator.FilterString(strID);
			}
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(int fatherID, int isDeleted, int count)
		{
			string strSql = string.Empty;
			if (count > 0)
			{
				strSql = "SELECT top " + count;
			}
			strSql = string.Concat(new object[]
			{
				"\t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE  IsShow=1 AND FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				" ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search2(int fatherID, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE  IsShow = 1 AND FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				"  ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search2(string showCount, int fatherID, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT  Top ",
				showCount,
				"\tID\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_City  WHERE  IsShow = 1 AND FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				"  ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetNameByID(int int_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 And ID =" + int_0;
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			string result;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				result = dataTable.Rows[0]["CityName"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
		public DataTable GetTableByID(int int_0)
		{
			string text = string.Empty;
			text = "SELECT \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 And ID =" + int_0;
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetCategoryByParam(string param)
		{
			string text = string.Empty;
			text = "select CityName, ID from ShopNum1_City,ShopNum1_Product where ShopNum1_City.IsShow = 1 and  fatherID in( select ID from ShopNum1_City where fatherID = 0) and " + param + "= 1 and ShopNum1_City.ID = ShopNum1_Product.ProductCategoryID Group by ShopNum1_City.CityName, ShopNum1_City.ID";
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable CheckIsChilds(string Field, string TableName, string ID)
		{
			string strSql = string.Concat(new string[]
			{
				" SELECT ",
				Field,
				" FROM ",
				TableName,
				"  WHERE fatherid='",
				ID,
				"' UNION all  SELECT  ",
				Field,
				" FROM  ",
				TableName,
				"  WHERE fatherid in (SELECT ID FROM ",
				TableName,
				"  WHERE fatherid='",
				ID,
				"')"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public string GetCodeBylevel(int level, int fatherID)
		{
			string addressCode = "0";
			if (level != 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(string.Concat(new object[]
				{
					"select ID,CityName,AddressCode from ",
					this.TableName,
					" WHERE ID=",
					fatherID
				}));
				addressCode = DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0]["AddressCode"].ToString();
			}
			string result;
			if (level == 1)
			{
				result = this.GetCfCode();
			}
			else if (level == 2)
			{
				result = this.GetCsCode(addressCode);
			}
			else if (level == 3)
			{
				result = this.GetCtCode(addressCode);
			}
			else
			{
				result = this.GetCmCode(addressCode);
			}
			return result;
		}
		public string GetCfCode()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @AddressCode varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM " + this.TableName + ") = 0) ");
			stringBuilder.Append("SET @AddressCode = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT TOP 1 @AddressCode = AddressCode FROM " + this.TableName + " WHERE LEN(AddressCode)=3 Order BY ID DESC ");
			stringBuilder.Append("SET @AddressCode = @AddressCode + 1 ");
			stringBuilder.Append("WHILE (LEN(@AddressCode) < 3) ");
			stringBuilder.Append("BEGIN SET @AddressCode = '0' + @AddressCode END END ");
			stringBuilder.Append("SELECT @AddressCode");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public string GetCsCode(string AddressCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @AddressCode varchar(10) ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"IF((SELECT COUNT(1) FROM ",
				this.TableName,
				" WHERE SUBSTRING(AddressCode,1,3) = '",
				AddressCode,
				"') = 0) "
			}));
			stringBuilder.Append("SET @AddressCode = '001' ELSE ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"BEGIN SELECT TOP 1 @AddressCode = SUBSTRING(AddressCode,4,3) FROM ",
				this.TableName,
				" WHERE SUBSTRING(AddressCode,1,3) = '",
				AddressCode,
				"' Order BY ID DESC "
			}));
			stringBuilder.Append("SET @AddressCode = @AddressCode + 1 ");
			stringBuilder.Append("IF(LEN(@AddressCode) <> 3) ");
			stringBuilder.Append("WHILE (LEN(@AddressCode) < 3) ");
			stringBuilder.Append("BEGIN SET @AddressCode = '0' + @AddressCode END END ");
			stringBuilder.Append("SELECT '" + AddressCode + "' + @AddressCode");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public string GetCtCode(string AddressCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @AddressCode varchar(10) ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"IF((SELECT COUNT(1) FROM ",
				this.TableName,
				" WHERE substring(AddressCode,1,6) = '",
				AddressCode,
				"') = 0) "
			}));
			stringBuilder.Append("SET @AddressCode = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"SELECT TOP 1 @AddressCode = SUBSTRING(AddressCode,7,3) FROM ",
				this.TableName,
				" WHERE SUBSTRING(AddressCode,1,6) = '",
				AddressCode,
				"' Order BY ID DESC "
			}));
			stringBuilder.Append("SET @AddressCode = @AddressCode + 1 ");
			stringBuilder.Append("WHILE (LEN(@AddressCode) < 3) ");
			stringBuilder.Append("BEGIN SET @AddressCode = '0' + @AddressCode END END ");
			stringBuilder.Append("SELECT '" + AddressCode + "' + @AddressCode");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public string GetCmCode(string AddressCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @AddressCode varchar(12) ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"IF((SELECT COUNT(1) FROM ",
				this.TableName,
				" WHERE substring(AddressCode,1,9) = '",
				AddressCode,
				"') = 0) "
			}));
			stringBuilder.Append("SET @AddressCode = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"SELECT TOP 1 @AddressCode = SUBSTRING(AddressCode,10,3) FROM ",
				this.TableName,
				" WHERE SUBSTRING(AddressCode,1,9) = '",
				AddressCode,
				"' Order BY ID DESC "
			}));
			stringBuilder.Append("SET @AddressCode = @AddressCode + 1 ");
			stringBuilder.Append("WHILE (LEN(@AddressCode) < 3) ");
			stringBuilder.Append("BEGIN SET @AddressCode = '0' + @AddressCode END END ");
			stringBuilder.Append("SELECT '" + AddressCode + "' + @AddressCode");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public DataTable SearchHotCity(string showCount)
		{
			string text = string.Empty;
			text = "SELECT top " + showCount + "\t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_City  WHERE 1=1 and  IsDeleted=0 and CategoryLevel=1 and IsShow=1 and IsHot=1";
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchCityLetter()
		{
			string text = string.Empty;
			text = "SELECT distinct   \tLetter\t  FROM ShopNum1_City  WHERE 1=1 and IsShow=1 and IsDeleted=0 and CategoryLevel=1 ";
			text += "  ORDER BY Letter ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchCityByLetter(string Letter)
		{
			string text = string.Empty;
			text = "SELECT distinct   \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_City   WHERE 1=1 and IsShow=1 and IsDeleted=0 and CategoryLevel=1 and Letter='" + Letter + "' ";
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable IsHost(string string_0)
		{
			string text = string.Empty;
			text = "SELECT ID,CityName FROM ShopNum1_City WHERE ID IN (SELECT ID FROM ShopNum1_City WHERE 1=1 and  IsDeleted=0 and CategoryLevel=1 and IsShow=1 and IsHot=1)";
			text = text + "  and id=" + string_0;
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDispatchRegionName(string AddressCode)
		{
			string text = string.Empty;
			text = "SELECT distinct   \t[ID]\t, \tCityName\t, \tShortName\t, \tCategoryLevel\t, \tFatherID\t, \tOrderID\t, \tLetter\t, \tIsHot\t, \tIsShow\t, \tAddressCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_City   WHERE 1=1 and IsShow=1 and IsDeleted=0  and AddressCode='" + AddressCode + "' ";
			text += "  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
