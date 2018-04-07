<%@ WebHandler Language="C#" Class="OrderList" %>

using System;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System.Text;

public class OrderList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (Common.ReqStr("type") != "")
        {
            ShopNum1_OrderInfo_Action OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            if (Common.ReqStr("user") == GetMemLoginId())
            {
                string strGuId = Common.ReqStr("guid");
                if (strGuId.IndexOf(",") != -1)
                {
                    StringBuilder sb = new StringBuilder();
                    string[] arryguid = strGuId.Split(',');
                    for (int i = 0; i < arryguid.Length; i++)
                    {
                        sb.Append("'" + arryguid[i] + "',");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    strGuId = sb.ToString();
                }
                else
                {
                    strGuId = "'" + strGuId + "'";
                }
                OrderInfo_Action.UpdateDelete(strGuId);
                context.Response.Write("ok");
            }
            else if (Common.ReqStr("price") != "" && Common.ReqStr("ordernumber") != "" && Common.ReqStr("orid") != "")
            {
                OrderInfo_Action.UpdateOrderPrice(Common.ReqStr("ordernumber"), GetMemLoginId(), Common.ReqStr("price")); OrderOperateLog("", "订单提交卖家调整费用", "等待买家付款", Common.ReqStr("orid"));
                context.Response.Write("ok");
            } 
        }
    }
    /// <summary>
    /// 订单操作日志
    /// </summary>
    /// <param name="memo"></param>
    protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg,string strOid)
    {
        ShopNum1MultiEntity.ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1MultiEntity.ShopNum1_OrderOperateLog();
        shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
        shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(strOid);
        shopNum1_OrderOperateLog.OderStatus = 1;
        shopNum1_OrderOperateLog.ShipmentStatus = 0;
        shopNum1_OrderOperateLog.PaymentStatus = 0;
        shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
        shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
        shopNum1_OrderOperateLog.Memo = memo;
        shopNum1_OrderOperateLog.OperateDateTime = System.DateTime.Now;
        shopNum1_OrderOperateLog.IsDeleted = 0;
        shopNum1_OrderOperateLog.CreateUser = GetMemLoginId();
        ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
        shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
    }
    //获取登录用户方法
    private string GetMemLoginId()
    {
        string name = "jely";
        if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
        {
            HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
            name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"].ToString();
        }
        return name;
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}