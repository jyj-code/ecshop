using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_UpPayPwd : BaseMemberWebControl
	{
		private string string_0 = "A_UpPayPwd.ascx";
		private Label label_0;
		private HtmlInputPassword htmlInputPassword_0;
		private HtmlInputPassword htmlInputPassword_1;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private HtmlInputText htmlInputText_0;
		private Label label_1;
		private Label label_2;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		public string NewPayPwd
		{
			get;
			set;
		}
		public string RNewPayPwd
		{
			get;
			set;
		}
		public A_UpPayPwd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("Lab_MemLoginID");
			this.htmlInputPassword_0 = (HtmlInputPassword)skin.FindControl("Input_NewPayPwd");
			this.htmlInputPassword_1 = (HtmlInputPassword)skin.FindControl("Input_NewSecondPayPwd");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButton_Save");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.label_1 = (Label)skin.FindControl("Lab_MobileOrEmailValue");
			this.label_2 = (Label)skin.FindControl("Lab_MobileOrEmailText");
			this.string_1 = Common.ReqStr("key");
			this.label_0.Text = this.MemLoginID;
			if ((Common.ReqStr("Email") != null || Common.ReqStr("Mobile") != null) && this.string_1 != "")
			{
				try
				{
					this.string_2 = ((Common.ReqStr("Email") == "") ? "Mobile" : "Email");
					this.string_3 = ((Common.ReqStr("Email") == "") ? Common.ReqStr("Mobile") : Common.ReqStr("Email"));
					ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
					if (!shopNum1_MemberActivate_Action.CheckKey(this.string_2, this.MemLoginID, this.string_1, this.string_3))
					{
						if (this.string_2 == "Email")
						{
							this.Page.Response.Redirect("A_CheckEmail.aspx");
						}
						if (this.string_2 == "Mobile")
						{
							this.Page.Response.Redirect("A_CheckEmail.aspx");
						}
						else
						{
							this.Page.Response.Redirect("A_PwdSer.aspx");
						}
					}
					return;
				}
				catch
				{
					this.Page.Response.Redirect("A_PwdSer.aspx");
					return;
				}
			}
			this.Page.Response.Redirect("A_PwdSer.aspx");
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		private void method_0()
		{
			if (this.htmlInputPassword_0.Value == "")
			{
				MessageBox.Show("交易密码不能为空");
			}
			else if (this.htmlInputPassword_1.Value == "")
			{
				MessageBox.Show("重复的交易密码不能为空");
			}
			else if (this.htmlInputPassword_0.Value != this.htmlInputPassword_1.Value)
			{
				MessageBox.Show("两次输入的不一样");
			}
			else
			{
				string text = Encryption.GetMd5SecondHash(this.htmlInputPassword_0.Value.Trim()).ToString();
				string b = Encryption.GetMd5SecondHash(this.htmlInputPassword_1.Value.Trim()).ToString();
				if (text == b)
				{
					ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
					try
					{
						int num = shopNum1_Member_Action.UpdatePayPwd(this.MemLoginID, text);
						if (num > 0)
						{
							MessageBox.Show("设置成功");
							ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
							int num2 = shopNum1_MemberActivate_Action.DeleteKey(this.MemLoginID, this.string_1);
							if (num2 > 0)
							{
								this.Page.Response.Redirect("A_UpPayPwdSucceed.aspx");
							}
						}
						else
						{
							MessageBox.Show("设置失败");
						}
					}
					catch
					{
					}
				}
			}
		}
	}
}
