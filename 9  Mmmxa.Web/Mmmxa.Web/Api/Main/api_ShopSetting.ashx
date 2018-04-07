<%@ WebHandler Language="C#" Class="api_ShopSetting" %>


using System;
using System.Web;
using ShopNum1MultiEntity;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using ShopNum1.Common;
using ShopNum1.WeiXinCommon.Enum;
using System.Collections.Generic;
using ShopNum1.BusinessLogic;
using ShopNum1.Interface;


public class api_ShopSetting : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string type = context.Request.QueryString["type"] ?? string.Empty;
        string shopnumloginid = "admin";
        if (type == "shop_appconfigop")
        {
            string flash = context.Request.QueryString["flash"] ?? string.Empty;
            string flashurl = context.Request.QueryString["flashurl"] ?? string.Empty;
            string shopid = "0";
            string ctype = context.Request.QueryString["configtype"] ?? string.Empty;
            List<ShopNum1_AdvertisementImage> configlists = new List<ShopNum1_AdvertisementImage>();
            string[] ImgSrc = flash.Split(',');
            string[] ImgUrl = flashurl.Split(',');
            for (int nI = 0; nI < ImgSrc.Length; nI++)
            {
                if (!string.IsNullOrEmpty(ImgSrc[nI]))
                {
                    ShopNum1_AdvertisementImage shopconfigs = new ShopNum1_AdvertisementImage();
                    shopconfigs.MemLoginID = shopnumloginid;
                    shopconfigs.ShopID = Convert.ToInt32(shopid);
                    shopconfigs.Value = ImgSrc[nI];
                    shopconfigs.Url = ImgUrl[nI];
                    shopconfigs.ConfigType = Convert.ToByte(Convert.ToInt32(ctype));
                    configlists.Add(shopconfigs);
                }
            }
            ShopNum1_AdvertisementImage_Action AdImg_Action = new ShopNum1_AdvertisementImage_Action();
            if (AdImg_Action.Add(configlists, shopid, ctype))
            {
                context.Response.Write("{\"errcode\":0,\"errmsg\":\"操作成功!\"}");
            }
            else
            {
                context.Response.Write("{\"errcode\":-1,\"errmsg\":\"操作失败!\"}");
            } 
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}