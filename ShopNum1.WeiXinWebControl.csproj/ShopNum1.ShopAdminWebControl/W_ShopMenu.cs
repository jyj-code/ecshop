using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopMenu : BaseShopWebControl
	{
		private string string_0 = "W_ShopMenu.ascx";
		private Repeater repeater_0;
		public W_ShopMenu()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("rep_menu");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("rep_chirldmenu");
				int int_ = Convert.ToInt32((e.Item.DataItem as DataRowView).Row["ID"]);
				IShopNum1_Weixin_ShopMenu_Active shopNum1_Weixin_ShopMenu_Active = new ShopNum1_Weixin_ShopMenu_Active();
				repeater.DataSource = shopNum1_Weixin_ShopMenu_Active.Select_MenuByPid(this.MemLoginID, int_);
				repeater.DataBind();
			}
		}
		private void method_0()
		{
			IShopNum1_Weixin_ShopMenu_Active shopNum1_Weixin_ShopMenu_Active = new ShopNum1_Weixin_ShopMenu_Active();
			this.repeater_0.DataSource = shopNum1_Weixin_ShopMenu_Active.Select_MenuByPid(this.MemLoginID, 0);
			this.repeater_0.DataBind();
		}
	}
}
