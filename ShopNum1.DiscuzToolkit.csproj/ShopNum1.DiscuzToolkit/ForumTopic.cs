using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class ForumTopic
	{
		[JsonProperty("tid"), XmlElement("tid")]
		public int TopicId;
		[JsonProperty("title"), XmlElement("title")]
		public string Title = string.Empty;
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
	}
}
