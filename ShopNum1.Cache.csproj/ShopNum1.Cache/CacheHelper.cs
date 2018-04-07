using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
namespace ShopNum1.Cache
{
	public class CacheHelper
	{
		public static readonly int DayFactor;
		public static readonly int HourFactor;
		public static readonly int MinuteFactor;
		public static readonly double SecondFactor;
		private static int int_0;
        private static readonly System.Web.Caching.Cache cache_0;
		private static readonly string string_0;
		private CacheHelper()
		{
		}
		public static void ReSetFactor(int cacheFactor)
		{
			CacheHelper.int_0 = cacheFactor;
		}
		static CacheHelper()
		{
			CacheHelper.DayFactor = 17280;
			CacheHelper.HourFactor = 720;
			CacheHelper.MinuteFactor = 12;
			CacheHelper.SecondFactor = 0.2;
			CacheHelper.int_0 = 5;
			CacheHelper.string_0 = "ShopNum1Cache";
			HttpContext current = HttpContext.Current;
			if (current != null)
			{
				CacheHelper.cache_0 = current.Cache;
			}
			else
			{
				CacheHelper.cache_0 = HttpRuntime.Cache;
			}
		}
		public static void Clear()
		{
			IDictionaryEnumerator enumerator = CacheHelper.cache_0.GetEnumerator();
			ArrayList arrayList = new ArrayList();
			while (enumerator.MoveNext())
			{
				arrayList.Add(enumerator.Key);
			}
			foreach (string key in arrayList)
			{
				CacheHelper.cache_0.Remove(key);
			}
		}
		public static void RemoveByPattern(string pattern)
		{
			IDictionaryEnumerator enumerator = CacheHelper.cache_0.GetEnumerator();
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
			while (enumerator.MoveNext())
			{
				if (regex.IsMatch(CacheHelper.string_0 + enumerator.Key.ToString()))
				{
					CacheHelper.cache_0.Remove(CacheHelper.string_0 + enumerator.Key.ToString());
				}
			}
		}
		public static void Remove(string string_1)
		{
			CacheHelper.cache_0.Remove(CacheHelper.string_0 + string_1);
		}
		public static void Insert(string string_1, object object_0)
		{
			CacheHelper.Insert(string_1, object_0, null, 1);
		}
		public static void Insert(string string_1, object object_0, CacheDependency cacheDependency_0)
		{
			CacheHelper.Insert(string_1, object_0, cacheDependency_0, CacheHelper.MinuteFactor * 3);
		}
		public static void Insert(string string_1, object object_0, int seconds)
		{
			CacheHelper.Insert(string_1, object_0, null, seconds);
		}
		public static void Insert(string string_1, object object_0, int seconds, CacheItemPriority priority)
		{
			CacheHelper.Insert(string_1, object_0, null, seconds, priority);
		}
		public static void Insert(string string_1, object object_0, CacheDependency cacheDependency_0, int seconds)
		{
			CacheHelper.Insert(string_1, object_0, cacheDependency_0, seconds, CacheItemPriority.Normal);
		}
		public static void Insert(string string_1, object object_0, CacheDependency cacheDependency_0, int seconds, CacheItemPriority priority)
		{
			if (object_0 != null)
			{
				CacheHelper.cache_0.Insert(CacheHelper.string_0 + string_1, object_0, cacheDependency_0, DateTime.Now.AddSeconds((double)(CacheHelper.int_0 * seconds)), TimeSpan.Zero, priority, null);
			}
		}
		public static object Get(string string_1)
		{
			return CacheHelper.cache_0[CacheHelper.string_0 + string_1];
		}
	}
}
