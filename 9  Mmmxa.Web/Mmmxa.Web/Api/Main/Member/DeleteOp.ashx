<%@ WebHandler Language="C#" Class="DeleteOp" %>

using System;
using System.Web;

using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
public class DeleteOp : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        try
        {
            if (Common.ReqStr("type") != "")
            {
                string strType = Common.ReqStr("type");
                ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = new ShopNum1_MessageInfo_Action();
                ShopNum1_MemberMessage_Action shopNum1_MemberMessage_Action = new ShopNum1_MemberMessage_Action();
                ShopNum1_MemberReport_Action MemberReport_Action = (ShopNum1_MemberReport_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MemberReport_Action();
                ShopNum1_OrderComplaintsReplyList_Action OrderComplaintsReplyList_Action = (ShopNum1_OrderComplaintsReplyList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action();

                ShopNum1_Collect_Action Collect_Action = (ShopNum1_Collect_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Collect_Action();
                
                Shop_SupplyDemand_Action SupplyDemand_Action=(Shop_SupplyDemand_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_SupplyDemand_Action();

                Shop_VideoComment_Action VideoComment_Action = (Shop_VideoComment_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_VideoComment_Action();

                ShopNum1_VedioCommentChecked_Action VedioCommentChecked_Action = (ShopNum1_VedioCommentChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_VedioCommentChecked_Action();

                ShopNum1_ArticleCheck_Action ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ArticleCheck_Action();

                Shop_News_Action News_Action = (Shop_News_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_News_Action();

                ShopNum1_SupplyDemandComment_Action SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SupplyDemandComment_Action();


                Shop_MessageBoard_Action MessageBoard_Action = (Shop_MessageBoard_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_MessageBoard_Action();
                
                string strDelid =context.Request.QueryString["delid"].ToString().Replace("''", "'");
                switch (strType)
                {
                    case "sysmsg":
                        shopNum1_MessageInfo_Action.Delete_SysMsg(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "msg":
                        shopNum1_MemberMessage_Action.Delete_Msg(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "Report"://会员中心删除举报信息
                        MemberReport_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "OrderComplaint"://会员中心删除投诉信息
                        OrderComplaintsReplyList_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "MemberProductCollect"://会员中心删除商品收藏信息
                        Collect_Action.DeleteMemberProductCollect(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ShopCollect"://会员中心删除店铺收藏信息
                        Collect_Action.DeleteMemberShopCollect(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "SupplyDemand"://删除供求信息
                        SupplyDemand_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ShopVideoComment"://删除店铺视频评论
                        VideoComment_Action.Delete(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "VideoComment"://删除视频信息
                        VedioCommentChecked_Action.DeleteVideoComment(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ArticleComment"://删除平台咨询评论
                        ArticleCheck_Action.DeleteArticleComment(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "ShopNewsComment"://删除店铺资讯评论信息
                        News_Action.DeleteNewsComment(strDelid);
                        context.Response.Write("ok");
                        break;
                    case "SupplyDemandComment"://删除供求评论
                        SupplyDemandComment_Action.DeleteSupplyDemandComment(strDelid);
                        context.Response.Write("ok");
                        break;

                    case "shopmessageBoard"://删除店铺留言信息
                        MessageBoard_Action.DeleteMessageBoard(strDelid);
                        context.Response.Write("ok");
                        break;
                        
                        
                }
            }
        }
        catch { context.Response.Write("error"); }
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}