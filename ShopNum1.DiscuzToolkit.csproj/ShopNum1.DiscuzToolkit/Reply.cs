using Newtonsoft.Json;
using System;
namespace ShopNum1.DiscuzToolkit
{
	public class Reply
	{
		[JsonProperty("tid")]
		public int Tid;
		[JsonProperty("fid")]
		public int Fid;
		[JsonProperty("message")]
		public string Message;
		[JsonProperty("title")]
		public string Title;
	}
}
