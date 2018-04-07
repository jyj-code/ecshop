using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class Post
	{
		[JsonProperty("pid"), XmlElement("pid")]
		public int Pid;
		[JsonProperty("layer"), XmlElement("layer")]
		public int Layer;
		[JsonProperty("poster_id"), XmlElement("poster_id")]
		public int PosterId;
		[JsonProperty("poster_name"), XmlElement("poster_name")]
		public string PosterName;
		[JsonProperty("title"), XmlElement("title")]
		public string Title;
		[JsonProperty("message"), XmlElement("message")]
		public string Message;
		[JsonProperty("post_date_time"), XmlElement("post_date_time")]
		public string PostDateTime;
		[JsonProperty("invisible"), XmlElement("invisible")]
		public int Invisible;
		[JsonProperty("rate"), XmlElement("rate")]
		public int Rate;
		[JsonProperty("rate_times"), XmlElement("rate_times")]
		public int RateTimes;
		[JsonProperty("use_signature"), XmlElement("use_signature")]
		public int UseSignature;
		[JsonProperty("poster_email"), XmlElement("poster_email")]
		public string PosterEmail;
		[JsonProperty("poster_show_email"), XmlElement("poster_show_email")]
		public int PosterShowEmail;
		[JsonProperty("poster_avator"), XmlElement("poster_avator")]
		public string PosterAvator;
		[JsonProperty("poster_avator_width"), XmlElement("poster_avator_width")]
		public int PosterAvatorWidth;
		[JsonProperty("poster_avator_height"), XmlElement("poster_avator_height")]
		public int PosterAvatorHeight;
		[JsonProperty("poster_signature"), XmlElement("poster_signature")]
		public string PosterSignature;
		[JsonProperty("poster_location"), XmlElement("poster_location")]
		public string PosterLocation;
		[JsonProperty("ad_index"), XmlElement("ad_index")]
		public int AdIndex;
	}
}
