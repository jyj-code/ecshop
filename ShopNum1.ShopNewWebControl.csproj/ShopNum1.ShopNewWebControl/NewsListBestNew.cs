using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class NewsListBestNew : BaseWebControl
	{
		private string string_0 = "NewsListBestNew.ascx";
		private Repeater repeater_0;
		private string string_1 = "-1";
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string ShowCount
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public NewsListBestNew()
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
			this.string_1 = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"]);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
			DataTable dataTable = shop_News_Action.SearchNewsList(this.MemLoginID, this.string_1);
			this.repeater_0.DataSource = ((this.ShowCount == "0") ? dataTable : this.Top(dataTable, Convert.ToInt32(this.ShowCount)));
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
					dataRow[j] = dataTable_0.Rows[i][j];
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
		public static string IsShow(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "否";
			}
			else if (a == "1")
			{
				result = "是";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
