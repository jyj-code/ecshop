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
	public class NewsCategoryShow : BaseWebControl
	{
		private string string_0 = "NewsCategoryShow.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		public int ShowCount
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public NewsCategoryShow()
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
			this.repeater_1 = (Repeater)e.Item.FindControl("RepeaterDataTitle");
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldID");
			this.method_1(hiddenField.Value);
		}
		private void method_0()
		{
			Shop_NewsCategory_Action shop_NewsCategory_Action = (Shop_NewsCategory_Action)LogicFactory.CreateShop_NewsCategory_Action();
			DataTable newsCategoryList = shop_NewsCategory_Action.GetNewsCategoryList(this.MemLoginID, "1");
			this.repeater_0.DataSource = newsCategoryList;
			this.repeater_0.DataBind();
		}
		private void method_1(string string_2)
		{
			Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
			DataTable dataTable = shop_News_Action.SearchNewsList(this.MemLoginID, string_2);
			this.repeater_0.DataSource = ((this.ShowCount == 0) ? dataTable : this.Top(dataTable, Convert.ToInt32(this.ShowCount)));
			this.repeater_0.DataBind();
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
