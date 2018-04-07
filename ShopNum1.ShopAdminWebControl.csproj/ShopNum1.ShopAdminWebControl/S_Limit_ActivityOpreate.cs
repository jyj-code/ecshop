using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
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
	public class S_Limit_ActivityOpreate : BaseShopWebControl
	{
		private string string_0 = "S_Limit_ActivityOpreate.ascx";
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private Button button_0;
		private Shop_LimtPackages_Action shop_LimtPackages_Action_0 = new Shop_LimtPackages_Action();
		private ShopNum1_Product_Activity shopNum1_Product_Activity_0 = new ShopNum1_Product_Activity();
		private ShopNum1_Activity_Action shopNum1_Activity_Action_0 = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
		public S_Limit_ActivityOpreate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txtStartTime");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txtEndTime");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txtDisCount");
			this.button_0 = (Button)skin.FindControl("btnSub");
			this.button_0.Click += new EventHandler(this.btnSub_Click);
			if (this.Page.IsPostBack)
			{
			}
		}
		protected void btnSub_Click(object sender, EventArgs e)
		{
			this.shopNum1_Product_Activity_0.Name = this.htmlInputText_0.Value;
			this.shopNum1_Product_Activity_0.StartTime = new DateTime?(Convert.ToDateTime(this.htmlInputText_1.Value));
			this.shopNum1_Product_Activity_0.EndTime = new DateTime?(Convert.ToDateTime(this.htmlInputText_2.Value));
			this.shopNum1_Product_Activity_0.Type = new int?(2);
			this.shopNum1_Product_Activity_0.Discount = new decimal?(Convert.ToDecimal(this.htmlInputText_3.Value));
			this.shopNum1_Product_Activity_0.LimitProduct = new int?(Convert.ToInt32(ShopSettings.GetValue("Limit_GoodsCount")));
			this.shopNum1_Product_Activity_0.MemloginId = this.MemLoginID;
			this.shopNum1_Product_Activity_0.SubstationID = ShopNum1.Common.Common.GetNameById("SubstationID", "shopnum1_shopinfo", " and memloginid='" + this.MemLoginID + "'");
			this.shopNum1_Product_Activity_0.ShopName = ShopNum1.Common.Common.GetNameById("shopname", "shopnum1_shopinfo", " and memloginid='" + this.MemLoginID + "'");
			this.shopNum1_Activity_Action_0.AddActivity(this.shopNum1_Product_Activity_0);
			this.Page.Response.Redirect("S_Limit_ActivityList.aspx");
		}
	}
}
