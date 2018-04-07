using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
namespace ShopNum1.Payment
{
	public class Alipay3
	{
		private string string_0 = "";
		private string string_1 = "";
		private string string_2 = "";
		private string string_3 = "";
		private string string_4 = "";
		private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();
		public bool CreatUrl(string partner, string seller_email, string return_url, string notify_url, string show_url, string out_trade_no, string subject, string body, string total_fee, string paymethod, string defaultbank, string encrypt_key, string exter_invoke_ip, string extra_common_param, string buyer_email, string royalty_type, string royalty_parameters, string it_b_pay, string string_5, string input_charset, string sign_type, out string strUrl)
		{
			this.string_0 = "https://www.alipay.com/cooperate/gateway.do?";
			this.string_1 = string_5.Trim();
			this.string_2 = input_charset.ToLower();
			this.string_3 = sign_type.ToUpper();
			this.dictionary_0 = this.Para_filter(new SortedDictionary<string, string>
			{

				{
					"service",
					"create_direct_pay_by_user"
				},

				{
					"payment_type",
					"1"
				},

				{
					"partner",
					partner
				},

				{
					"seller_email",
					seller_email
				},

				{
					"return_url",
					return_url
				},

				{
					"notify_url",
					notify_url
				},

				{
					"_input_charset",
					this.string_2
				},

				{
					"show_url",
					show_url
				},

				{
					"out_trade_no",
					out_trade_no
				},

				{
					"subject",
					subject
				},

				{
					"body",
					""
				},

				{
					"total_fee",
					total_fee
				},

				{
					"paymethod",
					paymethod
				},

				{
					"defaultbank",
					defaultbank
				},

				{
					"anti_phishing_key",
					encrypt_key
				},

				{
					"exter_invoke_ip",
					exter_invoke_ip
				},

				{
					"extra_common_param",
					extra_common_param
				},

				{
					"buyer_email",
					buyer_email
				},

				{
					"royalty_type",
					royalty_type
				},

				{
					"royalty_parameters",
					royalty_parameters
				},

				{
					"it_b_pay",
					it_b_pay
				}
			});
			this.string_4 = this.Build_mysign(this.dictionary_0, this.string_1, this.string_3, this.string_2);
			strUrl = this.string_0;
			string text = Alipay3.Create_linkstring_urlencode(this.dictionary_0);
			strUrl = string.Concat(new string[]
			{
				strUrl,
				text,
				"sign=",
				this.string_4,
				"&sign_type=",
				this.string_3
			});
			return true;
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
		public string Build_mysign(Dictionary<string, string> dicArray, string string_5, string sign_type, string _input_charset)
		{
			string text = Alipay3.Create_linkstring(dicArray);
			int length = text.Length;
			text = text.Substring(0, length - 1);
			text += string_5;
			return Alipay3.Sign(text, sign_type, _input_charset);
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
		public static string Create_linkstring_urlencode(Dictionary<string, string> dicArray)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> current in dicArray)
			{
				stringBuilder.Append(current.Key + "=" + HttpUtility.UrlEncode(current.Value) + "&");
			}
			return stringBuilder.ToString();
		}
		public static string Query_timestamp(string partner)
		{
			string url = "https://mapi.alipay.com/gateway.do?service=query_timestamp&partner=" + partner;
			XmlTextReader reader = new XmlTextReader(url);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(reader);
			return xmlDocument.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;
		}
	}
}
