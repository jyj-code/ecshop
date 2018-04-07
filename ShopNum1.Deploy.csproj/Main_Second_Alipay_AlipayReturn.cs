using ShopNum1.Second;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
public class Main_Second_Alipay_AlipayReturn : Page, IRequiresSessionState
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
		SortedDictionary<string, string> requestGet = this.GetRequestGet();
		ShopNum1_Alipay_config shopNum1_Alipay_config = new ShopNum1_Alipay_config();
		string partner = shopNum1_Alipay_config.Partner;
		string key = shopNum1_Alipay_config.Key;
		string input_charset = shopNum1_Alipay_config.Input_charset;
		string sign_type = shopNum1_Alipay_config.Sign_type;
		string transport = shopNum1_Alipay_config.Transport;
		if (requestGet.Count > 0)
		{
			ShopNum1_Alipay_notify shopNum1_Alipay_notify = new ShopNum1_Alipay_notify(requestGet, base.Request.QueryString["notify_id"], partner, key, input_charset, sign_type, transport);
			string responseTxt = shopNum1_Alipay_notify.ResponseTxt;
			string a = base.Request.QueryString["sign"];
			string mysign = shopNum1_Alipay_notify.Mysign;
			if (responseTxt == "true" && a == mysign)
			{
				string str = base.Request.QueryString["user_id"];
				base.Response.Redirect("~/threelogin.aspx?type=4&user_id=" + str);
			}
		}
	}
	public SortedDictionary<string, string> GetRequestGet()
	{
		SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
		NameValueCollection queryString = base.Request.QueryString;
		string[] allKeys = queryString.AllKeys;
		for (int i = 0; i < allKeys.Length; i++)
		{
			sortedDictionary.Add(allKeys[i], base.Request.QueryString[allKeys[i]]);
		}
		return sortedDictionary;
	}
}
