using System;
using System.Collections;
using System.Web;
using System.Web.Caching;
namespace ShopNum1.Cache
{
	public class DefaultCacheStrategy : ICacheStrategy
	{
        protected static volatile System.Web.Caching.Cache webCache;
		protected int _timeOut = 3600;
		private static object object_0;
		public virtual int TimeOut
		{
			get
			{
				return (this._timeOut > 0) ? this._timeOut : 3600;
			}
			set
			{
				this._timeOut = ((value > 0) ? value : 3600);
			}
		}
        public static System.Web.Caching.Cache GetWebCacheObj
		{
			get
			{
				return DefaultCacheStrategy.webCache;
			}
		}
		static DefaultCacheStrategy()
		{
			DefaultCacheStrategy.webCache = HttpRuntime.Cache;
			DefaultCacheStrategy.object_0 = new object();
		}
		public virtual void AddObject(string objId, object object_1)
		{
			if (objId != null && objId.Length != 0 && object_1 != null)
			{
				if (this.TimeOut == 7200)
				{
					DefaultCacheStrategy.webCache.Insert(objId, object_1, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High, null);
				}
				else
				{
                    DefaultCacheStrategy.webCache.Insert(objId, object_1, null, DateTime.Now.AddSeconds((double)this.TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
				}
			}
		}
		public virtual void AddObject(string objId, object object_1, int expire)
		{
			if (objId != null && objId.Length != 0 && object_1 != null)
			{
				if (expire == 0)
				{
					DefaultCacheStrategy.webCache.Insert(objId, object_1, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High, null);
				}
				else
				{
                    DefaultCacheStrategy.webCache.Insert(objId, object_1, null, DateTime.Now.AddSeconds((double)expire), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
				}
			}
		}
		public virtual void AddObjectWithFileChange(string objId, object object_1, string[] files)
		{
			if (objId != null && objId.Length != 0 && object_1 != null)
			{
				CacheItemRemovedCallback onRemoveCallback = new CacheItemRemovedCallback(this.onRemove);
				CacheDependency dependencies = new CacheDependency(files, DateTime.Now);
                DefaultCacheStrategy.webCache.Insert(objId, object_1, dependencies, DateTime.Now.AddSeconds((double)this.TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, onRemoveCallback);
			}
		}
		public virtual void AddObjectWithDepend(string objId, object object_1, string[] dependKey)
		{
			if (objId != null && objId.Length != 0 && object_1 != null)
			{
				CacheItemRemovedCallback onRemoveCallback = new CacheItemRemovedCallback(this.onRemove);
				CacheDependency dependencies = new CacheDependency(null, dependKey, DateTime.Now);
                DefaultCacheStrategy.webCache.Insert(objId, object_1, dependencies, DateTime.Now.AddSeconds((double)this.TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, onRemoveCallback);
			}
		}
		public void onRemove(string string_0, object object_1, CacheItemRemovedReason reason)
		{
			switch (reason)
			{
			case CacheItemRemovedReason.Removed:
			case CacheItemRemovedReason.Expired:
			case CacheItemRemovedReason.Underused:
			case CacheItemRemovedReason.DependencyChanged:
				return;
			}
		}
		public virtual void RemoveObject(string objId)
		{
			if (objId != null && objId.Length != 0)
			{
				DefaultCacheStrategy.webCache.Remove(objId);
			}
		}
		public virtual object RetrieveObject(string objId)
		{
			object result;
			if (objId == null || objId.Length == 0)
			{
				result = null;
			}
			else
			{
				result = DefaultCacheStrategy.webCache.Get(objId);
			}
			return result;
		}
		public virtual void FlushAll()
		{
			IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DefaultCacheStrategy.webCache.Remove(enumerator.Key.ToString());
			}
		}
	}
}
