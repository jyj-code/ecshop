using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopInfo : BaseShopWebControl
	{
		private string string_0 = "S_ShopInfo.ascx";
		private Panel panel_0;
		private Panel panel_1;
		private Panel panel_2;
		private Panel panel_3;
		public S_ShopInfo()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.panel_0 = (Panel)skin.FindControl("PanelShowSettings");
			this.panel_1 = (Panel)skin.FindControl("PanelCompany");
			this.panel_2 = (Panel)skin.FindControl("PanelClassify");
			this.panel_3 = (Panel)skin.FindControl("PanelShopMap");
			if (this.Page.Request.QueryString["type"] != null)
			{
				string text = this.Page.Request.QueryString["type"].ToString();
				if (text != null)
				{
					if (text == "0")
					{
						this.panel_0.Visible = true;
						return;
					}
					if (text == "1")
					{
						this.panel_1.Visible = true;
						return;
					}
					if (text == "2")
					{
						this.panel_2.Visible = true;
						return;
					}
					if (text == "3")
					{
						this.panel_3.Visible = true;
						return;
					}
				}
				this.panel_0.Visible = true;
			}
			else
			{
				this.panel_0.Visible = true;
			}
		}
	}
}
