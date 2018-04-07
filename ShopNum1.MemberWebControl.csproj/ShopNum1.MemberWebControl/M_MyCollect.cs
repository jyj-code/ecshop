using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_MyCollect : BaseMemberWebControl
	{
		private string string_0 = "M_MyCollect.ascx";
		private Panel panel_0;
		private Panel panel_1;
		public M_MyCollect()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.panel_0 = (Panel)skin.FindControl("PanelMemberProductCollect");
			this.panel_1 = (Panel)skin.FindControl("PanelShopCollect");
			string a = (ShopNum1.Common.Common.ReqStr("type") == "") ? "0" : ShopNum1.Common.Common.ReqStr("type");
			if (a == "0")
			{
				this.panel_0.Visible = true;
				this.panel_1.Visible = false;
			}
			else if (a == "1")
			{
				this.panel_0.Visible = false;
				this.panel_1.Visible = true;
			}
		}
	}
}
