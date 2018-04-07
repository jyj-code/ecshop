using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Brand_Action
	{
		int Add(ShopNum1_Brand brand);
		int Update(string guid, ShopNum1_Brand brand);
		int Delete(string guids);
		DataTable GetEditInfo(string guid);
		DataTable Search(int isDeleted);
		DataTable GetBrandMeto(string guid);
		DataTable SearchBrand(string pagesize);
		DataTable GetProductBrand(string code);
		DataTable GetProductBrandBycount(string code, string ShowCountTwo);
		DataTable GetProductCategoryCode(string fatherID);
		DataTable GetBrandCategory(string showCount);
		DataTable GetBrandImgByCode(string showCount, string code);
		DataTable SearchProductByBrandGuid(string brandGuid, string field, string order);
		DataTable CheckBrand(string strBrand);
		DataTable Select_Brand_Import(string strTypeId);
	}
}
