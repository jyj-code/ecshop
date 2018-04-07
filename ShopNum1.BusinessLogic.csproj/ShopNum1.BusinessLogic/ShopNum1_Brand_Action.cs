using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Brand_Action : IShopNum1_Brand_Action
	{
		[CompilerGenerated]
		private string string_0;
		public string TableName
		{
			get;
			set;
		}
		public DataTable Search_Type_Brand(string strId)
		{
			string strSql = "select guid,name,(select top 1 id from shopnum1_typebrand where brandguid=t.guid and typeid='" + strId + "')as ischeck from shopnum1_brand as t where IsDeleted=0 AND IsShow =1 order by orderid asc ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetBrandMeto(string guid)
		{
			string text = string.Empty;
			text = "SELECT  Name,Keywords,Description FROM ShopNum1_Brand where 0=0";
			guid = guid.Replace("'", "");
			if (Operator.FormatToEmpty(guid) != "-1")
			{
				text = text + "  and IsDeleted=0 AND IsShow =1  AND  Guid='" + guid + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_Brand brand)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Brand( Guid, Name, CategoryName,Logo, WebSite, OrderID, Keywords, IsShow, Remark, Description, CreateUser, CreateTime, ModifyUser, ModifyTime, IsCommend,  IsDeleted  ) VALUES (  '",
				brand.Guid,
				"',  '",
				Operator.FilterString(brand.Name),
				"',  '",
				Operator.FilterString(brand.CategoryName),
				"',  '",
				Operator.FilterString(brand.Logo),
				"',  '",
				brand.WebSite,
				"',  ",
				brand.OrderID,
				",  '",
				Operator.FilterString(brand.Keywords),
				"',  ",
				brand.IsShow,
				",  '",
				Operator.FilterString(brand.Remark),
				"',  '",
				Operator.FilterString(brand.Description),
				"',  '",
				brand.CreateUser,
				"', '",
				brand.CreateTime,
				"',  '",
				brand.ModifyUser,
				"' , '",
				brand.ModifyTime,
				"',  '",
				brand.IsCommend,
				"',  ",
				brand.IsDeleted,
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "delete from ShopNum1_Brand  WHERE Guid IN (" + guids + ") ";
			list.Add(item);
			item = "delete from ShopNum1_ProductCategoryAndProductBranDrelation  WHERE BrandGuid IN (" + guids + ")";
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
		public DataTable SearchF0(string name, string link, int isDeleted, string IsShow, string IsRecommond, string CategoryName)
		{
			string text = string.Empty;
			text = "select  Guid,Name,Logo,WebSite,OrderID,Keywords,IsShow,Remark,CategoryName,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsCommend";
			text += "  from ShopNum1_Brand where 1=1 ";
			if (Operator.FormatToEmpty(link) != string.Empty)
			{
				text = text + " and website like '%" + link + "%'";
			}
			if (IsShow == "0" || IsShow == "1")
			{
				text = text + " AND IsShow='" + IsShow + "' ";
			}
			if (IsRecommond == "0" || IsRecommond == "1")
			{
				text = text + " AND iscommend='" + IsRecommond + "' ";
			}
			if (Operator.FormatToEmpty(CategoryName) != string.Empty)
			{
				text = text + " AND CategoryName LIKE '%" + Operator.FilterString(CategoryName) + "%'";
			}
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND  IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += " Order By OrderID asc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetEditInfo(string guid)
		{
			string text = string.Empty;
			text = "SELECT  Name,CategoryName,IsCommend, Logo,WebSite,OrderID,Keywords,IsShow,Remark,Description, CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted FROM ShopNum1_Brand WHERE 0=0";
			guid = guid.Replace("'", "");
			if (Operator.FormatToEmpty(guid) != "-1")
			{
				text = text + " AND  Guid='" + guid + "'  and IsDeleted=0 ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(string guid, ShopNum1_Brand brand)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Brand SET  Name='",
				Operator.FilterString(brand.Name),
				"', CategoryName='",
				Operator.FilterString(brand.CategoryName),
				"', Logo='",
				Operator.FilterString(brand.Logo),
				"', WebSite='",
				brand.WebSite,
				"', OrderID=",
				brand.OrderID,
				", IsCommend=",
				brand.IsCommend,
				", Keywords='",
				Operator.FilterString(brand.Keywords),
				"', IsShow=",
				brand.IsShow,
				", Remark='",
				Operator.FilterString(brand.Remark),
				"', Description='",
				Operator.FilterString(brand.Description),
				"', ModifyUser='",
				brand.ModifyUser,
				"', ModifyTime='",
				brand.ModifyTime,
				"' WHERE Guid=",
				guid,
				";UPDATE shopnum1_shop_product SET BrandName='",
				Operator.FilterString(brand.Name),
				"' WHERE BrandGuid=",
				guid,
				" "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetProductCategoryCode(string fatherID)
		{
			string text = string.Empty;
			text = "select ID,Name,Code from " + this.TableName;
			text = text + " WHERE FatherID=" + fatherID;
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable CheckBrand(string strBrand)
		{
			string strSql = string.Empty;
			strSql = "Select guid from ShopNum1_Brand where Name='" + strBrand + "'  and IsDeleted=0 AND IsShow =1 ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add_TypeBrand(List<ShopNum1_TypeBrand> listShopNum1_TypeBrand)
		{
			List<string> list = new List<string>();
			if (listShopNum1_TypeBrand != null && listShopNum1_TypeBrand.Count > 0)
			{
				list.Add("delete from ShopNum1_TypeBrand where typeid='" + listShopNum1_TypeBrand[0].TypeID + "'");
				for (int i = 0; i < listShopNum1_TypeBrand.Count; i++)
				{
					string item = string.Concat(new object[]
					{
						"insert into ShopNum1_TypeBrand(typeid,brandguid)values('",
						listShopNum1_TypeBrand[i].TypeID,
						"','",
						listShopNum1_TypeBrand[i].BrandGuid,
						"')"
					});
					list.Add(item);
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
		public int Delete_TypeBrand(string strId)
		{
			string strSql = "delete from ShopNum1_TypeBrand where id='" + strId + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name,OrderID ,IsDeleted FROM ShopNum1_Brand where 0=0 ";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					"  and IsDeleted=0 AND IsShow =1  "
				});
			}
			text += " ORDER BY OrderID DESC ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchF(string name, int isDeleted, string productCategorycode)
		{
			string text = string.Empty;
			text = "select  Guid,Name,Logo,WebSite,OrderID,Keywords,IsShow,Remark,ProductCategoryCode,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsCommend";
			text += "  from ShopNum1_Brand ";
			text += "  where Guid  in  (";
			text += "  select  BrandGuid  from ShopNum1_ProductCategoryAndProductBranDrelation  where";
			if (productCategorycode != "-1")
			{
				text = text + " ProductCategoryCode  like  '" + productCategorycode + "%')  ";
			}
			else
			{
				text += " 1=1 )  ";
			}
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND  IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += "  and IsDeleted=0 AND IsShow =1  Order By OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable dt_Select_BrandByCid(string strCid)
		{
			string text = "SELECT name,Guid FROM dbo.ShopNum1_Brand X WHERE Guid IN ";
			text += "(SELECT BrandGuid FROM dbo.ShopNum1_TypeBrand b ";
			text = text + "INNER JOIN ShopNum1_CategoryType c ON c.id=b.TypeID WHERE c.id='" + strCid + "') and IsDeleted=0 AND IsShow =1 ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchBrand(string pagesize)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchBrand", array, array2);
		}
		public DataTable GetProductBrand(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductBrand", array, array2);
		}
		public DataTable GetProductBrandBycount(string code, string ShowCountTwo)
		{
			string text = string.Empty;
			text = text + "select distinct Top " + ShowCountTwo + " * from (SELECT  Guid,A.Name,Logo,WebSite,A.orderid from ShopNum1_Brand A INNER JOIN";
			text += " ShopNum1_TypeBrand B ON B.BRANDGUID=a.GUID INNER JOIN";
			text += " shopnum1_productcategory C on c.categorytype=b.typeid";
			if (code != "-1")
			{
				text = text + "  AND  Code  LIKE '" + code + "%'";
			}
			text += " AND A.IsDeleted=0 AND A.IsShow =1 ) as tab order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetBrandCategory(string showCount)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@showCount";
			array2[0] = showCount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetBrandCategory", array, array2);
		}
		public DataTable GetBrandImgByCode(string showCount, string code)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@showCount";
			array2[0] = showCount;
			array[1] = "@code";
			array2[1] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetBrandImgByCode", array, array2);
		}
		public DataTable SearchProductByBrandGuid(string brandGuid, string field, string order)
		{
			string text = string.Empty;
			text = "SELECT \tA.Guid\t, \tA.Name\t, \tA.IsPanicBuy\t, \tA.IsSpellBuy\t, \tB.ShopID\t, \tA.OriginalImage\t, \tA.ThumbImage\t, \tA.SmallImage\t, \tA.MarketPrice\t, \tA.ShopPrice\t, \tA.BrandName\t, \tA.CreateTime\t, \tA.MemLoginID\t  FROM ShopNum1_Shop_Product AS A,ShopNum1_ShopInfo AS B  WHERE A.MemLoginID=B.MemLoginID AND A.IsDeleted=0 AND IsSell=1 AND IsSaled=1 ";
			if (brandGuid != "-1")
			{
				text = text + " AND BrandGuid='" + brandGuid + "'";
			}
			text = string.Concat(new string[]
			{
				text,
				" ORDER BY ",
				field,
				" ",
				order
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable BindProductBrand(string Code)
		{
			string strSql = string.Empty;
			DataTable result;
			if (Code != "0")
			{
				strSql = "SELECT Guid,Name,Logo From ShopNum1_Brand Where guid in(select brandguid from ShopNum1_TypeBrand where typeid in(select categorytype from shopnum1_productcategory where code like '" + Code + "%'))and IsShow=1";
				result = DatabaseExcetue.ReturnDataTable(strSql);
			}
			else
			{
				strSql = "SELECT Guid,Name,Logo From ShopNum1_Brand Where IsShow=1 And IsCommend=1 ";
				result = DatabaseExcetue.ReturnDataTable(strSql);
			}
			return result;
		}
		public DataTable Select_Brand_Import(string strTypeId)
		{
			string strSql = "SELECT GUID as code,NAME FROM  shopnum1_brand WHERE GUID IN(select BRANDGUID from shopnum1_typebrand where typeid='" + strTypeId + "' ) and IsDeleted=0 AND IsShow =1 ";
			if (strTypeId == "")
			{
				strSql = "SELECT GUID as code,NAME FROM  shopnum1_brand where  IsDeleted=0 AND IsShow =1 ";
			}
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
