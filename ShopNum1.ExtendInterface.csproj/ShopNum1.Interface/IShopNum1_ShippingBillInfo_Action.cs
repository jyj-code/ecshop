using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShippingBillInfo_Action
	{
		DataTable SearchShippingBillInfo(string strGuid);
		DataTable Search(string OrderNumber, string MemLoginID, string Address, string Postalcode, string Mobile, string DispatchMode, string Tel, string CollectionPeople, decimal ShouldPayPrice1, decimal ShouldPayPrice2, string CreateTime1, string CreateTime2);
		DataTable SearchByGuid(string strGuid);
		int Delete(string strGuids);
		DataTable SearchShippingBillInfoByGuid(string strguids);
	}
}
