using ShopNum1.Common;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	[DefaultEvent("SelectedIndexChanged"), Description("ShopNum1 WebControl TabControl"), Designer(typeof(TabControlDesigner)), DesignTimeVisible(true), ParseChildren(true, "Items"), PersistChildren(false), ToolboxData("<{0}:TabControl runat=server></{0}:TabControl>")]
	public class TabControl : WebControl, IPostBackDataHandler, INamingContainer, IPostBackEventHandler
	{
		public enum HeightUnitEnum
		{
			percent,
			const_1
		}
		public enum WidthUnitEnum
		{
			percent,
			const_1
		}
		public enum SelectionModeEnum
		{
			Client,
			Server
		}
		private static readonly object object_0;
		private TabControl.HeightUnitEnum heightUnitEnum_0;
		private TabControl.WidthUnitEnum widthUnitEnum_0;
		private Unit unit_0;
		private TabPageCollection tabPageCollection_0;
		private int int_3;
		private TabControl.SelectionModeEnum selectionModeEnum_0;
		private Unit unit_1;
		private HtmlInputHidden htmlInputHidden_0;
		public event EventHandler TabSelectedIndexChanged
		{
			add
			{
				base.Events.AddHandler(TabControl.object_0, value);
			}
			remove
			{
				base.Events.RemoveHandler(TabControl.object_0, value);
			}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), MergableProperty(false), PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public TabPageCollection Items
		{
			get
			{
				return this.tabPageCollection_0;
			}
		}
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SelectedIndex
		{
			get
			{
				int result;
				if (this.Items.Count <= 0)
				{
					this.int_3 = -1;
					result = -1;
				}
				else if (this.int_3 == -1)
				{
					for (int i = 0; i < this.Items.Count; i++)
					{
						if (this.Items[i].Visible && this.Items[i].UniqueID == this.SelectedTabPageID)
						{
							result = (this.int_3 = i);
							return result;
						}
					}
					this.int_3 = 0;
					result = 0;
				}
				else if (this.int_3 >= this.Items.Count)
				{
					this.int_3 = 0;
					result = 0;
				}
				else
				{
					result = this.int_3;
				}
				return result;
			}
			set
			{
				if (value < -1 || value >= this.Items.Count)
				{
					throw new ArgumentOutOfRangeException("选项页必须小于" + this.Items.Count.ToString());
				}
				this.int_3 = value;
			}
		}
		protected string SelectedTabPageID
		{
			get
			{
				string result;
				if (this.ViewState["SelectedTabPageID"] != null)
				{
					result = (string)this.ViewState["SelectedTabPageID"];
				}
				else
				{
					result = string.Empty;
				}
				return result;
			}
			set
			{
				this.ViewState["SelectedTabPageID"] = value;
			}
		}
		[DefaultValue("./"), Description("Javascript脚本文件所在目录。")]
		public string TabScriptPath
		{
			get
			{
				object obj = this.ViewState["TabScriptPath"];
				return (obj == null) ? "../js/tabstrip.js" : ((string)obj);
			}
			set
			{
				this.ViewState["TabScriptPath"] = value;
			}
		}
		[DefaultValue("./"), Description("css文件所在目录。")]
		public string TabCssPath
		{
			get
			{
				object obj = this.ViewState["TabCssPath"];
				return (obj == null) ? "../styles/tab.css" : ((string)obj);
			}
			set
			{
				this.ViewState["TabCssPath"] = value;
			}
		}
		[DefaultValue(0), Description("顶部属性页标题距左边偏移量")]
		public int LeftOffSetX
		{
			get
			{
				object obj = this.ViewState["LeftOffSetX"];
				return (obj == null) ? 0 : Utils.StrToInt(obj.ToString(), 0);
			}
			set
			{
				this.ViewState["LeftOffSetX"] = value;
			}
		}
		public TabControl.SelectionModeEnum SelectionMode
		{
			get
			{
				return this.selectionModeEnum_0;
			}
			set
			{
				this.selectionModeEnum_0 = value;
			}
		}
		public TabControl.HeightUnitEnum HeightUnitMode
		{
			get
			{
				return this.heightUnitEnum_0;
			}
			set
			{
				this.heightUnitEnum_0 = value;
			}
		}
		public TabControl.WidthUnitEnum WidthUnitMode
		{
			get
			{
				return this.widthUnitEnum_0;
			}
			set
			{
				this.widthUnitEnum_0 = value;
			}
		}
		static TabControl()
		{
			TabControl.object_0 = new object();
		}
		public TabControl()
		{
			this.htmlInputHidden_0 = new HtmlInputHidden();
			this.int_3 = -1;
			this.htmlInputHidden_0.Value = string.Empty;
			this.unit_1 = Unit.Pixel(350);
			this.unit_0 = Unit.Pixel(150);
			this.tabPageCollection_0 = new TabPageCollection(this);
			this.selectionModeEnum_0 = TabControl.SelectionModeEnum.Client;
			this.Height = Unit.Pixel(100);
			this.Width = Unit.Pixel(100);
			this.heightUnitEnum_0 = TabControl.HeightUnitEnum.percent;
			this.widthUnitEnum_0 = TabControl.WidthUnitEnum.percent;
			this.LeftOffSetX = 0;
		}
		protected override void AddParsedSubObject(object parsedObj)
		{
			if (parsedObj is TabPage)
			{
				this.Items.Add((TabPage)parsedObj);
			}
		}
		protected override void CreateChildControls()
		{
			this.CreateControlCollection();
			this.htmlInputHidden_0.ID = this.UniqueID;
			for (int i = 0; i < this.Items.Count; i++)
			{
				this.Controls.Add(this.Items[i]);
			}
			base.ChildControlsCreated = true;
			base.CreateChildControls();
		}
		protected override void OnPreRender(EventArgs args)
		{
			base.OnPreRender(args);
			int selectedIndex = this.SelectedIndex;
			if (selectedIndex != -1)
			{
				this.Items[selectedIndex].Selected = true;
				this.htmlInputHidden_0.Value = this.Items[selectedIndex].UniqueID;
			}
			else
			{
				this.htmlInputHidden_0.Value = string.Empty;
			}
			string script = string.Format("<SCRIPT language=\"javascript\" src=\"{0}\"></SCRIPT>\r\n<LINK href=\"{1}\" type=\"text/css\" rel=\"stylesheet\">\r\n", this.TabScriptPath, this.TabCssPath);
			if (!this.Page.ClientScript.IsClientScriptBlockRegistered("TabWindow"))
			{
				this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "TabWindow", script);
			}
			base.OnPreRender(args);
		}
		protected void OnTabSelectedIndexChanged(EventArgs eventArgs_0)
		{
			if (base.Events != null)
			{
				EventHandler eventHandler = (EventHandler)base.Events[TabControl.object_0];
				if (eventHandler != null)
				{
					eventHandler(this, eventArgs_0);
				}
			}
		}
		protected override void Render(HtmlTextWriter pOutPut)
		{
			if (this.LeftOffSetX > 0)
			{
				pOutPut.Write(string.Concat(new object[]
				{
					"<div Class=\"tabs\" ID=\"",
					this.UniqueID,
					"_Tab\" style=\"padding-left:",
					this.LeftOffSetX,
					";\">"
				}));
			}
			else
			{
				pOutPut.Write("<div Class=\"tabs\" ID=\"" + this.UniqueID + "_Tab\" >");
			}
			this.htmlInputHidden_0.RenderControl(pOutPut);
			pOutPut.Write("<ul>");
			this.method_1(pOutPut);
			pOutPut.Write("</ul></div><div id=\"" + this.UniqueID + "tabarea\" class=\"tabarea\">");
			this.method_2(pOutPut);
			pOutPut.Write("</div>");
		}
		internal void method_0(HtmlTextWriter htmlTextWriter_0)
		{
			this.Render(htmlTextWriter_0);
		}
		private void method_1(HtmlTextWriter htmlTextWriter_0)
		{
			if (this.SelectionMode == TabControl.SelectionModeEnum.Server)
			{
				for (int i = 0; i < this.Items.Count; i++)
				{
					if (this.Items[i].Selected)
					{
						htmlTextWriter_0.Write("<li class=\"CurrentTabSelect\" ><a href=\"#\" class=\"current\" onfocus=\"this.blur();\">" + this.Items[i].Caption + "</a></li>");
					}
					else
					{
						htmlTextWriter_0.Write(string.Concat(new string[]
						{
							"<li class=\"TabSelect\" onmouseover=\"tabpage_mouseover(this)\" onmouseout=\"tabpage_mouseout(this)\" onClick=\"tabpage_selectonserver(this,'",
							this.Items[i].UniqueID,
							"');",
							this.Page.ClientScript.GetPostBackEventReference(this, ""),
							"\"><a href=\"#\" onfocus=\"this.blur();\">",
							this.Items[i].Caption,
							"</a></li>"
						}));
					}
				}
			}
			else
			{
				for (int i = 0; i < this.Items.Count; i++)
				{
					if (this.Items[i].Selected)
					{
						htmlTextWriter_0.Write(string.Concat(new string[]
						{
							"<li id=\"",
							this.Items[i].UniqueID,
							"_li\" class=\"CurrentTabSelect\" onclick=\"tabpage_selectonclient(this,'",
							this.Items[i].UniqueID,
							"');\"><a href=\"#\" class=\"current\" onfocus=\"this.blur();\">",
							this.Items[i].Caption,
							"</a></li>"
						}));
					}
					else
					{
						htmlTextWriter_0.Write(string.Concat(new string[]
						{
							"<li id=\"",
							this.Items[i].UniqueID,
							"_li\" class=\"TabSelect\" onmouseover=\"tabpage_mouseover(this)\" onMouseOut=\"tabpage_mouseout(this)\" onclick=\"tabpage_selectonclient(this,'",
							this.Items[i].UniqueID,
							"');\"><a href=\"#\" onfocus=\"this.blur();\">",
							this.Items[i].Caption,
							"</a></li>"
						}));
					}
				}
			}
		}
		private void method_2(HtmlTextWriter htmlTextWriter_0)
		{
			for (int i = 0; i < this.Items.Count; i++)
			{
				this.Items[i].RenderControl(htmlTextWriter_0);
			}
		}
		bool IPostBackDataHandler.LoadPostData(string ControlDataKey, NameValueCollection PostBackDataCollection)
		{
			string text = PostBackDataCollection[ControlDataKey];
			bool result;
			if (text != null && text != this.SelectedTabPageID)
			{
				this.SelectedTabPageID = text;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		void IPostBackDataHandler.RaisePostDataChangedEvent()
		{
			this.OnTabSelectedIndexChanged(EventArgs.Empty);
		}
		void IPostBackEventHandler.RaisePostBackEvent(string pEventArgument)
		{
		}
		public void InitTabPage()
		{
			this.CreateChildControls();
		}
	}
}
