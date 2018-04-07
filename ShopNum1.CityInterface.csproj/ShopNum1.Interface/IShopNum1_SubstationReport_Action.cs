using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SubstationReport_Action
	{
		DataTable GetSubstationAdSell(string StarDate, string EndDate);
		DataTable GetOneSubstationAdSellMsg(string SubstationID, string StarDate, string EndDate);
		DataTable GetMemLoginIDSellMsg(string StarDate, string EndDate);
		DataTable GetAll(string SubstationID, string AdId, string IsCancel, string IsExamine);
	}
}
