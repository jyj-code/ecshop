using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
namespace ShopNum1.Second
{
	public class ShopNum1_BaiduOAuthClient
	{
		private readonly string string_0 = "https://openapi.baidu.com/oauth/2.0/authorize";
		private readonly string string_1 = "https://openapi.baidu.com/oauth/2.0/token";
		public void GetAuthorizationCode(string API_Key, string redirect_uri)
		{
			string url = string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}", this.string_0, API_Key, redirect_uri);
			HttpContext.Current.Response.Redirect(url);
		}
		public string GetAuthorizationUrl(string API_Key, string redirect_uri)
		{
			return string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}", this.string_0, API_Key, redirect_uri);
		}
		public ShopNum1_BaiduOAuthMessage GetAccessTokenByAuthorizationCode(string API_Key, string Secret_Key, string code, string redirect_uri)
		{
			string string_ = string.Format("grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri={3}", new object[]
			{
				code,
				API_Key,
				Secret_Key,
				redirect_uri
			});
			return this.method_0(string_);
		}
		public ShopNum1_BaiduOAuthMessage GetAccessTokenByClientCredentials(string API_Key, string Secret_Key, string scope)
		{
			string string_ = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope={2}", API_Key, Secret_Key, scope);
			return this.method_0(string_);
		}
		public ShopNum1_BaiduOAuthMessage GetAccessTokenByPasswordCredentials(string API_Key, string Secret_Key, string username, string password, string scope)
		{
			string string_ = string.Format("grant_type=password&client_id={0}&client_secret={1}&scope={2}&username={3}&password={4}", new object[]
			{
				API_Key,
				Secret_Key,
				scope,
				username,
				password
			});
			return this.method_0(string_);
		}
		public ShopNum1_BaiduOAuthMessage GetAccessTokenByRefreshToken(string API_Key, string Secret_Key, string refresh_token, string scope)
		{
			string string_ = string.Format("grant_type=refresh_token&client_id={0}&client_secret={1}&scope={2}&refresh_token={3}", new object[]
			{
				API_Key,
				Secret_Key,
				scope,
				refresh_token
			});
			return this.method_0(string_);
		}
		private ShopNum1_BaiduOAuthMessage method_0(string string_2)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			string text = null;
			try
			{
				text = new Class0().method_0(this.string_1, string_2);
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8);
					text = streamReader.ReadToEnd();
				}
			}
			if (text.Contains("error"))
			{
				throw javaScriptSerializer.Deserialize<ShopNum1_BaiduOAuthException>(text);
			}
			text = text.Replace("\\", "\\\\");
			return javaScriptSerializer.Deserialize<ShopNum1_BaiduOAuthMessage>(text);
		}
	}
}
