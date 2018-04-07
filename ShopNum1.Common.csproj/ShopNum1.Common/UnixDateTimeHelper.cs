using System;
namespace ShopNum1.Common
{
	public static class UnixDateTimeHelper
	{
		private static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		private static readonly DateTime dateTime_1 = new DateTime(2038, 1, 19, 3, 14, 7, 0, DateTimeKind.Utc);
		public static int ConvertToUnixTimestamp(DateTime dateTime)
		{
			return Convert.ToInt32(Math.Floor((dateTime.ToUniversalTime() - UnixDateTimeHelper.dateTime_0).TotalSeconds));
		}
		public static DateTime ConvertFromUnixTimestamp(int timestamp)
		{
			return (UnixDateTimeHelper.dateTime_0 + TimeSpan.FromSeconds((double)timestamp)).ToLocalTime();
		}
	}
}
