using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ProductCategory_Action
	{
		int Add(ShopNum1_ProductCategory shopNum1_ProductCategory);
		int DeleteTypeC(string strID);
		int Delete(string guids);
		int Update(string guid, ShopNum1_ProductCategory shopNum1_ProductCategory);
		DataTable SearchtProductCategory(int fatherID, int isDeleted);
		DataTable GetProductCategoryByID(string ID);
		DataTable GetProductCategoryName();
		DataTable GetProductCategoryName(string fatherID);
		DataTable Search(int fatherID, int isDeleted);
		DataTable GetCategory(string FatherID);
		DataTable GetCategoryBycount(string FatherID, string ShowCountOne);
		DataTable GetProductCategory(string fatherid, string showcount);
		DataTable GetProductCategoryCode(string code);
		DataTable GetProductCategoryCodeByName(string name);
		DataTable GetCategoryTypeByCategoryID(string categoryid);
		int UpdateCatrgoryInfoCategory(ShopNum1_Category shopNum1_Category);
		DataTable GetProductCategoryMeto(string code);
		DataTable Search(int fatherID, int isDeleted, string showCount);
		DataTable dt_GetScale(string strCode);
		int Update_Scale(string strCode, string strScale, string strIsOpen);
		string strVScale(string strProductGuId);
		DataTable SearchtTwoProductCategory(int fatherID, int isDeleted);
		DataTable GetTwoOverType(int fatherId, string strTopCount);
		int AddList(List<ShopNum1_ProductCategory> list_ProductCategory);
	}
}
