using System;
using System.Text;
namespace ShopNum1.QRCode.Codec.Util
{
	public class QRCodeUtility
	{
		public static int sqrt(int int_0)
		{
			int num = 0;
			int num2 = 32768;
			int num3 = 15;
			do
			{
				int num4;
				if (int_0 >= (num4 = (num << 1) + num2 << (num3-- & 31)))
				{
					num += num2;
					int_0 -= num4;
				}
			}
			while ((num2 >>= 1) > 0);
			return num;
		}
		public static bool IsUniCode(string value)
		{
			byte[] characters = QRCodeUtility.AsciiStringToByteArray(value);
			byte[] characters2 = QRCodeUtility.UnicodeStringToByteArray(value);
			string a = QRCodeUtility.FromASCIIByteArray(characters);
			string b = QRCodeUtility.FromUnicodeByteArray(characters2);
			return a != b;
		}
		public static bool IsUnicode(byte[] byteData)
		{
			string string_ = QRCodeUtility.FromASCIIByteArray(byteData);
			string string_2 = QRCodeUtility.FromUnicodeByteArray(byteData);
			byte[] array = QRCodeUtility.AsciiStringToByteArray(string_);
			byte[] array2 = QRCodeUtility.UnicodeStringToByteArray(string_2);
			return array[0] != array2[0];
		}
		public static string FromASCIIByteArray(byte[] characters)
		{
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			return aSCIIEncoding.GetString(characters);
		}
		public static string FromUnicodeByteArray(byte[] characters)
		{
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			return unicodeEncoding.GetString(characters);
		}
		public static byte[] AsciiStringToByteArray(string string_0)
		{
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			return aSCIIEncoding.GetBytes(string_0);
		}
		public static byte[] UnicodeStringToByteArray(string string_0)
		{
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			return unicodeEncoding.GetBytes(string_0);
		}
	}
}
