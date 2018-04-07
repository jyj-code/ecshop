<%@ WebHandler Language="C#" Class="AdminApi" %>

using System;
using System.Web;
using System.Text;
using ShopNum1.ShopBusinessLogic;
using System.Data;
using System.Text.RegularExpressions;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;

public class AdminApi : IHttpHandler
{
    string strType = "";//类型
    string strKeyword = "";//关键词
    public void ProcessRequest (HttpContext context) {
        strType = context.Request["type"];
        strKeyword = context.Request["keyword"];
        if (strType == null)
        {
            context.Response.Write("0");
        }
        switch (strType.ToLower())
        {
            //判断店铺域名是否重复
            case "checkshopurl":
                context.Response.Write(CheckShopUrlOrYes(strKeyword));
                break;
            default: break;
        }
    }
    /// <summary>
    /// 判断店铺域名是否重复
    /// </summary>
    /// <param name="strkeyword"></param>
    /// <returns></returns>
    private string CheckShopUrlOrYes(string strkeyword)
    {
        Regex r = new Regex("[a-z0-9A-Z_]+");
        if (!r.IsMatch(strkeyword))
        {
            return "chinese";//汉语域名
        }
        if (!CheckIsRepeat(strkeyword))
        {
            return "no";
        }
        return "ok";
    }
    private bool CheckIsRepeat(string ShopURL)
    {
        ShopNum1_ShopInfoList_Action shopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
        DataTable datatable = shopInfoList_Action.CheckShopURLIsRepeat(ShopURL);
        if (datatable.Rows[0]["ShopUrl"].ToString() == "0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}