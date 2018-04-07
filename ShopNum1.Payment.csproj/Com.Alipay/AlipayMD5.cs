using System;
using System.Security.Cryptography;
using System.Text;
namespace Com.Alipay
{
	public sealed class AlipayMD5
	{
		public static string Sign(string prestr, string string_0, string _input_charset)
		{
			StringBuilder stringBuilder = new StringBuilder(32);
			prestr += string_0;
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] array = mD.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
			}
			return stringBuilder.ToString();
		}
		public static bool Verify(string prestr, string sign, string string_0, string _input_charset)
		{
			string a = AlipayMD5.Sign(prestr, string_0, _input_charset);
			return a == sign;
		}
	}
}
