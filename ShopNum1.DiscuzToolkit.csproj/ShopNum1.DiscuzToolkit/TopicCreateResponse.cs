using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("topics_create_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class TopicCreateResponse
	{
		[JsonProperty("topic_id"), XmlElement("topic_id")]
		public int Topicid;
		[JsonProperty("url"), XmlElement("url")]
		public string Url;
		[JsonProperty("need_audit"), XmlElement("need_audit")]
		public bool NeedAudit;
	}
}
