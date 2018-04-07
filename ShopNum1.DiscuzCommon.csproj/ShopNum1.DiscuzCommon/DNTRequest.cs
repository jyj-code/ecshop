using System;
using System.Web;
namespace ShopNum1.DiscuzCommon
{
	public class DNTRequest
	{
		public static bool IsPost()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("POST");
		}
		public static bool IsGet()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("GET");
		}
		public static string GetServerString(string strName)
		{
			string result;
			if (HttpContext.Current.Request.ServerVariables[strName] == null)
			{
				result = "";
			}
			else
			{
				result = HttpContext.Current.Request.ServerVariables[strName].ToString();
			}
			return result;
		}
		public static string GetUrlReferrer()
		{
			string text = null;
			try
			{
				text = HttpContext.Current.Request.UrlReferrer.ToString();
			}
			catch
			{
			}
			string result;
			if (text == null)
			{
				result = "";
			}
			else
			{
				result = text;
			}
			return result;
		}
		public static string GetCurrentFullHost()
		{
			HttpRequest request = HttpContext.Current.Request;
			string result;
			if (!request.Url.IsDefaultPort)
			{
				result = string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
			}
			else
			{
				result = request.Url.Host;
			}
			return result;
		}
		public static string GetHost()
		{
			return HttpContext.Current.Request.Url.Host;
		}
		public static string GetRawUrl()
		{
			return HttpContext.Current.Request.RawUrl;
		}
		public static bool IsBrowserGet()
		{
			string[] array = new string[]
			{
				"ie",
				"opera",
				"netscape",
				"mozilla",
				"konqueror",
				"firefox"
			};
			string text = HttpContext.Current.Request.Browser.Type.ToLower();
			bool result;
			for (int i = 0; i < array.Length; i++)
			{
				if (text.IndexOf(array[i]) >= 0)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public static bool IsSearchEnginesGet()
		{
			bool result;
			if (HttpContext.Current.Request.UrlReferrer == null)
			{
				result = false;
			}
			else
			{
				string[] array = new string[]
				{
					"google",
					"yahoo",
					"msn",
					"baidu",
					"sogou",
					"sohu",
					"sina",
					"163",
					"lycos",
					"tom",
					"yisou",
					"iask",
					"soso",
					"gougou",
					"zhongsou"
				};
				string text = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
				for (int i = 0; i < array.Length; i++)
				{
					if (text.IndexOf(array[i]) >= 0)
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		public static string GetUrl()
		{
			return HttpContext.Current.Request.Url.ToString();
		}
		public static string GetQueryString(string strName)
		{
			string result;
			if (HttpContext.Current.Request.QueryString[strName] == null)
			{
				result = "";
			}
			else
			{
				result = HttpContext.Current.Request.QueryString[strName];
			}
			return result;
		}
		public static string GetPageName()
		{
			string[] array = HttpContext.Current.Request.Url.AbsolutePath.Split(new char[]
			{
				'/'
			});
			return array[array.Length - 1].ToLower();
		}
		public static int GetParamCount()
		{
			return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
		}
		public static string GetFormString(string strName)
		{
			string result;
			if (HttpContext.Current.Request.Form[strName] == null)
			{
				result = "";
			}
			else
			{
				result = HttpContext.Current.Request.Form[strName];
			}
			return result;
		}
		public static string GetString(string strName)
		{
			string result;
			if ("".Equals(DNTRequest.GetQueryString(strName)))
			{
				result = DNTRequest.GetFormString(strName);
			}
			else
			{
				result = DNTRequest.GetQueryString(strName);
			}
			return result;
		}
		public static int GetQueryInt(string strName, int defValue)
		{
			return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
		}
		public static int GetFormInt(string strName, int defValue)
		{
			return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
		}
		public static int GetInt(string strName, int defValue)
		{
			int result;
			if (DNTRequest.GetQueryInt(strName, defValue) == defValue)
			{
				result = DNTRequest.GetFormInt(strName, defValue);
			}
			else
			{
				result = DNTRequest.GetQueryInt(strName, defValue);
			}
			return result;
		}
		public static float GetQueryFloat(string strName, float defValue)
		{
			return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
		}
		public static float GetFormFloat(string strName, float defValue)
		{
			return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
		}
		public static float GetFloat(string strName, float defValue)
		{
			float result;
			if (DNTRequest.GetQueryFloat(strName, defValue) == defValue)
			{
				result = DNTRequest.GetFormFloat(strName, defValue);
			}
			else
			{
				result = DNTRequest.GetQueryFloat(strName, defValue);
			}
			return result;
		}
		public static string GetIP()
		{
			string text = string.Empty;
			text = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (text == null || text == string.Empty)
			{
				text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
			if (text == null || text == string.Empty)
			{
				text = HttpContext.Current.Request.UserHostAddress;
			}
			string result;
			if (text == null || text == string.Empty || !Utils.IsIP(text))
			{
				result = "0.0.0.0";
			}
			else
			{
				result = text;
			}
			return result;
		}
		public static void SaveRequestFile(string path)
		{
			if (HttpContext.Current.Request.Files.Count > 0)
			{
				HttpContext.Current.Request.Files[0].SaveAs(path);
			}
		}
	}
}
