using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("auth_getSession_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class SessionInfo
	{
		[XmlElement("session_key")]
		public string SessionKey;
		[XmlElement("uid")]
		public long UId;
		[XmlIgnore]
		public string Secret;
		[XmlElement("user_name")]
		public string UserName;
		[XmlElement("expires")]
		public long Expires;
		public SessionInfo()
		{
		}
		public SessionInfo(string session_key, long long_0, string secret, string rest_url)
		{
			this.SessionKey = session_key;
			this.UId = long_0;
			this.Secret = secret;
			this.Expires = 0L;
		}
	}
}
