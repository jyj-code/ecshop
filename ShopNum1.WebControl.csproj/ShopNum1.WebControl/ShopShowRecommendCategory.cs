using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ShopShowRecommendCategory : BaseWebControl
	{
		private string string_0 = "ShopShowRecommendCategory.ascx";
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
		public ShopShowRecommendCategory()
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
				DataRow[] array = ShopNum1_ShopCategory_Action.ShopCategoryTable.Select("FatherID=" + hiddenField.Value);
				if (array != null && array.Length > 0)
				{
					repeater.DataSource = this.Top(array, this.int_1);
					repeater.DataBind();
					repeater.Items[repeater.Items.Count - 1].FindControl("LiteralLine").Visible = false;
				}
			}
		}
		private void method_0()
		{
			DataRow[] array = ShopNum1_ShopCategory_Action.ShopCategoryTable.Select("FatherID=0");
			if (array != null && array.Length > 0)
			{
				this.repeater_0.DataSource = this.Top(array, this.int_0);
				this.repeater_0.DataBind();
			}
		}
		public DataTable Top(DataRow[] dataRows, int count)
		{
			DataRow[] array = new DataRow[count];
			DataTable result;
			if (count > 0)
			{
				for (int i = 0; i < ((count <= dataRows.Length) ? count : dataRows.Length); i++)
				{
					array[i] = dataRows[i];
				}
				result = array.CopyToDataTable<DataRow>();
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
