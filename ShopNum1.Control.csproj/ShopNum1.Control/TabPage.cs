using System;
using System.ComponentModel;
using System.Web.UI;
namespace ShopNum1.Control
{
	[ToolboxItem(false), ParseChildren(false), PersistChildren(true)]
	public class TabPage : WebControl, INamingContainer
	{
		private string string_3;
		private TabControl tabControl_0;
		private string string_4;
		private string string_5;
		private bool bool_0;
		[Browsable(true), Description(""), NotifyParentProperty(true)]
		private string ActionLink
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		[Browsable(true), Description(""), NotifyParentProperty(true)]
		public string Caption
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		internal bool Selected
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
		public TabPage()
		{
			this.bool_0 = false;
			this.string_5 = string.Empty;
			this.string_3 = string.Empty;
			this.string_4 = string.Empty;
		}
		public object GetTabControl()
		{
			return this.tabControl_0;
		}
		protected override void Render(HtmlTextWriter pOutPut)
		{
			if (this.tabControl_0 == null || this.tabControl_0.GetType().ToString() != "Discuz.Control.TabControl")
			{
				throw new ArgumentException("ShopNum1.TabPage 必须是 ShopNum1.TabControl 的子控件");
			}
			if (this.Selected)
			{
				pOutPut.Write(string.Concat(new object[]
				{
					"<div id=\"",
					this.UniqueID,
					"\" class=\"tab-page\" style=\"display: block;background: #fff;\">"
				}));
			}
			else
			{
				pOutPut.Write(string.Concat(new object[]
				{
					"<div id=\"",
					this.UniqueID,
					"\" class=\"tab-page\" style=\"display: none;background: #fff;\">"
				}));
			}
			this.RenderChildren(pOutPut);
			pOutPut.Write("</div>");
		}
		internal void method_0(HtmlTextWriter htmlTextWriter_0)
		{
			this.Render(htmlTextWriter_0);
		}
		internal void method_1(TabControl tabControl_1)
		{
			this.tabControl_0 = tabControl_1;
		}
	}
}
