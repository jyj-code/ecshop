using System;
namespace Com.Alipay
{
	public class AliPayDirectConfig
	{
		private static string string_0;
		private static string string_1;
		private static string string_2;
		private static string string_3;
		public static string Partner
		{
			get
			{
				return AliPayDirectConfig.string_0;
			}
			set
			{
				AliPayDirectConfig.string_0 = value;
			}
		}
		public static string Key
		{
			get
			{
				return AliPayDirectConfig.string_1;
			}
			set
			{
				AliPayDirectConfig.string_1 = value;
			}
		}
		public static string Input_charset
		{
			get
			{
				return AliPayDirectConfig.string_2;
			}
		}
		public static string Sign_type
		{
			get
			{
				return AliPayDirectConfig.string_3;
			}
		}
		static AliPayDirectConfig()
		{
			AliPayDirectConfig.string_0 = "";
			AliPayDirectConfig.string_1 = "";
			AliPayDirectConfig.string_2 = "";
			AliPayDirectConfig.string_3 = "";
			AliPayDirectConfig.string_0 = "";
			AliPayDirectConfig.string_1 = "";
			AliPayDirectConfig.string_2 = "utf-8";
			AliPayDirectConfig.string_3 = "MD5";
		}
	}
}
