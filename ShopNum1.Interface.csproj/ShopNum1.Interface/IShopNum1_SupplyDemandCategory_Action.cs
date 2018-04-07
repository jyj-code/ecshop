using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SupplyDemandCategory_Action
	{
		int Add(ShopNum1_SupplyDemandCategory shopNum1_SupplyDemandCategory);
		DataTable SearchtSupplyDemandCategory(int fatherID, int isDeleted);
		DataTable GetSupplyCategoryByID(string ID);
		int Update(string guid, ShopNum1_SupplyDemandCategory shopNum1_SupplyDemandCategory);
	}
}
