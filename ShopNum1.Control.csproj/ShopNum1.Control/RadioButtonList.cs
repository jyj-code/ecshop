using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	[DefaultProperty("Text"), ToolboxData("<{0}:RadioButtonList runat=server></{0}:RadioButtonList>")]
	public class RadioButtonList : System.Web.UI.WebControls.RadioButtonList, IPostBackDataHandler, IWebControl
	{
		private string string_0 = "";
		private string string_1 = "";
		private int int_0 = 0;
		private int int_1 = 0;
		private string string_2 = "up";
		private int int_2 = 50;
		private int int_3 = 0;
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string SetFocusButtonID
		{
			get
			{
				object obj = this.ViewState[this.ClientID + "_SetFocusButtonID"];
				return (obj == null) ? "" : obj.ToString();
			}
			set
			{
				this.ViewState[this.ClientID + "_SetFocusButtonID"] = value;
				if (value != "")
				{
					base.Attributes.Add("onChange", "document.getElementById('" + value + "').focus();");
				}
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string HintTitle
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string HintInfo
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue(0)]
		public int HintLeftOffSet
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue(0)]
		public int HintTopOffSet
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue("up")]
		public string HintShowType
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue(130)]
		public int HintHeight
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}
		[Bindable(true), Category("Appearance"), DefaultValue(0)]
		public int HintTopFirefoxOffset
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}
		public RadioButtonList()
		{
			this.BorderStyle = BorderStyle.Dotted;
			this.BorderWidth = 0;
			this.RepeatColumns = 2;
			this.RepeatDirection = RepeatDirection.Vertical;
			this.RepeatLayout = RepeatLayout.Table;
			this.CssClass = "buttonlist";
		}
		protected override void Render(HtmlTextWriter output)
		{
			if (this.HintInfo != "")
			{
				output.WriteBeginTag(string.Concat(new object[]
				{
					"span id=\"",
					this.ClientID,
					"\"  onmouseover=\"showhintinfo(this,",
					this.HintLeftOffSet,
					",",
					this.HintTopOffSet,
					",'",
					this.HintTitle,
					"','",
					this.HintInfo,
					"','",
					this.HintHeight,
					"','",
					this.HintShowType,
					"','",
					this.HintTopFirefoxOffset,
					"');\" onmouseout=\"hidehintinfo();\">"
				}));
			}
			base.Render(output);
			if (this.HintInfo != "")
			{
				output.WriteEndTag("span");
			}
		}
	}
}
