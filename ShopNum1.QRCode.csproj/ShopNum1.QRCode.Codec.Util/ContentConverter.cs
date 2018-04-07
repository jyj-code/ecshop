using System;
namespace ShopNum1.QRCode.Codec.Util
{
	public class ContentConverter
	{
		internal static char char_0 = '\n';
		public static string convert(string targetString)
		{
			string result;
			if (targetString == null)
			{
				result = targetString;
			}
			else
			{
				if (targetString.IndexOf("MEBKM:") > -1)
				{
					targetString = ContentConverter.smethod_0(targetString);
				}
				if (targetString.IndexOf("MECARD:") > -1)
				{
					targetString = ContentConverter.smethod_1(targetString);
				}
				if (targetString.IndexOf("MATMSG:") > -1)
				{
					targetString = ContentConverter.smethod_2(targetString);
				}
				if (targetString.IndexOf("http\\://") > -1)
				{
					targetString = ContentConverter.smethod_3(targetString, "http\\://", "\nhttp://");
				}
				result = targetString;
			}
			return result;
		}
		private static string smethod_0(string string_0)
		{
			string_0 = ContentConverter.smethod_4(string_0, "MEBKM:");
			string_0 = ContentConverter.smethod_4(string_0, "TITLE:");
			string_0 = ContentConverter.smethod_4(string_0, ";");
			string_0 = ContentConverter.smethod_4(string_0, "URL:");
			return string_0;
		}
		private static string smethod_1(string string_0)
		{
			string_0 = ContentConverter.smethod_4(string_0, "MECARD:");
			string_0 = ContentConverter.smethod_4(string_0, ";");
			string_0 = ContentConverter.smethod_3(string_0, "N:", "NAME1:");
			string_0 = ContentConverter.smethod_3(string_0, "SOUND:", ContentConverter.char_0 + "NAME2:");
			string_0 = ContentConverter.smethod_3(string_0, "TEL:", ContentConverter.char_0 + "TEL1:");
			string_0 = ContentConverter.smethod_3(string_0, "EMAIL:", ContentConverter.char_0 + "MAIL1:");
			string_0 += ContentConverter.char_0;
			return string_0;
		}
		private static string smethod_2(string string_0)
		{
			string text = ContentConverter.smethod_4(string_0, "MATMSG:");
			text = ContentConverter.smethod_4(text, ";");
			text = ContentConverter.smethod_3(text, "TO:", "MAILTO:");
			text = ContentConverter.smethod_3(text, "SUB:", '\n' + "SUBJECT:");
			text = ContentConverter.smethod_3(text, "BODY:", '\n' + "BODY:");
			return text + '\n';
		}
		private static string smethod_3(string string_0, string string_1, string string_2)
		{
			string text = string_0;
			for (int i = text.IndexOf(string_1, 0); i > -1; i = text.IndexOf(string_1, i + string_2.Length))
			{
				text = text.Substring(0, i) + string_2 + text.Substring(i + string_1.Length);
			}
			return text;
		}
		private static string smethod_4(string string_0, string string_1)
		{
			return ContentConverter.smethod_3(string_0, string_1, "");
		}
	}
}
