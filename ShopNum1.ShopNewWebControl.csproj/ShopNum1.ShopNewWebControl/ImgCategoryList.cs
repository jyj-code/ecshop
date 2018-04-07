using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class ImgCategoryList : BaseWebControl
	{
		private string string_0 = "ImgCategoryList.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private Panel panel_0;
		private string string_1 = GetPageName.AgentGetPage("");
		public static DataTable dt_Album = null;
		private string string_2 = null;
		private int int_0;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private int int_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
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
		public ImgCategoryList()
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
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_0 = 1;
			}
			this.ordername = ((this.Page.Request.QueryString["ordername"] == null) ? "id" : this.Page.Request.QueryString["ordername"].ToString());
			this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "desc" : this.Page.Request.QueryString["sort"].ToString());
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterImgCate");
			this.string_2 = ShopNum1.Common.Common.ReqStr("sort");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
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
		private void method_0()
		{
			Shop_ImageCategory_Action shop_ImageCategory_Action = new Shop_ImageCategory_Action();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			ImgCategoryList.dt_Album = shop_ImageCategory_Action.Select(this.MemLoginID);
			if (ImgCategoryList.dt_Album != null && ImgCategoryList.dt_Album.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(ImgCategoryList.dt_Album.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("ProductIsPanic_List", true);
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_0.Text = this.int_0.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (this.int_0 > pageList.PageCount)
			{
				this.int_0 = pageList.PageCount;
			}
			ImgCategoryList.dt_Album = shop_ImageCategory_Action.Select(this.MemLoginID);
			if (ImgCategoryList.dt_Album != null && ImgCategoryList.dt_Album.Rows.Count > 0)
			{
				this.repeater_0.DataSource = ImgCategoryList.dt_Album.DefaultView;
				this.repeater_0.DataBind();
			}
			if (ImgCategoryList.dt_Album == null || ImgCategoryList.dt_Album.Rows.Count == 0)
			{
				this.panel_0.Visible = true;
			}
		}
	}
}
