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
	public class DeBrandList : BaseWebControl
	{
		private string string_0 = "DeBrandList.ascx";
		private Repeater repeater_0;
		public DeBrandList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterBrand");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
			string value = ShopSettings.GetValue("DefaultRecommendBrandCount");
			DataTable dataTable = shopNum1_Brand_Action.SearchBrand(value);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
