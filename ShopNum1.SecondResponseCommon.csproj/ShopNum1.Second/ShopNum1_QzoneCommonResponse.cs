using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Xml;
namespace ShopNum1.Second
{
	public class ShopNum1_QzoneCommonResponse
	{
		public string GetQQUserName(string string_0, string ftype)
		{
			string result;
			if (ftype == "xml")
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(string_0);
				try
				{
					if (xmlDocument.SelectNodes("data").Count != 0)
					{
						XmlNode xmlNode = xmlDocument.SelectSingleNode("data/nickname");
						result = xmlNode.InnerText;
						return result;
					}
				}
				catch
				{
				}
				result = "";
			}
			else
			{
				JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
				Dictionary<string, object> dictionary = (Dictionary<string, object>)javaScriptSerializer.DeserializeObject(string_0);
				try
				{
					object obj;
					dictionary.TryGetValue("nickname", out obj);
					result = obj.ToString();
				}
				catch
				{
					result = "";
				}
			}
			return result;
		}
	}
}
