using Newtonsoft.Json;
using System;
namespace ShopNum1.DiscuzToolkit
{
	public class UserForEditing
	{
		[JsonProperty("nick_name")]
		public string NickName;
		[JsonProperty("password")]
		public string Password;
		[JsonProperty("space_id")]
		public string SpaceId;
		[JsonProperty("gender")]
		public string Gender;
		[JsonProperty("ext_credits_1")]
		public string ExtCredits1;
		[JsonProperty("ext_credits_2")]
		public string ExtCredits2;
		[JsonProperty("ext_credits_3")]
		public string ExtCredits3;
		[JsonProperty("ext_credits_4")]
		public string ExtCredits4;
		[JsonProperty("ext_credits_5")]
		public string ExtCredits5;
		[JsonProperty("ext_credits_6")]
		public string ExtCredits6;
		[JsonProperty("ext_credits_7")]
		public string ExtCredits7;
		[JsonProperty("ext_credits_8")]
		public string ExtCredits8;
		[JsonProperty("email")]
		public string Email;
		[JsonProperty("birthday")]
		public string Birthday;
		[JsonProperty("web_site")]
		public string WebSite;
		[JsonProperty("icq")]
		public string Icq;
		[JsonProperty("qq")]
		public string Qq;
		[JsonProperty("yahoo")]
		public string Yahoo;
		[JsonProperty("msn")]
		public string Msn;
		[JsonProperty("skype")]
		public string Skype;
		[JsonProperty("location")]
		public string Location;
		[JsonProperty("about_me")]
		public string Bio;
		[JsonProperty("real_name")]
		public string RealName;
		[JsonProperty("id_card")]
		public string IdCard;
		[JsonProperty("mobile")]
		public string Mobile;
		[JsonProperty("telephone")]
		public string Phone;
	}
}
