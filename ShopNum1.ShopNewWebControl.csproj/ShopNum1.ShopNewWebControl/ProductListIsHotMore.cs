using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class ProductListIsHotMore : BaseWebControl
	{
		private string string_0 = "ProductListIsHotMoreNew.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private Label label_1;
		private Label label_2;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private ImageButton imageButton_0;
		private ImageButton imageButton_1;
		private Panel panel_0;
		private int int_0;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private LinkButton linkButton_4;
		private LinkButton linkButton_5;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private HtmlGenericControl htmlGenericControl_4;
		private string string_1 = GetPageName.AgentGetPage("");
		private int int_1;
		[CompilerGenerated]
		private int int_2;
		[CompilerGenerated]
		private int int_3;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public int ShowCount
		{
			get;
			set;
		}
		public int PageCount
		{
			get;
			set;
		}
		public string MemLoginID
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
		public ProductListIsHotMore()
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
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.label_1 = (Label)skin.FindControl("LabelCurrent");
			this.label_2 = (Label)skin.FindControl("LabelTotal");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonPrevPage");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonNextPage");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
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
			this.ordername = ((this.Page.Request.QueryString["ordername"] == null) ? "guid" : this.Page.Request.QueryString["ordername"].ToString());
			this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "desc" : this.Page.Request.QueryString["sort"].ToString());
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.imageButton_0 = (ImageButton)skin.FindControl("ImageButtonList");
			this.imageButton_1 = (ImageButton)skin.FindControl("ImageButtonGrid");
			this.imageButton_1.Click += new ImageClickEventHandler(this.ImageButtonGrid_Click);
			this.imageButton_0.Click += new ImageClickEventHandler(this.ImageButtonList_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterDataGrid");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterDataList");
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.repeater_0_ItemCommand);
			this.ViewState["ShowStyle"] = "Grid";
			this.ViewState["SortStyle"] = "ishot";
			this.method_1();
			this.method_0(this.ordername, this.soft);
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new object[]
			{
				this.string_1,
				"?sort=",
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
				"?sort=",
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
				this.ordername = "shopprice";
				this.soft = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?sort=",
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
				this.ordername = "salenumber";
				this.soft = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?sort=",
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
				"?sort=",
				this.soft,
				"&ordername=",
				this.ordername
			}));
		}
		private void linkButton_4_Click(object sender, EventArgs e)
		{
			if (this.ordername == "createtime")
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
				this.ordername = "createtime";
				this.soft = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?sort=",
				this.soft,
				"&ordername=",
				this.ordername
			}));
		}
		private void method_0(string string_5, string string_6)
		{
			string_5 = string_5.ToLower();
			if (this.soft == "desc")
			{
				if (string_5 == "shopprice")
				{
					this.linkButton_5.CssClass = "as_rise as_down";
					this.htmlGenericControl_4.Attributes.Add("class", "comSort-d");
				}
				if (string_5 == "salenumber")
				{
					this.linkButton_3.CssClass = "as_rise as_down";
					this.htmlGenericControl_2.Attributes.Add("class", "comSort-d");
				}
				if (string_5 == "collectcount")
				{
					this.linkButton_2.CssClass = "as_rise as_down";
					this.htmlGenericControl_1.Attributes.Add("class", "comSort-d");
				}
				if (string_5 == "createtime")
				{
					this.linkButton_4.CssClass = "as_rise as_down";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-d");
				}
			}
			else
			{
				if (string_5 == "shopprice")
				{
					this.linkButton_5.CssClass = "as_rise as_down";
					this.htmlGenericControl_4.Attributes.Add("class", "comSort-d");
				}
				if (string_5 == "salenumber")
				{
					this.linkButton_3.CssClass = "as_rise as_down";
					this.htmlGenericControl_2.Attributes.Add("class", "comSort-d");
				}
				if (string_5 == "collectcount")
				{
					this.linkButton_2.CssClass = "as_rise as_down";
					this.htmlGenericControl_1.Attributes.Add("class", "comSort-d");
				}
				if (string_5 == "shopreputation")
				{
					this.linkButton_4.CssClass = "as_rise as_down";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-d");
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(this.textBox_0.Text.Trim());
			if (num > this.int_0)
			{
				num = this.int_0;
			}
			this.Page.Response.Redirect(string.Concat(new object[]
			{
				this.string_1,
				"?sort=",
				this.soft,
				"&ordername=",
				this.ordername,
				"&pageid=",
				num
			}));
		}
		private void repeater_0_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "BtnProductCollect")
			{
				Literal literal = (Literal)e.Item.FindControl("LiteralMemLoginID");
				Literal literal2 = (Literal)e.Item.FindControl("LiteralShopPrice");
				string text = literal2.Text;
				Literal literal3 = (Literal)e.Item.FindControl("LiteralProductName");
				string text2 = literal3.Text;
				Literal literal4 = (Literal)e.Item.FindControl("LiteralShopName");
				string text3 = literal4.Text;
				Literal literal5 = (Literal)e.Item.FindControl("LiteralProductGuid");
				string text4 = literal5.Text;
				string isAttention = "0";
				if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
				{
					HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
					HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
					string text5 = httpCookie.Values["MemLoginID"].ToString();
					Shop_Collect_Action shop_Collect_Action = (Shop_Collect_Action)LogicFactory.CreateShop_Collect_Action();
					if (literal.Text == text5)
					{
						MessageBox.Show("您不能收藏自己的商品！");
					}
					else if (shop_Collect_Action.AddProductCollect(text5, text4, text3, isAttention, text, text2, literal.Text) > 0)
					{
						MessageBox.Show("收藏成功!");
						shop_Collect_Action.ProductCollectNum(text4);
					}
					else
					{
						MessageBox.Show("已收藏过该商品!");
					}
				}
				else
				{
					GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再收藏！");
				}
			}
		}
		public void ImageButtonGrid_Click(object sender, ImageClickEventArgs e)
		{
			this.ViewState["ShowStyle"] = "Grid";
			this.method_1();
			this.imageButton_0.ImageUrl = "../Images/tabulat.png";
			this.imageButton_1.ImageUrl = "../Images/large_bg.png";
		}
		public void ImageButtonList_Click(object sender, ImageClickEventArgs e)
		{
			this.ViewState["ShowStyle"] = "List";
			this.method_1();
			this.imageButton_0.ImageUrl = "../Images/display_mode_list_act.gif";
			this.imageButton_1.ImageUrl = "../Images/display_mode_grid.gif";
		}
		private void method_1()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_1;
			DataSet isProductNewAndRecommend = shop_Product_Action.GetIsProductNewAndRecommend("-1", "1", "-1", "-1", this.ordername, this.MemLoginID, this.soft, this.ShowCount.ToString(), this.int_1.ToString(), "1");
			if (isProductNewAndRecommend != null && isProductNewAndRecommend.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(isProductNewAndRecommend.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("ProductListHot", true);
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_0.Text = (this.label_1.Text = this.int_1.ToString());
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = (this.label_2.Text = pageList.PageCount.ToString());
			this.int_0 = pageList.PageCount;
			if (this.int_1 + pageList.PageCount == 2)
			{
				this.linkButton_0.Enabled = false;
				this.linkButton_1.Enabled = false;
				this.linkButton_0.CssClass = "pgup pgnext";
				this.linkButton_1.CssClass = "pgup pgnext";
			}
			else if (this.int_1 == pageList.PageCount)
			{
				this.linkButton_0.Enabled = true;
				this.linkButton_1.Enabled = false;
				this.linkButton_1.CssClass = "pgup pgnext";
			}
			else
			{
				this.linkButton_0.Enabled = false;
				this.linkButton_0.CssClass = "pgup pgnext";
				this.linkButton_1.Enabled = true;
			}
			DataSet isProductNewAndRecommend2 = shop_Product_Action.GetIsProductNewAndRecommend("-1", "1", "-1", "-1", this.ordername, this.MemLoginID, this.soft, this.ShowCount.ToString(), this.int_1.ToString(), "0");
			if (isProductNewAndRecommend2.Tables[0] == null || isProductNewAndRecommend2.Tables[0].Rows.Count == 0)
			{
				this.panel_0.Visible = true;
			}
			else if (this.ViewState["ShowStyle"].ToString().ToLower() == "Grid".ToLower())
			{
				this.repeater_1.Visible = false;
				this.repeater_0.Visible = true;
				this.repeater_0.DataSource = isProductNewAndRecommend2.Tables[0];
				this.repeater_0.DataBind();
			}
			else if (this.ViewState["ShowStyle"].ToString().ToLower() == "List".ToLower())
			{
				this.repeater_0.Visible = false;
				this.repeater_1.Visible = true;
				this.repeater_1.DataSource = isProductNewAndRecommend2.Tables[0];
				this.repeater_1.DataBind();
			}
		}
	}
}
