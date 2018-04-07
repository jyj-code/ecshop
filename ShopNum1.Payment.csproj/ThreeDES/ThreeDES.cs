using System;
using System.Security.Cryptography;
using System.Text;
namespace ThreeDES
{
	public static class ThreeDES
	{
		private static byte[] smethod_0(string string_0)
		{
			string_0 = string_0.Trim();
			if (string_0.Length % 2 != 0)
			{
				string_0 += " ";
			}
			byte[] array = new byte[string_0.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(string_0.Substring(i * 2, 2), 16);
			}
			return array;
		}
		public static string byteToHexStr(byte[] bytes)
		{
			string text = "";
			if (bytes != null)
			{
				for (int i = 0; i < bytes.Length; i++)
				{
					text += bytes[i].ToString("X2");
				}
			}
			return text;
		}
		public static string byteTohex(byte[] byte_0)
		{
			byte[] bytes = new byte[]
			{
				byte.Parse("20")
			};
			string @string = Encoding.GetEncoding("GBK").GetString(bytes);
			return Encoding.GetEncoding("GBK").GetString(byte_0).Replace(@string, "");
		}
		public static byte[] getTrueByte(byte[] byte_0)
		{
			int num = byte_0.Length;
			int num2 = num % 8;
			int num3 = 8 - num2;
			byte[] array = new byte[num + num3];
			for (int i = 0; i < byte_0.Length; i++)
			{
				array[i] = byte_0[i];
			}
			for (int j = 0; j < num3; j++)
			{
				array[num + j] = byte.Parse("20");
			}
			return array;
		}
		public static string Encrypt3DES(string a_strString, string a_strKey)
		{
			ICryptoTransform cryptoTransform = new TripleDESCryptoServiceProvider
			{
				Key = ThreeDES.smethod_0(a_strKey),
				Mode = CipherMode.ECB,
				Padding = PaddingMode.None
			}.CreateEncryptor();
			byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(a_strString);
			byte[] array = bytes;
			if (bytes.Length % 8 != 0)
			{
				array = ThreeDES.getTrueByte(bytes);
			}
			byte[] bytes2 = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
			return ThreeDES.byteToHexStr(bytes2);
		}
		public static string Decrypt3DES(string a_strString, string a_strKey)
		{
			ICryptoTransform cryptoTransform = new TripleDESCryptoServiceProvider
			{
				Key = ThreeDES.smethod_0(a_strKey),
				Mode = CipherMode.ECB,
				Padding = PaddingMode.None
			}.CreateDecryptor();
			byte[] array = ThreeDES.smethod_0(a_strString);
			byte[] byte_ = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
			return ThreeDES.byteTohex(byte_);
		}
	}
}
