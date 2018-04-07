using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_CategoryType_Action
	{
		DataTable SelectCategoryType_List(int pagesize, int currentpage, string strcondition, int resultnum);
		int Add_CategoryType(ShopNum1_CategoryType shopNum1_CategoryType);
		int Update_CategoryType(ShopNum1_CategoryType shopNum1_CategoryType);
		ShopNum1_CategoryType Select_CategoryType(string strID);
		int Get_TypeMaxId();
		int update_CategoryType_Order(string strorderid, string strId);
		int DeleteBatch_CategoryType(string strId);
		DataTable Select_ProductCategoryType();
		int Add_CategoryTypeInto(ShopNum1_CategoryType shopNum1_CategoryType);
		string Get_SpValue(string strId);
	}
}
