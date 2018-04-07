using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SpellBuyListNofind : BaseWebControl
	{
		private string string_0 = "SpellBuyListNofind.ascx";
		private Label label_0;
		[CompilerGenerated]
		private string string_1;
		public string ProtectName
		{
			get;
			set;
		}
		public SpellBuyListNofind()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelProtectSearch");
			this.ProtectName = ((this.Page.Request.QueryString["search"] == null) ? "" : this.Page.Request.QueryString["search"].ToString());
			this.label_0.Text = this.ProtectName.Trim();
		}
	}
}
