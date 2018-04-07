<%@ WebHandler Language="C#" Class="feedback" %>

using System;
using System.Web;

using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;   
using ShopNum1MultiEntity;
using ShopNum1.Common;
using System.Data;      



public class feedback : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        string type = context.Request.Params["type"].ToLower().Trim();
        switch (type)
        {
            case "updatefeed":
                UpdateFeed(context);
                break;
            default:
                break;
        }
    }
    public void UpdateFeed(HttpContext context)
    {
        string commenttype = context.Request.Params["commenttype"].Trim();
        string comment = context.Request.Params["comment"].Trim();
        string guid = context.Request.Params["guid"].Trim();
        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //会员登录ID
        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();        
        Shop_ProductComment_Action ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
        int num = ProductComment_Action.UpdateCommentType(MemberLoginID, guid, commenttype, comment);
        if (num > 0)
        {
            context.Response.Write("ok");
        }
        else
            context.Response.Write("no");   
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}