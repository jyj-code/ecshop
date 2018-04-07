using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopCopyright : BaseWebControl
	{
		private string string_0 = "ShopCopyright.ascx";
		private Label label_0;
		private Label label_1;
		private HtmlGenericControl htmlGenericControl_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HiddenField hiddenField_0;
		public ShopCopyright()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("labelCopyright");
			this.label_1 = (Label)skin.FindControl("labelPoweredBy");
			this.hyperLink_1 = (HyperLink)skin.FindControl("HyperLinkUrl");
			this.hyperLink_0 = (HyperLink)skin.FindControl("HyperLinkCertification");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("CnzzCode");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldXmlPath");
			this.hiddenField_0.Value = this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
			if (this.Page.IsPostBack)
			{
			}
			if (this.htmlGenericControl_0 != null)
			{
				this.GetStatisticsCode();
			}
			if (this.label_1 != null)
			{
				this.method_0();
			}
			if (this.label_0 != null)
			{
				this.GetCopyRightInfo();
			}
			if (this.hyperLink_0 != null)
			{
				this.method_1();
			}
		}
		protected void GetCopyRightInfo()
		{
		}
		protected void GetStatisticsCode()
		{
			this.htmlGenericControl_0.InnerHtml = this.Page.Server.HtmlDecode(ShopSettings.GetValue("StatisticsCode"));
		}
		private void method_0()
		{
			this.hyperLink_1.NavigateUrl = "http://www.shopnum1.com/";
			this.label_1.Text = "Powered by ShopNum1[GroupFly]";
		}
		private void method_1()
		{
		}
	}
}
