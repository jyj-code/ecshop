using System;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.Payment
{
	public class Alipay2GB
	{
		public static string GetMD5(string string_0)
		{
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] array = mD.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(string_0));
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
		public bool CreatUrl(string gateway, string service, string partner, string sign_type, string out_trade_no, string subject, string body, string quantity, string price, string show_url, string seller_email, string string_0, string return_url, string notify_url, string logistics_type, string logistics_fee, string logistics_payment, string logistics_type_1, string logistics_fee_1, string logistics_payment_1, string payment_type, out string string_1)
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
					"price=" + price,
					"show_url=" + show_url,
					"quantity=" + quantity,
					"seller_email=" + seller_email,
					"notify_url=" + notify_url,
					"return_url=" + return_url,
					"logistics_type=" + logistics_type,
					"logistics_fee=" + logistics_fee,
					"logistics_payment=" + logistics_payment,
					"logistics_type_1=" + logistics_type_1,
					"logistics_fee_1=" + logistics_fee_1,
					"logistics_payment_1=" + logistics_payment_1,
					"payment_type=" + payment_type
				};
				string[] array = Alipay2GB.BubbleSort(string_2);
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
				string mD = Alipay2GB.GetMD5(stringBuilder.ToString());
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.Append(gateway);
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder2.Append(array[i] + "&");
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
