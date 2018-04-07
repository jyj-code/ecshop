//----------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.TbTopCommon;
using ShopNum1.Common;
using System.Net;
using System.IO;
using System.Text;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //验证会员中心的cookies
        if (Page.Request.Cookies["MemberLoginCookie"] == null)
        {      //退出
            GetUrl.RedirectTopLogin();
        }
        else
        {
            HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
            string MemberType = decodedCookieMemberLogin.Values["MemberType"].ToString();
            if (MemberType != "2")
            {
                //退出
                GetUrl.RedirectTopLogin();
                return;
            }
            //会员登录ID
            MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"].ToString();
        }
        try
        {
            Dictionary<string, string> paras = new Dictionary<string, string>();
            paras.Add("code", Request["code"]);
            paras.Add("client_id", TopConfig.AppKey);
            paras.Add("client_secret", TopConfig.AppSecret);
            paras.Add("grant_type", "authorization_code");
            paras.Add("redirect_uri", "http://" + ConfigurationManager.AppSettings["redirect_uri"]);
            string querystring = string.Empty;
            foreach (var p in paras)
            {
                querystring += p.Key + "=" + p.Value;
                querystring += "&";
            }
            querystring = querystring.Substring(0, querystring.Length - 1);
            string result = string.Empty;
            bool istest = ConfigurationManager.AppSettings["IsSandBox"] == "1";
            string url = string.Empty;
            if (istest)
            {
                url = ConfigurationManager.AppSettings["sandtoptokenurl"];
            }
            else
            {
                url = ConfigurationManager.AppSettings["toptokenurl"];
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            byte[] bytes = Encoding.UTF8.GetBytes(querystring);
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
            Stream stream = null;
            using (stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                result = reader.ReadToEnd();
            }
            if (result.Length > 0)
            {
                var hashtable = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Hashtable>(result);
                if (hashtable != null && hashtable.ContainsKey("access_token"))
                {
                    Session["access_token"] = hashtable["access_token"].ToString();
                    string nick = hashtable["taobao_user_nick"].ToString();
                    Session["taobao_user_nick"] = nick;
                    ///检查是淘宝商铺和本地是否绑定
                    ShopNum1_TbSystem_Action tbSystem = (ShopNum1_TbSystem_Action)LogicTbFactory.CreateShopNum1_TbSystem_Action();
                    string shopname = string.Empty;
                    tbSystem.CheckTbUserBind(nick, MemLoginID, out shopname);
                    if (shopname == "000")
                    {
                        tbSystem.InsertTbSystem(MemLoginID, nick);
                    }
                    ShopNum1.TbTopCommon.TopAPI.RestUrl = TopConfig.ServerURL;
                    TopClient.isAgentSessionTrue = true;
                    Page.Response.Redirect("TbAuthorizationSuccess.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "startup", "alert('授权失败,请检查您的配置是否正确!');window.location='TbSetAppKey.aspx';", true);
        }

        //if (Request.QueryString["top_appkey"] != null)
        //{
        //    //关于回调地址：http://open.taobao.com/dev/index.php/%E8%8E%B7%E5%8F%96SessionKey
        //    //关于用户验证：http://open.taobao.com/dev/index.php/%E7%94%A8%E6%88%B7%E9%AA%8C%E8%AF%81

        //    //验证回调地址参数是否合法，如果合法并保存用户数据至CookieAdmin
        //    if (ShopNum1.TbTopCommon.Sys.VerifyTopResponse(Request.QueryString["top_parameters"], Request.QueryString["top_session"], Request.QueryString["top_sign"], TopConfig.AppKey, TopConfig.AppSecret) == true)
        //    {
        //        //验证成功

        //        //从top_parameters为解析当前回调地址登录的nick
        //        string nick = new ShopNum1.TbTopCommon.Parser().GetParameters(Request.QueryString["top_parameters"].ToString(), "visitor_nick");
        //        ///检查是淘宝商铺和本地是否绑定
        //        ShopNum1_TbSystem_Action tbSystem = (ShopNum1_TbSystem_Action)LogicTbFactory.CreateShopNum1_TbSystem_Action();
        //        string shopname = string.Empty;
        //        if (!tbSystem.CheckTbUserBind(nick, MemLoginID, out shopname))
        //        {
        //            Response.Write(String.Format("<script type='text/javascript'>alert(\"您绑定的店铺为 '{0}' 请用该账户重新登录淘宝!\");</script>", shopname));
        //            Response.Write("<script type='text/javascript'>window.location.href=\"../s_Index.aspx?tosurl=TbTop/TbAuthorization.aspx\" </script>");
        //            return;
        //        }
        //        if (shopname == "000")
        //        {

        //            tbSystem.InsertTbSystem(MemLoginID, nick);
        //        }

        //        TopClient.SetAgentCookies(nick, Request.QueryString["top_session"].ToString());
        //        ShopNum1.TbTopCommon.TopAPI.RestUrl = TopConfig.ServerURL;

        //        TopClient.isAgentSessionTrue = true;
        //        // Response.Redirect("TbAuthorizationSuccess.aspx");
        //        Response.Redirect("../s_Index.aspx?tosurl=TbTop/TbAuthorizationSuccess.aspx");
        //    }
        //    else
        //    {
        //        //验证失败
        //        Response.Write("无效验证！");
        //        //Response.Write("<script type='text/javascript'>window.location.href=\"../login.aspx\" </script>");
        //    }
        //}
        //else
        //{
        //    Response.Write("无效参数对象，登录验证失败");
        //    Response.Write("<script type='text/javascript'>window.location.href=\"../login.aspx\" </script>");
        //}
    }

    private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }

    /// <summary>
    /// 会员名
    /// </summary>
    private string MemLoginID { get; set; }

}
