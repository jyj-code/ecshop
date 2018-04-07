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
	public class ArticleCommentLists : BaseWebControl
	{
		private string string_0 = "ArticleCommentLists.ascx";
		private Repeater repeater_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		private Label label_1;
		[CompilerGenerated]
		private string string_1;
		public string guid
		{
			get;
			set;
		}
		public ArticleCommentLists()
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
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterArticleCommentList");
			if (this.Page.IsPostBack)
			{
			}
			string a = (this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"];
			if (a != "0")
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopSettings shopSettings = new ShopSettings();
			string value = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ArticleCommentCount");
			ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
			DataTable dataTable = shopNum1_ArticleComment_Action.Search(this.Page.Request.QueryString["guid"].ToString(), -1, 1, Convert.ToInt32(value));
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			string value2 = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ArticleCommentPageCount");
			pagedDataSource.PageSize = Convert.ToInt32(value2);
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
			this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, this.Page.Request.QueryString["guid"].ToString(), pagedDataSource.PageCount, num);
			this.hyperLink_0.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				Convert.ToInt32(num - 1),
				"&guid=",
				this.Page.Request.QueryString["guid"].ToString()
			}));
			this.hyperLink_1.NavigateUrl = GetPageName.GetPage("?Page=1&guid=" + this.Page.Request.QueryString["guid"].ToString());
			this.hyperLink_2.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				Convert.ToInt32(num + 1),
				"&guid=",
				this.Page.Request.QueryString["guid"].ToString()
			}));
			this.hyperLink_3.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				pagedDataSource.PageCount,
				"&guid=",
				this.Page.Request.QueryString["guid"].ToString()
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
			this.repeater_0.DataSource = pagedDataSource;
			this.repeater_0.DataBind();
		}
	}
}
