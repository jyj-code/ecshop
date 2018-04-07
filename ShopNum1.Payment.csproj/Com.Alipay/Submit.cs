using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Xml;
namespace Com.Alipay
{
	public class Submit
	{
		private static string string_0;
		public static string _key;
		private static string string_1;
		private static string string_2;
		[CompilerGenerated]
		private static string string_3;
		public static string String_0
		{
			get;
			set;
		}
		static Submit()
		{
			Submit.string_0 = "https://mapi.alipay.com/gateway.do?";
			Submit._key = "";
			Submit.string_1 = "";
			Submit.string_2 = "";
			Submit.string_1 = Config.Input_charset.Trim().ToLower();
			Submit.string_2 = Config.Sign_type.Trim().ToUpper();
		}
		private static string smethod_0(Dictionary<string, string> dictionary_0, string string_4)
		{
			string prestr = Core.CreateLinkString(dictionary_0);
			string text = Submit.string_2;
			string result;
			if (text != null && text == "MD5")
			{
				result = AlipayMD5.Sign(prestr, string_4, Submit.string_1);
			}
			else
			{
				result = "";
			}
			return result;
		}
		private static string smethod_1(Dictionary<string, string> dictionary_0)
		{
			string prestr = Core.CreateLinkString(dictionary_0);
			string text = Submit.string_2;
			string result;
			if (text != null && text == "MD5")
			{
				result = AlipayMD5.Sign(prestr, Submit._key, Submit.string_1);
			}
			else
			{
				result = "";
			}
			return result;
		}
		private static Dictionary<string, string> smethod_2(SortedDictionary<string, string> sortedDictionary_0, string string_4)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary = Core.FilterPara(sortedDictionary_0);
			string value = Submit.smethod_0(dictionary, string_4);
			dictionary.Add("sign", value);
			dictionary.Add("sign_type", Submit.string_2);
			return dictionary;
		}
		private static Dictionary<string, string> smethod_3(SortedDictionary<string, string> sortedDictionary_0)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary = Core.FilterPara(sortedDictionary_0);
			string value = Submit.smethod_1(dictionary);
			dictionary.Add("sign", value);
			dictionary.Add("sign_type", Submit.string_2);
			return dictionary;
		}
		private static string smethod_4(SortedDictionary<string, string> sortedDictionary_0, Encoding encoding_0)
		{
			Dictionary<string, string> dicArray = new Dictionary<string, string>();
			dicArray = Submit.smethod_3(sortedDictionary_0);
			return Core.CreateLinkStringUrlencode(dicArray, encoding_0);
		}
		public static string BuildRequest(SortedDictionary<string, string> sParaTemp, string strMethod, string strButtonValue)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary = Submit.smethod_3(sParaTemp);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"<form id='alipaysubmit' name='alipaysubmit' action='",
				Submit.string_0,
				"_input_charset=",
				Submit.string_1,
				"' method='",
				strMethod.ToLower().Trim(),
				"'>"
			}));
			foreach (KeyValuePair<string, string> current in dictionary)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<input type='hidden' name='",
					current.Key,
					"' value='",
					current.Value,
					"'/>"
				}));
			}
			stringBuilder.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");
			stringBuilder.Append("<script>document.forms['alipaysubmit'].submit();</script>");
			return stringBuilder.ToString();
		}
		public static string BuildRequest(SortedDictionary<string, string> sParaTemp, string strMethod, string strButtonValue, string xKey)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary = Submit.smethod_2(sParaTemp, xKey);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"<form id='alipaysubmit' name='alipaysubmit' action='",
				Submit.string_0,
				"_input_charset=",
				Submit.string_1,
				"' method='",
				strMethod.ToLower().Trim(),
				"'>"
			}));
			foreach (KeyValuePair<string, string> current in dictionary)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<input type='hidden' name='",
					current.Key,
					"' value='",
					current.Value,
					"'/>"
				}));
			}
			stringBuilder.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");
			stringBuilder.Append("<script>document.forms['alipaysubmit'].submit();</script>");
			return stringBuilder.ToString();
		}
		public static string BuildRequest(SortedDictionary<string, string> sParaTemp)
		{
			Encoding encoding = Encoding.GetEncoding(Submit.string_1);
			string text = Submit.smethod_4(sParaTemp, encoding);
			byte[] bytes = encoding.GetBytes(text);
			string requestUriString = Submit.string_0 + "_input_charset=" + Submit.string_1;
			string result = "";
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				File.AppendAllText(HttpContext.Current.Server.MapPath("/log/sendpost.txt"), Submit.string_0 + text + "\r\n");
				httpWebRequest.Method = "post";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentLength = (long)bytes.Length;
				Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, encoding);
				StringBuilder stringBuilder = new StringBuilder();
				string value;
				while ((value = streamReader.ReadLine()) != null)
				{
					stringBuilder.Append(value);
				}
				responseStream.Close();
				result = stringBuilder.ToString();
			}
			catch (Exception ex)
			{
				result = "报错：" + ex.Message;
			}
			return result;
		}
		public static string BuildRequest(SortedDictionary<string, string> sParaTemp, string strMethod, string fileName, byte[] data, string contentType, int lengthFile)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary = Submit.smethod_3(sParaTemp);
			string requestUriString = Submit.string_0 + "_input_charset=" + Submit.string_1;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.Method = strMethod;
			string str = DateTime.Now.Ticks.ToString("x");
			string text = "--" + str;
			httpWebRequest.ContentType = "\r\nmultipart/form-data; boundary=" + str;
			httpWebRequest.KeepAlive = true;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> current in dictionary)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					text,
					"\r\nContent-Disposition: form-data; name=\"",
					current.Key,
					"\"\r\n\r\n",
					current.Value,
					"\r\n"
				}));
			}
			stringBuilder.Append(text + "\r\nContent-Disposition: form-data; name=\"withhold_file\"; filename=\"");
			stringBuilder.Append(fileName);
			stringBuilder.Append("\"\r\nContent-Type: " + contentType + "\r\n\r\n");
			string s = stringBuilder.ToString();
			Encoding encoding = Encoding.GetEncoding(Submit.string_1);
			byte[] bytes = encoding.GetBytes(s);
			byte[] bytes2 = Encoding.ASCII.GetBytes("\r\n" + text + "--\r\n");
			long contentLength = (long)(bytes.Length + lengthFile + bytes2.Length);
			httpWebRequest.ContentLength = contentLength;
			Stream requestStream = httpWebRequest.GetRequestStream();
			Stream responseStream;
			string result;
			try
			{
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Write(data, 0, lengthFile);
				requestStream.Write(bytes2, 0, bytes2.Length);
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				responseStream = httpWebResponse.GetResponseStream();
			}
			catch (WebException ex)
			{
				result = ex.ToString();
				return result;
			}
			finally
			{
				if (requestStream != null)
				{
					requestStream.Close();
				}
			}
			StreamReader streamReader = new StreamReader(responseStream, encoding);
			StringBuilder stringBuilder2 = new StringBuilder();
			string value;
			while ((value = streamReader.ReadLine()) != null)
			{
				stringBuilder2.Append(value);
			}
			responseStream.Close();
			result = stringBuilder2.ToString();
			return result;
		}
		public static string Query_timestamp()
		{
			string url = string.Concat(new string[]
			{
				Submit.string_0,
				"service=query_timestamp&partner=",
				Config.Partner,
				"&_input_charset=",
				Config.Input_charset
			});
			XmlTextReader reader = new XmlTextReader(url);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(reader);
			return xmlDocument.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;
		}
	}
}
