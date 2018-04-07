using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ExtendOrderStatistics_Action : IShopNum1_ExtendOrderStatistics_Action
	{
		public int Add()
		{
			return 0;
		}
		public DataTable SearchDispatchModeStatistics()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select DispatchModeName,count(DispatchModeGuid) as DispatchModeCount,(select count(1) from ShopNum1_OrderInfo where PaymentStatus=2) as AllCount");
			stringBuilder.Append(" from ShopNum1_OrderInfo  where PaymentStatus=2 group by DispatchModeName order by DispatchModeCount desc");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchPaymentStatistics()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select PaymentName,count(PaymentGuid) as PaymentCount,(select count(1) from ShopNum1_OrderInfo ) as AllCount ");
			stringBuilder.Append(" from ShopNum1_OrderInfo   group by PaymentName order by PaymentCount desc");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchPaymentStatistics(string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select PaymentName,count(PaymentGuid) as PaymentCount,(select count(1) from ShopNum1_OrderInfo  where SubstationID='" + SubstationID + "' ) as AllCount ");
			stringBuilder.Append(" from ShopNum1_OrderInfo where SubstationID='" + SubstationID + "'   group by PaymentName order by PaymentCount desc");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
	}
}
