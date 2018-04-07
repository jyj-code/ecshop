using System;
using System.Text;
namespace ShopNum1.Ucenter.Request
{
	public static class UCAuthCode
	{
		private static string smethod_0(string string_0, string string_1, string string_2, int int_0)
		{
			string result;
			if (Utils.StrIsNullOrEmpty(string_0) || Utils.StrIsNullOrEmpty(string_2))
			{
				result = "";
			}
			else
			{
				int num = 4;
				string_2 = Utils.MD5(string_2);
				string str = Utils.MD5(Utils.CutString(string_2, 0, 16));
				string str2 = Utils.MD5(Utils.CutString(string_2, 16, 16));
				string text = (string_1 == "DECODE") ? Utils.CutString(string_0, 0, num) : Utils.RandomString(num);
				string string_3 = str + Utils.MD5(str + text);
				if (string_1 == "DECODE")
				{
					byte[] byte_;
					try
					{
						byte_ = Convert.FromBase64String(Utils.CutString(string_0, num));
					}
					catch
					{
						try
						{
							byte_ = Convert.FromBase64String(Utils.CutString(string_0 + "=", num));
						}
						catch
						{
							try
							{
								byte_ = Convert.FromBase64String(Utils.CutString(string_0 + "==", num));
							}
							catch
							{
								result = "";
								return result;
							}
						}
					}
					string @string = Encoding.UTF8.GetString(UCAuthCode.smethod_2(byte_, string_3));
					if (Utils.CutString(@string, 10, 16) == Utils.CutString(Utils.MD5(Utils.CutString(@string, 26) + str2), 0, 16))
					{
						result = Utils.CutString(@string, 26);
					}
					else
					{
						result = "";
					}
				}
				else
				{
					string_0 = "0000000000" + Utils.CutString(Utils.MD5(string_0 + str2), 0, 16) + string_0;
					byte[] inArray = UCAuthCode.smethod_2(Encoding.UTF8.GetBytes(string_0), string_3);
					result = text + Convert.ToBase64String(inArray);
				}
			}
			return result;
		}
		public static string AuthCodeDecode(string string_0, string string_1)
		{
			return UCAuthCode.smethod_0(string_0, "DECODE", string_1, 0);
		}
		public static string AuthCodeDecode(string string_0, string string_1, int expiry)
		{
			return UCAuthCode.smethod_0(string_0, "DECODE", string_1, expiry);
		}
		public static string AuthCodeEncode(string string_0, string string_1)
		{
			return UCAuthCode.smethod_0(string_0, "ENCODE", string_1, 0);
		}
		public static string AuthCodeEncode(string string_0, string string_1, int expiry)
		{
			return UCAuthCode.smethod_0(string_0, "ENCODE", string_1, expiry);
		}
		private static byte[] smethod_1(byte[] byte_0, int int_0)
		{
			byte[] array = new byte[int_0];
			for (long num = 0L; num < (long)int_0; num += 1L)
			{
				array[(int)((IntPtr)num)] = (byte)num;
			}
			long num2 = 0L;
			for (long num3 = 0L; num3 < (long)int_0; num3 += 1L)
			{
				num2 = (num2 + (long)((ulong)array[(int)((IntPtr)num3)]) + (long)((ulong)byte_0[(int)((IntPtr)(num3 % (long)byte_0.Length))])) % (long)int_0;
				byte b = array[(int)((IntPtr)num3)];
				array[(int)((IntPtr)num3)] = array[(int)((IntPtr)num2)];
				array[(int)((IntPtr)num2)] = b;
			}
			return array;
		}
		private static byte[] smethod_2(byte[] byte_0, string string_0)
		{
            if ((byte_0 == null) || (string_0 == null))
            {
                return null;
            }
            Encoding encoding = Encoding.UTF8;
            byte[] buffer2 = new byte[byte_0.Length];
            byte[] buffer3 = smethod_1(encoding.GetBytes(string_0), 0x100);
            long num2 = 0L;
            long num3 = 0L;
            for (long i = 0L; i < byte_0.Length; i += 1L)
            {
                num2 = (num2 + 1L) % ((long)buffer3.Length);
                num3 = (num3 + buffer3[(int)((IntPtr)num2)]) % ((long)buffer3.Length);
                byte num4 = buffer3[(int)((IntPtr)num2)];
                buffer3[(int)((IntPtr)num2)] = buffer3[(int)((IntPtr)num3)];
                buffer3[(int)((IntPtr)num3)] = num4;
                byte num5 = byte_0[(int)((IntPtr)i)];
                byte num6 = buffer3[(buffer3[(int)((IntPtr)num2)] + buffer3[(int)((IntPtr)num3)]) % buffer3.Length];
                buffer2[(int)((IntPtr)i)] = (byte)(num5 ^ num6);
            }
            return buffer2;

		}
	}
}
