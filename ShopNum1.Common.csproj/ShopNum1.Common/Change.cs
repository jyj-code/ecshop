using System;
namespace ShopNum1.Common
{
	public static class Change
	{
		public static string ChangeYesNo(string isDefault)
		{
			string result;
			if (isDefault == "1")
			{
				result = "是";
			}
			else
			{
				result = "否";
			}
			return result;
		}
	}
}
