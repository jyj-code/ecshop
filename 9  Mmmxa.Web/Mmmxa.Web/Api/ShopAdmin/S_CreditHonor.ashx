<%@ WebHandler Language="C#" Class="S_CreditHonor" %>

using System;
using System.Web;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

public class S_CreditHonor : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (Common.ReqStr("type") == "sendReply")
        {
            string strbuyer = Common.ReqStr("buyerc");
            string strpguid = Common.ReqStr("pguid");
            string strreply = Common.ReqStr("reply");
            ShopNum1_ProductComment_Action ProductComment_Action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
            ProductComment_Action.UpdateComment(strpguid, strreply, System.DateTime.Now.ToString(), strbuyer);
            context.Response.Write("ok");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}     