using System;
using System.Text.RegularExpressions;
using System.Web;
public class safe_360
{
	private const string string_0 = "<[^>]+?style=[\\w]+?:expression\\(|\\b(alert|confirm|prompt)\\b|^\\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\\b(and|or)\\b.{1,6}?(=|>|<|\\bin\\b|\\blike\\b)|/\\*.+?\\*/|<\\s*script\\b|<\\s*img\\b|\\bEXEC\\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\\s+(TABLE|DATABASE)";
	public static bool PostData()
	{
		bool result = false;
		int num = 0;
		while (num < HttpContext.Current.Request.Form.Count && !(result = safe_360.CheckData(HttpContext.Current.Request.Form[num].ToString())))
		{
			num++;
		}
		return result;
	}
	public static bool GetData()
	{
		bool result = false;
		int num = 0;
		while (num < HttpContext.Current.Request.QueryString.Count && !(result = safe_360.CheckData(HttpContext.Current.Request.QueryString[num].ToString())))
		{
			num++;
		}
		return result;
	}
	public static bool CookieData()
	{
		bool result = false;
		int num = 0;
		while (num < HttpContext.Current.Request.Cookies.Count && !(result = safe_360.CheckData(HttpContext.Current.Request.Cookies[num].Value.ToLower())))
		{
			num++;
		}
		return result;
	}
	public static bool referer()
	{
		return safe_360.CheckData(HttpContext.Current.Request.UrlReferrer.ToString());
	}
	public static bool CheckData(string inputData)
	{
		return Regex.IsMatch(inputData, "<[^>]+?style=[\\w]+?:expression\\(|\\b(alert|confirm|prompt)\\b|^\\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\\b(and|or)\\b.{1,6}?(=|>|<|\\bin\\b|\\blike\\b)|/\\*.+?\\*/|<\\s*script\\b|<\\s*img\\b|\\bEXEC\\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\\s+(TABLE|DATABASE)");
	}
}
