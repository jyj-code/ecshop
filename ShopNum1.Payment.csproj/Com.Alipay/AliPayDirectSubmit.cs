using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
namespace Com.Alipay
{
	public class AliPayDirectSubmit
	{
		private static string string_0;
		private static string string_1;
		private static string string_2;
		private static string string_3;
		static AliPayDirectSubmit()
		{
			AliPayDirectSubmit.string_0 = "https://mapi.alipay.com/gateway.do?";
			AliPayDirectSubmit.string_1 = "";
			AliPayDirectSubmit.string_2 = "";
			AliPayDirectSubmit.string_3 = "";
			AliPayDirectSubmit.string_1 = AliPayDirectConfig.Key.Trim();
			AliPayDirectSubmit.string_2 = AliPayDirectConfig.Input_charset.Trim().ToLower();
			AliPayDirectSubmit.string_3 = AliPayDirectConfig.Sign_type.Trim().ToUpper();
		}
		private static string smethod_0(Dictionary<string, string> dictionary_0)
		{
			string prestr = AliPayDirectCore.CreateLinkString(dictionary_0);
			string text = AliPayDirectSubmit.string_3;
			string result;
			if (text != null && text == "MD5")
			{
				result = AliPayDirectMD5.Sign(prestr, AliPayDirectSubmit.string_1, AliPayDirectSubmit.string_2);
			}
			else
			{
				result = "";
			}
			return result;
		}
		private static Dictionary<string, string> smethod_1(SortedDictionary<string, string> sortedDictionary_0)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary = AliPayDirectCore.FilterPara(sortedDictionary_0);
			string value = AliPayDirectSubmit.smethod_0(dictionary);
			dictionary.Add("sign", value);
			dictionary.Add("sign_type", AliPayDirectSubmit.string_3);
			return dictionary;
		}
		private static string smethod_2(SortedDictionary<string, string> sortedDictionary_0, Encoding encoding_0)
		{
			Dictionary<string, string> dicArray = new Dictionary<string, string>();
			dicArray = AliPayDirectSubmit.smethod_1(sortedDictionary_0);
			return AliPayDirectCore.CreateLinkStringUrlencode(dicArray, encoding_0);
		}
		public static string BuildRequest(SortedDictionary<string, string> sParaTemp, string strMethod, string strButtonValue)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary = AliPayDirectSubmit.smethod_1(sParaTemp);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"<form id='alipaysubmit' name='alipaysubmit' action='",
				AliPayDirectSubmit.string_0,
				"_input_charset=",
				AliPayDirectSubmit.string_2,
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
			Encoding encoding = Encoding.GetEncoding(AliPayDirectSubmit.string_2);
			string s = AliPayDirectSubmit.smethod_2(sParaTemp, encoding);
			byte[] bytes = encoding.GetBytes(s);
			string requestUriString = AliPayDirectSubmit.string_0 + "_input_charset=" + AliPayDirectSubmit.string_2;
			string result = "";
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
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
			dictionary = AliPayDirectSubmit.smethod_1(sParaTemp);
			string requestUriString = AliPayDirectSubmit.string_0 + "_input_charset=" + AliPayDirectSubmit.string_2;
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
			Encoding encoding = Encoding.GetEncoding(AliPayDirectSubmit.string_2);
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
				AliPayDirectSubmit.string_0,
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
