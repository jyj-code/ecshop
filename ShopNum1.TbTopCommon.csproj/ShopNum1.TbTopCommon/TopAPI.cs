using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace ShopNum1.TbTopCommon
{
	public class TopAPI
	{
		public static string RestUrl = string.Empty;
		protected static string error_rspXML = "<error_response>\r\n<args list=\"true\"><arg><key>post</key><value>{2}</value></arg></args>\r\n<code>{0}</code>\r\n<msg>{1}</msg>\r\n<sub_code></sub_code>\r\n<sub_msg></sub_msg>\r\n</error_response>";
		public TopAPI()
		{
			if (ConfigurationManager.AppSettings["IsSandBox"] == "1")
			{
				TopAPI.RestUrl = ConfigurationManager.AppSettings["TopApiSandUrl"];
			}
			else
			{
				TopAPI.RestUrl = ConfigurationManager.AppSettings["TopApiUrl"];
			}
		}
		protected static string CustomErrorXML(string code, Exception exception_0)
		{
			return string.Format(TopAPI.error_rspXML, code, exception_0.Message.Replace("\"", "'").Replace("'", "'").Replace("&", "＆"), exception_0.StackTrace.Replace("\"", "'").Replace("'", "'").Replace("<", "＜").Replace(">", "＞").Replace("&", "＆"));
		}
		protected static string PostData(IDictionary<string, string> parameters)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			IEnumerator<KeyValuePair<string, string>> enumerator = parameters.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, string> current = enumerator.Current;
				string key = current.Key;
				current = enumerator.Current;
				string value = current.Value;
				if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
				{
					if (flag)
					{
						stringBuilder.Append("&");
					}
					stringBuilder.Append(key);
					stringBuilder.Append("=");
					stringBuilder.Append(Uri.EscapeDataString(value));
					flag = true;
				}
			}
			stringBuilder.ToString();
			return stringBuilder.ToString();
		}
		protected static string CreateSign(IDictionary<string, string> parameters, string secret)
		{
			parameters.Remove("sign");
			IDictionary<string, string> dictionary = new SortedDictionary<string, string>(parameters);
			IEnumerator<KeyValuePair<string, string>> enumerator = dictionary.GetEnumerator();
			StringBuilder stringBuilder = new StringBuilder(secret);
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, string> current = enumerator.Current;
				string key = current.Key;
				current = enumerator.Current;
				string value = current.Value;
				if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
				{
					stringBuilder.Append(key).Append(value);
				}
			}
			stringBuilder.Append(secret);
			MD5 mD = MD5.Create();
			byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
			StringBuilder stringBuilder2 = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].ToString("X");
				if (text.Length == 1)
				{
					stringBuilder2.Append("0");
				}
				stringBuilder2.Append(text);
			}
			return stringBuilder2.ToString();
		}
		public static string Post(string method, IDictionary<string, string> parameters)
		{
			return TopAPI.Post(TopAPI.RestUrl, method, "", parameters);
		}
		public static string Post(string method, string session, IDictionary<string, string> parameters)
		{
			return TopAPI.Post(TopAPI.RestUrl, method, session, parameters);
		}
		public static string Post(string string_0, string method, string session, IDictionary<string, string> param)
		{
			string appKey = TopConfig.AppKey;
			string appSecret = TopConfig.AppSecret;
			return TopAPI.Post(string_0, appKey, appSecret, method, session, param);
		}
		public static string Post(string string_0, string appkey, string appSecret, string method, string session, IDictionary<string, string> param)
		{
			string result;
			try
			{
				param.Add("app_key", appkey);
				param.Add("method", method);
				if (appkey != "test")
				{
					param.Add("session", session);
				}
				param.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				param.Add("format", "xml");
				param.Add("v", "2.0");
				param.Add("access_token", HttpContext.Current.Session["access_token"].ToString());
				string input = string.Empty;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = "SpaceTimeApp2.0";
				httpWebRequest.Timeout = 300000;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
				byte[] bytes = Encoding.UTF8.GetBytes(TopAPI.PostData(param));
				Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Encoding encoding = Encoding.GetEncoding(httpWebResponse.CharacterSet);
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, encoding);
				input = streamReader.ReadToEnd();
				if (streamReader != null)
				{
					streamReader.Close();
				}
				if (responseStream != null)
				{
					responseStream.Close();
				}
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				result = Regex.Replace(input, "[\\x00-\\x08\\x0b-\\x0c\\x0e-\\x1f]", "");
			}
			catch (Exception exception_)
			{
				result = TopAPI.CustomErrorXML("8001", exception_);
			}
			return result;
		}
		public static string Post(string method, string session, IDictionary<string, string> textParams, IDictionary<string, FileItem> fileParams)
		{
			string appKey = TopConfig.AppKey;
			string appSecret = TopConfig.AppSecret;
			return TopAPI.Post(TopAPI.RestUrl, appKey, appSecret, method, session, textParams, fileParams);
		}
		public static string Post(string string_0, string appkey, string appSecret, string method, string session, IDictionary<string, string> textParams, IDictionary<string, FileItem> fileParams)
		{
			string result;
			try
			{
				if (fileParams == null || fileParams.Count == 0)
				{
					result = TopAPI.Post(string_0, appkey, appSecret, method, session, textParams);
				}
				else
				{
					textParams.Add("app_key", appkey);
					textParams.Add("method", method);
					textParams.Add("session", session);
					textParams.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
					textParams.Add("format", "xml");
					textParams.Add("v", "2.0");
					textParams.Add("sign_method", "md5");
					textParams.Add("sign", TopAPI.CreateSign(textParams, appSecret));
					string input = string.Empty;
					ServicePointManager.DefaultConnectionLimit = 20;
					string str = DateTime.Now.Ticks.ToString("X");
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
					httpWebRequest.Method = "POST";
					httpWebRequest.KeepAlive = true;
					httpWebRequest.UserAgent = "SpaceTimeApp2.0";
					httpWebRequest.Timeout = 600000;
					httpWebRequest.ContentType = "multipart/form-data;charset=utf-8;boundary=" + str;
					Stream requestStream = httpWebRequest.GetRequestStream();
					byte[] bytes = Encoding.UTF8.GetBytes("\r\n--" + str + "\r\n");
					byte[] bytes2 = Encoding.UTF8.GetBytes("\r\n--" + str + "--\r\n");
					string text = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
					IEnumerator<KeyValuePair<string, string>> enumerator = textParams.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string arg_1A8_0 = text;
						KeyValuePair<string, string> current = enumerator.Current;
						object arg_1A8_1 = current.Key;
						current = enumerator.Current;
						string s = string.Format(arg_1A8_0, arg_1A8_1, current.Value);
						byte[] bytes3 = Encoding.UTF8.GetBytes(s);
						requestStream.Write(bytes, 0, bytes.Length);
						requestStream.Write(bytes3, 0, bytes3.Length);
					}
					string format = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
					IEnumerator<KeyValuePair<string, FileItem>> enumerator2 = fileParams.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						KeyValuePair<string, FileItem> current2 = enumerator2.Current;
						string key = current2.Key;
						current2 = enumerator2.Current;
						FileItem value = current2.Value;
						string s2 = string.Format(format, key, value.GetFileName(), value.GetMimeType());
						byte[] bytes3 = Encoding.UTF8.GetBytes(s2);
						requestStream.Write(bytes, 0, bytes.Length);
						requestStream.Write(bytes3, 0, bytes3.Length);
						byte[] content = value.GetContent();
						requestStream.Write(content, 0, content.Length);
					}
					requestStream.Write(bytes2, 0, bytes2.Length);
					requestStream.Close();
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					Encoding encoding = Encoding.GetEncoding(httpWebResponse.CharacterSet);
					Stream responseStream = httpWebResponse.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream, encoding);
					input = streamReader.ReadToEnd();
					if (streamReader != null)
					{
						streamReader.Close();
					}
					if (responseStream != null)
					{
						responseStream.Close();
					}
					if (httpWebResponse != null)
					{
						httpWebResponse.Close();
					}
					result = Regex.Replace(input, "[\\x00-\\x08\\x0b-\\x0c\\x0e-\\x1f]", "");
				}
			}
			catch (Exception exception_)
			{
				result = TopAPI.CustomErrorXML("8004", exception_);
			}
			return result;
		}
		public static string GetItemcatsPost(string appkey, string appSecret, string method, IDictionary<string, string> param)
		{
			string result;
			try
			{
				string restUrl = TopAPI.RestUrl;
				param.Add("app_key", appkey);
				param.Add("method", method);
				param.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				param.Add("format", "xml");
				param.Add("v", "2.0");
				param.Add("sign_method", "md5");
				param.Add("sign", TopAPI.CreateSign(param, appSecret));
				string input = string.Empty;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(restUrl);
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = "SpaceTimeApp2.0";
				httpWebRequest.Timeout = 30000;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
				byte[] bytes = Encoding.UTF8.GetBytes(TopAPI.PostData(param));
				Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Encoding encoding = Encoding.GetEncoding(httpWebResponse.CharacterSet);
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, encoding);
				input = streamReader.ReadToEnd();
				if (streamReader != null)
				{
					streamReader.Close();
				}
				if (responseStream != null)
				{
					responseStream.Close();
				}
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				result = Regex.Replace(input, "[\\x00-\\x08\\x0b-\\x0c\\x0e-\\x1f]", "");
			}
			catch (Exception exception_)
			{
				result = TopAPI.CustomErrorXML("8001", exception_);
			}
			return result;
		}
	}
}
