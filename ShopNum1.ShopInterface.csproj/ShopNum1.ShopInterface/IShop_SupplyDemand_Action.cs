using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_SupplyDemand_Action
	{
		DataTable Search(string commerceMemLoginID, string IsAudit);
		DataRow UpdateSearch(string guid);
		int Delete(string guid);
		string GetAddressCode(string commerceMemLoginID);
		string GetAddressValue(string addressCode);
		int SupplyDemandCommentAdd(ShopNum1_SupplyDemandComment supplyDemandComment);
		DataTable SupplyDemandCommentList(string guid);
		DataTable SupplyDemandDetail(string guid);
		DataTable GetSupplyDemandMeto(string guid);
	}
}
