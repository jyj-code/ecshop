<%@ WebHandler Language="C#" Class="ProductListOp" %>

using System;
using System.Web;
using ShopNum1.Common;
using System.Text;
using ShopNum1.ShopBusinessLogic;
using System.Data;
using ShopNum1.ShopFactory;

public class ProductListOp : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        string strType = Common.ReqStr("type");
        string strShowCount = "", strShopID = "", strMemLoginID = "";
        DataTable dataTable = null;
        Shop_Product_Action productAction = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
        Shop_ShopInfo_Action shopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
        switch (strType)
        {
            case "salerank":
                strShowCount = ShopSettings.GetValue("SellOrderCount");
                strShopID = Common.ReqStr("shopid") == "" ? "0" : Common.ReqStr("shopid");
                strMemLoginID = shopInfo_Action.GetMemberLoginidByShopid(strShopID).ToString();
                try
                {
                    int.Parse(strShowCount);
                }
                catch
                {
                    strShowCount = "10";
                }
                dataTable = productAction.GetSaleRankingProduct(strShowCount.ToString(), strMemLoginID);
                context.Response.Write(GetJson(dataTable));
                break;
            case "collectrank":
                strShowCount = ShopSettings.GetValue("SellOrderCount");
                strShopID = Common.ReqStr("shopid") == "" ? "0" : Common.ReqStr("shopid");
                strMemLoginID = shopInfo_Action.GetMemberLoginidByShopid(strShopID).ToString();
                try
                {
                    int.Parse(strShowCount);
                }
                catch
                {
                    strShowCount = "10";
                }
                dataTable = productAction.GetCollectRankingProduct(strShowCount.ToString(), strMemLoginID);
                context.Response.Write(GetJson(dataTable));
                break;
            default: break;
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
                    if (dt.Columns[j].ColumnName.ToLower() == "guid")
                    {
                        sbJson.Append("\"url\":\"" + GetPageName.RetUrl("ProductDetail", dt.Rows[i][j].ToString()) + "\","); 
                    }
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
    public bool IsReusable {
        get {
            return false;
        }
    }

}