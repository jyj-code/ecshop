using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
namespace ShopNum1.Encryption
{
	public class DESEncrypt
	{
		public byte[] DESKey = new byte[]
		{
			104,
			173,
			137,
			95,
			124,
			120,
			157,
			230,
			75,
			187,
			88,
			105,
			127,
			61,
			237,
			31,
			151,
			104,
			226,
			95,
			212,
			188,
			184,
			61,
			80,
			185,
			58,
			145,
			158,
			186,
			251,
			221
		};
		public static string Encrypt(string Text)
		{
			return DESEncrypt.Encrypt(Text, "williamshopnum1");
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
			return DESEncrypt.Decrypt(Text, "williamshopnum1");
		}
		public static string Decrypt(string Text, string sKey)
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
			return Encoding.Default.GetString(memoryStream.ToArray());
		}
		public string Encrypt3DES(string string_0)
		{
			string s = "william450";
			string s2 = "5484450";
			SymmetricAlgorithm symmetricAlgorithm = new TripleDESCryptoServiceProvider();
			symmetricAlgorithm.Key = Convert.FromBase64String(s);
			symmetricAlgorithm.IV = Convert.FromBase64String(s2);
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		public string Encrypt3DES(string string_0, string sKey, string sIV)
		{
			SymmetricAlgorithm symmetricAlgorithm = new TripleDESCryptoServiceProvider();
			symmetricAlgorithm.Key = Convert.FromBase64String(sKey);
			symmetricAlgorithm.IV = Convert.FromBase64String(sIV);
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		public string Decrypt3DES(string Value)
		{
			string s = "william450";
			string s2 = "5484450";
			SymmetricAlgorithm symmetricAlgorithm = new TripleDESCryptoServiceProvider();
			symmetricAlgorithm.Key = Convert.FromBase64String(s);
			symmetricAlgorithm.IV = Convert.FromBase64String(s2);
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
			byte[] array = Convert.FromBase64String(Value);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
		public string Decrypt3DES(string string_0, string sKey, string sIV)
		{
			SymmetricAlgorithm symmetricAlgorithm = new TripleDESCryptoServiceProvider();
			symmetricAlgorithm.Key = Convert.FromBase64String(sKey);
			symmetricAlgorithm.IV = Convert.FromBase64String(sIV);
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
			byte[] array = Convert.FromBase64String(string_0);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
	}
}
