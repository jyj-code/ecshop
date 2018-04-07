using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("topics_get_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class TopicGetResponse
	{
		[JsonProperty("topic_id"), XmlElement("topic_id")]
		public int TopicId;
		[JsonProperty("url"), XmlElement("url")]
		public string Url;
		[JsonProperty("title"), XmlElement("title", IsNullable = false)]
		public string Title;
		[JsonProperty("fid"), XmlElement("fid", IsNullable = false)]
		public int Fid;
		[JsonProperty("icon_id"), XmlElement("icon_id", IsNullable = false)]
		public int Iconid;
		[JsonProperty("tags"), XmlElement("tags", IsNullable = true)]
		public string Tags;
		[JsonProperty("author"), XmlElement("author")]
		public string Author = string.Empty;
		[JsonProperty("author_id"), XmlElement("author_id")]
		public int AuthorId;
		[JsonProperty("reply_count"), XmlElement("reply_count")]
		public int ReplyCount;
		[JsonProperty("view_count"), XmlElement("view_count")]
		public int ViewCount;
		[JsonProperty("last_post_time"), XmlElement("last_post_time")]
		public string LastPostTime = string.Empty;
		[JsonProperty("last_poster_id"), XmlElement("last_poster_id")]
		public int LastPosterId;
		[JsonProperty("posts"), XmlElement("post")]
		public Post[] Posts;
		[JsonProperty("attachments"), XmlElement("attachment")]
		public AttachmentInfo[] Attachments;
		[JsonIgnore, XmlAttribute("list")]
		public bool List;
	}
}
