using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_BindEmail : BaseMemberWebControl
	{
		private string string_0 = "A_BindEmail.ascx";
		private Button button_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlInputText htmlInputText_0;
		private Label label_0;
		private string string_1 = string.Empty;
		public A_BindEmail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.button_0 = (Button)skin.FindControl("btn_Next");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("M_code");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_Email");
			this.label_0 = (Label)skin.FindControl("Lab_MemLoginID");
			this.label_0.Text = this.MemLoginID;
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divProEmail");
			this.htmlInputHidden_0.Value = Common.ReqStr("Email");
			this.string_1 = Common.ReqStr("type");
			if (this.string_1 == "2")
			{
				this.htmlGenericControl_0.Visible = true;
			}
			else
			{
				this.htmlGenericControl_0.Visible = false;
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string value = this.htmlInputText_0.Value;
			this.method_0();
			if (this.string_1 == "1" || this.string_1 == "2")
			{
				this.method_1(value);
				this.Page.Response.Redirect("A_MemInfo.aspx");
			}
			else if (this.string_1 == "3")
			{
				this.Page.Response.Redirect("A_UpPayPwd.aspx?Email=" + this.htmlInputHidden_0.Value + "&key=" + value);
			}
			else
			{
				this.method_1(value);
				this.Page.Response.Redirect("A_PwdSer.aspx");
			}
		}
		private void method_0()
		{
			if (!string.IsNullOrEmpty(this.htmlInputHidden_0.Value))
			{
				Common.UpdateInfo("Email='" + this.htmlInputHidden_0.Value + "', IsEmailActivation=1", "ShopNum1_Member", " and  MemLoginID='" + this.MemLoginID + "'");
			}
		}
		private void method_1(string string_2)
		{
			ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
			shopNum1_MemberActivate_Action.DeleteKey(this.MemLoginID, string_2);
		}
	}
}
