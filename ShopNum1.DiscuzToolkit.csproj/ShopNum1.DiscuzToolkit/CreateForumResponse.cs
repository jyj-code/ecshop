using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("forums_create_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class CreateForumResponse
	{
		[JsonProperty("fid"), XmlElement("fid")]
		public int Fid;
		[JsonProperty("url"), XmlElement("url")]
		public string Url;
	}
}
