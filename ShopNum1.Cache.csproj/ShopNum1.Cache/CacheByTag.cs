using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
namespace ShopNum1.Cache
{
	public class CacheByTag
	{
        private static readonly System.Web.Caching.Cache cache_0 = HttpContext.Current.Cache;
		private static string smethod_0(string string_0)
		{
			return "project_name/" + string_0;
		}
		public static object Get(string string_0)
		{
			string_0 = CacheByTag.smethod_0(string_0);
			object obj = CacheByTag.cache_0.Get(string_0);
			if (obj == null)
			{
			}
			return obj;
		}
		public static void Set(string string_0, object value)
		{
			string_0 = CacheByTag.smethod_0(string_0);
			CacheByTag.cache_0.Insert(string_0, value);
		}
		public static void Set(string string_0, object value, string[] tags)
		{
			if (tags.Length == 0)
			{
				CacheByTag.Set(string_0, value);
			}
			for (int i = 0; i < tags.Length; i++)
			{
				tags[i] = "tags/" + tags[i];
			}
			List<string> list = new List<string>();
			for (int j = 0; j < tags.Length; j++)
			{
				string string_ = tags[j];
				object obj = CacheByTag.Get(string_);
				if (obj != null)
				{
					list = (List<string>)obj;
				}
				list.Add(string_0);
				CacheByTag.Set(string_, list);
			}
			CacheByTag.Set(string_0, value);
		}
		public static void Remove(string string_0)
		{
			string_0 = CacheByTag.smethod_0(string_0);
			CacheByTag.cache_0.Remove(string_0);
		}
		public static void RemoveByTags(string[] tags)
		{
			for (int i = 0; i < tags.Length; i++)
			{
				tags[i] = "tags/" + tags[i];
			}
			List<string> list = new List<string>();
			for (int j = 0; j < tags.Length; j++)
			{
				string string_ = tags[j];
				object obj = CacheByTag.Get(string_);
				if (obj != null)
				{
					list = (List<string>)obj;
					foreach (string current in list)
					{
						CacheByTag.Remove(current);
					}
				}
				CacheByTag.Remove(string_);
			}
		}
	}
}
