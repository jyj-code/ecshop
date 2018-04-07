using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class Friend : SessionWrapper
	{
		[XmlElement("uid")]
		public long UId;
		public Friend(long UId, DiscuzSession session)
		{
			this.UId = UId;
			this.discuzSession_0 = session;
		}
		public Friend()
		{
		}
		public User GetUserInfo()
		{
			User[] userInfo = this.discuzSession_0.GetUserInfo(new long[]
			{
				this.UId
			}, User.FIELDS);
			return userInfo[0];
		}
	}
}
