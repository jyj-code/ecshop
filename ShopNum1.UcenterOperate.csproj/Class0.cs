using ShopNum1.Ucenter.Request;
using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
internal class Class0
{
	internal static string smethod_0(string string_0, string string_1, Hashtable hashtable_0)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		foreach (DictionaryEntry dictionaryEntry in hashtable_0)
		{
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				text2,
				dictionaryEntry.Key,
				"=",
				Class0.smethod_13(Class0.smethod_2(dictionaryEntry.Value.ToString()))
			});
			text2 = "&";
		}
		string string_2 = Class0.smethod_4(string_0, string_1, text);
		return Class0.smethod_29(UCConfig.UC_API + "/index.php", 500000, string_2, string.Empty, true, ConfigurationManager.AppSettings["UC_IP"], 20);
	}
	internal static Hashtable smethod_1(string string_0)
	{
		return Class2.smethod_0(string_0);
	}
	private static string smethod_2(string string_0)
	{
		return string_0;
	}
	private static string smethod_3(string string_0, string string_1)
	{
		return Class0.smethod_5(string_0, string_1, string.Empty, string.Empty);
	}
	private static string smethod_4(string string_0, string string_1, string string_2)
	{
		return Class0.smethod_5(string_0, string_1, string_2, string.Empty);
	}
	private static string smethod_5(string string_0, string string_1, string string_2, string string_3)
	{
		string text = Class0.smethod_14(string_2);
		return string.Concat(new string[]
		{
			"m=",
			string_0,
			"&a=",
			string_1,
			"&inajax=2&input=",
			text,
			"&appid=",
			UCConfig.UC_APPID,
			string_3
		});
	}
	private static string smethod_6(string string_0)
	{
		MD5 mD = new MD5CryptoServiceProvider();
		byte[] array = mD.ComputeHash(Encoding.GetEncoding(UCConfig.UC_CHARSET).GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder(32);
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
		}
		return stringBuilder.ToString();
	}
	internal static long smethod_7()
	{
		DateTime dateTime = new DateTime(1970, 1, 1);
		return (DateTime.UtcNow.Ticks - dateTime.Ticks) / 10000000L;
	}
	private static string smethod_8()
	{
		long num = Class0.smethod_7();
		string str = "0." + DateTime.UtcNow.Millisecond.ToString().PadRight(8, '0');
		return str + " " + num.ToString();
	}
	public static string smethod_9(byte[] byte_0)
	{
		return Convert.ToBase64String(byte_0);
	}
	public static string smethod_10(string string_0)
	{
		string result = "";
		try
		{
			byte[] bytes = Encoding.GetEncoding(UCConfig.UC_CHARSET).GetBytes(string_0);
			result = Convert.ToBase64String(bytes);
		}
		catch
		{
			result = string_0;
		}
		return result;
	}
	private static string smethod_11(string string_0)
	{
		while (string_0.Length % 4 != 0)
		{
			string_0 += "=";
		}
		string text = "";
		byte[] array = Convert.FromBase64String(string_0);
		byte[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			byte b = array2[i];
			text += (char)b;
		}
		return text;
	}
	private static string smethod_12(string string_0)
	{
		while (string_0.Length % 4 != 0)
		{
			string_0 += "=";
		}
		string result = "";
		byte[] bytes = Convert.FromBase64String(string_0);
		try
		{
			result = Encoding.GetEncoding(UCConfig.UC_CHARSET).GetString(bytes);
		}
		catch
		{
			result = string_0;
		}
		return result;
	}
	private static string smethod_13(string string_0)
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
				byte[] bytes = Encoding.GetEncoding(UCConfig.UC_CHARSET).GetBytes(text3);
				byte[] array = bytes;
				for (int j = 0; j < array.Length; j++)
				{
					byte b = array[j];
					text = text + "%" + b.ToString("X");
				}
			}
		}
		return text;
	}
	private static string smethod_14(string string_0)
	{
		return Class0.smethod_13(Class0.smethod_33(string.Concat(new object[]
		{
			string_0,
			"&agent=",
			Class0.smethod_6(HttpContext.Current.Request.UserAgent),
			"&time=",
			Class0.smethod_7()
		}), "ENCODE", UCConfig.UC_KEY));
	}
	private static string smethod_15(string string_0)
	{
		return Class0.smethod_22(string_0, 0, string.Empty, string.Empty, false, string.Empty, 15, true);
	}
	private static string smethod_16(string string_0, int int_0)
	{
		return Class0.smethod_22(string_0, int_0, string.Empty, string.Empty, false, string.Empty, 15, true);
	}
	private static string smethod_17(string string_0, int int_0, string string_1)
	{
		return Class0.smethod_22(string_0, int_0, string_1, string.Empty, false, string.Empty, 15, true);
	}
	private static string smethod_18(string string_0, int int_0, string string_1, string string_2)
	{
		return Class0.smethod_22(string_0, int_0, string_1, string_2, false, string.Empty, 15, true);
	}
	private static string smethod_19(string string_0, int int_0, string string_1, string string_2, bool bool_0)
	{
		return Class0.smethod_22(string_0, int_0, string_1, string_2, bool_0, string.Empty, 15, true);
	}
	private static string smethod_20(string string_0, int int_0, string string_1, string string_2, bool bool_0, string string_3)
	{
		return Class0.smethod_22(string_0, int_0, string_1, string_2, bool_0, string_3, 15, true);
	}
	private static string smethod_21(string string_0, int int_0, string string_1, string string_2, bool bool_0, string string_3, int int_1)
	{
		return Class0.smethod_22(string_0, int_0, string_1, string_2, bool_0, string_3, int_1, true);
	}
	private static string smethod_22(string string_0, int int_0, string string_1, string string_2, bool bool_0, string string_3, int int_1, bool bool_1)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
		httpWebRequest.AllowAutoRedirect = true;
		httpWebRequest.UserAgent = HttpContext.Current.Request.UserAgent;
		httpWebRequest.KeepAlive = false;
		if (string.IsNullOrEmpty(string_1))
		{
			httpWebRequest.Method = "GET";
		}
		else
		{
			httpWebRequest.Method = "POST";
			Stream stream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding(UCConfig.UC_CHARSET));
			streamWriter.Write(string_1);
			streamWriter.Flush();
			long length = stream.Length;
			streamWriter.Close();
			stream.Close();
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = length;
			Stream requestStream = httpWebRequest.GetRequestStream();
			streamWriter = new StreamWriter(requestStream, Encoding.GetEncoding(UCConfig.UC_CHARSET));
			streamWriter.Write(string_1);
			streamWriter.Close();
			requestStream.Close();
		}
		string result = string.Empty;
		httpWebRequest.Timeout = int_1;
		try
		{
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			bool flag = true;
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				flag = false;
			}
			if (flag)
			{
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(UCConfig.UC_CHARSET));
				result = streamReader.ReadToEnd();
				streamReader.Close();
			}
			if (httpWebResponse != null)
			{
				httpWebResponse.Close();
			}
		}
		catch (Exception)
		{
		}
		return result;
	}
	private static string smethod_23(string string_0)
	{
		return Class0.smethod_30(string_0, 0, string.Empty, string.Empty, false, string.Empty, 15, true);
	}
	private static string smethod_24(string string_0, int int_0)
	{
		return Class0.smethod_30(string_0, int_0, string.Empty, string.Empty, false, string.Empty, 15, true);
	}
	private static string smethod_25(string string_0, int int_0, string string_1)
	{
		return Class0.smethod_30(string_0, int_0, string_1, string.Empty, false, string.Empty, 15, true);
	}
	private static string smethod_26(string string_0, int int_0, string string_1, string string_2)
	{
		return Class0.smethod_30(string_0, int_0, string_1, string_2, false, string.Empty, 15, true);
	}
	private static string smethod_27(string string_0, int int_0, string string_1, string string_2, bool bool_0)
	{
		return Class0.smethod_30(string_0, int_0, string_1, string_2, bool_0, string.Empty, 15, true);
	}
	private static string smethod_28(string string_0, int int_0, string string_1, string string_2, bool bool_0, string string_3)
	{
		return Class0.smethod_30(string_0, int_0, string_1, string_2, bool_0, string_3, 15, true);
	}
	private static string smethod_29(string string_0, int int_0, string string_1, string string_2, bool bool_0, string string_3, int int_1)
	{
		return Class0.smethod_30(string_0, int_0, string_1, string_2, bool_0, string_3, int_1, true);
	}
	private static string smethod_30(string string_0, int int_0, string string_1, string string_2, bool bool_0, string string_3, int int_1, bool bool_1)
	{
		int num = 1;
		if (HttpContext.Current.Request["__times__"] != null)
		{
			num = int.Parse(HttpContext.Current.Request["__times__"].ToString()) + 1;
		}
		string result;
		if (num > 2)
		{
			result = string.Empty;
		}
		else
		{
			string_0 += (string_0.Contains("?") ? "&" : ("?__times__=" + num));
			result = Class0.smethod_22(string_0, int_0, string_1, string_2, bool_0, string_3, int_1, bool_1);
		}
		return result;
	}
	internal static string smethod_31(string string_0)
	{
		return Class0.smethod_34(string_0, "DECODE", string.Empty, 0);
	}
	internal static string smethod_32(string string_0, string string_1)
	{
		return Class0.smethod_34(string_0, string_1, string.Empty, 0);
	}
	internal static string smethod_33(string string_0, string string_1, string string_2)
	{
		return Class0.smethod_34(string_0, string_1, string_2, 0);
	}
	internal static string smethod_34(string string_0, string string_1, string string_2, int int_0)
	{
		int num = 4;
		string_2 = Class0.smethod_6(string.IsNullOrEmpty(string_2) ? UCConfig.UC_KEY : string_2);
		string str = Class0.smethod_6(string_2.Substring(0, 16));
		string str2 = Class0.smethod_6(string_2.Substring(16, 16));
		string text = Class0.smethod_6(Class0.smethod_8());
		string text2 = (num > 0) ? (string_1.Equals("DECODE") ? string_0.Substring(0, num) : text.Substring(text.Length - num)) : string.Empty;
		string text3 = str + Class0.smethod_6(str + text2);
		int length = text3.Length;
		string_0 = (string_1.Equals("DECODE") ? Class0.smethod_11(string_0.Substring(num)) : (((int_0 > 0) ? ((long)int_0 + Class0.smethod_7()) : 0L).ToString("D10") + Class0.smethod_6(string_0 + str2).Substring(0, 16) + string_0));
		int length2 = string_0.Length;
		string text4 = string.Empty;
		int[] array = new int[256];
		int i;
		for (i = 0; i < 256; i++)
		{
			array[i] = i;
		}
		int[] array2 = new int[256];
		for (i = 0; i < 256; i++)
		{
			array2[i] = (int)text3[i % length];
		}
		i = 0;
		int num2 = 0;
		while (i < 256)
		{
			num2 = (num2 + array[i] + array2[i]) % 256;
			int num3 = array[i];
			array[i] = array[num2];
			array[num2] = num3;
			i++;
		}
		byte[] array3 = new byte[length2];
		int num4 = 0;
		num2 = 0;
		for (i = 0; i < length2; i++)
		{
			num4 = (num4 + 1) % 256;
			num2 = (num2 + array[num4]) % 256;
			int num3 = array[num4];
			array[num4] = array[num2];
			array[num2] = num3;
			array3[i] = (byte)((int)string_0[i] ^ array[(array[num4] + array[num2]) % 256]);
		}
		text4 = Encoding.GetEncoding(UCConfig.UC_CHARSET).GetString(array3);
		string result;
		if (string_1.Equals("DECODE"))
		{
			if ((long.Parse(text4.Substring(0, 10)) == 0L || long.Parse(text4.Substring(0, 10)) > Class0.smethod_7()) && text4.Substring(10, 16).Equals(Class0.smethod_6(text4.Substring(26) + str2).Substring(0, 16)))
			{
				result = text4.Substring(26);
			}
			else
			{
				result = string.Empty;
			}
		}
		else
		{
			result = text2 + Class0.smethod_9(array3).Replace("=", string.Empty);
		}
		return result;
	}
}
