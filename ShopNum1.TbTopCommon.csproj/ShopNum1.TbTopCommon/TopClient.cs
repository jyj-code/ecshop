using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Xml;
namespace ShopNum1.TbTopCommon
{
	public static class TopClient
	{
		public static bool isAdminSessionTrue = false;
		public static bool isAgentSessionTrue = false;
		public static string UserNick
		{
			get
			{
				string result;
				try
				{
					if (HttpContext.Current.Request.Cookies[TopConfig.CookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["top_session"] != null)
					{
						result = HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["visitor_nick"].ToString());
					}
					else
					{
						result = "";
					}
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
			}
		}
		public static string AdminUserNick
		{
			get
			{
				string result;
				try
				{
					if (HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["top_session"] != null)
					{
						result = HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["visitor_nick"].ToString());
					}
					else
					{
						result = "";
					}
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
			}
		}
		public static string AgentUserNick
		{
			get
			{
				string result;
				try
				{
					if (HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["top_session"] != null)
					{
						result = HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"].ToString());
					}
					else
					{
						result = "";
					}
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
			}
		}
		public static string Session
		{
			get
			{
				string result;
				try
				{
					if (HttpContext.Current.Request.Cookies[TopConfig.CookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["top_session"] != null)
					{
						result = HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["top_session"].ToString();
					}
					else
					{
						result = "";
					}
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
			}
		}
		public static string AdminSession
		{
			get
			{
				string result;
				try
				{
					if (HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["top_session"] != null)
					{
						result = HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["top_session"].ToString();
					}
					else
					{
						result = "";
					}
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
			}
		}
		public static string AgentSession
		{
			get
			{
				string result;
				try
				{
					if (HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["top_session"] != null)
					{
						result = HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["top_session"].ToString();
					}
					else
					{
						result = "";
					}
				}
				catch (Exception)
				{
					result = "";
				}
				return result;
			}
		}
		public static bool IsLogin
		{
			get
			{
				return HttpContext.Current.Request.Cookies[TopConfig.CookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.CookiesName]["top_session"] != null;
			}
		}
		public static bool IsAdminLogin
		{
			get
			{
				return HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.AdminCookiesName]["top_session"] != null;
			}
		}
		public static bool IsAgentLogin
		{
			get
			{
				return HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName] != null && HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["top_session"] != null;
			}
		}
		public static void SetCookies(string nick, string sessionkey)
		{
			HttpContext.Current.Response.Cookies[TopConfig.CookiesName]["visitor_nick"] = HttpUtility.UrlEncode(nick);
			HttpContext.Current.Response.Cookies[TopConfig.CookiesName]["top_session"] = sessionkey;
		}
		public static void SetAdminCookies(string nick, string sessionkey)
		{
			HttpContext.Current.Response.Cookies[TopConfig.AdminCookiesName]["visitor_nick"] = HttpUtility.UrlEncode(nick);
			HttpContext.Current.Response.Cookies[TopConfig.AdminCookiesName]["top_session"] = sessionkey;
		}
		public static void SetAgentCookies(string nick, string sessionkey)
		{
			HttpContext.Current.Response.Cookies[TopConfig.AgentCookiesName]["visitor_nick"] = HttpUtility.UrlEncode(nick);
			HttpContext.Current.Response.Cookies[TopConfig.AgentCookiesName]["top_session"] = sessionkey;
		}
		public static bool isSessionTimeOut(Page page, string user)
		{
			bool result;
			if (user == "admin")
			{
				if (TopClient.IsAdminLogin)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add("fields", "oid");
					dictionary.Add("rate_type", "get");
					dictionary.Add("role", "seller");
					dictionary.Add("page_no", "1");
					dictionary.Add("page_size", "1");
					string xml = TopAPI.Post("taobao.traderates.get", TopClient.AdminSession, dictionary);
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(xml);
					ErrorRsp errorRsp_ = new ErrorRsp();
					Parser parser = new Parser();
					if (parser.IsXmlError2(xmlDocument, errorRsp_))
					{
						TopClient.isAdminSessionTrue = false;
						result = false;
					}
					else
					{
						TopClient.isAdminSessionTrue = true;
						result = true;
					}
				}
				else
				{
					TopClient.isAdminSessionTrue = false;
					result = false;
				}
			}
			else if (TopClient.IsAgentLogin)
			{
				TopClient.isAgentSessionTrue = true;
				result = true;
			}
			else
			{
				TopClient.isAgentSessionTrue = false;
				result = false;
			}
			return result;
		}
		public static int Logout()
		{
			HttpContext.Current.Response.Cookies.Remove(TopConfig.CookiesName);
			HttpContext.Current.Response.Cookies.Remove(TopConfig.AdminCookiesName);
			HttpContext.Current.Response.Cookies.Remove(TopConfig.AgentCookiesName);
			return 1;
		}
		public static int AdminLogout()
		{
			HttpCookie httpCookie = new HttpCookie(TopConfig.AdminCookiesName, "");
			httpCookie.Expires = DateTime.Now.AddDays(-1.0);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
			return 1;
		}
		public static int AgentLogout()
		{
			HttpCookie httpCookie = new HttpCookie(TopConfig.AgentCookiesName, "");
			httpCookie.Expires = DateTime.Now.AddDays(-1.0);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
			return 1;
		}
	}
}
