using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SellOrder : BaseWebControl
	{
		private string string_0 = "SellOrder.ascx";
		private DataList dataList_0;
		public SellOrder()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.dataList_0 = (DataList)skin.FindControl("DataListSellOrder");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopSettings shopSettings = new ShopSettings();
			string value = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SellOrderCount");
			ShopNum1_Report_Action shopNum1_Report_Action = (ShopNum1_Report_Action)LogicFactory.CreateShopNum1_Report_Action();
			DataTable dataSource = shopNum1_Report_Action.SearchSellOrder(string.Empty, string.Empty, Convert.ToInt32(value));
			this.dataList_0.DataSource = dataSource;
			this.dataList_0.DataBind();
		}
	}
}
