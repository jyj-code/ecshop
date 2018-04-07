using System;
using System.Collections;
namespace ShopNum1.Common
{
	public class VerifyImageProvider
	{
		private static Hashtable hashtable_0 = new Hashtable();
		private static object object_0 = new object();
		public static IVerifyImage GetInstance(string assemlyName)
		{
			if (!VerifyImageProvider.hashtable_0.ContainsKey(assemlyName))
			{
				lock (VerifyImageProvider.object_0)
				{
					if (!VerifyImageProvider.hashtable_0.ContainsKey(assemlyName))
					{
						IVerifyImage value = null;
						try
						{
							value = (IVerifyImage)Activator.CreateInstance(Type.GetType(string.Format("ShopNum1.Common.{0}.VerifyImage, ShopNum1.Common.{0}", assemlyName), false, true));
						}
						catch
						{
							value = new VerifyImage();
						}
						VerifyImageProvider.hashtable_0.Add(assemlyName, value);
					}
				}
			}
			return (IVerifyImage)VerifyImageProvider.hashtable_0[assemlyName];
		}
	}
}
