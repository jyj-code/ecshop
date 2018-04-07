using ShopNum1.Common;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
internal class Class0 : XMLComponent
{
	private string string_8;
	public Class0(string string_9)
	{
		this.string_8 = string_9;
	}
	public override StringBuilder WriteStringBuilder()
	{
		string s = string.Format("<?xml version='1.0' encoding='{0}'?><{3} ></{3}>", new object[]
		{
			base.FileEncode,
			base.XslLink,
			base.Version,
			base.SourceDataTable.TableName
		});
		this.xmlDoc_Metone.Load(new StringReader(s));
		foreach (DataRow dataRow in base.SourceDataTable.Rows)
		{
			XmlElement xmlElement = this.xmlDoc_Metone.CreateElement(base.StartElement);
			this.xmlDoc_Metone.DocumentElement.AppendChild(xmlElement);
			foreach (DataColumn dataColumn in base.SourceDataTable.Columns)
			{
				base.AppendChildElement(dataColumn.Caption.ToString().ToLower(), dataRow[dataColumn].ToString().Trim(), xmlElement);
			}
		}
		return new StringBuilder().Append(this.xmlDoc_Metone.InnerXml);
	}
	public override string WriteFile()
	{
		string result;
		if (base.SourceDataTable != null)
		{
			string text = base.FileOutPath + base.FileName;
			XmlTextWriter xmlTextWriter = null;
			Encoding encoding = Encoding.GetEncoding(base.FileEncode);
			base.CreatePath();
			xmlTextWriter = new XmlTextWriter(text, encoding);
			try
			{
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.Indentation = base.Indentation;
				xmlTextWriter.Namespaces = false;
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='" + base.XslLink + "'");
				xmlTextWriter.WriteStartElement(base.SourceDataTable.TableName);
				xmlTextWriter.WriteAttributeString("", "version", null, base.Version);
				foreach (DataRow dataRow in base.SourceDataTable.Rows)
				{
					xmlTextWriter.WriteStartElement("", base.StartElement, "");
					foreach (DataColumn dataColumn in base.SourceDataTable.Columns)
					{
						xmlTextWriter.WriteStartElement("", dataColumn.Caption.ToString().Trim().ToLower(), "");
						xmlTextWriter.WriteString(dataRow[dataColumn].ToString().Trim());
						xmlTextWriter.WriteEndElement();
					}
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.Flush();
				base.SourceDataTable.Dispose();
			}
			catch (Exception ex)
			{
				Console.WriteLine("异常：{0}", ex.ToString());
			}
			finally
			{
				Console.WriteLine("对文件 {0} 的处理已完成。");
				if (xmlTextWriter != null)
				{
					xmlTextWriter.Close();
				}
			}
			result = text;
		}
		else
		{
			Console.WriteLine("对文件 {0} 的处理未完成。");
			result = "";
		}
		return result;
	}
}
