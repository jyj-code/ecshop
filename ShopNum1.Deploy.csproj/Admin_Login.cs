using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Login : PageBase, IRequiresSessionState
{
	protected Label LabelLoginID;
	protected TextBox TextBoxLoginID;
	protected Label LabelPwd;
	protected TextBox TextBoxPwd;
	protected Button ButtonLogin;
	protected Label Message;
	protected Label LabelCheckCode;
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
	}
	protected void ButtonLogin_Click(object sender, EventArgs e)
	{
		string loginID = this.TextBoxLoginID.Text.Trim().ToLower();
		string sHA1SecondHash = Encryption.GetSHA1SecondHash(this.TextBoxPwd.Text.Trim());
		int num = this.CheckLogin(loginID, sHA1SecondHash);
		if (num > 0)
		{
			DataTable userInfo = this.GetUserInfo(this.TextBoxLoginID.Text.Trim().ToLower());
			HttpCookie httpCookie = new HttpCookie("AdminLoginCookie");
			this.Session["AdminLoginCookie"] = this.TextBoxLoginID.Text.Trim().ToLower();
			httpCookie.Values.Add("LoginID", this.TextBoxLoginID.Text.Trim().ToLower());
			httpCookie.Values.Add("Guid", userInfo.Rows[0]["Guid"].ToString());
			httpCookie.Values.Add("PeopleType", userInfo.Rows[0]["PeopleType"].ToString());
			httpCookie.Values.Add("SubstationID", "all");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "后台用户登陆系统成功",
				OperatorID = this.TextBoxLoginID.Text.Trim().ToLower(),
				IP = Globals.IPAddress,
				PageName = "login.aspx",
				Date = DateTime.Now
			});
			HttpCookie httpCookie2 = new HttpCookie("AdminLoginDateCookie");
			string value = string.Empty;
			value = Common.GetNameById("LastLoginTime", "ShopNum1_User", "   AND   LoginId='" + this.TextBoxLoginID.Text.Trim().ToLower() + "' ");
			if (string.IsNullOrEmpty(value))
			{
				value = DateTime.Now.ToString();
			}
			httpCookie2.Values.Add("LastLoginTime", value);
			HttpCookie httpCookie3 = HttpSecureCookie.Encode(httpCookie2);
			httpCookie3.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
			httpCookie3.Expires = DateTime.Now.AddYears(1);
			this.Page.Response.AppendCookie(httpCookie3);
			this.method_5(this.TextBoxLoginID.Text.Trim().ToLower());
			base.Response.Redirect("Index.aspx");
		}
		else
		{
			this.Message.Text = "登录失败！";
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = string.Concat(new string[]
				{
					"用户",
					this.TextBoxLoginID.Text.Trim().ToLower(),
					"尝试用错误密码",
					this.TextBoxPwd.Text.Trim(),
					"登陆系统,被拒绝!"
				}),
				OperatorID = this.TextBoxLoginID.Text.Trim().ToLower(),
				IP = Globals.IPAddress,
				PageName = "login.aspx",
				Date = DateTime.Now
			});
		}
	}
	protected int CheckLogin(string loginID, string string_5)
	{
		ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
		return shopNum1_User_Action.CheckLogin(loginID, string_5, 0);
	}
	protected DataTable GetUserInfo(string loginID)
	{
		ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
		return shopNum1_User_Action.GetUserByLoginID(loginID, 0);
	}
	private void method_5(string string_5)
	{
		ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
		shopNum1_User_Action.UpdateLoginInfo(new ShopNum1_User
		{
			LoginId = string_5,
			LastLoginTime = new DateTime?(DateTime.Now),
			LastLoginIP = Globals.IPAddress
		});
	}
}