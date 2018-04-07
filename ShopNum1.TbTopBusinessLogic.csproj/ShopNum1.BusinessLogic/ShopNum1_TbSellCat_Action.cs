using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_TbSellCat_Action : IShopNum1_TbSellCat_Action
	{
		private ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext_0 = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
		public bool InsertSellCat(ShopNum1_TbSellCat sellCat)
		{
			bool result;
			try
			{
				this.shopNum1_TbLinqDataContext_0.ShopNum1_TbSellCats.InsertOnSubmit(sellCat);
				this.shopNum1_TbLinqDataContext_0.SubmitChanges();
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		public bool UpdateSellCat(ShopNum1_TbSellCat sellCat)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@cid";
			array2[0] = sellCat.cid.ToString();
			array[1] = "@name";
			array2[1] = sellCat.name.ToString();
			array[2] = "@pic_url";
			array2[2] = sellCat.pic_url.ToString();
			array[3] = "@sort_order";
			array2[3] = sellCat.sort_order.ToString();
			array[4] = "@site_cid";
			array2[4] = sellCat.site_cid.ToString();
			array[5] = "@shopname";
			array2[5] = sellCat.shopname;
			array[6] = "@MemloginId";
			array2[6] = sellCat.MemloginId;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbSellCat_Update", array, array2) > 0;
		}
		public decimal CheckSellCat(string shopname, string string_0, string memloginid, string site_cid)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@shopname";
			array2[0] = shopname;
			array[1] = "@cid";
			array2[1] = string_0;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			array[3] = "@site_cid";
			array2[3] = site_cid;
			DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbSellCat_Check", array, array2);
			decimal result;
			if (dataTable == null || dataTable.Rows.Count == 0)
			{
				result = 0m;
			}
			else
			{
				object obj = dataTable.Rows[0][0];
				if (obj == null)
				{
					result = 0m;
				}
				else
				{
					result = Convert.ToInt32(obj);
				}
			}
			return result;
		}
		public DataTable GetSellCat(decimal siteCid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@site_cid";
			array2[0] = siteCid.ToString();
			DataSet dataSet = DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_TbSellCat_CheckSiteCid", array, array2);
			DataTable result;
			if (dataSet.Tables.Count == 2)
			{
				result = dataSet.Tables[1];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public DataTable GetAllCidByShopName(string shopName, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shopname";
			array2[0] = shopName;
			array[1] = "@MemloginId";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbSellCat_GetAllcid", array, array2);
		}
		public bool DeleteSellCat(string shopname, string memlogid, decimal decimal_0, decimal sitecid)
		{
			int num = this.shopNum1_TbLinqDataContext_0.Pro_ShopNum1_TbSellCat_Delete(shopname, memlogid, new decimal?(decimal_0), new decimal?(sitecid));
			return num > 0;
		}
		public decimal CheckSellCatByTb(string shopname, string string_0, string MemloginId)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@shopname";
			array2[0] = shopname;
			array[1] = "@cid";
			array2[1] = string_0;
			array[2] = "@memloginId";
			array2[2] = MemloginId;
			DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbSellCat_Check", array, array2);
			decimal result;
			if (dataTable == null || dataTable.Rows.Count == 0)
			{
				result = 0m;
			}
			else
			{
				result = Convert.ToDecimal(dataTable.Rows[0]["site_cid"]);
			}
			return result;
		}
		public decimal CheckSiteSellCat(decimal siteCid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@site_cid";
			array2[0] = siteCid.ToString();
			DataSet dataSet = DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_TbSellCat_CheckSiteCid", array, array2);
			decimal result;
			if (dataSet == null)
			{
				result = 0m;
			}
			else if (dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0)
			{
				result = 0m;
			}
			else if (dataSet.Tables[0].Rows[0]["TotalCount"].ToString() == "0")
			{
				result = 0m;
			}
			else
			{
				result = Convert.ToDecimal(dataSet.Tables[1].Rows[0]["cid"]);
			}
			return result;
		}
	}
}
