using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Security;
namespace ShopNum1.Standard
{
	public class SendMessage
	{
		public static string send(string string_0, string urlAddr, Dictionary<string, string> dictionary_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = string.Empty;
			foreach (KeyValuePair<string, string> current in dictionary_0)
			{
				stringBuilder.Append(current.Key);
				stringBuilder.Append("=");
				stringBuilder.Append(current.Value);
				stringBuilder.Append("&");
			}
			string text2 = stringBuilder.ToString();
			if (text2.Length > 0)
			{
				text2 = text2.TrimEnd(new char[]
				{
					'&'
				});
			}
			string result;
			try
			{
				string string_ = urlAddr + text2;
				result = SendMessage.getPage(string_, text2);
				return result;
			}
			catch (Exception ex)
			{
				text = ex.Message;
			}
			result = text;
			return result;
		}
		public static string getPage(string string_0, string paramList)
		{
			string result = string.Empty;
			Encoding encoding = Encoding.GetEncoding("utf-8");
			WebRequest webRequest = WebRequest.Create(string_0);
			try
			{
				WebResponse response = webRequest.GetResponse();
				StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
				result = streamReader.ReadToEnd();
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
		public static string smethod_0(string string_0)
		{
			return FormsAuthentication.HashPasswordForStoringInConfigFile(string_0, "MD5").ToLower();
		}
	}
}
