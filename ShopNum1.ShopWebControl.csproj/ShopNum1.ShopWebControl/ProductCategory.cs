using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductCategory : BaseWebControl
	{
		private string string_0 = "ProductCategory.ascx";
		private Repeater repeater_0;
		private DataTable dataTable_0 = null;
		private int int_0 = 0;
		private int int_1 = 0;
		private int int_2 = 0;
		[CompilerGenerated]
		private string string_1;
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
		public int ShowCountThree
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public ProductCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
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
				DataRow[] array = this.dataTable_0.Select("fatherId='" + hiddenField.Value + "'");
				if (array.Length > 0)
				{
					repeater.DataSource = this.ToDataTable(array).DefaultView;
					repeater.DataBind();
				}
			}
		}
		private void method_0()
		{
			Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
			this.dataTable_0 = shop_ProductCategory_Action.GetShopCate(this.MemLoginID);
			DataRow[] array = this.dataTable_0.Select("fatherid=0");
			if (array.Length > 0)
			{
				this.repeater_0.DataSource = this.ToDataTable(array).DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public DataTable ToDataTable(DataRow[] rows)
		{
			DataTable result;
			if (rows == null || rows.Length == 0)
			{
				result = null;
			}
			else
			{
				DataTable dataTable = rows[0].Table.Clone();
				for (int i = 0; i < rows.Length; i++)
				{
					DataRow dataRow = rows[i];
					dataTable.Rows.Add(dataRow.ItemArray);
				}
				result = dataTable;
			}
			return result;
		}
		public DataTable Top(DataTable dataTable_1, int count)
		{
			int num = (dataTable_1.Rows.Count > count) ? count : dataTable_1.Rows.Count;
			DataTable dataTable = dataTable_1.Clone();
			for (int i = 0; i < num; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int j = 0; j < dataTable_1.Columns.Count; j++)
				{
					dataRow[j] = dataTable_1.Rows[i][j].ToString();
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
	}
}
