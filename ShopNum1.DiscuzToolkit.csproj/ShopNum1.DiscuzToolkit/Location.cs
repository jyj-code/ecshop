using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class Location
	{
		[XmlElement("street")]
		public string Street;
		[XmlElement("city")]
		public string City;
		[XmlElement("state")]
		public string State;
		[XmlElement("country")]
		public string Country;
		[XmlElement("zip")]
		public string Zip;
	}
}
