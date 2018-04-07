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
	public class A_UpPwd : BaseMemberWebControl
	{
		private string string_0 = "A_UpPwd.ascx";
		private HtmlInputPassword htmlInputPassword_0;
		private HtmlInputPassword htmlInputPassword_1;
		private HtmlInputText htmlInputText_0;
		private HtmlInputHidden htmlInputHidden_0;
		private Button button_0;
		private Button button_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private int int_0;
		public string OldPwd
		{
			get;
			set;
		}
		public string NewPwd
		{
			get;
			set;
		}
		public string RNewPwd
		{
			get;
			set;
		}
		public int Count
		{
			get;
			set;
		}
		public A_UpPwd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputPassword_0 = (HtmlInputPassword)skin.FindControl("Input_OldPwd");
			this.htmlInputPassword_1 = (HtmlInputPassword)skin.FindControl("Input_NewPwd");
			this.htmlInputText_0 = (HtmlInputPassword)skin.FindControl("Input_NewSecondPwd");
			this.button_0 = (Button)skin.FindControl("btn_UpPwd");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("btn_Back");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_Count");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			string text = Encryption.GetMd5Hash(this.htmlInputPassword_0.Value.Trim()).ToString();
			string text2 = Encryption.GetMd5Hash(this.htmlInputPassword_1.Value.Trim()).ToString();
			string b = Encryption.GetMd5Hash(this.htmlInputText_0.Value.Trim()).ToString();
			int num = shopNum1_Member_Action.CheckPassword(this.MemLoginID, text);
			if (num > 0)
			{
				if (text2 == b)
				{
					int num2 = shopNum1_Member_Action.UpdatePwd(this.MemLoginID, text2);
					if (num2 > 0)
					{
						MessageBox.Show("修改成功");
					}
					else
					{
						MessageBox.Show("修改失败");
					}
				}
			}
			else
			{
				MessageBox.Show("旧密码错误");
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("A_PwdSer.aspx");
		}
	}
}
