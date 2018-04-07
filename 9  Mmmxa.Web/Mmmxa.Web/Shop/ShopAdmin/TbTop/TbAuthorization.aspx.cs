using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ShopNum1.BusinessLogic;
using ShopNum1.TbTopCommon;
using ShopNum1.Common;
using ShopNum1.TbLinq;
using ShopNum1.Factory;

public partial class ShopTbAuthorization : System.Web.UI.Page
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

        if (Session["access_token"] != null)
        {
            Response.Redirect("TbAuthorizationSuccess.aspx");
        }
    }
    protected void btnAuthorization_Click(object sender, EventArgs e)
    {
        ShopNum1_TbTopKey_Action tbTopKeyAction = (ShopNum1_TbTopKey_Action)LogicTbFactory.CreateShopNum1_TbTopKey_Action();
        ShopNum1_TbTopKey tbTop = tbTopKeyAction.SearchTopKey(MemLoginID);
        if (tbTop != null)
        {
            TopConfig.AppKey = tbTop.AppKey;
            TopConfig.AppSecret = tbTop.AppSecret;
            TopConfig.AgentAppkey = tbTop.AppKey;
            TopConfig.AgentSecret = tbTop.AppSecret;
        }
        TopAPI.RestUrl = TopConfig.ServerURL;
        Response.Redirect(TopConfig.ShopContainerURL);//识别环境类型，返回不同调用容器地址
    }


    /// <summary>
    /// 会员名
    /// </summary>
    private string MemLoginID { get; set; }


}
