using ShopNum1.Second;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
public class Main_Second_Baidu_BaiduReturn : Page, IRequiresSessionState
{
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
		if (this.Page.Request.QueryString["code"] != null)
		{
			ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness = new ShopNum1_SecondTypeBussiness();
			string code = this.Page.Request.QueryString["code"].ToString();
			DataTable model = shopNum1_SecondTypeBussiness.GetModel(2);
			ShopNum1_BaiduOAuthMessage accessTokenByAuthorizationCode = new ShopNum1_BaiduOAuthClient().GetAccessTokenByAuthorizationCode(model.Rows[0]["AppID"].ToString(), model.Rows[0]["AppSecret"].ToString(), code, "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Baidu/BaiduReturn.aspx");
			if (accessTokenByAuthorizationCode != null)
			{
				base.Response.Redirect("~/threelogin.aspx?type=2&access_token=" + accessTokenByAuthorizationCode.Access_token);
			}
		}
	}
}
