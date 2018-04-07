<%@ WebHandler Language="C#" Class="AutoSearchName" %>

using System;
using System.Web;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System.Web.UI.WebControls;
using ShopNum1.Factory;
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

public class AutoSearchName : IHttpHandler
{
    string strType = "";//类型
    string strKeyword = "";//关键词

    public void ProcessRequest(HttpContext context)
    {
        strType = context.Request["type"];
        strKeyword = context.Request["keyword"] == null ? "" : context.Request["keyword"].ToString();
        if (strType == null)
        {
            return;
        }
        switch (strType.ToLower())
        {
            //搜索商品
            case "searchproduct":
                context.Response.Write(SearchProduct(strKeyword));
                break;
            //搜索店铺
            case "searchshop":
                context.Response.Write(SearchShop(strKeyword));
                break;
          
            ////搜索供求
            //case "searchsupply":
            //    context.Response.Write(SearchSupply(strKeyword));
            //    break;
            default:
                break;
        }
    }

    /// <summary>
    /// 搜索商品
    /// </summary>
    /// <param name="strKeyword">关键词</param>
    /// <returns></returns>
    private string SearchProduct(string strKeyword)
    {
        Shop_Product_Action product_action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
        DataTable dataTable_ProName = product_action.AutoSearchProductName(strKeyword);

        string str_data = string.Empty;
        if (dataTable_ProName != null && dataTable_ProName.Rows.Count > 0)
        {
            str_data += "<li> \"" + strKeyword + "\" <span>在宝贝分类下搜</span>索</li>";

            for (int i = 0; i < dataTable_ProName.Rows.Count; i++)
            {
                str_data += " <li onclick=\"javascript:test(1,this)\">" + dataTable_ProName.Rows[i]["Name"].ToString() + "</li>";
            }
        }
        else
        {

        }
        return str_data;
    }


    /// <summary>
    /// 搜索店铺
    /// </summary>
    /// <param name="strKeyword">关键词</param>
    /// <returns></returns>
    private string SearchShop(string strKeyword)
    {
        Shop_Product_Action product_action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
        DataTable dataTable_ProName = product_action.AutoSearchShopName(strKeyword);

        string str_data = string.Empty;
        if (dataTable_ProName != null && dataTable_ProName.Rows.Count > 0)
        {
            str_data += "<li> \"" + strKeyword + "\" <span>在店铺分类下搜</span>索</li>";

            for (int i = 0; i < dataTable_ProName.Rows.Count; i++)
            {
                str_data += " <li onclick=\"javascript:test(2,this)\">" + dataTable_ProName.Rows[i]["ShopName"].ToString() + "</li>";
            }
        }
        else
        {

        }
        return str_data;
    }



    ///// <summary>
    ///// 搜索供求
    ///// </summary>
    ///// <param name="strKeyword">关键词</param>
    ///// <returns></returns>
    //private string SearchSupply(string strKeyword)
    //{
    //    Shop_Product_Action product_action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
    //    DataTable dataTable_ProName = product_action.AutoSearchSupplyName(strKeyword);

    //    string str_data = string.Empty;
    //    if (dataTable_ProName != null && dataTable_ProName.Rows.Count > 0)
    //    {
    //        str_data += "<li> \"" + strKeyword + "\" <span>在供求分类下搜</span>索</li>";

    //        for (int i = 0; i < dataTable_ProName.Rows.Count; i++)
    //        {
    //            str_data += " <li onclick=\"javascript:test(3,this)\">" + dataTable_ProName.Rows[i]["Title"].ToString() + "</li>";
    //        }
    //    }
    //    else
    //    {

    //    }
    //    return str_data;
    //}







    public bool IsReusable
    {
        get { throw new NotImplementedException(); }
    }
    bool IHttpHandler.IsReusable
    {
        get { throw new NotImplementedException(); }
    }
}