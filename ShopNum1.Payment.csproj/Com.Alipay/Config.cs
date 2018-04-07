using System;
namespace Com.Alipay
{
	public class Config
	{
		private static string string_0;
		private static string string_1;
		private static string string_2;
		private static string string_3;
		public static string Partner
		{
			get
			{
				return Config.string_0;
			}
			set
			{
				Config.string_0 = value;
			}
		}
		public static string Key
		{
			get
			{
				return Config.string_1;
			}
			set
			{
				Config.string_1 = value;
			}
		}
		public static string Input_charset
		{
			get
			{
				return Config.string_2;
			}
		}
		public static string Sign_type
		{
			get
			{
				return Config.string_3;
			}
		}
		static Config()
		{
			Config.string_0 = "";
			Config.string_1 = "";
			Config.string_2 = "";
			Config.string_3 = "";
			Config.string_0 = "";
			Config.string_1 = "";
			Config.string_2 = "utf-8";
			Config.string_3 = "MD5";
		}
	}
}
