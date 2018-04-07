using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("topics_getRecentReplies_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class TopicGetRencentRepliesResponse
	{
		[XmlElement("count")]
		public int Count;
		[XmlElement("post")]
		public Post[] post_array;
		[JsonIgnore, XmlAttribute("list")]
		public bool List;
		[JsonIgnore]
		public Post[] Posts
		{
			get
			{
				return this.post_array ?? new Post[0];
			}
		}
	}
}
