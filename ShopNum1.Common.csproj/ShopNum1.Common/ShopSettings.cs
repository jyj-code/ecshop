using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Xml;
namespace ShopNum1.Common
{
	public class ShopSettings
	{
		private static string string_0 = HttpContext.Current.Server.MapPath("\\Settings\\ShopSetting.xml");
		private static XmlNodeList xmlNodeList_0 = null;
		private static DataRow dataRow_0 = null;
		private static string string_1 = "";
		private static string string_2 = null;
		private static bool bool_0;
		private static string string_3 = string.Empty;
		public static string shopsettingXml
		{
			get
			{
				return ShopSettings.string_0;
			}
			set
			{
				ShopSettings.string_0 = value;
			}
		}
		public static XmlNodeList xmlNodes
		{
			get
			{
				if (ShopSettings.xmlNodeList_0 == null)
				{
					ShopSettings.xmlNodeList_0 = XmlOperator.ReadXmlReturnNodeList(ShopSettings.shopsettingXml, "ShopSetting");
				}
				return ShopSettings.xmlNodeList_0;
			}
			set
			{
				ShopSettings.xmlNodeList_0 = value;
			}
		}
		public static DataRow ShopSettingRow
		{
			get
			{
				if (ShopSettings.dataRow_0 == null)
				{
					DataSet dataSet = new DataSet();
					dataSet.ReadXml(ShopSettings.shopsettingXml);
					ShopSettings.dataRow_0 = dataSet.Tables["ShopSetting"].Rows[0];
				}
				return ShopSettings.dataRow_0;
			}
			set
			{
				ShopSettings.dataRow_0 = value;
			}
		}
		public static string siteDomain
		{
			get
			{
				string result;
				if (ShopSettings.string_1 == string.Empty)
				{
					ShopSettings.string_1 = ConfigurationManager.AppSettings["Domain"].Trim().ToLower();
					result = ShopSettings.string_1;
				}
				else
				{
					result = ShopSettings.string_1;
				}
				return result;
			}
			set
			{
				ShopSettings.string_1 = value;
			}
		}
		public static bool IsOverrideUrl
		{
			get
			{
				bool result;
				if (ShopSettings.string_2 == null)
				{
					DataRow shopSettingRow = ShopSettings.ShopSettingRow;
					ShopSettings.bool_0 = bool.Parse(shopSettingRow["OverrideUrl"].ToString());
					ShopSettings.string_2 = "true";
					result = ShopSettings.bool_0;
				}
				else
				{
					result = ShopSettings.bool_0;
				}
				return result;
			}
			set
			{
				ShopSettings.bool_0 = value;
			}
		}
		public static string overrideUrlName
		{
			get
			{
				string result;
				if (ShopSettings.string_3 == string.Empty)
				{
					DataRow shopSettingRow = ShopSettings.ShopSettingRow;
					ShopSettings.string_3 = shopSettingRow["OverrideUrlName"].ToString();
					result = ShopSettings.string_3;
				}
				else
				{
					result = ShopSettings.string_3;
				}
				return result;
			}
			set
			{
				ShopSettings.string_3 = value;
			}
		}
		public static void ResetShopSetting()
		{
			ShopSettings.xmlNodes = null;
			ShopSettings.ShopSettingRow = null;
			ShopSettings.xmlNodes = null;
			ShopSettings.siteDomain = string.Empty;
			ShopSettings.overrideUrlName = string.Empty;
			ShopSettings.siteDomain = string.Empty;
			ShopSettings.string_2 = string.Empty;
		}
		public string GetValue(string fieldXmlPath, string nodeName)
		{
			XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(fieldXmlPath, "ShopSetting");
			string result;
			foreach (XmlNode xmlNode in xmlNodeList)
			{
				foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
				{
					if (xmlNode2.Name == nodeName)
					{
						result = xmlNode2.InnerText;
						return result;
					}
				}
			}
			result = string.Empty;
			return result;
		}
		public static string GetValue(string nodeName)
		{
			string result;
			foreach (XmlNode xmlNode in ShopSettings.xmlNodes)
			{
				foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
				{
					if (xmlNode2.Name == nodeName)
					{
						result = xmlNode2.InnerText;
						return result;
					}
				}
			}
			result = string.Empty;
			return result;
		}
		public string GetValueInvoice(string fieldXmlPath, string nodeName)
		{
			XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(fieldXmlPath, "ShopSetting/InvoiceType");
			string result;
			foreach (XmlNode xmlNode in xmlNodeList)
			{
				foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
				{
					if (xmlNode2.Name == nodeName)
					{
						result = xmlNode2.InnerText;
						return result;
					}
				}
			}
			result = string.Empty;
			return result;
		}
		public static string GetValueInvoice(string nodeName)
		{
			string result;
			foreach (XmlNode xmlNode in ShopSettings.xmlNodes)
			{
				foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
				{
					if (xmlNode2.Name == nodeName)
					{
						result = xmlNode2.InnerText;
						return result;
					}
				}
			}
			result = string.Empty;
			return result;
		}
		public List<string> GetValueAllInvoice(string fieldXmlPath)
		{
			return new List<string>
			{
				this.GetValueInvoice(fieldXmlPath, "InvoiceType1"),
				this.GetValueInvoice(fieldXmlPath, "InvoiceType2"),
				this.GetValueInvoice(fieldXmlPath, "InvoiceType3")
			};
		}
		public static List<string> GetValueAllInvoice()
		{
			return new List<string>
			{
				ShopSettings.GetValueInvoice("InvoiceType1"),
				ShopSettings.GetValueInvoice("InvoiceType2"),
				ShopSettings.GetValueInvoice("InvoiceType3")
			};
		}
	}
}
