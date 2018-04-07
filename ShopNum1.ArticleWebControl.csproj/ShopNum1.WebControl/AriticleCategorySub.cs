using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class AriticleCategorySub : BaseWebControl
	{
		public int int_0 = 0;
		private string string_0 = "AriticleCategorySub.ascx";
		private Repeater repeater_0;
		public AriticleCategorySub()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCategory");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			Repeater repeater = (Repeater)e.Item.FindControl("RepeaterSubCategory");
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldID");
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			DataTable dataTable = shopNum1_ArticleCategory_Action.SearchShow(Convert.ToInt32(hiddenField.Value), 0);
			repeater.DataSource = dataTable.DefaultView;
			repeater.DataBind();
		}
		private void method_0()
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			string value = string.Empty;
			if (this.Page.Request["ID"] != null)
			{
				value = this.Page.Request["ID"].ToString();
				DataTable dataTable = shopNum1_ArticleCategory_Action.SearchShow(Convert.ToInt32(value), 0);
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
