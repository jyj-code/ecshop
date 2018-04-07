using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1.TbLinq;
using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_TbItem_Action : IShopNum1_TbItem_Action
	{
		[CompilerGenerated]
		private sealed class Class6
		{
			public decimal decimal_0;
		}
		public string checkItemExists(decimal numiid)
		{
			ShopNum1_TbLinqDataContext shopNum1_TbLinqDataContext = new ShopNum1_TbLinqDataContext(DatabaseExcetue.GetConnstring());
			string result;
			try
			{
				IQueryable<string> queryable = 
					from v in shopNum1_TbLinqDataContext.ShopNum1_TbItems
					where v.num_iid == (decimal?)Convert.ToDecimal(numiid)
					select v.site_Id;
				if (queryable == null)
				{
					result = "";
				}
				else
				{
					DataTable dataTable = (DataTable)queryable;
					if (dataTable.Rows.Count == 0)
					{
						result = "";
					}
					else
					{
						result = dataTable.Rows[0]["site_Id"].ToString();
					}
				}
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		public DataSet checkItemSiteExists(string siteCid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@site_id";
			array2[0] = siteCid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_TbItemCheckSite", array, array2);
		}
		public bool InsertItem(ShopNum1_TbItem tbitem)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@num_iid";
			array2[0] = tbitem.num_iid.ToString();
			array[1] = "@site_id";
			array2[1] = tbitem.site_Id;
			array[2] = "@memlogid";
			array2[2] = tbitem.Memlogid;
			array[3] = "@shopname";
			array2[3] = tbitem.ShopName;
			array[4] = "@istaobao";
			array2[4] = tbitem.isTaobao.ToString();
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbItem_InsertS", array, array2) > 0;
		}
		public bool InsertItemSimplify(decimal numiid, string siteId, decimal decimal_0, bool isTaobao)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@num_iid";
			array2[0] = numiid.ToString();
			array[1] = "@site_id";
			array2[1] = siteId.ToString();
			array[2] = "@cid";
			array2[2] = decimal_0.ToString();
			array[3] = "@isTaobao";
			array2[3] = isTaobao.ToString();
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbItem_InsertS", array, array2) > 0;
		}
		public DataTable GetAllItem(string shopname, string memlogid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memlogid";
			array2[0] = memlogid;
			array[1] = "@shopname";
			array2[1] = shopname;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbItem_GetAll", array, array2);
		}
		public bool UpdateProductCount(string num_iid, string memlogid, string string_0)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@num_iid";
			array2[0] = num_iid;
			array[1] = "@memlogid";
			array2[1] = memlogid;
			array[2] = "@num";
			array2[2] = string_0;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbItem_UpdateProductCount", array, array2) > 0;
		}
		public bool UpdateProductItems(string num_iid, string memlogid, string string_0, string title, string price)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@num_iid";
			array2[0] = num_iid;
			array[1] = "@memlogid";
			array2[1] = memlogid;
			array[2] = "@num";
			array2[2] = string_0;
			array[3] = "@title";
			array2[3] = title;
			array[4] = "@price";
			array2[4] = price;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_TbItem_UpdateProductItem", array, array2) > 0;
		}
		public string CheckItemByTb(string num_iid, string Memlogid, string shopName)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@num_iid";
			array2[0] = num_iid;
			array[1] = "@Memlogid";
			array2[1] = Memlogid;
			array[2] = "@shopname";
			array2[2] = shopName;
			DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_TbItemCheck", array, array2);
			string result;
			if (dataTable == null || dataTable.Rows.Count == 0)
			{
				result = "0";
			}
			else
			{
				result = dataTable.Rows[0]["site_Id"].ToString();
			}
			return result;
		}
	}
}
