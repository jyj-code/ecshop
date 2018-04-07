using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class BrandAllList : BaseWebControl
	{
		private string string_0 = "BrandAllList.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string ShowCountOne
		{
			get;
			set;
		}
		public string ShowCountTwo
		{
			get;
			set;
		}
		public BrandAllList()
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
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCID");
			Repeater repeater = (Repeater)e.Item.FindControl("RepeaterBrand");
			Label label = (Label)e.Item.FindControl("LabelBrandCount");
			ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
			DataTable productBrandBycount = shopNum1_Brand_Action.GetProductBrandBycount(hiddenField.Value.ToString(), this.ShowCountTwo);
			label.Text = ((productBrandBycount == null) ? "0" : productBrandBycount.Rows.Count.ToString());
			if (productBrandBycount != null)
			{
				repeater.DataSource = productBrandBycount.DefaultView;
				repeater.DataBind();
			}
		}
		private void method_0()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			DataTable dataTable = shopNum1_ProductCategory_Action.Search(0, 0, this.ShowCountOne);
			if (dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
