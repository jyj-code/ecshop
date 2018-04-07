using System;
namespace ShopNum1.DiscuzToolkit
{
	public enum ErrorType
	{
		API_EC_UNKNOWN = 1,
		API_EC_SERVICE,
		API_EC_METHOD,
		API_EC_TOO_MANY_CALLS,
		API_EC_BAD_IP,
		API_EC_PARAM = 100,
		API_EC_APPLICATION,
		API_EC_SESSIONKEY,
		API_EC_CALLID,
		API_EC_SIGNATURE
	}
}
