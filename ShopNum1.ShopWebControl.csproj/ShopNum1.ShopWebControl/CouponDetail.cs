using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Configuration;
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
	public class CouponDetail : BaseWebControl
	{
		private string string_0 = "CouponDetail.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		private Literal literal_1;
		private DropDownList dropDownList_0;
		private ImageButton imageButton_0;
		private HtmlImage htmlImage_0;
		private HtmlImage htmlImage_1;
		private HiddenField hiddenField_0;
		[CompilerGenerated]
		private string string_1;
		public string ShopID
		{
			get;
			set;
		}
		public CouponDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterDetail");
			this.literal_0 = (Literal)skin.FindControl("LiteralBrowserCount");
			this.literal_1 = (Literal)skin.FindControl("LiteralDownloadCount");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListPrint");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.hiddenField_0.Value = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
			this.htmlImage_0 = (HtmlImage)skin.FindControl("CouponImg");
			this.htmlImage_1 = (HtmlImage)skin.FindControl("imgIsEffective");
			this.imageButton_0 = (ImageButton)skin.FindControl("ImageButton");
			this.imageButton_0.Click += new ImageClickEventHandler(this.imageButton_0_Click);
			this.method_0();
			this.method_1();
		}
		private void imageButton_0_Click(object sender, ImageClickEventArgs e)
		{
			if (this.dropDownList_0.SelectedValue == "0")
			{
				this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "msg", "<script>alert('最少打印一张!');window.location.href=window.location.href;</script>", false);
			}
			else
			{
				try
				{
					Guid guid = new Guid(this.hiddenField_0.Value);
				}
				catch
				{
					MessageBox.Show("当前没有可以打印的优惠券！");
					return;
				}
				string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
				string shopURLByShopID = shopNum1_ShopInfoList_Action.GetShopURLByShopID(this.ShopID);
				string text2 = string.Empty;
				try
				{
					ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
					DataTable domainNameByShopID = shopNum1_SubstationManage_Action.GetDomainNameByShopID(this.ShopID);
					if (domainNameByShopID != null && domainNameByShopID.Rows.Count > 0)
					{
						text2 = domainNameByShopID.Rows[0][0].ToString();
					}
				}
				catch (Exception)
				{
					MessageBox.Show("分站数据查询错误！");
				}
				if (ShopSettings.IsOverrideUrl)
				{
					this.Page.Response.Redirect(string.Concat(new string[]
					{
						"http://",
						shopURLByShopID,
						".",
						text2,
						text,
						"/CouponPrint/",
						this.hiddenField_0.Value,
						ShopSettings.overrideUrlName,
						"?count=",
						this.dropDownList_0.SelectedValue
					}));
				}
				else
				{
					this.Page.Response.Redirect(string.Concat(new string[]
					{
						"http://",
						shopURLByShopID,
						".",
						text2,
						text,
						"/CouponPrint/",
						this.hiddenField_0.Value,
						".aspx?count=",
						this.dropDownList_0.SelectedValue
					}));
				}
			}
		}
		private void method_0()
		{
			Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
			DataTable dataTable = shop_Coupon_Action.SearchCouponByGuid(this.hiddenField_0.Value, this.ShopID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.htmlImage_0.Src = this.Page.ResolveUrl(dataTable.Rows[0]["ImgPath"].ToString());
				this.literal_0.Text = dataTable.Rows[0]["BrowserCount"].ToString();
				this.literal_1.Text = dataTable.Rows[0]["DownloadCount"].ToString();
				if (dataTable.Rows[0]["IsEffective"].ToString() == "0" || Convert.ToDateTime(dataTable.Rows[0]["EndTime"].ToString()) < DateTime.Now)
				{
					this.htmlImage_1.Src = "../Images/unineffect.gif";
				}
				else
				{
					this.htmlImage_1.Src = "../Images/ineffect.gif";
				}
				this.hiddenField_0.Value = dataTable.Rows[0]["Guid"].ToString();
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		protected string GetWebFilePath()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			DataTable openTimeByShopID = shop_ShopInfo_Action.GetOpenTimeByShopID(this.ShopID);
			string text = DateTime.Parse(openTimeByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			string text2 = string.Concat(new string[]
			{
				"~/ImgUpload/",
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
		private void method_1()
		{
			if (this.Page.Request.Cookies["Browser"] == null)
			{
				try
				{
					Guid guid = new Guid(this.hiddenField_0.Value);
				}
				catch
				{
					return;
				}
				Shop_Coupon_Action shop_Coupon_Action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();
				int num = shop_Coupon_Action.UpdateBrowserCount(this.hiddenField_0.Value);
				if (num > 0)
				{
					HttpCookie cookie = new HttpCookie("Browser");
					HttpCookie httpCookie = HttpSecureCookie.Encode(cookie);
					httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
					httpCookie.Expires = DateTime.Now.AddMinutes(30.0);
					this.Page.Response.AppendCookie(httpCookie);
				}
			}
		}
	}
}
