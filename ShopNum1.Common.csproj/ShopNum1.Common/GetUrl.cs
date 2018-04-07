using System;
using System.Collections;
using System.Configuration;
using System.Web;
namespace ShopNum1.Common
{
	public class GetUrl
	{
		public static string GetNewHost()
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["UserUrl"];
			string text = HttpContext.Current.Request.Url.Host.ToLower();
			string text2 = ConfigurationManager.AppSettings["Domain"].ToLower();
			string key;
			if (text.IndexOf(text2.Replace("/", "")) != -1)
			{
				key = text.Split(new char[]
				{
					'.'
				})[0];
			}
			else
			{
				key = hashtable[text].ToString();
			}
			return hashtable[key].ToString() + text2;
		}
		public static string GetLoginUrl(string pagename, string memloginid)
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["UserUrl"];
			string str = ConfigurationManager.AppSettings["Domain"].ToLower();
			string str2 = hashtable[memloginid].ToString() + str;
			return "http://" + str2 + pagename + ".html";
		}
		public static void RedirectTopLogin(string Message)
		{
			string text = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
			string text2 = string.Concat(new string[]
			{
				"<script>alert('{0}');top.location.href='http://",
				ShopSettings.siteDomain,
				"/Login",
				text,
				"';</script>"
			});
			text2 = string.Format(text2, Message);
			HttpContext.Current.Response.Write(text2);
			HttpContext.Current.Response.End();
		}
		public static void RedirectTopLogin()
		{
			string text = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
			string s = string.Concat(new string[]
			{
				"<script>top.location.href='http://",
				ShopSettings.siteDomain,
				"/Login",
				text,
				"';</script>"
			});
			HttpContext.Current.Response.Write(s);
			HttpContext.Current.Response.End();
		}
		public static void RedirectLogin()
		{
			string str = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
			HttpContext.Current.Response.Redirect("http://" + ShopSettings.siteDomain + "/Login" + str);
		}
		public static void RedirectLogin(string Message)
		{
			string text = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
			string text2 = string.Concat(new string[]
			{
				"<script>alert('{0}');location.href='http://",
				ShopSettings.siteDomain,
				"/Login",
				text,
				"';</script>"
			});
			text2 = string.Format(text2, Message);
			HttpContext.Current.Response.Write(text2);
			HttpContext.Current.Response.End();
		}
		public static void RedirectLoginGoBack()
		{
			string text = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
			string text2 = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
			if (text2.IndexOf("?goback=") == -1 && text2.IndexOf("/login") == -1)
			{
				HttpContext.Current.Response.Redirect(string.Concat(new string[]
				{
					"http://",
					ShopSettings.siteDomain,
					"/Login",
					text,
					"?goback=",
					HttpContext.Current.Server.UrlEncode(text2)
				}));
			}
			else
			{
				HttpContext.Current.Response.Redirect(text2);
			}
		}
		public static void RedirectLoginGoBack(string Message)
		{
			string text = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
			string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
			string text2 = string.Concat(new string[]
			{
				"<script>alert('{0}');location.href='http://",
				ShopSettings.siteDomain,
				"/Login",
				text,
				"?goback=",
				HttpContext.Current.Server.UrlEncode(s),
				"';</script>"
			});
			text2 = string.Format(text2, Message);
			HttpContext.Current.Response.Write(text2);
			HttpContext.Current.Response.End();
		}
		public static void RedirectShopLoginGoBack()
		{
			string text = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
			string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
			HttpContext.Current.Response.Redirect(string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/Login",
				text,
				"?goback=",
				HttpContext.Current.Server.UrlEncode(s)
			}));
		}
		public static void RedirectShopLoginGoBack(string Message)
		{
			string text = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
			string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
			string text2 = string.Concat(new string[]
			{
				"<script>alert('{0}');location.href='http://",
				ShopSettings.siteDomain,
				"/Login",
				text,
				"?goback=",
				HttpContext.Current.Server.UrlEncode(s),
				"';</script>"
			});
			text2 = string.Format(text2, Message);
			HttpContext.Current.Response.Write(text2);
			HttpContext.Current.Response.End();
		}
	}
}
