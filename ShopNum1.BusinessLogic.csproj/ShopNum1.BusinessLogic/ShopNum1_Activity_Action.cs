using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Activity_Action : IShopNum1_Activity_Action
	{
		public int AddActivity(ShopNum1_Product_Activity ShopNum1_Activity)
		{
			string text = "INSERT INTO ShopNum1_Product_Activity(name,starttime,endtime,finaltime,type,pic,Discount,limitProduct,memloginId,shopName,SubstationID";
			if (ShopNum1_Activity.State.ToString() != "")
			{
				text += ",state";
			}
			text += ")";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"VALUES('",
				ShopNum1_Activity.Name,
				"','",
				ShopNum1_Activity.StartTime,
				"','",
				ShopNum1_Activity.EndTime,
				"','",
				ShopNum1_Activity.FinalTime,
				"',"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"'",
				ShopNum1_Activity.Type,
				"','",
				ShopNum1_Activity.Pic,
				"','",
				ShopNum1_Activity.Discount,
				"','",
				ShopNum1_Activity.LimitProduct,
				"',"
			});
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"'",
				ShopNum1_Activity.MemloginId,
				"','",
				ShopNum1_Activity.ShopName,
				"','",
				ShopNum1_Activity.SubstationID,
				"'"
			});
			if (ShopNum1_Activity.State.ToString() != "")
			{
				text += ",0";
			}
			text += ");";
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int UpdateActivity(ShopNum1_Product_Activity ShopNum1_Activity)
		{
			string text = "UPDATE ShopNum1_Product_Activity SET name='" + ShopNum1_Activity.Name + "',";
			if (!string.IsNullOrEmpty(ShopNum1_Activity.Pic))
			{
				text = text + "pic='" + ShopNum1_Activity.Pic + "',";
			}
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"starttime='",
				ShopNum1_Activity.StartTime,
				"',"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"endtime='",
				ShopNum1_Activity.EndTime,
				"',"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"finaltime='",
				ShopNum1_Activity.FinalTime,
				"',"
			});
			if (!string.IsNullOrEmpty(ShopNum1_Activity.Discount.ToString()))
			{
				obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"discount='",
					ShopNum1_Activity.Discount,
					"',"
				});
			}
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"type='",
				ShopNum1_Activity.Type,
				"'"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" where id='",
				ShopNum1_Activity.Id,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "id,name,starttime,endtime,finaltime,state,type,Discount,memloginId,shopName,SubstationID";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Product_Activity";
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = "starttime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int CloseActivity(string strId)
		{
			string strSql = "UPDATE ShopNum1_Product_Activity SET State='2' WHERE Id='" + strId + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteActivity(string strId)
		{
			string strSql = string.Concat(new string[]
			{
				"DELETE FROM ShopNum1_Product_Activity WHERE Id in(",
				strId,
				");delete from ShopNum1_Limt_Product where lid in(",
				strId,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetProductActivity()
		{
			string strSql = "select id,name, CONVERT(varchar(100),starttime, 102)s,CONVERT(varchar(100),endtime, 102)e from ShopNum1_Product_Activity where state!=2 and endtime>getdate()  and type=1";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetProductActivity(string SubstationID)
		{
			string strSql = "select id,name, CONVERT(varchar(100),starttime, 102)s,CONVERT(varchar(100),endtime, 102)e from ShopNum1_Product_Activity where state!=2 and endtime>getdate()  and type=1  and SubstationID='" + SubstationID + "'  ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int AddThemeActivty(ShopNum1_ThemeActivity shopNum1_ThemeActivity)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO [ShopNum1_ThemeActivity] ");
			stringBuilder.Append(" ([Guid] ");
			stringBuilder.Append(" ,[ThemeTitle] ");
			stringBuilder.Append(" ,[StartDate] ");
			stringBuilder.Append(" ,[EndDate] ");
			stringBuilder.Append(" ,[ThemeImage] ");
			stringBuilder.Append(" ,[ThemeDescription] ");
			stringBuilder.Append(" ,[ThemeStatus] ");
			stringBuilder.Append(" ,[OrderID] ");
			stringBuilder.Append(" ,[CreateUser] ");
			stringBuilder.Append(" ,[CreateTime] ");
			stringBuilder.Append(" ,[SubstationID]) ");
			stringBuilder.Append(" VALUES ");
			stringBuilder.Append(" ('" + shopNum1_ThemeActivity.Guid + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivity.ThemeTitle + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivity.StartDate + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivity.EndDate + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivity.ThemeImage + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivity.ThemeDescription + "' ");
			stringBuilder.Append(" ," + shopNum1_ThemeActivity.ThemeStatus + " ");
			stringBuilder.Append(" ," + shopNum1_ThemeActivity.OrderID + " ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivity.CreateUser + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivity.CreateTime + "'");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivity.SubstationID + "')");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int UpdateThemeActivty(ShopNum1_ThemeActivity shopNum1_ThemeActivity)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE [ShopNum1_ThemeActivity] ");
			stringBuilder.Append(" SET ");
			stringBuilder.Append(" [ThemeTitle] = '" + shopNum1_ThemeActivity.ThemeTitle + "' ");
			stringBuilder.Append(" ,[StartDate] = '" + shopNum1_ThemeActivity.StartDate + "' ");
			stringBuilder.Append(" ,[EndDate] = '" + shopNum1_ThemeActivity.EndDate + "' ");
			stringBuilder.Append(" ,[ThemeImage] = '" + shopNum1_ThemeActivity.ThemeImage + "' ");
			stringBuilder.Append(" ,[ThemeDescription] = '" + shopNum1_ThemeActivity.ThemeDescription + "' ");
			stringBuilder.Append(" ,[ThemeStatus] = " + shopNum1_ThemeActivity.ThemeStatus + " ");
			stringBuilder.Append(" ,[OrderID] = " + shopNum1_ThemeActivity.OrderID + " ");
			stringBuilder.Append(" ,[CreateUser] = '" + shopNum1_ThemeActivity.CreateUser + "' ");
			stringBuilder.Append(" ,[CreateTime] = '" + shopNum1_ThemeActivity.CreateTime + "' ");
			stringBuilder.Append(" WHERE [Guid] = '" + shopNum1_ThemeActivity.Guid + "' ");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetThemeActivtyByGuid(string Guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from ShopNum1_ThemeActivity where Guid='" + Guid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SelectThemeActivty(string pagesize, string currentpage, string condition, string resultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "Guid,ThemeTitle,StartDate,EndDate,ThemeImage,ThemeDescription,ThemeStatus,OrderID,CreateUser,CreateTime,SubstationID";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_ThemeActivity";
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = "CreateTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable GetThemeActivty()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  Guid,ThemeTitle, CONVERT(varchar(100),startdate, 102)s,CONVERT(varchar(100),enddate, 102)e from ShopNum1_ThemeActivity where ThemeStatus!=2 and enddate>getdate() ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int DeleteThemeActivty(string guid)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "DELETE FROM [ShopNum1_ThemeActivity] WHERE Guid in (" + guid + ")";
			list.Add(item);
			item = "Delete from ShopNum1_ThemeActivityProduct where ThemeGuid in (" + guid + ")";
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
		public DataTable SelectThemeActivtyProduct(string pagesize, string currentpage, string condition, string resultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "Guid,ThemeGuid,ProductGuid,ProductName,ProductImage,ProductPrice,ShopName,MemloginId,IsAudit,CreateTime";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_ThemeActivityProduct";
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = "CreateTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int DeleteThemeActivtyProduct(string Guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Delete from ShopNum1_ThemeActivityProduct where Guid in (" + Guid + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int UpdateThemeProductIsAudit(string Guid, string IsAudit)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"Update ShopNum1_ThemeActivityProduct set IsAudit=",
				IsAudit,
				" where Guid='",
				Guid,
				"'"
			}));
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int AddThemeProduct(ShopNum1_ThemeActivityProduct shopNum1_ThemeActivityProduct)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO [ShopNum1_ThemeActivityProduct] ");
			stringBuilder.Append(" ([Guid] ");
			stringBuilder.Append(" ,[ThemeGuid] ");
			stringBuilder.Append(" ,[ProductGuid] ");
			stringBuilder.Append(" ,[ProductName] ");
			stringBuilder.Append(" ,[ProductImage] ");
			stringBuilder.Append(" ,[ProductPrice] ");
			stringBuilder.Append(" ,[ShopName] ");
			stringBuilder.Append(" ,[MemloginID] ");
			stringBuilder.Append(" ,[IsAudit] ");
			stringBuilder.Append(" ,[CreateTime]) ");
			stringBuilder.Append("  VALUES ");
			stringBuilder.Append(" ('" + shopNum1_ThemeActivityProduct.Guid + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.ThemeGuid + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.ProductGuid + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.ProductName + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.ProductImage + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.ProductPrice + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.ShopName + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.MemloginID + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.IsAudit + "' ");
			stringBuilder.Append(" ,'" + shopNum1_ThemeActivityProduct.CreateTime + "')");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable SelectShopThemeActivty(string pagesize, string currentpage, string condition, string resultnum)
		{
			string text = "select Count(B.Guid)as ct ,A.Guid,A.SubstationID,A.ThemeTitle,A.ThemeDescription,A.ThemeStatus,A.StartDate,A.EndDate from dbo.ShopNum1_ThemeActivity A left join ShopNum1_ThemeActivityProduct B on A.Guid=B.ThemeGuid where 1=1  " + condition;
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = text;
			array[4] = "@condition";
			array2[4] = "";
			array[5] = "@ordercolumn";
			array2[5] = "startdate";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable SelectThemeProductByGuid(string pagesize, string currentpage, string condition, string resultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "A.Guid,A.ThemeTitle,A.ThemeImage,A.ThemeDesCription,A.ThemeStatus,B.ProductGuid,B.ProductName,B.ProductImage,B.ProductPrice,B.CreateTime,MemloginId,A.EndDate,B.ShopName,(select AddressValue from ShopNum1_shopinfo where memloginid=B.MemloginId)AddressValue,(select MarketPrice from ShopNum1_Shop_Product where guid=B.ProductGuid)MarketPrice";
			array[3] = "@tablename";
			array2[3] = " dbo.ShopNum1_ThemeActivity A inner join dbo.ShopNum1_ThemeActivityProduct B on A.Guid=B.ThemeGuid";
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = "B.CreateTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable SelectProductByThemeGuid(string themeGuid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from ShopNum1_ThemeActivityProduct where ThemeGuid ='" + themeGuid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetActivityById(string strMemloginId, string strLid)
		{
			string text = "select name,starttime s,endtime e,state,discount,memloginid,limitProduct,\r\n(select count(*) from ShopNum1_Limt_Product where lid=t.id)pc from ShopNum1_Product_Activity as t where type=2 ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				" and memloginid='",
				strMemloginId,
				"' and id='",
				strLid,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateActivityState(string strId, string strState)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Product_Activity SET State='",
				strState,
				"' where id='",
				strId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetGroupActivityById(string string_0)
		{
			string text = "select name,starttime,endtime from ShopNum1_Product_Activity where type=1 ";
			text = text + "and id='" + string_0 + "'";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
