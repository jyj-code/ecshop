using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
namespace ShopNum1.Second
{
	public class ShopNum1_XinlanOAuthClient
	{
		private readonly string string_0 = "https://api.weibo.com/oauth2/authorize";
		private readonly string string_1 = "https://api.weibo.com/oauth2/access_token";
		public void GetAuthorizationCode(string API_Key, string redirect_uri)
		{
			string url = string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}", this.string_0, API_Key, redirect_uri);
			HttpContext.Current.Response.Redirect(url);
		}
		public string GetAuthorizationUrl(string API_Key, string redirect_uri)
		{
			return string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}", this.string_0, API_Key, redirect_uri);
		}
		public ShopNum1_XinLanOAuthMessage GetAccessTokenByAppkeySecret(string API_Key, string Secret, string redirect_url, string code)
		{
			string string_ = string.Format("client_id={0}&client_secret={1}&grant_type=authorization_code&redirect_uri={2}&code={3}", new object[]
			{
				API_Key,
				Secret,
				redirect_url,
				code
			});
			return this.method_0(string_);
		}
		private ShopNum1_XinLanOAuthMessage method_0(string string_2)
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
				throw javaScriptSerializer.Deserialize<ShopNum1_XinlanOAuthException>(text);
			}
			text = text.Replace("\\", "\\\\");
			return javaScriptSerializer.Deserialize<ShopNum1_XinLanOAuthMessage>(text);
		}
	}
}
