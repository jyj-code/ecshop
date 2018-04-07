using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_UserDefinedColumn_Action
	{
		int AddUserDefinedColumn(ShopNum1_Shop_UserDefinedColumn shop_UserDefinedColumn);
		DataTable GetUserDefinedColumnList(string memloginid, string isshow);
		DataTable SearchUserDefinedColumnList(string ifshow, string showlocation);
		DataTable GetUserDefinedColumn(string guid);
		int UpdateUserDefinedColumn(ShopNum1_Shop_UserDefinedColumn shop_UserDefinedColumn);
		int DeleteUserDefinedColumn(string guid);
		DataTable MetaGetUserDefinedColumn(string memloginid, string linkaddress);
		DataTable GetButtomNavigation(string showCount);
		DataTable SelectNavigation_List(CommonPageModel commonModel);
	}
}
