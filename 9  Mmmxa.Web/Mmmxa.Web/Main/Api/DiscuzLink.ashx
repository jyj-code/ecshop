<%@ WebHandler Language="C#" Class="DiscuzLink" %>

using System;
using System.Web;

public class DiscuzLink : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
      //  context.Response.Write("Hello World");
        ShopNum1.DiscuzCommon.DisRequestObject disReq = new ShopNum1.DiscuzCommon.DisRequestObject(context.Request);
        if (disReq.IsInvalidRequest)
        {
            context.Response.Write("Invalid Request");
            context.Response.End();
        }
        if (disReq.IsInvalidAction)
        {
            context.Response.Write("Invalid Action");
            context.Response.End();
        }
        if (disReq.IsAuthracationExpiried)
        {
            context.Response.Write("Authracation has expiried");
            context.Response.End();
        }
        context.Response.Clear();
        switch (disReq.Action)
        { 
            case "login":
                context.Response.Write(login(disReq.user_name));
                context.Response.End();
                break;
            case "logout":
                context.Response.Write(logout(disReq.user_name));
                context.Response.End();
                break;
            default:
                context.Response.Write("1");
                context.Response.End();
                break;
        }
    }
    
    //登陆
    private string login(string userName)
    {
        //取要写到Cookie的信息
        ShopNum1.BusinessLogic.ShopNum1_Member_Action memberAction = (ShopNum1.BusinessLogic.ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
        System.Data.DataTable dataTable = memberAction.SearchByMemLoginID(userName);


        //将登录名写入Cookie
        HttpCookie logincookie = new HttpCookie("ShopNum1MemberLoginCookie");
        //将登录ID写到cookie
        logincookie.Values.Add("MemLoginID", userName);
        //将会员等级Guid写到Cookie
        logincookie.Values.Add("MemberRankGuid", dataTable.Rows[0]["MemberRankGuid"].ToString());
        //加密Cookie
        HttpCookie encodeCookie = ShopNum1.Common.HttpSecureCookie.Encode(logincookie);
        HttpContext.Current.Response.AppendCookie(encodeCookie);
                
        //System.IO.File.AppendAllText(HttpContext.Current.Request.PhysicalApplicationPath+"\\log\\logDiscuz.txt",DateTime.Now.ToString()+"用户"+userName+"登陆过\r\n",System.Text.Encoding.UTF8);

        HttpContext.Current.Response.AppendHeader("P3P", "CP=\"CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR\"");
       //HttpContext.Current.Response.Headers.Add("P3P", "CP=\"CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR\""); 
        return "1";
    }
    
    //退出
    private string logout(string userName)
    {
        HttpCookie cookie = new HttpCookie("ShopNum1MemberLoginCookie");
        cookie.Values.Clear();
        cookie.Expires = DateTime.Now.AddDays(-1);
        HttpContext.Current.Response.AppendCookie(cookie);
        ShopNum1.DiscuzToolkit.DiscuzSession ds = ShopNum1.DiscuzHelper.DiscuzSessionHelper.GetSession();
        ds.Logout(System.Configuration.ConfigurationManager.AppSettings["DiscuzCookieDomain"].Trim());
     //   System.IO.File.AppendAllText(HttpContext.Current.Request.PhysicalApplicationPath + "\\log\\logDiscuz.txt", DateTime.Now.ToString() +"用户"+userName+"退出过\r\n", System.Text.Encoding.UTF8);
        return "1";
    }
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}