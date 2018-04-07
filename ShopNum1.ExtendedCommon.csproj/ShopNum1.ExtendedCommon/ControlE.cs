using System;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.ExtendedCommon
{
	public static class ControlE
	{
		public static string GetMd5Hash(string input)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(input));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}
		public static string GetMd5SecondHash(string input)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(input));
			StringBuilder stringBuilder = new StringBuilder();
			byte b = array[0];
			array[0] = array[array.Length - 1];
			array[array.Length - 1] = b;
			for (int i = 0; i < array.Length; i++)
			{
				if (i == 3)
				{
					stringBuilder.Append(array[i].ToString("x2").Replace('a', 'd'));
				}
				else
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
			}
			return stringBuilder.ToString().ToUpper();
		}
		public static string GetSHA1SecondHash(string input)
		{
			SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] array = sHA1CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(input));
			StringBuilder stringBuilder = new StringBuilder();
			array[0] = array[array.Length - 1];
			array[array.Length - 1] = array[0];
			for (int i = 0; i < array.Length; i++)
			{
				if (i == 4)
				{
					stringBuilder.Append(array[i].ToString("x2").Replace('a', 'd'));
				}
				else
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
			}
			return stringBuilder.ToString().ToUpper();
		}
		public static string GetSHA1Hash(string input)
		{
			SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] array = sHA1CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(input));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}
		public static bool VerifyMd5Hash(string input, string hash)
		{
			string md5Hash = ControlE.GetMd5Hash(input);
			StringComparer ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
			return ordinalIgnoreCase.Compare(md5Hash, hash) == 0;
		}
	}
}
