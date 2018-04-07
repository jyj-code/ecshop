using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	[DefaultProperty("ScriptPath"), ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>")]
	public class Calendar : WebControl, IPostBackDataHandler, INamingContainer
	{
		protected TextBox DateTextBox = new TextBox();
		protected HtmlImage ImgHtmlImage = new HtmlImage();
		private bool bool_0 = false;
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
					result = "/images/btn_calendar.gif";
				}
				return result;
			}
			set
			{
				base.ViewState["imageurl"] = value;
				this.ImgHtmlImage.Src = value;
			}
		}
		[DefaultValue(""), Description("当前选择的日期。")]
		public DateTime SelectedDate
		{
			get
			{
				DateTime result;
				try
				{
					result = DateTime.Parse(this.DateTextBox.Text);
				}
				catch
				{
					result = Convert.ToDateTime("1900-1-1");
				}
				return result;
			}
			set
			{
				try
				{
					this.DateTextBox.Text = value.ToString("yyyy-MM-dd");
				}
				catch
				{
					this.DateTextBox.Text = "";
				}
			}
		}
		[DefaultValue(""), Description("当前输入框的值")]
		public string SelectedText
		{
			get
			{
				string result;
				try
				{
					result = this.DateTextBox.Text;
				}
				catch
				{
					result = "";
				}
				return result;
			}
			set
			{
				try
				{
					this.DateTextBox.Text = value;
				}
				catch
				{
					this.DateTextBox.Text = "";
				}
			}
		}
		[DefaultValue(true), Description("是否是只读。")]
		public bool ReadOnly
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
		[DefaultValue("./"), Description("Javascript脚本文件所在目录。")]
		public string ScriptPath
		{
			get
			{
				object obj = this.ViewState["ScriptPath"];
				return (obj == null) ? "/js/calendar.js" : ((string)obj);
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
		protected override void CreateChildControls()
		{
			if (this.ReadOnly)
			{
				this.DateTextBox.Attributes.Add("readonly", "readonly");
			}
			this.DateTextBox.Size = 8;
			this.DateTextBox.ID = this.ID;
			this.Controls.Add(this.DateTextBox);
			this.ImgHtmlImage.Src = this.ImageUrl;
			this.ImgHtmlImage.Align = "bottom";
			this.ImgHtmlImage.Attributes.Add("onclick", string.Concat(new string[]
			{
				"showcalendar(event, $('",
				this.ClientID,
				"_",
				this.ID,
				"'))"
			}));
			this.ImgHtmlImage.Attributes.Add("class", "calendarimg");
			this.Controls.Add(this.ImgHtmlImage);
			RegularExpressionValidator regularExpressionValidator = new RegularExpressionValidator();
			regularExpressionValidator.ID = regularExpressionValidator.ClientID;
			regularExpressionValidator.Display = ValidatorDisplay.Dynamic;
			regularExpressionValidator.ControlToValidate = this.DateTextBox.ID;
			regularExpressionValidator.ValidationExpression = "^((((1[6-9]|[2-9]\\d)\\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\\d|3[01]))|(((1[6-9]|[2-9]\\d)\\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\\d|30))|(((1[6-9]|[2-9]\\d)\\d{2})-0?2-(0?[1-9]|1\\d|2[0-9]))|(((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
			regularExpressionValidator.ErrorMessage = "请输入正确的日期,如:2006-1-1";
			this.Controls.Add(regularExpressionValidator);
			base.CreateChildControls();
		}
		public void AddAttributes(string string_3, string valuestr)
		{
			this.DateTextBox.Attributes.Add(string_3, valuestr);
		}
		protected override void OnPreRender(EventArgs eventArgs_0)
		{
			if (!this.Page.ClientScript.IsClientScriptBlockRegistered("CalendarSet"))
			{
				this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "CalendarSet", string.Format("<SCRIPT language='javascript' src='{0}'></SCRIPT>", this.ScriptPath));
			}
			base.OnPreRender(eventArgs_0);
		}
		public void RaisePostDataChangedEvent()
		{
		}
		public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			string text = this.DateTextBox.Text;
			string text2 = postCollection[postDataKey];
			bool result;
			if (!text.Equals(text2))
			{
				this.DateTextBox.Text = text2;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
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
		}
	}
}
