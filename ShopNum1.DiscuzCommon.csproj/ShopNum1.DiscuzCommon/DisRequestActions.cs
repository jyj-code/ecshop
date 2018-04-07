using System;
using System.Collections.Specialized;
namespace ShopNum1.DiscuzCommon
{
	public static class DisRequestActions
	{
		public const string Dis_ACTION_DELETEUSER = "deleteuser";
		public const string Dis_ACTION_GETCREDITSETTINGS = "getcreditsettings";
		public const string Dis_ACTION_GETTAG = "gettag";
		public const string Dis_ACTION_RENAMEUSER = "renameuser";
		public const string Dis_ACTION_SYNLOGIN = "login";
		public const string Dis_ACTION_SYNLOGOUT = "logout";
		public const string Dis_ACTION_TEST = "test";
		private static StringCollection stringCollection_0;
		static DisRequestActions()
		{
			if (DisRequestActions.stringCollection_0 == null)
			{
				DisRequestActions.stringCollection_0 = new StringCollection();
				DisRequestActions.stringCollection_0.Add("test");
				DisRequestActions.stringCollection_0.Add("deleteuser");
				DisRequestActions.stringCollection_0.Add("renameuser");
				DisRequestActions.stringCollection_0.Add("gettag");
				DisRequestActions.stringCollection_0.Add("login");
				DisRequestActions.stringCollection_0.Add("logout");
				DisRequestActions.stringCollection_0.Add("getcreditsettings");
			}
		}
		public static bool IsValidAction(string action)
		{
			return DisRequestActions.stringCollection_0.Contains(action.ToLower());
		}
		public static int StringToInt(string string_0)
		{
			return DisRequestActions.StringToInt(string_0, 0);
		}
		public static int StringToInt(string string_0, int defaultValue)
		{
			int result;
			if (!string.IsNullOrEmpty(string_0))
			{
				int num = 0;
				if (int.TryParse(string_0, out num))
				{
					result = num;
					return result;
				}
			}
			result = defaultValue;
			return result;
		}
		public static int UnixTimestamp()
		{
			DateTime value = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			string text = DateTime.Parse(DateTime.Now.ToString()).Subtract(value).Ticks.ToString();
			return Convert.ToInt32(text.Substring(0, text.Length - 7));
		}
	}
}
