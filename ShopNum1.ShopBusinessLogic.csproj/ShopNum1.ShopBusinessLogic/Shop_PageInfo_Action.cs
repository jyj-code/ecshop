using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Xml;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_PageInfo_Action : IShop_PageInfo_Action
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
		public DataTable Search(string pagename)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			if (pagename != "" && pagename != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("pagename like '%" + pagename + "%'");
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
		public int Add(PageInfo pageInfo)
		{
			this.LoadXml();
			XmlNode xmlNode = this.xmlDoc.SelectSingleNode("pages");
			XmlElement xmlElement = this.xmlDoc.CreateElement("page");
			xmlElement.SetAttribute("guid", pageInfo.Guid);
			xmlElement.SetAttribute("pagename", pageInfo.PageName);
			xmlElement.SetAttribute("filename", pageInfo.FileName);
			xmlElement.SetAttribute("pagenote", pageInfo.PageName);
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
		public int Delete(string guids)
		{
			string[] array = guids.Replace("'", "").Split(new char[]
			{
				','
			});
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("pages").ChildNodes;
			int i = 0;
			IL_9B:
			while (i < array.Length)
			{
				for (int j = 0; j < childNodes.Count; j++)
				{
					XmlElement xmlElement = (XmlElement)childNodes[j];
					if (xmlElement.GetAttribute("guid") == array[i])
					{
						this.xmlDoc.SelectSingleNode("pages").RemoveChild(xmlElement);
						IL_97:
						i++;
						goto IL_9B;
					}
				}
                //goto IL_97;
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
		public int Update(PageInfo pageInfo)
		{
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("pages").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("guid") == pageInfo.Guid)
				{
					xmlElement.SetAttribute("guid", pageInfo.Guid);
					xmlElement.SetAttribute("pagename", pageInfo.PageName);
					xmlElement.SetAttribute("filename", pageInfo.FileName);
					xmlElement.SetAttribute("pagenote", pageInfo.PageName);
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
	}
}
