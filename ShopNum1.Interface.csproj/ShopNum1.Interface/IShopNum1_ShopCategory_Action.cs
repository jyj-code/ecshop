using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopCategory_Action
	{
		int Add(ShopNum1_ShopCategory shopNum1_ShopCategory);
		int Delete(string guids);
		int Update(string guid, ShopNum1_ShopCategory shopNum1_ShopCategory);
		DataTable SearchShopCategory(int fatherID, int isDeleted);
		DataTable GetShopCategoryByID(string ID);
		DataTable GetShopCategoryName();
		DataTable GetList(string categoryID);
		DataTable GetShopCategoryMeto(string string_0);
		DataTable GetShopCategoryCount(string showcount);
		DataTable Search(int fatherID, int isDeleted, string showCount);
	}
}
