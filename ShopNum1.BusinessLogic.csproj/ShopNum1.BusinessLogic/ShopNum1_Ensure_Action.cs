using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Ensure_Action : IShopNum1_Ensure_Action
	{
		public DataTable GetShopapplyEnsure(string shopid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@shopid";
			array2[0] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopApplyEnsure", array, array2);
		}
	}
}
