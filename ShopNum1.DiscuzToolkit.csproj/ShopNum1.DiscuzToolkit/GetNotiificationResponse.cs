using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("notification_get_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class GetNotiificationResponse
	{
		[JsonProperty("message"), XmlElement("message", IsNullable = true)]
		public Notification Message;
		[JsonProperty("notification"), XmlElement("notification", IsNullable = true)]
		public Notification Notification;
	}
}
