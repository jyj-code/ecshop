<%@ WebHandler Language="C#" Class="uc" %>
using System;
using System.Web;
using ShopNum1.BusinessLogic;
using System.IO;
using System.Data;
using ShopNum1.Factory;
using ShopNum1.Common;
using System.Text;
using System.Configuration;
public class uc : ShopNum1.Ucenter.UCAPI.UCAPIBase
{
    /// <summary>
    /// 接收删除用户
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public override bool DeleteUser(string[] ids)
    {
        string strids = string.Empty;
        for (int i = 0; i < ids.Length; i++)
        {
            strids += ids[i];
        }
        if (strids.Length > 0)
        {
            strids = strids.Substring(0, strids.Length - 1);
        }
       // ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        //int check = member_Action.DelMemberByUID(strids);
        return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="creditId"></param>
    /// <returns></returns>
    public override int GetCredit(int uid, int creditId)
    {
        throw new NotImplementedException();
    }
    public override string GetCreditSettings()
    {
        throw new NotImplementedException();
    }
    public override bool RenameUser(int uid, string oldname, string newname)
    {
        throw new NotImplementedException();
    }

    public override bool Synlogin(int uid)
    {
        //用户名
        string userName = HttpUtility.UrlEncode(Parameter_USERNAME);
        
        ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        DataTable tempDateTable = member_Action.SearchByMemLoginID(HttpUtility.UrlDecode(userName));
       
        if (tempDateTable!=null&&tempDateTable.Rows.Count > 0)
        {    //将登录名写入Cookie                 MemberLoginCookie
                HttpCookie logincookie = new HttpCookie("MemberLoginCookie");
                //将用户ID写到cookie
                logincookie.Values.Add("MemLoginID", tempDateTable.Rows[0]["MemLoginID"].ToString());

                //将用户名写到cookie
                logincookie.Values.Add("Name", tempDateTable.Rows[0]["Name"].ToString());
              
                //会员类型
                logincookie.Values.Add("MemberType", tempDateTable.Rows[0]["MemberType"].ToString());
   
                //如果为店铺会员，则存储店铺等级
                if (tempDateTable.Rows[0]["MemberType"].ToString() == "2")
                {
                    ShopNum1.ShopBusinessLogic.Shop_ShopInfo_Action shop_ShopInfo_Action = (ShopNum1.ShopBusinessLogic.Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
                    DataTable dataTablerank = shop_ShopInfo_Action.GetShopRankByMemLoginID(tempDateTable.Rows[0]["MemLoginID"].ToString());
                    if (dataTablerank != null && dataTablerank.Rows.Count > 0)
                    {
                        logincookie.Values.Add("ShopRank", dataTablerank.Rows[0]["ShopRank"].ToString());
                    }
                }

                //论坛的uid (兑换积分使用)
                logincookie.Values.Add("UID", "-1");
                
                //加密Cookie
                HttpCookie encodeCookie = HttpSecureCookie.Encode(logincookie);
                encodeCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
            
                HttpContext.Current.Response.AppendCookie(encodeCookie);
                ///更新用户登录时间
                member_Action.UpdateLoginTime(tempDateTable.Rows[0]["MemLoginID"].ToString(), Globals.IPAddress); ///修改登陆时间


         
            
        }
        return true;
    }

    public override void Synlogout()
    {
        ///本地清除cookie
        if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
        {
            HttpCookie shopnum1Cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            shopnum1Cookie.Values.Clear();
            shopnum1Cookie.Expires = System.DateTime.Now.AddDays(-6);
            shopnum1Cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
            HttpContext.Current.Response.Cookies.Add(shopnum1Cookie);
        }
    }

    public override void UpdateApps()
    {
        ////HttpCookie cookie = new HttpCookie("shopnum1_username");
        ////cookie.Domain = "";
        ////cookie.Value = "uid";
        ////cookie.Path = "/";
        ////HttpContext.Current.Response.Cookies.Add(cookie);
        //throw new NotImplementedException();
    }

    public override void UpdateBadwords()
    {
        //throw new NotImplementedException();
    }

    public override void UpdateClient()
    {
        //throw new NotImplementedException();
    }

    public override void UpdateCreditSettings(string creditSettings)
    {
        //throw new NotImplementedException();
    }
    public override void UpdateHosts()
    {
        //throw new NotImplementedException();
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="uname"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public override bool UpdatePW(string uname, string pwd)
    {
        ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        int check = member_Action.UpdatePwd(uname, pwd);
        if (check > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public override bool UpdateCredit(int uid, int creditId, int amount)
    {
        throw new NotImplementedException();
    }
}