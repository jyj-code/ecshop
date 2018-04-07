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
	public class NewsList : BaseWebControl
	{
		private string string_0 = "NewsListNew.ascx";
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
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
		public string MemLoginID
		{
			get;
			set;
		}
		public NewsList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.hiddenField_0.Value = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"]);
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
			this.ordername = ((this.Page.Request.QueryString["ordername"] == null) ? "a.guid" : this.Page.Request.QueryString["ordername"].ToString());
			this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "desc" : this.Page.Request.QueryString["sort"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string str = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(this.string_1 + "?pageid=" + str);
		}
		private void method_0()
		{
			Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			DataSet dataSet = shop_News_Action.SearchNewsListNew(this.MemLoginID, this.hiddenField_0.Value, this.ordername, this.soft, this.ShowCount.ToString(), this.int_0.ToString(), "1");
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("NewsListBestNew", true);
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
			DataSet dataSet2 = shop_News_Action.SearchNewsListNew(this.MemLoginID, this.hiddenField_0.Value, this.ordername, this.soft, this.ShowCount.ToString(), this.int_0.ToString(), "0");
			if (dataSet2.Tables[0] == null || dataSet2.Tables[0].Rows.Count == 0)
			{
				this.panel_0.Visible = true;
			}
			else
			{
				this.repeater_0.DataSource = dataSet2.Tables[0];
				this.repeater_0.DataBind();
			}
		}
		public static string IsShow(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "否";
			}
			else if (a == "1")
			{
				result = "是";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
