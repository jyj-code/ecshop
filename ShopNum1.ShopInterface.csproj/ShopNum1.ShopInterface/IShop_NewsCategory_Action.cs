using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_NewsCategory_Action
	{
		int AddNewsCategory(ShopNum1_Shop_NewsCategory newsCategory);
		DataTable GetNewsCategoryList(string memloginid, string isshow);
		DataTable GetNewsCategory(string guid);
		int UpdateNewsCategory(ShopNum1_Shop_NewsCategory newsCategory);
		int DeleteNewsCategory(string guid);
	}
}
