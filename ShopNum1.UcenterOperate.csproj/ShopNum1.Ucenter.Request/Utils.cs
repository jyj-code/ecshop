using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace ShopNum1.Ucenter.Request
{
	public static class Utils
	{
		public static string AscArr2Str(byte[] byte_0)
		{
			return Encoding.Unicode.GetString(Encoding.Convert(Encoding.ASCII, Encoding.Unicode, byte_0));
		}
		public static string Base64Decode(string string_0)
		{
			string result;
			try
			{
				byte[] bytes = Convert.FromBase64String(string_0);
				result = Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				result = "";
			}
			return result;
		}
		public static string Base64Encode(string string_0)
		{
			string result;
			try
			{
				result = Convert.ToBase64String(Encoding.UTF8.GetBytes(string_0));
			}
			catch
			{
				result = "";
			}
			return result;
		}
		public static string CutString(string string_0, int startIndex)
		{
			return Utils.CutString(string_0, startIndex, string_0.Length);
		}
		public static string CutString(string string_0, int startIndex, int length)
		{
			string result;
			if (startIndex >= 0)
			{
				if (length < 0)
				{
					length *= -1;
					if (startIndex - length < 0)
					{
						length = startIndex;
						startIndex = 0;
					}
					else
					{
						startIndex -= length;
					}
				}
				if (startIndex > string_0.Length)
				{
					result = "";
					return result;
				}
			}
			else
			{
				if (length < 0 || length + startIndex <= 0)
				{
					result = "";
					return result;
				}
				length += startIndex;
				startIndex = 0;
			}
			if (string_0.Length - startIndex < length)
			{
				length = string_0.Length - startIndex;
			}
			result = string_0.Substring(startIndex, length);
			return result;
		}
		public static bool FileExists(string filename)
		{
			return File.Exists(filename);
		}
		public static bool IsIntArray(string string_0)
		{
			bool result;
			if (string.IsNullOrEmpty(string_0))
			{
				result = false;
			}
			else
			{
				Regex regex = new Regex("\\d{1,9}");
				if (!regex.IsMatch(string_0))
				{
					string[] array = string_0.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						string input = array[i];
						if (!regex.IsMatch(input))
						{
							result = false;
							return result;
						}
					}
				}
				result = true;
			}
			return result;
		}
		public static void Log(string string_0)
		{
			File.AppendAllText(HttpContext.Current.Server.MapPath("~/API/log.txt"), string_0 + "\r\n", Encoding.Default);
		}
		public static string MD5(string string_0)
		{
			byte[] array = Encoding.UTF8.GetBytes(string_0);
			array = new MD5CryptoServiceProvider().ComputeHash(array);
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("x").PadLeft(2, '0');
			}
			return text;
		}
		public static long PHP_Time()
		{
			DateTime dateTime = new DateTime(1970, 1, 1);
			return (DateTime.UtcNow.Ticks - dateTime.Ticks) / 10000000L;
		}
		public static string PHP_UrlEncode(string string_0)
		{
			string text = string.Empty;
			string text2 = "_-.1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			for (int i = 0; i < string_0.Length; i++)
			{
				string text3 = string_0.Substring(i, 1);
				if (text2.Contains(text3))
				{
					text += text3;
				}
				else
				{
					Encoding encoding = Encoding.GetEncoding(UCConfig.UC_CHARSET);
					byte[] bytes = encoding.GetBytes(text3);
					for (int j = 0; j < bytes.Length; j++)
					{
						byte b = bytes[j];
						text = text + "%" + b.ToString("X");
					}
				}
			}
			return text;
		}
		public static string RandomString(int lens)
		{
			char[] array = new char[]
			{
				'a',
				'b',
				'c',
				'd',
				'e',
				'f',
				'g',
				'h',
				'j',
				'k',
				'l',
				'm',
				'n',
				'o',
				'p',
				'q',
				'r',
				's',
				't',
				'u',
				'v',
				'w',
				'x',
				'y',
				'z',
				'A',
				'B',
				'C',
				'D',
				'E',
				'F',
				'G',
				'H',
				'J',
				'K',
				'L',
				'M',
				'N',
				'O',
				'P',
				'Q',
				'R',
				'S',
				'T',
				'U',
				'V',
				'W',
				'X',
				'Y',
				'Z',
				'0',
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9'
			};
			int maxValue = array.Length;
			string text = "";
			Random random = new Random();
			for (int i = 0; i < lens; i++)
			{
				text += array[random.Next(maxValue)];
			}
			return text;
		}
		public static DateTime StringToDatetime(string string_0)
		{
			return Utils.StringToDatetime(string_0, DateTime.MinValue);
		}
		public static DateTime StringToDatetime(string string_0, DateTime defaultValue)
		{
			DateTime result;
			if (!string.IsNullOrEmpty(string_0))
			{
				DateTime minValue = DateTime.MinValue;
				if (DateTime.TryParse(string_0, out minValue))
				{
					result = minValue;
					return result;
				}
			}
			result = defaultValue;
			return result;
		}
		public static int StringToInt(string string_0)
		{
			return Utils.StringToInt(string_0, 0);
		}
		public static int StringToInt(string string_0, int defaultValue)
		{
			int result;
			if (!string.IsNullOrEmpty(string_0))
			{
				int num = 0;
				if (int.TryParse(string_0, out num))
				{
					result = num;
					return result;
				}
			}
			result = defaultValue;
			return result;
		}
		public static short StringToShort(string string_0)
		{
			return Utils.StringToShort(string_0, 0);
		}
		public static short StringToShort(string string_0, short defaultValue)
		{
			short result;
			if (!string.IsNullOrEmpty(string_0))
			{
				short num = 0;
				if (short.TryParse(string_0, out num))
				{
					result = num;
					return result;
				}
			}
			result = defaultValue;
			return result;
		}
		public static bool StrIsNullOrEmpty(string string_0)
		{
			return string_0 == null || string_0.Trim() == "";
		}
		public static int UnixTimestamp()
		{
			DateTime value = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			string text = DateTime.Parse(DateTime.Now.ToString()).Subtract(value).Ticks.ToString();
			return Convert.ToInt32(text.Substring(0, text.Length - 7));
		}
	}
}
