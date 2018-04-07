using System;
using System.Web;
namespace ShopNum1.Common
{
	public static class PageOperator
	{
		public static string GetCurrentPageName()
		{
			string text = HttpContext.Current.Request.FilePath.ToLower();
			string text2 = text.Replace("/main/admin", "").Trim();
			string text3 = text2.Substring(text2.IndexOf("/"));
			if (Operator.Left(text3, 1) == "/")
			{
				text3 = text3.Substring(1);
			}
			return text3;
		}
		public static string GetListImageStatus(string isshow)
		{
			string result;
			if (isshow == "0")
			{
				result = "images/shopNum1Admin-right.gif";
			}
			else
			{
				result = "images/shopNum1Admin-wrong.gif";
			}
			return result;
		}
	}
}
