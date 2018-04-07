using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_PageGo : BaseShopWebControl
	{
		private string string_0 = "S_PageGo.ascx";
		public S_PageGo()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string text = ShopNum1.Common.Common.ReqStr("pagetype");
			string text2 = text;
			switch (text2)
			{
			case "0":
				this.Page.Response.Redirect("S_SellGoods_One.aspx?sign=go&op=add&step=one");
				break;
			case "1":
				this.Page.Response.Redirect("TbTop/TbAuthorization.aspx");
				break;
			case "2":
				this.Page.Response.Redirect("TbTop/TbStep_Set.aspx");
				break;
			case "3":
				this.Page.Response.Redirect("TbTop/TbProductCategory_List.aspx");
				break;
			case "4":
				this.Page.Response.Redirect("TbTop/TbToSite_Operate.aspx");
				break;
			case "5":
				this.Page.Response.Redirect("TbTop/TbPrdouctView.aspx");
				break;
			case "6":
				this.Page.Response.Redirect("TbTop/TbOrderView.aspx");
				break;
			case "7":
				this.Page.Response.Redirect("TbTop/TbRemoveShopBind.aspx");
				break;
			case "8":
				this.Page.Response.Redirect("TbTop/TbSetAppKey.aspx");
				break;
			}
		}
	}
}
