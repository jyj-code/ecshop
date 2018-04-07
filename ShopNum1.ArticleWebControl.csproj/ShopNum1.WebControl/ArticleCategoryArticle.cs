using ShopNum1.BusinessLogic;
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
	public class ArticleCategoryArticle : BaseWebControl
	{
		public int int_0 = 0;
		private string string_0 = "ArticleCategroyArticle.ascx";
		private Repeater repeater_0;
		private Label label_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string ArticleCategoryID
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public ArticleCategoryArticle()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterArticleCategoryArticle");
			this.label_0 = (Label)skin.FindControl("ArticleCategoryName");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable dataTable = shopNum1_Article_Action.SearchByArticleCategoryID(Convert.ToInt32(this.ArticleCategoryID), Convert.ToInt32(this.ShowCount));
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			this.label_0.Text = shopNum1_ArticleCategory_Action.GetNameByID(Convert.ToInt32(this.ArticleCategoryID));
		}
	}
}
