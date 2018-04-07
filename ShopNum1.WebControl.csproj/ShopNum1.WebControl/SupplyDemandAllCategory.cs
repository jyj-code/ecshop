using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SupplyDemandAllCategory : BaseWebControl
	{
		private string string_0 = "SupplyDemandAllCategory.ascx";
		private Repeater repeater_0;
		private int int_0 = 0;
		private int int_1 = 0;
		private int int_2 = 0;
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
		public SupplyDemandAllCategory()
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
				DataRow[] array = ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable.Select("FatherID=" + hiddenField.Value);
				if (array != null && array.Length > 0)
				{
					repeater.DataSource = array.CopyToDataTable<DataRow>();
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
				DataRow[] array = ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable.Select("FatherID=" + hiddenField.Value);
				if (array != null && array.Length > 0)
				{
					repeater.DataSource = array.CopyToDataTable<DataRow>();
					repeater.DataBind();
				}
			}
		}
		private void method_1()
		{
			DataRow[] array = ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable.Select("FatherID=0");
			if (array != null && array.Length > 0)
			{
				this.repeater_0.DataSource = array.CopyToDataTable<DataRow>();
				this.repeater_0.DataBind();
			}
		}
		public DataTable Top(DataTable dataTable_0, int count)
		{
			int num = (dataTable_0.Rows.Count > count) ? count : dataTable_0.Rows.Count;
			DataTable dataTable = dataTable_0.Clone();
			for (int i = 0; i < num; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int j = 0; j < dataTable_0.Columns.Count; j++)
				{
					dataRow[j] = dataTable_0.Rows[i][j].ToString();
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
	}
}
