using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
namespace ShopNum1.Second
{
	public class ShopNum1_XinlanCommonClient
	{
		private readonly string string_0 = "https://api.weibo.com/2/users/show.json";
		public ShopNum1_XinlanUserResponse GetXinlanUser(string string_1, string access_token)
		{
			string text = this.string_0;
			if (string_1 != "")
			{
				text = text + "?" + string.Format("uid={0}&access_token={1}", string_1, access_token);
			}
			return this.method_0(text);
		}
		private ShopNum1_XinlanUserResponse method_0(string string_1)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			ShopNum1_XinlanUserResponse shopNum1_XinlanUserResponse = new ShopNum1_XinlanUserResponse();
			string input = null;
			try
			{
				input = new Class0().method_1(string_1);
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8);
					input = streamReader.ReadToEnd();
				}
			}
			return javaScriptSerializer.Deserialize<ShopNum1_XinlanUserResponse>(input);
		}
	}
}
