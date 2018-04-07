using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
namespace ShopNum1.Second
{
	public class ShopNum1_Alipay_function
	{
		public string Build_mysign(Dictionary<string, string> dicArray, string string_0, string sign_type, string _input_charset)
		{
			string text = this.Create_linkstring(dicArray);
			int length = text.Length;
			text = text.Substring(0, length - 1);
			text += string_0;
			return this.Sign(text, sign_type, _input_charset);
		}
		public string Create_linkstring(Dictionary<string, string> dicArray)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> current in dicArray)
			{
				stringBuilder.Append(current.Key + "=" + current.Value + "&");
			}
			return stringBuilder.ToString();
		}
		public Dictionary<string, string> Para_filter(SortedDictionary<string, string> dicArrayPre)
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
		public string Sign(string prestr, string sign_type, string _input_charset)
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
		public void log_result(string sPath, string sWord)
		{
			StreamWriter streamWriter = new StreamWriter(sPath, false, Encoding.Default);
			streamWriter.Write(sWord);
			streamWriter.Close();
		}
		public string Query_timestamp(string partner)
		{
			string url = "https://mapi.alipay.com/gateway.do?service=query_timestamp&partner=" + partner;
			XmlTextReader reader = new XmlTextReader(url);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(reader);
			return xmlDocument.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;
		}
	}
}
