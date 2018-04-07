using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopCollect : BaseWebControl
	{
		private string string_0 = "ShopCollect.ascx";
		private ImageButton imageButton_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string MemLoginID
		{
			get;
			set;
		}
		public string MemberLoginID
		{
			get;
			set;
		}
		public string ShopID
		{
			get;
			set;
		}
		public ShopCollect()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.imageButton_0 = (ImageButton)skin.FindControl("ImageButtonShopCollect");
			this.imageButton_0.Click += new ImageClickEventHandler(this.imageButton_0_Click);
			if (this.Page.IsPostBack)
			{
			}
		}
		private void imageButton_0_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
				this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.ShopID).ToString();
				if (this.MemLoginID == this.MemberLoginID)
				{
					MessageBox.Show("您不能收藏自己的店铺！");
				}
				else
				{
					Shop_Collect_Action shop_Collect_Action = (Shop_Collect_Action)LogicFactory.CreateShop_Collect_Action();
					if (shop_Collect_Action.AddShopCollect(this.MemberLoginID, this.ShopID) > 0)
					{
						MessageBox.Show("收藏成功");
						shop_Collect_Action.ShopCollectNum(this.MemLoginID);
					}
					else
					{
						MessageBox.Show("已收藏该店");
					}
				}
			}
			else
			{
				GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再收藏店铺！");
			}
		}
	}
}
