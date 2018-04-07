using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Web;
namespace ShopNum1.Common
{
	public static class HexConvert
	{
		public static string Encode(string strEncode)
		{
			string text = "";
			char[] array = strEncode.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				text += ((short)array[i]).ToString("X4");
			}
			return text;
		}
		public static string Decode(string strDecode)
		{
			string text = "";
			for (int i = 0; i < strDecode.Length / 4; i++)
			{
				text += (char)short.Parse(strDecode.Substring(i * 4, 4), NumberStyles.HexNumber);
			}
			return text;
		}
		public static SortedDictionary<string, string> GetRequestHtmlGet()
		{
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			NameValueCollection queryString = HttpContext.Current.Request.QueryString;
			string[] allKeys = queryString.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				if (queryString[i] != null && allKeys[i] != null)
				{
					sortedDictionary.Add(allKeys[i], queryString[i]);
				}
			}
			return sortedDictionary;
		}
		public static SortedDictionary<string, string> GetRequestHtmlPost()
		{
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			NameValueCollection form = HttpContext.Current.Request.Form;
			string[] allKeys = form.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				if (form[i] != null && allKeys[i] != null)
				{
					sortedDictionary.Add(allKeys[i], form[i]);
				}
			}
			return sortedDictionary;
		}
	}
}
