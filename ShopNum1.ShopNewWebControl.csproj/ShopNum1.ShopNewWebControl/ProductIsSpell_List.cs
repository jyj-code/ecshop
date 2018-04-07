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
	public class ProductIsSpell_List : BaseWebControl
	{
		private string string_0 = "ProductIsSpell_List.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private ImageButton imageButton_0;
		private ImageButton imageButton_1;
		private DropDownList dropDownList_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private Panel panel_0;
		private string string_1 = GetPageName.AgentGetPage("");
		private int int_0;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private int int_2;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public int PageCount
		{
			get;
			set;
		}
		public int ShowCount
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
		public ProductIsSpell_List()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.panel_0 = (Panel)skin.FindControl("PanelNoFind");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_0 = 1;
			}
			this.ordername = ((this.Page.Request.QueryString["ordername"] == null) ? "guid" : this.Page.Request.QueryString["ordername"].ToString());
			this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "desc" : this.Page.Request.QueryString["sort"].ToString());
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.imageButton_0 = (ImageButton)skin.FindControl("ImageButtonList");
			this.imageButton_1 = (ImageButton)skin.FindControl("ImageButtonGrid");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListSort");
			this.imageButton_1.Click += new ImageClickEventHandler(this.ImageButtonGrid_Click);
			this.imageButton_0.Click += new ImageClickEventHandler(this.ImageButtonList_Click);
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterDataGrid");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterDataList");
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.repeater_0_ItemCommand);
			this.ViewState["ShowStyle"] = "Grid";
			this.ViewState["SortStyle"] = "CreateTime";
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?sort=",
				this.soft,
				"&ordername=",
				this.ordername,
				"&pageid=",
				text
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
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ViewState["SortStyle"] = this.dropDownList_0.SelectedValue;
			this.method_0();
		}
		public void ImageButtonGrid_Click(object sender, ImageClickEventArgs e)
		{
			this.imageButton_1.ImageUrl = "../Images/productDisplayGrid.gif";
			this.imageButton_0.ImageUrl = "../Images/display_mode_list.gif";
			this.ViewState["ShowStyle"] = "Grid";
			this.method_0();
		}
		public void ImageButtonList_Click(object sender, ImageClickEventArgs e)
		{
			this.imageButton_1.ImageUrl = "../Images/display_mode_grid.gif";
			this.imageButton_0.ImageUrl = "../Images/display_mode_list_act.gif";
			this.ViewState["ShowStyle"] = "List";
			this.method_0();
		}
		private void method_0()
		{
			if (this.ShowCount.ToString() == "")
			{
				this.ShowCount = 10;
			}
			Shop_GroupProduct_Action shop_GroupProduct_Action = new Shop_GroupProduct_Action();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			string condition = "  and State=1 and memloginid='" + this.MemLoginID + "'";
			DataTable dataTable = shop_GroupProduct_Action.SelectGroupProduct(this.ShowCount.ToString(), this.int_0.ToString(), condition, "3", "desc", "id");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("SpellBuyList", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			if (this.int_0 > pageList.PageCount)
			{
				this.int_0 = pageList.PageCount;
			}
			DataTable dataTable2 = shop_GroupProduct_Action.SelectGroupProduct(this.ShowCount.ToString(), this.int_0.ToString(), condition, "2", "desc", "id");
			if (dataTable2.Rows.Count == 0)
			{
				this.panel_0.Visible = true;
			}
			if (this.ViewState["ShowStyle"].ToString().ToLower() == "Grid".ToLower())
			{
				this.repeater_1.Visible = false;
				this.repeater_0.Visible = true;
				this.repeater_0.DataSource = dataTable2.DefaultView;
				this.repeater_0.DataBind();
			}
			else if (this.ViewState["ShowStyle"].ToString().ToLower() == "List".ToLower())
			{
				this.repeater_0.Visible = false;
				this.repeater_1.Visible = true;
				this.repeater_1.DataSource = dataTable2.DefaultView;
				this.repeater_1.DataBind();
			}
		}
	}
}
