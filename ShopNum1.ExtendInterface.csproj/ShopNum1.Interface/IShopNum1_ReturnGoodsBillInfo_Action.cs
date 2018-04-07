using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ReturnGoodsBillInfo_Action
	{
		DataTable Search(string OrderNumber, string ReturnGoodsPeople, string Address, string Postalcode, string Mobile, string Name, string Tel, decimal ShouldPayPrice1, decimal ShouldPayPrice2, string CreateTime1, string CreateTime2);
		DataTable SearchByGuid(string strGuid);
		int Delete(string strGuids);
		DataTable SearchReturnGoodsBillByGuid(string strguids);
	}
}
