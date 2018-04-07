using System;
using System.Data;
using System.IO;
using System.Xml;
namespace ShopNum1.Common
{
	public class XmlOperator : IDisposable
	{
		private bool bool_0 = false;
		public static DataSet GetXml(string XmlPath)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(XmlPath);
			return dataSet;
		}
		public static string ReadXmlReturnNode(string XmlPath, string Node)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(XmlPath);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(Node);
			return elementsByTagName.Item(0).InnerText.ToString();
		}
		public static XmlNodeList ReadXmlReturnNodeList(string XmlPath, string Node)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(XmlPath);
			return xmlDocument.SelectNodes(Node);
		}
		public static string ReadXmlReturnNodeText(string XmlPath, string Node)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(XmlPath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(Node);
			return xmlNode.InnerText.ToString();
		}
		public static DataSet GetXmlData(string xmlPath, string XmlPathNode)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			DataSet dataSet = new DataSet();
			StringReader reader = new StringReader(xmlDocument.SelectSingleNode(XmlPathNode).OuterXml);
			dataSet.ReadXml(reader);
			return dataSet;
		}
		public static void XmlNodeReplace(string xmlPath, string Node, string Content)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			xmlDocument.SelectSingleNode(Node).InnerText = Content;
			xmlDocument.Save(xmlPath);
		}
		public static void XmlNodeDelete(string xmlPath, string Node)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			string xpath = Node.Substring(0, Node.LastIndexOf("/"));
			xmlDocument.SelectSingleNode(xpath).RemoveChild(xmlDocument.SelectSingleNode(Node));
			xmlDocument.Save(xmlPath);
		}
		public static void XmlInsertNode(string xmlPath, string MailNode, string ChildNode, string Element, string Content)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(MailNode);
			XmlElement xmlElement = xmlDocument.CreateElement(ChildNode);
			xmlNode.AppendChild(xmlElement);
			XmlElement xmlElement2 = xmlDocument.CreateElement(Element);
			xmlElement2.InnerText = Content;
			xmlElement.AppendChild(xmlElement2);
			xmlDocument.Save(xmlPath);
		}
		public static void XmlInsertElement(string xmlPath, string MainNode, string Element, string Attrib, string AttribContent, string Content)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(MainNode);
			XmlElement xmlElement = xmlDocument.CreateElement(Element);
			xmlElement.SetAttribute(Attrib, AttribContent);
			xmlElement.InnerText = Content;
			xmlNode.AppendChild(xmlElement);
			xmlDocument.Save(xmlPath);
		}
		public static void XmlInsertElement(string xmlPath, string MainNode, string Node, string Attrib, string AttribValue, string Attrib2, string AttribValue2, string Attrib3, string AttribValue3)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(MainNode);
			XmlElement xmlElement = xmlDocument.CreateElement(Node);
			xmlElement.SetAttribute(Attrib, AttribValue);
			xmlElement.SetAttribute(Attrib2, AttribValue2);
			xmlElement.SetAttribute(Attrib3, AttribValue3);
			xmlNode.AppendChild(xmlElement);
			xmlDocument.Save(xmlPath);
		}
		public static void XmlInsertElement(string xmlPath, string MainNode, string Element, string Content)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(MainNode);
			XmlElement xmlElement = xmlDocument.CreateElement(Element);
			xmlElement.InnerText = Content;
			xmlNode.AppendChild(xmlElement);
			xmlDocument.Save(xmlPath);
		}
		public static void XmlDeleteElement(string xmlPath, string MainNode, string string_0, string value)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			XmlNodeList childNodes = xmlDocument.SelectSingleNode(MainNode).ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute(string_0) == value)
				{
					xmlElement.RemoveAll();
					xmlDocument.SelectSingleNode(MainNode).RemoveChild(xmlElement);
				}
			}
			xmlDocument.Save(xmlPath);
		}
		~XmlOperator()
		{
			this.Dispose();
		}
		protected virtual void Dispose(bool isDisposing)
		{
			if (!this.bool_0)
			{
				if (!isDisposing)
				{
				}
				this.bool_0 = true;
			}
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
