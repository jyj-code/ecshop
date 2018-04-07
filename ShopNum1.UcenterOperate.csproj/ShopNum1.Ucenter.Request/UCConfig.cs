using System;
using System.Configuration;
namespace ShopNum1.Ucenter.Request
{
	public static class UCConfig
	{
		public static string UC_API
		{
			get
			{
				string text = ConfigurationManager.AppSettings["UC_API"];
				if (!text.EndsWith("/"))
				{
					text += "/";
				}
				return text;
			}
		}
		public static string UC_APPID
		{
			get
			{
				return ConfigurationManager.AppSettings["UC_APPID"];
			}
		}
		public static string UC_CHARSET
		{
			get
			{
				return ConfigurationManager.AppSettings["UC_CHARSET"];
			}
		}
		public static string UC_CLIENT_RELEASE
		{
			get
			{
				return ConfigurationManager.AppSettings["UC_CLIENT_RELEASE"];
			}
		}
		public static string UC_CLIENT_VERSION
		{
			get
			{
				return ConfigurationManager.AppSettings["UC_CLIENT_VERSION"];
			}
		}
		public static string UC_CONST_AVATAR_REAL
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_AVATAR_REAL", "real");
			}
		}
		public static string UC_CONST_AVATAR_SIZE_BIG
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_AVATAR_SIZE_BIG", "big");
			}
		}
		public static string UC_CONST_AVATAR_SIZE_MIDDLE
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_AVATAR_SIZE_MIDDLE", "middle");
			}
		}
		public static string UC_CONST_AVATAR_SIZE_SMALL
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_AVATAR_SIZE_SMALL", "small");
			}
		}
		public static string UC_CONST_AVATAR_VIRTUAL
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_AVATAR_VIRTUAL", "virtual");
			}
		}
		public static string UC_CONST_PM_BLACKLS_ALL
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_PM_BLACKLS_ALL", "ALL");
			}
		}
		public static string UC_CONST_PM_FILTER_ANNOUNCEPM
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_PM_FILTER_ANNOUNCEPM", "announcepm");
			}
		}
		public static string UC_CONST_PM_FILTER_NEWPM
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_PM_FILTER_NEWPM", "newpm");
			}
		}
		public static string UC_CONST_PM_FILTER_SYSTEMPM
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_PM_FILTER_SYSTEMPM", "systempm");
			}
		}
		public static string UC_CONST_PM_INBOX
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_PM_INBOX", "inbox");
			}
		}
		public static string UC_CONST_PM_NEWBOX
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_PM_NEWBOX", "newbox");
			}
		}
		public static string UC_CONST_PM_OUTBOX
		{
			get
			{
				return UCConfig.smethod_0("UC_CONST_PM_OUTBOX", "outbox");
			}
		}
		public static string UC_IP
		{
			get
			{
				return ConfigurationManager.AppSettings["UC_IP"];
			}
		}
		public static string UC_KEY
		{
			get
			{
				return ConfigurationManager.AppSettings["UC_KEY"];
			}
		}
		public static string IsIntergrationUCenter
		{
			get
			{
				return ConfigurationManager.AppSettings["IsIntergrationUCenter"];
			}
		}
		private static string smethod_0(string string_0, string string_1)
		{
			string text = ConfigurationManager.AppSettings[string_0];
			string result;
			if (string.IsNullOrEmpty(text))
			{
				result = string_1;
			}
			else
			{
				result = text.Trim();
			}
			return result;
		}
	}
}
