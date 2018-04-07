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
	public class ArticleList : BaseWebControl
	{
		private string string_0 = "ArticleList.ascx";
		private Repeater repeater_0;
		public ArticleList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterArticleList");
			if (this.Page.IsPostBack)
			{
			}
			string text = (this.Page.Request.QueryString["ID"] == null) ? "0" : this.Page.Request.QueryString["ID"];
			if (text != "0")
			{
				this.method_0(text);
			}
			else
			{
				this.method_0("-1");
			}
		}
		private void method_0(string string_1)
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			string value = ShopSettings.GetValue("ArticleListCount");
			DataTable dataTable = shopNum1_Article_Action.SearchArticleList("0", Convert.ToInt32(string_1), Convert.ToInt32(value));
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
