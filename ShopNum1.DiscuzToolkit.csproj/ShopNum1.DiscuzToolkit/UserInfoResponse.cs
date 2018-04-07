using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	[XmlRoot("users_getInfo_response", Namespace = "http://nt.discuz.net/api/", IsNullable = false)]
	public class UserInfoResponse
	{
		[XmlElement("user")]
		public User[] user_array;
		[XmlAttribute("list")]
		public bool List;
		[XmlIgnore]
		public User[] Users
		{
			get
			{
				return this.user_array ?? new User[0];
			}
		}
	}
}
