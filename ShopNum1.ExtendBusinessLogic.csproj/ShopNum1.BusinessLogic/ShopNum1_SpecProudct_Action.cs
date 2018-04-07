using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SpecProudct_Action : IShopNum1_SpecProudct_Action
	{
		public DataTable dt_SpecProducts(string strPid)
		{
			string strSql = "SELECT * FROM dbo.ShopNum1_SpecProudct where productguid='" + strPid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable dt_SpecProducts(string strPid, string strCtype, string strV)
		{
			string strSql = string.Concat(new string[]
			{
				"SELECT * FROM dbo.ShopNum1_SpecProudct where productguid='",
				strPid,
				"' And productguid in(select productguid from ShopNum1_SpecProudctDetails where productguid='",
				strPid,
				"' And typeid='",
				strCtype,
				"')"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable dt_SpecProducts(string strPid, string strSpecDetail)
		{
			string strSql = string.Concat(new string[]
			{
				"SELECT * FROM dbo.ShopNum1_SpecProudct where productguid='",
				strPid,
				"' and specdetail='",
				strSpecDetail,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int AddListSpecProducts(List<ShopNum1_SpecProudct> SpecProudcts)
		{
			List<string> list = new List<string>();
			if (SpecProudcts != null)
			{
				list.Add("delete from ShopNum1_SpecProudct where productguid='" + SpecProudcts[0].ProductGuid + "'");
				for (int i = 0; i < SpecProudcts.Count; i++)
				{
					string item = string.Concat(new object[]
					{
						"INSERT INTO dbo.ShopNum1_SpecProudct \r\n        ( ProductGuid ,\r\n          SpecDetail ,\r\n          SpecTotalId ,\r\n          GoodsPrice,\r\n          GoodsStock ,\r\n          GoodsNumber ,\r\n          GoodColor,\r\n          TbProp,\r\n          ShopId,\r\n          CreateTime  \r\n        ) Values('",
						SpecProudcts[i].ProductGuid,
						"','",
						SpecProudcts[i].SpecDetail,
						"','",
						SpecProudcts[i].SpecTotalId,
						"','",
						SpecProudcts[i].GoodsPrice,
						"','",
						SpecProudcts[i].GoodsStock,
						"','",
						SpecProudcts[i].GoodsNumber,
						"','",
						SpecProudcts[i].GoodColor,
						"','",
						SpecProudcts[i].TbProp,
						"','",
						SpecProudcts[i].ShopID,
						"','",
						Convert.ToDateTime(SpecProudcts[i].CreateTime).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
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
			catch
			{
				result = 0;
			}
			return result;
		}
		public int UpdateListSpecProducts(List<ShopNum1_SpecProudct> SpecificationProudcts)
		{
			List<string> list = new List<string>();
			if (SpecificationProudcts != null)
			{
				for (int i = 0; i < SpecificationProudcts.Count; i++)
				{
					string item = string.Format("update dbo.ShopNum1_SpecProudct set SpecDetail='{0}',SpecTotalId='{1}',\r\nSpecTotalId='{2}',GoodsPrice='{3}',GoodsStock='{4}',GoodsNumber='{5}',GoodColor='{6}' where ProductGuid='{7}'", new object[]
					{
						SpecificationProudcts[i].SpecDetail,
						SpecificationProudcts[i].SpecTotalId,
						SpecificationProudcts[i].GoodsPrice,
						SpecificationProudcts[i].GoodsStock,
						SpecificationProudcts[i].GoodsNumber,
						SpecificationProudcts[i].GoodColor,
						SpecificationProudcts[i].ProductGuid
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
			catch
			{
				result = 0;
			}
			return result;
		}
		public int DeleteSpecProduct(string strPGuID)
		{
			string strSql = "Delete from ShopNum1_SpecProudct where ProductGuid='" + strPGuID + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetSpecificationByProduct(string productGuid, string Detail)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@productguid";
			array2[0] = productGuid;
			array[1] = "@SpecDetailDetail";
			array2[1] = Detail;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecProudctPriceChange", array, array2);
		}
		public DataTable Get(string productGuid, string Detail)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@productguid";
			array2[0] = productGuid;
			array[1] = "@SpecDetailDetail";
			array2[1] = Detail;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecProudctPriceChange", array, array2);
		}
	}
}
