using com.unionpay.upop.sdk;
using ShopNum1.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace ShopNum1.Payment
{
	public class Upop
	{
		public bool GoToUpopUrl(string strProductName, string strOrderId, string strPrice, string frontEndUrl, string backEndUrl, out string string_0, out Encoding charset)
		{
			bool result;
			try
			{
				UPOPSrv.LoadConf(HttpContext.Current.Server.MapPath("~/WebConfig/conf.xml.config").Replace("Main", ""));
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				Random random = new Random();
                //DateTime.Now.ToString("yyyyMMddHHmmss") + (random.Next(900) + 100).ToString().Trim();
				string str = string.Empty;
				if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
				{
					HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					str = httpCookie.Values["MemLoginID"].ToString();
				}
				dictionary["transType"] = "01";
				dictionary["commodityUrl"] = "http://emall.chinapay.com/product?name=jelybuy";
				dictionary["commodityName"] = "商品支付";
				dictionary["commodityUnitPrice"] = "11000";
				dictionary["commodityQuantity"] = "1";
				dictionary["orderNumber"] = strOrderId;
				dictionary["orderAmount"] = strPrice;
				dictionary["orderCurrency"] = "156";
				dictionary["orderTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");
				dictionary["customerIp"] = "172.17.136.34";
				if (frontEndUrl.IndexOf("A_Index.aspx") != -1)
				{
					frontEndUrl = frontEndUrl.Replace("/PayReturn/unionpay/unionpay_receive.aspx", "");
				}
				dictionary["frontEndUrl"] = frontEndUrl + "?site=1&sendmoney=" + str;
				dictionary["backEndUrl"] = backEndUrl + "?site=2&sendmoney=" + str;
				FrontPaySrv frontPaySrv = new FrontPaySrv(dictionary);
				charset = frontPaySrv.Charset;
				string_0 = frontPaySrv.CreateHtml();
				result = true;
			}
			catch
			{
				string_0 = "";
				charset = Encoding.ASCII;
				result = false;
			}
			return result;
		}
		public bool GoToUpopUrl(string strshopId, string strProductName, string strOrderId, string strPrice, string frontEndUrl, string backEndUrl, out string string_0, out Encoding charset)
		{
			bool result;
			try
			{
				UPOPSrv.LoadConf(HttpContext.Current.Server.MapPath("./App_Data/conf.xml.config").Replace("Main", ""));
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				Random random = new Random();
                //DateTime.Now.ToString("yyyyMMddHHmmss") + (random.Next(900) + 100).ToString().Trim();
				dictionary["transType"] = "01";
				dictionary["commodityUrl"] = "http://emall.chinapay.com/product?name=商品";
				dictionary["commodityName"] = "商品支付";
				dictionary["commodityUnitPrice"] = "11000";
				dictionary["commodityQuantity"] = "1";
				dictionary["orderNumber"] = strOrderId;
				dictionary["orderAmount"] = strPrice;
				dictionary["orderCurrency"] = "156";
				dictionary["orderTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");
				dictionary["customerIp"] = "172.17.136.34";
				dictionary["frontEndUrl"] = frontEndUrl + "?sendmoney=" + strshopId;
				dictionary["backEndUrl"] = backEndUrl + "?sendmoney=" + strshopId;
				FrontPaySrv frontPaySrv = new FrontPaySrv(dictionary);
				charset = frontPaySrv.Charset;
				string_0 = frontPaySrv.CreateHtml();
				result = true;
			}
			catch
			{
				string_0 = "";
				charset = Encoding.ASCII;
				result = false;
			}
			return result;
		}
	}
}
