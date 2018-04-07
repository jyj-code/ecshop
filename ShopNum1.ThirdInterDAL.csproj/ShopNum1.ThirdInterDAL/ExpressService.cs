using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace ShopNum1.ThirdInterDAL
{
	public class ExpressService
	{
		private IShopNum1_Region_Action ishopNum1_Region_Action_0 = new ShopNum1_Region_Action();
		private IShopNum1_Shipper_Action ShipperAction
		{
			get
			{
				return new ShopNum1_Shipper_Action();
			}
		}
		private IShopNum1_OrderExpress_Action ExpressAction
		{
			get
			{
				return new ShopNum1_OrderExpress_Action();
			}
		}
		public ShopNum1_Shipper GetShiperByShopID(string ShopID)
		{
			ShopNum1_Shipper shopNum1_Shipper = new ShopNum1_Shipper();
			try
			{
				DataTable dataTable = this.ShipperAction.Search(" And Isdefault=1 And ShopID=(Select ShopID FROM ShopNum1_ShopInfo where MemLoginID='" + ShopID + "')");
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					shopNum1_Shipper = EvalData<ShopNum1_Shipper>.GetData(dataTable).First<ShopNum1_Shipper>();
				}
				shopNum1_Shipper.Address = this.ishopNum1_Region_Action_0.GetAreaByRegionCode(shopNum1_Shipper.RegionCode) + shopNum1_Shipper.Address;
			}
			catch (Exception)
			{
			}
			return shopNum1_Shipper;
		}
		public ShopNum1_OrderExpressInfo GetExpressInfoByLogiticCode(string LogiticCode)
		{
			ShopNum1_OrderExpressInfo result = new ShopNum1_OrderExpressInfo();
			try
			{
				DataTable dataTable = this.ExpressAction.SearchByLogisticsID(LogiticCode);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					result = EvalData<ShopNum1_OrderExpressInfo>.GetData(dataTable).First<ShopNum1_OrderExpressInfo>();
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
		public List<ShopNum1_OrderProduct> GeOrderProductsByOrderNumber(string OrderNumber)
		{
			return null;
		}
	}
}
