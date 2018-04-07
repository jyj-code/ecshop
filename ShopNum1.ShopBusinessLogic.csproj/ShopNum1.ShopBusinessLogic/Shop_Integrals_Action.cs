using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Integrals_Action : IShop_Integrals_Action
	{
		public int AddShopIntegral(ShopNum1_Shop_Integral shop_Integral)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@memloginid";
			array2[0] = shop_Integral.MemLoginID;
			array[1] = "@score";
			array2[1] = shop_Integral.Score.ToString();
			array[2] = "@agentloginid";
			array2[2] = shop_Integral.AgentLoginID;
			array[3] = "@isaudit";
			array2[3] = shop_Integral.IsAudit.ToString();
			array[4] = "@remark";
			array2[4] = shop_Integral.Remark;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddIntegral", array, array2);
		}
		public int DeleteIntegral(string guid, string isaudit)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@isaudit";
			array2[1] = isaudit;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteIntegral", array, array2);
		}
		public DataTable GetIntegralInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIntegralInfo", array, array2);
		}
		public DataTable GetIntegralList(string memloginid, string isaudit)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@isaudit";
			array2[1] = isaudit;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIntegralList", array, array2);
		}
		public DataTable SearchIntegralCostList(string shopid, string scorestate)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@scorestate";
			array2[1] = scorestate;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchIntegralCostList", array, array2);
		}
	}
}
