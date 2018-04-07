using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopPayment_Action
	{
		DataTable Search(int isDeleted, string memloginid);
		DataTable Search(string memloginid);
		int Add(ShopNum1_ShopPayment payment);
		int Delete(string guids);
		DataTable SearchPayInfo(string guid, int delete);
		int Update(ShopNum1_ShopPayment payment, string guid, int isDeleted);
		string GetPaymentType(string guid);
		DataTable GetPaymentInfoByGuid(string guid);
		DataTable GetPaymentKey(string paymentType, string agentLoginID);
		DataTable GetPaymentInfoByGuid(string guid, string memloginid);
	}
}
