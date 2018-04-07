using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_ProductCategory_Action
	{
		DataTable GetCategoryProc(string FatherID, string idname, string idvalue);
		DataTable GetProductCategoryCodeProc(string code, string memloginid);
		DataTable GetCategory(string code, string codelen, string agentloginid);
		DataTable GetProductCategoryCode(string fatherID);
		DataTable GetShopProductCategoryCode(string fatherID, string memLoginID);
		DataTable GetShopMetaBycategory(string code);
		DataTable Search(int fatherID, string memLoginID);
		DataTable SearchShopType(int fatherID, string memLoginID);
		int Add(ShopNum1_Shop_ProductCategory shop_ProductCategory);
		int Update(ShopNum1_Shop_ProductCategory shop_ProductCateGory);
		DataTable GetShopAgentID(string memberLoginID);
		int GetMaxID(string MemloginId);
		int Update1(string guid, ShopNum1_Shop_ProductCategory agent_ProductCateGory);
		DataTable Search_Import(string FatherID, string MemloginId);
		DataTable SetCategoryCode(string code, string strMemloginId);
	}
}
