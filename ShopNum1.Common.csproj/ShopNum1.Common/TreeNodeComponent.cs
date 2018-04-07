using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
namespace ShopNum1.Common
{
	public class TreeNodeComponent : XMLComponent
	{
		private string string_8;
		public TreeNodeComponent(string string_9)
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
					xmlTextWriter.WriteStartElement(base.SourceDataTable.TableName);
					foreach (DataRow dataRow in base.SourceDataTable.Rows)
					{
						string str = string.Concat(new string[]
						{
							"  Text=\"",
							dataRow[0].ToString().Trim(),
							"\"   ImageUrl=\"../../editor/images/smilies/",
							dataRow[1].ToString().Trim(),
							"\""
						});
						xmlTextWriter.WriteStartElement("", base.StartElement + str, "");
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
}
