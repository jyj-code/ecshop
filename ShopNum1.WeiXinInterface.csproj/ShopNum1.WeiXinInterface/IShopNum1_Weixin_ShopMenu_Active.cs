using ShopNum1.WeiXinCommon.model;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.WeiXinInterface
{
	public interface IShopNum1_Weixin_ShopMenu_Active
	{
		bool Add_Menu(List<MenuButton> menulist, string shopmemloginid);
		DataTable Select_MenuByPid(string shopmemloginid, int int_0);
		DataTable Select_AllMenu(string shopmemloginid);
		string Add_menu(string menu_name, string menu_pid, string shopmemloginid);
		bool Edit_menu(string menu_name, string string_0);
		bool Del_menu(string string_0);
		DataTable Get_menubyid(string shopmemloginid, string string_0);
		DataTable Get_menubypid(string shopmemloginid, string string_0);
		bool UpdateView(string string_0, string string_1);
		DataTable GetAllMenu(string shopmemloginid);
	}
}
