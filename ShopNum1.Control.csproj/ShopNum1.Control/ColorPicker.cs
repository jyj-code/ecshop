using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.Control
{
	[DefaultProperty("ScriptPath"), ToolboxData("<{0}:ColorPicker runat=server></{0}:ColorPicker>")]
	public class ColorPicker : WebControl, IPostBackDataHandler, INamingContainer
	{
		protected TextBox ColorTextBox = new TextBox();
		protected HtmlImage ImgHtmlImage = new HtmlImage();
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string ImageUrl
		{
			get
			{
				string result;
				if (base.ViewState["imageurl"] != null)
				{
					result = (string)base.ViewState["imageurl"];
				}
				else
				{
					result = "/images/colorpicker.gif";
				}
				return result;
			}
			set
			{
				base.ViewState["imageurl"] = value;
				this.ImgHtmlImage.Src = value;
			}
		}
		[DefaultValue(""), Description("当前选择的颜色值")]
		public string Text
		{
			get
			{
				return this.ColorTextBox.Text;
			}
			set
			{
				this.ColorTextBox.Text = value.Trim();
			}
		}
		[DefaultValue(true), Description("是否是只读")]
		public bool ReadOnly
		{
			get
			{
				return Environment.Version.Major == 1 && this.ColorTextBox.ReadOnly;
			}
			set
			{
				if (Environment.Version.Major == 1)
				{
					this.ColorTextBox.ReadOnly = value;
				}
			}
		}
		[DefaultValue("./"), Description("Javascript脚本文件所在目录。")]
		public string ScriptPath
		{
			get
			{
				object obj = this.ViewState["ScriptPath"];
				return (obj == null) ? "/js/colorpicker.js" : ((string)obj);
			}
			set
			{
				this.ViewState["ScriptPath"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("边框的样式。"), TypeConverter(typeof(BorderStyleConverter))]
		public new string BorderStyle
		{
			get
			{
				object obj = this.ViewState["BorderStyle"];
				return (obj == null) ? "solid" : ((string)obj);
			}
			set
			{
				this.ViewState["BorderStyle"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("边框的宽度。")]
		public new string BorderWidth
		{
			get
			{
				object obj = this.ViewState["BorderWidth"];
				return (obj == null) ? "1" : ((string)obj);
			}
			set
			{
				this.ViewState["BorderWidth"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("边框的颜色。")]
		public override Color BorderColor
		{
			get
			{
				object obj = this.ViewState["BorderColor"];
				return (obj == null) ? Color.FromArgb(153, 153, 153) : ((Color)obj);
			}
			set
			{
				this.ViewState["BorderColor"] = value;
			}
		}
		[Category("Appearance"), DefaultValue(""), Description("CSS文件路径。")]
		public string Css_Path
		{
			get
			{
				object obj = this.ViewState["ColorPickerCssPath"];
				return (obj == null) ? "/css/colorpicker.css" : ((string)obj);
			}
			set
			{
				this.ViewState["ColorPickerCssPath"] = value;
			}
		}
		[DefaultValue(0), Description("向上偏移量")]
		public float TopOffSet
		{
			get
			{
				object obj = this.ViewState["TopOffSet"];
				return (obj == null) ? 0f : ((float)obj);
			}
			set
			{
				this.ViewState["TopOffSet"] = value;
			}
		}
		[DefaultValue(0), Description("向左偏移量")]
		public float LeftOffSet
		{
			get
			{
				object obj = this.ViewState["LeftOffSet"];
				return (obj == null) ? 0f : ((float)obj);
			}
			set
			{
				this.ViewState["LeftOffSet"] = value;
			}
		}
		protected override void CreateChildControls()
		{
			this.ColorTextBox.Size = 8;
			this.ColorTextBox.ID = this.ID;
			this.Controls.Add(this.ColorTextBox);
			this.ImgHtmlImage.ID = "ColorPreview";
			this.ImgHtmlImage.Src = this.ImageUrl;
			this.ImgHtmlImage.Attributes.Add("onclick", string.Concat(new object[]
			{
				"IsShowColorPanel('",
				this.ColorTextBox.ClientID,
				"','",
				this.ImgHtmlImage.ClientID,
				"',",
				this.LeftOffSet,
				",",
				this.TopOffSet,
				")"
			}));
			this.ImgHtmlImage.Attributes.Add("class", "img");
			this.ImgHtmlImage.Attributes.Add("title", "选择颜色");
			this.Controls.Add(this.ImgHtmlImage);
			base.CreateChildControls();
		}
		public void AddAttributes(string string_3, string valuestr)
		{
			this.ColorTextBox.Attributes.Add(string_3, valuestr);
		}
		protected override void OnPreRender(EventArgs eventArgs_0)
		{
			string script = string.Format("<link href=\"{0}\" type=\"text/css\" rel=\"stylesheet\">\r\n<script language=\"javascript\" src=\"{1}\"></script>\r\n", this.Css_Path, this.ScriptPath);
			if (!this.Page.ClientScript.IsClientScriptBlockRegistered("ColorPickerSet"))
			{
				this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "ColorPickerSet", script);
			}
			base.OnPreRender(eventArgs_0);
		}
		public void RaisePostDataChangedEvent()
		{
		}
		public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			string text = this.ColorTextBox.Text;
			string text2 = postCollection[postDataKey];
			bool result;
			if (!text.Equals(text2))
			{
				this.ColorTextBox.Text = text2;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public string ColorPickHtmlContent()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<span id=\"ColorPicker{0}\" style=\"display:none; position:absolute;z-index:500;\" onmouseout=\"HideColorPanel('{0}');\"  onmouseover=\"ShowColorPanel('{0}','{1}',{2},{3});\">");
			stringBuilder.Append("<div  style=\"display:block;cursor:crosshair;z-index:501\" class=\"article\" >");
			stringBuilder.Append("<table border=0 cellPadding=0 cellSpacing=10 onmouseover=\"ShowColorPanel('{0}','{1}',{2},{3});\">");
			stringBuilder.Append("<tbody>");
			stringBuilder.Append("<tr>");
			stringBuilder.Append("<script language=\"javaScript\">");
			stringBuilder.Append("WriteColorPanel('{0}','{1}',{2},{3});");
			stringBuilder.Append("</script>");
			stringBuilder.Append("</tr></tbody></table>");
			stringBuilder.Append("<table style=\"font-size:12px;word-break:break-all;width:100%;border:0px\"  cellPadding=0 cellSpacing=10 onmouseover=\"ShowColorPanel('{0}','{1}',{2},{3});\">");
			stringBuilder.Append("<tbody>");
			stringBuilder.Append("<tr>");
			stringBuilder.Append("<td align=middle rowSpan=2>选中色彩");
			stringBuilder.Append("<table border=1 cellPadding=0 cellSpacing=0 height=30 id=ShowColor{0} width=40 bgcolor=\"\">");
			stringBuilder.Append("<tbody>");
			stringBuilder.Append("<tr>");
			stringBuilder.Append("<td></td></tr></tbody></table></td>");
			stringBuilder.Append("<td rowSpan=2>基色: <SPAN id=RGB{0}></SPAN><br />亮度: <SPAN id=GRAY{0}>120</SPAN><br />代码: <INPUT id=SelColor{0} size=7 value=\"\" border=0></TD>");
			stringBuilder.Append("<td><input type=\"button\" onclick=\"javascript:ColorPickerOK('{0}','{1}');\" value=\"确定\"></TD></TR>");
			stringBuilder.Append("<tr>");
			stringBuilder.Append("<td><input type=\"button\" onclick=\"javascript:document.getElementById('{0}').value='';document.getElementById('{1}').style.background='#FFFFFF';HideColorPanel('{0}');\" value=\"取消\"></TD>");
			stringBuilder.Append("</tr></tbody></table>");
			stringBuilder.Append("</DIV>");
			stringBuilder.Append("<iframe id=\"pickcoloriframe{0}\" style=\"position:absolute;z-index:102;top:-1px;width:250px;scrolling:no;height:237px;\" frameborder=\"0\"></iframe>");
			stringBuilder.Append("</span>");
			stringBuilder.Append("<script language=javascript>\r\n");
			stringBuilder.Append("InitColorPicker('{1}','" + this.Text + "');\r\n");
			stringBuilder.Append("</script>\r\n");
			return string.Format(stringBuilder.ToString(), new object[]
			{
				this.ColorTextBox.ClientID,
				this.ImgHtmlImage.ClientID,
				this.LeftOffSet,
				this.TopOffSet
			});
		}
		protected override void Render(HtmlTextWriter output)
		{
			if (base.HintInfo != "")
			{
				output.WriteBeginTag(string.Concat(new object[]
				{
					"span id=\"",
					this.ClientID,
					"\"  onmouseover=\"showhintinfo(this,",
					base.HintLeftOffSet,
					",",
					base.HintTopOffSet,
					",'",
					base.HintTitle,
					"','",
					base.HintInfo,
					"','",
					base.HintHeight,
					"','",
					base.HintShowType,
					"');\" onmouseout=\"hidehintinfo();\">"
				}));
			}
			this.RenderChildren(output);
			if (base.HintInfo != "")
			{
				output.WriteEndTag("span");
			}
			output.Write(this.ColorPickHtmlContent());
		}
	}
}
