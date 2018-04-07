<%@ WebHandler Language="C#" Class="V8_2_ProductCategory" %>

using System;
using System.Web;
using System.Text;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Data;
using ShopNum1.Common;

public class V8_2_ProductCategory : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.Buffer = true;
        context.Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
        context.Response.Expires = 0;
        context.Response.CacheControl = "no-cache";
        string strType=Common.ReqStr("type");
        switch (strType)
        {
            case "index_productType":
                int fatherid = Convert.ToInt32(Common.ReqStr("pid"));
                ShopNum1_ProductCategory_Action productCategoryAction = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
                DataTable dataTable = productCategoryAction.GetTwoOverType(fatherid, "5000");
                string strJson = GetJson(dataTable, fatherid);
                context.Response.Write(strJson);
                break;
        }
    }
    /// <summary>
    /// 将datatable转换成json数组
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    private string GetJson(DataTable dt,int FatherId)
    {
        StringBuilder sbJson = new StringBuilder();
        DataRow[] drr = null,drr1=null;
        if (dt.Rows.Count > 0)
        {
            drr = dt.Select("fatherid='"+FatherId+"'");
            sbJson.Append("[");
            
            for (int v = 0; v < drr.Length; v++)
            {
                sbJson.Append("{");
                for (int i = 0; i < drr[v].Table.Columns.Count; i++)
                {
                    sbJson.Append("\"" + drr[v].Table.Columns[i].ColumnName.ToLower() + "\":\"" + drr[v][i].ToString().Replace("~/", "/").Replace("\r\n", "").Trim() + "\",");
                }
                sbJson.Append("subdata:[");
                drr1 = dt.Select("fatherid='" + dt.Rows[v]["id"] + "'");
                for (int x = 0; x < drr1.Length; x++)
                {
                    if (x != drr1.Length-1)
                        sbJson.Append("{\"name\":\"" + drr1[x]["name"].ToString().Trim() + "\",\"code\":\"" + drr1[x]["code"] + "\"},");
                    else
                        sbJson.Append("{\"name\":\"" + drr1[x]["name"].ToString().Trim() + "\",\"code\":\"" + drr1[x]["code"] + "\"}");
                }
                sbJson.Append("],");
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