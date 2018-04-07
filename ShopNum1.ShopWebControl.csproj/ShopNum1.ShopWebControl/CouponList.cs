using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class CouponList : BaseWebControl
	{
		private string string_0 = "CouponList.ascx";
		private Repeater repeater_0;
		private HtmlImage htmlImage_0;
		private HtmlImage htmlImage_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		private string MemLoginID
		{
			get;
			set;
		}
		private string ShopID
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public CouponList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.ShopID).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();
			DataTable dataTable = shop_Coupon_Action.SearchCouponByMemloginID(this.ShowCount, this.MemLoginID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
				for (int i = 0; i < this.repeater_0.Items.Count; i++)
				{
					this.htmlImage_1 = (HtmlImage)this.repeater_0.Items[i].FindControl("ImgCoupon");
					this.htmlImage_1.Src = this.Page.ResolveUrl(this.GetWebFilePath() + dataTable.Rows[i]["ImgPath"].ToString());
					this.htmlImage_0 = (HtmlImage)this.repeater_0.Items[i].FindControl("imgIsEffective");
					if (dataTable.Rows[i]["IsEffective"].ToString() == "0" || Convert.ToDateTime(dataTable.Rows[i]["EndTime"].ToString()) < DateTime.Now)
					{
						this.htmlImage_0.Src = "../Images/unineffect.gif";
					}
					else
					{
						this.htmlImage_0.Src = "../Images/ineffect.gif";
					}
				}
			}
		}
		protected string GetWebFilePath()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			string shopOpenTimeByShopID = shopNum1_ShopInfoList_Action.GetShopOpenTimeByShopID(this.ShopID);
			string text = string.Empty;
			if (shopOpenTimeByShopID != "")
			{
				string text2 = DateTime.Parse(shopOpenTimeByShopID).ToString("yyyy-MM-dd");
				text = string.Concat(new string[]
				{
					"~/ImgUpload/",
					text2.Replace("-", "/"),
					"/shop",
					this.ShopID,
					"/Coupon/"
				});
				if (!Directory.Exists(HttpContext.Current.Server.MapPath(text)))
				{
					Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text));
				}
			}
			return text;
		}
	}
}
