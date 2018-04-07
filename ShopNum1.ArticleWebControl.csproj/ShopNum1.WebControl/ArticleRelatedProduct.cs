using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ArticleRelatedProduct : BaseWebControl
	{
		private string string_0 = "ArticleRelatedProduct.ascx";
		private DataList dataList_0;
		protected bool List = true;
		public ArticleRelatedProduct()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.dataList_0 = (DataList)skin.FindControl("DataListArticleRelatedProduct");
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
			shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ArticleRelatedProductListCount");
		}
	}
}
