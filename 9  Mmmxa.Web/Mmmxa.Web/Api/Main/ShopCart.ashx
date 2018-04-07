<%@ WebHandler Language="C#" Class="ShopCart" %>

using System;
using System.Web;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Collections.Generic;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopInterface;


public class ShopCart : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string strguid = Common.ReqStr("guid");
        string strnum = Common.ReqStr("num");
        string strprice = Common.ReqStr("pirce");
        string strpguid = Common.ReqStr("pguid");
        string strMemloginId = HttpUtility.HtmlDecode(Common.ReqStr("mid"));
        if (strguid != "" && strnum != "" && strprice != "" && strpguid != "")
        {
            List<ShopNum1_Shop_Cart> listCart = new List<ShopNum1_Shop_Cart>();
            ShopNum1_Shop_Cart tempCart = new ShopNum1_Shop_Cart();
            tempCart.Guid = new Guid(Common.ReqStr("guid"));
            tempCart.BuyPrice = Convert.ToDecimal(Common.ReqStr("pirce"));
            tempCart.BuyNumber = Convert.ToInt32(Common.ReqStr("num"));
            listCart.Add(tempCart);
            //Shop_Product_Action productAction = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
            //int limitBuyCount = productAction.GetLimitBuyCount(Common.ReqStr("pguid"));
            //if (limitBuyCount < tempCart.BuyNumber)
            //{
            //    if (limitBuyCount != 0)
            //    {
            //        context.Response.Write(limitBuyCount);
            //        return;
            //    }
            //}
            ShopNum1_Cart_Action cartAction=(ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
            cartAction.Update(listCart); context.Response.Write("ok");
        }
        else if (strguid != "" & Common.ReqStr("sign") == "address")
        {
            System.Threading.Thread.Sleep(200);
            ShopNum1_Address_Action address_action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
            address_action.ChangeDefaultAddress(strMemloginId, strguid);
            context.Response.Write("ok");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}