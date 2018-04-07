using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class User : Friend
	{
		public static readonly string[] FIELDS = new string[]
		{
			"uid",
			"user_name",
			"nick_name",
			"password",
			"space_id",
			"secques",
			"gender",
			"admin_id",
			"group_id",
			"group_expiry",
			"reg_ip",
			"join_date",
			"last_ip",
			"last_visit",
			"last_activity",
			"last_post",
			"last_post_id",
			"last_post_title",
			"post_count",
			"digest_post_count",
			"online_time",
			"page_view_count",
			"credits",
			"ext_credits_1",
			"ext_credits_2",
			"ext_credits_3",
			"ext_credits_4",
			"ext_credits_5",
			"ext_credits_6",
			"ext_credits_7",
			"ext_credits_8",
			"email",
			"birthday",
			"tpp",
			"ppp",
			"template_id",
			"pm_sound",
			"show_email",
			"invisible",
			"has_new_pm",
			"new_pm_count",
			"access_masks",
			"online_state",
			"web_site",
			"icq",
			"qq",
			"yahoo",
			"msn",
			"skype",
			"location",
			"custom_status",
			"avatar",
			"avatar_width",
			"avatar_height",
			"medals",
			"about_me",
			"sign_html",
			"real_name",
			"id_card",
			"mobile",
			"telephone"
		};
		[JsonProperty("user_name"), XmlElement("user_name", IsNullable = true)]
		public string UserName;
		[JsonProperty("nick_name"), XmlElement("nick_name", IsNullable = true)]
		public string NickName;
		[JsonProperty("password"), XmlElement("password", IsNullable = true)]
		public string Password;
		[JsonProperty("space_id"), XmlElement("space_id", IsNullable = true)]
		public int? SpaceId;
		[JsonProperty("secques"), XmlElement("secques", IsNullable = true)]
		public string Secques;
		[JsonProperty("gender"), XmlElement("gender", IsNullable = true)]
		public int? Gender;
		[JsonProperty("admin_id"), XmlElement("admin_id", IsNullable = true)]
		public int? Adminid;
		[JsonProperty("group_id"), XmlElement("group_id", IsNullable = true)]
		public int? GroupId;
		[JsonProperty("group_expiry"), XmlElement("group_expiry", IsNullable = true)]
		public int? GroupExpiry;
		[JsonProperty("ext_groupids"), XmlElement("ext_groupids", IsNullable = true)]
		public string ExtGroupids;
		[JsonProperty("reg_ip"), XmlElement("reg_ip", IsNullable = true)]
		public string RegIp;
		[JsonProperty("join_date"), XmlElement("join_date", IsNullable = true)]
		public string JoinDate;
		[JsonProperty("last_ip"), XmlElement("last_ip", IsNullable = true)]
		public string LastIp;
		[JsonProperty("last_visit"), XmlElement("last_visit", IsNullable = true)]
		public string LastVisit;
		[JsonProperty("last_activity"), XmlElement("last_activity", IsNullable = true)]
		public string LastActivity;
		[JsonProperty("last_post"), XmlElement("last_post", IsNullable = true)]
		public string LastPost;
		[JsonProperty("last_post_id"), XmlElement("last_post_id", IsNullable = true)]
		public int? LastPostid;
		[JsonProperty("last_post_title"), XmlElement("last_post_title", IsNullable = true)]
		public string LastPostTitle;
		[JsonProperty("post_count"), XmlElement("post_count", IsNullable = true)]
		public int? Posts;
		[JsonProperty("digest_post_count"), XmlElement("digest_post_count", IsNullable = true)]
		public int? DigestPosts;
		[JsonProperty("online_time"), XmlElement("online_time", IsNullable = true)]
		public int? OnlineTime;
		[JsonProperty("page_view_count"), XmlElement("page_view_count", IsNullable = true)]
		public int? PageViews;
		[JsonProperty("credits"), XmlElement("credits", IsNullable = true)]
		public int? Credits;
		[JsonProperty("ext_credits_1"), XmlElement("ext_credits_1", IsNullable = true)]
		public float? ExtCredits1;
		[JsonProperty("ext_credits_2"), XmlElement("ext_credits_2", IsNullable = true)]
		public float? ExtCredits2;
		[JsonProperty("ext_credits_3"), XmlElement("ext_credits_3", IsNullable = true)]
		public float? ExtCredits3;
		[JsonProperty("ext_credits_4"), XmlElement("ext_credits_4", IsNullable = true)]
		public float? ExtCredits4;
		[JsonProperty("ext_credits_5"), XmlElement("ext_credits_5", IsNullable = true)]
		public float? ExtCredits5;
		[JsonProperty("ext_credits_6"), XmlElement("ext_credits_6", IsNullable = true)]
		public float? ExtCredits6;
		[JsonProperty("ext_credits_7"), XmlElement("ext_credits_7", IsNullable = true)]
		public float? ExtCredits7;
		[JsonProperty("ext_credits_8"), XmlElement("ext_credits_8", IsNullable = true)]
		public float? ExtCredits8;
		[JsonIgnore, XmlIgnore]
		public int? AvatarShowId;
		[JsonProperty("email"), XmlElement("email", IsNullable = true)]
		public string Email;
		[JsonProperty("birthday"), XmlElement("birthday", IsNullable = true)]
		public string Birthday;
		[JsonIgnore, XmlIgnore]
		public int? SigStatus;
		[JsonProperty("tpp"), XmlElement("tpp", IsNullable = true)]
		public int? Tpp;
		[JsonProperty("ppp"), XmlElement("ppp", IsNullable = true)]
		public int? Ppp;
		[JsonProperty("template_id"), XmlElement("template_id", IsNullable = true)]
		public int? Templateid;
		[JsonProperty("pm_sound"), XmlElement("pm_sound", IsNullable = true)]
		public int? PmSound;
		[JsonProperty("show_email"), XmlElement("show_email", IsNullable = true)]
		public int? ShowEmail;
		[JsonProperty("invisible"), XmlElement("invisible", IsNullable = true)]
		public int? Invisible;
		[JsonProperty("has_new_pm"), XmlElement("has_new_pm", IsNullable = true)]
		public int? NewPm;
		[JsonProperty("new_pm_count"), XmlElement("new_pm_count", IsNullable = true)]
		public int? NewPmCount;
		[JsonProperty("access_masks"), XmlElement("access_masks", IsNullable = true)]
		public int? AccessMasks;
		[JsonProperty("online_state"), XmlElement("online_state", IsNullable = true)]
		public int? OnlineState;
		[JsonProperty("web_site"), XmlElement("web_site", IsNullable = true)]
		public string WebSite;
		[JsonProperty("icq"), XmlElement("icq", IsNullable = true)]
		public string Icq;
		[JsonProperty("qq"), XmlElement("qq", IsNullable = true)]
		public string Qq;
		[JsonProperty("yahoo"), XmlElement("yahoo", IsNullable = true)]
		public string Yahoo;
		[JsonProperty("msn"), XmlElement("msn", IsNullable = true)]
		public string Msn;
		[JsonProperty("skype"), XmlElement("skype", IsNullable = true)]
		public string Skype;
		[JsonProperty("location"), XmlElement("location", IsNullable = true)]
		public string Location;
		[JsonProperty("custom_status"), XmlElement("custom_status", IsNullable = true)]
		public string CustomStatus;
		[JsonProperty("avatar"), XmlElement("avatar", IsNullable = true)]
		public string Avatar;
		[JsonProperty("avatar_width"), XmlElement("avatar_width", IsNullable = true)]
		public int? AvatarWidth;
		[JsonProperty("avatar_height"), XmlElement("avatar_height", IsNullable = true)]
		public int? AvatarHeight;
		[JsonProperty("medals"), XmlElement("medals", IsNullable = true)]
		public string Medals;
		[JsonProperty("about_me"), XmlElement("about_me", IsNullable = true)]
		public string Bio;
		[JsonIgnore, XmlIgnore]
		public string Signature;
		[JsonProperty("sign_html"), XmlElement("sign_html", IsNullable = true)]
		public string Sightml;
		[JsonIgnore, XmlIgnore]
		public string AuthStr;
		[JsonIgnore, XmlIgnore]
		public string AuthTime;
		[JsonIgnore, XmlIgnore]
		public byte AuthFlag;
		[JsonProperty("real_name"), XmlElement("real_name", IsNullable = true)]
		public string RealName;
		[JsonProperty("id_card"), XmlElement("id_card", IsNullable = true)]
		public string IdCard;
		[JsonProperty("mobile"), XmlElement("mobile", IsNullable = true)]
		public string Mobile;
		[JsonProperty("telephone"), XmlElement("telephone", IsNullable = true)]
		public string Phone;
	}
}
