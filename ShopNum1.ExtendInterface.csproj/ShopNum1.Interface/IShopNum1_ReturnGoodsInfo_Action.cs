using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ReturnGoodsInfo_Action
	{
		DataTable SearchReturnGoods(string MemLoginID, string DispatchModeName, string OrderNumber, int Status, string ReturnGoodsTime1, string ReturnGoodsTime2);
		DataTable SearchByGuid(string strGuid);
		int Delete(string strGuids);
	}
}
