using System;
using System.Configuration;
using System.Web;
namespace ShopNum1.TbTopCommon
{
	public static class TopConfig
	{
		private static string string_0 = string.Empty;
		private static string string_1 = "test";
		private static string string_2 = "test";
		private static string string_3 = "test";
		private static string string_4 = "test";
		private static string string_5 = "test";
		private static string string_6 = "test";
		private static bool bool_0 = false;
		private static string string_7 = string.Empty;
		private static string string_8 = TopConfig.SendBox ? "http://container.api.tbsandbox.com/container?appkey={0}" : "http://container.open.taobao.com/container?appkey={0}";
		private static string string_9 = TopConfig.SendBox ? "http://container.api.tbsandbox.com/container?authcode={0}" : "http://container.open.taobao.com/container?authcode={0}";
		private static string string_10 = "ShopNum1TbApp{0}";
		private static string string_11 = "ShopNum1AgentTbApp{0}";
		private static string string_12 = "ShopNum1AdminTbApp{0}";
		public static string Domain
		{
			get
			{
				string result;
				if (ConfigurationManager.AppSettings["Domain"] != null)
				{
					TopConfig.string_0 = ConfigurationManager.AppSettings["Domain"];
					result = TopConfig.string_0;
				}
				else
				{
					result = TopConfig.string_0;
				}
				return result;
			}
			set
			{
				TopConfig.string_0 = value;
			}
		}
		public static string AppKey
		{
			get
			{
				if (HttpContext.Current.Session["Appkey"] != null)
				{
					TopConfig.string_1 = HttpContext.Current.Session["Appkey"].ToString();
				}
				return TopConfig.string_1;
			}
			set
			{
				HttpContext.Current.Session["Appkey"] = value;
				HttpContext.Current.Session.Timeout = 20;
			}
		}
		public static string AppSecret
		{
			get
			{
				if (HttpContext.Current.Session["AppSecret"] != null)
				{
					TopConfig.string_2 = HttpContext.Current.Session["AppSecret"].ToString();
				}
				return TopConfig.string_2;
			}
			set
			{
				HttpContext.Current.Session["AppSecret"] = value;
				HttpContext.Current.Session.Timeout = 20;
			}
		}
		public static string AdminAppkey
		{
			get
			{
				string result;
				if (TopConfig.string_3 != "test")
				{
					result = TopConfig.string_3;
				}
				else if (ConfigurationManager.AppSettings["AdminAppKey"] != null)
				{
					TopConfig.string_3 = ConfigurationManager.AppSettings["AdminAppKey"];
					result = TopConfig.string_3;
				}
				else
				{
					result = TopConfig.string_3;
				}
				return result;
			}
			set
			{
				TopConfig.string_3 = value;
			}
		}
		public static string AdminSecret
		{
			get
			{
				string result;
				if (TopConfig.string_4 != "test")
				{
					result = TopConfig.string_4;
				}
				else if (ConfigurationManager.AppSettings["AdminAppSecret"] != null)
				{
					TopConfig.string_4 = ConfigurationManager.AppSettings["AdminAppSecret"];
					result = TopConfig.string_4;
				}
				else
				{
					result = TopConfig.string_4;
				}
				return result;
			}
			set
			{
				TopConfig.string_4 = value;
			}
		}
		public static string AgentAppkey
		{
			get
			{
				string result;
				if (TopConfig.string_5 != "test")
				{
					result = TopConfig.string_5;
				}
				else if (ConfigurationManager.AppSettings["AgentAppKey"] != null)
				{
					TopConfig.string_5 = ConfigurationManager.AppSettings["AgentAppKey"];
					result = TopConfig.string_5;
				}
				else if (TopConfig.string_5 != null)
				{
					result = TopConfig.string_5;
				}
				else
				{
					result = TopConfig.string_5;
				}
				return result;
			}
			set
			{
				TopConfig.string_5 = value;
			}
		}
		public static string AgentSecret
		{
			get
			{
				string result;
				if (TopConfig.string_6 != "test")
				{
					result = TopConfig.string_6;
				}
				else if (ConfigurationManager.AppSettings["AgentAppSecret"] != null)
				{
					TopConfig.string_6 = ConfigurationManager.AppSettings["AgentAppSecret"];
					result = TopConfig.string_6;
				}
				else
				{
					result = TopConfig.string_6;
				}
				return result;
			}
			set
			{
				TopConfig.string_6 = value;
			}
		}
		public static bool SendBox
		{
			get
			{
				if (ConfigurationManager.AppSettings["SandBox"] != null)
				{
					if (ConfigurationManager.AppSettings["SandBox"].ToString() == "1")
					{
						TopConfig.bool_0 = true;
					}
					else
					{
						TopConfig.bool_0 = false;
					}
				}
				return TopConfig.bool_0;
			}
			set
			{
				TopConfig.bool_0 = value;
			}
		}
		public static string ServerURL
		{
			get
			{
				string result = string.Empty;
				if (ConfigurationManager.AppSettings["IsSandBox"] == "1")
				{
					result = ConfigurationManager.AppSettings["TopServerSandUrl"];
				}
				else
				{
					result = ConfigurationManager.AppSettings["TopServerUrl"];
				}
				return result;
			}
		}
		public static string AgentContainerURL
		{
			get
			{
				return TopConfig.getUrl(TopConfig.AgentAppkey);
			}
		}
		public static string AdminContainerURL
		{
			get
			{
				return TopConfig.getUrl(TopConfig.AdminAppkey);
			}
		}
		public static string ShopContainerURL
		{
			get
			{
				return TopConfig.getUrl(TopConfig.AppKey);
			}
		}
		public static string ContainerAuthCodeURL
		{
			get
			{
				string str = string.Empty;
				if (ConfigurationManager.AppSettings["IsSandBox"] == "1")
				{
					str = ConfigurationManager.AppSettings["SandContainerAuthCodeURL"];
				}
				else
				{
					str = ConfigurationManager.AppSettings["ContainerAuthCodeURL"];
				}
				return str + "?authcode={0}";
			}
		}
		public static string CookiesName
		{
			get
			{
				string result;
				if (ConfigurationManager.AppSettings["CookieName"] != null)
				{
					result = string.Format(ConfigurationManager.AppSettings["CookieName"].ToString(), TopConfig.AgentAppkey + TopConfig.AdminAppkey);
				}
				else
				{
					result = string.Format(TopConfig.string_10, TopConfig.AgentAppkey + TopConfig.AdminAppkey);
				}
				return result;
			}
			set
			{
				TopConfig.string_10 = value;
			}
		}
		public static string AgentCookiesName
		{
			get
			{
				string result;
				if (ConfigurationManager.AppSettings["AgentCookiesName"] != null)
				{
					result = string.Format(ConfigurationManager.AppSettings["AgentCookiesName"].ToString(), TopConfig.AgentAppkey);
				}
				else
				{
					result = string.Format(TopConfig.string_11, TopConfig.AgentAppkey);
				}
				return result;
			}
			set
			{
				TopConfig.string_11 = value;
			}
		}
		public static string AdminCookiesName
		{
			get
			{
				string result;
				if (ConfigurationManager.AppSettings["AdminCookiesName"] != null)
				{
					result = string.Format(ConfigurationManager.AppSettings["AdminCookiesName"].ToString(), TopConfig.AdminAppkey);
				}
				else
				{
					result = string.Format(TopConfig.string_12, TopConfig.AdminAppkey);
				}
				return result;
			}
			set
			{
				TopConfig.string_12 = value;
			}
		}
		public static string getUrl(string string_13)
		{
			string str = string.Empty;
			if (ConfigurationManager.AppSettings["IsSandBox"] == "1")
			{
				str = ConfigurationManager.AppSettings["SandContainerURL"];
			}
			else
			{
				str = ConfigurationManager.AppSettings["ContainerURL"];
			}
			return str + string.Format("?client_id={0}&response_type=code&redirect_uri=http://www.groupfly.com/shop/shopadmin/TbTop/Login.aspx", string_13);
		}
	}
}
