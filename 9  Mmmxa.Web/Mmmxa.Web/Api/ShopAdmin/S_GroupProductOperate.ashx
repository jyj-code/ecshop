<%@ WebHandler Language="C#" Class="S_GroupProductOperate" %>

using System;
using System.Web;
using ShopNum1.Common;
using ShopNum1.ShopInterface;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System.Data;
using System.Text;
using ShopNum1.BusinessLogic;
public class S_GroupProductOperate : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (Common.ReqStr("type") != "")
        {
            Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
            switch (Common.ReqStr("type"))
            {
                case "getactivity":
                    ShopNum1_Activity_Action GroupProduct =(ShopNum1_Activity_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Activity_Action();
                    string strSubstationID = string.Empty;
                    if (Common.ReqStr("sub") == "city")
                    {
                        try
                        {
                            strSubstationID = Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + GetMemLoginId() + "'   ");
                        }
                        catch (Exception ex)
                        { }
                    }
                    else
                    {
                        strSubstationID = "all";
                    }
                    
                    
                    DataTable dtv = GroupProduct.GetProductActivity(strSubstationID);
                    context.Response.Write(Json.GetJson(dtv));
                    break;
                case "getshoptype":
                    DataTable dt = shop_ProductCategory_Action.Search_Import(Common.ReqStr("id"), GetMemLoginId());
                    context.Response.Write(Json.GetJson(dt));
                    break;
                case "getproduct":
                    string strcode = Common.ReqStr("code");
                    string strKey = HttpUtility.HtmlDecode(Common.ReqStr("keyword"));
                    context.Response.Write(GetProduct(strcode, strKey, GetMemLoginId()));
                    break;
                case "getinfobyId":
                    string strGuid=Common.ReqStr("guid");
                    Shop_GroupProduct_Action groupProduct = new Shop_GroupProduct_Action();
                    DataTable dts = groupProduct.GetProductById(strGuid, GetMemLoginId());
                    context.Response.Write(dts.Rows[0]["shopprice"]+","+dts.Rows[0]["repertorycount"]+","+dts.Rows[0]["name"]);
                    break;
            }
        }
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
    public string GetProduct(string code, string textName, string MemLoginID)
    {
        Shop_GroupProduct_Action groupProduct = new Shop_GroupProduct_Action();
        DataTable dt = groupProduct.GetProduct(50, code, textName, MemLoginID);
        return Json.GetJson(dt);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}