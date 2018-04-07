using System;
using System.Collections;
namespace ShopNum1.Ucenter.Request
{
	public class Func
	{
		public static int uc_user_register(string username, string password, string email)
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("username", username);
			hashtable.Add("password", password);
			hashtable.Add("email", email);
			string s = Class0.smethod_0("user", "register", hashtable);
			hashtable.Clear();
			int result;
			try
			{
				result = int.Parse(s);
			}
			catch
			{
				result = -7;
			}
			return result;
		}
		public static string uc_user_registerstring(string username, string password, string email)
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("username", username);
			hashtable.Add("password", password);
			hashtable.Add("email", email);
			string result = Class0.smethod_0("user", "register", hashtable);
			hashtable.Clear();
			return result;
		}
		public static string ceshiuc_user_login(string username, string password)
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("username", username);
			hashtable.Add("password", password);
			string result = Class0.smethod_0("user", "login", hashtable);
			hashtable.Clear();
			return result;
		}
		public static string uc_user_synlogin(int int_0)
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("uid", int_0);
			string result = Class0.smethod_0("user", "synlogin", hashtable);
			hashtable.Clear();
			return result;
		}
		public static string uc_user_synlogout()
		{
			Hashtable hashtable_ = new Hashtable();
			return Class0.smethod_0("user", "synlogout", hashtable_);
		}
		public static string uc_user_Del(string string_0)
		{
			return Class0.smethod_0("user", "delete", new Hashtable
			{

				{
					"uid",
					string_0
				}
			});
		}
		public static RTN_UserLogin uc_user_login(string username, string password)
		{
			return Func.uc_user_login(username, password, false);
		}
		public static RTN_UserLogin uc_user_login(string username, string password, bool isuid)
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("username", username);
			hashtable.Add("password", password);
			hashtable.Add("isuid", isuid ? 1 : 0);
			string string_ = Class0.smethod_0("user", "login", hashtable);
			hashtable.Clear();
			hashtable = Class0.smethod_1(string_);
			RTN_UserLogin result;
			if (hashtable == null)
			{
				result = new RTN_UserLogin(-9, "", "", "", false);
			}
			else
			{
				result = new RTN_UserLogin(int.Parse((string)hashtable[0]), (string)hashtable[1], (string)hashtable[2], (string)hashtable[3], !"0".Equals((string)hashtable[4]));
			}
			return result;
		}
		public static int uc_user_edit(string username, string oldpw, string newpw, string email, bool ignoreoldpw)
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("username", username);
			hashtable.Add("oldpw", oldpw);
			hashtable.Add("newpw", newpw);
			hashtable.Add("email", email);
			hashtable.Add("ignoreoldpw", ignoreoldpw);
			string s = Class0.smethod_0("user", "edit", hashtable);
			hashtable.Clear();
			int result;
			try
			{
				result = int.Parse(s);
			}
			catch
			{
				result = 0;
			}
			return result;
		}
	}
}
