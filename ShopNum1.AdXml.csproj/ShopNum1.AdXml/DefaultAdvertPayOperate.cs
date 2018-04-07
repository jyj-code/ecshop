using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Xml;
namespace ShopNum1.AdXml
{
	public class DefaultAdvertPayOperate
	{
		private DataTable dataTable_0 = null;
		[CompilerGenerated]
		private string string_0;
		public DataTable xmlDataTable
		{
			get
			{
				DataTable result;
				if (this.dataTable_0 == null)
				{
					DataSet dataSet = new DataSet();
					if (this.SubstationID == "all")
					{
						dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/PayAdImage.xml"));
					}
					else
					{
						dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/City/" + this.SubstationID + "/Themes/Skin_Default/Xml/PayAdImage.xml"));
					}
					if (dataSet == null || dataSet.Tables.Count == 0)
					{
						result = null;
						return result;
					}
					if (dataSet.Tables.Count != 0)
					{
						this.dataTable_0 = dataSet.Tables[0];
					}
				}
				result = this.dataTable_0;
				return result;
			}
			set
			{
				this.dataTable_0 = value;
			}
		}
		public string SubstationID
		{
			get;
			set;
		}
		public void ResetDe()
		{
			this.xmlDataTable = null;
		}
		public DataTable GetXmlDataTable(string SubstationID)
		{
			string path = string.Empty;
			if (SubstationID == "all")
			{
				path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml";
			}
			else
			{
				path = "~/City/" + SubstationID + "/Themes/Skin_Default/Xml/PayAdImage.xml";
			}
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(HttpContext.Current.Server.MapPath(path));
			DataTable result;
			if (dataSet == null || dataSet.Tables.Count == 0)
			{
				result = null;
			}
			else
			{
				result = dataSet.Tables[0];
			}
			return result;
		}
		public string GetPath()
		{
			string result = string.Empty;
			if (this.SubstationID == "all")
			{
				result = HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/PayAdImage.xml");
			}
			else
			{
				result = HttpContext.Current.Server.MapPath("~/City/" + this.SubstationID + "/Themes/Skin_Default/Xml/PayAdImage.xml");
			}
			return result;
		}
		public DataTable SelecByID(string string_1)
		{
			DataRow[] array = this.xmlDataTable.Select("id= '" + string_1 + "'");
			DataTable result;
			if (array.Length > 0)
			{
				result = array.CopyToDataTable<DataRow>();
			}
			else
			{
				result = null;
			}
			return result;
		}
		public string GetAdPro(string string_1, string string_2)
		{
			string result;
			foreach (DataRow dataRow in this.xmlDataTable.Rows)
			{
				if (dataRow["id"].ToString() == string_1)
				{
					try
					{
						result = dataRow[string_2].ToString();
						return result;
					}
					catch
					{
						result = "";
						return result;
					}
					break;
				}
			}
			result = "";
			return result;
		}
		public int Update(string string_1, string title, string type, string Map, string Href, string width, string height, string money, string showDay, string DefaultImage, string IsRun)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPath());
			XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("id") == string_1.Replace("'", ""))
				{
					xmlElement.SetAttribute("title", title);
					xmlElement.SetAttribute("type", type);
					xmlElement.SetAttribute("Map", Map);
					xmlElement.SetAttribute("Href", Href);
					xmlElement.SetAttribute("width", width);
					xmlElement.SetAttribute("height", height);
					xmlElement.SetAttribute("money", money);
					xmlElement.SetAttribute("showDay", showDay);
					xmlElement.SetAttribute("DefaultImage", DefaultImage);
					xmlElement.SetAttribute("IsRun", IsRun);
					break;
				}
			}
			int result;
			try
			{
				xmlDocument.Save(this.GetPath());
				this.ResetDe();
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int UpdateRun(string string_1, string IsRun)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPath());
			XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("id") == string_1.Replace("'", ""))
				{
					xmlElement.SetAttribute("IsRun", IsRun);
					break;
				}
			}
			int result;
			try
			{
				xmlDocument.Save(this.GetPath());
				this.ResetDe();
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int Add(string title, string type, string Map, string Href, string width, string height, string money, string showDay, string DefaultImage, string IsRun)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPath());
			XmlNode xmlNode = xmlDocument.SelectSingleNode("ads");
			XmlElement xmlElement = xmlDocument.CreateElement("ad");
			xmlElement.SetAttribute("id", this.GetMaxId().ToString());
			xmlElement.SetAttribute("title", title);
			xmlElement.SetAttribute("type", type);
			xmlElement.SetAttribute("Map", Map);
			xmlElement.SetAttribute("Href", Href);
			xmlElement.SetAttribute("width", width);
			xmlElement.SetAttribute("height", height);
			xmlElement.SetAttribute("money", money);
			xmlElement.SetAttribute("showDay", showDay);
			xmlElement.SetAttribute("DefaultImage", DefaultImage);
			xmlElement.SetAttribute("IsRun", IsRun);
			xmlNode.AppendChild(xmlElement);
			int result;
			try
			{
				xmlDocument.Save(this.GetPath());
				this.ResetDe();
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int GetMaxId()
		{
			int num = 0;
			int result;
			if (this.xmlDataTable == null)
			{
				result = 1;
			}
			else
			{
				foreach (DataRow dataRow in this.xmlDataTable.Rows)
				{
					if (Convert.ToInt32(dataRow["id"]) > num)
					{
						num = Convert.ToInt32(dataRow["id"]);
					}
				}
				result = num + 1;
			}
			return result;
		}
		public int Delete(string guids)
		{
			string[] array = guids.Replace("'", "").Split(new char[]
			{
				','
			});
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPath());
			XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
			for (int i = 0; i < array.Length; i++)
			{
				foreach (XmlNode xmlNode in childNodes)
				{
					XmlElement xmlElement = (XmlElement)xmlNode;
					if (xmlElement.GetAttribute("id") == array[i])
					{
						xmlDocument.SelectSingleNode("ads").RemoveChild(xmlNode);
						break;
					}
				}
			}
			int result;
			try
			{
				xmlDocument.Save(this.GetPath());
				this.ResetDe();
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
	}
}
