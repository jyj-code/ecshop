using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Xml;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_DefaultAdImg_Action : IShopNum1_DefaultAdImg_Action
	{
		private string string_0 = HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/DefaultAdImg.xml");
		private DataTable dataTable_0 = null;
		public string adpath
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public DataTable DefaultData
		{
			get
			{
				if (this.dataTable_0 == null)
				{
					this.dataTable_0 = this.GetDefaultAd();
				}
				return this.dataTable_0;
			}
			set
			{
				this.dataTable_0 = value;
			}
		}
		public void ResetAd()
		{
			this.dataTable_0 = null;
		}
		public bool Add(DefaultAdImg advertisement)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.adpath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("ads");
			XmlElement xmlElement = xmlDocument.CreateElement("ad");
			xmlElement.SetAttribute("guid", advertisement.Guid);
			xmlElement.SetAttribute("title", advertisement.title);
			xmlElement.SetAttribute("pagename", advertisement.PageName);
			xmlElement.SetAttribute("filename", advertisement.FileName);
			xmlElement.SetAttribute("type", advertisement.Type);
			xmlElement.SetAttribute("imgsrc", advertisement.imgsrc);
			xmlElement.SetAttribute("href", advertisement.Href);
			xmlElement.SetAttribute("width", advertisement.Width);
			xmlElement.SetAttribute("height", advertisement.Height);
			xmlElement.SetAttribute("orderID", advertisement.orderID);
			xmlNode.AppendChild(xmlElement);
			bool result;
			try
			{
				xmlDocument.Save(this.adpath);
				this.ResetAd();
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		public bool Update(DefaultAdImg advertisement)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.adpath);
			XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("guid") == advertisement.Guid)
				{
					xmlElement.SetAttribute("guid", advertisement.Guid);
					xmlElement.SetAttribute("title", advertisement.title);
					xmlElement.SetAttribute("pagename", advertisement.PageName);
					xmlElement.SetAttribute("filename", advertisement.FileName);
					xmlElement.SetAttribute("type", advertisement.Type);
					xmlElement.SetAttribute("imgsrc", advertisement.imgsrc);
					xmlElement.SetAttribute("href", advertisement.Href);
					xmlElement.SetAttribute("width", advertisement.Width);
					xmlElement.SetAttribute("height", advertisement.Height);
					xmlElement.SetAttribute("orderID", advertisement.orderID);
					break;
				}
			}
			bool result;
			try
			{
				xmlDocument.Save(this.adpath);
				this.ResetAd();
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		public bool Delete(string guids)
		{
			string[] array = guids.Replace("'", "").Split(new char[]
			{
				','
			});
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.adpath);
			XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
			for (int i = 0; i < array.Length; i++)
			{
				foreach (XmlNode xmlNode in childNodes)
				{
					XmlElement xmlElement = (XmlElement)xmlNode;
					if (xmlElement.GetAttribute("guid") == array[i])
					{
						xmlDocument.SelectSingleNode("ads").RemoveChild(xmlNode);
						break;
					}
				}
			}
			bool result;
			try
			{
				xmlDocument.Save(this.adpath);
				this.ResetAd();
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		public DataTable GetDefaultAd()
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.adpath);
			return dataSet.Tables[0];
		}
		public DataTable SelectByID(string guid)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.adpath);
			DataRow[] array = dataSet.Tables[0].Select("guid = '" + guid + "'");
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
	}
}
