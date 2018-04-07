using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ProductSearchNofind : BaseWebControl
	{
		private string string_0 = "ProductSearchNofind.ascx";
		private Label label_0;
		[CompilerGenerated]
		private string string_1;
		public string ProtectName
		{
			get;
			set;
		}
		public ProductSearchNofind()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelProtectSearch");
			this.ProtectName = ((ShopNum1.Common.Common.ReqStr("search") == "") ? "" : ShopNum1.Common.Common.ReqStr("search"));
			if (this.ProtectName == "-1")
			{
				this.label_0.Text = "";
			}
			else
			{
				this.label_0.Text = "与“" + this.ProtectName.Trim() + "”";
			}
		}
	}
}
