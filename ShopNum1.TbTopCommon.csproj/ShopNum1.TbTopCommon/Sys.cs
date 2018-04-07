using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.TbTopCommon
{
	public class Sys
	{
		public static bool VerifyTopResponse(string callbackUrl, string appSecret)
		{
			Uri uri = new Uri(callbackUrl);
			string text = uri.Query;
			bool result;
			if (string.IsNullOrEmpty(text))
			{
				result = false;
			}
			else
			{
				text = text.Trim(new char[]
				{
					'?',
					' '
				});
				if (text.Length == 0)
				{
					result = false;
				}
				else
				{
					IDictionary<string, string> dictionary = new Dictionary<string, string>();
					string[] array = text.Split(new char[]
					{
						'&'
					});
					if (array != null && array.Length > 0)
					{
						string[] array2 = array;
						for (int i = 0; i < array2.Length; i++)
						{
							string text2 = array2[i];
							string[] array3 = text2.Split(new char[]
							{
								'='
							});
							if (array3.Length >= 2)
							{
								dictionary.Add(array3[0], array3[1]);
							}
						}
					}
					StringBuilder stringBuilder = new StringBuilder();
					if (dictionary.ContainsKey("top_appkey"))
					{
						stringBuilder.Append(dictionary["top_appkey"]);
					}
					if (dictionary.ContainsKey("top_parameters"))
					{
						stringBuilder.Append(dictionary["top_parameters"]);
					}
					if (dictionary.ContainsKey("top_session"))
					{
						stringBuilder.Append(dictionary["top_session"]);
					}
					stringBuilder.Append(appSecret);
					byte[] inArray = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
					string stringToEscape = Convert.ToBase64String(inArray);
					result = (dictionary.ContainsKey("top_sign") && Uri.EscapeDataString(stringToEscape) == dictionary["top_sign"]);
				}
			}
			return result;
		}
		public static bool VerifyTopResponse(string topParams, string topSession, string topSign, string appKey, string appSecret)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (appKey.ToLower() == "test" || appKey == "系统分配")
			{
				appKey = "";
				appSecret = "";
			}
			new MD5CryptoServiceProvider();
			stringBuilder.Append(appKey).Append(topParams).Append(topSession).Append(appSecret);
			byte[] inArray = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
			return Convert.ToBase64String(inArray) == topSign;
		}
		public static string GetFileSuffix(byte[] fileData)
		{
			string result;
			if (fileData == null || fileData.Length < 10)
			{
				result = null;
			}
			else if (fileData[0] == 71 && fileData[1] == 73 && fileData[2] == 70)
			{
				result = "GIF";
			}
			else if (fileData[1] == 80 && fileData[2] == 78 && fileData[3] == 71)
			{
				result = "PNG";
			}
			else if (fileData[6] == 74 && fileData[7] == 70 && fileData[8] == 73 && fileData[9] == 70)
			{
				result = "JPG";
			}
			else if (fileData[0] == 66 && fileData[1] == 77)
			{
				result = "BMP";
			}
			else
			{
				result = null;
			}
			return result;
		}
		public static string GetMimeType(byte[] fileData)
		{
			string fileSuffix = Sys.GetFileSuffix(fileData);
			string text = fileSuffix;
			string result;
			if (text != null)
			{
				if (text == "JPG")
				{
					result = "image/jpeg";
					return result;
				}
				if (text == "GIF")
				{
					result = "image/gif";
					return result;
				}
				if (text == "PNG")
				{
					result = "image/png";
					return result;
				}
				if (text == "BMP")
				{
					result = "image/bmp";
					return result;
				}
			}
			result = "application/octet-stream";
			return result;
		}
		public static string GetMimeType(string fileName)
		{
			fileName = fileName.ToLower();
			string result;
			if (fileName.EndsWith(".bmp", StringComparison.CurrentCulture))
			{
				result = "image/bmp";
			}
			else if (fileName.EndsWith(".gif", StringComparison.CurrentCulture))
			{
				result = "image/gif";
			}
			else if (fileName.EndsWith(".jpg", StringComparison.CurrentCulture) || fileName.EndsWith(".jpeg", StringComparison.CurrentCulture))
			{
				result = "image/jpeg";
			}
			else if (fileName.EndsWith(".png", StringComparison.CurrentCulture))
			{
				result = "image/png";
			}
			else
			{
				result = "application/octet-stream";
			}
			return result;
		}
	}
}
