using ShopNum1.ThirdInterDAL;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.ThirdInterBLL
{
	public class OrderManager
	{
		private OrderService orderservice
		{
			get
			{
				return new OrderService();
			}
		}
		public DataTable GetOrders(string shopid, string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, string oderStatus, decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted, int pagesize, int currentpage, string sign)
		{
			return this.orderservice.GetOrders(shopid, orderNumber, memLoginID, name, address, postalcode, string_0, mobile, email, oderStatus, shouldPayPrice1, shouldPayPrice2, createTime1, createTime2, isDeleted, pagesize, currentpage, sign);
		}
		public DataTable GetNewOrders(string shopid, string fisttime, string lasttime, string sign)
		{
			return this.orderservice.GetNewOrders(shopid, fisttime, lasttime, sign);
		}
		public int GetCountOrders(string shopid, string fisttime, string lasttime, string sign, string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, string oderStatus, decimal shouldPayPrice1, decimal shouldPayPrice2, int isDeleted)
		{
			return this.orderservice.GetCountOrders(shopid, fisttime, lasttime, sign, orderNumber, memLoginID, name, address, postalcode, string_0, mobile, email, oderStatus, shouldPayPrice1, shouldPayPrice2, isDeleted);
		}
		public bool CancelOrders()
		{
			return this.orderservice.CancelOrders();
		}
		public DataTable GetOrderDetail(string guid)
		{
			return this.orderservice.GetOrderDetail(guid);
		}
		public ShopNum1_OrderInfo GetOrderInfoByOrderNumber(string orderNumber)
		{
			return this.orderservice.GetOrderInfoByOrderNumber(orderNumber);
		}
		public List<string> GetPrintOrderNumbersByShopID(string shopid)
		{
			return this.orderservice.GetPrintOrderNumbersByShopID(shopid);
		}
	}
}
