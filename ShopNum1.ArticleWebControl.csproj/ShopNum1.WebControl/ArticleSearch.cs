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
	[ParseChildren(true)]
	public class ArticleSearch : BaseWebControl
	{
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private HiddenField hiddenField_0;
		private string string_0 = GetPageName.RetDomainUrl("ArticleListSearch");
		private string string_1 = "all";
		private string string_2 = "ArticleSearch.ascx";
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		private string pageID
		{
			get;
			set;
		}
		public string PageSize
		{
			get;
			set;
		}
		public string ArticleName
		{
			get;
			set;
		}
		public string ArticleCategoryID
		{
			get;
			set;
		}
		public ArticleSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_2;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldSearchName");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.ArticleName = ((this.Page.Request.QueryString["search"] == null) ? "-1" : this.Page.Request.QueryString["search"].ToString());
			this.hiddenField_0.Value = ((this.Page.Request.QueryString["search"] == null) ? this.Page.Request.QueryString["Category"] : this.Page.Request.QueryString["search"].ToString());
			if (this.hiddenField_0.Value == "" || this.hiddenField_0.Value == "-1")
			{
				this.hiddenField_0.Value = "咨询";
			}
			this.ArticleCategoryID = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
			if (this.Page.IsPostBack)
			{
			}
			this.pageID = "1";
			try
			{
				this.pageID = this.Page.Request.QueryString["PageID"].ToString();
			}
			catch
			{
				this.pageID = "1";
			}
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_0,
				"?search=",
				this.ArticleName,
				"&guid=",
				this.ArticleCategoryID,
				"&pageid=",
				text
			}));
		}
		private void method_0()
		{
			try
			{
				Convert.ToInt32(this.pageID);
			}
			catch (Exception)
			{
				return;
			}
			this.ArticleCategoryID = this.ArticleCategoryID.Replace("'", "");
			PageList1 pageList = new PageList1();
			pageList.PageSize = Convert.ToInt32(this.PageSize);
			pageList.PageID = Convert.ToInt32(this.pageID);
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable dataTable = shopNum1_Article_Action.SearchArticle(this.ArticleName, this.ArticleCategoryID, this.pageID.ToString(), this.PageSize, "1", this.string_1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("ArticleListSearch", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_0.Text = this.pageID.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (Convert.ToInt32(this.pageID) > pageList.PageCount)
			{
				this.pageID = pageList.PageCount.ToString();
			}
			DataTable dataTable2 = shopNum1_Article_Action.SearchArticle(this.ArticleName, this.ArticleCategoryID, this.pageID.ToString(), this.PageSize, "0", this.string_1);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable2;
				this.repeater_0.DataBind();
			}
			else
			{
				string url = GetPageName.AgentRetUrl("ArticleSearchNofind", this.ArticleName, "search");
				this.Page.Response.Redirect(url);
			}
		}
	}
}
