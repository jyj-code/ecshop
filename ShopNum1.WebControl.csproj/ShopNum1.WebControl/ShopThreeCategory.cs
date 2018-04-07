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
	public class ShopThreeCategory : BaseWebControl
	{
		private string string_0 = "ShopThreeCategory.ascx";
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
		public ShopThreeCategory()
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
			this.method_1();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCID");
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterChild");
				repeater.ItemDataBound += new RepeaterItemEventHandler(this.method_0);
				ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
				DataTable dataTable = shopNum1_ShopCategory_Action.Search(Convert.ToInt32(hiddenField.Value), 0, this.ShowCountTwo);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					repeater.DataSource = dataTable;
					repeater.DataBind();
				}
			}
		}
		private void method_0(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldFID");
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterthreeChild");
				ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
				DataTable dataTable = shopNum1_ShopCategory_Action.Search(Convert.ToInt32(hiddenField.Value), 0, this.ShowCountThree);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					repeater.DataSource = dataTable;
					repeater.DataBind();
					repeater.Items[repeater.Items.Count - 1].FindControl("LiteralLine").Visible = false;
				}
			}
		}
		private void method_1()
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable dataTable = shopNum1_ShopCategory_Action.Search(0, 0, this.string_1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
		}
	}
}
