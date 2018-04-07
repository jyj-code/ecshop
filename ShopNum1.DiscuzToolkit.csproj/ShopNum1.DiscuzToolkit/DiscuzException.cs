using System;
namespace ShopNum1.DiscuzToolkit
{
	public class DiscuzException : Exception
	{
		private int int_0;
		private string string_0;
		public int ErrorCode
		{
			get
			{
				return this.int_0;
			}
		}
		public string ErrorMessage
		{
			get
			{
				return this.string_0;
			}
		}
		public DiscuzException(int error_code, string error_message) : base(DiscuzException.smethod_0(error_code, error_message))
		{
			this.int_0 = error_code;
			this.string_0 = error_message;
		}
		private static string smethod_0(int int_1, string string_1)
		{
			return string.Format("Code: {0}, Message: {1}", int_1, string_1);
		}
	}
}
