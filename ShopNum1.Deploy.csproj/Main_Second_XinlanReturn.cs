using ShopNum1.Second;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
public class Main_Second_XinlanReturn : Page, IRequiresSessionState
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
			DataTable model = shopNum1_SecondTypeBussiness.GetModel(3);
			try
			{
				ShopNum1_XinLanOAuthMessage accessTokenByAppkeySecret = new ShopNum1_XinlanOAuthClient().GetAccessTokenByAppkeySecret(model.Rows[0]["AppID"].ToString(), model.Rows[0]["AppSecret"].ToString(), "http://" + ConfigurationManager.AppSettings["Domain"] + "/Main/Second/Xinlan/XinlanReturn.aspx", code);
				if (accessTokenByAppkeySecret != null)
				{
					base.Response.Redirect("~/threelogin.aspx?type=3&access_token=" + accessTokenByAppkeySecret.access_token + "&uid=" + accessTokenByAppkeySecret.uid);
				}
				return;
			}
			catch (ShopNum1_XinlanOAuthException ex)
			{
				base.Response.Write(ex.error + ex.Message + ex.error_description + ex.error_code);
				return;
			}
		}
		if (base.Request.QueryString["error_uri"] != null)
		{
			base.Response.Redirect("~/default.html");
		}
	}
}
