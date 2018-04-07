<%@ WebHandler Language="C#" Class="ProductCategory" %>

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

public class ProductCategory : IHttpHandler
{
    string strCategoryID = "";//关键词
    string fz = "";//是否为主站
    public void ProcessRequest(HttpContext context)
    {
        strCategoryID = context.Request["id"] == null ? "" : context.Request["id"].ToString();
        fz = context.Request["fz"] == null ? "" : context.Request["fz"].ToString();
        string type = context.Request["type"];
        if (type == null)
        {
            return;
        }
        switch (type.ToLower())
        {
            //搜索商品分类
            case "getproductcategory":
                context.Response.Write(BindData(strCategoryID));
                break;
            default:
                break;
        }
    }


    private string BindData(string CategoryID)
    {
        System.Text.StringBuilder sbuilder = new System.Text.StringBuilder();
        //绑定商品分类
        ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
        DataTable dataTable = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(CategoryID), 0, "1000");
        if (dataTable != null && dataTable.Rows.Count > 0)
        {

            sbuilder.Append("<div class=\"tag_sx\"></div><ul class=\"imgYujiazai\">");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (fz == "zz")
                {
                    sbuilder.Append("<li><div class=\"tagsub\"><a href='" + ShopUrlOperate.RetUrl("Search_productlist", dataTable.Rows[i]["Code"].ToString(), "code") + "'>");
                }
                else
                {
                    sbuilder.Append("<li><div class=\"tagsub\"><a href='" + ShopUrlOperate.RetUrlNew1("Search_productlist", dataTable.Rows[i]["Code"].ToString(), "code") + "'>");
                }
                sbuilder.Append(dataTable.Rows[i]["Name"].ToString() + "</a></div>");
                sbuilder.Append("<div class=\"tagsan\">");

                int twoid = Convert.ToInt32(dataTable.Rows[i]["id"].ToString());
                DataTable datatabletwo = shopNum1_ProductCategory_Action.Search(twoid, 0, "1000");
                for (int j = 0; j < datatabletwo.Rows.Count; j++)
                {
                    if (fz == "zz")
                    {
                        sbuilder.Append("<a href='" + ShopUrlOperate.RetUrl("Search_productlist", datatabletwo.Rows[j]["Code"].ToString(), "code") + "'>");
                    }
                    else
                    {
                        sbuilder.Append("<a href='" + ShopUrlOperate.RetUrlNew1("Search_productlist", datatabletwo.Rows[j]["Code"].ToString(), "code") + "'>");
                    }
                    sbuilder.Append(datatabletwo.Rows[j]["Name"].ToString() + "</a>");
                }
                sbuilder.Append("</div>");
                sbuilder.Append("<div class=\"clear\"></div>");
                sbuilder.Append("</li>");
            }

            sbuilder.Append("</ul>");
            return sbuilder.ToString();
        }
        else
        {
            return "";
        }
        
    }

    public bool IsReusable
    {
        get { throw new NotImplementedException(); }
    }
    bool IHttpHandler.IsReusable
    {
        get { throw new NotImplementedException(); }
    }
}