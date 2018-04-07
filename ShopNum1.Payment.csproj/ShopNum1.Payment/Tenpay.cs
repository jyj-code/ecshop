using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace ShopNum1.Payment
{
	public class Tenpay
	{
		private const int int_0 = 1;
		private const int int_1 = 2;
		public const int PAYOK = 0;
		public const int PAYSPERROR = 1;
		public const int PAYMD5ERROR = 2;
		public const int PAYERROR = 3;
		private string string_0 = "";
		private string string_1 = "";
		private string string_2 = "https://www.tenpay.com/cgi-bin/v1.0/pay_gate.cgi";
		private string string_3 = "http://portal.tenpay.com/cfbiportal/cgi-bin/cfbiqueryorder.cgi";
		private string string_4 = "";
		private string string_5 = "http://davidzhu-pc/tenpaymd5/queryresult.aspx";
		private int int_2 = 1;
		private string string_6;
		private string string_7 = "";
		private long long_0 = 0L;
		private string string_8 = "";
		private string string_9 = "";
		private string string_10 = "";
		private string string_11 = "";
		private string string_12 = Tenpay.getRealIp();
		private int int_3;
		private string string_13 = "";
		public string Bargainor_id
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
		public string Key
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
		public string Paygateurl
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
		public string Querygateurl
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
		public string Return_url
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
		public string Queryreturn_url
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
		public string Date
		{
			get
			{
				if (this.string_6 == null)
				{
					this.string_6 = DateTime.Now.ToString("yyyyMMdd");
				}
				return this.string_6;
			}
			set
			{
				if (value == null || value.Trim().Length != 8)
				{
					this.string_6 = DateTime.Now.ToString("yyyyMMdd");
				}
				else
				{
					try
					{
						string text = value.Trim();
						this.string_6 = DateTime.Parse(string.Concat(new string[]
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
						this.string_6 = DateTime.Now.ToString("yyyyMMdd");
					}
				}
			}
		}
		public string Sp_billno
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
		public long Total_fee
		{
			get
			{
				return this.long_0;
			}
			set
			{
				this.long_0 = value;
			}
		}
		public string Transaction_id
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
		public string Desc
		{
			get
			{
				return Tenpay.smethod_1(this.string_9);
			}
			set
			{
				this.string_9 = Tenpay.smethod_0(value);
			}
		}
		public string Attach
		{
			get
			{
				return Tenpay.smethod_1(this.string_10);
			}
			set
			{
				this.string_10 = Tenpay.smethod_0(value);
			}
		}
		public string Purchaser_id
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
		public string Spbill_create_ip
		{
			get
			{
				return this.string_12;
			}
			set
			{
				this.string_12 = value;
			}
		}
		public int Pay_Result
		{
			get
			{
				return this.int_3;
			}
		}
		public string PayResultStr
		{
			get
			{
				string result;
				switch (this.int_3)
				{
				case 0:
					result = "支付成功";
					break;
				case 1:
					result = "商户号错";
					break;
				case 2:
					result = "签名错误";
					break;
				case 3:
					result = "支付失败";
					break;
				default:
					result = "未知类型(" + this.int_3 + ")";
					break;
				}
				return result;
			}
		}
		public string PayErrMsg
		{
			get
			{
				return this.string_13;
			}
		}
		public uint UnixStamp()
		{
			return Convert.ToUInt32((DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds);
		}
		public static string getRealIp()
		{
			string result;
			if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
			{
				result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
			}
			else
			{
				result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
			}
			return result;
		}
		private static string smethod_0(string string_14)
		{
			string result;
			if (string_14 == null || string_14.Trim() == "")
			{
				result = "";
			}
			else
			{
				result = string_14.Replace("%", "%25").Replace("=", "%3d").Replace("&", "%26").Replace("\"", "%22").Replace("?", "%3f").Replace("'", "%27").Replace(" ", "%20");
			}
			return result;
		}
		public static string UrlEncode(string instr, string charset)
		{
			string result;
			if (instr == null || instr.Trim() == "")
			{
				result = "";
			}
			else
			{
				string text;
				try
				{
					text = HttpUtility.UrlEncode(instr, Encoding.GetEncoding(charset));
				}
				catch (Exception)
				{
					text = HttpUtility.UrlEncode(instr, Encoding.GetEncoding("GB2312"));
				}
				result = text;
			}
			return result;
		}
		private static string smethod_1(string string_14)
		{
			string result;
			if (string_14 == null || string_14.Trim() == "")
			{
				result = "";
			}
			else
			{
				result = string_14.Replace("%3d", "=").Replace("%26", "&").Replace("%22", "\"").Replace("%3f", "?").Replace("%27", "'").Replace("%20", " ").Replace("%25", "%");
			}
			return result;
		}
		public static string UrlDecode(string instr, string charset)
		{
			string result;
			if (instr == null || instr.Trim() == "")
			{
				result = "";
			}
			else
			{
				string text;
				try
				{
					text = HttpUtility.UrlDecode(instr, Encoding.GetEncoding(charset));
				}
				catch (Exception)
				{
					text = HttpUtility.UrlDecode(instr, Encoding.GetEncoding("GB2312"));
				}
				result = text;
			}
			return result;
		}
		public static string GetMD5(string encypStr, string charset)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes;
			try
			{
				bytes = Encoding.GetEncoding(charset).GetBytes(encypStr);
			}
			catch (Exception)
			{
				bytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
			}
			byte[] value = mD5CryptoServiceProvider.ComputeHash(bytes);
			string text = BitConverter.ToString(value);
			return text.Replace("-", "").ToUpper();
		}
		private string method_0()
		{
			string text = string.Concat(new object[]
			{
				"cmdno=",
				1,
				"&date=",
				this.Date,
				"&bargainor_id=",
				this.string_0,
				"&transaction_id=",
				this.Transaction_id,
				"&sp_billno=",
				this.string_7,
				"&total_fee=",
				this.long_0,
				"&fee_type=",
				this.int_2,
				"&return_url=",
				this.string_4,
				"&attach=",
				this.Attach
			});
			if (this.string_12 != "")
			{
				text = text + "&spbill_create_ip=" + this.string_12;
			}
			text = text + "&key=" + this.string_1;
			return Tenpay.GetMD5(text, this.getCharset());
		}
		private string method_1()
		{
			string encypStr = string.Concat(new object[]
			{
				"cmdno=",
				1,
				"&pay_result=",
				this.int_3,
				"&date=",
				this.string_6,
				"&transaction_id=",
				this.string_8,
				"&sp_billno=",
				this.string_7,
				"&total_fee=",
				this.long_0,
				"&fee_type=",
				this.int_2,
				"&attach=",
				this.string_10,
				"&key=",
				this.string_1
			});
			return Tenpay.GetMD5(encypStr, this.getCharset());
		}
		public bool GetPayUrl(out string string_14)
		{
			bool result;
			try
			{
				string str = this.method_0();
				string_14 = string.Concat(new object[]
				{
					"?attach=",
					this.Attach,
					"&bank_type=0&bargainor_id=",
					this.string_0,
					"&cmdno=",
					1,
					"&cs=gb2312&date=",
					this.Date,
					"&desc=",
					TenpayUtil.UrlEncode(this.string_9, this.getCharset()),
					"&fee_type=",
					this.int_2,
					"&return_url=",
					TenpayUtil.UrlEncode(this.string_4, this.getCharset())
				});
				string_14 = string_14 + "&sign=" + str;
				string_14 = string_14 + "&sp_billno=" + this.string_7;
				string_14 = string_14 + "&spbill_create_ip=" + Tenpay.getRealIp();
				string_14 = string_14 + "&total_fee=" + this.long_0;
				string_14 = string_14 + "&transaction_id=" + this.Transaction_id;
				string_14 = this.string_2 + string_14;
				result = true;
			}
			catch (Exception ex)
			{
				string_14 = "创建URL时出错,错误信息:" + ex.Message;
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
			else if (querystring["cmdno"] == null || querystring["cmdno"].ToString().Trim() != 1.ToString())
			{
				errmsg = "没有cmdno参数或cmdno参数不正确";
				result = false;
			}
			else if (querystring["pay_result"] == null)
			{
				errmsg = "没有pay_result参数";
				result = false;
			}
			else if (querystring["date"] == null)
			{
				errmsg = "没有date参数";
				result = false;
			}
			else if (querystring["pay_info"] == null)
			{
				errmsg = "没有pay_info参数";
				result = false;
			}
			else if (querystring["bargainor_id"] == null)
			{
				errmsg = "没有bargainor_id参数";
				result = false;
			}
			else if (querystring["transaction_id"] == null)
			{
				errmsg = "没有transaction_id参数";
				result = false;
			}
			else if (querystring["sp_billno"] == null)
			{
				errmsg = "没有sp_billno参数";
				result = false;
			}
			else if (querystring["total_fee"] == null)
			{
				errmsg = "没有total_fee参数";
				result = false;
			}
			else if (querystring["fee_type"] == null)
			{
				errmsg = "没有fee_type参数";
				result = false;
			}
			else if (querystring["attach"] == null)
			{
				errmsg = "没有attach参数";
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
					this.int_3 = int.Parse(querystring["pay_result"].Trim());
					this.string_13 = Tenpay.smethod_1(querystring["pay_info"].Trim());
					this.Date = querystring["date"];
					this.string_8 = querystring["transaction_id"];
					this.string_7 = querystring["sp_billno"];
					this.long_0 = long.Parse(querystring["total_fee"]);
					this.int_2 = int.Parse(querystring["fee_type"]);
					this.string_10 = querystring["attach"];
					if (querystring["bargainor_id"] != this.string_0)
					{
						this.int_3 = 1;
						result = true;
					}
					else
					{
						string b = querystring["sign"];
						string a = this.method_1();
						if (a != b)
						{
							this.int_3 = 2;
						}
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
		public void InitQueryParam(string adate, string atransaction_id, string asp_billno, string aattach)
		{
			this.Date = adate;
			this.Sp_billno = asp_billno;
			this.Transaction_id = atransaction_id;
			this.Attach = aattach;
		}
		private string method_2()
		{
			string encypStr = string.Concat(new object[]
			{
				"cmdno=",
				2,
				"&date=",
				this.string_6,
				"&bargainor_id=",
				this.string_0,
				"&transaction_id=",
				this.string_8,
				"&sp_billno=",
				this.string_7,
				"&return_url=",
				this.string_5,
				"&attach=",
				this.Attach,
				"&key=",
				this.string_1
			});
			return Tenpay.GetMD5(encypStr, this.getCharset());
		}
		private string method_3()
		{
			string encypStr = string.Concat(new object[]
			{
				"cmdno=",
				2,
				"&pay_result=",
				this.int_3,
				"&date=",
				this.string_6,
				"&transaction_id=",
				this.string_8,
				"&sp_billno=",
				this.string_7,
				"&total_fee=",
				this.long_0,
				"&fee_type=",
				this.int_2,
				"&attach=",
				this.string_10,
				"&key=",
				this.string_1
			});
			return Tenpay.GetMD5(encypStr, this.getCharset());
		}
		public bool GetQueryUrl(out string string_14)
		{
			bool result;
			try
			{
				string text = this.method_2();
				string_14 = string.Concat(new object[]
				{
					this.string_3,
					"?cmdno=",
					2,
					"&date=",
					this.string_6,
					"&bargainor_id=",
					this.string_0,
					"&transaction_id=",
					this.string_8,
					"&sp_billno=",
					this.string_7,
					"&return_url=",
					this.string_5,
					"&attach=",
					this.string_10,
					"&sign=",
					text
				});
				result = true;
			}
			catch (Exception ex)
			{
				string_14 = "创建URL时出错,错误信息:" + ex.Message;
				result = false;
			}
			return result;
		}
		public bool GetQueryValueFromUrl(NameValueCollection querystring, out string errmsg)
		{
			bool result;
			if (querystring == null || querystring.Count == 0)
			{
				errmsg = "参数为空";
				result = false;
			}
			else if (querystring["cmdno"] == null || querystring["cmdno"].ToString().Trim() != 2.ToString())
			{
				errmsg = "没有cmdno参数或cmdno参数不正确";
				result = false;
			}
			else if (querystring["pay_result"] == null)
			{
				errmsg = "没有pay_result参数";
				result = false;
			}
			else if (querystring["date"] == null)
			{
				errmsg = "没有date参数";
				result = false;
			}
			else if (querystring["pay_info"] == null)
			{
				errmsg = "没有pay_info参数";
				result = false;
			}
			else if (querystring["bargainor_id"] == null)
			{
				errmsg = "没有bargainor_id参数";
				result = false;
			}
			else if (querystring["transaction_id"] == null)
			{
				errmsg = "没有transaction_id参数";
				result = false;
			}
			else if (querystring["sp_billno"] == null)
			{
				errmsg = "没有sp_billno参数";
				result = false;
			}
			else if (querystring["total_fee"] == null)
			{
				errmsg = "没有total_fee参数";
				result = false;
			}
			else if (querystring["fee_type"] == null)
			{
				errmsg = "没有fee_type参数";
				result = false;
			}
			else if (querystring["attach"] == null)
			{
				errmsg = "没有attach参数";
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
					this.int_3 = int.Parse(querystring["pay_result"].Trim());
					this.string_13 = Tenpay.smethod_1(querystring["pay_info"].Trim());
					this.Date = querystring["date"];
					this.string_8 = querystring["transaction_id"];
					this.string_7 = querystring["sp_billno"];
					this.long_0 = long.Parse(querystring["total_fee"]);
					this.int_2 = int.Parse(querystring["fee_type"]);
					this.string_10 = querystring["attach"];
					if (querystring["bargainor_id"] != this.string_0)
					{
						this.int_3 = 1;
						result = true;
					}
					else
					{
						string b = querystring["sign"];
						string a = this.method_3();
						if (a != b)
						{
							this.int_3 = 2;
						}
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
		protected virtual string getCharset()
		{
			return HttpContext.Current.Request.ContentEncoding.BodyName;
		}
	}
}
