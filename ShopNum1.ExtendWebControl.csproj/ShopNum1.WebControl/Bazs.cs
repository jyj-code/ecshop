using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class Bazs : BaseWebControl
	{
		private string string_0 = "Bazs.ascx";
		private Label label_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HyperLink hyperLink_0;
		public Bazs()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("labelBazs");
			this.hyperLink_0 = (HyperLink)skin.FindControl("HyperLinkUrl");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("CnzzCode");
			if (this.Page.IsPostBack)
			{
			}
			if (this.label_0 != null)
			{
				this.GetBazs();
				this.method_0();
			}
		}
		protected void GetBazs()
		{
			this.label_0.Text = this.Page.Server.HtmlDecode(ShopSettings.GetValue("ICPNum"));
		}
		protected void GetStatisticsCode()
		{
			this.htmlGenericControl_0.InnerHtml = this.Page.Server.HtmlDecode(ShopSettings.GetValue("StatisticsCode"));
		}
		private void method_0()
		{
			this.hyperLink_0.NavigateUrl = "http://www.miibeian.gov.cn/";
		}
	}
}
