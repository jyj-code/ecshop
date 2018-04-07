<%@ WebHandler Language="C#" Class="S_Limit_ProductOp" %>

using System;
using System.Web;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1.Factory;
using System.Text;
using System.Data;

public class S_Limit_ProductOp : IHttpHandler
{
    public void ProcessRequest (HttpContext context) {
        //ProductGuid,Lid,Discount,ShopName,MemloginID
        if (Common.ReqStr("type") != "")
        {
            Shop_LimtProduct_Action shop_LimtProduct_Action = new Shop_LimtProduct_Action();
            string strId = "";
            switch (Common.ReqStr("type"))
            {
                case "addlimitproduct":
                    string strProductGuId = Common.ReqStr("guid");
                    string strLid = Common.ReqStr("lid");
                    string strDisCount1 = Common.ReqStr("discount");
                    string strShopName = Common.GetNameById("shopname", "ShopNum1_shopinfo", " and name='" + GetMemLoginId() + "'");
                    ShopNum1_Limt_Product shopNum1_Limt_Product = new ShopNum1_Limt_Product();
                    shopNum1_Limt_Product.ProductGuid = new Guid(strProductGuId);
                    shopNum1_Limt_Product.Lid = Convert.ToInt32(strLid);
                    shopNum1_Limt_Product.DisCount = Convert.ToDecimal(strDisCount1);
                    shopNum1_Limt_Product.ShopName = strShopName;
                    shopNum1_Limt_Product.MemLoginId = GetMemLoginId();
                    shop_LimtProduct_Action.AddLimitProduct(shopNum1_Limt_Product);
                    context.Response.Write(GetMemLoginId()); break;
                case "del":
                    strId = Common.ReqStr("Id");
                    shop_LimtProduct_Action.DeleteLimitProduct(strId);
                    context.Response.Write(GetMemLoginId()); break;
                case "cancel":
                    strId = Common.ReqStr("Id");
                    shop_LimtProduct_Action.UpdateLimitProductStae(strId, "0");
                    context.Response.Write(GetMemLoginId()); break;
                case "updatediscount":
                    strId = Common.ReqStr("Id");
                    string strDisCount2 = Common.ReqStr("txtdiscount");
                    shop_LimtProduct_Action.UpdateDisCount(strDisCount2, strId);
                    context.Response.Write(GetMemLoginId()); break;
                case "cancelAct":
                    strId = Common.ReqStr("Id");
                    ShopNum1_Activity_Action shopNum1_Activity_Action = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
                    shopNum1_Activity_Action.UpdateActivityState(strId, "2");
                    context.Response.Write(GetMemLoginId()); break;
                case "ptype":
                    ShopNum1_ProductCategory_Action ProductCategory_Action = (ShopNum1_ProductCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductCategory_Action();
                    context.Response.Write(GetJson(ProductCategory_Action.Select_ProductCategory())); break;
            }
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