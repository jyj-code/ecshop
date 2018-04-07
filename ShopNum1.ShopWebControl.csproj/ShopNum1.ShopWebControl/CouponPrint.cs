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
	public class CouponPrint : BaseWebControl
	{
		private string string_0 = "CouponPrint.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		private Literal literal_1;
		private HtmlAnchor htmlAnchor_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string CouponGuid
		{
			get;
			set;
		}
		private string Count
		{
			get;
			set;
		}
		private string ShopID
		{
			get;
			set;
		}
		public CouponPrint()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			this.CouponGuid = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.literal_0 = (Literal)skin.FindControl("LiteralCount");
			this.literal_1 = (Literal)skin.FindControl("LiteralPic");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("Aprint");
			this.htmlAnchor_0.ServerClick += new EventHandler(this.htmlAnchor_0_ServerClick);
			this.method_0();
		}
		private void htmlAnchor_0_ServerClick(object sender, EventArgs e)
		{
			string count = (this.Page.Request.QueryString["count"] == null) ? "2" : this.Page.Request.QueryString["count"].ToString();
			Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();
			shop_Coupon_Action.UpdataDownloadCountByGuid(this.CouponGuid, count);
		}
		private void method_0()
		{
			int num = int.Parse((this.Page.Request.QueryString["count"] == null) ? "2" : this.Page.Request.QueryString["count"].ToString());
			string text = string.Empty;
			Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)LogicFactory.CreateShop_Coupon_Action();
			DataTable dataTable = shop_Coupon_Action.SearchCouponByGuid(this.CouponGuid, this.ShopID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				string str = this.Page.ResolveUrl(dataTable.Rows[0]["ImgPath"].ToString());
				this.literal_0.Text = num.ToString();
				for (int i = 0; i < num; i++)
				{
					text = text + "<div class=\"ticket\"> <p><img alt=\"\" src=\"" + str + "\" width=\"294\" /></p><span><img alt=\"\" src=\"Themes/Skin_Default/Images/33.gif\" /></span> </div>";
				}
				this.literal_1.Text = text;
			}
		}
		protected string GetWebFilePath()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable openTimeByShopID = shop_ShopInfo_Action.GetOpenTimeByShopID(this.ShopID);
			string text = DateTime.Parse(openTimeByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			string text2 = string.Concat(new string[]
			{
				"/ImgUpload/",
				text.Replace("-", "/"),
				"/shop",
				this.ShopID,
				"/Coupon/"
			});
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(text2)))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text2));
			}
			return text2;
		}
	}
}
