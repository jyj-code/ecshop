using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
namespace ShopNum1.Control
{
	[DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:Button runat=server></{0}:Button>")]
	public class Button : WebControl, IPostBackEventHandler
	{
		public enum ButtonType
		{
			Normal,
			WithImage
		}
		protected static readonly object EventClick;
		private string string_3 = "";
		private bool bool_0 = true;
		private bool bool_1 = true;
		private bool bool_2 = false;
		public event EventHandler Click
		{
			add
			{
				base.Events.AddHandler(Button.EventClick, value);
			}
			remove
			{
				base.Events.RemoveHandler(Button.EventClick, value);
			}
		}
		public string OnClientClick
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = (value.EndsWith(";") ? value : (value + ";"));
			}
		}
		public virtual string PostBackUrl
		{
			get
			{
				string text = (string)this.ViewState["PostBackUrl"];
				string result;
				if (text != null)
				{
					result = text;
				}
				else
				{
					result = string.Empty;
				}
				return result;
			}
			set
			{
				this.ViewState["PostBackUrl"] = value;
			}
		}
		public bool AutoPostBack
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
		public bool ShowPostDiv
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}
		public bool ValidateForm
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}
		public Button.ButtonType ButtontypeMode
		{
			get
			{
				object obj = this.ViewState["ButtontypeMode"];
				return (obj == null) ? Button.ButtonType.WithImage : ((Button.ButtonType)obj);
			}
			set
			{
				this.ViewState["ButtontypeMode"] = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue(" 提 交 ")]
		public string Text
		{
			get
			{
				object obj = this.ViewState["ButtonText"];
				return (obj == null) ? " 提 交 " : ((string)obj);
			}
			set
			{
				this.ViewState["ButtonText"] = value;
			}
		}
		[DefaultValue("../images/submit.gif"), Description("图版按钮链接")]
		public string ButtonImgUrl
		{
			get
			{
				object obj = this.ViewState["ButtonImgUrl"];
				return (obj == null) ? "../images/submit.gif" : ((string)obj);
			}
			set
			{
				this.ViewState["ButtonImgUrl"] = value;
			}
		}
		[DefaultValue("../images/"), Description("图版按钮链接")]
		public string XpBGImgFilePath
		{
			get
			{
				object obj = this.ViewState["XpBGImgFilePath"];
				return (obj == null) ? "../images/" : ((string)obj);
			}
			set
			{
				this.ViewState["XpBGImgFilePath"] = value;
			}
		}
		[DefaultValue("../images/"), Description("图版按钮链接")]
		public string ScriptContent
		{
			get
			{
				object obj = this.ViewState["ScriptContent"];
				return (obj == null) ? "" : ((string)obj);
			}
			set
			{
				this.ViewState["ScriptContent"] = value;
			}
		}
		static Button()
		{
			Button.EventClick = new object();
			Button.EventClick = new object();
		}
		public Button()
		{
			this.ButtontypeMode = Button.ButtonType.WithImage;
		}
		protected virtual void OnClick(EventArgs eventArgs_0)
		{
			EventHandler eventHandler = (EventHandler)base.Events[Button.EventClick];
			if (eventHandler != null)
			{
				eventHandler(this, eventArgs_0);
			}
		}
		public void RaisePostBackEvent(string eventArgument)
		{
			this.OnClick(new EventArgs());
		}
		void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
		{
			this.RaisePostBackEvent(eventArgument);
		}
		protected override void OnPreRender(EventArgs eventArgs_0)
		{
			base.OnPreRender(eventArgs_0);
		}
		protected override void LoadViewState(object savedState)
		{
			if (savedState != null)
			{
				base.LoadViewState(savedState);
				string text = (string)this.ViewState["Text"];
				if (text != null)
				{
					this.Text = text;
				}
			}
		}
		protected override void AddParsedSubObject(object object_0)
		{
			if (this.HasControls())
			{
				base.AddParsedSubObject(object_0);
			}
			else if (object_0 is LiteralControl)
			{
				this.Text = ((LiteralControl)object_0).Text;
			}
			else
			{
				string text = this.Text;
				if (text.Length != 0)
				{
					this.Text = string.Empty;
					base.AddParsedSubObject(new LiteralControl(text));
				}
				base.AddParsedSubObject(object_0);
			}
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
			string text = "";
			if (!this.Enabled)
			{
				text = " disabled=\"true\"";
			}
			if (this.AutoPostBack)
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (!string.IsNullOrEmpty(this.OnClientClick))
				{
					stringBuilder.Append(this.OnClientClick);
				}
				stringBuilder.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate() == false) { return false; }}");
				stringBuilder.Append("this.disabled=true;");
				if (this.ValidateForm)
				{
					stringBuilder.Append("if(validate(this.form)){");
					if (this.ShowPostDiv)
					{
						stringBuilder.Append("document.getElementById('success').style.display = 'block';HideOverSels('success');");
					}
					stringBuilder.Append(this.Page.ClientScript.GetPostBackEventReference(this, "") + ";}else{this.disabled=false;}");
				}
				else
				{
					stringBuilder.Append(this.Page.ClientScript.GetPostBackEventReference(this, "") + ";");
				}
				if (this.ScriptContent != "")
				{
					stringBuilder.Append(this.ScriptContent);
				}
				if (this.ButtontypeMode == Button.ButtonType.Normal)
				{
					output.Write(string.Concat(new string[]
					{
						"<span><button type=\"button\" class=\"ManagerButton\" id=\"",
						this.UniqueID,
						"\"",
						text,
						" onclick=\"",
						stringBuilder.ToString(),
						"\">",
						this.Text,
						"</button></span>"
					}));
				}
				if (this.ButtontypeMode == Button.ButtonType.WithImage)
				{
					output.Write(string.Concat(new string[]
					{
						"<span><button type=\"button\" class=\"ManagerButton\" id=\"",
						this.UniqueID,
						"\"",
						text,
						" onclick=\"",
						stringBuilder.ToString(),
						"\"><img src=\"",
						this.ButtonImgUrl,
						"\"/>",
						this.Text,
						"</button></span>"
					}));
				}
			}
			else
			{
				if (this.ButtontypeMode == Button.ButtonType.Normal)
				{
					output.Write(string.Concat(new string[]
					{
						"<span><button type=\"button\" class=\"ManagerButton\" id=\"",
						this.UniqueID,
						"\"",
						text,
						" onclick=\"",
						this.OnClientClick,
						this.ScriptContent,
						"\">",
						this.Text,
						"</button></span>"
					}));
				}
				if (this.ButtontypeMode == Button.ButtonType.WithImage)
				{
					output.Write(string.Concat(new string[]
					{
						"<span><button type=\"button\" class=\"ManagerButton\" id=\"",
						this.UniqueID,
						"\"",
						text,
						" onclick=\"",
						this.OnClientClick,
						this.ScriptContent,
						"\"><img src=\"",
						this.ButtonImgUrl,
						"\"/>",
						this.Text,
						"</button></span>"
					}));
				}
			}
			if (base.HintInfo != "")
			{
				output.WriteEndTag("span");
			}
		}
	}
}
