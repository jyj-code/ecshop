using ShopNum1.Common;
using ShopNum1.ThirdInterBLL;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
namespace ShopNum1.ThirdInterService
{
	[ToolboxItem(false), WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class ExpressService : WebService
	{
		protected ExpressManager exMdr
		{
			get
			{
				return new ExpressManager();
			}
		}
		[WebMethod(Description = "获取店铺默认发件人信息")]
		public ShopNum1_Shipper GetShiperByShopID(string ShopID, string sign)
		{
			ShopNum1_Shipper result;
			if (Encryption.GetMd5Hash("GetShiperByShopID") == sign)
			{
				result = this.exMdr.GetShiperByShopID(ShopID);
			}
			else
			{
				result = null;
			}
			return result;
		}
		[WebMethod(Description = "根据物流编号获取物流单模板信息")]
		public ShopNum1_OrderExpressInfo GetExpressInfoByLogiticCode(string LogiticCode, string sign)
		{
			ShopNum1_OrderExpressInfo result;
			if (Encryption.GetMd5Hash("GetExpressInfoByLogiticCode") == sign)
			{
				result = this.exMdr.GetExpressInfoByLogiticCode(LogiticCode);
			}
			else
			{
				result = null;
			}
			return result;
		}
		[WebMethod(Description = "根据订单编号获取商品信息")]
		public List<ShopNum1_OrderProduct> GeOrderProductsByOrderNumber(string OrderNumber, string sign)
		{
			List<ShopNum1_OrderProduct> result;
			if (Encryption.GetMd5Hash("GeOrderProductsByOrderNumber") == sign)
			{
				result = this.exMdr.GeOrderProductsByOrderNumber(OrderNumber);
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
