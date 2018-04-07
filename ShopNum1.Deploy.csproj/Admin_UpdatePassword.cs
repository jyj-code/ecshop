using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_UpdatePassword : PageBase, IRequiresSessionState
{
	protected ToolkitScriptManager ToolkitScriptManager2;
	protected Label LabelPageTitle;
	protected TextBox TextBoxOldPwd;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected TextBox TextBoxNewPwd;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected TextBox TextBoxRePwd;
	protected Label Label5;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidatorRePwd;
	protected CompareValidator CompareValidatorRePwd;
	protected Button ButtonPwd;
	protected HtmlForm form1;
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
	}
	protected void ButtonPwd_Click(object sender, EventArgs e)
	{
		ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
		int num = shopNum1_User_Action.CheckLogin(base.ShopNum1LoginID.Trim(), Encryption.GetSHA1SecondHash(this.TextBoxOldPwd.Text.Trim()), 0);
		if (this.TextBoxNewPwd.Text != this.TextBoxRePwd.Text)
		{
			MessageBox.Show("两次密码不一致！");
		}
		else if (num > 0)
		{
			int num2 = shopNum1_User_Action.UpdatePwd(base.ShopNum1LoginID.Trim(), Encryption.GetSHA1SecondHash(this.TextBoxOldPwd.Text.Trim()), Encryption.GetSHA1SecondHash(this.TextBoxNewPwd.Text));
			if (num2 > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "修改密码成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "UpdatePassword.aspx",
					Date = DateTime.Now
				});
				MessageBox.Show("修改成功！");
			}
		}
		else
		{
			MessageBox.Show("原密码不正确！");
		}
	}
}
