using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
namespace ShopNum1.Common
{
	public abstract class XMLComponent
	{
		private DataTable dataTable_0 = null;
		private string string_0 = "";
		private string string_1 = "utf-8";
		private int int_0 = 6;
		private string string_2 = "2.0";
		private string string_3 = "channel";
		private string string_4 = null;
		private string string_5 = "MyFile.xml";
		private string string_6 = "Item";
		private string string_7 = "ItemID";
		public XmlDocument xmlDoc_Metone = new XmlDocument();
		public DataTable SourceDataTable
		{
			get
			{
				return this.dataTable_0;
			}
			set
			{
				this.dataTable_0 = value;
			}
		}
		public string FileOutPath
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (value.LastIndexOf("\\") != value.Length - 1)
				{
					this.string_0 = value + "\\";
				}
			}
		}
		public string FileEncode
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public int Indentation
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public string Version
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public string StartElement
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public string XslLink
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public string FileName
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public string ParentField
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}
		public string Key
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}
		public abstract string WriteFile();
		public abstract StringBuilder WriteStringBuilder();
		protected void BulidXmlTree(XmlElement tempXmlElement, string location)
		{
			DataRow dataRow = this.SourceDataTable.Select(this.Key + "=" + location)[0];
			XmlElement xmlElement = this.xmlDoc_Metone.CreateElement(this.ParentField);
			tempXmlElement.AppendChild(xmlElement);
			foreach (DataColumn dataColumn in this.SourceDataTable.Columns)
			{
				if (dataColumn.Caption.ToString().ToLower() != this.ParentField.ToLower())
				{
					this.AppendChildElement(dataColumn.Caption.ToString().Trim().ToLower(), dataRow[dataColumn.Caption.Trim()].ToString().Trim(), xmlElement);
				}
			}
			DataRow[] array = this.SourceDataTable.Select(this.ParentField + "=" + location);
			for (int i = 0; i < array.Length; i++)
			{
				DataRow dataRow2 = array[i];
				if (this.SourceDataTable.Select("item=" + dataRow2[this.Key].ToString()).Length >= 0)
				{
					this.BulidXmlTree(xmlElement, dataRow2[this.Key].ToString().Trim());
				}
			}
		}
		protected void AppendChildElement(string strName, string strInnerText, XmlElement parentElement, XmlDocument xmlDocument)
		{
			XmlElement xmlElement = xmlDocument.CreateElement(strName);
			xmlElement.InnerText = strInnerText;
			parentElement.AppendChild(xmlElement);
		}
		protected void AppendChildElement(string strName, string strInnerText, XmlElement parentElement)
		{
			this.AppendChildElement(strName, strInnerText, parentElement, this.xmlDoc_Metone);
		}
		public void CreatePath()
		{
			if (this.FileOutPath != null)
			{
				string text = this.FileOutPath;
				if (!Directory.Exists(text))
				{
					Utils.CreateDir(text);
				}
			}
			else
			{
				string text = "C:\\";
				string text2 = DateTime.Now.ToString("yyyy-M").Trim();
				if (!Directory.Exists(text + text2))
				{
					Utils.CreateDir(text + "\\" + text2);
				}
			}
		}
	}
}
