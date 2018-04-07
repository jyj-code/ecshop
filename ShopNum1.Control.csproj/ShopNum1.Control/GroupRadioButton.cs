using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Shopnum1.Control
{
	[ToolboxData("<{0}:GroupRadioButton runat=server></{0}:GroupRadioButton>")]
	public class GroupRadioButton : RadioButton, IPostBackDataHandler
	{
		private string Value
		{
			get
			{
				string text = base.Attributes["value"];
				if (text == null)
				{
					text = this.UniqueID;
				}
				else
				{
					text = this.UniqueID + "_" + text;
				}
				return text;
			}
		}
		protected override void Render(HtmlTextWriter output)
		{
			this.method_0(output);
		}
		private void method_0(HtmlTextWriter htmlTextWriter_0)
		{
			htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
			htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Type, "radio");
			htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Name, this.GroupName);
			htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Value, this.Value);
			if (this.Checked)
			{
				htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
			}
			if (!this.Enabled)
			{
				htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
			}
			string text = base.Attributes["onclick"];
			if (this.AutoPostBack)
			{
				if (text != null)
				{
					text = string.Empty;
				}
				text += this.Page.GetPostBackClientEvent(this, string.Empty);
				htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Onclick, text);
				htmlTextWriter_0.AddAttribute("language", "javascript");
			}
			else if (text != null)
			{
				htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Onclick, text);
			}
			if (this.AccessKey.Length > 0)
			{
				htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Accesskey, this.AccessKey);
			}
			if (this.TabIndex != 0)
			{
				htmlTextWriter_0.AddAttribute(HtmlTextWriterAttribute.Tabindex, this.TabIndex.ToString(NumberFormatInfo.InvariantInfo));
			}
			htmlTextWriter_0.RenderBeginTag(HtmlTextWriterTag.Input);
			htmlTextWriter_0.RenderEndTag();
		}
		void IPostBackDataHandler.RaisePostDataChangedEvent()
		{
			this.OnCheckedChanged(EventArgs.Empty);
		}
		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			bool result = false;
			string text = postCollection[this.GroupName];
			if (text != null && text == this.Value)
			{
				if (!this.Checked)
				{
					this.Checked = true;
					result = true;
				}
			}
			else if (this.Checked)
			{
				this.Checked = false;
			}
			return result;
		}
	}
}
