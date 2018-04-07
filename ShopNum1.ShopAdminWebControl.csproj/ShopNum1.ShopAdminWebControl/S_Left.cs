using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Left : BaseMemberWebControl
	{
		private string string_0 = "S_Left.ascx";
		private HtmlAnchor htmlAnchor_0;
		private HtmlAnchor htmlAnchor_1;
		private Panel panel_0;
		private Panel panel_1;
		public S_Left()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.panel_0 = (Panel)skin.FindControl("PanelScroe");
			this.panel_1 = (Panel)skin.FindControl("panShowWeixin");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("ScoreOrder");
			this.htmlAnchor_1 = (HtmlAnchor)skin.FindControl("ScoreProduct");
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("isnull(cast(IsIntegralShop as varchar(10)),0)+'|'+isnull(cast(IsWeixin as varchar(10)),0)", "ShopNum1_ShopInfo", "  AND  MemLoginID='" + this.MemLoginID + "'");
				if (nameById != "")
				{
					this.panel_0.Visible = false;
					this.htmlAnchor_0.Visible = false;
					this.htmlAnchor_1.Visible = false;
					this.panel_1.Visible = false;
					if (nameById.Split(new char[]
					{
						'|'
					})[0] == "1")
					{
						this.htmlAnchor_0.Visible = true;
						this.htmlAnchor_1.Visible = true;
						this.panel_0.Visible = true;
					}
					if (nameById.Split(new char[]
					{
						'|'
					})[1] == "1")
					{
						this.panel_1.Visible = true;
					}
				}
			}
			catch
			{
				this.panel_0.Visible = false;
				this.htmlAnchor_0.Visible = false;
				this.htmlAnchor_1.Visible = false;
				this.panel_1.Visible = false;
			}
		}
	}
}
