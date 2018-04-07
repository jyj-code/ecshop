using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("messages_get_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class MessagesGetResponse
	{
		[JsonProperty("count"), XmlElement("count")]
		public int count;
		[JsonProperty("pms"), XmlElement("pm")]
		public PrivateMessage[] PM;
	}
}
