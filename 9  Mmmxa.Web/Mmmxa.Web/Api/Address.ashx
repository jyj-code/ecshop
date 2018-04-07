<%@ WebHandler Language="C#" Class="Address" %>

using System;
using System.Web;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System.Web.UI.WebControls;
using ShopNum1MultiEntity;
using System.Configuration;
using ShopNum1.Email;
using System.IO;
using ShopNum1.DiscuzToolkit;
using ShopNum1.DiscuzHelper;
using ShopNum1.Standard;
using ShopNum1.Ucenter.Request;
using System.Net;
using ShopNum1_Second;
using System.Web.UI;
using ShopNum1.ShopBusinessLogic;
using System.Collections.Generic;


public class Address : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string code = context.Request.QueryString["AddressCode"] == null ? "0" : context.Request.QueryString["AddressCode"].ToString();

        string Type = context.Request.QueryString["type"] == null ? "" : context.Request.QueryString["type"].ToString();

        string yzm = context.Request.QueryString["YzCode"] == null ? "" : context.Request.QueryString["YzCode"].ToString();

        string num = context.Request.QueryString["num"] == null ? "" : context.Request.QueryString["num"].ToString();

        string name = context.Request.QueryString["name"] == null ? "" : HttpUtility.HtmlDecode(context.Request.QueryString["name"].ToString());

        string AddressCode = context.Request.QueryString["code"] == null ? "" : context.Request.QueryString["code"].ToString();

        string phone = context.Request.QueryString["phone"] == null ? "" : context.Request.QueryString["phone"].ToString();

        string postCode = context.Request.QueryString["postCode"] == null ? "" : context.Request.QueryString["postCode"].ToString();

        string adress = context.Request.QueryString["adress"] == null ? "" : HttpUtility.HtmlDecode(context.Request.QueryString["adress"].ToString());

        string email = context.Request.QueryString["email"] == null ? "" : context.Request.QueryString["email"].ToString();

        string productGuid = context.Request.QueryString["productGuid"] == null ? "" : context.Request.QueryString["productGuid"].ToString();


        string proGuid = context.Request.QueryString["proguid"] == null ? "" : context.Request.QueryString["proguid"].ToString();
        switch (Type)
        {
            case "adress" :
                context.Response.Write(BindRegionCode(code));//获取收货地址 三级联动
                break;
            case "Yzm":
                context.Response.Write(GetSafecode(yzm));//验证码
                break;
            case "order":
                context.Response.Write(CreateOrder(num, name, AddressCode, phone, postCode, adress, email, productGuid));//验证码
                break;
            case "kc":
                context.Response.Write(GetRepertoryCount(proGuid));//验证码
                break;
            default: ;
                break;
        }
        
        
    }

    //获得库存
    public string GetRepertoryCount(string guid)
    {
        ShopNum1_Shop_ScoreProduct_Action Shop_ScoreProductNew_Action = (ShopNum1_Shop_ScoreProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
        DataTable dataRepertoryCount = Shop_ScoreProductNew_Action.GetInfoByGuid(guid);
        if (dataRepertoryCount != null && dataRepertoryCount.Rows.Count > 0)
        {
            return dataRepertoryCount.Rows[0]["RepertoryCount"].ToString();
        }
        else
        {
            return "";
        }
        
    }

    //生成积分订单    
    public string CreateOrder(string num, string name, string code, string phone, string postCode, string adress, string email,string productGuid)
    {
        string msg=string.Empty;
        string MemLoginID=string.Empty;
        if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
        {
            HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
            
            //求商品信息
            ShopNum1_Shop_ScoreProduct_Action Shop_ScoreProductNew_Action = (ShopNum1_Shop_ScoreProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            DataTable dataTable = Shop_ScoreProductNew_Action.GetInfoByGuid(productGuid, 1, 1, 0);
            MemLoginID = decodedCookieShopNum1MemberLogin.Values["MemLoginID"].ToString();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                ShopNum1_ScoreOrderInfo ScoreOrderInfo = new ShopNum1_ScoreOrderInfo();
                Order ord = new Order();
                string newOrder = ord.CreateOrderNumber();
                ScoreOrderInfo.Address =code+"|"+adress;
                ScoreOrderInfo.ConfirmTime = Convert.ToDateTime("1900-1-1");
                ScoreOrderInfo.CreateTime = DateTime.Now;
                ScoreOrderInfo.Email = email;
                ScoreOrderInfo.Guid = Guid.NewGuid();
                ScoreOrderInfo.IsDeleted = 0;
                ScoreOrderInfo.MemLoginID = MemLoginID;
                ScoreOrderInfo.Mobile = phone;
                ScoreOrderInfo.ModifyTime = DateTime.Now;
                ScoreOrderInfo.ModifyUser = MemLoginID;
                ScoreOrderInfo.Name = name;
                ScoreOrderInfo.OderStatus = 0;
                ScoreOrderInfo.OrderNumber = newOrder;
                ScoreOrderInfo.Postalcode = postCode;
                ScoreOrderInfo.ShopMemLoginID = dataTable.Rows[0]["MemLoginID"].ToString();//商家
                ScoreOrderInfo.ShopName = "";//商家名称
                ScoreOrderInfo.Tel = phone;
                int allScore=Convert.ToInt32(dataTable.Rows[0]["Score"].ToString())*Convert.ToInt32(num);
                ScoreOrderInfo.TotalScore = allScore;//总分
                ScoreOrderInfo.UserMsg = "兑换积分";
                #region 求店铺所在分站
                string strSubstationID = string.Empty;
                try
                {
                    strSubstationID = Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + dataTable.Rows[0]["MemLoginID"].ToString() + "'   ");
                }
                catch (Exception ex)
                { }

                #endregion
                ScoreOrderInfo.SubstationID = strSubstationID;
                //商品
                List<ShopNum1_ScoreOrderProduct> listOrderProduct = new List<ShopNum1_ScoreOrderProduct>();
                ShopNum1_ScoreOrderProduct ScoreOrderProduct = new ShopNum1_ScoreOrderProduct();
                ScoreOrderProduct.BuyNumber = Convert.ToInt32(num);
                ScoreOrderProduct.Guid = Guid.NewGuid();
                ScoreOrderProduct.Name = dataTable.Rows[0]["Name"].ToString();//商品名
                ScoreOrderProduct.OrderNumber = newOrder;
                ScoreOrderProduct.ProductGuid = new Guid(productGuid);
                ScoreOrderProduct.RepertoryNumber = dataTable.Rows[0]["RepertoryNumber"].ToString();//商品型号
                ScoreOrderProduct.Score = allScore;//积分

                 listOrderProduct.Add(ScoreOrderProduct);
                ShopNum1_ScoreOrderInfo_Action ScoreOrderInfo_Action=(ShopNum1_ScoreOrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
                
                try
                {
                    int check = ScoreOrderInfo_Action.Add(ScoreOrderInfo, listOrderProduct);
                    if (check > 0)
                    {
                        //订单生成成功后扣除积分
                        ScoreOrderInfo_Action.UseUserScore(MemLoginID, allScore.ToString());
                        
                        //生成日志
                        //获取当前积分
                        int UserScore = 0;
                        DataTable dataScore = Shop_ScoreProductNew_Action.GetScoreByMemLoginID(MemLoginID);
                        if (dataScore != null && dataScore.Rows.Count>0)
                        {
                            UserScore = Convert.ToInt32(dataScore.Rows[0]["Score"]) + allScore;
                        }

                        int lastScore = Convert.ToInt32(dataScore.Rows[0]["Score"]);
                        ShopNum1_ScoreModifyLog_Action ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
                        ShopNum1_ScoreModifyLog ScoreModifyLog = new ShopNum1_ScoreModifyLog();
                        ScoreModifyLog.CreateTime = DateTime.Now;
                        ScoreModifyLog.CreateUser = MemLoginID;
                        ScoreModifyLog.CurrentScore = UserScore;//当前积分
                        ScoreModifyLog.Date = DateTime.Now;
                        //ScoreModifyLog.EnteMemLoginID = "";
                        ScoreModifyLog.Guid = Guid.NewGuid();
                        ScoreModifyLog.IsDeleted = 0;
                        ScoreModifyLog.LastOperateScore = lastScore;//最后积分
                        ScoreModifyLog.MemLoginID = MemLoginID;
                        ScoreModifyLog.Memo = "兑换商品消费积分";
                        ScoreModifyLog.OperateScore = allScore;
                        ScoreModifyLog.OperateType = 3;//消费减少
                        //操作
                        ScoreModifyLog_Action.OperateScore(ScoreModifyLog);
                        
                        msg = "ok";
                    }
                    else
                    {
                        msg = "no";
                    }
                }
                catch(Exception ex)
                {}
                
            }
            else
            {
                msg = "noProduct";
            }
            
            
            //会员登录ID
            
            
        }
        else
        {
            msg= "nologin";
        }
        return msg;
        //已经登录 
    }
    
    
    //验证码
    private string GetSafecode(string verifycodetype)
    {
        if (verifycodetype.ToLower() == HttpContext.Current.Session["code"].ToString().ToLower())
        {
            return "true";
        }

        return "false";
    }

    

    private string  BindRegionCode(string fatherID)
    {
        string ID = fatherID.Split('/')[1].ToString();
        int intCodeID = Convert.ToInt32(ID);
        
        Shop_Category_Action productCategory_Action = (Shop_Category_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Category_Action();
        string GetOption = string.Empty;
        DataTable dataTable = productCategory_Action.GetRegionFatherID(intCodeID.ToString());
        GetOption = "<option value=\"-1\">-请选择-</option> ";
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            GetOption += "<option value=" + dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString() + ">" + dataTable.Rows[i]["Name"].ToString() + "</option>";
        }
        return GetOption;
    }
    
    
    

    bool IHttpHandler.IsReusable
    {
        get { throw new NotImplementedException(); }
    }
}