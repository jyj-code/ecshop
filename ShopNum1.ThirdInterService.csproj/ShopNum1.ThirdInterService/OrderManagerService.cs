using ShopNum1.Common;
using ShopNum1.ThirdInterBLL;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.Services;
namespace ShopNum1.ThirdInterService
{
	[ToolboxItem(false), WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class OrderManagerService : WebService
	{
		private OrderManager orderMdr
		{
			get
			{
				return new OrderManager();
			}
		}
		private MemberManager memberMdr
		{
			get
			{
				return new MemberManager();
			}
		}
		private ZtcManager ztcMdr
		{
			get
			{
				return new ZtcManager();
			}
		}
		[WebMethod(Description = "检查用户")]
		public int CheckMember(string memLoginId, string password)
		{
			return this.memberMdr.CheckMember(memLoginId, password);
		}
		[WebMethod(Description = "返回订单信息")]
		public DataTable GetOrders(string shopid, string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, string oderStatus, decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted, int pagesize, int currentpage, string sign)
		{
			return this.orderMdr.GetOrders(shopid, orderNumber, memLoginID, name, address, postalcode, string_0, mobile, email, oderStatus, shouldPayPrice1, shouldPayPrice2, createTime1, createTime2, isDeleted, pagesize, currentpage, sign);
		}
		[WebMethod(Description = "返回用户指定时间段的订单信息")]
		public DataTable GetNewOrders(string shopid, string fisttime, string lasttime, string sign)
		{
			return this.orderMdr.GetNewOrders(shopid, fisttime, lasttime, sign);
		}
		[WebMethod(Description = "返回用户指定时间段的订单总量")]
		public int GetCountOrders(string shopid, string fisttime, string lasttime, string sign, string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, string oderStatus, decimal shouldPayPrice1, decimal shouldPayPrice2, int isDeleted)
		{
			return this.orderMdr.GetCountOrders(shopid, fisttime, lasttime, sign, orderNumber, memLoginID, name, address, postalcode, string_0, mobile, email, oderStatus, shouldPayPrice1, shouldPayPrice2, isDeleted);
		}
		[WebMethod(Description = "取消订单")]
		public bool CancelOrders()
		{
			return this.orderMdr.CancelOrders();
		}
		[WebMethod(Description = "获取服务器时间")]
		public DateTime GetServierTime()
		{
			return DateTime.Now;
		}
		[WebMethod(Description = "获取订单详细")]
		public DataTable GetOrdersDetail(string guid)
		{
			return this.orderMdr.GetOrderDetail(guid);
		}
		[WebMethod(Description = "直通车扣款")]
		public bool TimeNessMoney()
		{
			return this.ztcMdr.TimeNessMoney();
		}
		[WebMethod(Description = "根据订单编号获取订单信息")]
		public ShopNum1_OrderInfo GetOrderInfoByOrderNumber(string orderNumber, string sign)
		{
			ShopNum1_OrderInfo result;
			if (Encryption.GetMd5Hash("GetOrderInfoByOrderNumber") == sign)
			{
				result = this.orderMdr.GetOrderInfoByOrderNumber(orderNumber);
			}
			else
			{
				result = null;
			}
			return result;
		}
		[WebMethod(Description = "根据店铺ID获取需要打印的快递单的订单编号")]
		public List<string> GetPrintOrderNumbersByShopID(string ShopId, string sign)
		{
			List<string> result;
			if (Encryption.GetMd5Hash("GetPrintOrderNumbersByShopID") == sign)
			{
				result = this.orderMdr.GetPrintOrderNumbersByShopID(ShopId);
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
