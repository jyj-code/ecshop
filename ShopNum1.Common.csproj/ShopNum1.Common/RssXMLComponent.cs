using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
namespace ShopNum1.Common
{
	public class RssXMLComponent : XMLComponent
	{
		private string string_8;
		public RssXMLComponent(string string_9)
		{
			this.string_8 = string_9;
			base.FileEncode = "gb2312";
			base.Version = "2.0";
			base.StartElement = "channel";
		}
		public override StringBuilder WriteStringBuilder()
		{
			string s = string.Format("<?xml version='1.0' encoding='{0}'?><?xml-stylesheet type=\"text/xsl\" href=\"{1}\"?><rss version='{2}'></rss>", base.FileEncode, base.XslLink, base.Version);
			this.xmlDoc_Metone.Load(new StringReader(s));
			string str = "-1";
			foreach (DataRow dataRow in base.SourceDataTable.Rows)
			{
				if (base.Key != null && base.ParentField != null)
				{
					if (dataRow[base.ParentField].ToString().Trim() == "" || dataRow[base.ParentField].ToString().Trim() == "0")
					{
						XmlElement xmlElement = this.xmlDoc_Metone.CreateElement(base.StartElement);
						this.xmlDoc_Metone.DocumentElement.AppendChild(xmlElement);
						foreach (DataColumn dataColumn in base.SourceDataTable.Columns)
						{
							if (dataColumn.Caption.ToString().ToLower() == base.ParentField.ToLower())
							{
								str = dataRow[base.Key].ToString().Trim();
							}
							else if (dataRow[base.ParentField].ToString().Trim() == "" || dataRow[base.ParentField].ToString().Trim() == "0")
							{
								base.AppendChildElement(dataColumn.Caption.ToString().ToLower(), dataRow[dataColumn].ToString().Trim(), xmlElement);
							}
						}
						DataRow[] array = base.SourceDataTable.Select(base.ParentField + "=" + str);
						for (int i = 0; i < array.Length; i++)
						{
							DataRow dataRow2 = array[i];
							if (base.SourceDataTable.Select(base.ParentField + "=" + dataRow2[base.Key].ToString()).Length >= 0)
							{
								base.BulidXmlTree(xmlElement, dataRow2["ItemID"].ToString().Trim());
							}
						}
					}
				}
				else
				{
					XmlElement xmlElement = this.xmlDoc_Metone.CreateElement(base.StartElement);
					this.xmlDoc_Metone.DocumentElement.AppendChild(xmlElement);
					foreach (DataColumn dataColumn in base.SourceDataTable.Columns)
					{
						base.AppendChildElement(dataColumn.Caption.ToString().ToLower(), dataRow[dataColumn].ToString().Trim(), xmlElement);
					}
				}
			}
			return new StringBuilder().Append(this.xmlDoc_Metone.InnerXml);
		}
		public override string WriteFile()
		{
			base.CreatePath();
			string s = string.Format("<?xml version='1.0' encoding='{0}'?><?xml-stylesheet type=\"text/xsl\" href=\"{1}\"?><rss version='{2}'></rss>", base.FileEncode, base.XslLink, base.Version);
			this.xmlDoc_Metone.Load(new StringReader(s));
			string str = "-1";
			foreach (DataRow dataRow in base.SourceDataTable.Rows)
			{
				if (base.Key != null && base.ParentField != null)
				{
					if (dataRow[base.ParentField].ToString().Trim() == "" || dataRow[base.ParentField].ToString().Trim() == "0")
					{
						XmlElement xmlElement = this.xmlDoc_Metone.CreateElement(base.StartElement);
						this.xmlDoc_Metone.DocumentElement.AppendChild(xmlElement);
						foreach (DataColumn dataColumn in base.SourceDataTable.Columns)
						{
							if (dataColumn.Caption.ToString().ToLower() == base.ParentField.ToLower())
							{
								str = dataRow[base.Key].ToString().Trim();
							}
							else if (dataRow[base.ParentField].ToString().Trim() == "" || dataRow[base.ParentField].ToString().Trim() == "0")
							{
								base.AppendChildElement(dataColumn.Caption.ToString().ToLower(), dataRow[dataColumn].ToString().Trim(), xmlElement);
							}
						}
						DataRow[] array = base.SourceDataTable.Select(base.ParentField + "=" + str);
						for (int i = 0; i < array.Length; i++)
						{
							DataRow dataRow2 = array[i];
							if (base.SourceDataTable.Select(base.ParentField + "=" + dataRow2[base.Key].ToString()).Length >= 0)
							{
								base.BulidXmlTree(xmlElement, dataRow2["ItemID"].ToString().Trim());
							}
						}
					}
				}
				else
				{
					XmlElement xmlElement = this.xmlDoc_Metone.CreateElement(base.StartElement);
					this.xmlDoc_Metone.DocumentElement.AppendChild(xmlElement);
					foreach (DataColumn dataColumn in base.SourceDataTable.Columns)
					{
						base.AppendChildElement(dataColumn.Caption.ToString().ToLower(), dataRow[dataColumn].ToString().Trim(), xmlElement);
					}
				}
			}
			this.xmlDoc_Metone.Save(base.FileOutPath + base.FileName);
			return base.FileOutPath + base.FileName;
		}
	}
}
