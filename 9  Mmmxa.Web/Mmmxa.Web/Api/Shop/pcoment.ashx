<%@ WebHandler Language="C#" Class="pcoment" %>

using System;
using System.Web;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopInterface;
using ShopNum1.ShopFactory;
using System.Text;
using System.Data;

public class pcoment : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string strPageSize="20";
        string strCurrentPage = Common.ReqStr("currentpage") == "" ? "1" : Common.ReqStr("currentpage");
        string strShopId = Common.ReqStr("shopid");
        string strGuId = Common.ReqStr("guid");
        string strSign = Common.ReqStr("sign");
        string strCtype = Common.ReqStr("ctype");
        string strshowtype = Common.ReqStr("showtype");
        if (strshowtype == "undefined")
            strshowtype = "2";
        string strCondition="";
        if (strSign == "vj" && strShopId != "" & strGuId != "")
        {
            switch (strCtype)
            {
                case "good": strCondition = " and commenttype='5'"; break;
                case "normal": strCondition = " and commenttype='3'"; break;
                case "bad": strCondition = " and commenttype='1'"; break;
                case "addcomment": strCondition = " and continuecomment!=''"; break; 
            }
            Shop_ProductComment_Action ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
            DataTable dt= ProductComment_Action.SelectShopDetailComment(strPageSize, strCurrentPage, strCondition, "2", strShopId,strshowtype,strGuId);
            context.Response.Write(GetJson(dt));
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
                    sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("~/", "/").Replace("\r\n","").Trim() + "\",");
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