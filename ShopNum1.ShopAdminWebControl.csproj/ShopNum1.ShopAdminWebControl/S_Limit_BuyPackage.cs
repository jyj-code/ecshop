using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Limit_BuyPackage : BaseShopWebControl
	{
		private string string_0 = "S_Limit_BuyPackage.ascx";
		private HtmlInputText htmlInputText_0;
		private Button button_0;
		public S_Limit_BuyPackage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.button_0 = (Button)skin.FindControl("btnSub");
			this.button_0.Click += new EventHandler(this.btnSub_Click);
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtNum");
		}
		protected void btnSub_Click(object sender, EventArgs e)
		{
			string value = ShopSettings.GetValue("Limit_Money");
			string value2 = ShopSettings.GetValue("Limit_ActivityCount");
			string value3 = ShopSettings.GetValue("Limit_GoodsCount");
			int num = Convert.ToInt32(this.htmlInputText_0.Value);
			ShopNum1_Limt_Package shopNum1_Limt_Package = new ShopNum1_Limt_Package();
			shopNum1_Limt_Package.Name = "限制折扣套餐";
			shopNum1_Limt_Package.StartTime = new DateTime?(DateTime.Now);
			shopNum1_Limt_Package.EndTime = new DateTime?(DateTime.Now.AddMonths(num));
			shopNum1_Limt_Package.BuyNum = new int?(num);
			shopNum1_Limt_Package.PayMoney = new decimal?(Convert.ToDecimal(num * Convert.ToDecimal(value)));
			shopNum1_Limt_Package.LeaveNum = new int?(Convert.ToInt32(value2));
			shopNum1_Limt_Package.LimtActivityNum = new int?(Convert.ToInt32(value2));
			shopNum1_Limt_Package.LimitProductNum = new int?(Convert.ToInt32(value3));
			shopNum1_Limt_Package.MemloginId = this.MemLoginID;
			shopNum1_Limt_Package.ShopName = ShopNum1.Common.Common.GetNameById("shopname", "shopnum1_shopinfo", " and name='" + this.MemLoginID + "'");
			Shop_LimtPackages_Action shop_LimtPackages_Action = new Shop_LimtPackages_Action();
			shop_LimtPackages_Action.AddLimtPackage(shopNum1_Limt_Package);
			this.Page.Response.Redirect("S_Limit_Packages.aspx");
		}
	}
}
