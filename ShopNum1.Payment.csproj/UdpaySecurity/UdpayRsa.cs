using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
namespace UdpaySecurity
{
	public static class UdpayRsa
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SignKeyParams
		{
			public static string MPK;
			public static string Wht_n;
			public static string Wht_e;
			public static string message;
			public static RSAParameters RSAParams1 = default(RSAParameters);
			public static RSAParameters RSAParams2 = default(RSAParameters);
		}
		public static bool LoadSignKey()
		{
			bool result;
			try
			{
				char[] char_ = new char[256];
				char[] array = new char[6];
				char[] array2 = new char[256];
				char[] array3 = new char[128];
				char[] array4 = new char[128];
				char[] array5 = new char[128];
				char[] array6 = new char[128];
				char[] array7 = new char[128];
				UdpayRsa.smethod_2(UdpayRsa.SignKeyParams.MPK, char_, array, array2, array4, array3, array5, array6, array7);
				UdpayRsa.SignKeyParams.RSAParams1.Exponent = UdpayRsa.smethod_3(array);
				UdpayRsa.SignKeyParams.RSAParams1.Modulus = UdpayRsa.smethod_3(char_);
				UdpayRsa.SignKeyParams.RSAParams1.D = UdpayRsa.smethod_3(array2);
				UdpayRsa.SignKeyParams.RSAParams1.DP = UdpayRsa.smethod_3(array3);
				UdpayRsa.SignKeyParams.RSAParams1.DQ = UdpayRsa.smethod_3(array4);
				UdpayRsa.SignKeyParams.RSAParams1.InverseQ = UdpayRsa.smethod_3(array5);
				UdpayRsa.SignKeyParams.RSAParams1.P = UdpayRsa.smethod_3(array6);
				UdpayRsa.SignKeyParams.RSAParams1.Q = UdpayRsa.smethod_3(array7);
				int num = UdpayRsa.SignKeyParams.Wht_e.IndexOf("=", 0);
				int num2;
				if (UdpayRsa.SignKeyParams.Wht_e[num + 1].Equals(UdpayRsa.SignKeyParams.Wht_e[num + 2]) && UdpayRsa.SignKeyParams.Wht_e[num + 1].Equals('0'))
				{
					num += 3;
					num2 = UdpayRsa.SignKeyParams.Wht_e.Length - num;
				}
				else
				{
					num++;
					num2 = UdpayRsa.SignKeyParams.Wht_e.Length - num;
				}
				char[] array8 = new char[num2];
				UdpayRsa.SignKeyParams.Wht_e.CopyTo(num, array8, 0, num2);
				num = UdpayRsa.SignKeyParams.Wht_n.IndexOf("=", 0);
				if (UdpayRsa.SignKeyParams.Wht_n[num + 1].Equals(UdpayRsa.SignKeyParams.Wht_n[num + 2]) && UdpayRsa.SignKeyParams.Wht_n[num + 1].Equals('0'))
				{
					num += 3;
					num2 = UdpayRsa.SignKeyParams.Wht_n.Length - num;
				}
				else
				{
					num++;
					num2 = UdpayRsa.SignKeyParams.Wht_n.Length - num;
				}
				char[] array9 = new char[num2];
				UdpayRsa.SignKeyParams.Wht_n.CopyTo(num, array9, 0, num2);
				UdpayRsa.SignKeyParams.RSAParams2.Exponent = UdpayRsa.smethod_3(array8);
				UdpayRsa.SignKeyParams.RSAParams2.Modulus = UdpayRsa.smethod_3(array9);
				result = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("The key could not be read:");
				Console.WriteLine(ex.Message);
				result = false;
			}
			return result;
		}
		public static string GenerateSigature(string PText)
		{
			return UdpayRsa.smethod_0(PText);
		}
		public static int VerifySigature(string PText, string Sign)
		{
			int result;
			if (UdpayRsa.smethod_1(PText, Sign))
			{
				result = 0;
			}
			else
			{
				result = -1;
			}
			return result;
		}
		private static string smethod_0(string string_0)
		{
			Encoding encoding = Encoding.GetEncoding(936);
			byte[] bytes = encoding.GetBytes(string_0);
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			rSACryptoServiceProvider.ImportParameters(UdpayRsa.SignKeyParams.RSAParams1);
			MD5CryptoServiceProvider halg = new MD5CryptoServiceProvider();
			byte[] byte_ = rSACryptoServiceProvider.SignData(bytes, halg);
			return UdpayRsa.smethod_4(byte_);
		}
		private static bool smethod_1(string string_0, string string_1)
		{
			Encoding encoding = Encoding.GetEncoding(936);
			byte[] bytes = encoding.GetBytes(string_0);
			char[] array = new char[string_1.Length];
			string_1 = string_1.ToUpper();
			string_1.CopyTo(0, array, 0, string_1.Length);
			byte[] signature = UdpayRsa.smethod_3(array);
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			rSACryptoServiceProvider.ImportParameters(UdpayRsa.SignKeyParams.RSAParams2);
			MD5CryptoServiceProvider halg = new MD5CryptoServiceProvider();
			return rSACryptoServiceProvider.VerifyData(bytes, halg, signature);
		}
		private static void smethod_2(string string_0, char[] char_0, char[] char_1, char[] char_2, char[] char_3, char[] char_4, char[] char_5, char[] char_6, char[] char_7)
		{
			int num = string_0.IndexOf("02818100", 0);
			if (num == -1)
			{
				num = string_0.IndexOf("028180", 0) + 6;
			}
			else
			{
				num += 8;
			}
			string_0.CopyTo(num, char_0, 0, 256);
			num += 256;
			int num2 = num;
			num = string_0.IndexOf("02818100", num2, 30);
			if (num == -1)
			{
				num = string_0.IndexOf("028180", 0) - 6;
				num2 = num + 12;
			}
			else
			{
				num -= 6;
				num2 = num + 14;
			}
			string_0.CopyTo(num, char_1, 0, 6);
			string_0.CopyTo(num2, char_2, 0, 256);
			num = num2 + 256;
			num2 = num;
			num = string_0.IndexOf("0240", num2, 6);
			if (num == -1)
			{
				num = string_0.IndexOf("024100", num2, 6) + 6;
			}
			else
			{
				num += 4;
			}
			string_0.CopyTo(num, char_6, 0, 128);
			num += 128;
			num2 = num;
			num = string_0.IndexOf("0240", num2, 6);
			if (num == -1)
			{
				num = string_0.IndexOf("024100", num2, 6) + 6;
			}
			else
			{
				num += 4;
			}
			string_0.CopyTo(num, char_7, 0, 128);
			num += 128;
			num2 = num;
			num = string_0.IndexOf("0240", num2, 6);
			if (num == -1)
			{
				num = string_0.IndexOf("024100", num2, 6) + 6;
			}
			else
			{
				num += 4;
			}
			string_0.CopyTo(num, char_4, 0, 128);
			num += 128;
			num2 = num;
			num = string_0.IndexOf("0240", num2, 6);
			if (num == -1)
			{
				num = string_0.IndexOf("024100", num2, 6) + 6;
			}
			else
			{
				num += 4;
			}
			string_0.CopyTo(num, char_3, 0, 128);
			num += 128;
			num2 = num;
			num = string_0.IndexOf("0240", num2, 6);
			if (num == -1)
			{
				num = string_0.IndexOf("024100", num2, 6) + 6;
			}
			else
			{
				num += 4;
			}
			string_0.CopyTo(num, char_5, 0, 128);
		}
		private static byte[] smethod_3(char[] char_0)
		{
			byte[] array = new byte[char_0.Length / 2];
			for (int i = 0; i < char_0.Length / 2; i++)
			{
				int num;
				if (char_0[2 * i] <= '9')
				{
					num = (int)(Convert.ToInt16(char_0[2 * i]) - 48);
				}
				else
				{
					num = (int)(Convert.ToInt16(char_0[2 * i]) - 55);
				}
				int num2;
				if (char_0[2 * i + 1] <= '9')
				{
					num2 = (int)(Convert.ToInt16(char_0[2 * i + 1]) - 48);
				}
				else
				{
					num2 = (int)(Convert.ToInt16(char_0[2 * i + 1]) - 55);
				}
				array[i] = Convert.ToByte(num * 16 + num2);
			}
			return array;
		}
		private static string smethod_4(byte[] byte_0)
		{
			string text = null;
			for (int i = 0; i < byte_0.Length; i++)
			{
				int num = (int)Convert.ToInt16(byte_0[i]);
				int num2 = num / 16;
				char value;
				if (num2 <= 9)
				{
					value = Convert.ToChar(num2 + 48);
				}
				else
				{
					value = Convert.ToChar(num2 + 55);
				}
				num2 = num % 16;
				char value2;
				if (num2 <= 9)
				{
					value2 = Convert.ToChar(num2 + 48);
				}
				else
				{
					value2 = Convert.ToChar(num2 + 55);
				}
				text = text + Convert.ToString(value) + Convert.ToString(value2);
			}
			return text.ToLower();
		}
	}
}
