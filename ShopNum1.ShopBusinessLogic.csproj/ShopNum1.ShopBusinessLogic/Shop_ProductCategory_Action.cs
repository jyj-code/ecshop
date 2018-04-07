using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_ProductCategory_Action : IShop_ProductCategory_Action
	{
		[CompilerGenerated]
		private string string_0;
		public string TableName
		{
			get;
			set;
		}
		public DataTable GetShopAgentID(string memberLoginID)
		{
			return null;
		}
		public int Add(ShopNum1_Shop_ProductCategory shop_ProductCategory)
		{
			string text = this.method_0(shop_ProductCategory.CategoryLevel, shop_ProductCategory.FatherID);
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Shop_ProductCategory(Name,Keywords,Description,IsShow,OrderID,CategoryLevel,FatherID,Code,MemLoginID) VALUES (  '",
				shop_ProductCategory.Name,
				"',  '",
				shop_ProductCategory.Keywords,
				"',  '",
				shop_ProductCategory.Description,
				"',  '",
				shop_ProductCategory.IsShow,
				"', '",
				shop_ProductCategory.OrderID,
				"', ",
				shop_ProductCategory.CategoryLevel,
				",  ",
				shop_ProductCategory.FatherID,
				",  '",
				text,
				"',  '",
				shop_ProductCategory.MemLoginID,
				" ')"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(ShopNum1_Shop_ProductCategory shop_ProductCateGory)
		{
			string text = string.Empty;
			text = "UPDATE  ShopNum1_Shop_ProductCategory SET ";
			text = text + " Name  ='" + shop_ProductCateGory.Name + "',";
			text = text + " Keywords  ='" + shop_ProductCateGory.Keywords + "',";
			text = text + " Description  ='" + shop_ProductCateGory.Description + "',";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" isshow  ='",
				shop_ProductCateGory.IsShow,
				"',"
			});
			if (shop_ProductCateGory.FatherID.ToString() != "0")
			{
				object obj2 = text;
				text = string.Concat(new object[]
				{
					obj2,
					" FatherID  ='",
					shop_ProductCateGory.FatherID,
					"',"
				});
			}
			text = text + " OrderID  =" + shop_ProductCateGory.OrderID;
			text = text + " WHERE id=" + shop_ProductCateGory.ID;
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int DeleteType(string strId)
		{
			string strSql = string.Concat(new string[]
			{
				"DELETE FROM ShopNum1_Shop_ProductCategory WHERE Id='",
				strId,
				"';DELETE FROM ShopNum1_Shop_ProductCategory where fatherid='",
				strId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateOrderName(string strID, string strName, string strOrderId)
		{
			string strSql = string.Format("update ShopNum1_Shop_ProductCategory set orderid='{0}',name='{1}' where id='{2}'", strOrderId, strName, strID);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateIsshow(string strIsshow, string strId)
		{
			string strSql = string.Format("update ShopNum1_Shop_ProductCategory set isshow='{0}' where id='{1}'", strIsshow, strId);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteRecId(string strID)
		{
			string strSql = "DELETE FROM ShopNum1_Shop_ProductCategory WHERE ID IN (" + strID + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(int fatherID, string memLoginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"select id,name,keywords,description,orderid,isshow,categorylevel,code,(select top 1 id from  ShopNum1_Shop_ProductCategory where fatherid=''+t.id+'')v,(select top 1 id from ShopNum1_Shop_ProductCategory where code like ''+t.code+'%')m  from ShopNum1_Shop_ProductCategory as t where fatherid='",
				fatherID,
				"' and memloginid='",
				memLoginID,
				"' ORDER BY OrderID desc"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchShopType(int fatherID, string memLoginID)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"select id,name,code from ShopNum1_Shop_ProductCategory as t where fatherid='",
				fatherID,
				"' and memloginid='",
				memLoginID,
				"' ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		private string method_0(int int_0, int int_1)
		{
			string code = "0";
			if (int_0 != 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("select code from ShopNum1_Shop_ProductCategory WHERE ID=" + int_1);
				code = DatabaseExcetue.ReturnString(stringBuilder.ToString());
			}
			if (int_0 == 1)
			{
				return this.GetCfCode();
			}
			if (int_0 == 2)
			{
				return this.GetCsCode(code);
			}
			if (int_0 == 3)
			{
				return this.GetCtCode(code);
			}
			return this.GetCmCode(code);
		}
		public int Update1(string guid, ShopNum1_Shop_ProductCategory agent_ProductCateGory)
		{
			return 0;
		}
		public string GetCfCode()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Shop_ProductCategory ) = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = max(Code) FROM ShopNum1_Shop_ProductCategory WHERE LEN(Code)=3 ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Shop_ProductCategory  WHERE SUBSTRING(Code,1,3) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ELSE ");
			stringBuilder.Append("BEGIN SELECT  @code =max(SUBSTRING(Code,4,3)) FROM ShopNum1_Shop_ProductCategory WHERE SUBSTRING(Code,1,3) = '" + code + "'  ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Shop_ProductCategory WHERE substring(Code,1,6) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = max(SUBSTRING(Code,7,3)) FROM ShopNum1_Shop_ProductCategory WHERE SUBSTRING(Code,1,6) = '" + code + "'  ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_Shop_ProductCategory WHERE substring(Code,1,9) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code =max(SUBSTRING(Code,10,3)) FROM ShopNum1_Shop_ProductCategory WHERE SUBSTRING(Code,1,9) = '" + code + "'   ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + code + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public DataTable Search_Import(string FatherID, string MemloginId)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"select id,name,code from ShopNum1_Shop_ProductCategory as t where fatherid='",
				FatherID,
				"' and memloginid='",
				MemloginId,
				"' ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetCategoryProc(string fatherID, string idname, string idvalue)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@fatherid";
			array2[0] = fatherID;
			array[1] = "@tablename";
			array2[1] = this.TableName;
			array[2] = "@idname";
			array2[2] = idname;
			array[3] = "@idvalue";
			array2[3] = idvalue;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCategory", array, array2);
		}
		public int DeleteProductCategoryCode(string string_1, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@id";
			array2[0] = string_1;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteProductCategoryCode", array, array2);
		}
		public DataTable GetProductCategoryCodeProc(string code, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@code";
			array2[0] = code;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductCategoryCode", array, array2);
		}
		public DataTable GetProductCategoryInfoByCode(string string_1, string memberid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@id";
			array2[0] = string_1;
			array[1] = "@memberid";
			array2[1] = memberid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductCategoryInfoByCode", array, array2);
		}
		public DataTable GetCategory(string code, string codelen, string agentloginid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@code";
			array2[0] = code;
			array[1] = "@codelen";
			array2[1] = codelen;
			array[2] = "@agentloginid";
			array2[2] = agentloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCategory", array, array2);
		}
		public DataTable GetProductCategoryCode(string fatherID)
		{
			string text = string.Empty;
			text = "select ID,Name,Code from ShopNum1_Shop_ProductCategory ";
			text = text + " WHERE FatherID=" + fatherID;
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetShopProductCategoryCode(string fatherID, string memLoginID)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@fatherid";
			array2[0] = fatherID;
			array[1] = "@tablename";
			array2[1] = "ShopNum1_Shop_ProductCategory";
			array[2] = "@memloginid";
			array2[2] = memLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopProductCategoryCode", array, array2);
		}
		public DataTable GetShopMetaBycategory(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopMetaBycategory", array, array2);
		}
		public int GetMaxID(string MemloginId)
		{
			int result;
			try
			{
				string strSql = "select max(orderid)+1 from ShopNum1_Shop_ProductCategory where memloginid='" + MemloginId + "'";
				result = Convert.ToInt32(DatabaseExcetue.ReturnString(strSql));
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable SetCategoryCode(string code, string strMemloginId)
		{
			string text = "select name,code from ShopNum1_Shop_ProductCategory where 1=1 ";
			if (code == "0")
			{
				text += " and fatherId=0 ";
			}
			else
			{
				text = text + " and Code like '" + code + "%'";
			}
			text = text + " and MemloginId='" + strMemloginId + "'";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetShopCate(string strMemloginId)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = strMemloginId;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_F_ShopProductCategory", array, array2);
		}
	}
}
