using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("forums_getIndexList_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class GetIndexListResponse
	{
		[JsonProperty("forums"), XmlElement("forum")]
		public IndexForum[] Forum;
	}
}
