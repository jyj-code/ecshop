using System;
using System.Data;
using System.Web;
using System.Xml;
namespace ShopNum1.AdXml
{
	public class DefaultAdvertismentOperate
	{
		private static DataTable dataTable_0 = null;
		public static DataTable xmlDataTable
		{
			get
			{
				DataTable result;
				if (DefaultAdvertismentOperate.dataTable_0 == null)
				{
					DataSet dataSet = new DataSet();
					dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/AdImage.xml"));
					if (dataSet == null || dataSet.Tables.Count == 0)
					{
						result = null;
						return result;
					}
					if (dataSet.Tables.Count != 0)
					{
						DefaultAdvertismentOperate.dataTable_0 = dataSet.Tables[0];
					}
				}
				result = DefaultAdvertismentOperate.dataTable_0;
				return result;
			}
			set
			{
				DefaultAdvertismentOperate.dataTable_0 = value;
			}
		}
		public static void ResetDe()
		{
			DefaultAdvertismentOperate.xmlDataTable = null;
		}
		public DataTable GetXmlDataTable()
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/AdImage.xml"));
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
		public DataTable GetXmlDataTable1(string PageName)
		{
			DataSet dataSet = new DataSet();
			DataTable result;
			if (PageName != "" && PageName != null)
			{
				dataSet.ReadXml(this.GetPath());
				DataRow[] array = dataSet.Tables[0].Select("pagename like '%" + PageName + "%'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (PageName == "" || PageName == null)
			{
				dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/AdImage.xml"));
				if (dataSet == null || dataSet.Tables.Count == 0)
				{
					result = null;
				}
				else
				{
					if (dataSet.Tables.Count != 0)
					{
						DefaultAdvertismentOperate.dataTable_0 = dataSet.Tables[0];
					}
					result = dataSet.Tables[0];
				}
			}
			else
			{
				dataSet.ReadXml(this.GetPath());
				if (dataSet.Tables.Count > 0)
				{
					result = dataSet.Tables[0];
				}
				else
				{
					result = null;
				}
			}
			return result;
		}
		public DataTable GetXmlDataTable1(string PageName, string SubstationManage)
		{
			DataSet dataSet = new DataSet();
			DataTable result;
			if (PageName != "" && PageName != null)
			{
				dataSet.ReadXml(this.GetPathNew(SubstationManage));
				DataRow[] array = dataSet.Tables[0].Select("pagename like '%" + PageName + "%'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (PageName == "" || PageName == null)
			{
				dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/City/" + SubstationManage + "/Themes/Skin_Default/Xml/AdImage.xml"));
				if (dataSet == null || dataSet.Tables.Count == 0)
				{
					result = null;
				}
				else
				{
					if (dataSet.Tables.Count != 0)
					{
						DefaultAdvertismentOperate.dataTable_0 = dataSet.Tables[0];
					}
					result = dataSet.Tables[0];
				}
			}
			else
			{
				dataSet.ReadXml(this.GetPathNew(SubstationManage));
				if (dataSet.Tables.Count > 0)
				{
					result = dataSet.Tables[0];
				}
				else
				{
					result = null;
				}
			}
			return result;
		}
		public string GetPath()
		{
			return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/AdImage.xml");
		}
		public string GetPathNew(string SubstationID)
		{
			return HttpContext.Current.Server.MapPath("~/City/" + SubstationID + "/Themes/Skin_Default/Xml/AdImage.xml");
		}
		public static DataTable SelecByID(string string_0)
		{
			DataRow[] array = DefaultAdvertismentOperate.xmlDataTable.Select("id= '" + string_0 + "'");
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
		public static DataTable SelecByID(string string_0, string SubstationID)
		{
			DataTable dataTable = null;
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/City/" + SubstationID + "/Themes/Skin_Default/Xml/AdImage.xml"));
			DataTable result;
			if (dataSet == null || dataSet.Tables.Count == 0)
			{
				result = null;
			}
			else
			{
				if (dataSet.Tables.Count != 0)
				{
					dataTable = dataSet.Tables[0];
				}
				DataRow[] array = dataTable.Select("id= '" + string_0 + "'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			return result;
		}
		public static string GetAdPro(string string_0, string string_1)
		{
			string result;
			foreach (DataRow dataRow in DefaultAdvertismentOperate.xmlDataTable.Rows)
			{
				if (dataRow["id"].ToString() == string_0)
				{
					try
					{
						result = dataRow[string_1].ToString();
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
		public int Update(string string_0, string title, string imgsrc, string linkUrl, string height, string width, string pageName, string string_1)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPath());
			XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("id") == string_0.Replace("'", ""))
				{
					xmlElement.SetAttribute("title", title);
					xmlElement.SetAttribute("imgsrc", imgsrc);
					xmlElement.SetAttribute("href", linkUrl);
					xmlElement.SetAttribute("height", height);
					xmlElement.SetAttribute("width", width);
					xmlElement.SetAttribute("pagename", pageName);
					xmlElement.SetAttribute("des", string_1);
					break;
				}
			}
			int result;
			try
			{
				xmlDocument.Save(this.GetPath());
				DefaultAdvertismentOperate.ResetDe();
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int Update(string string_0, string title, string imgsrc, string linkUrl, string height, string width, string pageName, string string_1, string SubstationID)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPathNew(SubstationID));
			XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("id") == string_0.Replace("'", ""))
				{
					xmlElement.SetAttribute("title", title);
					xmlElement.SetAttribute("imgsrc", imgsrc);
					xmlElement.SetAttribute("href", linkUrl);
					xmlElement.SetAttribute("height", height);
					xmlElement.SetAttribute("width", width);
					xmlElement.SetAttribute("pagename", pageName);
					xmlElement.SetAttribute("des", string_1);
					break;
				}
			}
			int result;
			try
			{
				xmlDocument.Save(this.GetPathNew(SubstationID));
				DefaultAdvertismentOperate.ResetDe();
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int Update(string string_0, string title, string imgsrc, string linkUrl)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPath());
			XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("id") == string_0.Replace("'", ""))
				{
					xmlElement.SetAttribute("title", title);
					xmlElement.SetAttribute("imgsrc", imgsrc);
					xmlElement.SetAttribute("href", linkUrl);
					break;
				}
			}
			int result;
			try
			{
				xmlDocument.Save(this.GetPath());
				DefaultAdvertismentOperate.ResetDe();
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int Add(string title, string imgsrc, string href, string width, string height, string pageName, string string_0)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPath());
			XmlNode xmlNode = xmlDocument.SelectSingleNode("ads");
			XmlElement xmlElement = xmlDocument.CreateElement("ad");
			xmlElement.SetAttribute("id", this.GetMaxId().ToString());
			xmlElement.SetAttribute("title", title);
			xmlElement.SetAttribute("imgsrc", imgsrc);
			xmlElement.SetAttribute("href", href);
			xmlElement.SetAttribute("width", width);
			xmlElement.SetAttribute("height", height);
			xmlElement.SetAttribute("pagename", pageName);
			xmlElement.SetAttribute("des", string_0);
			xmlNode.AppendChild(xmlElement);
			int result;
			try
			{
				xmlDocument.Save(this.GetPath());
				DefaultAdvertismentOperate.ResetDe();
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int Add(string title, string imgsrc, string href, string width, string height, string pageName, string string_0, string SubstationID)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.GetPathNew(SubstationID));
			XmlNode xmlNode = xmlDocument.SelectSingleNode("ads");
			XmlElement xmlElement = xmlDocument.CreateElement("ad");
			xmlElement.SetAttribute("id", this.GetMaxId().ToString());
			xmlElement.SetAttribute("title", title);
			xmlElement.SetAttribute("imgsrc", imgsrc);
			xmlElement.SetAttribute("href", href);
			xmlElement.SetAttribute("width", width);
			xmlElement.SetAttribute("height", height);
			xmlElement.SetAttribute("pagename", pageName);
			xmlElement.SetAttribute("des", string_0);
			xmlNode.AppendChild(xmlElement);
			int result;
			try
			{
				xmlDocument.Save(this.GetPath());
				DefaultAdvertismentOperate.ResetDe();
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
			if (DefaultAdvertismentOperate.xmlDataTable == null)
			{
				result = 1;
			}
			else
			{
				foreach (DataRow dataRow in DefaultAdvertismentOperate.xmlDataTable.Rows)
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
				DefaultAdvertismentOperate.ResetDe();
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
