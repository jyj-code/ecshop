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
	public class ProductOneTwoCategory : BaseWebControl
	{
		private string string_0 = "ProductOneTwoCategory.ascx";
		private Repeater repeater_0;
		private int int_0 = 6;
		private int int_1 = 6;
		public int ShowCountOne
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public int ShowCountTwo
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}
		public ProductOneTwoCategory()
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
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			DataTable dataTable = shopNum1_ProductCategory_Action.Search(0, 0, this.int_0.ToString());
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCID");
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterChild");
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				DataTable dataTable = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(hiddenField.Value), 0, this.int_1.ToString());
				repeater.DataSource = dataTable.DefaultView;
				repeater.DataBind();
			}
		}
	}
}
