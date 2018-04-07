using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Friends_Action : IShop_Friends_Action
	{
		public DataTable GetFriendList(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetFriendList", array, array2);
		}
		public int UpdateFriend(string memloginid, string memberfriends)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@memberfriends";
			array2[1] = memberfriends;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateFriend", array, array2);
		}
		public int AddFriend(string memloginid, string memberfriends)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@memberfriends";
			array2[1] = memberfriends;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddFriend", array, array2);
		}
	}
}
