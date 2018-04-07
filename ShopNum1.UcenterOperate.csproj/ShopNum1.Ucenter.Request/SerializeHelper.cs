using System;
using System.Collections;
using System.Text;
using System.Xml;
namespace ShopNum1.Ucenter.Request
{
	public sealed class SerializeHelper
	{
		private static void smethod_0(XmlNode xmlNode_0, Hashtable hashtable_0)
		{
			foreach (XmlNode xmlNode in xmlNode_0.ChildNodes)
			{
				hashtable_0.Add(xmlNode.Name.Substring(xmlNode.Name.IndexOf('_') + 1), xmlNode.InnerText);
			}
		}
		public static string Serialize(Hashtable args, bool htmlOn)
		{
			return SerializeHelper.smethod_1(args, htmlOn, 1);
		}
		private static string smethod_1(Hashtable hashtable_0, bool bool_0, int int_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (int_0 <= 1)
			{
				stringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
				stringBuilder.AppendLine("<root>");
			}
			foreach (DictionaryEntry dictionaryEntry in hashtable_0)
			{
				if (dictionaryEntry.Value is Hashtable)
				{
					stringBuilder.AppendLine("<item_" + dictionaryEntry.Key.ToString() + ">");
					stringBuilder.AppendLine(SerializeHelper.smethod_1((Hashtable)dictionaryEntry.Value, bool_0, int_0 + 1));
					stringBuilder.AppendLine("</item>");
				}
				else
				{
					stringBuilder.AppendFormat(bool_0 ? "<item_{0}><![CDATA[{1}]]></item>\r\n" : "<item_{0}>{1}</item>\r\n", dictionaryEntry.Key, dictionaryEntry.Value);
				}
			}
			if (int_0 == 1)
			{
				stringBuilder.AppendLine("</root>");
			}
			return stringBuilder.ToString();
		}
		public static Hashtable UnSerialize(string string_0)
		{
			return SerializeHelper.UnSerialize(string_0, "root");
		}
		public static Hashtable UnSerialize(string string_0, string rootNodeName)
		{
			Hashtable hashtable = new Hashtable();
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(string_0);
				XmlNode xmlNode_ = xmlDocument.SelectSingleNode(rootNodeName);
				SerializeHelper.smethod_0(xmlNode_, hashtable);
			}
			catch
			{
			}
			Console.WriteLine("----------------HT---------------------");
			return hashtable;
		}
	}
}
