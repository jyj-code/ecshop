using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class PasswordReminderUrl : BaseWebControl
	{
		private string string_0 = "PasswordReminderUrl.ascx";
		private Panel panel_0;
		private Panel panel_1;
		public PasswordReminderUrl()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.panel_0 = (Panel)skin.FindControl("PanelOK");
			this.panel_1 = (Panel)skin.FindControl("PanelNO");
			if (!this.Page.IsPostBack && this.Page.Request.QueryString["key"] != null && this.Page.Request.QueryString["type"] != null)
			{
				this.YZemail();
			}
			if (this.Page.IsPostBack && this.Page.Request.Form["__EmailEVENTTARGET"] == "ButtonFindPwdSubmit")
			{
				this.ButtonConfirm_Click(null, null);
			}
		}
		public void YZemail()
		{
			IShopNum1_MemberPwd_Action shopNum1_MemberPwd_Action = LogicFactory.CreateShopNum1_MemberPwd_Action();
			DataTable dataTable = shopNum1_MemberPwd_Action.CheckLink(this.Page.Request.QueryString["key"].ToString(), this.Page.Request.QueryString["type"]);
			if (dataTable.Rows.Count <= 0)
			{
				this.panel_1.Visible = true;
				this.panel_0.Visible = false;
			}
		}
		public void ButtonConfirm_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["type"] == null || this.Page.Request.QueryString["key"] == null)
			{
				if (ShopSettings.IsOverrideUrl)
				{
					this.Page.Response.Redirect("~/Login" + ShopSettings.overrideUrlName);
				}
				else
				{
					this.Page.Response.Redirect("~/Login.aspx");
				}
			}
			else
			{
				string text = this.Page.Request.Form["TextBoxPwd"];
				LogicFactory.CreateShopNum1_Member_Action();
				IShopNum1_MemberPwd_Action shopNum1_MemberPwd_Action = LogicFactory.CreateShopNum1_MemberPwd_Action();
				string empty = string.Empty;
				string input = string.Empty;
				input = text;
				ShopNum1_MemberPwd shopNum1_MemberPwd = new ShopNum1_MemberPwd();
				shopNum1_MemberPwd.MemberID = empty;
				shopNum1_MemberPwd.pwd = Encryption.GetMd5Hash(input);
				shopNum1_MemberPwd.pwdkey = Encryption.GetMd5SecondHash(DateTime.Now.AddDays(1.0).ToString() + new Random().Next().ToString()).Substring(0, 8);
				shopNum1_MemberPwd.type = 0;
				shopNum1_MemberPwd.extireTime = DateTime.Now.AddDays(1.0);
				shopNum1_MemberPwd.Email = empty;
				shopNum1_MemberPwd_Action.UpdatePwd(this.Page.Request.QueryString["key"].ToString(), this.Page.Request.QueryString["type"].ToString(), Encryption.GetMd5Hash(input));
				DataTable dataTable = shopNum1_MemberPwd_Action.ShopNum1MemberPwdExec(this.Page.Request.QueryString["key"].ToString(), this.Page.Request.QueryString["type"]);
				if (dataTable.Rows[0]["Result"].ToString() == "1")
				{
					if (ShopSettings.IsOverrideUrl)
					{
						this.Page.Response.Redirect("~/FindPasswordSuccess.html");
					}
					else
					{
						this.Page.Response.Redirect("~/FindPasswordSuccess.aspx");
					}
				}
				else
				{
					this.panel_1.Visible = true;
					this.panel_0.Visible = false;
				}
			}
		}
	}
}
