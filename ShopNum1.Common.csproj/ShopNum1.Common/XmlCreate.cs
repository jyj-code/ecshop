using System;
using System.Collections;
using System.Xml;
namespace ShopNum1.Common
{
	public class XmlCreate : IDisposable
	{
		private bool bool_0 = false;
		private string string_0;
		private XmlDocument xmlDocument_0 = new XmlDocument();
		private XmlNode xmlNode_0;
		private XmlElement xmlElement_0;
		~XmlCreate()
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
		public void CreateXmlRoot(string root)
		{
			this.xmlNode_0 = this.xmlDocument_0.CreateNode(XmlNodeType.XmlDeclaration, "", "");
			this.xmlDocument_0.AppendChild(this.xmlNode_0);
			this.xmlElement_0 = this.xmlDocument_0.CreateElement("", root, "");
			this.xmlDocument_0.AppendChild(this.xmlElement_0);
		}
		public void CreatXmlNode(string mainNode, string node)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode(mainNode);
			XmlElement newChild = this.xmlDocument_0.CreateElement(node);
			xmlNode.AppendChild(newChild);
		}
		public void CreatXmlNode(string mainNode, string node, string content)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode(mainNode);
			XmlElement xmlElement = this.xmlDocument_0.CreateElement(node);
			xmlElement.InnerText = content;
			xmlNode.AppendChild(xmlElement);
		}
		public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode(MainNode);
			XmlElement xmlElement = this.xmlDocument_0.CreateElement(Node);
			xmlElement.SetAttribute(Attrib, AttribValue);
			xmlNode.AppendChild(xmlElement);
		}
		public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Content)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode(MainNode);
			XmlElement xmlElement = this.xmlDocument_0.CreateElement(Node);
			xmlElement.SetAttribute(Attrib, AttribValue);
			xmlElement.InnerText = Content;
			xmlNode.AppendChild(xmlElement);
		}
		public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Attrib2, string AttribValue2)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode(MainNode);
			XmlElement xmlElement = this.xmlDocument_0.CreateElement(Node);
			xmlElement.SetAttribute(Attrib, AttribValue);
			xmlElement.SetAttribute(Attrib2, AttribValue2);
			xmlNode.AppendChild(xmlElement);
		}
		public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Attrib2, string AttribValue2, string Content)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode(MainNode);
			XmlElement xmlElement = this.xmlDocument_0.CreateElement(Node);
			xmlElement.SetAttribute(Attrib, AttribValue);
			xmlElement.SetAttribute(Attrib2, AttribValue2);
			xmlElement.InnerText = Content;
			xmlNode.AppendChild(xmlElement);
		}
		public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Attrib2, string AttribValue2, string Attrib3, string AttribValue3)
		{
			XmlNode xmlNode = this.xmlDocument_0.SelectSingleNode(MainNode);
			XmlElement xmlElement = this.xmlDocument_0.CreateElement(Node);
			xmlElement.SetAttribute(Attrib, AttribValue);
			xmlElement.SetAttribute(Attrib2, AttribValue2);
			xmlElement.SetAttribute(Attrib3, AttribValue3);
			xmlNode.AppendChild(xmlElement);
		}
		public void XmlSave(string path)
		{
			this.xmlDocument_0.Save(path);
		}
		public static ArrayList GetSubElementByAttribute(string XmlPath, string FatherElenetName, string AttributeName, int AttributeIndex, int ArrayLength)
		{
			ArrayList arrayList = new ArrayList();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(XmlPath);
			XmlNodeList childNodes = xmlDocument.DocumentElement.ChildNodes;
			ArrayList result;
			foreach (XmlElement xmlElement in childNodes)
			{
				if (xmlElement.Name == FatherElenetName)
				{
					if (xmlElement.Attributes.Count < AttributeIndex)
					{
						result = null;
						return result;
					}
					if (xmlElement.Attributes[AttributeIndex].Value == AttributeName)
					{
						XmlNodeList childNodes2 = xmlElement.ChildNodes;
						if (childNodes2.Count > 0)
						{
							int num = 0;
							while (num < ArrayLength & num < childNodes2.Count)
							{
								arrayList.Add(childNodes2[num].InnerText);
								num++;
							}
						}
					}
				}
			}
			result = arrayList;
			return result;
		}
		public static ArrayList GetSubElementByAttribute(string XmlPath, string FatherElement, string AttributeName, string AttributeValue, int ArrayLength)
		{
			ArrayList arrayList = new ArrayList();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(XmlPath);
			XmlNodeList xmlNodeList = xmlDocument.DocumentElement.SelectNodes(string.Concat(new string[]
			{
				"//",
				FatherElement,
				"[",
				AttributeName,
				"='",
				AttributeValue,
				"']"
			}));
			XmlNodeList childNodes = xmlNodeList.Item(0).ChildNodes;
			int num = 0;
			while (num < ArrayLength & num < childNodes.Count)
			{
				arrayList.Add(childNodes.Item(num).InnerText);
				num++;
			}
			return arrayList;
		}
	}
}
