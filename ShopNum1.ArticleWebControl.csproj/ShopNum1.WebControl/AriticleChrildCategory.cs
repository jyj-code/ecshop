using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class AriticleChrildCategory : BaseWebControl
	{
		public int int_0 = 0;
		private string string_0 = "AriticleChrildCategory.ascx";
		private Repeater repeater_0;
		public AriticleChrildCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCategory");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			DataRow[] array = ShopNum1_ArticleCategory_Action.ArticleCategoryTable.Select("FatherID=0");
			if (array != null && array.Length > 0)
			{
				this.repeater_0.DataSource = array.CopyToDataTable<DataRow>();
				this.repeater_0.DataBind();
			}
		}
	}
}
