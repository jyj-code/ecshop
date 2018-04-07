using System;
using System.Web.Caching;
namespace ShopNum1.Cache
{
	public abstract class LogVisitor
	{
		protected static int m_IsWriteCachelog = 1;
		public int IsWriteCacheLog
		{
			get
			{
				return LogVisitor.m_IsWriteCachelog;
			}
			set
			{
				LogVisitor.m_IsWriteCachelog = value;
			}
		}
		public abstract void WriteLog(DefaultCacheStrategy defaultCacheStrategy_0, string string_0, object object_0, CacheItemRemovedReason reason);
	}
}
