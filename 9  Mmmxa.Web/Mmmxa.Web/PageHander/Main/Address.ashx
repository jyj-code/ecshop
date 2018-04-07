<%@ WebHandler Language="C#" Class="Address" %>

using System;
using System.Web;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Text;
using ShopNum1.Common;
//using System.Web.HttpContext;

public class Address : IHttpHandler
{

    string type;
    string url;
    string urlCanshu;
    ShopNum1_DispatchRegion_Action dispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();

    static readonly ShopNum1.Interface.IShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = LogicFactory.CreateShopNum1_ShopInfoList_Action();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = Encoding.GetEncoding("utf-8");

        string showcount = context.Request["showcount"];
        string Level = context.Request["Level"];
        url = context.Request["url"];
        urlCanshu = context.Request["urlCanshu"];

        type = context.Request["type"];
        if (type == null)
        {
            return;
        }
        switch (type.ToLower().Trim())
        {
            //查询城市 SearchCity.
            case "searchcity":
                context.Response.Write(Search(showcount, Level,url,urlCanshu));
                break;
            default:
                break;
        }
    }




    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="showcount">""为所有</param>
    /// <param name="type">1:获取省 2：获取城市</param>
    /// <returns></returns>
    private string Search(string strShowcount, string Level, string strurl, string strurlCanshu)
    {
        ShopNum1_Region_Action shopnum1_region_action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
        shopnum1_region_action.TableName = "ShopNum1_Region";
        DataTable datatable = shopnum1_region_action.SearchByCategoryLevel(Level, strShowcount);
        //拼接链接地址
        datatable.Columns.Add("Url", Type.GetType("System.String"));

        foreach (DataRow r in datatable.Rows)
        {
            r["Url"] = ShopUrlOperate.RetUrlForSearch(strurl,urlCanshu, r["code"].ToString(), "addcode");
        }
        //拼接 缩短 省市名称
        datatable.Columns.Add("SuoName", Type.GetType("System.String"));
        foreach (DataRow r in datatable.Rows)
        {
            r["SuoName"] = r["name"].ToString();
        }
        return datatableToJson(datatable);
    }

    //DataTable 转为json字符串
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
        get
        {
            return false;
        }
    }

}