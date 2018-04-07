using System;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
namespace ShopNum1.Common
{
	public static class CookieProtectionHelperWrapper
	{
		private static MethodInfo methodInfo_0;
		private static MethodInfo methodInfo_1;
		static CookieProtectionHelperWrapper()
		{
			Assembly assembly = typeof(HttpContext).Assembly;
			if (assembly == null)
			{
				throw new InvalidOperationException("Unable to load System.Web.");
			}
			Type type = assembly.GetType("System.Web.Security.CookieProtectionHelper");
			if (type == null)
			{
				throw new InvalidOperationException("Unable to get the internal class System.Web.Security.CookieProtectionHelper.");
			}
			CookieProtectionHelperWrapper.methodInfo_0 = type.GetMethod("Encode", BindingFlags.Static | BindingFlags.NonPublic);
			CookieProtectionHelperWrapper.methodInfo_1 = type.GetMethod("Decode", BindingFlags.Static | BindingFlags.NonPublic);
			if (CookieProtectionHelperWrapper.methodInfo_0 == null || CookieProtectionHelperWrapper.methodInfo_1 == null)
			{
				throw new InvalidOperationException("Unable to get the methods to invoke.");
			}
		}
		public static string Encode(CookieProtection cookieProtection, byte[] byte_0, int count)
		{
			return (string)CookieProtectionHelperWrapper.methodInfo_0.Invoke(null, new object[]
			{
				cookieProtection,
				byte_0,
				count
			});
		}
		public static byte[] Decode(CookieProtection cookieProtection, string data)
		{
            try
            {
                return (byte[])CookieProtectionHelperWrapper.methodInfo_1.Invoke(null, new object[]
                    {
                cookieProtection,
                data
                    });
            }
            catch (Exception)
            {
                return Encoding.UTF8.GetBytes(data);
            }
		}
	}
}
