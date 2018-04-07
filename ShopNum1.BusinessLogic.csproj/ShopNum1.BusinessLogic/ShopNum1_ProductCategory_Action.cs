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
	public class ShopNum1_ProductCategory_Action : IShopNum1_ProductCategory_Action
	{
		private static DataTable dataTable_0 = null;
		[CompilerGenerated]
		private string string_0;
		public static DataTable ProductCategoryTable
		{
			get
			{
				if (ShopNum1_ProductCategory_Action.dataTable_0 == null)
				{
					string strSql = "SELECT ID,Name,Code,FatherID,OrderID FROM ShopNum1_ProductCategory WHERE IsShow = 1 AND IsDeleted = 0 ORDER BY OrderID DESC";
					ShopNum1_ProductCategory_Action.dataTable_0 = DatabaseExcetue.ReturnDataTable(strSql);
				}
				return ShopNum1_ProductCategory_Action.dataTable_0;
			}
			set
			{
				ShopNum1_ProductCategory_Action.dataTable_0 = value;
			}
		}
		public string TableName
		{
			get;
			set;
		}
		public int Add(ShopNum1_ProductCategory shopNum1_ProductCategory)
		{
			string text = this.method_0(shopNum1_ProductCategory.CategoryLevel, shopNum1_ProductCategory.FatherID);
			string strSql = string.Format("INSERT INTO ShopNum1_ProductCategory(Name,OrderID,CategoryLevel,FatherID,CreateUser,CreateTime,\r\n            ModifyUser,ModifyTime,Code,IsDeleted,CategoryTypeName,CategoryType)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',\r\n            '{11}')", new object[]
			{
				shopNum1_ProductCategory.Name,
				shopNum1_ProductCategory.OrderID,
				shopNum1_ProductCategory.CreateUser,
				shopNum1_ProductCategory.CreateTime,
				shopNum1_ProductCategory.ModifyUser,
				shopNum1_ProductCategory.ModifyTime,
				text,
				shopNum1_ProductCategory.IsDeleted,
				shopNum1_ProductCategory.CategoryTypeName,
				shopNum1_ProductCategory.CategoryType
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public object Add1(ShopNum1_ProductCategory shopNum1_ProductCategory)
		{
			string text = this.method_0(shopNum1_ProductCategory.CategoryLevel, shopNum1_ProductCategory.FatherID);
			string text2 = string.Empty;
			text2 = "INSERT INTO ShopNum1_ProductCategory(  Name  ,";
			text2 = text2 + " OrderID  , Keywords  , Description  , CategoryLevel  , FatherID  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code  , IsDeleted , logoimg,   CategoryType ,  IsShow ,  CategoryTypeName    ) VALUES (  '" + Operator.FilterString(shopNum1_ProductCategory.Name) + "', ";
			text2 = string.Concat(new object[]
			{
				text2,
				" ",
				shopNum1_ProductCategory.OrderID,
				",  '",
				shopNum1_ProductCategory.Keywords,
				"',  '",
				shopNum1_ProductCategory.Description,
				"',  ",
				shopNum1_ProductCategory.CategoryLevel,
				",  ",
				shopNum1_ProductCategory.FatherID,
				",  '",
				shopNum1_ProductCategory.CreateUser,
				"', '",
				shopNum1_ProductCategory.CreateTime,
				"',  '",
				shopNum1_ProductCategory.ModifyUser,
				"' , '",
				shopNum1_ProductCategory.ModifyTime,
				"',  '",
				text,
				"',  ",
				shopNum1_ProductCategory.IsDeleted,
				",  '",
				shopNum1_ProductCategory.logoimg,
				" ', '",
				shopNum1_ProductCategory.CategoryType,
				" ', '",
				shopNum1_ProductCategory.IsShow,
				" ', '",
				shopNum1_ProductCategory.CategoryTypeName,
				" ')"
			});
			text2 += "  SELECT  @@IDENTITY AS 'Identity'";
			return DatabaseExcetue.ReturnObject(text2);
		}
		public int Delete(string guids)
		{
			List<string> list = new List<string>();
			string text = string.Empty;
			text = "select id from ShopNum1_ProductCategory WHERE FATHERID IN(" + guids + ") ";
			int result;
			if (DatabaseExcetue.CheckExists(text))
			{
				result = 2;
			}
			else
			{
				text = "select count(*) from ShopNum1_Shop_Product where ProductCategoryCode in(select code from ShopNum1_ProductCategory where id in(" + guids + "))";
				string a = DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
				if (a != "0")
				{
					result = 3;
				}
				else
				{
					text = "delete from ShopNum1_ProductCategory  WHERE ID IN (" + guids + ") ";
					list.Add(text);
					DatabaseExcetue.RunTransactionSql(list);
					result = 1;
				}
			}
			return result;
		}
		public int Update(string guid, ShopNum1_ProductCategory shopNum1_ProductCategory)
		{
			string text = string.Empty;
			text = "UPDATE  ShopNum1_ProductCategory SET  Name  ='" + Operator.FilterString(shopNum1_ProductCategory.Name) + "',";
			text = string.Concat(new object[]
			{
				text,
				" OrderID  =",
				shopNum1_ProductCategory.OrderID,
				", CategoryTypeName  ='",
				shopNum1_ProductCategory.CategoryTypeName,
				"', CategoryType  ='",
				shopNum1_ProductCategory.CategoryType,
				"', CategoryLevel  ='",
				shopNum1_ProductCategory.CategoryLevel,
				"', Description  ='",
				shopNum1_ProductCategory.Description,
				"', Keywords  ='",
				shopNum1_ProductCategory.Keywords,
				"', CreateUser  ='",
				shopNum1_ProductCategory.CreateUser,
				"', CreateTime  ='",
				shopNum1_ProductCategory.CreateTime,
				"', IsShow  ='",
				shopNum1_ProductCategory.IsShow,
				"', ModifyUser  ='",
				shopNum1_ProductCategory.ModifyUser,
				"', ModifyTime  ='",
				shopNum1_ProductCategory.ModifyTime,
				"', IsDeleted  ='",
				shopNum1_ProductCategory.IsDeleted,
				"',  logoimg  ='",
				shopNum1_ProductCategory.logoimg,
				"'  WHERE id=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int UpdateCatrgoryInfoCategory(ShopNum1_Category shopNum1_Category)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Category SET  Name  ='",
				Operator.FilterString(shopNum1_Category.Name),
				"', Keywords  ='",
				Operator.FilterString(shopNum1_Category.Keywords),
				"', Description  ='",
				Operator.FilterString(shopNum1_Category.Description),
				"', ModifyUser  ='",
				Operator.FilterString(shopNum1_Category.ModifyUser),
				"', ModifyTime  ='",
				Operator.FilterString(shopNum1_Category.ModifyTime),
				"', IsShow =",
				shopNum1_Category.IsShow,
				", OrderID=",
				shopNum1_Category.OrderID,
				"where ID=",
				shopNum1_Category.ID
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchtProductCategory(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Name,OrderID,CategoryLevel,CategoryTypeName,CategoryType,FatherID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,code,isshow,(select top 1 id from  ShopNum1_ProductCategory where fatherid=''+t.id+'' and isDeleted='0')v,(select top 1 id from shopnum1_shop_product where productcategorycode like ''+t.code+'%' and isdeleted='0')m  from ShopNum1_ProductCategory as t where 1=1 ");
			if (fatherID != -1)
			{
				stringBuilder.Append("and FatherID=" + fatherID);
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				stringBuilder.Append(" and isDeleted=" + isDeleted);
			}
			stringBuilder.Append(" ORDER BY OrderID asc ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		private string method_0(int int_0, int int_1)
		{
			string code = "0";
			if (int_0 != 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("select ID,Name,code from ShopNum1_ProductCategory WHERE ID=" + int_1);
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
		public DataTable GetProductCategoryByID(string ID)
		{
			string text = string.Empty;
			text = "select ID,Name,";
			text = text + "OrderID,CategoryTypeName,CategoryType,code,CategoryLevel,FatherID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,Keywords,Description,IsShow,logoimg from ShopNum1_ProductCategory where IsDeleted=0 AND  ID=" + ID + " order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProductCategoryName()
		{
			string strSql = string.Empty;
			strSql = "select ID,Name,Code from ShopNum1_ProductCategory order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetProductCategoryName(string fatherID)
		{
			string text = string.Empty;
			text = "select ID,Name,Code from ShopNum1_ProductCategory";
			text = text + " WHERE FatherID=" + fatherID;
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetCfCode()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @code varchar(10) ");
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ProductCategory) = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(Code) FROM ShopNum1_ProductCategory WHERE LEN(Code)=3 ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE SUBSTRING(Code,1,3) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ELSE ");
			stringBuilder.Append("BEGIN SELECT  @code = Max(SUBSTRING(Code,4,3)) FROM ShopNum1_ProductCategory WHERE SUBSTRING(Code,1,3) = '" + code + "'  ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE substring(Code,1,6) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT  @code = Max(SUBSTRING(Code,7,3)) FROM ShopNum1_ProductCategory WHERE SUBSTRING(Code,1,6) = '" + code + "' ");
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
			stringBuilder.Append("IF((SELECT COUNT(1) FROM ShopNum1_ProductCategory WHERE substring(Code,1,9) = '" + code + "') = 0) ");
			stringBuilder.Append("SET @code = '001' ");
			stringBuilder.Append("ELSE BEGIN ");
			stringBuilder.Append("SELECT @code = Max(SUBSTRING(Code,10,3)) FROM ShopNum1_ProductCategory WHERE SUBSTRING(Code,1,9) = '" + code + "' ");
			stringBuilder.Append("SET @code = @code + 1 ");
			stringBuilder.Append("WHILE (LEN(@code) < 3) ");
			stringBuilder.Append("BEGIN SET @code = '0' + @code END END ");
			stringBuilder.Append("SELECT '" + code + "' + @code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public DataTable GetCategory(string FatherID)
		{
			string text = "SELECT ID,Name,Code,categoryType FROM ShopNum1_ProductCategory where 1=1 ";
			if (FatherID != "0")
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" and Code like '",
					FatherID,
					"%' and Code!='",
					FatherID,
					"' and len(code)=",
					FatherID.Length + 3
				});
			}
			else if (FatherID == "0")
			{
				text += " and fatherid=0 ";
			}
			text += " and IsShow = 1  and isdeleted=0 ORDER BY OrderID asc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetCategoryBycount(string FatherID, string ShowCountOne)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT Top  ",
				ShowCountOne,
				"  ID,Name,Code FROM ShopNum1_ProductCategory WHERE FatherID = ",
				FatherID,
				" AND IsShow = 1 ORDER BY OrderID DESC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetProductCategory(string fatherid, string showcount)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@fatherid";
			array2[0] = fatherid;
			array[1] = "@showcount";
			array2[1] = showcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductCategory", array, array2);
		}
		public DataTable GetProductCategoryCode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductCategoryCode", array, array2);
		}
		public DataTable GetProductCategoryCodeByName(string name)
		{
			string strSql = string.Empty;
			strSql = "SELECT Code From ShopNum1_ProductCategory WHERE Name= '" + name + "'  ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(int fatherID, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT top 30 \tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tCategoryType\t, \tCategoryTypeName\t, \tFatherID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tCode\t, \tIsDeleted   FROM ShopNum1_ProductCategory  WHERE FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				" and IsShow=1 ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string Code, int isDeleted)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT \tCategoryLevel\t FROM ShopNum1_ProductCategory  WHERE  IsDeleted =",
				isDeleted,
				" AND Code='",
				Code,
				"' and isshow=1  ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetCategoryTypeByCategoryID(string categoryid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@categoryid";
			array2[0] = categoryid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCategoryTypeByCategoryID", array, array2);
		}
		public DataTable GetProductCategoryMeto(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductCategoryMeto", array, array2);
		}
		public int GetMaxID()
		{
			return DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_ProductCategory") + 1;
		}
		public int Update(ShopNum1_ProductCategory productCategory)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ProductCategory   SET    [Name]\t='",
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
				",\tModifyUser='",
				productCategory.ModifyUser,
				"' ,\tModifyTime\t='",
				productCategory.ModifyTime,
				"', \tCategoryTypeName\t='",
				productCategory.CategoryTypeName,
				"', \tCategoryType\t='",
				productCategory.CategoryType,
				"', \tIsDeleted =",
				productCategory.IsDeleted,
				"   WHERE ID=",
				productCategory.ID
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(int fatherID, int isDeleted, string showCount)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT  TOP ",
				showCount,
				"\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tCategoryType\t, \tCategoryTypeName\t, \tCode\t, \tIsDeleted,logoimg   FROM ShopNum1_ProductCategory  WHERE 1 =1 And IsShow=1  AND  IsDeleted =",
				isDeleted
			});
			if (!string.IsNullOrEmpty(fatherID.ToString()))
			{
				text = text + " AND FatherID =" + fatherID;
			}
			text += " ORDER BY OrderID ASC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchShopIsCategoryID(int fatherID, int isDeleted, string showCount)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT  TOP ",
				showCount,
				"\tID\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tCategoryType\t, \tCategoryTypeName\t, \tCode\t, \tIsDeleted   FROM ShopNum1_ShopCategory  WHERE 1 =1   AND  IsDeleted =",
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
		public int UpdateIsshow(string strIsshow, string strId)
		{
			string strSql = string.Format("update ShopNum1_ProductCategory set isshow='{0}' where id='{1}'", strIsshow, strId);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateOrderName(string strID, string strName, string strOrderId)
		{
			string strSql = string.Format("update ShopNum1_ProductCategory set orderid='{0}',name='{1}' where id='{2}'", strOrderId, strName.Replace("%2f", ""), strID);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchtTypeId(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID from ShopNum1_ProductCategory t where 1=1 ");
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
			return DatabaseExcetue.ReturnMaxID("orderid", "ShopNum1_ProductCategory");
		}
		public DataTable Select_ProductCategory()
		{
			string strSql = "select id,name,code,IsOpen,categorytype from ShopNum1_productcategory where  fatherid=0 and isdeleted=0 order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetThreeType(string strKeyword, string strId)
		{
			string text = "select * from (select name,id,code,categoryType,categorylevel,name typename,orderid from \r\nShopNum1_productcategory as t where categorylevel=1  and id not in(select fatherid from ShopNum1_productcategory)\r\nunion all\r\nselect name,id,code,categoryType,categorylevel,dbo.fun_GetCategoryTypeV8_1(t.id,2)typename,orderid from \r\nShopNum1_productcategory as t where categorylevel=2  and id not in(select fatherid from ShopNum1_productcategory)\r\nunion all\r\nselect name,id,code,categoryType,categorylevel,(dbo.fun_GetCategoryTypeV8_1(t.fatherid,3)+' > '+name)typename,orderid from \r\nShopNum1_productcategory as t where categorylevel=3 ) as tab where 1=1";
			if (!string.IsNullOrEmpty(Operator.FilterString(strKeyword)))
			{
				text = text + " and typename like '%" + strKeyword + "%'";
			}
			if (!string.IsNullOrEmpty(strId))
			{
				text = text + " and id='" + strId + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetThreeType(string strId)
		{
			string strSql = "select ([dbo].[fun_GetCategoryType](t.fatherid)+' > '+name)typename from ShopNum1_productcategory t where categorylevel=3  and isdeleted=0 and code='" + strId + "'";
			string text = DatabaseExcetue.ReturnString(strSql);
			string result;
			if (text == "")
			{
				strSql = "select ([dbo].[fun_GetCategoryType](t.id))typename from ShopNum1_productcategory t where isdeleted=0 and code='" + strId + "'";
				string text2 = DatabaseExcetue.ReturnString(strSql);
				if (text2 == "")
				{
					result = DatabaseExcetue.ReturnString("select name from ShopNum1_productcategory t where isdeleted=0 and code='" + strId + "'");
				}
				else
				{
					result = text2;
				}
			}
			else
			{
				result = text;
			}
			return result;
		}
		public int DeleteTypeC(string strID)
		{
			string strSql = string.Format("delete from  ShopNum1_ProductCategory where id in({0})", strID);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable dt_GetScale(string strCode)
		{
			string strSql = "select id,Scale,IsOpen from ShopNum1_productcategory where code='" + strCode + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update_Scale(string strCode, string strScale, string strIsOpen)
		{
			string strSql = string.Concat(new string[]
			{
				"update ShopNum1_productcategory set Scale='",
				strScale,
				"',IsOpen='",
				strIsOpen,
				"' from ShopNum1_productcategory where code='",
				strCode,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public string strVScale(string strProductGuId)
		{
			string strSql = "select cast(isnull(Scale,0) as varchar(10))+'|'+cast(isnull(IsOpen,0) as varchar(10)) from ShopNum1_ProductCategory where code in(select substring(productcategoryCode,1,3) from shopnum1_shop_product where guid='" + strProductGuId + "')";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable SearchtTwoProductCategory(int fatherID, int isDeleted)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,Name,CategoryLevel from ShopNum1_ProductCategory as t where 1=1 ");
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
		public DataTable GetTwoOverType(int fatherId, string strTopCount)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@fatherid";
			array2[0] = fatherId.ToString();
			array[1] = "@showCount";
			array2[1] = strTopCount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetTwoOverType_V82", array, array2);
		}
		public int AddList(List<ShopNum1_ProductCategory> list_ProductCategory)
		{
			List<string> list = new List<string>();
			if (list_ProductCategory != null && list_ProductCategory.Count > 0)
			{
				for (int i = 0; i < list_ProductCategory.Count; i++)
				{
					string text = this.method_0(list_ProductCategory[i].CategoryLevel, list_ProductCategory[i].FatherID);
					string text2 = string.Empty;
					text2 = "INSERT INTO ShopNum1_ProductCategory(  Name  ,";
					text2 = text2 + " OrderID  , Keywords  , Description  , CategoryLevel  , FatherID  , CreateUser  , CreateTime  , ModifyUser  , ModifyTime  , Code  , IsDeleted , logoimg,   CategoryType ,  IsShow ,  CategoryTypeName    ) VALUES (  '" + Operator.FilterString(list_ProductCategory[i].Name) + "', ";
					text2 = string.Concat(new object[]
					{
						text2,
						" ",
						list_ProductCategory[i].OrderID,
						",  '",
						list_ProductCategory[i].Keywords,
						"',  '",
						list_ProductCategory[i].Description,
						"',  ",
						list_ProductCategory[i].CategoryLevel,
						",  ",
						list_ProductCategory[i].FatherID,
						",  '",
						list_ProductCategory[i].CreateUser,
						"', '",
						list_ProductCategory[i].CreateTime,
						"',  '",
						list_ProductCategory[i].ModifyUser,
						"' , '",
						list_ProductCategory[i].ModifyTime,
						"',  '",
						text,
						"',  ",
						list_ProductCategory[i].IsDeleted,
						",  '",
						list_ProductCategory[i].logoimg,
						" ', '",
						list_ProductCategory[i].CategoryType,
						" ', '",
						list_ProductCategory[i].IsShow,
						" ', '",
						list_ProductCategory[i].CategoryTypeName,
						" ')"
					});
					text2 += "  SELECT  @@IDENTITY AS 'Identity'";
					list.Add(text2);
				}
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
	}
}
