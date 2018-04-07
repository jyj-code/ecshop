using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace ShopNum1.Second
{
	public class ShopNum1_QzoneCommonClient
	{
		public string access_token;
		public string openid;
		public string scrore;
		public string redirectURI;
		public string AppId;
		public string AppSecret;
		public static string RestUrl = "https://graph.qq.com/";
		protected static string error_rspXML = "<error_response>\r\n<args list=\"true\"><arg><key>post</key><value>{2}</value></arg></args>\r\n<code>{0}</code>\r\n<msg>{1}</msg>\r\n<sub_code></sub_code>\r\n<sub_msg></sub_msg>\r\n</error_response>";
		public string GetQzoneOpenID()
		{
			string text = this.QzoneGet("openID", "", "");
			return JsonOperate.GetValueFromJson(text.Replace("callback(", "").Replace(");", ""), "openid");
		}
		public static void GetAuthorizationCode(string appid, string returnurl)
		{
			string url = string.Format("http://openapi.qzone.qq.com/oauth/show?client_id={0}&response_type=token&scope=get_user_info&redirect_uri={1}&which=ConfirmPage&display=", appid, returnurl);
			HttpContext.Current.Response.Redirect(url);
		}
		public static string GetAuthorizationUrl(string appid, string returnurl)
		{
			return string.Format("http://openapi.qzone.qq.com/oauth/show?client_id={0}&response_type=token&scope=get_user_info&redirect_uri={1}&which=ConfirmPage&display=", appid, returnurl);
		}
		public string QzoneGet(string type, string method, string format)
		{
			string result;
			try
			{
				string input = string.Empty;
				string qzoneUrl = this.GetQzoneUrl(type, method, format);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(qzoneUrl);
				httpWebRequest.Method = "GET";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = "SpaceTimeApp2.0";
				httpWebRequest.Timeout = 300000;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Encoding encoding = Encoding.GetEncoding("utf-8");
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, encoding);
				input = streamReader.ReadToEnd();
				if (streamReader != null)
				{
					streamReader.Close();
				}
				if (responseStream != null)
				{
					responseStream.Close();
				}
				if (httpWebResponse != null)
				{
					httpWebResponse.Close();
				}
				result = Regex.Replace(input, "[\\x00-\\x08\\x0b-\\x0c\\x0e-\\x1f]", "");
			}
			catch (Exception exception_)
			{
				result = ShopNum1_QzoneCommonClient.CustomErrorXML("8001", exception_);
			}
			return result;
		}
		public string GetQzoneUrl(string type, string method, string format)
		{
			string result;
			if (type == "openID")
			{
				result = string.Format("https://graph.qq.com/oauth2.0/me?access_token={0}", this.access_token);
			}
			else
			{
				result = string.Format("https://graph.qq.com/{0}/{1}?access_token={2}&oauth_consumer_key={3}&openid={4}&format={5}", new object[]
				{
					type,
					method,
					this.access_token,
					this.AppId,
					this.openid,
					format
				});
			}
			return result;
		}
		protected static string CustomErrorXML(string code, Exception exception_0)
		{
			return string.Format(ShopNum1_QzoneCommonClient.error_rspXML, code, exception_0.Message.Replace("\"", "'").Replace("'", "'").Replace("&", "＆"), exception_0.StackTrace.Replace("\"", "'").Replace("'", "'").Replace("<", "＜").Replace(">", "＞").Replace("&", "＆"));
		}
	}
}
