using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_RefundBillInfo_Action
	{
		DataTable Search(string OrderNumber, string ModifyUser, string PaymentGuid, string CollectionPeople, decimal PayPrice1, decimal PayPrice2, string CreateTime1, string CreateTime2);
		DataTable SearchByGuid(string strGuid);
		DataTable SearchRefundBillByGuid(string strguids);
		int Delete(string strGuids);
	}
}
