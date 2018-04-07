using ShopNum1.Interface;
using System;
using System.Data;
using System.Web;
using System.Xml;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ExtendSiteMota_Action : IShopNum1_ExtendSiteMota_Action
	{
		private string string_0 = "~/Settings/SetMeto.xml";
		public XmlDocument xmlDoc;
		private static DataTable dataTable_0 = null;
		private static DataTable dataTable_1 = null;
		public static DataTable MetoTable
		{
			get
			{
				if (ShopNum1_ExtendSiteMota_Action.dataTable_0 == null)
				{
					DataSet dataSet = new DataSet();
					dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/SetMeto.xml"));
					if (dataSet != null && dataSet.Tables.Count > 0)
					{
						ShopNum1_ExtendSiteMota_Action.dataTable_0 = dataSet.Tables[0];
					}
				}
				return ShopNum1_ExtendSiteMota_Action.dataTable_0;
			}
		}
		public static DataTable MetoTable1
		{
			get
			{
				if (ShopNum1_ExtendSiteMota_Action.dataTable_1 == null)
				{
					DataSet dataSet = new DataSet();
					dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
					if (dataSet != null && dataSet.Tables.Count > 0)
					{
						ShopNum1_ExtendSiteMota_Action.dataTable_1 = dataSet.Tables[0];
					}
				}
				return ShopNum1_ExtendSiteMota_Action.dataTable_1;
			}
		}
		public DataTable MetoTable2(string _SubstationID)
		{
			DataSet dataSet = new DataSet();
			DataTable result = null;
			dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/City/" + _SubstationID + "/Settings/SetMeto.xml"));
			if (dataSet != null && dataSet.Tables.Count > 0)
			{
				result = dataSet.Tables[0];
			}
			return result;
		}
		public static void ResetMeto()
		{
			ShopNum1_ExtendSiteMota_Action.dataTable_0 = null;
		}
		public DataTable SearchMetoList(string pagename)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.method_0());
			DataTable result;
			if (pagename != "" && pagename != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("PageName like '%" + pagename + "%'");
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
		public DataTable SearchMetoListNew(string pagename, string SubstationID)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/City/" + SubstationID + "/Settings/SetMeto.xml"));
			DataTable result;
			if (pagename != "" && pagename != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("PageName like '%" + pagename + "%'");
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
		public DataTable SearchMetoList(string pagename, string path)
		{
			DataSet dataSet = new DataSet();
			this.string_0 = path;
			dataSet.ReadXml(this.method_0());
			DataTable result;
			if (pagename != "" && pagename != null)
			{
				DataRow[] array = dataSet.Tables[0].Select("PageName like '%" + pagename + "%'");
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
		public DataTable SelectByName(string PageName, string path)
		{
			DataTable result;
			try
			{
				DataSet dataSet = new DataSet();
				this.string_0 = path;
				dataSet.ReadXml(this.method_0());
				DataRow[] array = dataSet.Tables[0].Select("PageName = '" + PageName + "'");
				if (array.Length > 0)
				{
					result = array.CopyToDataTable<DataRow>();
				}
				else
				{
					result = null;
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}
		public int Add(string name, string title, string keywords, string string_1, string path)
		{
			int result;
			if (this.check(name, path))
			{
				this.string_0 = path;
				this.LoadXml();
				XmlNode xmlNode = this.xmlDoc.SelectSingleNode("SiteMeta");
				XmlElement xmlElement = this.xmlDoc.CreateElement("Meta");
				xmlElement.SetAttribute("PageName", name);
				xmlElement.SetAttribute("Title", title);
				xmlElement.SetAttribute("KeyWords", keywords);
				xmlElement.SetAttribute("Description", string_1);
				xmlNode.AppendChild(xmlElement);
				try
				{
					this.xmlDoc.Save(this.method_0());
					result = 1;
					return result;
				}
				catch (Exception)
				{
					result = -1;
					return result;
				}
			}
			result = 0;
			return result;
		}
		public bool check(string PageName, string path)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.method_0());
			DataRow[] array = dataSet.Tables[0].Select("PageName = '" + PageName + "'");
			return array.Length <= 0;
		}
		public int edit(string name, string title, string keywords, string string_1, string path)
		{
			this.string_0 = path;
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("SiteMeta").ChildNodes;
			foreach (XmlNode xmlNode in childNodes)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (xmlElement.GetAttribute("PageName") == name)
				{
					xmlElement.SetAttribute("PageName", name);
					xmlElement.SetAttribute("Title", title);
					xmlElement.SetAttribute("KeyWords", keywords);
					xmlElement.SetAttribute("Description", string_1);
					break;
				}
			}
			int result;
			try
			{
				this.xmlDoc.Save(this.method_0());
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int delete(string names, string path)
		{
			string[] array = names.Replace("'", "").Split(new char[]
			{
				','
			});
			this.string_0 = path;
			this.LoadXml();
			XmlNodeList childNodes = this.xmlDoc.SelectSingleNode("SiteMeta").ChildNodes;
			for (int i = 0; i < array.Length; i++)
			{
				foreach (XmlNode xmlNode in childNodes)
				{
					XmlElement xmlElement = (XmlElement)xmlNode;
					if (xmlElement.GetAttribute("PageName") == array[i])
					{
						this.xmlDoc.SelectSingleNode("SiteMeta").RemoveChild(xmlNode);
						break;
					}
				}
			}
			int result;
			try
			{
				this.xmlDoc.Save(this.method_0());
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public void LoadXml()
		{
			this.xmlDoc = new XmlDocument();
			this.xmlDoc.Load(this.method_0());
		}
		private string method_0()
		{
			return HttpContext.Current.Server.MapPath(this.string_0);
		}
	}
}
