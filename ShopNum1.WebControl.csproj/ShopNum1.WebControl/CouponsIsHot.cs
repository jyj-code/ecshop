using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CouponsIsHot : BaseWebControl
	{
		private string string_0 = "CouponsIsHot.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string ShowCount
		{
			get;
			set;
		}
		public CouponsIsHot()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterDate");
			this.CouponsDataBind();
		}
		protected void CouponsDataBind()
		{
			try
			{
				int.Parse(this.ShowCount);
			}
			catch
			{
				this.ShowCount = "10";
			}
			ShopNum1_Coupon_Action shopNum1_Coupon_Action = (ShopNum1_Coupon_Action)LogicFactory.CreateShopNum1_Coupon_Action();
			DataTable couponTitleByBrowserCount = shopNum1_Coupon_Action.GetCouponTitleByBrowserCount(this.ShowCount);
			if (couponTitleByBrowserCount != null && couponTitleByBrowserCount.Rows.Count > 0)
			{
				this.repeater_0.DataSource = couponTitleByBrowserCount.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
