using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Xml;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Advertisement_Action : IShop_Advertisement_Action
	{
		public XmlDocument xmlDoc;
		[CompilerGenerated]
		private string string_0;
		public string StrPath
		{
			get;
			set;
		}
		public string GetPath()
		{
			return HttpContext.Current.Server.MapPath(this.StrPath);
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
			if (pagename != "" && pagename != null && fileName == "-1")
			{
				DataRow[] array = dataSet.Tables[0].Select("pagename like '%" + pagename + "%'");
				if (array.Length > 0)
				{
					return array.CopyToDataTable<DataRow>();
				}
				return null;
			}
			else if ((pagename == "" || pagename == null) && fileName != "-1")
			{
				DataRow[] array2 = dataSet.Tables[0].Select(" filename='" + fileName + "'");
				if (array2.Length > 0)
				{
					return array2.CopyToDataTable<DataRow>();
				}
				return null;
			}
			else if (pagename != "" && pagename != null && fileName != "-1")
			{
				DataRow[] array3 = dataSet.Tables[0].Select(string.Concat(new string[]
				{
					"pagename like '%",
					pagename,
					"%' AND filename='",
					fileName,
					"'"
				}));
				if (array3.Length > 0)
				{
					return array3.CopyToDataTable<DataRow>();
				}
				return null;
			}
			else
			{
				if (dataSet.Tables.Count > 0)
				{
					return dataSet.Tables[0];
				}
				return null;
			}
		}
		public DataTable SearchPPT(string pagename)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			if (pagename != "" && pagename != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("filename like '%" + pagename + "%'");
				if (array.Length > 0)
				{
					return array.CopyToDataTable<DataRow>();
				}
				return null;
			}
			else
			{
				if (dataSet.Tables.Count > 0)
				{
					return dataSet.Tables[0];
				}
				return null;
			}
		}
		public DataTable SelectByID(string guid)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataRow[] array = dataSet.Tables[0].Select("guid = '" + guid + "'");
			if (array.Length > 0)
			{
				return array.CopyToDataTable<DataRow>();
			}
			return null;
		}
		public int Add(Advertisement advertisement)
		{
			this.LoadXml();
			XmlNode xmlNode = this.xmlDoc.SelectSingleNode("ads");
			XmlElement xmlElement = this.xmlDoc.CreateElement("ad");
			xmlElement.SetAttribute("guid", advertisement.Guid.ToString());
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
			catch (Exception)
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
			if (array.Length > 0)
			{
				int num = int.Parse(array[array.Length - 1]["divid"].ToString().Replace("ad", "")) + 1;
				return "ad" + (num + 1).ToString();
			}
			return "ad1";
		}
		public DataTable ShowAD(string filename)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			if (filename != "" && filename != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("filename = '" + filename + "'");
				if (array.Length > 0)
				{
					return array.CopyToDataTable<DataRow>();
				}
				return null;
			}
			else
			{
				if (dataSet.Tables.Count > 0)
				{
					return dataSet.Tables[0];
				}
				return null;
			}
		}
		public DataTable ShowADByDivID(string divID)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			if (dataSet == null || dataSet.Tables.Count == 0)
			{
				return null;
			}
			DataRow[] array = dataSet.Tables[0].Select("divid = '" + divID + "'");
			if (array.Length > 0)
			{
				return array.CopyToDataTable<DataRow>();
			}
			return null;
		}
	}
}
