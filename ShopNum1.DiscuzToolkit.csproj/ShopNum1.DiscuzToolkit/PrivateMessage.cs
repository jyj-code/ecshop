using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class PrivateMessage
	{
		[JsonProperty("message_id"), XmlElement("message_id")]
		public int MsgID;
		[JsonProperty("from"), XmlElement("from")]
		public string FromUser;
		[JsonProperty("from_id"), XmlElement("from_id")]
		public string FormID;
		[JsonProperty("subject"), XmlElement("subject", IsNullable = false)]
		public string Subject;
		[JsonProperty("post_date_time"), XmlElement("post_date_time")]
		public string PostDateTime;
		[JsonProperty("message"), XmlElement("message")]
		public string Message;
	}
}
