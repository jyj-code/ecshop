using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class Logo : BaseWebControl
	{
		private string string_0 = "Logo.ascx";
		private HtmlImage htmlImage_0;
		private HtmlAnchor htmlAnchor_0;
		private string string_1 = "all";
		public Logo()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlImage_0 = (HtmlImage)skin.FindControl("ImageOriginalImge");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("logoLink");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			if (this.string_1 == "all")
			{
				string value = ShopSettings.GetValue("Logo");
				this.htmlImage_0.Src = this.Page.ResolveUrl(value);
				string value2 = ShopSettings.GetValue("Link");
				this.htmlAnchor_0.HRef = value2;
			}
			else
			{
				string text = string.Empty;
				string hRef = string.Empty;
				try
				{
					text = CitySettings.GetValue("Logo", this.string_1);
				}
				catch (Exception)
				{
				}
				if (string.IsNullOrEmpty(text))
				{
					text = ShopSettings.GetValue("Logo");
					this.htmlImage_0.Src = this.Page.ResolveUrl(text);
					hRef = ShopSettings.GetValue("Link");
					this.htmlAnchor_0.HRef = hRef;
				}
				else
				{
					text = CitySettings.GetValue("Logo", this.string_1);
					this.htmlImage_0.Src = this.Page.ResolveUrl(text);
					hRef = CitySettings.GetValue("Link", this.string_1);
					this.htmlAnchor_0.HRef = hRef;
				}
			}
		}
	}
}
