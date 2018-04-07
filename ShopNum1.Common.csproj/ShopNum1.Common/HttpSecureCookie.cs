using System;
using System.Web;
using System.Web.Security;
namespace ShopNum1.Common
{
	public static class HttpSecureCookie
	{
		public static HttpCookie Encode(HttpCookie cookie)
		{
			return HttpSecureCookie.Encode(cookie, CookieProtection.All);
		}
		public static HttpCookie Encode(HttpCookie cookie, CookieProtection cookieProtection)
		{
			HttpCookie httpCookie = HttpSecureCookie.CloneCookie(cookie);
			httpCookie.Value = MachineKeyCryptography.Encode(cookie.Value, cookieProtection);
			return httpCookie;
		}
		public static HttpCookie Decode(HttpCookie cookie)
		{
			HttpCookie result;
			if (cookie == null)
			{
				result = null;
			}
			else
			{
				result = HttpSecureCookie.Decode(cookie, CookieProtection.All);
			}
			return result;
		}
		public static HttpCookie Decode(HttpCookie cookie, CookieProtection cookieProtection)
		{
			HttpCookie result;
			if (cookie == null)
			{
				result = null;
			}
			else
			{
				HttpCookie httpCookie = HttpSecureCookie.CloneCookie(cookie);
				httpCookie.Value = MachineKeyCryptography.Decode(cookie.Value, cookieProtection);
				result = httpCookie;
			}
			return result;
		}
		public static HttpCookie CloneCookie(HttpCookie cookie)
		{
			return new HttpCookie(cookie.Name, cookie.Value)
			{
				Domain = cookie.Domain,
				Expires = cookie.Expires,
				HttpOnly = cookie.HttpOnly,
				Path = cookie.Path,
				Secure = cookie.Secure
			};
		}
	}
}
