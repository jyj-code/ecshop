using System;
using System.Configuration;
using System.Web;
namespace ShopNum1.Common
{
	public class GetPageName
	{
		public static string RetUrl(string pagename)
		{
			return string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				GetPageName.GetOverrideUrlName()
			});
		}
		public static string RetDomainUrl(string pagename)
		{
			return string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				pagename,
				GetPageName.GetOverrideUrlName()
			});
		}
		public static string RetUrl(string pagename, object value)
		{
			return string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				"/",
				value.ToString(),
				GetPageName.GetOverrideUrlName()
			});
		}
		public static string RetDomainUrl(string pagename, object value)
		{
			return string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				pagename,
				"/",
				value.ToString(),
				GetPageName.GetOverrideUrlName()
			});
		}
		public static string RetUrl(string pagename, object value, string args)
		{
			return string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				GetPageName.GetOverrideUrlName(),
				"?",
				args,
				"=",
				value.ToString()
			});
		}
		public static string RetDomainUrl(string pagename, object value, string args)
		{
			return string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				pagename,
				GetPageName.GetOverrideUrlName(),
				"?",
				args,
				"=",
				value.ToString()
			});
		}
		public static string RetDomainUrlMore(string pagename, string value)
		{
			return string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				pagename,
				GetPageName.GetOverrideUrlName(),
				"?",
				value
			});
		}
		public static string RetUrl(string pagename, string value, string args)
		{
			string text = string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				GetPageName.GetOverrideUrlName()
			});
			if (args != null)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"?",
					args,
					"=",
					value
				});
			}
			return text;
		}
		public static string RetUrlMore(string pagename, string value)
		{
			return string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				GetPageName.GetOverrideUrlName(),
				"?",
				value
			});
		}
		public static string ProductSearch(string search, object name)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/ProductList",
					GetPageName.GetOverrideUrlName(),
					"?Search=",
					search,
					"&code=",
					name.ToString()
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/ProductList.aspx?Search=",
					search,
					"&code=",
					name.ToString()
				});
			}
			return result;
		}
		public static string ProductMultiImage(object guid, object originalImge)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/ProductMultiImage",
					GetPageName.GetOverrideUrlName(),
					"?guid=",
					guid.ToString(),
					"&OriginalImge=",
					originalImge.ToString()
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/ProductMultiImage.aspx?guid=",
					guid.ToString(),
					"&OriginalImge=",
					originalImge.ToString()
				});
			}
			return result;
		}
		public static string OrganizBuyDetail(object guid, object productguid)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/OrganizBuyDetail/",
					guid.ToString(),
					GetPageName.GetOverrideUrlName(),
					"?productguid=",
					productguid.ToString()
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/OrganizBuyDetail.aspx?guid=",
					guid.ToString(),
					"&productguid=",
					productguid.ToString()
				});
			}
			return result;
		}
		public static string UserDefinedColumn(string pagename)
		{
			string result;
			if (pagename.IndexOf("http://") == -1)
			{
				if (ShopSettings.IsOverrideUrl)
				{
					result = string.Concat(new string[]
					{
						"http://",
						HttpContext.Current.Request.Url.Host,
						"/",
						pagename.Split(new char[]
						{
							'+'
						})[0].ToString(),
						GetPageName.GetOverrideUrlName()
					});
				}
				else
				{
					result = "http://" + HttpContext.Current.Request.Url.Host + "/" + pagename.Split(new char[]
					{
						'+'
					})[1];
				}
			}
			else
			{
				result = pagename;
			}
			return result;
		}
		public static string GetPage(string value)
		{
			int num = HttpContext.Current.Request.Path.LastIndexOf('/');
			int num2 = HttpContext.Current.Request.Path.LastIndexOf('.');
			string text = HttpContext.Current.Request.Path.Substring(num + 1, num2 - num - 1);
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					text,
					GetPageName.GetOverrideUrlName(),
					value
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					text,
					".aspx",
					value
				});
			}
			return result;
		}
		public static string GetMainPage(string PageName)
		{
			string text = ShopSettings.siteDomain;
			if (!ShopSettings.siteDomain.Contains("http://"))
			{
				text = "http://" + text;
			}
			return text + "/" + PageName;
		}
		public static string GetMainPage(string PageName, string SubstationID)
		{
			string text = string.Empty;
			try
			{
				text = Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   AND SubstationID='" + SubstationID + "'    ");
			}
			catch (Exception)
			{
			}
			string text2 = text + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
			if (ShopSettings.siteDomain.IndexOf(".") != -1)
			{
				string[] array = ShopSettings.siteDomain.Split(new char[]
				{
					'.'
				});
				if (array.Length == 2)
				{
					text2 = string.Concat(new string[]
					{
						text,
						".",
						array[1],
						".",
						array[2]
					});
				}
			}
			if (!ShopSettings.siteDomain.Contains("http://"))
			{
				text2 = "http://" + text2;
			}
			return text2 + "/" + PageName;
		}
		public static string AgentGetPage(string value)
		{
			int num = HttpContext.Current.Request.Path.LastIndexOf('/');
			int num2 = HttpContext.Current.Request.Path.LastIndexOf('.');
			string text = HttpContext.Current.Request.Path.Substring(num + 1, num2 - num - 1);
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					text,
					GetPageName.GetOverrideUrlName(),
					value
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Agent/Agent/",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"/",
					text,
					".aspx",
					value,
					"&AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"]
				});
			}
			return result;
		}
		public static string AgentRetUrl(string pagename)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					pagename,
					GetPageName.GetOverrideUrlName()
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Agent/Agent/",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"/",
					pagename,
					".aspx?AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"]
				});
			}
			return result;
		}
		public static string AgentRetUrl(string pagename, object value)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					pagename,
					"/",
					value.ToString(),
					GetPageName.GetOverrideUrlName()
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Agent/Agent/",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"/",
					pagename,
					".aspx?guid=",
					value.ToString(),
					"&AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"]
				});
			}
			return result;
		}
		public static string AgentRetUrl(string pagename, object value, string args)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					pagename,
					"/",
					value.ToString(),
					GetPageName.GetOverrideUrlName()
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Agent/Agent/",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"/",
					pagename,
					".aspx?",
					args,
					"=",
					value.ToString(),
					"&AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"]
				});
			}
			return result;
		}
		public static string AgentRetUrl(string pagename, string value, string args)
		{
			string text = string.Empty;
			if (ShopSettings.IsOverrideUrl)
			{
				text = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					pagename,
					GetPageName.GetOverrideUrlName()
				});
				if (args != null)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"?",
						args,
						"=",
						value
					});
				}
			}
			else
			{
				text = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Agent/Agent/",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"/",
					pagename,
					".aspx"
				});
				if (args != null)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"?",
						args,
						"=",
						value,
						"&AgentLoginID=",
						HttpContext.Current.Request.QueryString["AgentLoginID"]
					});
				}
			}
			return text;
		}
		public static string AgentProductSearch(string search, object name)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/ProductSearch",
					GetPageName.GetOverrideUrlName(),
					"?Search=",
					search,
					"&Name=",
					name.ToString()
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Agent/Agent/",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"/ProductSearch.aspx?Search=",
					search,
					"&Name=",
					name.ToString(),
					"&AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"]
				});
			}
			return result;
		}
		public static string AgentProductMultiImage(object guid, object originalImge)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/ProductMultiImage",
					GetPageName.GetOverrideUrlName(),
					"?guid=",
					guid.ToString(),
					"&OriginalImge=",
					originalImge.ToString()
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Agent/Agent/",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"/ProductMultiImage.aspx?guid=",
					guid.ToString(),
					"&OriginalImge=",
					originalImge.ToString(),
					"&AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"]
				});
			}
			return result;
		}
		public static string AgentUserDefinedColumn(string pagename)
		{
			string result;
			if (pagename.IndexOf("http://") == -1)
			{
				if (ShopSettings.IsOverrideUrl)
				{
					result = string.Concat(new string[]
					{
						"http://",
						HttpContext.Current.Request.Url.Host,
						"/",
						pagename.Split(new char[]
						{
							'+'
						})[0].ToString(),
						GetPageName.GetOverrideUrlName()
					});
				}
				else
				{
					string text = string.Empty;
					if (pagename.Split(new char[]
					{
						'+'
					})[1].IndexOf("?") != -1)
					{
						text = "&&AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"];
					}
					else
					{
						text = "?AgentLoginID=" + HttpContext.Current.Request.QueryString["AgentLoginID"];
					}
					result = string.Concat(new string[]
					{
						"http://",
						HttpContext.Current.Request.Url.Host,
						"/Agent/Agent/",
						HttpContext.Current.Request.QueryString["AgentLoginID"],
						"/",
						pagename.Split(new char[]
						{
							'+'
						})[1],
						text
					});
				}
			}
			else
			{
				result = pagename;
			}
			return result;
		}
		public static string AgentRetUrlMore(string pagename, string value)
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					pagename,
					GetPageName.GetOverrideUrlName(),
					"?",
					value
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/Agent/Agent/",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"/",
					pagename,
					".aspx?",
					value.ToString(),
					"&AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"]
				});
			}
			return result;
		}
		public static string GetOverrideUrlName()
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = ShopSettings.overrideUrlName;
			}
			else
			{
				result = ".aspx";
			}
			return result;
		}
		public static string GetDoMain()
		{
			string result;
			if (ConfigurationManager.AppSettings["DoMain"] != HttpContext.Current.Request.Url.Host && HttpContext.Current.Request.Url.AbsoluteUri.ToLower().IndexOf("http://www") != -1)
			{
				result = HttpContext.Current.Request.Url.Host;
			}
			else
			{
				result = HttpContext.Current.Request.Url.Host.Replace("www", HttpContext.Current.Request.QueryString["AgentLoginID"]);
			}
			return result;
		}
		public static string pop_RetDomainUrl(string pagename)
		{
			return string.Concat(new string[]
			{
				"http%3A%2F%2F",
				ShopSettings.siteDomain,
				"%2F",
				pagename,
				GetPageName.GetOverrideUrlName()
			});
		}
		public static string pop_GetMainPage(string PageName)
		{
			string text = ShopSettings.siteDomain;
			if (!ShopSettings.siteDomain.Contains("http%3A%2F%2F"))
			{
				text = "http%3A%2F%2F" + text;
			}
			return text + "%2F" + PageName;
		}
	}
}
