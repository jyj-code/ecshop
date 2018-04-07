using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopSEOManage : BaseShopWebControl
	{
		private string string_0 = "S_ShopSEOManage.aspx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string xmlmetopath
		{
			get;
			set;
		}
		public S_ShopSEOManage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.GetData();
		}
		public void GetData()
		{
			IShopNum1_ExtendSiteMota_Action shopNum1_ExtendSiteMota_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			string text = memLoginInfo.Rows[0]["ShopID"].ToString();
			string text2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			this.xmlmetopath = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				text2.Replace("-", "/"),
				"/shop",
				text,
				"/xml/SetMeto.xml"
			});
			DataTable dataTable = shopNum1_ExtendSiteMota_Action.SearchMetoList("", this.xmlmetopath);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
