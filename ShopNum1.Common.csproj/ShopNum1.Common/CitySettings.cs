using System;
using System.Web;
using System.Xml;
namespace ShopNum1.Common
{
	public class CitySettings
	{
		public static string GetValue(string nodeName, string SubstationID)
		{
			string result;
			try
			{
				string xmlPath = HttpContext.Current.Request.PhysicalApplicationPath + "\\City\\" + SubstationID + "\\Settings\\ShopSetting.xml";
				XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(xmlPath, "ShopSetting");
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
			}
			catch
			{
				result = "";
			}
			return result;
		}
	}
}
