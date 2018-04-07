using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
namespace ShopNum1.Second
{
	public class ShopNum1_Alipay_notify
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
		private ShopNum1_Alipay_function shopNum1_Alipay_function_0 = new ShopNum1_Alipay_function();
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
		public ShopNum1_Alipay_notify(SortedDictionary<string, string> inputPara, string notify_id, string partner, string string_9, string input_charset, string sign_type, string transport)
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
			this.dictionary_0 = this.shopNum1_Alipay_function_0.Para_filter(inputPara);
			this.string_8 = this.shopNum1_Alipay_function_0.Create_linkstring(this.dictionary_0);
			this.string_6 = this.shopNum1_Alipay_function_0.Build_mysign(this.dictionary_0, this.string_3, this.string_5, this.string_4);
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
	}
}
