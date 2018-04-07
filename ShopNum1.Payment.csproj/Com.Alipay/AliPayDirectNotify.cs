using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
namespace Com.Alipay
{
	public class AliPayDirectNotify
	{
		private string string_0 = "";
		private string string_1 = "";
		private string string_2 = "";
		private string string_3 = "";
		private string string_4 = "https://mapi.alipay.com/gateway.do?service=notify_verify&";
		public AliPayDirectNotify()
		{
			this.string_0 = AliPayDirectConfig.Partner.Trim();
			this.string_1 = AliPayDirectConfig.Key.Trim();
			this.string_2 = AliPayDirectConfig.Input_charset.Trim().ToLower();
			this.string_3 = AliPayDirectConfig.Sign_type.Trim().ToUpper();
		}
		public bool Verify(SortedDictionary<string, string> inputPara, string notify_id, string sign)
		{
			bool flag = this.method_1(inputPara, sign);
			string a = "true";
			if (notify_id != null && notify_id != "")
			{
				a = this.method_2(notify_id);
			}
			return a == "true" && flag;
		}
		private string method_0(SortedDictionary<string, string> sortedDictionary_0)
		{
			Dictionary<string, string> dicArray = new Dictionary<string, string>();
			dicArray = AliPayDirectCore.FilterPara(sortedDictionary_0);
			return AliPayDirectCore.CreateLinkString(dicArray);
		}
		private bool method_1(SortedDictionary<string, string> sortedDictionary_0, string string_5)
		{
			Dictionary<string, string> dicArray = new Dictionary<string, string>();
			dicArray = AliPayDirectCore.FilterPara(sortedDictionary_0);
			string prestr = AliPayDirectCore.CreateLinkString(dicArray);
			bool result = false;
			if (string_5 != null && string_5 != "")
			{
				string text = this.string_3;
				if (text != null && text == "MD5")
				{
					result = AliPayDirectMD5.Verify(prestr, string_5, this.string_1, this.string_2);
				}
			}
			return result;
		}
		private string method_2(string string_5)
		{
			string string_6 = string.Concat(new string[]
			{
				this.string_4,
				"partner=",
				this.string_0,
				"&notify_id=",
				string_5
			});
			return this.method_3(string_6, 120000);
		}
		private string method_3(string string_5, int int_0)
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
