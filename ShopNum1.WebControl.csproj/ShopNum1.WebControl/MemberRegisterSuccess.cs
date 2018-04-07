using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class MemberRegisterSuccess : BaseWebControl, ICallbackEventHandler
	{
		private string string_0 = "MemberRegisterSuccess.ascx";
		private HiddenField hiddenField_0;
		private LinkButton linkButton_0;
		private Panel panel_0;
		private Panel panel_1;
		private Panel panel_2;
		private Panel panel_3;
		private Label label_0;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		public MemberRegisterSuccess()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldIsEmailYz");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonLogin");
			this.panel_0 = (Panel)skin.FindControl("PanelYes");
			this.panel_1 = (Panel)skin.FindControl("PanelNO");
			this.panel_2 = (Panel)skin.FindControl("PanelSan");
			this.panel_3 = (Panel)skin.FindControl("PanelMobile");
			this.label_0 = (Label)skin.FindControl("LabelUserName");
			if (!this.Page.IsPostBack)
			{
				this.linkButton_0.PostBackUrl = GetPageName.RetDomainUrl("Login");
				if (this.Page.Request.QueryString["type"] != null)
				{
					this.string_1 = this.Page.Request.QueryString["type"].ToString();
					if (this.string_1 == "1")
					{
						this.hiddenField_0.Value = "1";
						this.panel_0.Visible = true;
						this.panel_1.Visible = false;
						this.panel_2.Visible = false;
						this.panel_3.Visible = false;
					}
					else if (this.string_1 == "0")
					{
						this.hiddenField_0.Value = "1";
						this.panel_0.Visible = false;
						this.panel_1.Visible = true;
						this.panel_2.Visible = false;
					}
					else if (this.string_1 == "2" && this.Page.Request.QueryString["MemLoginID"] != null)
					{
						if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
						{
							this.Page.Response.Write("<script>window.top.location.target= '_blank '; window.top.location.href='" + GetPageName.RetUrl("Login") + "' </script>");
						}
						this.panel_0.Visible = false;
						this.panel_1.Visible = false;
						this.panel_2.Visible = true;
						this.panel_3.Visible = false;
						HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
						HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
						this.string_2 = httpCookie.Values["MemLoginID"].ToString();
						this.label_0.Text = httpCookie.Values["MemLoginID"].ToString();
					}
				}
			}
		}
		public string GetCallbackResult()
		{
			throw new NotImplementedException();
		}
		public void RaiseCallbackEvent(string eventArgument)
		{
			throw new NotImplementedException();
		}
	}
}
