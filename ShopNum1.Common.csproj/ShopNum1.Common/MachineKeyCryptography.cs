using System;
using System.Text;
using System.Web.Security;
namespace ShopNum1.Common
{
    public static class MachineKeyCryptography
    {
        public static string Encode(string text)
        {
            return MachineKeyCryptography.Encode(text, CookieProtection.All);
        }
        public static string Encode(string text, CookieProtection cookieProtection)
        {
            string result = text;
            try
            {
                if (string.IsNullOrEmpty(text) || cookieProtection == CookieProtection.None)
                {
                    result = text;
                }
                else
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(text);
                    result = CookieProtectionHelperWrapper.Encode(cookieProtection, bytes, bytes.Length);
                }
            }
            catch { }
            return result;
        }
        public static string Decode(string text)
        {
            return MachineKeyCryptography.Decode(text, CookieProtection.All);
        }
        public static string Decode(string text, CookieProtection cookieProtection)
        {
            string result;
            if (string.IsNullOrEmpty(text))
            {
                result = text;
            }
            else
            {
                byte[] array;
                try
                {
                    array = CookieProtectionHelperWrapper.Decode(cookieProtection, text);
                }
                catch (Exception ex)
                {
                    throw new InvalidCypherTextException("Unable to decode the text", ex.InnerException);
                }
                if (array == null || array.Length == 0)
                {
                    throw new InvalidCypherTextException("Unable to decode the text");
                }
                result = Encoding.UTF8.GetString(array, 0, array.Length);
            }
            return result;
        }
    }
}
