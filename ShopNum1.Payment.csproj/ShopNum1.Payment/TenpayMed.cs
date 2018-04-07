using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.Payment
{
	public class TenpayMed
	{
		private const int int_0 = 2;
		private string string_0 = "";
		private int int_1 = 12;
		private int int_2 = 1;
		private string string_1 = "";
		private string string_2 = "";
		private int int_3 = 1;
		private int int_4 = 1;
		private int int_5 = 2;
		private string string_3 = "";
		private string string_4 = "";
		private string string_5 = "";
		private string string_6 = "2";
		private int int_6 = 1;
		private int int_7 = 1;
		private int int_8 = 0;
		private string string_7 = "";
		private int int_9 = 0;
		private string string_8 = "3";
		private string string_9 = "";
		private string string_10 = "";
		private string string_11 = "";
		private string string_12 = ConfigurationSettings.AppSettings["paygateurl"];
		private string string_13 = ConfigurationSettings.AppSettings["querygateurl"];
		private string string_14 = ConfigurationSettings.AppSettings["mch_returl"];
		private string string_15 = ConfigurationSettings.AppSettings["show_url"];
		private string string_16;
		private string string_17 = "";
		private string string_18 = "";
		public string Chnid
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public int Cmdno
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}
		public int Encode_type
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}
		public string Mch_desc
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public string Mch_name
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
		public int Mch_price
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}
		public int Mch_type
		{
			get
			{
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
			}
		}
		public int Need_buyerinfo
		{
			get
			{
				return this.int_5;
			}
			set
			{
				this.int_5 = value;
			}
		}
		public string Sign
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
		public string Seller
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public string Transport_desc
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public string Version
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}
		public int Total_fee
		{
			get
			{
				return this.int_6;
			}
			set
			{
				this.int_6 = value;
			}
		}
		public int Trade_price
		{
			get
			{
				return this.int_7;
			}
			set
			{
				this.int_7 = value;
			}
		}
		public int Transport_fee
		{
			get
			{
				return this.int_8;
			}
			set
			{
				this.int_8 = value;
			}
		}
		public string Mch_vno
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}
		public int Retcode
		{
			get
			{
				return this.int_9;
			}
			set
			{
				this.int_9 = value;
			}
		}
		public string Status
		{
			get
			{
				return this.string_8;
			}
			set
			{
				this.string_8 = value;
			}
		}
		public string Buyer_id
		{
			get
			{
				return this.string_9;
			}
			set
			{
				this.string_9 = value;
			}
		}
		public string Cft_tid
		{
			get
			{
				return this.string_10;
			}
			set
			{
				this.string_10 = value;
			}
		}
		public string Key
		{
			get
			{
				return this.string_11;
			}
			set
			{
				this.string_11 = value;
			}
		}
		public string Mch_returl
		{
			get
			{
				return this.string_14;
			}
			set
			{
				this.string_14 = value;
			}
		}
		public string Show_url
		{
			get
			{
				return this.string_15;
			}
			set
			{
				this.string_15 = value;
			}
		}
		public string Date
		{
			get
			{
				if (this.string_16 == null)
				{
					this.string_16 = DateTime.Now.ToString("yyyyMMdd");
				}
				return this.string_16;
			}
			set
			{
				if (value == null || value.Trim().Length != 8)
				{
					this.string_16 = DateTime.Now.ToString("yyyyMMdd");
				}
				else
				{
					try
					{
						string text = value.Trim();
						this.string_16 = DateTime.Parse(string.Concat(new string[]
						{
							text.Substring(0, 4),
							"-",
							text.Substring(4, 2),
							"-",
							text.Substring(6, 2)
						})).ToString("yyyyMMdd");
					}
					catch
					{
						this.string_16 = DateTime.Now.ToString("yyyyMMdd");
					}
				}
			}
		}
		public string Attach
		{
			get
			{
				return TenpayMed.smethod_1(this.string_17);
			}
			set
			{
				this.string_17 = TenpayMed.smethod_0(value);
			}
		}
		public string PayErrMsg
		{
			get
			{
				return this.string_18;
			}
		}
		private static string smethod_0(string string_19)
		{
			string result;
			if (string_19 == null || string_19.Trim() == "")
			{
				result = "";
			}
			else
			{
				result = string_19.Replace("%", "%25").Replace("=", "%3d").Replace("&", "%26").Replace("\"", "%22").Replace("?", "%3f").Replace("'", "%27").Replace(" ", "%20");
			}
			return result;
		}
		private static string smethod_1(string string_19)
		{
			string result;
			if (string_19 == null || string_19.Trim() == "")
			{
				result = "";
			}
			else
			{
				result = string_19.Replace("%3d", "=").Replace("%26", "&").Replace("%22", "\"").Replace("%3f", "?").Replace("%27", "'").Replace("%20", " ").Replace("%25", "%");
			}
			return result;
		}
		private static string smethod_2(string string_19)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(string_19);
			byte[] value = mD5CryptoServiceProvider.ComputeHash(bytes);
			string text = BitConverter.ToString(value);
			return text.Replace("-", "").ToUpper();
		}
		protected StringBuilder AddParameter(StringBuilder stringBuilder_0, string parameterName, string parameterValue)
		{
			StringBuilder result;
			if (parameterValue == null || "".Equals(parameterValue))
			{
				result = stringBuilder_0;
			}
			else
			{
				if ("".Equals(stringBuilder_0.ToString()))
				{
					stringBuilder_0.Append(parameterName);
					stringBuilder_0.Append("=");
					stringBuilder_0.Append(parameterValue);
				}
				else
				{
					stringBuilder_0.Append("&");
					stringBuilder_0.Append(parameterName);
					stringBuilder_0.Append("=");
					stringBuilder_0.Append(parameterValue);
				}
				result = stringBuilder_0;
			}
			return result;
		}
		public string GetPaySign()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.AddParameter(stringBuilder, "attach", this.string_17);
			this.AddParameter(stringBuilder, "chnid", this.string_0);
			this.AddParameter(stringBuilder, "cmdno", this.int_1.ToString());
			this.AddParameter(stringBuilder, "encode_type", this.int_2.ToString());
			this.AddParameter(stringBuilder, "mch_desc", this.string_1);
			this.AddParameter(stringBuilder, "mch_name", this.string_2);
			this.AddParameter(stringBuilder, "mch_price", this.int_3.ToString());
			this.AddParameter(stringBuilder, "mch_returl", this.string_14);
			this.AddParameter(stringBuilder, "mch_type", this.int_4.ToString());
			this.AddParameter(stringBuilder, "mch_vno", this.string_7);
			this.AddParameter(stringBuilder, "need_buyerinfo", this.int_5.ToString());
			this.AddParameter(stringBuilder, "seller", this.string_4);
			this.AddParameter(stringBuilder, "show_url", this.string_15);
			this.AddParameter(stringBuilder, "transport_desc", this.string_5);
			this.AddParameter(stringBuilder, "transport_fee", this.int_8.ToString());
			this.AddParameter(stringBuilder, "version", this.string_6);
			this.AddParameter(stringBuilder, "key", this.string_11);
			return TenpayMed.smethod_2(stringBuilder.ToString());
		}
		public string GetPayResultSign()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.AddParameter(stringBuilder, "attach", this.string_17);
			this.AddParameter(stringBuilder, "buyer_id", this.string_9);
			this.AddParameter(stringBuilder, "cft_tid", this.string_10.ToString());
			this.AddParameter(stringBuilder, "chnid", this.string_0.ToString());
			this.AddParameter(stringBuilder, "cmdno", this.int_1.ToString());
			this.AddParameter(stringBuilder, "mch_vno", this.string_7);
			this.AddParameter(stringBuilder, "retcode", this.int_9.ToString());
			this.AddParameter(stringBuilder, "seller", this.string_4);
			this.AddParameter(stringBuilder, "status", this.string_8.ToString());
			this.AddParameter(stringBuilder, "total_fee", this.int_6.ToString());
			this.AddParameter(stringBuilder, "trade_price", this.int_7.ToString());
			this.AddParameter(stringBuilder, "transport_fee", this.int_8.ToString());
			this.AddParameter(stringBuilder, "version", this.string_6);
			this.AddParameter(stringBuilder, "key", this.string_11);
			return TenpayMed.smethod_2(stringBuilder.ToString());
		}
		public bool GetPayUrl(out string string_19)
		{
			bool result;
			try
			{
				string paySign = this.GetPaySign();
				string_19 = string.Concat(new object[]
				{
					this.string_12,
					"?attach=",
					this.string_17,
					"&chnid=",
					this.string_0,
					"&cmdno=",
					this.int_1,
					"&encode_type=",
					this.int_2,
					"&mch_desc=",
					this.string_1,
					"&mch_name=",
					this.string_2,
					"&mch_price=",
					this.int_3,
					"&mch_returl=",
					this.string_14,
					"&mch_type=",
					this.int_4,
					"&mch_vno=",
					this.string_7,
					"&need_buyerinfo=",
					this.int_5,
					"&seller=",
					this.string_4,
					"&show_url=",
					this.string_15,
					"&transport_desc=",
					this.string_5,
					"&transport_fee=",
					this.int_8,
					"&version=",
					this.string_6,
					"&sign=",
					paySign
				});
				result = true;
			}
			catch (Exception ex)
			{
				string_19 = "创建URL时出错,错误信息:" + ex.Message;
				result = false;
			}
			return result;
		}
		public bool GetPayValueFromUrl(NameValueCollection querystring, out string errmsg)
		{
			bool result;
			if (querystring == null || querystring.Count == 0)
			{
				errmsg = "参数为空";
				result = false;
			}
			else if (querystring["cmdno"] == null || querystring["cmdno"].ToString().Trim() != this.int_1.ToString())
			{
				errmsg = "没有cmdno参数或cmdno参数不正确";
				result = false;
			}
			else if (querystring["seller"] == null)
			{
				errmsg = "没有seller参数";
				result = false;
			}
			else if (querystring["buyer_id"] == null)
			{
				errmsg = "没有buyer_id参数";
				result = false;
			}
			else if (querystring["cft_tid"] == null)
			{
				errmsg = "没有cft_tid参数";
				result = false;
			}
			else if (querystring["mch_vno"] == null)
			{
				errmsg = "没有mch_vno参数";
				result = false;
			}
			else if (querystring["retcode"] == null)
			{
				errmsg = "没有retcode参数";
				result = false;
			}
			else if (querystring["status"] == null)
			{
				errmsg = "没有status参数";
				result = false;
			}
			else if (querystring["total_fee"] == null)
			{
				errmsg = "没有total_fee参数";
				result = false;
			}
			else if (querystring["attach"] == null)
			{
				errmsg = "没有attach参数";
				result = false;
			}
			else if (querystring["trade_price"] == null)
			{
				errmsg = "没有trade_price参数";
				result = false;
			}
			else if (querystring["transport_fee"] == null)
			{
				errmsg = "没有transport_fee参数";
				result = false;
			}
			else if (querystring["chnid"] == null)
			{
				errmsg = "没有chnid参数";
				result = false;
			}
			else if (querystring["sign"] == null)
			{
				errmsg = "没有sign参数";
				result = false;
			}
			else
			{
				errmsg = "";
				try
				{
					this.string_17 = querystring["attach"];
					this.string_9 = querystring["buyer_id"];
					this.string_10 = querystring["cft_tid"];
					this.string_0 = querystring["chnid"];
					this.int_1 = int.Parse(querystring["cmdno"]);
					this.string_7 = querystring["mch_vno"];
					this.int_9 = int.Parse(querystring["retcode"]);
					this.string_4 = querystring["seller"];
					this.string_8 = querystring["status"];
					this.int_6 = int.Parse(querystring["total_fee"]);
					this.int_7 = int.Parse(querystring["trade_price"]);
					this.int_8 = int.Parse(querystring["transport_fee"]);
					this.string_6 = querystring["version"];
					string b = querystring["sign"];
					string payResultSign = this.GetPayResultSign();
					if (payResultSign != b)
					{
						errmsg = "验证签名失败";
						result = false;
					}
					else
					{
						result = true;
					}
				}
				catch (Exception ex)
				{
					errmsg = "解析参数出错:" + ex.Message;
					result = false;
				}
			}
			return result;
		}
	}
}
