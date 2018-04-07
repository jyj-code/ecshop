<%@ WebHandler Language="C#" Class="shopProductDetail" %>

using System;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopInterface;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using ShopNum1.ShopFactory;
using System.Text;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Interface;

public class shopProductDetail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string strType = Common.ReqStr("vtype");
        DataTable dataTable = null;
        string shopMemLoginID = string.Empty;
        Shop_ProductConsult_Action ConsultAction = (Shop_ProductConsult_Action)LogicFactory.CreateShop_ProductConsult_Action();
        switch (strType)
        {
            case "addComment":
                if (GetMemLoginId() == "jely")
                {
                    context.Response.Write("empty"); return; 
                }
                shopMemLoginID = Common.GetNameById("MemLoginID", "ShopNum1_Shop_Product", "  AND guid='" + Common.ReqStr("guid") + "' ");
                if (shopMemLoginID == GetMemLoginId())
                {
                    context.Response.Write("common"); return;
                }
                ShopNum1_ShopProductConsult ProductConsult = new ShopNum1_ShopProductConsult();
                ProductConsult.Guid = Guid.NewGuid();
                ProductConsult.ProductGuid = new Guid(Common.ReqStr("guid"));
                ProductConsult.Content = HttpUtility.HtmlDecode(Common.ReqStr("comment"));
                ProductConsult.ConsultPeople = GetMemLoginId();
                ProductConsult.Title ="";
                ProductConsult.MemLoginID = GetMemLoginId();
                ProductConsult.IsReply = 0; //未回复
                ProductConsult.SendTime = System.DateTime.Now;
                ProductConsult.IsDeleted = 0;
                if (ShopSettings.GetValue("ProductConsultISAudit") == "1")
                {
                    ProductConsult.IsAudit = 0;
                }
                else
                {
                    ProductConsult.IsAudit = 1;
                }
                ProductConsult.ShopID = shopMemLoginID;
                ProductConsult.IPAddress = Globals.IPAddress; //需要修改
                int check = ConsultAction.Add(ProductConsult);
                if (check > 0)
                {
                    context.Response.Write("ok"); 
                }
                break;
            case "getComment":
                shopMemLoginID = Common.GetNameById("MemLoginID", "ShopNum1_Shop_Product", "  AND guid='" + Common.ReqStr("guid") + "' ");
                dataTable = ConsultAction.Search(Common.ReqStr("guid"), 0, 1, shopMemLoginID);
                context.Response.Write(GetJson(dataTable));
                break;
            case "showOrderlist":
                ShopNum1_OrderInfo_Action orderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
                dataTable = orderInfo_Action.SearchProductOrderRecord(Common.ReqStr("guid"), "-1").Tables[0];
                context.Response.Write(GetJson(dataTable));
                break; 
        }
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
        else { sbJson.Append(""); }
        return sbJson.ToString();
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