using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ProductBookingDetail : BaseShopWebControl
	{
		private string string_0 = "S_ProductBookingDetail.ascx";
		private Repeater repeater_0;
		private Button button_0;
		private string string_1 = string.Empty;
		public S_ProductBookingDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			Repeater arg_10_0 = (Repeater)skin.FindControl("RepeaterData");
			Button button = (Button)skin.FindControl("btn_Back");
			button.Click += new EventHandler(this.method_0);
			this.string_1 = ((ShopNum1.Common.Common.ReqStr("guid") == "") ? "0" : ShopNum1.Common.Common.ReqStr("Guid"));
		}
		private void method_0(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ProductBookingList.aspx");
		}
		private void method_1()
		{
			Shop_ProductBooking_Action shop_ProductBooking_Action = (Shop_ProductBooking_Action)LogicFactory.CreateShop_ProductBooking_Action();
			this.repeater_0.DataSource = shop_ProductBooking_Action.GetProductBooking(this.string_1);
			this.repeater_0.DataBind();
		}
		public static string IsAudit(object object_0)
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
