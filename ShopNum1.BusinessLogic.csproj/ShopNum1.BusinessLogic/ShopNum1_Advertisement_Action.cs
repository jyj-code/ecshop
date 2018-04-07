using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Xml;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Advertisement_Action : IShopNum1_Advertisement_Action
	{
		public XmlDocument xmlDoc;
		public string GetPath()
		{
			return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/Advertisement.xml");
		}
		public void LoadXml()
		{
			this.xmlDoc = new XmlDocument();
			this.xmlDoc.Load(this.GetPath());
		}
		public DataTable Search(string pagename, string fileName)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataTable result;
			if (pagename != "" && pagename != null && fileName == "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("pagename like '%" + pagename + "%'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if ((pagename == "" || pagename == null) && fileName != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select(" filename='" + fileName + "'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (pagename != "" && pagename != null && fileName != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select(string.Concat(new string[]
				{
					"pagename like '%",
					pagename,
					"%' AND filename='",
					fileName,
					"'"
				}));
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (dataSet.Tables.Count > 0)
			{
				result = dataSet.Tables[0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public DataTable Search1(string pagename, string fileName)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataTable result;
			if (pagename != "" && pagename != null && fileName == "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("divid like '%" + pagename + "%'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if ((pagename == "" || pagename == null) && fileName != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select(" filename='" + fileName + "'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (pagename != "" && pagename != null && fileName != "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select(string.Concat(new string[]
				{
					"divid like '%",
					pagename,
					"%' AND filename='",
					fileName,
					"'"
				}));
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (dataSet.Tables.Count > 0)
			{
				result = dataSet.Tables[0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public DataTable Search(string pagename, string fileName, string adID)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			string text = string.Empty;
			if (pagename != "-1")
			{
				text = "pagename like '%" + pagename.Trim() + "%' AND ";
			}
			if (fileName != "-1")
			{
				text = text + " filename='" + fileName.Trim() + "' AND ";
			}
			if (adID != "-1")
			{
				text = text + " divid like '%" + adID.Trim() + "%' AND";
			}
			text += " 1=1";
			DataRow[] array = dataSet.Tables[0].Select(text);
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
		public DataTable SearchPPT(string pagename)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataTable result;
			if (pagename != "" && pagename != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("filename like '%" + pagename + "%'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (dataSet.Tables.Count > 0)
			{
				result = dataSet.Tables[0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public DataTable SelectByID(string guid)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
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
		public int Add(Advertisement advertisement)
		{
			this.LoadXml();
			XmlNode xmlNode = this.xmlDoc.SelectSingleNode("ads");
			XmlElement xmlElement = this.xmlDoc.CreateElement("ad");
			xmlElement.SetAttribute("guid", advertisement.Guid);
			xmlElement.SetAttribute("explain", advertisement.Explain);
			xmlElement.SetAttribute("pagename", advertisement.PageName);
			xmlElement.SetAttribute("filename", advertisement.FileName);
			xmlElement.SetAttribute("divid", advertisement.DivID);
			xmlElement.SetAttribute("type", advertisement.Type);
			xmlElement.SetAttribute("content", advertisement.Content);
			xmlElement.SetAttribute("href", advertisement.Href);
			xmlElement.SetAttribute("width", advertisement.Width);
			xmlElement.SetAttribute("height", advertisement.Height);
			xmlNode.AppendChild(xmlElement);
			int result;
			try
			{
				this.xmlDoc.Save(this.GetPath());
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Update(Advertisement advertisement)
		{
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("ads").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("guid") == advertisement.Guid)
				{
					xmlElement.SetAttribute("guid", advertisement.Guid);
					xmlElement.SetAttribute("explain", advertisement.Explain);
					xmlElement.SetAttribute("pagename", advertisement.PageName);
					xmlElement.SetAttribute("filename", advertisement.FileName);
					xmlElement.SetAttribute("divid", advertisement.DivID);
					xmlElement.SetAttribute("type", advertisement.Type);
					xmlElement.SetAttribute("content", advertisement.Content);
					xmlElement.SetAttribute("href", advertisement.Href);
					xmlElement.SetAttribute("width", advertisement.Width);
					xmlElement.SetAttribute("height", advertisement.Height);
					break;
				}
			}
			int result;
			try
			{
				this.xmlDoc.Save(this.GetPath());
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int Delete(string guids)
		{
			string[] array = guids.Replace("'", "").Split(new char[]
			{
				','
			});
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("ads").ChildNodes;
			for (int i = 0; i < array.Length; i++)
			{
				foreach (XmlNode xmlNode in childNodes)
				{
					XmlElement xmlElement = (XmlElement)xmlNode;
					if (xmlElement.GetAttribute("guid") == array[i])
					{
						this.xmlDoc.SelectSingleNode("ads").RemoveChild(xmlNode);
						break;
					}
				}
			}
			int result;
			try
			{
				this.xmlDoc.Save(this.GetPath());
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public string GetNewDivID(string filename)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataRow[] array = dataSet.Tables[0].Select("filename = '" + filename + "'");
			string result;
			if (array.Length > 0)
			{
				int num = int.Parse(array[array.Length - 1]["divid"].ToString().Replace("ad", "")) + 1;
				result = "ad" + (num + 1).ToString();
			}
			else
			{
				result = "ad1";
			}
			return result;
		}
		public DataTable ShowAD(string filename)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataTable result;
			if (filename != "" && filename != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("filename = '" + filename + "'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			else if (dataSet.Tables.Count > 0)
			{
				result = dataSet.Tables[0];
			}
			else
			{
				result = null;
			}
			return result;
		}
		public DataTable ShowADByDivID(string divID)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataRow[] array = dataSet.Tables[0].Select("divid = '" + divID + "'");
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
		public DataTable ShowADByDivID(string divID, string type)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataRow[] array;
			if (type == "-1" || type == string.Empty || type == null)
			{
				array = dataSet.Tables[0].Select("divid = '" + divID + "'");
			}
			else
			{
				array = dataSet.Tables[0].Select(string.Concat(new string[]
				{
					"divid = '",
					divID,
					"' AND type='",
					type,
					"'"
				}));
			}
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
