using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_CreditDetails : BaseMemberWebControl
	{
		private string string_0 = "M_CreditDetails.ascx";
		private Panel panel_0;
		private Panel panel_1;
		public M_CreditDetails()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.panel_0 = (Panel)skin.FindControl("PanelRankScoreModifyLog");
			this.panel_1 = (Panel)skin.FindControl("PanelScoreModifyLog");
			string a = (ShopNum1.Common.Common.ReqStr("type") == "") ? "0" : ShopNum1.Common.Common.ReqStr("type");
			if (a == "0")
			{
				this.panel_1.Visible = true;
				this.panel_0.Visible = false;
			}
			else if (a == "1")
			{
				this.panel_1.Visible = false;
				this.panel_0.Visible = true;
			}
		}
	}
}
