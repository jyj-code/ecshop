using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ArticleCategoryList : BaseWebControl
	{
		private string string_0 = "ArticleCategoryList.ascx";
		private Repeater repeater_0;
		private DataList dataList_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string FatherID
		{
			get;
			set;
		}
		public string ArticleCategoryID
		{
			get;
			set;
		}
		public ArticleCategoryList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.method_0("4");
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			this.dataList_0 = (DataList)e.Item.FindControl("RepeaterDataTitle");
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldID");
			this.method_1(hiddenField.Value);
		}
		private void method_0(string string_3)
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			this.repeater_0.DataSource = shopNum1_ArticleCategory_Action.GetArticleCategory(string_3);
			this.repeater_0.DataBind();
		}
		private void method_1(string string_3)
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			this.dataList_0.DataSource = shopNum1_ArticleCategory_Action.GetArticleCategory(string_3);
			this.dataList_0.DataBind();
		}
	}
}
