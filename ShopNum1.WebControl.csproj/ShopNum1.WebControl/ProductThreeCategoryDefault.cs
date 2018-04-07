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
	public class ProductThreeCategoryDefault : BaseWebControl
	{
		public int int_0 = 0;
		private string string_0 = "ProductThreeCategoryDefault.ascx";
		private Repeater repeater_0;
		private ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action_0 = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		private string string_1 = "10";
		private string string_2 = "6";
		private string string_3 = "10";
		public string ShowOneCount
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
		public string ShowTwoCount
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
		public string ShowThreeCount
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
		public ProductThreeCategoryDefault()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCategoryOne");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.method_0();
		}
		private void method_0()
		{
			DataTable dataTable = this.shopNum1_ProductCategory_Action_0.Search(0, 0, this.string_1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterCategory2");
				repeater.ItemDataBound += new RepeaterItemEventHandler(this.method_1);
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCategory1");
				DataTable dataTable = this.shopNum1_ProductCategory_Action_0.Search(Convert.ToInt32(hiddenField.Value), 0, this.string_2);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					repeater.DataSource = dataTable.DefaultView;
					repeater.DataBind();
				}
			}
		}
		private void method_1(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterCategory3");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCheck");
				HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("HiddenFieldCategory2");
				DataTable dataTable = this.shopNum1_ProductCategory_Action_0.Search(Convert.ToInt32(hiddenField2.Value), 0, this.string_2);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					repeater.DataSource = dataTable.DefaultView;
					repeater.DataBind();
				}
				else
				{
					hiddenField.Value = "0";
				}
			}
		}
	}
}
