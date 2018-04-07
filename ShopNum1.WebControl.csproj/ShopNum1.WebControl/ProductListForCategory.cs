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
	public class ProductListForCategory : BaseWebControl
	{
		private string string_0 = "all";
		private string string_1 = "ProductListForCategory.ascx";
		private Repeater repeater_0;
		private string string_2 = "0";
		private string string_3 = "0";
		public string ShowCountProduct
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
		public string CategoryID
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public ProductListForCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_0 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable productByCategoryID;
			if (this.string_0 != "all")
			{
				productByCategoryID = shopNum1_ProuductChecked_Action.GetProductByCategoryID(this.CategoryID, this.string_2, this.string_0);
			}
			else
			{
				productByCategoryID = shopNum1_ProuductChecked_Action.GetProductByCategoryID(this.CategoryID, this.string_2);
			}
			if (productByCategoryID != null && productByCategoryID.Rows.Count > 0)
			{
				this.repeater_0.DataSource = productByCategoryID;
				this.repeater_0.DataBind();
			}
		}
	}
}
