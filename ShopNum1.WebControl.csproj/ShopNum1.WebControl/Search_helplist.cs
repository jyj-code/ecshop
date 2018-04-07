using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	public class Search_helplist : BaseWebControl
	{
		private string string_0 = "Search_helplist.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private Button button_1;
		private TextBox textBox_1;
		private Label label_1;
		private Label label_2;
		private string string_1 = GetPageName.RetDomainUrl("HelpListSearch");
		private ShopNum1_Help_Action shopNum1_Help_Action_0 = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
		private string string_2;
		private string string_3;
		private int int_0;
		private string string_4;
		private string string_5;
		[CompilerGenerated]
		private int int_1;
		public int ShowCount
		{
			get;
			set;
		}
		public Search_helplist()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.label_1 = (Label)skin.FindControl("LabelName");
			this.label_2 = (Label)skin.FindControl("LabelNum");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonAgainSearch");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxSearch");
			this.string_3 = ((ShopNum1.Common.Common.ReqStr("search") == "") ? "" : ShopNum1.Common.Common.ReqStr("search"));
			this.string_5 = ((ShopNum1.Common.Common.ReqStr("ordername") == "") ? "CreateTime" : ShopNum1.Common.Common.ReqStr("ordername"));
			this.string_4 = ((ShopNum1.Common.Common.ReqStr("sort") == "") ? "desc" : ShopNum1.Common.Common.ReqStr("sort"));
			this.label_1.Text = this.string_3;
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(ShopNum1.Common.Common.ReqStr("PageID"));
			}
			catch
			{
				this.int_0 = 1;
			}
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.string_3 = ((this.textBox_1.Text.Trim().Replace("'", "") == string.Empty) ? "-1" : this.textBox_1.Text.Trim().Replace("'", ""));
			string url = GetPageName.AgentRetUrl("HelpListSearch", this.string_3, "search");
			this.Page.Response.Redirect(url);
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?search=",
				this.string_3,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&pageid=",
				text
			}));
		}
		private void method_0()
		{
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			DataSet dataSet = this.shopNum1_Help_Action_0.Search(this.string_3, this.string_5, this.string_4, this.ShowCount.ToString(), this.int_0.ToString(), "1");
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			this.label_2.Text = pageList.RecordCount.ToString();
			PageListBll pageListBll = new PageListBll("HelpListSearch", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页";
			this.textBox_0.Text = this.int_0.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			DataSet dataSet2 = this.shopNum1_Help_Action_0.Search(this.string_3, this.string_5, this.string_4, this.ShowCount.ToString(), this.int_0.ToString(), "0");
			if (dataSet2 != null && dataSet2.Tables[0].Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataSet2.Tables[0];
				this.repeater_0.DataBind();
			}
		}
	}
}
