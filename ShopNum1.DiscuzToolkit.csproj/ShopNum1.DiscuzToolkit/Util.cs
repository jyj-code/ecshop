using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class Util
	{
		private const string string_0 = "\r\n";
		private static Dictionary<int, XmlSerializer> dictionary_0 = new Dictionary<int, XmlSerializer>();
		private string string_1;
		private string string_2;
		private string string_3;
		private bool bool_0;
		private static XmlSerializer ErrorSerializer
		{
			get
			{
				return Util.GetSerializer(typeof(Error));
			}
		}
		public bool UseJson
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		internal string SharedSecret
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		internal string ApiKey
		{
			get
			{
				return this.string_1;
			}
		}
		internal string Url
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public Util(string api_key, string secret, string string_4)
		{
			this.string_1 = api_key;
			this.string_2 = secret;
			this.string_3 = string_4;
		}
		public T GetResponse<T>(string method_name, params DiscuzParam[] parameters)
		{
			DiscuzParam[] array = this.Sign(method_name, parameters);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append("&");
				}
				stringBuilder.Append(array[i].ToEncodedString());
			}
			byte[] responseBytes = Util.GetResponseBytes(this.Url, method_name, stringBuilder.ToString());
			XmlSerializer serializer = Util.GetSerializer(typeof(T));
			T result;
			try
			{
				T t = (T)((object)serializer.Deserialize(new MemoryStream(responseBytes)));
				result = t;
			}
			catch
			{
				Error error = (Error)Util.ErrorSerializer.Deserialize(new MemoryStream(responseBytes));
				File.AppendAllText(HttpContext.Current.Request.PhysicalApplicationPath + "\\log\\logDiscuz.txt", string.Format("{0}:{1}，错误代码:{2}\r\n", DateTime.Now.ToString(), error.ErrorMsg, error.ErrorCode));
				throw new DiscuzException(error.ErrorCode, error.ErrorMsg);
			}
			return result;
		}
		public static byte[] GetResponseBytes(string apiUrl, string method_name, string postData)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = (long)postData.Length;
			httpWebRequest.Timeout = 20000;
			HttpWebResponse httpWebResponse = null;
			byte[] bytes;
			try
			{
				StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
				streamWriter.Write(postData);
				if (streamWriter != null)
				{
					streamWriter.Close();
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
				{
					bytes = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
				}
			}
			finally
			{
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
			}
			return bytes;
		}
		private string method_0(string string_4, params DiscuzParam[] discuzParam_0)
		{
			DiscuzParam[] array = this.Sign(string_4, discuzParam_0);
			StringBuilder stringBuilder = new StringBuilder(this.Url);
			for (int i = 0; i < array.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append("&");
				}
				stringBuilder.Append(array[i].ToString());
			}
			return stringBuilder.ToString();
		}
		public static XmlSerializer GetSerializer(Type type_0)
		{
			int hashCode = type_0.GetHashCode();
			if (!Util.dictionary_0.ContainsKey(hashCode))
			{
				Util.dictionary_0.Add(hashCode, new XmlSerializer(type_0));
			}
			return Util.dictionary_0[hashCode];
		}
		public DiscuzParam[] Sign(string method_name, DiscuzParam[] parameters)
		{
			List<DiscuzParam> list = new List<DiscuzParam>(parameters);
			list.Add(DiscuzParam.Create("method", method_name));
			list.Add(DiscuzParam.Create("api_key", this.string_1));
			list.Add(DiscuzParam.Create("call_id", DateTime.Now.Ticks));
			list.Sort();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DiscuzParam current in list)
			{
				if (!string.IsNullOrEmpty(current.Value))
				{
					stringBuilder.Append(current.ToString());
				}
			}
			stringBuilder.Append(this.string_2);
			byte[] array = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
			StringBuilder stringBuilder2 = new StringBuilder();
			byte[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				byte b = array2[i];
				stringBuilder2.Append(b.ToString("x2"));
			}
			list.Add(DiscuzParam.Create("sig", stringBuilder2.ToString()));
			return list.ToArray();
		}
		public static int GetIntFromString(string input)
		{
			int result;
			try
			{
				result = int.Parse(input);
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public static bool GetBoolFromString(string input)
		{
			bool result;
			try
			{
				result = bool.Parse(input);
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static string RemoveJsonNull(string json)
		{
			json = Regex.Replace(json, ",\"\\w*\":null", string.Empty);
			json = Regex.Replace(json, "\"\\w*\":null,", string.Empty);
			json = Regex.Replace(json, "\"\\w*\":null", string.Empty);
			json = Regex.Replace(json, ",\"\\w*\":0", string.Empty);
			json = Regex.Replace(json, "\"\\w*\":0,", string.Empty);
			return json;
		}
	}
}
