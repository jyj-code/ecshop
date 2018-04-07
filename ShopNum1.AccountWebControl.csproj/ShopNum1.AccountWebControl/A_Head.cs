using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_Head : BaseMemberWebControl
	{
		private string string_0 = "A_Head.ascx";
		private Label label_0;
		private LinkButton linkButton_0;
		private Label label_1;
		private Label label_2;
		private Image image_0;
		public A_Head()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.linkButton_0 = (LinkButton)skin.FindControl("ButtonOut");
			this.label_0 = (Label)skin.FindControl("LabelMemberID");
			this.label_0.Text = this.MemLoginID;
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.label_1 = (Label)skin.FindControl("LabelMsg");
			this.label_2 = (Label)skin.FindControl("LabelGouWuChe");
			this.image_0 = (Image)skin.FindControl("ImageShopLogo");
			try
			{
				this.image_0.ImageUrl = ShopSettings.GetValue("MemberLogo");
			}
			catch (Exception)
			{
			}
			this.GetDataInfo();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie httpCookie = this.Page.Request.Cookies["MemberLoginCookie"];
				httpCookie.Values.Clear();
				httpCookie.Expires = Convert.ToDateTime(DateTime.Now.AddDays(-6.0).ToString("yyyy-MM-dd HH:mm:ss"));
				httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
				this.Page.Response.Cookies.Add(httpCookie);
				this.Page.Response.Redirect("/default.html");
			}
		}
		public void GetDataInfo()
		{
			this.label_1.Text = Common.GetNameById("COUNT(Guid)", "ShopNum1_UserMessage", " and IsDeleted=0 and IsRead=0  AND  ReceiveID='" + this.MemLoginID + "' ");
			this.label_2.Text = Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Cart", "  AND   MemLoginId='" + this.MemLoginID + "'    ");
		}
	}
}
