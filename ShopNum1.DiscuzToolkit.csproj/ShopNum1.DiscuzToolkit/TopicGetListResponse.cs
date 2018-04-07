using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("topics_getList_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class TopicGetListResponse
	{
		[XmlElement("count")]
		public int Count;
		[XmlElement("topic")]
		public ForumTopic[] Topics;
		[JsonIgnore, XmlAttribute("list")]
		public bool List;
	}
}
