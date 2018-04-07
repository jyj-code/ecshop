using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using System;
using System.Data;
using System.Runtime.CompilerServices;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Category_Action : IShop_Category_Action
	{
		[CompilerGenerated]
		private string string_0;
		public string TableName
		{
			get;
			set;
		}
		public DataTable GetShopCategoryCode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductCategoryCode", array, array2);
		}
		public DataTable GetShopCategoryFatherID(string fatherid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@fatherid";
			array2[0] = fatherid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopCategoryFatherID", array, array2);
		}
		public DataTable GetRegionCode(string code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@code";
			array2[0] = code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetRegionCode", array, array2);
		}
		public DataTable GetRegionFatherID(string fatherid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@fatherid";
			array2[0] = fatherid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetRegionFatherID", array, array2);
		}
		public DataTable GetShopBrand(string memberloiid, string categoryid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memberloiid";
			array2[0] = memberloiid;
			array[1] = "@categoryid";
			array2[1] = categoryid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopBrand", array, array2);
		}
	}
}
