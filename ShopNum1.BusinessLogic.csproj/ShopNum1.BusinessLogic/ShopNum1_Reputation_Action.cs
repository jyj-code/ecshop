using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Reputation_Action : IShopNum1_Reputation_Action
	{
		public DataTable ShopReputationSearch(string shopReputation, string isdeleted, string type)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@shopReputation";
			array2[0] = shopReputation;
			array[1] = "@isdeleted";
			array2[1] = isdeleted;
			array[2] = "@type";
			array2[2] = type;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_ShopReputationSearch", array, array2);
		}
	}
}
