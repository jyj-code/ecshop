using System;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.Payment
{
	public class Xpay
	{
		public bool CreateUrl(string gatewayurl, string string_0, string string_1, string string_2, string string_3, string type, decimal decimal_0, string card, string lang, string string_4, string string_5, string remark1, string actioncode, string actionparameter, string username, out string url1)
		{
			bool result = true;
			try
			{
				string empty = string.Empty;
				string string_6 = string.Concat(new object[]
				{
					string_0,
					":",
					decimal_0,
					",",
					string_2,
					",",
					string_1,
					",",
					card,
					",",
					empty,
					",",
					actioncode,
					",",
					actionparameter,
					",",
					string_5
				});
				string str = this.method_0(string_6);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(gatewayurl);
				stringBuilder.Append("?tid=" + string_1);
				stringBuilder.Append("&bid=" + string_2);
				stringBuilder.Append("&pdt=" + string_3);
				stringBuilder.Append("&type=" + type);
				stringBuilder.Append("&prc=" + decimal_0);
				stringBuilder.Append("&card=" + card);
				stringBuilder.Append("&scard=" + empty);
				stringBuilder.Append("&lang=" + lang);
				stringBuilder.Append("&url=" + string_4);
				stringBuilder.Append("&ver=" + string_5);
				stringBuilder.Append("&remark1=" + remark1);
				stringBuilder.Append("&actioncode=" + actioncode);
				stringBuilder.Append("&actionparameter=" + actionparameter);
				stringBuilder.Append("&username=" + username);
				stringBuilder.Append("&md=" + str);
				string text = stringBuilder.ToString();
				url1 = text;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		private string method_0(string string_0)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			return BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(string_0))).Replace("-", "").ToLower();
		}
	}
}
