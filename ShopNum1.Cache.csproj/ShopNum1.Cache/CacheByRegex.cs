using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
namespace ShopNum1.Cache
{
	public class CacheByRegex
	{
		[CompilerGenerated]
		private sealed class Class0
		{
			public string string_0;
			public bool method_0(string string_1)
			{
				return string_1 == this.string_0;
			}
		}
		[CompilerGenerated]
		private sealed class Class1
		{
			public Regex regex_0;
			public bool method_0(string string_0)
			{
				return this.regex_0.IsMatch(string_0);
			}
		}
        private static readonly System.Web.Caching.Cache cache_0 = HttpContext.Current.Cache;
		private static List<string> list_0 = new List<string>();
		private static void smethod_0(string string_0)
		{
			CacheByRegex.Class0 @class = new CacheByRegex.Class0();
			@class.string_0 = string_0;
			if (!CacheByRegex.list_0.Exists(new Predicate<string>(@class.method_0)))
			{
				CacheByRegex.list_0.Add(@class.string_0);
			}
		}
		public static void Set(string string_0, object value)
		{
			CacheByRegex.smethod_0(string_0);
			CacheByRegex.cache_0.Insert(string_0, value);
		}
		public static void Remove(string string_0, bool match)
		{
			if (!match)
			{
				CacheByRegex.cache_0.Remove(string_0);
			}
			else
			{
				CacheByRegex.Class1 @class = new CacheByRegex.Class1();
				@class.regex_0 = new Regex(string_0, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
				List<string> list = CacheByRegex.list_0.FindAll(new Predicate<string>(@class.method_0));
				foreach (string current in list)
				{
					CacheByRegex.cache_0.Remove(current);
				}
			}
		}
	}
}
