using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("users_getLoggedInUser_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class LoggedInUserResponse
	{
		[XmlText]
		public int Uid;
		[XmlAttribute("list")]
		public bool List;
	}
}
