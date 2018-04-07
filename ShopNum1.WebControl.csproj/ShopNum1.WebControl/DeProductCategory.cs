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
	public class DeProductCategory : BaseWebControl
	{
		private string string_0 = "DeProductCategory.ascx";
		private Repeater repeater_0;
		private int int_0 = 0;
		private int int_1 = 0;
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
		public DeProductCategory()
		{
			//base.FK();
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
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_ProductCategory";
				DataTable category = shopNum1_ProductCategory_Action.GetCategory(hiddenField.Value);
				if (category.Rows.Count > 0)
				{
					repeater.DataSource = ((this.int_1 == 0) ? category : this.Top(category, this.int_1));
					repeater.DataBind();
				}
			}
		}
		private void method_0()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_ProductCategory";
			DataTable category = shopNum1_ProductCategory_Action.GetCategory("0");
			this.repeater_0.DataSource = ((this.int_0 == 0) ? category : this.Top(category, this.int_0));
			this.repeater_0.DataBind();
		}
		public DataTable Top(DataTable dataTable_0, int count)
		{
			int num = (dataTable_0.Rows.Count > count) ? count : dataTable_0.Rows.Count;
			DataTable dataTable = dataTable_0.Clone();
			DataTable result;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					for (int j = 0; j < dataTable_0.Columns.Count; j++)
					{
						dataRow[j] = dataTable_0.Rows[i][j].ToString();
					}
					dataTable.Rows.Add(dataRow);
				}
				result = dataTable;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
