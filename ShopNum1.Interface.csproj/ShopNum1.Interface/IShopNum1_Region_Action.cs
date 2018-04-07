using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Region_Action
	{
		DataTable SearchByCategoryLevel(string lever, string showcount);
		int Add(ShopNum1_Region shopNum1_Region);
		DataTable SearchtRegionCategory(int fatherID, int isDeleted);
		DataTable GetRegionCategoryByID(string ID);
		int Update(string guid, ShopNum1_Region shopNum1_RegionCategory);
		string GetAreaByRegionCode(string Code);
	}
}
