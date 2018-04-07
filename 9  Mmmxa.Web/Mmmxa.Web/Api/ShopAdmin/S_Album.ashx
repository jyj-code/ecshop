<%@ WebHandler Language="C#" Class="S_Album" %>

using System;
using System.Web;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopInterface;
using System.Text;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Interface;

public class S_Album : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (Common.ReqStr("op") != "")
        {
            Shop_ImageCategory_Action shop_ImageCategory_Action = new Shop_ImageCategory_Action();
            string strname = HttpUtility.HtmlDecode(Common.ReqStr("name")).Replace("%2f","/");
            string strdesc = HttpUtility.HtmlDecode(Common.ReqStr("desc"));
            string strsort = HttpUtility.HtmlDecode(Common.ReqStr("sort"));
            string strid = HttpUtility.HtmlDecode(Common.ReqStr("id"));
            switch (Common.ReqStr("op"))
            {
                case "addalbum":
                    shop_ImageCategory_Action.Insert(GetMemLoginId(), strname, strdesc, strsort);
                    context.Response.Write("ok");
                    ; break;
                case "getalbum":
                    context.Response.Write(GetJson(shop_ImageCategory_Action.Select_AllType(GetMemLoginId()))); break;
                case "setalbum":
                    context.Response.Write(shop_ImageCategory_Action.UpdateAlbumImg(Common.ReqStr("typeid"), Common.ReqStr("imgpath").Replace("-", "/")).ToString()); break;
                //修改相册名称
                case "editAlbumName":
                    shop_ImageCategory_Action.Update(strid, strname, "", strsort);
                    ; break;
                case "savename":
                    Shop_Image_Action Image_Action = new Shop_Image_Action();
                    Image_Action.UpdateImgName(strname, Common.ReqStr("id"), GetMemLoginId());
                    context.Response.Write("ok"); break;
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
                    sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j] + "\",");
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
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}