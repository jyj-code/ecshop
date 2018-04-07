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
	public class ArticleDetail : BaseWebControl
	{
		private string string_0 = "ArticleDetail.ascx";
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		private Repeater repeater_1;
		private string string_1 = "上一篇：";
		private string string_2 = "下一篇：";
		public string OnArticleName
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public string NextArticleName
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public ArticleDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterArticleDetail");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterOnAndNext");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			if (this.Page.IsPostBack)
			{
			}
			this.hiddenField_0.Value = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			if (this.hiddenField_0.Value != "0")
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable editInfo = shopNum1_Article_Action.GetEditInfo("'" + this.hiddenField_0.Value + "'");
			if (editInfo != null && editInfo.Rows.Count > 0)
			{
				this.repeater_0.DataSource = editInfo.DefaultView;
				this.repeater_0.DataBind();
				shopNum1_Article_Action.UpdateClickCount(this.hiddenField_0.Value);
			}
			this.repeater_1.DataSource = shopNum1_Article_Action.GetArticleOnAndNext(this.hiddenField_0.Value, this.string_1, this.string_2);
			this.repeater_1.DataBind();
		}
	}
}
