using ShopNum1.DiscuzToolkit;
using System;
using System.Configuration;
namespace ShopNum1.DiscuzHelper
{
	public class DiscuzSessionHelper
	{
		private static string string_0;
		private static string string_1;
		private static string string_2;
		private static DiscuzSession discuzSession_0;
		static DiscuzSessionHelper()
		{
			DiscuzSessionHelper.string_0 = ConfigurationManager.AppSettings["DiscuzApiKey"];
			DiscuzSessionHelper.string_1 = ConfigurationManager.AppSettings["DiscuzSecret"];
			DiscuzSessionHelper.string_2 = ConfigurationManager.AppSettings["DiscuzPostUrl"];
			DiscuzSessionHelper.discuzSession_0 = new DiscuzSession(DiscuzSessionHelper.string_0, DiscuzSessionHelper.string_1, DiscuzSessionHelper.string_2);
		}
		public static DiscuzSession GetSession()
		{
			return DiscuzSessionHelper.discuzSession_0;
		}
		public static bool IsDiscuzIntegration()
		{
			string a = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
			return a == "1";
		}
	}
}
