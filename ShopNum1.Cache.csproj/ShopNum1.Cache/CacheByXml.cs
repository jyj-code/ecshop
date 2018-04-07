using System;
using System.Collections;
using System.Web;
using System.Web.Caching;
using System.Xml;
namespace ShopNum1.Cache
{
	public class CacheByXml
	{
		public static XmlElement objectXmlMap;
		public static XmlDocument rootXml;
		protected static volatile System.Web.Caching.Cache webCache;
		private static object object_0;
		static CacheByXml()
		{
			CacheByXml.rootXml = new XmlDocument();
			CacheByXml.webCache = HttpRuntime.Cache;
			CacheByXml.object_0 = new object();
			CacheByXml.objectXmlMap = CacheByXml.rootXml.CreateElement("Cache");
			CacheByXml.rootXml.AppendChild(CacheByXml.objectXmlMap);
		}
		public static void Add(string xpath, object object_1)
		{
			string text = CacheByXml.smethod_1(xpath);
			int num = text.LastIndexOf("/");
			string text2 = text.Substring(0, num);
			string name = text.Substring(num + 1);
			XmlNode xmlNode = CacheByXml.objectXmlMap.SelectSingleNode(text2);
			string text3 = "";
			XmlNode xmlNode2 = CacheByXml.objectXmlMap.SelectSingleNode(CacheByXml.smethod_1(xpath));
			if (xmlNode2 != null)
			{
				text3 = xmlNode2.Attributes["objectId"].Value;
			}
			if (text3 == "")
			{
				xmlNode = CacheByXml.smethod_0(text2);
				text3 = Guid.NewGuid().ToString();
				XmlElement xmlElement = CacheByXml.objectXmlMap.OwnerDocument.CreateElement(name);
				XmlAttribute xmlAttribute = CacheByXml.objectXmlMap.OwnerDocument.CreateAttribute("objectId");
				xmlAttribute.Value = text3;
				xmlElement.Attributes.Append(xmlAttribute);
				xmlNode.AppendChild(xmlElement);
			}
			else
			{
				XmlElement xmlElement = CacheByXml.objectXmlMap.OwnerDocument.CreateElement(name);
				XmlAttribute xmlAttribute = CacheByXml.objectXmlMap.OwnerDocument.CreateAttribute("objectId");
				xmlAttribute.Value = text3;
				xmlElement.Attributes.Append(xmlAttribute);
				xmlNode.ReplaceChild(xmlElement, xmlNode2);
			}
			CacheByXml.webCache.Insert(text3, object_1);
		}
		public static object Get(string xpath)
		{
			object result = null;
			XmlNode xmlNode = CacheByXml.objectXmlMap.SelectSingleNode(CacheByXml.smethod_1(xpath));
			if (xmlNode != null)
			{
				string value = xmlNode.Attributes["objectId"].Value;
				result = CacheByXml.webCache.Get(value);
			}
			return result;
		}
		public static object[] GetList(string xpath)
		{
			XmlNode xmlNode = CacheByXml.objectXmlMap.SelectSingleNode(CacheByXml.smethod_1(xpath));
			XmlNodeList xmlNodeList = xmlNode.SelectNodes(CacheByXml.smethod_1(xpath) + "/*[@objectId]");
			ArrayList arrayList = new ArrayList();
			foreach (XmlNode xmlNode2 in xmlNodeList)
			{
				string value = xmlNode2.Attributes["objectId"].Value;
				arrayList.Add(CacheByXml.webCache.Get(value));
			}
			return (object[])arrayList.ToArray(typeof(object));
		}
		public static void Remove(string xpath)
		{
			lock (CacheByXml.object_0)
			{
				XmlNode xmlNode = CacheByXml.objectXmlMap.SelectSingleNode(CacheByXml.smethod_1(xpath));
				string value;
				if (xmlNode.HasChildNodes)
				{
					XmlNodeList xmlNodeList = xmlNode.SelectNodes("*[@objectId]");
					IEnumerator enumerator = xmlNodeList.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							XmlNode xmlNode2 = (XmlNode)enumerator.Current;
							value = xmlNode2.Attributes["objectId"].Value;
							xmlNode2.ParentNode.RemoveChild(xmlNode2);
							CacheByXml.webCache.Remove(value);
						}
						goto IL_DE;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				value = xmlNode.Attributes["objectId"].Value;
				xmlNode.ParentNode.RemoveChild(xmlNode);
				CacheByXml.webCache.Remove(value);
				IL_DE:;
			}
		}
		private static XmlNode smethod_0(string string_0)
		{
			XmlNode result;
			lock (CacheByXml.object_0)
			{
				string[] array = string_0.Split(new char[]
				{
					'/'
				});
				string text = "";
				XmlNode xmlNode = CacheByXml.objectXmlMap;
				for (int i = 1; i < array.Length; i++)
				{
					XmlNode xmlNode2 = CacheByXml.objectXmlMap.SelectSingleNode(text + "/" + array[i]);
					if (xmlNode2 == null)
					{
						XmlElement newChild = CacheByXml.objectXmlMap.OwnerDocument.CreateElement(array[i]);
						xmlNode.AppendChild(newChild);
					}
					text = text + "/" + array[i];
					xmlNode = CacheByXml.objectXmlMap.SelectSingleNode(text);
				}
				result = xmlNode;
			}
			return result;
		}
		private static string smethod_1(string string_0)
		{
			string[] array = string_0.Split(new char[]
			{
				'/'
			});
			string_0 = "/Cache";
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				if (text != "")
				{
					string_0 = string_0 + "/" + text;
				}
			}
			return string_0;
		}
	}
}
