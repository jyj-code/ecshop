using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_DispatchRegion_Action : IShopNum1_DispatchRegion_Action
	{
		[CompilerGenerated]
		private string string_0;
		public string TableName
		{
			get;
			set;
		}
		public DataTable Search(int IsDeleted)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, Name, OrderID,Memo,CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_DispatchRegion WHERE (IsDeleted = " + IsDeleted + ") Order By OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add(ShopNum1_DispatchRegion dispatchRegion)
		{
			string text = this.method_0(dispatchRegion.CategoryLevel.Value, dispatchRegion.FatherID.Value);
			string text2 = string.Empty;
			text2 = "INSERT INTO " + this.TableName + "(  Name  ,";
			text2 = text2 + " OrderID  , CategoryLevel  , FatherID  , Family  , Remark  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code   ) VALUES (  '" + Operator.FilterString(dispatchRegion.Name) + "', ";
			text2 = string.Concat(new object[]
			{
				text2,
				" ",
				dispatchRegion.OrderID,
				",  ",
				dispatchRegion.CategoryLevel,
				",  ",
				dispatchRegion.FatherID,
				",  '",
				dispatchRegion.Family,
				"',  '",
				dispatchRegion.Remark,
				"',  '",
				dispatchRegion.CreateUser,
				"', '",
				dispatchRegion.CreateTime,
				"',  '",
				dispatchRegion.ModifyUser,
				"' , '",
				dispatchRegion.ModifyTime,
				"',  '",
				text,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(text2);
		}
		public int Add(ShopNum1_DispatchRegion dispatchRegion, string shop)
		{
			string text = this.method_0(dispatchRegion.CategoryLevel.Value, dispatchRegion.FatherID.Value);
			string text2 = string.Empty;
			text2 = string.Concat(new string[]
			{
				"INSERT INTO ",
				this.TableName,
				"(  Name  , Keywords  , Description  , IsShow  , OrderID  , CategoryLevel  , FatherID  , Family  , Code  , MemLoginID   ) VALUES (  '",
				Operator.FilterString(dispatchRegion.Name),
				"', "
			});
			text2 = string.Concat(new object[]
			{
				text2,
				" ",
				dispatchRegion.OrderID,
				",  ",
				dispatchRegion.CategoryLevel,
				",  ",
				dispatchRegion.FatherID,
				",  '",
				dispatchRegion.Family,
				"',  '",
				text,
				"', )"
			});
			return DatabaseExcetue.RunNonQuery(text2);
		}
		private string method_0(int int_0, int int_1)
		{
			string code = "0";
			if (int_0 != 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(string.Concat(new object[]
				{
					"select ID,Name,code from ",
					this.TableName,
					" WHERE ID=",
					int_1
				}));
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
		public int Delete(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new string[]
			{
				"delete from ",
				this.TableName,
				"  WHERE ID IN (",
				guids,
				") "
			});
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
		public int Update(string guid, ShopNum1_DispatchRegion dispatchRegion)
		{
			string text = string.Empty;
			text = string.Concat(new string[]
			{
				"UPDATE  ",
				this.TableName,
				" SET  Name  ='",
				Operator.FilterString(dispatchRegion.Name),
				"',"
			});
			text = string.Concat(new object[]
			{
				text,
				" OrderID  =",
				dispatchRegion.OrderID,
				", CategoryLevel  ='",
				dispatchRegion.CategoryLevel,
				"', FatherID  ='",
				dispatchRegion.FatherID,
				"', Family  ='",
				dispatchRegion.Family,
				"', Remark  ='",
				Operator.FilterString(dispatchRegion.Remark),
				"', CreateUser  ='",
				dispatchRegion.CreateUser,
				"', CreateTime  ='",
				dispatchRegion.CreateTime,
				"', ModifyUser  ='",
				dispatchRegion.ModifyUser,
				"', ModifyTime  ='",
				dispatchRegion.ModifyTime,
				"'  WHERE id=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int Update(string guid, ShopNum1_DispatchRegion dispatchRegion, string shop)
		{
			string text = string.Empty;
			text = string.Concat(new string[]
			{
				"UPDATE  ",
				this.TableName,
				" SET  Name  ='",
				Operator.FilterString(dispatchRegion.Name),
				"',"
			});
			text = string.Concat(new object[]
			{
				text,
				" OrderID  =",
				dispatchRegion.OrderID,
				", CategoryLevel  ='",
				dispatchRegion.CategoryLevel,
				"', FatherID  ='",
				dispatchRegion.FatherID,
				"', Family  ='",
				dispatchRegion.Family,
				"'  WHERE id=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable SearchtDispatchRegion(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Name,OrderID,CategoryLevel,FatherID,Family,CreateUser,CreateTime,ModifyUser,ModifyTime,code from " + this.TableName + " where 1=1 ");
			stringBuilder.Append("and FatherID=" + fatherID);
			stringBuilder.Append(" ORDER BY OrderID ASC ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetDispatchRegionByID(string ID)
		{
			string text = string.Empty;
			text = "select ID,Name,";
			text = string.Concat(new string[]
			{
				text,
				"OrderID,CategoryLevel,FatherID,Family,Remark,CreateUser,CreateTime,ModifyUser,ModifyTime from ",
				this.TableName,
				" where ID=",
				ID
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDispatchRegionName()
		{
			string strSql = string.Empty;
			strSql = "select ID,Name,Code from " + this.TableName;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetDispatchRegionCode(string code)
		{
			string text = string.Empty;
			text = "select ID,Name,Code from " + this.TableName;
			text = text + " WHERE Code in (" + code + ")";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDispatchRegionName(string fatherID)
		{
			string text = string.Empty;
			text = "select ID,Name,Code,OrderID,CategoryLevel from " + this.TableName;
			text = text + " WHERE FatherID=" + fatherID;
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDispatchRegionName(string fatherID, string agentLoginID)
		{
			string text = string.Empty;
			text = "select ID,Name,Code from " + this.TableName;
			text = text + " WHERE FatherID=" + fatherID;
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDispatchRegionCode(string code, string agentLoginID)
		{
			string text = string.Empty;
			text = "select ID,Name,Code from " + this.TableName;
			text = text + " WHERE Code='" + code + "'";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetCfCode()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM " + this.TableName + ") = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT TOP 1 @code = Code FROM " + this.TableName + " WHERE LEN(Code)=3 Order BY ID DESC ");
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
			stringBuilder.Append(string.Concat(new string[]
			{
				"IF((SELECT COUNT(1) FROM ",
				this.TableName,
				" WHERE SUBSTRING(Code,1,3) = '",
				code,
				"') = 0) "
			}));
			stringBuilder.Append("SET @code = '001' ELSE ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"BEGIN SELECT TOP 1 @code = SUBSTRING(Code,4,3) FROM ",
				this.TableName,
				" WHERE SUBSTRING(Code,1,3) = '",
				code,
				"' Order BY ID DESC "
			}));
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
			stringBuilder.Append(string.Concat(new string[]
			{
				"IF((SELECT COUNT(1) FROM ",
				this.TableName,
				" WHERE substring(Code,1,6) = '",
				code,
				"') = 0) "
			}));
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"SELECT TOP 1 @code = SUBSTRING(Code,7,3) FROM ",
				this.TableName,
				" WHERE SUBSTRING(Code,1,6) = '",
				code,
				"' Order BY ID DESC "
			}));
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
			stringBuilder.Append(string.Concat(new string[]
			{
				"IF((SELECT COUNT(1) FROM ",
				this.TableName,
				" WHERE substring(Code,1,9) = '",
				code,
				"') = 0) "
			}));
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append(string.Concat(new string[]
			{
				"SELECT TOP 1 @code = SUBSTRING(Code,10,3) FROM ",
				this.TableName,
				" WHERE SUBSTRING(Code,1,9) = '",
				code,
				"' Order BY ID DESC "
			}));
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + code + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public int GetDispatchCount(int fatherID, int isDeleted)
		{
			string text = "select count(*) as TotalCount from {0} where 1=1 and FatherID={1}";
			text = string.Format(text, this.TableName, fatherID);
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(text);
			return Convert.ToInt32(dataTable.Rows[0]["TotalCount"]);
		}
	}
}
