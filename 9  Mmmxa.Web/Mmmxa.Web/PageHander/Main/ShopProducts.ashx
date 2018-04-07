<%@ WebHandler Language="C#" Class="ShopProducts" %>

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
using System.Text;

public class ShopProducts : IHttpHandler
{
    string strType = "";//类型
    string shopid = "";//关键词
    int pageindex = 1;//当前页
    int pagesize =4;//页大小

    public void ProcessRequest(HttpContext context)
    {
        strType = context.Request["type"];
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
        shopid = context.Request["shopid"] == null ? "" : context.Request["shopid"].ToString();
        pageindex = context.Request["pageindex"] == null ? 1 : Convert.ToInt32(context.Request["pageindex"].ToString());
        pagesize = context.Request["pagesize"] == null ? 4 : Convert.ToInt32(context.Request["pagesize"].ToString());

        if (strType == null)
        {
            return;
        }
        switch (strType.ToLower())
        {
            //搜索商品
            case "shopproduct":
                context.Response.Write(SearchProduct(shopid, pageindex, pagesize));
                break;
            //搜索商品总数
            case "shopproductcount":
                context.Response.Write(SearchProductCount(shopid));
                break;
            default:
                break;
        }
    }

    private string SearchProduct(string shopid, int pageindex, int pagesize)
    {
        System.Text.StringBuilder sbuilder = new System.Text.StringBuilder();
        ShopNum1_ProuductChecked_Action ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
        DataTable datatable = ProuductChecked_Action.SearchRelatedProduct("-1", shopid, pageindex, pagesize,"0");
        datatable.Columns.Add("ProductDetailUrl", Type.GetType("System.String"));
        foreach (DataRow r in datatable.Rows)
        {
            r["ProductDetailUrl"] = ShopUrlOperate.shopDetailHrefNew(r["Guid"].ToString(), r["MemLoginID"].ToString(), "ProductDetail");
        }
        return datatableToJson(datatable);
    }
    
    //返回记录总数
    private string SearchProductCount(string shopid)
    {
        System.Text.StringBuilder sbuilder = new System.Text.StringBuilder();
        ShopNum1_ProuductChecked_Action ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
        DataTable datatable = ProuductChecked_Action.SearchRelatedProduct("-1", shopid, 1, 1,"1");
        return datatable.Rows[0][0].ToString();
    }
    
    public string datatableToJson(DataTable dt)
    {
        if (dt != null)
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            int rcount = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (rcount > 0)
                {
                    str.Append(",");
                }
                str.Append("{");
                int ccount = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    if (ccount > 0)
                    {

                        str.Append(",");
                    }
                    str.Append("\"" + c.ColumnName + "\":\"" + r[c].ToString() + "\"");
                    ccount++;
                }
                str.Append("}");
                rcount++;
            }
            str.Append("]");
            return str.ToString();

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