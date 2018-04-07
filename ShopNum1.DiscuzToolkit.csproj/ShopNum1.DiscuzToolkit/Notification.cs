using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class Notification
	{
		[JsonProperty("unread"), XmlElement("unread", IsNullable = false)]
		public int Unread;
		[JsonProperty("most_recent"), XmlElement("most_recent", IsNullable = false)]
		public int MostRecent;
	}
}
