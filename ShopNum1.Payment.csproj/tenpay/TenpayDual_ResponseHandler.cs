using ShopNum1.Payment;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Web;
namespace tenpay
{
	public class TenpayDual_ResponseHandler
	{
		private string string_0;
		protected Hashtable parameters;
		private string string_1;
		protected HttpContext httpContext;
		public TenpayDual_ResponseHandler(HttpContext httpContext)
		{
			this.parameters = new Hashtable();
			this.httpContext = httpContext;
			NameValueCollection nameValueCollection;
			if (this.httpContext.Request.HttpMethod == "POST")
			{
				nameValueCollection = this.httpContext.Request.Form;
			}
			else
			{
				nameValueCollection = this.httpContext.Request.QueryString;
			}
			foreach (string text in nameValueCollection)
			{
				string parameterValue = nameValueCollection[text];
				this.setParameter(text, parameterValue);
			}
		}
		public string getKey()
		{
			return this.string_0;
		}
		public void setKey(string string_2)
		{
			this.string_0 = string_2;
		}
		public string getParameter(string parameter)
		{
			string text = (string)this.parameters[parameter];
			return (text == null) ? "" : text;
		}
		public void setParameter(string parameter, string parameterValue)
		{
			if (parameter != null && parameter != "")
			{
				if (this.parameters.Contains(parameter))
				{
					this.parameters.Remove(parameter);
				}
				this.parameters.Add(parameter, parameterValue);
			}
		}
		public virtual bool isTenpaySign()
		{
			StringBuilder stringBuilder = new StringBuilder();
			ArrayList arrayList = new ArrayList(this.parameters.Keys);
			arrayList.Sort();
			foreach (string text in arrayList)
			{
				string text2 = (string)this.parameters[text];
				if (text2 != null && "".CompareTo(text2) != 0 && "sign".CompareTo(text) != 0 && "key".CompareTo(text) != 0)
				{
					stringBuilder.Append(text + "=" + text2 + "&");
				}
			}
			stringBuilder.Append("key=" + this.getKey());
			string text3 = MD5Util.GetMD5(stringBuilder.ToString(), this.getCharset()).ToLower();
			this.setDebugInfo(stringBuilder.ToString() + " => sign:" + text3);
			return this.getParameter("sign").ToLower().Equals(text3);
		}
		public void doShow(string show_url)
		{
			string s = "<html><head>\r\n<meta name=\"TENCENT_ONLINE_PAYMENT\" content=\"China TENCENT\">\r\n<script language=\"javascript\">\r\nwindow.location.href='" + show_url + "';\r\n</script>\r\n</head><body></body></html>";
			this.httpContext.Response.Write(s);
			this.httpContext.Response.End();
		}
		public string getDebugInfo()
		{
			return this.string_1;
		}
		protected void setDebugInfo(string debugInfo)
		{
			this.string_1 = debugInfo;
		}
		protected virtual string getCharset()
		{
			return this.httpContext.Request.ContentEncoding.BodyName;
		}
		public virtual bool _isTenpaySign(ArrayList akeys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text in akeys)
			{
				string text2 = (string)this.parameters[text];
				if (text2 != null && "".CompareTo(text2) != 0 && "sign".CompareTo(text) != 0 && "key".CompareTo(text) != 0)
				{
					stringBuilder.Append(text + "=" + text2 + "&");
				}
			}
			stringBuilder.Append("key=" + this.getKey());
			string text3 = MD5Util.GetMD5(stringBuilder.ToString(), this.getCharset()).ToLower();
			this.setDebugInfo(stringBuilder.ToString() + " => sign:" + text3);
			return this.getParameter("sign").ToLower().Equals(text3);
		}
	}
}
