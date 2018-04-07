using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_LimtPackages_Action : IShop_LimtPackages_Action
	{
		public int AddLimtPackage(ShopNum1_Limt_Package shopNum1_Limt_Package)
		{
			string text = "INSERT INTO ShopNum1_Limt_Package(name,starttime,endtime,PublishedNum,LeaveNum,LimtActivityNum,LimitProductNum,BuyNum,PayMoney,ShopName,MemloginId)";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"VALUES('",
				shopNum1_Limt_Package.Name,
				"','",
				shopNum1_Limt_Package.StartTime,
				"','",
				shopNum1_Limt_Package.EndTime,
				"','",
				shopNum1_Limt_Package.PublishedNum,
				"',"
			});
			object obj2 = text;
			text = string.Concat(new object[]
			{
				obj2,
				"'",
				shopNum1_Limt_Package.LeaveNum,
				"','",
				shopNum1_Limt_Package.LimtActivityNum,
				"','",
				shopNum1_Limt_Package.LimitProductNum,
				"','",
				shopNum1_Limt_Package.BuyNum,
				"',"
			});
			object obj3 = text;
			text = string.Concat(new object[]
			{
				obj3,
				"'",
				shopNum1_Limt_Package.PayMoney,
				"','",
				shopNum1_Limt_Package.ShopName,
				"','",
				shopNum1_Limt_Package.MemloginId,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable SelectLimtPackage(string pagesize, string currentpage, string condition, string resultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Limt_Package";
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
		public string ReturnDate(string MemloginId)
		{
			string strSql = "select CONVERT(varchar(100),starttime,23)+'|'+CONVERT(varchar(100),endtime,23) from ShopNum1_Limt_Package where memloginid='" + MemloginId + "' order by endtime desc";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable SelectLastPack(string MemloginId)
		{
			string strSql = "select top 1 starttime,endtime,publishednum,leavenum,limtactivitynum from ShopNum1_Limt_Package where memloginid='" + MemloginId + "' order by endtime desc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int DeletePackById(string MemloginId, string strAid)
		{
			string item = string.Concat(new string[]
			{
				"DELETE FROM ShopNum1_Product_Activity WHERE MemloginId='",
				MemloginId,
				"' And Id='",
				strAid,
				"';"
			});
			string item2 = string.Concat(new string[]
			{
				"DELETE FROM ShopNum1_Limt_Product WHERE MemloginId='",
				MemloginId,
				"' And Lid='",
				strAid,
				"';"
			});
			List<string> list = new List<string>();
			list.Add(item);
			list.Add(item2);
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
	}
}
