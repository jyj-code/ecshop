using System;
using System.Collections;
using System.Text;
using System.Web;
namespace ShopNum1.Payment
{
	public class Tenpay_Dual
	{
		private string string_0;
		private string string_1;
		protected Hashtable parameters;
		private string string_2;
		protected HttpContext httpContext;
		public Tenpay_Dual(HttpContext httpContext)
		{
			this.parameters = new Hashtable();
			this.httpContext = httpContext;
			this.setGateUrl("https://www.tenpay.com/cgi-bin/v1.0/service_gate.cgi");
		}
		public virtual void init()
		{
		}
		public string getGateUrl()
		{
			return this.string_0;
		}
		public void setGateUrl(string gateUrl)
		{
			this.string_0 = gateUrl;
		}
		public string getKey()
		{
			return this.string_1;
		}
		public void setKey(string string_3)
		{
			this.string_1 = string_3;
		}
		public virtual string getRequestURL()
		{
			this.createSign();
			StringBuilder stringBuilder = new StringBuilder();
			ArrayList arrayList = new ArrayList(this.parameters.Keys);
			arrayList.Sort();
			foreach (string text in arrayList)
			{
				string text2 = (string)this.parameters[text];
				if (text2 != null && "key".CompareTo(text) != 0)
				{
					stringBuilder.Append(text + "=" + TenpayUtil.UrlEncode(text2, this.getCharset()) + "&");
				}
			}
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
			return this.getGateUrl() + "?" + stringBuilder.ToString();
		}
		protected virtual void createSign()
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
			this.setParameter("sign", text3);
			this.setDebugInfo(stringBuilder.ToString() + " => sign:" + text3);
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
		public void doSend()
		{
			this.httpContext.Response.Redirect(this.getRequestURL());
		}
		public string getDebugInfo()
		{
			return this.string_2;
		}
		public void setDebugInfo(string debugInfo)
		{
			this.string_2 = debugInfo;
		}
		public Hashtable getAllParameters()
		{
			return this.parameters;
		}
		protected virtual string getCharset()
		{
			return this.httpContext.Request.ContentEncoding.BodyName;
		}
	}
}
