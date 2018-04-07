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
	public class ProductThreeCategory : BaseWebControl
	{
		private string string_0 = "ProductThreeCategory.ascx";
		private Repeater repeater_0;
		private string string_1 = "0";
		private string string_2 = "0";
		private string string_3 = "0";
		public string ShowCountOne
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
		public string ShowCountTwo
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
		public string ShowCountThree
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
		public ProductThreeCategory()
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
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCID");
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterChild");
				HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("HiddenFieldIsHaveCategory");
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_ProductCategory";
				DataTable dataTable = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(hiddenField.Value), 0, this.ShowCountTwo);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					repeater.DataSource = dataTable;
					repeater.DataBind();
					hiddenField2.Value = "1";
				}
				else
				{
					hiddenField2.Value = "0";
				}
			}
		}
		private void method_0()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_ProductCategory";
			DataTable dataTable = shopNum1_ProductCategory_Action.Search(0, 0, this.string_1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
		}
	}
}
