using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
namespace ShopNum1.Second
{
	public class ShopNum1_TaobaoCommonClient
	{
		private readonly string string_0 = "\thttps://openapi.baidu.com/rest/2.0/passport/users/getLoggedInUser";
		public ShopNum1_TaobaoUserResponse GetBaiduUser(string acctoken, string format)
		{
			string string_ = string.Format("access_token={0}&format={1}", acctoken, format);
			ShopNum1_TaobaoUserResponse result = new ShopNum1_TaobaoUserResponse();
			if (format == "json")
			{
				result = this.method_0(string_);
			}
			else
			{
				result = this.method_2(string_);
			}
			return result;
		}
		private ShopNum1_TaobaoUserResponse method_0(string string_1)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			ShopNum1_TaobaoUserResponse shopNum1_TaobaoUserResponse = new ShopNum1_TaobaoUserResponse();
			string text = null;
			try
			{
				text = new Class0().method_0(this.string_0, string_1);
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
			return javaScriptSerializer.Deserialize<ShopNum1_TaobaoUserResponse>(text);
		}
		private ShopNum1_TaobaoUserResponse method_1(string string_1)
		{
			string strXml = null;
			ShopNum1_TaobaoUserResponse shopNum1_TaobaoUserResponse = new ShopNum1_TaobaoUserResponse();
			ShopNum1_TaobaoUserResponse result;
			try
			{
				strXml = new Class0().method_0(this.string_0, string_1);
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8);
					strXml = streamReader.ReadToEnd();
					result = null;
					return result;
				}
			}
			XmlOperate xmlOperate = new XmlOperate();
			ErrorRsp errorRsp_ = new ErrorRsp();
			xmlOperate.XmlToObject2<ShopNum1_TaobaoUserResponse>(strXml, "passport_users_getLoggedInUser", "", shopNum1_TaobaoUserResponse, errorRsp_);
			result = shopNum1_TaobaoUserResponse;
			return result;
		}
		private ShopNum1_TaobaoUserResponse method_2(string string_1)
		{
			string xml = null;
			ShopNum1_TaobaoUserResponse shopNum1_TaobaoUserResponse = new ShopNum1_TaobaoUserResponse();
			ShopNum1_TaobaoUserResponse result;
			try
			{
				xml = new Class0().method_0(this.string_0, string_1);
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError)
				{
					StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8);
					xml = streamReader.ReadToEnd();
					result = null;
					return result;
				}
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("passport_users_getLoggedInUser_response");
			if (xmlNodeList.Count == 0)
			{
				result = null;
			}
			else
			{
				shopNum1_TaobaoUserResponse.uid=xmlNodeList[0].ChildNodes[0].InnerText;
				shopNum1_TaobaoUserResponse.uname = xmlNodeList[0].ChildNodes[1].InnerText;
				shopNum1_TaobaoUserResponse.portrait = xmlNodeList[0].ChildNodes[2].InnerText;
				result = shopNum1_TaobaoUserResponse;
			}
			return result;
		}
	}
}
