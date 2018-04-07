using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Address_Action : IShop_Address_Action
	{
		public DataTable GetAddress(string guid, string isdefault)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@isdefault";
			array2[1] = isdefault;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetAddress", array, array2);
		}
	}
}
