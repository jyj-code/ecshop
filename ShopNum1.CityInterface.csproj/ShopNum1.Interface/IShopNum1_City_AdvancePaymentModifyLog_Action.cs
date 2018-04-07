using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_City_AdvancePaymentModifyLog_Action
	{
		int Add(ShopNum1_City_AdvancePaymentModifyLog City_AdvancePaymentModifyLog);
		int Updata(ShopNum1_City_AdvancePaymentModifyLog City_AdvancePaymentModifyLog);
		int Delete(string string_0);
		DataTable Search();
	}
}
