using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SubstationError : BaseWebControl
	{
		private string string_0 = "SubstationError.ascx";
		private HtmlAnchor htmlAnchor_0;
		private Label label_0;
		private HiddenField hiddenField_0;
		public SubstationError()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("aMainUrl");
			this.label_0 = (Label)skin.FindControl("LabelMainCity");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldCityUrl");
			this.BindData();
		}
		public void BindData()
		{
			try
			{
				string value = ShopSettings.GetValue("SubstationCityMode");
				string value2 = ShopSettings.GetValue("DefaultMainCityUrl");
				if (value == "0")
				{
					this.htmlAnchor_0.HRef = "http://" + ShopSettings.siteDomain;
					this.label_0.Text = "全国站";
					this.hiddenField_0.Value = "http://" + ShopSettings.siteDomain;
				}
				else if (value == "1")
				{
					this.htmlAnchor_0.HRef = value2;
					this.label_0.Text = "默认城市分站";
					this.hiddenField_0.Value = value2;
				}
				else
				{
					this.htmlAnchor_0.HRef = "http://" + ShopSettings.siteDomain;
					this.label_0.Text = "全国站";
					this.hiddenField_0.Value = "http://" + ShopSettings.siteDomain;
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
