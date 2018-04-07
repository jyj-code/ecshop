using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_Comment : BaseMemberWebControl
	{
		private string string_0 = "M_Comment.ascx";
		private Panel panel_0;
		private Panel panel_1;
		private Panel panel_2;
		private Panel panel_3;
		private Panel panel_4;
		public M_Comment()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.panel_0 = (Panel)skin.FindControl("PanelComment1");
			this.panel_1 = (Panel)skin.FindControl("PanelComment2");
			this.panel_2 = (Panel)skin.FindControl("PanelComment3");
			this.panel_3 = (Panel)skin.FindControl("PanelComment4");
			this.panel_4 = (Panel)skin.FindControl("PanelComment5");
			string text = (ShopNum1.Common.Common.ReqStr("type") == "") ? "0" : ShopNum1.Common.Common.ReqStr("type");
			string text2 = text;
			if (text2 != null)
			{
				if (text2 == "0")
				{
					this.panel_0.Visible = true;
					return;
				}
				if (text2 == "1")
				{
					this.panel_1.Visible = true;
					return;
				}
				if (text2 == "2")
				{
					this.panel_2.Visible = true;
					return;
				}
				if (text2 == "3")
				{
					this.panel_3.Visible = true;
					return;
				}
				if (text2 == "4")
				{
					this.panel_4.Visible = true;
					return;
				}
			}
			this.panel_0.Visible = true;
		}
	}
}
