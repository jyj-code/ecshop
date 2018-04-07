using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
namespace ShopNum1.Control
{
	[ToolboxData("<{0}:SpanTimer runat=server></{0}:SpanTimer>")]
	public class SpanTimer : System.Web.UI.Control, IPostBackDataHandler
	{
		[Bindable(true), Category("Appearance"), DefaultValue(""), Localizable(true)]
		public string EndTime
		{
			get
			{
				string result;
				if (this.ViewState["EndTime"] == null)
				{
					result = "";
				}
				else
				{
					result = (string)this.ViewState["EndTime"];
				}
				return result;
			}
			set
			{
				this.ViewState["EndTime"] = value;
			}
		}
		protected override void OnPreRender(EventArgs eventArgs_0)
		{
			base.OnPreRender(eventArgs_0);
		}
		protected override void Render(HtmlTextWriter output)
		{
			string text = "\n";
			text += "<span style=\"color:#FF0000\" id=\"djs\"> </span>\n";
			text += "<script type=\"text/javascript\">\n";
			text += "    function show_date_time()";
			text += "    {\n";
			text += "        window.setTimeout(\"show_date_time()\", 1000);\n";
			text = text + "        BirthDay = new Date(\"" + this.EndTime + "\");\n";
			text += "         today = new Date();\n";
			text += "         timeold = (BirthDay.getTime() - today.getTime());\n";
			text += "        sectimeold = timeold/1000;\n";
			text += "        secondsold = Math.floor(sectimeold); \n";
			text += "        msPerDay = 24*60*60*1000; \n";
			text += "        e_daysold = timeold/msPerDay;\n";
			text += "        daysold = Math.floor(e_daysold);  \n";
			text += "        e_hrsold = (e_daysold-daysold)*24;  \n";
			text += "        hrsold = Math.floor(e_hrsold); \n";
			text += "        e_minsold = (e_hrsold-hrsold)*60; \n";
			text += "        minsold = Math.floor((e_hrsold-hrsold)*60); \n";
			text += "        seconds = Math.floor((e_minsold-minsold)*60);  \n";
			text += "        document.getElementById(\"djs\").innerHTML = daysold+\"天\"+hrsold+\"小时\"+minsold+\"分钟\"+seconds+\"秒\";  \n";
			text += "    }\n";
			text += "   show_date_time();";
			text += "</script>\n";
			output.Write(text);
		}
		public bool LoadPostData(string postDataKey, NameValueCollection values)
		{
			this.EndTime = "4/29/2009";
			return false;
		}
		public void RaisePostDataChangedEvent()
		{
		}
	}
}
