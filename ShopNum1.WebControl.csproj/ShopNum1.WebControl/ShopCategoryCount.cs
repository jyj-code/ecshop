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
	public class ShopCategoryCount : BaseWebControl
	{
		private string string_0 = "ShopCategoryCount.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		private string string_2 = "0";
		public string ShowCountOne
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
		public ShopCategoryCount()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable shopCategoryCount;
			if (this.string_1 == "all")
			{
				shopCategoryCount = shopNum1_ShopCategory_Action.GetShopCategoryCount(this.string_2);
			}
			else
			{
				shopCategoryCount = shopNum1_ShopCategory_Action.GetShopCategoryCount(this.string_2, this.string_1);
			}
			if (shopCategoryCount != null && shopCategoryCount.Rows.Count > 0)
			{
				this.repeater_0.DataSource = shopCategoryCount;
				this.repeater_0.DataBind();
			}
		}
	}
}
