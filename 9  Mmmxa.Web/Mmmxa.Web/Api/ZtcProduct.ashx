<%@ WebHandler Language="C#" Class="ZtcProduct" %>

using System;
using System.Web;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System.Web.UI.WebControls;
using ShopNum1MultiEntity;
using System.Configuration;
using ShopNum1.Email;
using System.IO;
using ShopNum1.DiscuzToolkit;
using ShopNum1.DiscuzHelper;
using ShopNum1.Standard;
using ShopNum1.Ucenter.Request;
using System.Net;
using ShopNum1_Second;
using System.Web.UI;
using ShopNum1.ShopBusinessLogic;
using System.Collections.Generic;


public class ZtcProduct : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string Type = context.Request.QueryString["type"] == null ? "" : context.Request.QueryString["type"].ToString();
        string FatherID = context.Request.QueryString["FatherID"] == null ? "" : context.Request.QueryString["FatherID"].ToString();

        string code = context.Request.QueryString["code"] == null ? "" : context.Request.QueryString["code"].ToString();

        string textName = context.Request.QueryString["textName"] == null ? "" : context.Request.QueryString["textName"].ToString();

        string productGuid = context.Request.QueryString["productGuid"] == null ? "" : context.Request.QueryString["productGuid"].ToString();

        string Money = context.Request.QueryString["Money"] == null ? "" : context.Request.QueryString["Money"].ToString();

        string subId = context.Request.QueryString["subid"] == null ? "" : context.Request.QueryString["subid"].ToString();
        
        string MemLoginID = string.Empty;

        if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            MemLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
        }
        
        switch (Type)
        {
            case "fenlei":
                context.Response.Write(GetShopCategory(FatherID, MemLoginID));
                break;
            case "product":
                context.Response.Write(GetProduct(code, textName, MemLoginID));
                break;
            case "productImage":
                context.Response.Write(GetProductImage(productGuid));
                break;
            case "Money":
                context.Response.Write(GetOrder(Money, subId, MemLoginID));
                break;
            default: ;
                break;
        }
        
        
    }


    public string GetOrder(string money, string subId,string MemloginID)
    {
        string strOrder = "1";
        string strSubId = Common.GetNameById("substationid", "shopnum1_shopinfo", " And memloginid='" + MemloginID + "'");
        if (subId == "1")
            strSubId = "all";
        ShopNum1_ZtcGoods_Action ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
        DataTable dataOrder = ZtcGoods_Action.SearchProductOrder(money, strSubId);
        if (dataOrder!=null && dataOrder.Rows.Count>0)
        {
            strOrder =( Convert.ToInt32(dataOrder.Rows[0][0].ToString())+1).ToString();
        }
        return strOrder;
    }
    


    public string GetProductImage(string guid)
    {
        string image = string.Empty;
        ShopNum1_ZtcGoods_Action ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
        DataTable dataTable = ZtcGoods_Action.SearchProductImage(guid);
        if (dataTable != null && dataTable.Rows.Count>0)
        {
            image = dataTable.Rows[0]["OriginalImage"].ToString();
        }
        return image;
        
    }
    
    
    

    public string GetProduct(string code, string textName, string MemLoginID)
    {
        string codeString=code;
        if (code!="-1" && !string.IsNullOrEmpty(code) && code!="0")
        {
            string[] strCode = code.Split('/');
            if (strCode.Length > 0)
            {
                codeString = strCode[1].ToString();
            }
        }
        
        
        ShopNum1_ZtcGoods_Action ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
        DataTable dt = ZtcGoods_Action.GetProduct(50,codeString, textName, MemLoginID, 0, 1, 1,0,0,"1");
        System.Text.StringBuilder sbJson = new System.Text.StringBuilder();
        if (dt != null && dt.Rows.Count > 0)
        {
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
        }
        return sbJson.ToString();
    }




    public string GetShopCategory(string FatherID, string MemLoginID)
    {
        Shop_ProductCategory_Action productCategory_Action = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
        productCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";
        DataTable dataTable = productCategory_Action.GetShopProductCategoryCode(FatherID, MemLoginID);
        string strCategory = string.Empty;
        strCategory = "<option value=\"-1\">-请选择-</option>";
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            //DropDownListCategoryCode.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
            strCategory += "<option value=\"" + dataTable.Rows[i]["ID"].ToString() + "/" + dataTable.Rows[i]["Code"].ToString() + "\">" + dataTable.Rows[i]["Name"].ToString() + "</option>";
        }
        return strCategory;
    }
    
    bool IHttpHandler.IsReusable
    {
        get { throw new NotImplementedException(); }
    }
}