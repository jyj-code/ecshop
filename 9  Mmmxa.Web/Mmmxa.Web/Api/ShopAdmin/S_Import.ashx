<%@ WebHandler Language="C#" Class="S_Import" %>

using System;
using System.Web;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using System.Data;
using System.Text;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using System.IO;
using System.Web.UI.WebControls;
using System .Web.SessionState;

public class S_Import : IHttpHandler,IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Buffer = true;
        context.Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
        context.Response.Expires = 0;
        context.Response.CacheControl = "no-cache";
        if (Common.ReqStr("type") != "")
        {
            string strType = Common.ReqStr("type"); string strId = ""; DataTable dt_Type = null;
            switch (strType)
            {
                case "ctype":
                    ShopNum1_CategoryType_Action ct=(ShopNum1_CategoryType_Action)LogicFactory.CreateShopNum1_CategoryType_Action();
                    dt_Type = ct.Select_ProductCategoryType();
                    context.Response.Write(GetJson(dt_Type));
                    break;
                case "ptype":
                    strId = Common.ReqStr("id");
                    ShopNum1_ProductCategory_Action shopPc_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
                    dt_Type = shopPc_Action.GetCategory(strId);
                    context.Response.Write(GetJson(dt_Type)); break;
                case "stype":
                    strId = Common.ReqStr("id");
                    Shop_ProductCategory_Action shop_ProductCategory = (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
                    dt_Type = shop_ProductCategory.Search_Import(strId, GetMemLoginId(context));
                    context.Response.Write(GetJson(dt_Type)); break;
                case "btype":
                    strId = Common.ReqStr("id")=="0"?"":Common.ReqStr("id");
                    ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
                    dt_Type = shopNum1_Brand_Action.dt_Select_BrandByCid(strId);
                    context.Response.Write(GetJson(dt_Type)); break;
                case "vtype":
                    Shop_ImageCategory_Action shop_ImageCategory_Action = (Shop_ImageCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ImageCategory_Action();
                    dt_Type = shop_ImageCategory_Action.dt_Album_Import(GetMemLoginId(context));
                    context.Response.Write(GetJson(dt_Type)); break;
                    break;
                default: break;
            }
        }
        else if (Common.ReqStr("logid") != "")
        {
            try
            {
                string strMemloginId = Common.ReqStr("logid");
                HttpPostedFile file = context.Request.Files["Filedata"];
                int fileLength = Convert.ToInt32(file.ContentLength / 1024);
                if (fileLength < 1000000)
                {
                    string strShopId = "";
                    ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
                    strShopId = shopNum1_ShopInfoList_Action.GetShopid(strMemloginId);
                    string fileName = file.FileName;
                    string fileType = Path.GetExtension(fileName).ToLower();

                    //计算总共的大小
                    //ShopNum1.BusinessLogic.ShopNum1_ShopInfoList_Action ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
                    //DataTable dataTableRank = ShopInfoList_Action.Search(strMemloginId);
                    //string strMaxFileCount = dataTableRank.Rows[0]["BmaxFileCount"].ToString();
                    //long LongMaxFileCount = Convert.ToInt64(strMaxFileCount) * 1024 * 1024;
                    ////由于不同浏览器取出的FileName不同（有的是文件绝对路径，有的是只有文件名），故要进行处理
                    //if (loadImageSzie(strMemloginId) + Convert.ToInt32(file.ContentLength) > LongMaxFileCount)
                    //{
                    //    context.Response.Write("error|空间已满，无法继续上传数据了！");
                    //    return;
                    //}
                    if (fileName.IndexOf(' ') > -1)
                    {
                        fileName = fileName.Substring(fileName.LastIndexOf(' ') + 1);
                    }
                    else if (fileName.IndexOf('/') > -1)
                    {
                        fileName = fileName.Substring(fileName.LastIndexOf('/') + 1);
                    }
                    //上传的目录
                    string uploadDir = "/fileupload/" + strShopId + "/" + System.DateTime.Now.ToString("yyyy_MM") + "/";
                    //生成年月文件夹及日文件夹
                    if (!Directory.Exists(context.Server.MapPath(uploadDir)))
                    {
                        Directory.CreateDirectory(context.Server.MapPath(uploadDir));
                    }
                    Random r = new Random();
                    string uploadPath = uploadDir + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
                    //保存文件
                    file.SaveAs(context.Server.MapPath(uploadPath));
                    context.Response.Write("ok|" + uploadPath);
                }
                else
                {
                    context.Response.Write("error|您上传的文件为" + fileLength + ",上传文件超过了100M！");
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("error|上传失败,上传的文件店铺容量100M！<br/>详细错误信息：" + ex.Message);
            } 
        }
    }
    //加载店铺空间容量
    public long loadImageSzie(string strMemloginId)
    {
        Shop_ShopInfo_Action shopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
        DataTable dataTables = shopInfo_Action.GetMemLoginInfo(strMemloginId);
        string openTime = DateTime.Parse(dataTables.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
        XmlDataSource XmlDataSourceData = new XmlDataSource();
        DataTable dataTable = shopInfo_Action.GetMemLoginInfo(strMemloginId);
        string shopid = dataTable.Rows[0]["ShopID"].ToString();
        string imageSpec = "~/Shop/Shop/" + openTime.Replace("-", "/") + "/shop" + shopid + "/Site_Settings.xml";
        DataSet ds = new DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath(imageSpec));
        DataRow dr = ds.Tables["Setting"].Rows[0];
        return Convert.ToInt64(dr["UserImageSpace"]);
    }
    //获取登录用户方法
    private string GetMemLoginId(HttpContext context)
    {
        string name = "jely";
        HttpCookie cookies = context.Request.Cookies["MemberLoginCookie"];
        if (cookies != null)
        {
            HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookies);
            name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"].ToString();
        }
        return name;
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
                    sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("~/", "/") + "\",");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("},");
            }
            sbJson.Remove(sbJson.Length - 1, 1);
            sbJson.Append("]");
        }
        else {
            sbJson.Append(""); 
        }
        return sbJson.ToString();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}