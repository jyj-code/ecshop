using System;
namespace ShopNum1.QRCode.ExceptionHandler
{
	[Serializable]
	public class InvalidVersionException : VersionInformationException
	{
		internal string string_0;
		public override string Message
		{
			get
			{
				return this.string_0;
			}
		}
		public InvalidVersionException(string message)
		{
			this.string_0 = message;
		}
	}
}
