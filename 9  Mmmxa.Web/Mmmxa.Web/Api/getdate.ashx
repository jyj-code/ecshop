<%@ WebHandler Language="C#" Class="getdate" %>

using System;
using System.Web;

public class getdate : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.Write(System.DateTime.Now);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}