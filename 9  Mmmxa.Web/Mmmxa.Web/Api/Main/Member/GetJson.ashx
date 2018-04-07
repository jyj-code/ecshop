<%@ WebHandler Language="C#" Class="GetJson" %>

using System;
using System.Web;

using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1.Common;
using System.Data;
using System.Text;
using ShopNum1.ShopBusinessLogic;
public class GetJson : IHttpHandler
{
    public void ProcessRequest (HttpContext context) {

        try
        {
            if (Common.ReqStr("type") != "")
            {
                string strType = Common.ReqStr("type");//类型
                string pageIndex = Common.ReqStr("page") == null ? "1" : Common.ReqStr("page").ToString();//分页
                string shop = Common.ReqStr("shop") == null ? "" : Common.ReqStr("shop").ToString();//店铺
                string start = Common.ReqStr("start") == null ? "1" : Common.ReqStr("start").ToString();//
                string end = Common.ReqStr("end") == null ? "1" : Common.ReqStr("end").ToString();//
                string start1 = Common.ReqStr("start1") == null ? "1" : Common.ReqStr("start1").ToString();//团购
                string end1 = Common.ReqStr("end1") == null ? "1" : Common.ReqStr("end1").ToString();//团购
                string start2 = Common.ReqStr("start2") == null ? "1" : Common.ReqStr("start2").ToString();//抢购
                string end2 = Common.ReqStr("end2") == null ? "1" : Common.ReqStr("end2").ToString();//抢购
                switch (strType)
                {
                    case "GetBuyShop":
                        context.Response.Write(GetBuyShop(pageIndex));
                        break;
                    case "GetBuyShopProduct":
                        context.Response.Write(GetBuyShopProduct(shop));
                        break;
                    case "GetShopProductBrowse":
                        context.Response.Write(GetShopProduct_Browse(start, end));
                        break;
                    case "GroupProduct":
                        context.Response.Write(GetGroupProduct(start1, end1));
                        break;
                    case "GetShopQgProduct"://抢购
                        context.Response.Write(GetShopQgProduct(start2, end2));
                        break;
                }
            }
        }
        catch { context.Response.Write("error"); }
    }

    public string GetBuyShop(string pageIndex)
    {
        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //会员登录ID
        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
        string result=string.Empty;
        Shop_ShopInfo_Action ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
        DataTable dataTable = ShopInfo_Action.GetMyBuyShop(MemberLoginID, Convert.ToInt32(pageIndex));
        if (dataTable != null && dataTable.Rows.Count>0)
        {
            result = GetJsonString(dataTable);
        }
        return result;
    }


    public string GetBuyShopProduct(string shop)
    {
        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //会员登录ID
        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
        string result = string.Empty;
        Shop_ShopInfo_Action ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
        DataTable dataTable = ShopInfo_Action.GetMyBuyShopProduct(MemberLoginID, shop,3);
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            result = GetJsonString(dataTable);
        }
        return result;
    }



    public string GetShopProduct_Browse(string start,string end )
    {
        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //会员登录ID
        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
        string result = string.Empty;
        ShopNum1_ShopProduct_Browse_Action ShopProduct_Browse_Action = (ShopNum1_ShopProduct_Browse_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopProduct_Browse_Action();

        DataTable dataTable = ShopProduct_Browse_Action.Search(MemberLoginID, Convert.ToInt32(start), Convert.ToInt32(end));
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            result = GetJsonString(dataTable);
        }
        return result;
    }
    
    
    
    
    //
    public string GetGroupProduct(string start1, string end1)
    {
        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //会员登录ID
        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
        string result = string.Empty;
        ShopNum1_GroupProduct_Action GroupProduct_Action = (ShopNum1_GroupProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_GroupProduct_Action();

        DataTable dataTable = GroupProduct_Action.GetGroupProductData(Convert.ToInt32(start1), Convert.ToInt32(end1));
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            result = GetJsonString(dataTable);
        }
        return result;
    }

    //抢购商品
    public string GetShopQgProduct(string start, string end)
    {
        string result = string.Empty;
        Shop_Product_Action Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
        DataTable dataTable = Product_Action.GetQgProduct(Convert.ToInt32(start), Convert.ToInt32(end));
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            result = GetJsonString(dataTable);
        }
        return result;
    }
    
    

    public string GetJsonString(DataTable dt)
    {
        StringBuilder sbJson = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            sbJson.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sbJson.Append("{");
                string guid = string.Empty;
                string user = string.Empty;
                string strType = Common.ReqStr("type");//类型
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("~/", "/") + "\",");
                    switch (strType)
                    {
                        case "GetBuyShop"://我购买过的店铺
                            if(dt.Columns[j].ColumnName.ToLower()=="memloginid")
                            {
                                user = dt.Rows[i][j].ToString().Replace("~/", "/");
                                sbJson.Append("\"ahref\":\"" + ShopUrlOperate.shopHrefNew(user) + "\",");
                            }
                            
                            break;
                        case "GetBuyShopProduct":
                            if (dt.Columns[j].ColumnName.ToLower() == "guid")
                            {
                                guid = dt.Rows[i][j].ToString().Replace("~/", "/");
                                //sbJson.Append("\"ahref\":\"" + ShopUrlOperate.shopHref(guid,) + "\",");
                            }
                            if (dt.Columns[j].ColumnName.ToLower() == "memloginid")
                            {
                                user = dt.Rows[i][j].ToString().Replace("~/", "/");
                                sbJson.Append("\"ahref\":\"" + ShopUrlOperate.shopHrefNew(guid, user) + "\",");
                            }
                            
                            break;
                        case "GetShopProductBrowse":
                            if (dt.Columns[j].ColumnName.ToLower() == "productguid")
                            {
                                guid = dt.Rows[i][j].ToString().Replace("~/", "/");
                                //sbJson.Append("\"ahref\":\"" + ShopUrlOperate.shopHref(guid,) + "\",");
                            }
                            if (dt.Columns[j].ColumnName.ToLower() == "shopid")
                            {
                                user = dt.Rows[i][j].ToString().Replace("~/", "/");
                                sbJson.Append("\"ahref\":\"" + ShopUrlOperate.shopHrefNew(guid, user) + "\",");
                            }
                            break;
                        case "GroupProduct":
                            if (dt.Columns[j].ColumnName.ToLower() == "id")
                            {
                                guid = dt.Rows[i][j].ToString().Replace("~/", "/");
                                //sbJson.Append("\"ahref\":\"" + ShopUrlOperate.shopHref(guid,) + "\",");
                            }
                            if (dt.Columns[j].ColumnName.ToLower() == "memloginid")
                            {
                                user = dt.Rows[i][j].ToString().Replace("~/", "/");
                                sbJson.Append("\"ahref\":\"" + ShopUrlOperate.RedirectProductDetailByMemloginIDNew(guid, user, "1", "0") + "\",");
                            }
                            break;
                        case "GetShopQgProduct"://抢购
                            if (dt.Columns[j].ColumnName.ToLower() == "guid")
                            {
                                guid = dt.Rows[i][j].ToString().Replace("~/", "/");
                                //sbJson.Append("\"ahref\":\"" + ShopUrlOperate.shopHref(guid,) + "\",");
                            }
                            if (dt.Columns[j].ColumnName.ToLower() == "memloginid")
                            {
                                user = dt.Rows[i][j].ToString().Replace("~/", "/");
                                sbJson.Append("\"ahref\":\"" + ShopUrlOperate.RedirectProductDetailByMemloginIDNew(guid, user, "0", "1") + "\",");
                            }
                            break;
                    }
                    
                    
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("},");
            }
            sbJson.Remove(sbJson.Length - 1, 1);
            sbJson.Append("]");
        }
        return sbJson.ToString();
    }

    /// <summary>
    /// 返回数据
    /// </summary>
    /// <returns></returns>
    //public string GetUrl(string guid,string userid)
    //{
    //    string strUrl = string.Empty;
    //    string strType = Common.ReqStr("type");//类型
    //    switch (strType)
    //    {
    //        case "GetBuyShop"://我购买过的店铺
    //            strUrl = ShopUrlOperate.GetShopUrl(userid);
    //            break;
    //        case "GetBuyShopProduct":
    //            strUrl = ShopUrlOperate.shopHref(guid, userid);
    //            break;
    //        case "GetShopProductBrowse":
    //            strUrl = ShopUrlOperate.shopHref(guid, userid); ;
    //            break;
    //        case "GroupProduct":
    //            strUrl = ShopUrlOperate.shopDetailHrefByShopID(guid, userid, "ProductIsSpell_Detail");
    //            break;
    //        case "GetShopQgProduct"://抢购
    //            strUrl = ShopUrlOperate.shopDetailHrefByShopID(guid, userid, "ProductIsPanic_Detail");
    //            break;
    //    }
    //    return strUrl;
    //}
    
   
    public bool IsReusable {
        get {
            return false;
        }
    }

}