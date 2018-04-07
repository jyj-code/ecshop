using ShopNum1.Interface;
using System;
using System.Configuration;
using System.Reflection;
namespace ShopNum1.CityFactory
{
	public sealed class LogicFactory
	{
		private static readonly string string_0 = ConfigurationManager.AppSettings["BusinessLogic"];
		public static IShopNum1_SubstationManage_Action CreateShopNum1_SubstationManage_Action()
		{
			string typeName = LogicFactory.string_0 + ".ShopNum1_SubstationManage_Action";
			return (IShopNum1_SubstationManage_Action)Assembly.Load("ShopNum1.CityBusinessLogic").CreateInstance(typeName);
		}
		public static IShopNum1_SubstationReport_Action CreateShopNum1_SubstationReport_Action()
		{
			string typeName = LogicFactory.string_0 + ".ShopNum1_SubstationReport_Action";
			return (IShopNum1_SubstationReport_Action)Assembly.Load("ShopNum1.CityBusinessLogic").CreateInstance(typeName);
		}
		public static IShopNum1_City_AdvancePaymentModifyLog_Action CreateShopNum1_City_AdvancePaymentModifyLog_Action()
		{
			string typeName = LogicFactory.string_0 + ".ShopNum1_City_AdvancePaymentModifyLog_Action";
			return (IShopNum1_City_AdvancePaymentModifyLog_Action)Assembly.Load("ShopNum1.CityBusinessLogic").CreateInstance(typeName);
		}
		public static IShopNum1_AdvertPay_Action CreateShopNum1_AdvertPay_Action()
		{
			string typeName = LogicFactory.string_0 + ".ShopNum1_AdvertPay_Action";
			return (IShopNum1_AdvertPay_Action)Assembly.Load("ShopNum1.CityBusinessLogic").CreateInstance(typeName);
		}
		public static IShopNum1_AgentPaymentApplyLog_Action CreateShopNum1_AgentPaymentApplyLog_Action()
		{
			string typeName = LogicFactory.string_0 + ".ShopNum1_AgentPaymentApplyLog_Action";
			return (IShopNum1_AgentPaymentApplyLog_Action)Assembly.Load("ShopNum1.CityBusinessLogic").CreateInstance(typeName);
		}
	}
}
