using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class IndexForum
	{
		[JsonProperty("fid"), XmlElement("fid")]
		public int Fid;
		[JsonProperty("url"), XmlElement("url")]
		public string Url;
		[JsonProperty("topics"), XmlElement("topics")]
		public int Topics;
		[JsonProperty("current_topics"), XmlElement("current_topics")]
		public int CurTopics;
		[JsonProperty("posts"), XmlElement("posts")]
		public int Posts;
		[JsonProperty("today_posts"), XmlElement("today_posts")]
		public int TodayPosts;
		[JsonProperty("last_post"), XmlElement("last_post")]
		public string LastPost;
		[JsonProperty("last_poster"), XmlElement("last_poster")]
		public string LastPoster;
		[JsonProperty("last_poster_id"), XmlElement("last_poster_id")]
		public int LastPosterId;
		[JsonProperty("last_tid"), XmlElement("last_tid")]
		public int LastTid;
		[JsonProperty("last_title"), XmlElement("last_title")]
		public string LastTitle;
		[JsonProperty("description"), XmlElement("description")]
		public string Description;
		[JsonProperty("icon"), XmlElement("icon")]
		public string Icon;
		[JsonProperty("moderators"), XmlElement("moderators")]
		public string Moderators;
		[JsonProperty("rules"), XmlElement("rules")]
		public string Rules;
		[JsonProperty("parent_id"), XmlElement("parent_id")]
		public int ParentId;
		[JsonProperty("path_list"), XmlElement("path_list")]
		public string PathList;
		[JsonProperty("parent_id_list"), XmlElement("parent_id_list")]
		public string ParentIdList;
		[JsonProperty("sub_forum_count"), XmlElement("sub_forum_count")]
		public int SubForumCount;
		[JsonProperty("name"), XmlElement("name")]
		public string Name;
		[JsonProperty("status"), XmlElement("status")]
		public int Status;
		[JsonProperty("has_new"), XmlElement("has_new")]
		public string HasNew;
	}
}
