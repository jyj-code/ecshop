using System;
using System.Collections.Specialized;
using System.Web.UI;
public class AdminPage : Page
{
	public float m_starttick = (float)Environment.TickCount;
	public float m_processtime;
	private bool bool_0 = false;
	private NameValueCollection nameValueCollection_0 = null;
	public float Processtime
	{
		get
		{
			return this.m_processtime;
		}
	}
	private bool IsRestore
	{
		get
		{
			return base.Request.QueryString["IsRestore"] != null && base.Request.QueryString["IsRestore"] == "1" && base.Request.Form["__VIEWSTATE"] == null;
		}
	}
	private string RestoreKey
	{
		get
		{
			return base.Request.QueryString["key"];
		}
	}
	public bool SavePageState
	{
		get
		{
			return this.bool_0;
		}
		set
		{
			this.bool_0 = value;
		}
	}
	private NameValueCollection PostData
	{
		get
		{
			NameValueCollection form;
			if (this.IsRestore)
			{
				form = this.nameValueCollection_0;
			}
			else
			{
				form = base.Request.Form;
			}
			return form;
		}
	}
	protected override void OnInit(EventArgs eventArgs_0)
	{
		this.m_processtime = ((float)Environment.TickCount - this.m_starttick) / 1000f;
		base.OnInit(eventArgs_0);
	}
	public AdminPage()
	{
		if (this.Page.IsPostBack)
		{
		}
	}
	public void RegisterAdminPageClientScriptBlock()
	{
		string script = "<div id=\"success\" style=\"position:absolute;z-index:300;height:120px;width:284px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;\">\r\n\t<div id=\"Layer2\" style=\"position:absolute;z-index:300;width:270px;height:90px;background-color: #FFFFFF;border:solid #000000 1px;font-size:14px;\">\r\n\t\t<div id=\"Layer4\" style=\"height:26px;background:#f1f1f1;line-height:26px;padding:0px 3px 0px 3px;font-weight:bolder;\">操作提示</div>\r\n\t\t<div id=\"Layer5\" style=\"height:64px;line-height:150%;padding:0px 3px 0px 3px;\" align=\"center\"><BR /><table><tr><td valign=top><img border=\"0\" src=\"/Main/Admin/images/ajax_loading.gif\"  /></td><td valign=middle style=\"font-size: 14px;\" >正在执行当前操作, 请稍等...<BR /></td></tr></table><BR /></div>\r\n\t</div>\r\n\t<div id=\"Layer3\" style=\"position:absolute;width:270px;height:90px;z-index:299;left:4px;top:5px;background-color: #E8E8E8;\"></div>\r\n</div>\r\n<script> \r\ndocument.getElementById('success').style.display = \"none\"; \r\n</script> \r\n<script type=\"text/javascript\" src=\"/Main/Admin/js/divcover.js\"></script>\r\n";
		base.ClientScript.RegisterClientScriptBlock(base.GetType(), "Page", script);
	}
	public new void RegisterStartupScript(string string_0, string scriptstr)
	{
		string_0 = string_0.ToLower();
		if (string_0 == "pagetemplate" || string_0 == "page")
		{
			string script = "";
			if (string_0 == "page")
			{
				script = "<script> \r\nvar bar=0;\r\ndocument.getElementById('success').style.display = \"block\";  \r\ndocument.getElementById('Layer5').innerHTML ='<BR>操作成功执行<BR>';  \r\ncount() ; \r\nfunction count(){ \r\nbar=bar+4; \r\nif (bar<99) \r\n{setTimeout(\"count()\",100);} \r\nelse { \r\ndocument.getElementById('success').style.display = \"none\";HideOverSels('success'); \r\n" + scriptstr + "} \r\n} \r\n</script> \r\n<script> window.onload = function(){HideOverSels('success')};</script>\r\n";
			}
			if (string_0 == "pagetemplate")
			{
				script = "<script> \r\nvar bar=0;\r\n success.style.display = \"block\";  \r\ndocument.getElementById('Layer5').innerHTML = '<BR>" + scriptstr + "<BR>';  \r\ncount() ; \r\nfunction count(){ \r\nbar=bar+4; \r\nif (bar<99) \r\n{setTimeout(\"count()\",100);} \r\nelse { \r\ndocument.getElementById('success').style.display = \"none\";HideOverSels('success'); \r\n}} \r\n</script> \r\n<script> window.onload = function(){HideOverSels('success')};</script>\r\n";
			}
			base.ClientScript.RegisterStartupScript(base.GetType(), string_0, script);
		}
		else
		{
			base.ClientScript.RegisterStartupScript(base.GetType(), string_0, scriptstr);
		}
	}
	public void CallBaseRegisterStartupScript(string string_0, string scriptstr)
	{
		base.ClientScript.RegisterStartupScript(base.GetType(), string_0, scriptstr);
	}
	public void LoadRegisterStartupScript(string string_0, string scriptstr)
	{
		string text = "程序执行中... <BR /> 当前操作可能要运行一段时间.<BR />您可在此期间进行其它操作<BR /><BR />";
		string scriptstr2 = string.Concat(new string[]
		{
			"<script> \r\nvar bar=0;\r\n success.style.display = \"block\";  \r\ndocument.getElementById('Layer5').innerHTML ='",
			text,
			"';  \r\ncount() ; \r\nfunction count(){ \r\nbar=bar+2; \r\nif (bar<99) \r\n{setTimeout(\"count()\",100);} \r\nelse { \r\n\tdocument.getElementById('success').style.display = \"none\";HideOverSels('success'); \r\n",
			scriptstr,
			"} \r\n} \r\n</script> \r\n<script> window.onload = function(){HideOverSels('success')};</script>\r\n"
		});
		this.CallBaseRegisterStartupScript(string_0, scriptstr2);
	}
	protected override void OnLoad(EventArgs eventArgs_0)
	{
		//base.OnLoad(eventArgs_0);
	}
	private void method_0(string string_0, bool bool_1, string string_1)
	{
		string text = "<script type='text/javascript'>\r\nvar bar=0;\r\ndocument.getElementById('success').style.display = \"block\";\r\ndocument.getElementById('Layer5').innerHTML = '<BR>" + string_0 + "<BR>';\r\n";
		if (bool_1)
		{
			text += "count();\r\nfunction count()\r\n{\r\n\tbar=bar+4;\r\n\tif (bar<99)\r\n\t{\r\n\t\tsetTimeout(\"count()\",200);\r\n\t}\r\n\telse\r\n\t{\r\n";
			if (string_1 == "")
			{
				text += "\t\tdocument.getElementById('success').style.display = \"none\";HideOverSels('success');\r\n";
			}
			else
			{
				text = text + "\t\twindow.location='" + string_1 + "';\r\n";
			}
			text += "\t}\r\n}\r\n";
		}
		text += "</script>\r\n<script> window.onload = function(){HideOverSels('success')};</script>\r\n";
		base.ClientScript.RegisterStartupScript(base.GetType(), "resultMessage", text);
	}
	protected void RegisterMessage(string scriptstr, string autoJumpUrl)
	{
		this.method_0(scriptstr, true, autoJumpUrl);
	}
	protected void RegisterMessage(string scriptstr, bool autoHidd)
	{
		this.method_0(scriptstr, autoHidd, "");
	}
	protected void RegisterMessage(string scriptstr)
	{
		this.RegisterMessage(scriptstr, false);
	}
}