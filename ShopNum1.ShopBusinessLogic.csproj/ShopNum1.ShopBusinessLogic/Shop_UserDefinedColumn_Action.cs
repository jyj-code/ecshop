using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_UserDefinedColumn_Action : IShop_UserDefinedColumn_Action
	{
		public int AddUserDefinedColumn(ShopNum1_Shop_UserDefinedColumn shop_UserDefinedColumn)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@guid";
			array2[0] = shop_UserDefinedColumn.Guid.ToString();
			array[1] = "@name";
			array2[1] = shop_UserDefinedColumn.Name;
			array[2] = "@linkaddress";
			array2[2] = shop_UserDefinedColumn.LinkAddress;
			array[3] = "@isshow";
			array2[3] = shop_UserDefinedColumn.IsShow.ToString();
			array[4] = "@ifopen";
			array2[4] = shop_UserDefinedColumn.IfOpen.ToString();
			array[5] = "@orderid";
			array2[5] = shop_UserDefinedColumn.OrderID.ToString();
			array[6] = "@memloginid";
			array2[6] = shop_UserDefinedColumn.MemLoginID;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddUserDefinedColumn", array, array2);
		}
		public DataTable GetUserDefinedColumnList(string memloginid, string isshow)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@isshow";
			array2[1] = isshow;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetUserDefinedColumnList", array, array2);
		}
		public int UpdateUserDefinedColumn(ShopNum1_Shop_UserDefinedColumn shop_UserDefinedColumn)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@guid";
			array2[0] = shop_UserDefinedColumn.Guid.ToString();
			array[1] = "@name";
			array2[1] = shop_UserDefinedColumn.Name;
			array[2] = "@linkaddress";
			array2[2] = shop_UserDefinedColumn.LinkAddress;
			array[3] = "@isshow";
			array2[3] = shop_UserDefinedColumn.IsShow.ToString();
			array[4] = "@ifopen";
			array2[4] = shop_UserDefinedColumn.IfOpen.ToString();
			array[5] = "@orderid";
			array2[5] = shop_UserDefinedColumn.OrderID.ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateUserDefinedColumn", array, array2);
		}
		public int DeleteUserDefinedColumn(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteUserDefinedColumn", array, array2);
		}
		public DataTable GetUserDefinedColumn(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetUserDefinedColumn", array, array2);
		}
		public DataTable SearchUserDefinedColumnList(string ifshow, string showlocation)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@ifshow";
			array2[0] = ifshow;
			array[1] = "@showlocation";
			array2[1] = showlocation;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchUserDefinedColumnList", array, array2);
		}
		public DataTable MetaGetUserDefinedColumn(string memloginid, string linkaddress)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@linkaddress";
			array2[1] = linkaddress;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_MetaGetUserDefinedColumn", array, array2);
		}
		public DataTable GetButtomNavigation(string showCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append(" TOP  " + showCount + " ");
			stringBuilder.Append("Name,");
			stringBuilder.Append("LinkAddress,");
			stringBuilder.Append("IfOpen ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_UserDefinedColumn");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ShowLocation='1' AND IfShow=1 AND IsShop=1");
			stringBuilder.Append(" ORDER BY OrderID  ");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SelectNavigation_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = " * ";
			array[3] = "@tablename";
			array2[3] = commonModel.Tablename;
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "OrderID";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
