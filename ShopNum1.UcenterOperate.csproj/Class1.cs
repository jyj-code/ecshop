using ShopNum1.Ucenter.Request;
using ShopNum1.Ucenter.UCAPI;
using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
internal class Class1
{
	private string string_0;
	private bool bool_0;
	private bool bool_1;
	private StringBuilder stringBuilder_0;
	private NameValueCollection nameValueCollection_0;
	private int int_0;
	public Class1(HttpRequest httpRequest_0, string string_1, string string_2) : this(httpRequest_0, string_1, string_2, true, Encoding.Default)
	{
	}
	public Class1(HttpRequest httpRequest_0, string string_1, string string_2, bool bool_2) : this(httpRequest_0, string_1, string_2, bool_2, Encoding.Default)
	{
	}
	public Class1(HttpRequest httpRequest_0, string string_1, string string_2, bool bool_2, Encoding encoding_0)
	{
		this.stringBuilder_0 = new StringBuilder();
		this.stringBuilder_0.AppendLine(DateTime.Now.ToString());
		this.stringBuilder_0.AppendLine("原始请求：" + httpRequest_0.RawUrl);
		this.string_0 = string.Empty;
		this.int_0 = 0;
		this.bool_1 = false;
		this.bool_0 = false;
		this.nameValueCollection_0 = new NameValueCollection();
		if (httpRequest_0[string_1] != null)
		{
			string text = httpRequest_0.QueryString[string_1].Trim();
			this.stringBuilder_0.AppendLine("Code参数：" + text);
			if (bool_2)
			{
				text = HttpUtility.UrlDecode(text);
			}
			text = UCAuthCode.AuthCodeDecode(text, string_2);
			this.stringBuilder_0.AppendLine("Code解密：" + text);
			this.stringBuilder_0.AppendLine("------------------------\r\n\r\n");
			this.nameValueCollection_0 = HttpUtility.ParseQueryString(text, Encoding.UTF8);
		}
		if (this.nameValueCollection_0.Count == 0)
		{
			this.bool_1 = true;
		}
		if (this.nameValueCollection_0["action"] != null)
		{
			this.string_0 = this.nameValueCollection_0["action"].Trim().ToLower();
		}
		if (this.nameValueCollection_0["time"] != null)
		{
			this.int_0 = Utils.StringToInt(this.nameValueCollection_0["time"].Trim().ToLower());
		}
		if (Utils.UnixTimestamp() - this.int_0 > 3600)
		{
			this.bool_0 = true;
		}
		Utils.Log(this.stringBuilder_0.ToString());
	}
	public string method_0()
	{
		return this.string_0;
	}
	public bool method_1()
	{
		return this.bool_0;
	}
	public bool method_2()
	{
		return !UCRequestActions.IsValidAction(this.string_0);
	}
	public bool method_3()
	{
		return this.bool_1;
	}
	public NameValueCollection method_4()
	{
		return this.nameValueCollection_0;
	}
	public int method_5()
	{
		return this.int_0;
	}
}
