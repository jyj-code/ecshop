using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class IntegralLogin : BaseWebControl
	{
		private string string_0 = "IntegralLogin.ascx";
		private Image image_0;
		private Panel panel_0;
		private Panel panel_1;
		private Button button_0;
		private Label label_0;
		[CompilerGenerated]
		private string string_1;
		public string MemLoginID
		{
			get;
			set;
		}
		public IntegralLogin()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.image_0 = (Image)skin.FindControl("ImagePhoto");
			this.panel_0 = (Panel)skin.FindControl("PanelDiv");
			this.panel_1 = (Panel)skin.FindControl("PanelLogin");
			this.button_0 = (Button)skin.FindControl("LoginUser");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.label_0 = (Label)skin.FindControl("LabelScore");
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.panel_1.Visible = true;
				this.panel_0.Visible = false;
				ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
				try
				{
					DataTable scoreByMemLoginID = shopNum1_Shop_ScoreProduct_Action.GetScoreByMemLoginID(this.MemLoginID);
					DataTable photoByMemLoginID = shopNum1_Shop_ScoreProduct_Action.GetPhotoByMemLoginID(this.MemLoginID);
					if (scoreByMemLoginID != null && scoreByMemLoginID.Rows.Count > 0)
					{
						if (!string.IsNullOrEmpty(scoreByMemLoginID.Rows[0]["Score"].ToString()))
						{
							this.label_0.Text = scoreByMemLoginID.Rows[0]["Score"].ToString();
						}
						else
						{
							this.label_0.Text = "0";
						}
					}
					else
					{
						this.label_0.Text = "0";
					}
					if (photoByMemLoginID != null && photoByMemLoginID.Rows.Count > 0)
					{
						this.image_0.ImageUrl = photoByMemLoginID.Rows[0]["Photo"].ToString();
					}
					return;
				}
				catch (Exception)
				{
					this.label_0.Text = "0";
					return;
				}
			}
			this.panel_1.Visible = false;
			this.panel_0.Visible = true;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("/Login.html");
		}
	}
}
