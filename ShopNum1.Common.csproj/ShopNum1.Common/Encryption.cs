using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
namespace ShopNum1.Common
{
	public static class Encryption
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
			input = "shopnum1" + input + "@1$%^^)+_)(*&^%$#@!";
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
			return stringBuilder.ToString().ToUpper().Substring(0, 30);
		}
		public static string GetSHA1SecondHash(string input)
		{
			input = "~!@#$%&*()_01qda31+" + input + "shopnum1";
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
			string md5Hash = Encryption.GetMd5Hash(input);
			StringComparer ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
			return 0 == ordinalIgnoreCase.Compare(md5Hash, hash);
		}
		public static string Encrypt(string Text)
		{
			return Encryption.Encrypt(Text, "EncryptHelper");
		}
		public static string Encrypt(string Text, string sKey)
		{
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] bytes = Encoding.Default.GetBytes(Text);
			dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = memoryStream.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				byte b = array[i];
				stringBuilder.AppendFormat("{0:X2}", b);
			}
			return stringBuilder.ToString();
		}
		public static string Decrypt(string Text)
		{
			return Encryption.Decrypt(Text, "EncryptHelper");
		}
		public static string Decrypt(string Text, string sKey)
		{
			string result;
			try
			{
				if (!string.IsNullOrEmpty(Text))
				{
					DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
					int num = Text.Length / 2;
					byte[] array = new byte[num];
					for (int i = 0; i < num; i++)
					{
						int num2 = Convert.ToInt32(Text.Substring(i * 2, 2), 16);
						array[i] = (byte)num2;
					}
					dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
					dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
					MemoryStream memoryStream = new MemoryStream();
					CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
					cryptoStream.Write(array, 0, array.Length);
					cryptoStream.FlushFinalBlock();
					result = Encoding.Default.GetString(memoryStream.ToArray());
				}
				else
				{
					result = "";
				}
			}
			catch
			{
				result = Text;
			}
			return result;
		}
	}
}
