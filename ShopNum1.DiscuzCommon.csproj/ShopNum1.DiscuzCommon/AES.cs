using System;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.DiscuzCommon
{
	public class AES
	{
		private static byte[] byte_0 = new byte[]
		{
			65,
			114,
			101,
			121,
			111,
			117,
			109,
			121,
			83,
			110,
			111,
			119,
			109,
			97,
			110,
			63
		};
		public static string Encode(string encryptString, string encryptKey)
		{
			encryptKey = Utils.GetSubString(encryptKey, 32, "");
			encryptKey = encryptKey.PadRight(32, ' ');
			ICryptoTransform cryptoTransform = new RijndaelManaged
			{
				Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)),
				IV = AES.byte_0
			}.CreateEncryptor();
			byte[] bytes = Encoding.UTF8.GetBytes(encryptString);
			byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
			return Convert.ToBase64String(inArray);
		}
		public static string Decode(string decryptString, string decryptKey)
		{
			string result;
			try
			{
				decryptKey = Utils.GetSubString(decryptKey, 32, "");
				decryptKey = decryptKey.PadRight(32, ' ');
				ICryptoTransform cryptoTransform = new RijndaelManaged
				{
					Key = Encoding.UTF8.GetBytes(decryptKey),
					IV = AES.byte_0
				}.CreateDecryptor();
				byte[] array = Convert.FromBase64String(decryptString);
				byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
				result = Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				result = "";
			}
			return result;
		}
	}
}
