using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Head : BaseMemberWebControl
	{
		private string string_0 = "S_Head.ascx";
		private Label label_0;
		private LinkButton linkButton_0;
		private Label label_1;
		private Label label_2;
		private Image image_0;
		public S_Head()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.image_0 = (Image)skin.FindControl("ImageShopLogo");
			this.label_0 = (Label)skin.FindControl("LabelMemberID");
			this.linkButton_0 = (LinkButton)skin.FindControl("ButtonOut");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.label_0.Text = this.MemLoginID;
			this.label_1 = (Label)skin.FindControl("LabelMsg");
			this.label_2 = (Label)skin.FindControl("LabelGouWuChe");
			try
			{
				this.image_0.ImageUrl = ShopSettings.GetValue("MemberLogo");
			}
			catch (Exception)
			{
			}
			if (!this.Page.IsPostBack)
			{
				this.GetDataInfo();
			}
		}
		public void GetDataInfo()
		{
			this.label_1.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_MemberMessage", " and IsDeleted=0 and IsRead=0  AND  Reloginid='" + this.MemLoginID + "' ");
			this.label_2.Text = ShopNum1.Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Cart", "  AND   MemLoginId='" + this.MemLoginID + "'    ");
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			HttpCookie httpCookie = this.Page.Request.Cookies["MemberLoginCookie"];
			httpCookie.Values.Clear();
			httpCookie.Expires = DateTime.Now.AddDays(-6.0);
			httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
			this.Page.Response.Cookies.Add(httpCookie);
			this.Page.Response.Redirect("/default.html");
		}
	}
}
