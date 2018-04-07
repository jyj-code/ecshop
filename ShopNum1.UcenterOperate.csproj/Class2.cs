using System;
using System.Collections;
using System.Xml;
internal class Class2
{
	public static Hashtable smethod_0(string string_0)
	{
		string_0 = string_0.Replace("&", "&amp;");
		Hashtable hashtable = new Hashtable();
		Hashtable result;
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(string_0);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("root");
			int num = 0;
			foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
			{
				hashtable.Add(num++, xmlNode2.InnerText);
			}
		}
		catch
		{
			result = null;
			return result;
		}
		result = hashtable;
		return result;
	}
}
