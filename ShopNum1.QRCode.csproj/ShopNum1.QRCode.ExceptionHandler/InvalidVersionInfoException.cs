using System;
namespace ShopNum1.QRCode.ExceptionHandler
{
	[Serializable]
	public class InvalidVersionInfoException : VersionInformationException
	{
		internal string string_0 = null;
		public override string Message
		{
			get
			{
				return this.string_0;
			}
		}
		public InvalidVersionInfoException(string message)
		{
			this.string_0 = message;
		}
	}
}
