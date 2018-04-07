using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CouponsList : BaseWebControl
	{
		private string string_0 = "CouponsList.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public CouponsList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
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
			ShopNum1_Coupon_Action shopNum1_Coupon_Action = new ShopNum1_Coupon_Action();
			DataTable couponTitleByAdressCode;
			if (this.string_1 == "all")
			{
				couponTitleByAdressCode = shopNum1_Coupon_Action.GetCouponTitleByAdressCode("-1", this.ShowCount);
			}
			else
			{
				couponTitleByAdressCode = shopNum1_Coupon_Action.GetCouponTitleByAdressCode("-1", this.ShowCount, this.string_1);
			}
			if (couponTitleByAdressCode != null && couponTitleByAdressCode.Rows.Count > 0)
			{
				this.repeater_0.DataSource = couponTitleByAdressCode.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public static string check(object Hot, object New)
		{
			string result = "0";
			if (Hot.ToString() == "1")
			{
				result = "1";
			}
			else if (New.ToString() == "1")
			{
				result = "2";
			}
			return result;
		}
	}
}
