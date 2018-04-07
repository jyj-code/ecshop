using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
namespace ShopNum1.ThirdInterDAL
{
	public class ZtcService
	{
		private ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action_0 = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
		public bool TimeNessMoney()
		{
			bool result = false;
			try
			{
				decimal money = Convert.ToDecimal(ShopSettings.GetValue("ZtcMoney"));
				result = (this.shopNum1_ZtcGoods_Action_0.TimeNessMoney(money) > 0);
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
