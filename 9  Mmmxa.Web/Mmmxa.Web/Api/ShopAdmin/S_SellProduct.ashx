<%@ WebHandler Language="C#" Class="S_SellProduct" %>

using System;
using System.Web;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Text;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
public class S_SellProduct : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        //ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
        ShopNum1_CategoryType_Action shopNum1_CategoryType_Action = (ShopNum1_CategoryType_Action)LogicFactory.CreateShopNum1_CategoryType_Action();

        Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
        string strCommon = Common.ReqStr("type");
        switch (strCommon)
        {
            case "0": //获取商品分类相关操作
                if (context.Request.QueryString["parentid"] != null)
                {
                    string strid = context.Request.QueryString["parentid"].ToString();
                    DataTable dataTable = shopNum1_ProductCategory_Action.SearchtProductCategory(Convert.ToInt32(strid), 0);
                    context.Response.Write(GetJson(dataTable));
                } break;
            case "1":
                DataTable dt = shopNum1_CategoryType_Action.Select_ProductCategoryType();
                context.Response.Write(GetJson(dt));
                break;
            case "2":
                string strcol=Common.ReqStr("col");
                string strvalue=HttpUtility.HtmlDecode(Common.ReqStr("vl"));
                string guid=Common.ReqStr("guid");
                switch (strcol)
                {
                    case "name": Common.UpdateInfo("name='"+strvalue+"'", "shopnum1_shop_product", " and guid='"+guid+"'"); break;
                    case "rep": Common.UpdateInfo("repertorycount='" + strvalue + "'", "shopnum1_shop_product", " and guid='" + guid + "'"); break;
                    case "price": Common.UpdateInfo("shopprice='" + strvalue + "'", "shopnum1_shop_product", " and guid='" + guid + "'"); break;
                    default: break; 
                }
                context.Response.Write("ok"); break;
            case "3":
                shop_Product_Action.DeleteById(Common.ReqStr("ids"));
                context.Response.Write("ok"); break;
            case "4":
                shop_Product_Action.UpdateProductSaled(Common.ReqStr("ids"),Common.ReqStr("sale"));
                break;
            case "5": //获取店铺分类相关操作
                Shop_ProductCategory_Action ProductCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
                string strpid = Common.ReqStr("parentid");
                if (strpid != null)
                {
                    DataTable dataTable = ProductCategory_Action.SearchShopType(Convert.ToInt32(strpid), GetMemLoginId());
                    context.Response.Write(GetJson(dataTable));
                } 
                break;
            default: context.Response.Write("0"); break;
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
    /// <summary>
    /// 将datatable转换成json数组
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    private string GetJson(DataTable dt)
    {
        StringBuilder sbJson = new StringBuilder();
        sbJson.Append("[");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sbJson.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j] + "\",");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("},");
            }
        }
        sbJson.Remove(sbJson.Length - 1, 1);
        sbJson.Append("]");
        return sbJson.ToString();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}