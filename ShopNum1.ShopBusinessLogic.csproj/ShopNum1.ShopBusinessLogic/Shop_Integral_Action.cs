using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using System;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Integral_Action : IShop_Integral_Action
	{
		public int AddIntegral(string memloginid, string score, string agentloginid, string isaudit)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@score";
			array2[1] = score;
			array[2] = "@agentloginid";
			array2[2] = agentloginid;
			array[3] = "@isaudit";
			array2[3] = isaudit;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddIntegral", array, array2);
		}
	}
}
