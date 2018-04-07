using ShopNum1.Payment;
using System;
using System.Collections;
using System.Text;
using System.Xml;
namespace tenpay
{
	public class TenpayDual_ClientResponseHandler
	{
		private string string_0;
		protected Hashtable parameters;
		private string string_1;
		protected string content;
		private string string_2 = "gb2312";
		public TenpayDual_ClientResponseHandler()
		{
			this.parameters = new Hashtable();
		}
		public string getContent()
		{
			return this.content;
		}
		public virtual void setContent(string content)
		{
			this.content = content;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(content);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("root");
			XmlNodeList childNodes = xmlNode.ChildNodes;
			foreach (XmlNode xmlNode2 in childNodes)
			{
				this.setParameter(xmlNode2.Name, xmlNode2.InnerXml);
			}
		}
		public string getKey()
		{
			return this.string_0;
		}
		public void setKey(string string_3)
		{
			this.string_0 = string_3;
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
			return this.string_2;
		}
		public void setCharset(string charset)
		{
			this.string_2 = charset;
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
