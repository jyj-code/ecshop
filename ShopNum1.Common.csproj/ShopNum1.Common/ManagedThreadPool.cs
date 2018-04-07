using System;
using System.Collections;
using System.Threading;
namespace ShopNum1.Common
{
	public class ManagedThreadPool
	{
		private class Class1
		{
			private WaitCallback waitCallback_0;
			private object object_0;
			public Class1(WaitCallback waitCallback_1, object object_1)
			{
				this.waitCallback_0 = waitCallback_1;
				this.object_0 = object_1;
			}
			public WaitCallback method_0()
			{
				return this.waitCallback_0;
			}
			public object method_1()
			{
				return this.object_0;
			}
		}
		private const int int_0 = 10;
		private static Queue queue_0;
		private static Semaphore semaphore_0;
		private static ArrayList arrayList_0;
		private static int int_1;
		private static object object_0;
		public static int MaxThreads
		{
			get
			{
				return 10;
			}
		}
		public static int ActiveThreads
		{
			get
			{
				return ManagedThreadPool.int_1;
			}
		}
		public static int WaitingCallbacks
		{
			get
			{
				int count;
				lock (ManagedThreadPool.object_0)
				{
					count = ManagedThreadPool.queue_0.Count;
				}
				return count;
			}
		}
		static ManagedThreadPool()
		{
			ManagedThreadPool.object_0 = new object();
			ManagedThreadPool.smethod_0();
		}
		private static void smethod_0()
		{
			ManagedThreadPool.queue_0 = new Queue();
			ManagedThreadPool.arrayList_0 = new ArrayList();
			ManagedThreadPool.int_1 = 0;
			ManagedThreadPool.semaphore_0 = new Semaphore(0);
			for (int i = 0; i < 10; i++)
			{
				Thread thread = new Thread(new ThreadStart(ManagedThreadPool.smethod_1));
				ManagedThreadPool.arrayList_0.Add(thread);
				thread.Name = "ManagedPoolThread #" + i.ToString();
				thread.IsBackground = true;
				thread.Start();
			}
		}
		public static void QueueUserWorkItem(WaitCallback callback)
		{
			ManagedThreadPool.QueueUserWorkItem(callback, null);
		}
		public static void QueueUserWorkItem(WaitCallback callback, object state)
		{
			ManagedThreadPool.Class1 obj = new ManagedThreadPool.Class1(callback, state);
			lock (ManagedThreadPool.object_0)
			{
				ManagedThreadPool.queue_0.Enqueue(obj);
			}
			ManagedThreadPool.semaphore_0.AddOne();
		}
		public static void Reset()
		{
			lock (ManagedThreadPool.object_0)
			{
				try
				{
					foreach (object current in ManagedThreadPool.queue_0)
					{
						ManagedThreadPool.Class1 @class = (ManagedThreadPool.Class1)current;
						if (@class.method_1() is IDisposable)
						{
							((IDisposable)@class.method_1()).Dispose();
						}
					}
				}
				catch
				{
				}
				try
				{
					foreach (Thread thread in ManagedThreadPool.arrayList_0)
					{
						if (thread != null)
						{
							thread.Abort("reset");
						}
					}
				}
				catch
				{
				}
				ManagedThreadPool.smethod_0();
			}
		}
		private static void smethod_1()
		{
			while (true)
			{
				ManagedThreadPool.semaphore_0.WaitOne();
				ManagedThreadPool.Class1 @class = null;
				lock (ManagedThreadPool.object_0)
				{
					if (ManagedThreadPool.queue_0.Count > 0)
					{
						try
						{
							@class = (ManagedThreadPool.Class1)ManagedThreadPool.queue_0.Dequeue();
						}
						catch
						{
						}
					}
				}
				if (@class != null)
				{
					try
					{
						Interlocked.Increment(ref ManagedThreadPool.int_1);
						@class.method_0()(@class.method_1());
					}
					catch
					{
					}
					finally
					{
						Interlocked.Decrement(ref ManagedThreadPool.int_1);
					}
				}
			}
		}
	}
}
