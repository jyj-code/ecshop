<%@ WebHandler Language="C#" Class="S_PackAgeOpreate" %>

using System;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopInterface;
using ShopNum1.ShopFactory;
using System.Data;
using ShopNum1.Common;
using System.Text;
using ShopNum1.BusinessLogic;
using ShopNum1.Interface;

public class S_PackAgeOpreate : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.Buffer = true;
        context.Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
        context.Response.Expires = 0;
        context.Response.CacheControl = "no-cache";
        if (Common.ReqStr("sing") == "deleted" && Common.ReqStr("pid") != "" && Common.ReqStr("packid") != "")
        {
            PackAge_Action.DeletePackAgeInfo(Common.ReqStr("packid"), Common.ReqStr("pid"));
        }
        else if (Common.ReqStr("pageid") != "")
        {
            DataTable dt = GetData(context, HttpUtility.HtmlDecode(Common.ReqStr("pname")), Common.ReqStr("pcode"), Common.ReqStr("pageid"), "1");
           if (dt.Rows.Count > 0)
           {
               string strCount = GetData(context, HttpUtility.HtmlDecode(Common.ReqStr("pname")), Common.ReqStr("pcode"), Common.ReqStr("pageid"), "0").Rows[0][0].ToString();
               double pageC = Math.Ceiling(Convert.ToInt32(strCount) / Convert.ToDouble(10));
               context.Response.Write(pageC.ToString() + "|" + GetJson(dt));
           }
        }
        else if (Common.ReqStr("ptype") == "ptype")
        {
            ShopNum1_ProductCategory_Action ProductCategory_Action = (ShopNum1_ProductCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductCategory_Action();
            context.Response.Write(GetJson(ProductCategory_Action.Select_ProductCategory())); 
        }
    }
    Shop_PackAge_Action PackAge_Action = (Shop_PackAge_Action)LogicFactory.CreateShop_PackAge_Action();
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
    private DataTable GetData(HttpContext context,string strName,string strProCode,string strPageId,string strResultNum)
    {
        try { int.Parse(strProCode); }
        catch { return null; }
        string strPageSize="10";
        string strCurrentPage = strPageId;
        string strCondit = " and issaled=1 and issell=1 and isaudit=1 and Productstate=0 And guid not in(SELECT productguid FROM ShopNum1_PackAgeRalate ) and isreal!=0";
        strCondit += " and memloginId='" + GetMemLoginId() + "' ";
        if (strName != "")
            strCondit += " and name like '%"+strName+"%'";
        if(strProCode!="0")
            strCondit += " and ProductCategoryCode like '" + strProCode + "%'";
        string strSortValue="desc";
        string strOrderColumn="saletime";
        string strColumn = "Guid,Id,name,shopprice,Repertorycount,originalimage,ProductCategoryCode,memloginId,Productstate";
        string strTabName="shopnum1_shop_product";
        return PackAge_Action.SelectPackAgeProduct(strPageSize, strCurrentPage, strCondit, strResultNum, strSortValue, strOrderColumn, strColumn, strTabName);
    }
    /// <summary>
    /// 将datatable转换成json数组
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    private string GetJson(DataTable dt)
    {
        StringBuilder sbJson = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            sbJson.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sbJson.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("~/", "/") + "\",");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("},");
            }
            sbJson.Remove(sbJson.Length - 1, 1);
            sbJson.Append("]");
        }
        else { sbJson.Append("0"); }
        return sbJson.ToString();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}