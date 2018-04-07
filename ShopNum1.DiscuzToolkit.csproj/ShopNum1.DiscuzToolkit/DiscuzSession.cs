using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
namespace ShopNum1.DiscuzToolkit
{
	public class DiscuzSession
	{
		private Util util_0;
		public SessionInfo session_info;
		private string string_0;
		private string string_1;
		internal Util Util
		{
			get
			{
				return this.util_0;
			}
		}
		internal string SessionKey
		{
			get
			{
				return this.session_info.SessionKey;
			}
		}
		public DiscuzSession(string api_key, string shared_secret, string forum_url)
		{
			this.util_0 = new Util(api_key, shared_secret, forum_url + "/services/restserver.aspx?");
			this.string_1 = forum_url;
		}
		public DiscuzSession(string api_key, SessionInfo session_info, string forum_url) : this(api_key, session_info.Secret, forum_url)
		{
			this.session_info = session_info;
			this.string_1 = forum_url;
		}
		public Uri CreateToken()
		{
			return new Uri(string.Format("{0}/login.aspx?api_key={1}", this.string_1, this.util_0.ApiKey));
		}
		public Me GetLoggedInUser()
		{
			return new Me(this.session_info.UId, this);
		}
		public void Login(int int_0, string password, bool isMD5Passwd, int expires, string cookieDomain)
		{
			User userInfo = this.GetUserInfo((long)int_0);
			HttpCookie httpCookie = new HttpCookie("dnt");
			httpCookie.Values["userid"] = userInfo.UId.ToString();
			httpCookie.Values["password"] = this.EncodePassword(password, isMD5Passwd);
			httpCookie.Values["avatar"] = HttpUtility.UrlEncode(userInfo.Avatar.ToString());
			httpCookie.Values["tpp"] = userInfo.Tpp.ToString();
			httpCookie.Values["ppp"] = userInfo.Ppp.ToString();
			httpCookie.Values["invisible"] = userInfo.Invisible.ToString();
			httpCookie.Values["referer"] = "index.aspx";
			httpCookie.Values["expires"] = expires.ToString();
			if (expires > 0)
			{
				httpCookie.Expires = DateTime.Now.AddMinutes((double)expires);
			}
			httpCookie.Domain = cookieDomain;
			httpCookie.Secure = false;
			httpCookie.Path = "/";
			HttpContext.Current.Response.AppendCookie(httpCookie);
		}
		public void Logout(string domain)
		{
			HttpCookie httpCookie = new HttpCookie("dnt");
			httpCookie.Values.Clear();
			httpCookie.Expires = DateTime.Now.AddYears(-1);
			httpCookie.Domain = domain;
			HttpContext.Current.Response.AppendCookie(httpCookie);
		}
		public string CreateTokenForClient()
		{
			return this.util_0.GetResponse<TokenInfo>("auth.createToken", new DiscuzParam[0]).Token;
		}
		public int Register(string username, string password, string email, bool isMD5Passwd)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			list.Add(DiscuzParam.Create("user_name", username));
			list.Add(DiscuzParam.Create("password", password));
			list.Add(DiscuzParam.Create("email", email));
			if (isMD5Passwd)
			{
				list.Add(DiscuzParam.Create("password_format", "md5"));
			}
			RegisterResponse response = this.util_0.GetResponse<RegisterResponse>("auth.register", list.ToArray());
			return response.Uid;
		}
		public string EncodePassword(string password, bool isMD5Passwd)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			list.Add(DiscuzParam.Create("password", password));
			if (isMD5Passwd)
			{
				list.Add(DiscuzParam.Create("password_format", "md5"));
			}
			EncodePasswordResponse response = this.util_0.GetResponse<EncodePasswordResponse>("auth.encodePassword", list.ToArray());
			return response.Password;
		}
		public SessionInfo GetSessionFromToken(string auth_token)
		{
			this.session_info = this.util_0.GetResponse<SessionInfo>("auth.getSession", new DiscuzParam[]
			{
				DiscuzParam.Create("auth_token", auth_token)
			});
			this.string_0 = string.Empty;
			this.session_info.Secret = this.util_0.SharedSecret;
			return this.session_info;
		}
		public User[] GetUserInfo(long[] uids, string[] fields)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			if (uids == null || uids.Length == 0)
			{
				throw new Exception("uid not provided");
			}
			list.Add(DiscuzParam.Create("uids", uids));
			list.Add(DiscuzParam.Create("fields", fields));
			UserInfoResponse response = this.util_0.GetResponse<UserInfoResponse>("users.getInfo", list.ToArray());
			return response.Users;
		}
		public int GetUserID(string username)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("user_name", username));
			GetIDResponse response = this.util_0.GetResponse<GetIDResponse>("users.getID", list.ToArray());
			return response.UId;
		}
		public User GetUserInfo(long long_0)
		{
			User[] userInfo = this.GetUserInfo(new long[]
			{
				long_0
			}, User.FIELDS);
			User result;
			if (userInfo.Length < 1)
			{
				result = null;
			}
			else
			{
				result = userInfo[0];
			}
			return result;
		}
		public bool SetUserInfo(int int_0, UserForEditing user_for_editing)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("uid", int_0));
			list.Add(DiscuzParam.Create("user_info", JavaScriptConvert.SerializeObject(user_for_editing)));
			SetInfoResponse response = this.util_0.GetResponse<SetInfoResponse>("users.setInfo", list.ToArray());
			return response.Successfull == 1;
		}
		public bool SetExtCredits(string uids, string additional_values)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("uids", uids));
			list.Add(DiscuzParam.Create("additional_values", additional_values));
			SetExtCreditsResponse response = this.util_0.GetResponse<SetExtCreditsResponse>("users.setExtCredits", list.ToArray());
			return response.Successfull == 1;
		}
		public bool ChangeUserPassword(long long_0, string originalPassword, string newPassword, string confirmNewPassword, string passwordFormat)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			list.Add(DiscuzParam.Create("uid", long_0));
			list.Add(DiscuzParam.Create("original_password", originalPassword));
			list.Add(DiscuzParam.Create("new_password", newPassword));
			list.Add(DiscuzParam.Create("confirm_new_password", confirmNewPassword));
			list.Add(DiscuzParam.Create("password_format", passwordFormat));
			ChangePasswordResponse response = this.util_0.GetResponse<ChangePasswordResponse>("users.changePassword", list.ToArray());
			return response.Result == 1;
		}
		public TopicCreateResponse CreateTopic(int int_0, string title, int int_1, string message, int icon_id, string tags)
		{
			Topic topic = new Topic();
			topic.UId = ((int_0 == 0) ? ((int)this.session_info.UId) : int_0);
			topic.Title = title;
			topic.Fid = int_1;
			topic.Message = message;
			topic.Iconid = icon_id;
			topic.Tags = tags;
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (int_0 == 0)
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("topic_info", JavaScriptConvert.SerializeObject(topic)));
			return this.util_0.GetResponse<TopicCreateResponse>("topics.create", list.ToArray());
		}
		public TopicCreateResponse CreateTopic(string title, int int_0, string message, int icon_id, string tags)
		{
			return this.CreateTopic(0, title, int_0, message, icon_id, tags);
		}
		public TopicEditResponse EditTopic(int int_0, string jsonTopicInfo)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("tid", int_0));
			list.Add(DiscuzParam.Create("topic_info", jsonTopicInfo));
			return this.util_0.GetResponse<TopicEditResponse>("topics.edit", list.ToArray());
		}
		public TopicEditResponse EditTopic(int int_0, Topic topic)
		{
			return this.EditTopic(int_0, Util.RemoveJsonNull(JavaScriptConvert.SerializeObject(topic)));
		}
		public TopicDeleteResponse DeleteTopic(string topicids, int forumid)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("topic_ids", topicids));
			if (forumid > 0)
			{
				list.Add(DiscuzParam.Create("fid", forumid));
			}
			return this.util_0.GetResponse<TopicDeleteResponse>("topics.delete", list.ToArray());
		}
		public TopicDeleteResponse DeleteTopic(string topicids)
		{
			return this.DeleteTopic(topicids, 0);
		}
		public TopicGetResponse GetTopic(int int_0, int pageindex, int pagesize)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("tid", int_0));
			list.Add(DiscuzParam.Create("page_index", pageindex));
			list.Add(DiscuzParam.Create("page_size", pagesize));
			return this.util_0.GetResponse<TopicGetResponse>("topics.get", list.ToArray());
		}
		public TopicReplyResponse TopicReply(Reply reply)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("reply_info", JavaScriptConvert.SerializeObject(reply)));
			return this.util_0.GetResponse<TopicReplyResponse>("topics.reply", list.ToArray());
		}
		public Post[] GetRecentReplies(int int_0, int int_1, int page_size, int page_index)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("fid", int_0));
			list.Add(DiscuzParam.Create("tid", int_1));
			list.Add(DiscuzParam.Create("page_size", page_size));
			list.Add(DiscuzParam.Create("page_index", page_index));
			TopicGetRencentRepliesResponse response = this.util_0.GetResponse<TopicGetRencentRepliesResponse>("topics.getRecentReplies", list.ToArray());
			return response.Posts;
		}
		public ForumTopic[] GetTopicList(int int_0, int page_size, int page_index)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("fid", int_0));
			list.Add(DiscuzParam.Create("page_size", page_size));
			list.Add(DiscuzParam.Create("page_index", page_index));
			TopicGetListResponse response = this.util_0.GetResponse<TopicGetListResponse>("topics.getList", list.ToArray());
			return response.Topics;
		}
		public ForumTopic[] GetAttentionTopicList(int int_0, int page_size, int page_index)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("fid", int_0));
			list.Add(DiscuzParam.Create("page_size", page_size));
			list.Add(DiscuzParam.Create("page_index", page_index));
			TopicGetListResponse response = this.util_0.GetResponse<TopicGetListResponse>("topics.getAttentionList", list.ToArray());
			return response.Topics;
		}
		public TopicDeleteRepliesResponse DeleteTopicReplies(int int_0, string postids)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("tid", int_0));
			list.Add(DiscuzParam.Create("post_ids", postids));
			return this.util_0.GetResponse<TopicDeleteRepliesResponse>("topics.deletereplies", list.ToArray());
		}
		public string NotificationsSend(string notification, string to_ids, int int_0)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (int_0 < 1 && this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("to_ids", to_ids));
			list.Add(DiscuzParam.Create("notification", notification));
			SendNotificationResponse response = this.util_0.GetResponse<SendNotificationResponse>("notifications.send", list.ToArray());
			return response.Result;
		}
		public string NotificationSendEmail(string recipients, string subject, string text)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("recipients", recipients));
			list.Add(DiscuzParam.Create("subject", subject));
			list.Add(DiscuzParam.Create("text", text));
			SendNotificationEmailResponse response = this.util_0.GetResponse<SendNotificationEmailResponse>("notifications.sendEmail", list.ToArray());
			response.Recipients = recipients;
			return recipients;
		}
		public GetNotiificationResponse NotificationGet()
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			GetNotiificationResponse result;
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
				GetNotiificationResponse response = this.util_0.GetResponse<GetNotiificationResponse>("notifications.get", list.ToArray());
				result = response;
			}
			else
			{
				result = null;
			}
			return result;
		}
		public GetForumResponse ForumGet(int int_0)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("fid", int_0));
			return this.util_0.GetResponse<GetForumResponse>("forums.get", list.ToArray());
		}
		public CreateForumResponse ForumCreate(Forum forum)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			list.Add(DiscuzParam.Create("forum_info", JavaScriptConvert.SerializeObject(forum)));
			return this.util_0.GetResponse<CreateForumResponse>("forums.create", list.ToArray());
		}
		public GetIndexListResponse ForumGetIndexList()
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			if (this.session_info != null && !string.IsNullOrEmpty(this.session_info.SessionKey))
			{
				list.Add(DiscuzParam.Create("session_key", this.session_info.SessionKey));
			}
			return this.util_0.GetResponse<GetIndexListResponse>("forums.getindexlist", list.ToArray());
		}
		public string SendMessages(string to_uids, string fromid, string subject, string message)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			list.Add(DiscuzParam.Create("to_ids", to_uids));
			list.Add(DiscuzParam.Create("from_id", fromid));
			list.Add(DiscuzParam.Create("subject", subject));
			list.Add(DiscuzParam.Create("message", message));
			MessagesSendResponse response = this.util_0.GetResponse<MessagesSendResponse>("messages.send", list.ToArray());
			return response.Result;
		}
		public MessagesGetResponse GetUserMessages(int int_0, int pagesize, int pageindex)
		{
			List<DiscuzParam> list = new List<DiscuzParam>();
			list.Add(DiscuzParam.Create("uid", int_0));
			list.Add(DiscuzParam.Create("page_size", pagesize));
			list.Add(DiscuzParam.Create("page_index", pageindex));
			return this.util_0.GetResponse<MessagesGetResponse>("messages.get", list.ToArray());
		}
	}
}
