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
using ShopNum1.Factory;
using ShopNum1.Common;
using ShopNum1.TbTopCommon;

public partial class TbRemoveShopBind : System.Web.UI.Page
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

    }
    protected void ButtonRemoveAdmin_Click(object sender, EventArgs e)
    {
        TopClient.AgentLogout();
        //清空appsecret
        DelAppSecret();

        ShopNum1_TbSystem_Action tbSystemOperate = (ShopNum1_TbSystem_Action)LogicTbFactory.CreateShopNum1_TbSystem_Action();
        tbSystemOperate.Remove(MemLoginID);
        ShopNum1.Common.MessageBox.Show("删除绑定成功!");
    
     
    }

    /// <summary>
    /// 删除appsecret
    /// </summary>
    private void DelAppSecret()
    {
        ShopNum1_TbTopKey_Action tbTopKeyOperate = (ShopNum1_TbTopKey_Action)LogicTbFactory.CreateShopNum1_TbTopKey_Action();
        tbTopKeyOperate.Delete(MemLoginID);
    }

    /// <summary>
    /// 会员名
    /// </summary>
    private string MemLoginID { get; set; }

}
