using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ArticleRelatedArticle : BaseWebControl
	{
		private string string_0 = "ArticleRelatedArticle.ascx";
		private DataList dataList_0;
		public ArticleRelatedArticle()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.dataList_0 = (DataList)skin.FindControl("DataListArticleRelatedArticle");
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
			string value = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ArticleRelatedArticleListCount");
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable dataTable = shopNum1_Article_Action.SearchArticleRelatedArticle(this.Page.Request.QueryString["guid"].ToString(), Convert.ToInt32(value));
			this.dataList_0.DataSource = dataTable.DefaultView;
			this.dataList_0.DataBind();
		}
	}
}
