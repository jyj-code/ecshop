using System;
using System.Web;
namespace ShopNum1.Common
{
	public class Globals
	{
		public static string IPAddress
		{
			get
			{
				string text = string.Empty;
				HttpRequest request = HttpContext.Current.Request;
				if (request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
				{
					text = request.ServerVariables["REMOTE_ADDR"];
				}
				else
				{
					text = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
					if (text == null || text == "")
					{
						text = request.UserHostAddress;
					}
				}
				return text;
			}
		}
		public static string ApplicationPath
		{
			get
			{
				string applicationPath = HttpContext.Current.Request.ApplicationPath;
				string result;
				if (applicationPath == "/")
				{
					result = "/";
				}
				else
				{
					result = applicationPath;
				}
				return result;
			}
		}
		public static string ImagePath
		{
			get
			{
				string applicationPath = HttpContext.Current.Request.ApplicationPath;
				string result;
				if (applicationPath == "/")
				{
					result = "/ImgUpload/";
				}
				else
				{
					result = applicationPath + "/ImgUpload/";
				}
				return result;
			}
		}
		public static string SkinPath
		{
			get
			{
				Themes themes = new Themes();
				string fieldXmlPath = string.Empty;
				if (Globals.ApplicationPath == "/")
				{
					fieldXmlPath = HttpContext.Current.Server.MapPath("/Settings/SiteConfig.xml");
				}
				else
				{
					fieldXmlPath = HttpContext.Current.Server.MapPath(Globals.ApplicationPath + "/Settings/SiteConfig.xml");
				}
				string value = themes.GetValue(fieldXmlPath, "Themes");
				string text = "/Main/Themes/" + value;
				if (!(Globals.ApplicationPath == "/"))
				{
					text = Globals.ApplicationPath + text;
				}
				return text;
			}
		}
		public static string SkinName
		{
			get
			{
				Themes themes = new Themes();
				string fieldXmlPath = string.Empty;
				if (Globals.ApplicationPath == "/")
				{
					fieldXmlPath = HttpContext.Current.Server.MapPath("/Settings/SiteConfig.xml");
				}
				else
				{
					fieldXmlPath = HttpContext.Current.Server.MapPath(Globals.ApplicationPath + "/Settings/SiteConfig.xml");
				}
				return themes.GetValue(fieldXmlPath, "Themes");
			}
		}
		public static string MoneySymbol
		{
			get
			{
				new ShopSettings();
				if (Globals.ApplicationPath == "/")
				{
					HttpContext.Current.Server.MapPath("/Settings/ShopSetting.xml");
				}
				else
				{
					HttpContext.Current.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
				}
				return ShopSettings.GetValue("MoneySymbol");
			}
		}
	}
}
