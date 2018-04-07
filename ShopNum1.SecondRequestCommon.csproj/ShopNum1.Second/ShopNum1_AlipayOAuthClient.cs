using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace ShopNum1.Second
{
	public class ShopNum1_AlipayOAuthClient
	{
		private string string_0 = "https://mapi.alipay.com/gateway.do?";
		private string string_1 = "";
		private string string_2 = "";
		private string string_3 = "";
		private string string_4 = "";
		private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();
		private ShopNum1_Alipay_function shopNum1_Alipay_function_0 = new ShopNum1_Alipay_function();
		public ShopNum1_AlipayOAuthClient(ShopNum1_Alipay_config Alipay_config)
		{
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			sortedDictionary.Add("service", "alipay.auth.authorize");
			sortedDictionary.Add("target_service", "user.auth.quick.login");
			sortedDictionary.Add("partner", Alipay_config.Partner);
			sortedDictionary.Add("_input_charset", Alipay_config.Input_charset.ToLower());
			sortedDictionary.Add("return_url", Alipay_config.Return_url);
			this.dictionary_0 = this.shopNum1_Alipay_function_0.Para_filter(sortedDictionary);
			this.string_4 = this.shopNum1_Alipay_function_0.Build_mysign(this.dictionary_0, Alipay_config.Key.Trim(), Alipay_config.Sign_type.ToUpper(), Alipay_config.Input_charset.ToLower());
		}
		public string Build_Form()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"",
				this.string_0,
				"_input_charset=",
				this.string_2,
				"\" method=\"get\">"
			}));
			foreach (KeyValuePair<string, string> current in this.dictionary_0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<input type=\"hidden\" name=\"",
					current.Key,
					"\" value=\"",
					current.Value,
					"\"/>"
				}));
			}
			stringBuilder.Append("<input type=\"hidden\" name=\"sign\" value=\"" + this.string_4 + "\"/>");
			stringBuilder.Append("<input type=\"hidden\" name=\"sign_type\" value=\"" + this.string_3 + "\"/>");
			stringBuilder.Append("<input type=\"submit\" value=\"支付宝会员登录\"></form>");
			return stringBuilder.ToString();
		}
		public void GetAuthorizationCode1()
		{
			this.dictionary_0.Add("sign", this.string_4);
			this.dictionary_0.Add("sign_type", this.string_3);
			string arg = this.shopNum1_Alipay_function_0.Create_linkstring(this.dictionary_0);
			string url = string.Format(this.string_0 + "{0}", arg);
			HttpContext.Current.Response.Redirect(url);
		}
		public string GetAuthorizationUrl()
		{
			this.dictionary_0.Add("sign", this.string_4);
			this.dictionary_0.Add("sign_type", this.string_3);
			string arg = this.shopNum1_Alipay_function_0.Create_linkstring(this.dictionary_0);
			return string.Format(this.string_0 + "{0}", arg);
		}
	}
}
