using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ArticleCommentList : BaseWebControl
	{
		private string string_0 = "ArticleCommentList.ascx";
		private DataList dataList_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string guid
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public ArticleCommentList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.dataList_0 = (DataList)skin.FindControl("DataListArticleCommentList");
			if (this.Page.IsPostBack)
			{
			}
			if (this.Page.Request.QueryString["guid"] != null)
			{
				string arg_E4_0 = this.Page.Request.QueryString["guid"];
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
			DataTable dataTable = shopNum1_ArticleComment_Action.Search(this.Page.Request.QueryString["guid"].ToString(), -1, 1, Convert.ToInt32(this.ShowCount));
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = Convert.ToInt32(this.ShowCount);
			int num;
			if (this.Page.Request.QueryString.Get("page") != null)
			{
				num = Convert.ToInt32(this.Page.Request.QueryString.Get("page"));
			}
			else
			{
				num = 1;
			}
			pagedDataSource.CurrentPageIndex = num - 1;
			Num1WebControlCommon num1WebControlCommon = new Num1WebControlCommon();
			this.label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num);
			this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num);
			this.hyperLink_0.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				Convert.ToInt32(num - 1),
				"&guid=",
				this.guid
			}));
			this.hyperLink_1.NavigateUrl = GetPageName.GetPage("?Page=1&guid=" + this.guid);
			this.hyperLink_2.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				Convert.ToInt32(num + 1),
				"&guid=",
				this.guid
			}));
			this.hyperLink_3.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				pagedDataSource.PageCount,
				"&guid=",
				this.guid
			}));
			if (num <= 1 && pagedDataSource.PageCount <= 1)
			{
				this.hyperLink_1.NavigateUrl = "";
				this.hyperLink_0.NavigateUrl = "";
				this.hyperLink_2.NavigateUrl = "";
				this.hyperLink_3.NavigateUrl = "";
			}
			if (num <= 1 && pagedDataSource.PageCount > 1)
			{
				this.hyperLink_1.NavigateUrl = "";
				this.hyperLink_0.NavigateUrl = "";
			}
			if (num >= pagedDataSource.PageCount)
			{
				this.hyperLink_2.NavigateUrl = "";
				this.hyperLink_3.NavigateUrl = "";
			}
			this.dataList_0.DataSource = pagedDataSource;
			this.dataList_0.DataBind();
		}
	}
}
