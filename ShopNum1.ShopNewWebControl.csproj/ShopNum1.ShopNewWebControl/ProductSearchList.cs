using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class ProductSearchList : BaseWebControl
	{
		private string string_0 = "ProductSearchListNew.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private Button button_0;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private ImageButton imageButton_0;
		private ImageButton imageButton_1;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_3;
		private Button button_1;
		private Label label_1;
		private Label label_2;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private Label label_3;
		private Panel panel_0;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private LinkButton linkButton_4;
		private LinkButton linkButton_5;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private HtmlGenericControl htmlGenericControl_4;
		private int int_0;
		private string string_1 = GetPageName.AgentGetPage("");
		private int int_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private int int_2;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		[CompilerGenerated]
		private string string_7;
		[CompilerGenerated]
		private int int_3;
		[CompilerGenerated]
		private string string_8;
		[CompilerGenerated]
		private string string_9;
		private string ShowStype
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public int PageCount
		{
			get;
			set;
		}
		public string ProductCode
		{
			get;
			set;
		}
		public string Keywords
		{
			get;
			set;
		}
		public string PriceStart
		{
			get;
			set;
		}
		public string PriceEnd
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public string ordername
		{
			get;
			set;
		}
		public string soft
		{
			get;
			set;
		}
		public ProductSearchList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonRenqi");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonSales");
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.linkButton_4 = (LinkButton)skin.FindControl("LinkButtonCreatime");
			this.linkButton_4.Click += new EventHandler(this.linkButton_4_Click);
			this.linkButton_5 = (LinkButton)skin.FindControl("LinkButtonPrice");
			this.linkButton_5.Click += new EventHandler(this.linkButton_5_Click);
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("IRenqi");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("ISales");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("ICreatime");
			this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("IPrice");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_1 = (Button)skin.FindControl("ButtonSure");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.label_1 = (Label)skin.FindControl("LabelCurrent");
			this.label_2 = (Label)skin.FindControl("LabelTotal");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonPrevPage");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonNextPage");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.label_3 = (Label)skin.FindControl("LabelSearch");
			this.panel_0 = (Panel)skin.FindControl("PanelNoFind");
			this.int_1 = 1;
			try
			{
				this.int_1 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_1 = 1;
			}
			this.ordername = ((this.Page.Request.QueryString["ordername"] == null) ? "ModifyTime" : this.Page.Request.QueryString["ordername"].ToString());
			this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "desc" : this.Page.Request.QueryString["sort"].ToString());
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxKeywords");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxPriceStart");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxPriceEnd");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.textBox_2_TextChanged);
			this.textBox_0.TextChanged += new EventHandler(this.textBox_2_TextChanged);
			this.textBox_2.TextChanged += new EventHandler(this.textBox_2_TextChanged);
			this.imageButton_0 = (ImageButton)skin.FindControl("ImageButtonList");
			this.imageButton_1 = (ImageButton)skin.FindControl("ImageButtonGrid");
			this.imageButton_1.Click += new ImageClickEventHandler(this.ImageButtonGrid_Click);
			this.imageButton_0.Click += new ImageClickEventHandler(this.ImageButtonList_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterDataGrid");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterDataList");
			this.ShowStype = ((ShopNum1.Common.Common.ReqStr("showstyle") == "") ? "Grid" : ShopNum1.Common.Common.ReqStr("showstyle"));
			if (!this.Page.IsPostBack)
			{
				this.ViewState["ShowStyle"] = "Grid";
				this.ViewState["SortStyle"] = "ModifyTime";
			}
			if (this.Page.Request.QueryString["keywords"] != null && this.Page.Request.QueryString["keywords"].ToString() != "")
			{
				this.Keywords = this.Page.Request.QueryString["keywords"].ToString();
				this.textBox_0.Text = this.Keywords;
			}
			if (this.Page.Request.QueryString["priceStart"] != null && this.Page.Request.QueryString["priceStart"].ToString() != "")
			{
				this.PriceStart = this.Page.Request.QueryString["priceStart"].ToString();
				this.textBox_1.Text = this.PriceStart;
			}
			if (this.Page.Request.QueryString["priceEnd"] != null && this.Page.Request.QueryString["priceEnd"].ToString() != "")
			{
				this.PriceEnd = this.Page.Request.QueryString["priceEnd"].ToString();
				this.textBox_2.Text = this.PriceEnd;
			}
			if (this.Page.Request.QueryString["code"] != null && this.Page.Request.QueryString["code"].ToString() != "")
			{
				this.ProductCode = this.Page.Request.QueryString["code"].ToString();
			}
			this.method_1();
			this.method_0(this.ordername, this.soft);
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new object[]
			{
				this.string_1,
				"?showstyle=",
				this.ShowStype,
				"&keywords=",
				this.Keywords,
				"&priceStart=",
				this.PriceStart,
				"&priceEnd=",
				this.PriceEnd,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername,
				"&pageid=",
				this.int_1 + 1
			}));
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new object[]
			{
				this.string_1,
				"?showstyle=",
				this.ShowStype,
				"&keywords=",
				this.Keywords,
				"&priceStart=",
				this.PriceStart,
				"&priceEnd=",
				this.PriceEnd,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername,
				"&pageid=",
				this.int_1 - 1
			}));
		}
		private void linkButton_5_Click(object sender, EventArgs e)
		{
			if (this.ordername == "shopprice")
			{
				this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.soft == "desc" || this.soft == "")
				{
					this.soft = "asc";
				}
				else
				{
					this.soft = "desc";
				}
			}
			else
			{
				this.ordername = "shopprice";
				this.soft = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?showstyle=",
				this.ShowStype,
				"&keywords=",
				this.Keywords,
				"&priceStart=",
				this.PriceStart,
				"&priceEnd=",
				this.PriceEnd,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername
			}));
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			if (this.ordername == "salenumber")
			{
				this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.soft == "desc" || this.soft == "")
				{
					this.soft = "asc";
				}
				else
				{
					this.soft = "desc";
				}
			}
			else
			{
				this.ordername = "salenumber";
				this.soft = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?showstyle=",
				this.ShowStype,
				"&keywords=",
				this.Keywords,
				"&priceStart=",
				this.PriceStart,
				"&priceEnd=",
				this.PriceEnd,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername
			}));
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			if (this.ordername == "collectcount")
			{
				this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.soft == "asc" || this.soft == "")
				{
					this.soft = "desc";
				}
				else
				{
					this.soft = "asc";
				}
			}
			else
			{
				this.ordername = "collectcount";
				this.soft = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?showstyle=",
				this.ShowStype,
				"&keywords=",
				this.Keywords,
				"&priceStart=",
				this.PriceStart,
				"&priceEnd=",
				this.PriceEnd,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername
			}));
		}
		private void linkButton_4_Click(object sender, EventArgs e)
		{
			if (this.ordername == "modifytime")
			{
				this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.soft == "asc" || this.soft == "")
				{
					this.soft = "desc";
				}
				else
				{
					this.soft = "asc";
				}
			}
			else
			{
				this.ordername = "modifytime";
				this.soft = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?showstyle=",
				this.ShowStype,
				"&keywords=",
				this.Keywords,
				"&priceStart=",
				this.PriceStart,
				"&priceEnd=",
				this.PriceEnd,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername
			}));
		}
		private void textBox_2_TextChanged(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(GetPageName.GetPage(string.Concat(new string[]
			{
				"?showstyle=",
				this.ShowStype,
				"&keywords=",
				Operator.FilterString(this.textBox_0.Text),
				"&priceStart=",
				this.textBox_1.Text,
				"&priceEnd=",
				this.textBox_2.Text,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername
			})));
		}
		private void method_0(string string_10, string string_11)
		{
			string_10 = string_10.ToLower();
			if (this.soft == "asc" || this.soft == "")
			{
				if (string_10 == "shopprice")
				{
					this.linkButton_5.ToolTip = "价格从低到高";
					this.linkButton_5.CssClass = "as_rise";
					this.htmlGenericControl_4.Attributes.Add("class", "comSort-d");
				}
				if (string_10 == "salenumber")
				{
					this.linkButton_3.ToolTip = "销量从低到高";
					this.linkButton_3.CssClass = "as_rise";
					this.htmlGenericControl_2.Attributes.Add("class", "comSort-d");
				}
				if (string_10 == "collectcount")
				{
					this.linkButton_2.ToolTip = "人气从低到高";
					this.linkButton_2.CssClass = "as_rise";
					this.htmlGenericControl_1.Attributes.Add("class", "comSort-d");
				}
				if (string_10 == "modifytime")
				{
					this.linkButton_4.ToolTip = "时间从先到后";
					this.linkButton_4.CssClass = "as_rise";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-d");
				}
			}
			else
			{
				if (string_10 == "shopprice")
				{
					this.linkButton_5.CssClass = "as_down as_rise";
					this.htmlGenericControl_4.Attributes.Add("class", "comSort-d");
					this.linkButton_5.ToolTip = "价格从高到低";
				}
				if (string_10 == "salenumber")
				{
					this.linkButton_3.ToolTip = "销量从高到低";
					this.linkButton_3.CssClass = "as_down as_rise";
					this.htmlGenericControl_2.Attributes.Add("class", "comSort-d");
				}
				if (string_10 == "collectcount")
				{
					this.linkButton_2.ToolTip = "人气从高到低";
					this.linkButton_2.CssClass = "as_down as_rise";
					this.htmlGenericControl_1.Attributes.Add("class", "comSort-d");
				}
				if (string_10 == "modifytime")
				{
					this.linkButton_4.ToolTip = "时间从后到先";
					this.linkButton_4.CssClass = "as_down as_rise";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-d");
				}
			}
			if (this.ShowStype.ToLower() == "list")
			{
				this.imageButton_1.ImageUrl = "../Images/display_mode_grid.gif";
				this.imageButton_0.ImageUrl = "../Images/display_mode_list_act.gif";
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(this.textBox_3.Text.Trim());
			if (num > this.int_0)
			{
				num = this.int_0;
			}
			if (this.Page.Request.QueryString["code"] != null)
			{
				this.Page.Response.Redirect(string.Concat(new object[]
				{
					this.string_1,
					"?showstyle=",
					this.ShowStype,
					"&keywords=",
					this.Keywords,
					"&priceStart=",
					this.PriceStart,
					"&priceEnd=",
					this.PriceEnd,
					"&sort=",
					this.soft,
					"&ordername=",
					this.ordername,
					"&pageid=",
					num,
					"&code=",
					this.Page.Request.QueryString["code"].ToString()
				}));
			}
			else
			{
				this.Page.Response.Redirect(string.Concat(new object[]
				{
					this.string_1,
					"?showstyle=",
					this.ShowStype,
					"&keywords=",
					this.Keywords,
					"&priceStart=",
					this.PriceStart,
					"&priceEnd=",
					this.PriceEnd,
					"&sort=",
					this.soft,
					"&ordername=",
					this.ordername,
					"&pageid=",
					num
				}));
			}
		}
		public void ImageButtonGrid_Click(object sender, ImageClickEventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?showstyle=Grid&keywords=",
				this.Keywords,
				"&priceStart=",
				this.PriceStart,
				"&priceEnd=",
				this.PriceEnd,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername,
				"&pageid=1"
			}));
		}
		public void ImageButtonList_Click(object sender, ImageClickEventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?showstyle=List&keywords=",
				this.Keywords,
				"&priceStart=",
				this.PriceStart,
				"&priceEnd=",
				this.PriceEnd,
				"&sort=",
				this.soft,
				"&ordername=",
				this.ordername,
				"&pageid=1"
			}));
		}
		private void method_1()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_1;
			DataSet dataSet = shop_Product_Action.SearchProductListNew(this.MemLoginID, this.Keywords, this.PriceStart, this.PriceEnd, this.ProductCode, this.ordername, this.soft, this.ShowCount.ToString(), this.int_1.ToString(), "1");
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			this.label_3.Text = pageList.RecordCount.ToString();
			PageListBll pageListBll = new PageListBll("ProductSearchList", true);
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_3.Text = (this.label_1.Text = this.int_1.ToString());
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = (this.label_2.Text = pageList.PageCount.ToString());
			this.int_0 = pageList.PageCount;
			if (this.int_1 == pageList.PageCount)
			{
				this.linkButton_0.Enabled = true;
				this.linkButton_1.Enabled = false;
				this.linkButton_1.CssClass = "pgup pgnext";
			}
			if (this.int_1 == 1)
			{
				this.linkButton_0.Enabled = false;
				this.linkButton_0.CssClass = "pgup pgnext";
				this.linkButton_1.Enabled = true;
				if (this.int_1 == pageList.PageCount)
				{
					this.linkButton_0.Enabled = false;
					this.linkButton_1.Enabled = false;
					this.linkButton_1.CssClass = "pgup pgnext";
				}
			}
			if (pageList.RecordCount == 0 || pageList.RecordCount < pageList.PageCount)
			{
				this.linkButton_0.Enabled = false;
				this.linkButton_1.Enabled = false;
				this.linkButton_1.CssClass = "pgup pgnext";
				this.linkButton_0.CssClass = "pgup pgnext";
			}
			DataSet dataSet2 = shop_Product_Action.SearchProductListNew(this.MemLoginID, this.Keywords, this.PriceStart, this.PriceEnd, this.ProductCode, this.ordername, this.soft, this.ShowCount.ToString(), this.int_1.ToString(), "0");
			if (dataSet2.Tables[0] == null || dataSet2.Tables[0].Rows.Count == 0)
			{
				this.panel_0.Visible = true;
			}
			else if (this.ShowStype.ToLower() == "Grid".ToLower())
			{
				this.repeater_1.Visible = false;
				this.repeater_0.Visible = true;
				this.repeater_0.DataSource = dataSet2.Tables[0];
				this.repeater_0.DataBind();
			}
			else if (this.ShowStype.ToLower() == "List".ToLower())
			{
				this.repeater_0.Visible = false;
				this.repeater_1.Visible = true;
				this.repeater_1.DataSource = dataSet2.Tables[0];
				this.repeater_1.DataBind();
			}
		}
	}
}
