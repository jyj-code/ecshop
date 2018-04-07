using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Menu_Action
	{
		int Add(ShopNum1_Menu shopnum1_menu);
		DataTable GetMenuInfo();
		int Update(string guid, ShopNum1_Menu shopnum1_menu);
		DataTable Search(string name, int state, string typecode);
		int Delete(string guids);
		DataTable GetEditInfo(string guid);
		DataTable Search(string guid);
	}
}
