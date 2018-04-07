using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("topics_reply_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class TopicReplyResponse
	{
		[JsonProperty("post_id"), XmlElement("post_id")]
		public int PostId;
		[JsonProperty("url"), XmlElement("url")]
		public string Url;
		[JsonProperty("need_audit"), XmlElement("need_audit")]
		public bool NeedAudit;
	}
}
