using System;
using System.Web;
using System.Web.Caching;
namespace ShopNum1.Cache
{
	public class FactoryDataCache
	{
		public static object GetCache(string CacheKey)
		{
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
			return cache[CacheKey];
		}
		public static void SetCache(string CacheKey, object objObject)
		{
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
			cache.Insert(CacheKey, objObject);
		}
	}
}
