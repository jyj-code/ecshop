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
	public class ProductThreeCategory2 : BaseWebControl
	{
		public int int_0 = 0;
		private string string_0 = "ProductThreeCategory2.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private DataList dataList_0;
		private string string_1 = "100";
		private string string_2 = "100";
		private string string_3 = "100";
		private string string_4 = "100";
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
		public string ShowTwoRightCount
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
		public string ShowThreeCount
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public ProductThreeCategory2()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCategory");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.dataList_0 = (DataList)skin.FindControl("DataListCategoryRight");
			this.method_1();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			this.repeater_1 = (Repeater)e.Item.FindControl("RepeaterCategoryTwo");
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldID");
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			DataTable dataTable = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(hiddenField.Value), 0, this.string_2);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_1.DataSource = dataTable.DefaultView;
				this.repeater_1.DataBind();
			}
			DataList dataList = (DataList)e.Item.FindControl("DataListCategoryRight");
			dataList.ItemDataBound += new DataListItemEventHandler(this.method_0);
			DataTable dataTable2 = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(hiddenField.Value), 0, this.string_3);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				dataList.DataSource = dataTable2.DefaultView;
				dataList.DataBind();
			}
		}
		private void method_0(object sender, DataListItemEventArgs e)
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCategoryTwoID");
			Repeater repeater = (Repeater)e.Item.FindControl("RepeaterCategoryThree");
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			DataTable dataTable = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(hiddenField.Value), 0, this.string_4);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				repeater.DataSource = dataTable.DefaultView;
				repeater.DataBind();
			}
		}
		private void method_1()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			DataTable dataTable = shopNum1_ProductCategory_Action.Search(0, 0, this.ShowOneCount);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
