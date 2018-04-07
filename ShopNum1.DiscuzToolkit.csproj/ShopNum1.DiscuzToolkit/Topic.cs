using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class Topic
	{
		[JsonProperty("uid"), XmlElement("uid", IsNullable = false)]
		public int UId;
		[JsonProperty("title"), XmlElement("title", IsNullable = false)]
		public string Title;
		[JsonProperty("fid"), XmlElement("fid", IsNullable = false)]
		public int Fid;
		[JsonProperty("message"), XmlElement("message", IsNullable = false)]
		public string Message;
		[JsonProperty("icon_id"), XmlElement("icon_id", IsNullable = true)]
		public int Iconid;
		[JsonProperty("tags"), XmlElement("tags", IsNullable = true)]
		public string Tags;
	}
}
