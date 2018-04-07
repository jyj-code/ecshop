using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
namespace Com.Alipay
{
	public class Notify
	{
		private string string_0 = "";
		private string string_1 = "";
		private string string_2 = "";
		private string string_3 = "";
		private string string_4 = "https://mapi.alipay.com/gateway.do?service=notify_verify&";
		public Notify()
		{
			this.string_0 = Config.Partner.Trim();
			this.string_1 = Config.Key.Trim();
			this.string_2 = Config.Input_charset.Trim().ToLower();
			this.string_3 = Config.Sign_type.Trim().ToUpper();
		}
		public bool Verify(SortedDictionary<string, string> inputPara, string notify_id, string sign)
		{
			bool flag = this.method_1(inputPara, sign);
			string a = "true";
			if (notify_id != null && notify_id != "")
			{
				a = this.method_3(notify_id);
			}
			return a == "true" && flag;
		}
		public bool Verify(SortedDictionary<string, string> inputPara, string notify_id, string sign, string MD5Sign)
		{
			bool flag = this.method_2(inputPara, sign, MD5Sign);
			string a = "true";
			if (notify_id != null && notify_id != "")
			{
				a = this.method_3(notify_id);
			}
			return a == "true" && flag;
		}
		private string method_0(SortedDictionary<string, string> sortedDictionary_0)
		{
			Dictionary<string, string> dicArray = new Dictionary<string, string>();
			dicArray = Core.FilterPara(sortedDictionary_0);
			return Core.CreateLinkString(dicArray);
		}
		private bool method_1(SortedDictionary<string, string> sortedDictionary_0, string string_5)
		{
			Dictionary<string, string> dicArray = new Dictionary<string, string>();
			dicArray = Core.FilterPara(sortedDictionary_0);
			string prestr = Core.CreateLinkString(dicArray);
			bool result = false;
			if (string_5 != null && string_5 != "")
			{
				string text = this.string_3;
				if (text != null && text == "MD5")
				{
					result = AlipayMD5.Verify(prestr, string_5, this.string_1, this.string_2);
				}
			}
			return result;
		}
		private bool method_2(SortedDictionary<string, string> sortedDictionary_0, string string_5, string string_6)
		{
			Dictionary<string, string> dicArray = new Dictionary<string, string>();
			dicArray = Core.FilterPara(sortedDictionary_0);
			string prestr = Core.CreateLinkString(dicArray);
			bool result = false;
			if (string_5 != null && string_5 != "")
			{
				string text = this.string_3;
				if (text != null && text == "MD5")
				{
					result = AlipayMD5.Verify(prestr, string_5, string_6, this.string_2);
				}
			}
			return result;
		}
		private string method_3(string string_5)
		{
			string string_6 = string.Concat(new string[]
			{
				this.string_4,
				"partner=",
				this.string_0,
				"&notify_id=",
				string_5
			});
			return this.method_4(string_6, 120000);
		}
		private string method_4(string string_5, int int_0)
		{
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_5);
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
	}
}
