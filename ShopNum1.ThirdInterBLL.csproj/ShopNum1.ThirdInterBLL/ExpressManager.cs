using ShopNum1.ThirdInterDAL;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
namespace ShopNum1.ThirdInterBLL
{
	public class ExpressManager
	{
		protected ExpressService EsService
		{
			get
			{
				return new ExpressService();
			}
		}
		public ShopNum1_Shipper GetShiperByShopID(string ShopID)
		{
			return this.EsService.GetShiperByShopID(ShopID);
		}
		public ShopNum1_OrderExpressInfo GetExpressInfoByLogiticCode(string LogiticCode)
		{
			return this.EsService.GetExpressInfoByLogiticCode(LogiticCode);
		}
		public List<ShopNum1_OrderProduct> GeOrderProductsByOrderNumber(string OrderNumber)
		{
			return this.EsService.GeOrderProductsByOrderNumber(OrderNumber);
		}
	}
}
