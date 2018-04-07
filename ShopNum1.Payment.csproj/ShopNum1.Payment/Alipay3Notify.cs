using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.Payment
{
	public class Alipay3Notify
	{
		private string string_0 = "";
		private string string_1 = "";
		private string string_2 = "";
		private string string_3 = "";
		private string string_4 = "";
		private string string_5 = "";
		private string string_6 = "";
		private string string_7 = "";
		private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();
		private string string_8 = "";
		public string Mysign
		{
			get
			{
				return this.string_6;
			}
		}
		public string ResponseTxt
		{
			get
			{
				return this.string_7;
			}
		}
		public string PreSignStr
		{
			get
			{
				return this.string_8;
			}
		}
		public Alipay3Notify(SortedDictionary<string, string> inputPara, string notify_id, string partner, string string_9, string input_charset, string sign_type, string transport)
		{
			this.string_1 = transport;
			if (this.string_1 == "https")
			{
				this.string_0 = "https://www.alipay.com/cooperate/gateway.do?";
			}
			else
			{
				this.string_0 = "http://notify.alipay.com/trade/notify_query.do?";
			}
			this.string_2 = partner.Trim();
			this.string_3 = string_9.Trim();
			this.string_4 = input_charset;
			this.string_5 = sign_type.ToUpper();
			this.dictionary_0 = Alipay3Notify.Para_filter(inputPara);
			this.string_8 = Alipay3Notify.Create_linkstring(this.dictionary_0);
			this.string_6 = Alipay3Notify.Build_mysign(this.dictionary_0, this.string_3, this.string_5, this.string_4);
			this.string_7 = this.method_0(notify_id);
		}
		private string method_0(string string_9)
		{
			string string_10;
			if (this.string_1 == "https")
			{
				string_10 = string.Concat(new string[]
				{
					this.string_0,
					"service=notify_verify&partner=",
					this.string_2,
					"&notify_id=",
					string_9
				});
			}
			else
			{
				string_10 = string.Concat(new string[]
				{
					this.string_0,
					"partner=",
					this.string_2,
					"&notify_id=",
					string_9
				});
			}
			return this.method_1(string_10, 120000);
		}
		private string method_1(string string_9, int int_0)
		{
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_9);
				httpWebRequest.Timeout = int_0;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.Default);
				StringBuilder stringBuilder = new StringBuilder();
				while (-1 != streamReader.Peek())
				{
					stringBuilder.Append(streamReader.ReadLine());
				}
				result = stringBuilder.ToString();
			}
			catch (Exception ex)
			{
				result = "错误：" + ex.Message;
			}
			return result;
		}
		public static Dictionary<string, string> Para_filter(SortedDictionary<string, string> dicArrayPre)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> current in dicArrayPre)
			{
				if (current.Key.ToLower() != "sign" && current.Key.ToLower() != "sign_type" && current.Value != "")
				{
					dictionary.Add(current.Key.ToLower(), current.Value);
				}
			}
			return dictionary;
		}
		public static string Create_linkstring(Dictionary<string, string> dicArray)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> current in dicArray)
			{
				stringBuilder.Append(current.Key + "=" + current.Value + "&");
			}
			return stringBuilder.ToString();
		}
		public static string Build_mysign(Dictionary<string, string> dicArray, string string_9, string sign_type, string _input_charset)
		{
			string text = Alipay3Notify.Create_linkstring(dicArray);
			int length = text.Length;
			if (text != "")
			{
				text = text.Substring(0, length - 1);
			}
			text += string_9;
			return Alipay3Notify.Sign(text, sign_type, _input_charset);
		}
		public static string Sign(string prestr, string sign_type, string _input_charset)
		{
			StringBuilder stringBuilder = new StringBuilder(32);
			if (sign_type.ToUpper() == "MD5")
			{
				MD5 mD = new MD5CryptoServiceProvider();
				byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
				}
			}
			return stringBuilder.ToString();
		}
	}
}
