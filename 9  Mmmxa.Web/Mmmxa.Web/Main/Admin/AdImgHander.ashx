<%@ WebHandler Language="C#" Class="AdImgHander" %>

using System;
using System.Web;

public class AdImgHander : IHttpHandler {
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.Form["imgID"]==null)
        {
            context.Response.Write("failed1");
            context.Response.End();
            return;
        }
        //广告id
        string imgID = string.Empty;
        //标题
        string ImgTitle = string.Empty;
        //链接
        string imgLink = string.Empty;
        //图片位置
        string imgSrc = string.Empty;
        try
        {
         
          imgID = context.Request.Form["imgID"].ToString();
          ImgTitle = context.Request.Form["ImgTitle"].ToString();
          imgLink = context.Request.Form["ImgLink"].ToString();
          imgSrc = context.Request.Form["ImgSrc"].ToString();
          context.Response.Write(SavaAdImg(imgID,ImgTitle,imgLink,imgSrc));
        }
        catch(Exception ex)
        {
            context.Response.Write("error parameter");
            context.Response.End();
            return;
        }
        
       
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    /// <summary>
    /// 保存广告图片
    /// </summary>
    /// <param name="imgID"></param>
    /// <param name="imgTitle"></param>
    /// <param name="imgLink"></param>
    /// <param name="imgSrc"></param>
    /// <returns></returns>
    private string SavaAdImg(string imgID,string imgTitle,string imgLink,string imgSrc)
    {
        ShopNum1.AdXml.DefaultAdvertismentOperate adImgOperate = new ShopNum1.AdXml.DefaultAdvertismentOperate();
        if (adImgOperate.Update(imgID, imgTitle, imgSrc, imgLink) > 0)
        {
            ShopNum1.AdXml.DefaultAdvertismentOperate.ResetDe();
            return "success";
        }
        else
        {
            return "failed3";
        }
        
    }

}