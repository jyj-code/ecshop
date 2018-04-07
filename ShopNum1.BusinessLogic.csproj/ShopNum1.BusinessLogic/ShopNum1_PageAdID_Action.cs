using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Xml;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_PageAdID_Action : IShopNum1_PageAdID_Action
	{
		public XmlDocument xmlDoc;
		public string GetPath()
		{
			return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/PageAdID.xml");
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
			DataTable result;
			if (guid != "" && guid != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("guid= '" + guid + "'");
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
		public int Add(PageAdID pageAdID)
		{
			this.LoadXml();
			XmlNode xmlNode = this.xmlDoc.SelectSingleNode("pages");
			XmlElement xmlElement = this.xmlDoc.CreateElement("page");
			xmlElement.SetAttribute("guid", pageAdID.Guid);
			xmlElement.SetAttribute("pagename", pageAdID.PageName);
			xmlElement.SetAttribute("filename", pageAdID.FileName);
			xmlElement.SetAttribute("divid", pageAdID.DivID);
			xmlElement.SetAttribute("content", pageAdID.Content);
			xmlElement.SetAttribute("width", pageAdID.Width);
			xmlElement.SetAttribute("height", pageAdID.Height);
			xmlElement.SetAttribute("imgsrc", pageAdID.ImgSrc);
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
		public int Update(PageAdID pageAdID)
		{
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("pages").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("guid") == pageAdID.Guid)
				{
					xmlElement.SetAttribute("guid", pageAdID.Guid);
					xmlElement.SetAttribute("pagename", pageAdID.PageName);
					xmlElement.SetAttribute("filename", pageAdID.FileName);
					xmlElement.SetAttribute("content", pageAdID.Content);
					xmlElement.SetAttribute("width", pageAdID.Width);
					xmlElement.SetAttribute("height", pageAdID.Height);
					xmlElement.SetAttribute("imgsrc", pageAdID.ImgSrc);
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
		public string GetNewDivID()
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			DataTable dataTable = dataSet.Tables[0];
			int num = 0;
			string result;
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					int num2 = int.Parse(dataRow["divid"].ToString().Replace("ad", "")) + 1;
					if (num2 > num)
					{
						num = num2;
					}
				}
				result = "ad" + num.ToString();
			}
			else
			{
				result = "ad1";
			}
			return result;
		}
		public int CheckDivID(string divid)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.GetPath());
			int result;
			if (divid != "" && divid != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("divid like '%" + divid + "%'");
				if (array.Length > 0)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}
}
