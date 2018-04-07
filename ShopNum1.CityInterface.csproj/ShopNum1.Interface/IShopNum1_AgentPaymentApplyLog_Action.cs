using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_AgentPaymentApplyLog_Action
	{
		int Add(ShopNum1_AgentPaymentApplyLog AgentPaymentApplyLog);
		int Updata(ShopNum1_AgentPaymentApplyLog AgentPaymentApplyLog);
		int Delete(string string_0);
		DataTable Search();
	}
}
