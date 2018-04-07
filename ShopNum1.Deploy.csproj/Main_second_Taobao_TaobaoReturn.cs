using ShopNum1.Common;
using ShopNum1.Second;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
public class Main_second_Taobao_TaobaoReturn : Page, IRequiresSessionState
{
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
		if (this.Page.Request.QueryString["code"] != null)
		{
			ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness = new ShopNum1_SecondTypeBussiness();
			string code = this.Page.Request.QueryString["code"].ToString();
			DataTable model = shopNum1_SecondTypeBussiness.GetModel(6);
			ShopNum1_TaobaoOAuthMessage accessTokenByAuthorizationCode = new ShopNum1_TaobaoOAuthClient().GetAccessTokenByAuthorizationCode(model.Rows[0]["AppID"].ToString(), model.Rows[0]["AppSecret"].ToString(), code, "http://" + ConfigurationManager.AppSettings["Domain"] + "/API/Second/Taobao/TaobaoReturn.aspx");
			string text = Guid.NewGuid().ToString();
			HttpCookie httpCookie = HttpSecureCookie.Encode(new HttpCookie("ThirdpartyLoginCheck")
			{
				Values = 
				{

					{
						"Check",
						text
					}
				}
			});
			httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
			HttpContext.Current.Response.AppendCookie(httpCookie);
			if (accessTokenByAuthorizationCode != null)
			{
				base.Response.Redirect(string.Concat(new object[]
				{
					"~/threelogin.aspx?authorizecode=shopnum1&check=",
					text,
					"&type=5&access_token=",
					accessTokenByAuthorizationCode.Access_token,
					"&user_id=",
					accessTokenByAuthorizationCode.Taobao_user_id
				}));
			}
		}
	}
}
