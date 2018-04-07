using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace ShopNum1.Payment
{
	public class Alipay
	{
		public static string GetMD5(string string_0, string _input_charset)
		{
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(string_0));
			StringBuilder stringBuilder = new StringBuilder(32);
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
			}
			return stringBuilder.ToString();
		}
		public static string[] BubbleSort(string[] string_0)
		{
			for (int i = 0; i < string_0.Length; i++)
			{
				bool flag = false;
				for (int j = string_0.Length - 2; j >= i; j--)
				{
					if (string.CompareOrdinal(string_0[j + 1], string_0[j]) < 0)
					{
						string text = string_0[j + 1];
						string_0[j + 1] = string_0[j];
						string_0[j] = text;
						flag = true;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			return string_0;
		}
		public bool CreatUrl(string gateway, string service, string partner, string sign_type, string out_trade_no, string subject, string body, string total_fee, string show_url, string seller_email, string string_0, string return_url, string _input_charset, string notify_url, string logistics_type, string logistics_fee, string logistics_payment, string quantity, out string string_1)
		{
			bool result = true;
			try
			{
				string[] string_2 = new string[]
				{
					"service=" + service,
					"partner=" + partner,
					"subject=" + subject,
					"body=" + body,
					"out_trade_no=" + out_trade_no,
					"price=" + total_fee,
					"show_url=" + show_url,
					"payment_type=1",
					"seller_email=" + seller_email,
					"notify_url=" + notify_url,
					"_input_charset=" + _input_charset,
					"return_url=" + return_url,
					"quantity=" + quantity,
					"logistics_type=" + logistics_type,
					"logistics_fee=" + logistics_fee,
					"logistics_payment=" + logistics_payment
				};
				string[] array = Alipay.BubbleSort(string_2);
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					if (i == array.Length - 1)
					{
						stringBuilder.Append(array[i]);
					}
					else
					{
						stringBuilder.Append(array[i] + "&");
					}
				}
				stringBuilder.Append(string_0);
				string mD = Alipay.GetMD5(stringBuilder.ToString(), _input_charset);
				char[] separator = new char[]
				{
					'='
				};
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.Append(gateway);
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder2.Append(array[i].Split(separator)[0] + "=" + HttpUtility.UrlEncode(array[i].Split(separator)[1]) + "&");
				}
				stringBuilder2.Append("sign=" + mD + "&sign_type=" + sign_type);
				string_1 = stringBuilder2.ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}
}
