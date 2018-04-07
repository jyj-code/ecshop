using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_ChangePwdWay : BaseMemberWebControl
	{
		private string string_0 = "A_ChangePwdWay.ascx";
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		public A_ChangePwdWay()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonEmail");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonMobile");
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable memInfo = shopNum1_Member_Action.GetMemInfo(this.MemLoginID);
			string a = memInfo.Rows[0]["IsEmailActivation"].ToString();
			string str = memInfo.Rows[0]["Email"].ToString();
			string a2 = memInfo.Rows[0]["IsMobileActivation"].ToString();
			string str2 = memInfo.Rows[0]["Mobile"].ToString();
			if (a != "1")
			{
				this.linkButton_0.Text = "绑定邮箱之后，可以设置交易密码";
				this.linkButton_0.PostBackUrl = "../A_BindEmail.aspx?Type=3&Email=" + str;
			}
			else
			{
				this.linkButton_0.PostBackUrl = "../A_CheckEmail.aspx";
			}
			if (a2 != "1")
			{
				this.linkButton_1.Text = "账号绑定手机之后，可以设置交易密码";
				this.linkButton_1.PostBackUrl = "../A_BindMobile.aspx?Type=3&Mobile=" + str2;
			}
			else
			{
				this.linkButton_1.PostBackUrl = "../A_CheckMobile.aspx";
			}
		}
	}
}
