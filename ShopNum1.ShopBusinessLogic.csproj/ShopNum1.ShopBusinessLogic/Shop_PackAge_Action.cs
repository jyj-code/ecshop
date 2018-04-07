using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_PackAge_Action : IShop_PackAge_Action
	{
		public int OpPackAge(ShopNum1_PackAge ShopNum1_PackAge, List<ShopNum1_PackAgeRalate> listPackAgeRalate)
		{
			string[] array = new string[10];
			string[] array2 = new string[10];
			array[0] = "@Name";
			array2[0] = ShopNum1_PackAge.Name;
			array[1] = "@Price";
			array2[1] = ShopNum1_PackAge.Price.ToString();
			array[2] = "@SalePrice";
			array2[2] = ShopNum1_PackAge.SalePrice.ToString();
			array[3] = "@Pic";
			array2[3] = ShopNum1_PackAge.Pic;
			array[4] = "@Desc";
			array2[4] = ShopNum1_PackAge.Desc;
			array[5] = "@state";
			array2[5] = ShopNum1_PackAge.State.ToString();
			array[6] = "@ShopName";
			array2[6] = ShopNum1_PackAge.ShopName;
			array[7] = "@MemloginId";
			array2[7] = ShopNum1_PackAge.MemloginId;
			array[8] = "@CreateTime";
			array2[8] = ShopNum1_PackAge.CreateTime.ToString();
			array[9] = "@Id";
			array2[9] = ShopNum1_PackAge.Id.ToString();
			int value = Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_OpPackAge", array, array2));
			List<string> list = new List<string>();
			if (listPackAgeRalate != null && listPackAgeRalate.Count > 0)
			{
				list.Add("DELETE FROM ShopNum1_PackAgeRalate WHERE Packageid='" + ShopNum1_PackAge.Id + "'");
				for (int i = 0; i < listPackAgeRalate.Count; i++)
				{
					listPackAgeRalate[i].PackAgeId = new int?(value);
					list.Add(string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_PackAgeRalate(productguid,packageid) Values('",
						listPackAgeRalate[i].ProductGuid,
						"','",
						listPackAgeRalate[i].PackAgeId,
						"')"
					}));
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
			return 0;
		}
		public DataTable SelectPackAgeProduct(string pagesize, string currentpage, string condition, string resultnum, string sortvalue, string ordercolumn, string strColumns, string strTabName)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = strColumns;
			array[3] = "@tablename";
			array2[3] = strTabName;
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = ordercolumn;
			array[6] = "@sortvalue";
			array2[6] = sortvalue;
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataSet GetPackAgeInfo(string strPackAgeId, string strMemloginID)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@packageid";
			array2[0] = strPackAgeId;
			array[1] = "@memloginId";
			array2[1] = strMemloginID;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_shop_GetPackageInfo", array, array2);
		}
		public int DeletePackAgeInfo(string strPackAgeId, string strProductGuID)
		{
			string strSql = string.Concat(new string[]
			{
				"delete from ShopNum1_PackAgeRalate where productguid='",
				strProductGuID,
				"' AND packageId='",
				strPackAgeId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeletePackAge(string strPackAgeId, string strMemloginId)
		{
			string item = string.Concat(new string[]
			{
				"delete from ShopNum1_PackAge where id='",
				strPackAgeId,
				"' AND memloginId='",
				strMemloginId,
				"';"
			});
			List<string> list = new List<string>();
			list.Add(item);
			list.Add("DELETE FROM ShopNum1_PackAgeRalate WHERE packageId='" + strPackAgeId + "';");
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
		public DataSet GetPackAgeProduct(string strPackAgeId, string strProductGuID)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@packageid";
			array2[0] = strPackAgeId;
			array[1] = "@productguid";
			array2[1] = strProductGuID;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_GetPackAgeProduct", array, array2);
		}
	}
}
