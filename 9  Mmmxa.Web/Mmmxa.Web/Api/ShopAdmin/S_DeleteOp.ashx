<%@ WebHandler Language="C#" Class="S_DeleteOp" %>

using System;
using System.Web;

using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using System.IO;
using System.Collections.Generic;
using ShopNum1MultiEntity;

public class S_DeleteOp : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        try
        {
            if (Common.ReqStr("type") != "" && HttpContext.Current.Request.Cookies["MemberLoginCookie"]!=null)
            {
                string strType = Common.ReqStr("type");
                Shop_News_Action News_Action = (Shop_News_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_News_Action();
                Shop_Video_Action Video_Action = (Shop_Video_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Video_Action();
                Shop_ShopLink_Action ShopLink_Action = (Shop_ShopLink_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopLink_Action();

                Shop_Coupon_Action Coupon_Action = (Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action();

                ShopNum1_Shop_ScoreProduct_Action Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();

                ShopNum1_ScoreOrderInfo_Action ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();

                ShopNum1_ZtcApply_Action ZtcApply_Action = (ShopNum1_ZtcApply_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcApply_Action();

                ShopNum1_ZtcGoods_Action ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcGoods_Action();


                Shop_NewsCategory_Action NewsCategory_Action = (Shop_NewsCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_NewsCategory_Action();


                Shop_VideoCategory_Action VideoCategory_Action = (Shop_VideoCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_VideoCategory_Action();


                ShopNum1_AdvancePaymentApplyLog_Action AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();

                ShopNum1_AdvertPay_Action AdvertPay_Action = (ShopNum1_AdvertPay_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_AdvertPay_Action();
                
                string strDelid = context.Request.QueryString["delid"].ToString().Replace("''", "'");
                switch (strType)
                {
                    case "ShopNews"://删除店铺资讯
                        News_Action.DeleteNews(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ShopVideo"://删除店铺视频
                        Video_Action.DeleteVideoInfo(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ShopLink"://删除友情链接
                        ShopLink_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ShopCoupon"://删除优惠券
                        Coupon_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ShopSEO"://删除seo
                        context.Response.Write(DeleteSeoXml(strDelid));
                        break;
                    case "ScoreProduct"://删除积分商品
                        Shop_ScoreProduct_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ScoreOrderInfo"://删除积分订单
                        try
                        {
                            ScoreOrderInfo_Action.DeleteProductNew(strDelid);
                            ScoreOrderInfo_Action.Delete(strDelid);
                            context.Response.Write("ok");
                        }
                        catch (Exception ex)
                        {

                        }

                        break;
                    case "ZtcApply"://删除直通车申请
                        ZtcApply_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ZtcGoods"://删除直通车商品
                        ZtcGoods_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "Shop_NewsCategory"://删除资讯分类
                        NewsCategory_Action.DeleteNewsCategory(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "Shop_VideoCategory"://删除视频分类
                        VideoCategory_Action.DeleteVideoCategory(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "PaymentApplyLog"://删除充值
                        AdvancePaymentApplyLog_Action.Delete("'"+strDelid+"'");
                        context.Response.Write("ok");
                        break;
                    case "AdvertPay"://删除付费广告
                        AdvertPay_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "delpic"://删除图片
                        if (strDelid != "")
                        {
                            List<ShopNum1_Shop_Image> listSpecValue = new List<ShopNum1_Shop_Image>();
                            Shop_Image_Action Image_Action = (Shop_Image_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Image_Action();
                            string[] arryId = strDelid.Split(',');
                            string[] arryImg = Common.ReqStr("path").Split(',');
                            for (int i = 0; i < arryId.Length; i++)
                            {
                                ShopNum1_Shop_Image si = new ShopNum1_Shop_Image();
                                si.Id = Convert.ToInt32(arryId[i]);
                                listSpecValue.Add(si);

                                //string webFilePath = HttpContext.Current.Server.MapPath(arryImg[i].Replace("$path$", "ImgUpload"));
                                //if (File.Exists(webFilePath))
                                //{
                                //    File.Delete(webFilePath); 
                                //}
                            }
                           int x= Image_Action.DeleteSelectImg(listSpecValue);
                           if (x > 0)
                           {
                               context.Response.Write("ok");
                           }
                           else {
                               context.Response.Write("error");
                           }
                        }
                        else
                        {
                            string webFilePath = HttpContext.Current.Server.MapPath(Common.ReqStr("path").Replace("-", "/"));
                            if (File.Exists(webFilePath))
                            {
                                File.Delete(webFilePath); context.Response.Write("ok");
                            }
                        }
                        break;
                }
            }
        }
        catch { context.Response.Write("error"); }
    }

    public string DeleteSeoXml(string pages)
    {
        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //会员登录ID
        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
        string SetPath = string.Empty;
        Shop_ShopInfo_Action companyInfoAction = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
        System.Data.DataTable dataTable = companyInfoAction.GetMemLoginInfo(MemberLoginID);
        string shopid = dataTable.Rows[0]["ShopID"].ToString();

        string OpenTime = DateTime.Parse(dataTable.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
        SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + shopid + "/xml/SetMeto.xml";
        
        IShopNum1_ExtendSiteMota_Action ExtendSiteMota = ShopNum1.Factory.LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
        if (ExtendSiteMota.delete(pages, SetPath) > 0)
        {
            MessageBox.Show("删除成功！");
            return "ok";
        }
        return "error";
    }
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}