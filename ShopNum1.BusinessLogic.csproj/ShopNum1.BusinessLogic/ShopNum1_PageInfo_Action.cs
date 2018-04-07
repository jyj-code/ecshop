using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Xml;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_PageInfo_Action : IShopNum1_PageInfo_Action
	{
		public XmlDocument xmlDoc;
		public string GetPath()
		{
			return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/PageInfo.xml");
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
			DataTable result;
			if (pagename != "" && pagename != null)
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
			DataTable dataTable = dataSet.Tables[0].DefaultView.ToTable();
			DataTable result;
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (!(dataTable.Rows[i]["guid"].ToString() == guid))
					{
						dataTable.Rows.Remove(dataTable.Rows[i]);
					}
				}
				result = dataTable;
			}
			else
			{
				result = null;
			}
			return result;
		}
		public DataTable SelectBydivID(string divID)
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
		public int Add(PageInfo pageInfo)
		{
			this.LoadXml();
			XmlNode xmlNode = this.xmlDoc.SelectSingleNode("pages");
			XmlElement xmlElement = this.xmlDoc.CreateElement("page");
			xmlElement.SetAttribute("guid", pageInfo.Guid);
			xmlElement.SetAttribute("pagename", pageInfo.PageName);
			xmlElement.SetAttribute("filename", pageInfo.FileName);
			xmlElement.SetAttribute("pagenote", pageInfo.PageNote);
			xmlElement.SetAttribute("divid", pageInfo.divid);
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
			IL_A0:
			while (i < array.Length)
			{
				for (int j = 0; j < childNodes.Count; j++)
				{
					XmlElement xmlElement = (XmlElement)childNodes[j];
					if (xmlElement.GetAttribute("guid") == array[i])
					{
						this.xmlDoc.SelectSingleNode("pages").RemoveChild(xmlElement);
						IL_9C:
						i++;
						goto IL_A0;
					}
				}
                //goto IL_9C;
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
					xmlElement.SetAttribute("pagenote", pageInfo.PageNote);
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
