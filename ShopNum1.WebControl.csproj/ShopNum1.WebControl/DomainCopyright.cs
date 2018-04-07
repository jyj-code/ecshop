using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class DomainCopyright : BaseWebControl
	{
		private string string_0 = "DomainCopyright.ascx";
		private Label label_0;
		private string string_1 = "all";
		public DomainCopyright()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.label_0 = (Label)skin.FindControl("labelButtomInfo");
			if (this.string_1 == "all")
			{
				this.label_0.Text = this.Page.Server.HtmlDecode(ShopSettings.GetValue("ButtomInfo"));
			}
			else
			{
				string value = string.Empty;
				try
				{
					value = CitySettings.GetValue("ButtomInfo", this.string_1);
				}
				catch (Exception)
				{
				}
				if (string.IsNullOrEmpty(value))
				{
					this.label_0.Text = this.Page.Server.HtmlDecode(ShopSettings.GetValue("ButtomInfo"));
				}
				else
				{
					this.label_0.Text = this.Page.Server.HtmlDecode(CitySettings.GetValue("ButtomInfo", this.string_1));
				}
			}
		}
	}
}
