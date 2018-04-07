using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_SupplyDemandCategory_Action
	{
		DataTable Search(string commerceMemLoginID, string IsAudit);
		int Delete(string guid);
		int Insert(ShopNum1_CategoryInfo shopNum1_CategoryInfo);
		int Update(ShopNum1_CategoryInfo shopNum1_CategoryInfo);
		DataRow UpdateSearch(string guid);
		string GetAddressCode(string commerceMemLoginID);
		string GetAddressValue(string addressCode);
	}
}
