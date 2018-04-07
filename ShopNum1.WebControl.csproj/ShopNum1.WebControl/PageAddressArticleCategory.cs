using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class PageAddressArticleCategory : BaseWebControl
	{
		private string string_0 = "PageAddress.ascx";
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		public string ArticleCategoryID
		{
			get;
			set;
		}
		public PageAddressArticleCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.ArticleCategoryID = ((this.Page.Request.QueryString["ID"] == null) ? "0" : this.Page.Request.QueryString["ID"]);
			this.literal_0 = (Literal)skin.FindControl("PageAddress");
			if (this.Page.IsPostBack)
			{
			}
			this.Bind();
		}
		public void Bind()
		{
			StringBuilder stringBuilder = new StringBuilder();
			HtmlAnchor htmlAnchor = new HtmlAnchor();
			htmlAnchor.InnerText = "首页";
			htmlAnchor.HRef = "http://" + this.Page.Request.Url.Host + "/";
			stringBuilder.Append(PageAddressArticleCategory.RenderControl(htmlAnchor));
			if (this.ArticleCategoryID == "0")
			{
				htmlAnchor.InnerText = "商城文章";
				htmlAnchor.HRef = GetPageName.RetUrl("ArticleList");
				stringBuilder.Append("&nbsp;&gt;&nbsp;" + PageAddressArticleCategory.RenderControl(htmlAnchor));
			}
			else
			{
				ShopNum1_PageAddress_Action shopNum1_PageAddress_Action = (ShopNum1_PageAddress_Action)LogicFactory.CreateShopNum1_PageAddress_Action();
				DataTable articleCategoryPageAddress = shopNum1_PageAddress_Action.GetArticleCategoryPageAddress(this.ArticleCategoryID);
				for (int i = 0; i < articleCategoryPageAddress.Rows.Count; i++)
				{
					htmlAnchor.InnerText = articleCategoryPageAddress.Rows[i]["Name"].ToString();
					htmlAnchor.HRef = GetPageName.RetUrl("ArticleList", articleCategoryPageAddress.Rows[i]["ID"].ToString(), "ID");
					stringBuilder.Append("&nbsp;&gt;&nbsp;" + PageAddressArticleCategory.RenderControl(htmlAnchor));
				}
			}
			this.literal_0.Text = stringBuilder.ToString();
		}
		public static string RenderControl(System.Web.UI.Control control)
		{
			StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
			control.RenderControl(htmlTextWriter);
			htmlTextWriter.Flush();
			htmlTextWriter.Close();
			return stringWriter.ToString();
		}
	}
}
