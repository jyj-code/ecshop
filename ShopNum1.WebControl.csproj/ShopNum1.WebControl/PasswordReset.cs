using ShopNum1.BusinessLogic;
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
	public class PasswordReset : BaseWebControl
	{
		private string string_0 = "PasswordReset.ascx";
		private Panel panel_0;
		private Panel panel_1;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Button button_0;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		public PasswordReset()
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
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxPwd");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxPwd2");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldType");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldMemID");
			this.hiddenField_2 = (skin.FindControl("HdFieldMobile") as HiddenField);
			this.button_0 = (Button)skin.FindControl("ButtonFindPwdSubmit");
			this.button_0.Click += new EventHandler(this.ButtonFindPwdSubmit_Click);
			if (!this.Page.IsPostBack && this.Page.Request.QueryString["key"] != null && this.Page.Request.QueryString["type"] != null)
			{
				this.YZemail();
				this.hiddenField_0.Value = "0";
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
				this.hiddenField_0.Value = "1";
			}
			else
			{
				this.hiddenField_0.Value = "0";
			}
		}
		public void ButtonFindPwdSubmit_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["type"] == null || this.Page.Request.QueryString["key"] == null)
			{
				if (this.hiddenField_0.Value == "5")
				{
					string str = string.Empty;
					Random random = new Random();
					for (int i = 0; i < 7; i++)
					{
						str += random.Next(0, 9).ToString();
					}
					ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
					int num = shopNum1_Member_Action.UpdatePwd(this.hiddenField_1.Value.Trim(), Encryption.GetMd5Hash(this.textBox_0.Text.Trim()));
					if (num == 1)
					{
						shopNum1_Member_Action.DeleteMemberActivate(this.hiddenField_2.Value);
						this.hiddenField_0.Value = "4";
					}
					else
					{
						this.panel_1.Visible = true;
						this.panel_0.Visible = false;
					}
				}
				else if (ShopSettings.IsOverrideUrl)
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
				string text = this.textBox_0.Text.Trim();
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
					this.hiddenField_0.Value = "4";
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
