using System;
using System.Web;
public static class AjaxMsgHelper
{
	public static void AjaxMsg(string statu, string string_0)
	{
		AjaxMsgHelper.AjaxMsg(statu, string_0, "null", "null");
	}
	public static void AjaxMsg(string statu, string string_0, string data)
	{
		AjaxMsgHelper.AjaxMsg(statu, string_0, data, "null");
	}
	public static void AjaxMsg(string statu, string string_0, string data, string nextUrl)
	{
		string s = string.Concat(new string[]
		{
			"{\"statu\":\"",
			statu,
			"\",\"msg\":\"",
			string_0.Replace('"', ' ').Replace('\'', ' ').Replace("\r\n", ""),
			"\",\"data\":",
			(data == null) ? "null" : data,
			",\"nextUrl\":",
			(nextUrl == null) ? "null" : ("\"" + nextUrl + "\""),
			"}"
		});
		HttpContext.Current.Response.Write(s);
	}
}
