using System;
namespace ShopNum1.Common
{
	public class TosUrl
	{
		public static string GosUrl(object object_0)
		{
			string result;
			if (object_0.ToString().Length > 0)
			{
				int num = object_0.ToString().LastIndexOf('/') + 1;
				string text = object_0.ToString().Substring(0, num);
				result = text + "s_" + object_0.ToString().Substring(num, object_0.ToString().Length - text.Length);
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string GetSyPic(object object_0)
		{
			string result;
			if (object_0.ToString().Length > 0)
			{
				int num = object_0.ToString().LastIndexOf('/') + 1;
				string text = object_0.ToString().Substring(0, num);
				result = text + "sy_" + object_0.ToString().Substring(num, object_0.ToString().Length - text.Length);
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
