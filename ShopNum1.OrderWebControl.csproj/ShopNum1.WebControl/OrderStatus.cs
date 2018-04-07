using System;
using System.Web.UI;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class OrderStatus
	{
		public static string ChangeOrderStatus(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "等待买家付款";
			}
			else if (a == "1")
			{
				result = "等待卖家发货";
			}
			else if (a == "2")
			{
				result = "等待买家确认收货";
			}
			else if (a == "3")
			{
				result = "交易成功";
			}
			else if (a == "4")
			{
				result = "系统关闭订单";
			}
			else if (a == "5")
			{
				result = "卖家关闭订单";
			}
			else if (a == "6")
			{
				result = "买家关闭订单";
			}
			else
			{
				result = "非法状态";
			}
			return result;
		}
	}
}
