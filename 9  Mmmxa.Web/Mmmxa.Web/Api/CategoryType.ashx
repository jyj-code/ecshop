<%@ WebHandler Language="C#" Class="CategoryType" %>

using System;
using System.Web;
using ShopNum1.BusinessLogic;
public class CategoryType : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        ShopNum1_CategoryType_Action ShopNum1_ct=new ShopNum1_CategoryType_Action ();
        if (context.Request.QueryString["oid"] != null)
        {
            string str=context.Request.QueryString["oid"].ToString();
            try
            {
                ShopNum1_ct.update_CategoryType_Order(str.Split('|')[0], str.Split('|')[1]);
                context.Response.Write("ok");
            }
            catch { context.Response.Write("error"); }
        }
        else if (context.Request.QueryString["delBatchId"] != null)
        {
            try
            {
                string strDelBatchId = context.Request.QueryString["delBatchId"].ToString();
                ShopNum1_ct.DeleteBatch_CategoryType(strDelBatchId);
                context.Response.Write("ok");
            }
            catch { context.Response.Write("error"); }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}