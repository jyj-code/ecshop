using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;
using Com.Alipay;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

public partial class PayReturn_Alipay_alidirect_pay_show : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SortedDictionary<string, string> sPara = GetRequestPost();

        if (sPara.Count > 0)//判断是否有带返回参数
        {
            string partner = string.Empty;    //合作身份者ID
            string key = string.Empty;                   //安全检验码
            ShopNum1_Payment_Action paymentAction = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable PaymentdataTable = paymentAction.GetPaymentKey("alidirectpay.aspx");//支付宝担保交易
            if (PaymentdataTable.Rows.Count > 0)
            {
                partner = PaymentdataTable.Rows[0]["MerchantCode"].ToString(); //ConfigurationManager.AppSettings["platSupplierID"];    //合作身份者ID
                key = PaymentdataTable.Rows[0]["SecretKey"].ToString(); //ConfigurationManager.AppSettings["key"];                   //安全检验码
            }
            AliPayDirectConfig.Partner = partner;
            AliPayDirectConfig.Key = key;
            AliPayDirectNotify aliNotify = new AliPayDirectNotify();
            bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

            if (verifyResult)//验证成功
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //请在这里加上商户的业务逻辑程序代码


                //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                //商户订单号

                string out_trade_no = Request.Form["out_trade_no"];

                //支付宝交易号

                string trade_no = Request.Form["trade_no"];

                //交易状态
                string trade_status = Request.Form["trade_status"];

                ShopNum1_OrderInfo_Action orderInfoAction = new ShopNum1_OrderInfo_Action();
                if (Request.Form["trade_status"] == "TRADE_FINISHED")
                {
                    System.IO.File.AppendAllText(Server.MapPath("~/log/directali.txt"), "TRADE_FINISHED1");
                    DataTable dataTableOrderInfo = orderInfoAction.SearchOrderInfo(out_trade_no);
                    if (dataTableOrderInfo.Rows.Count > 0)
                    {
                        string strMember = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                        string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                        string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                        string strOrderNumber = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
                        string strOderStatus = dataTableOrderInfo.Rows[0]["OderStatus"].ToString();
                        string strPaymentStatus = dataTableOrderInfo.Rows[0]["PaymentStatus"].ToString();
                        string strShipmentStatus = dataTableOrderInfo.Rows[0]["ShipmentStatus"].ToString();
                        //表示买家已在支付宝交易管理中产生了交易记录，但没有付款
                        //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                        //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是订单未处理状态
                        //注：该交易状态下，也可不做数据库更新程序，此时，建议把该状态的通知信息记录到商户通知日志数据库表中。
                        if (strOderStatus == "0" && strShipmentStatus == "0" && strPaymentStatus == "0")
                        {
                        }
                        else
                        {
                            int checkWaitBuyerPay = orderInfoAction.SetWaitBuyerPay("1", "0", "1", strOrderGuid);
                        }
                        Response.Write("success");
                    }
                    //判断该笔订单是否在商户网站中已经做过处理
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序

                    //注意：
                    //该种交易状态只在两种情况下出现
                    //1、开通了普通即时到账，买家付款成功后。
                    //2、开通了高级即时到账，从该笔交易成功时间算起，过了签约时的可退款时限（如：三个月以内可退款、一年以内可退款等）后。
                }
                else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                {
                    System.IO.File.AppendAllText(Server.MapPath("~/log/directali.txt"), "TRADE_SUCCESS2");
                    Page.Response.Write("success");
                    //判断该笔订单是否在商户网站中已经做过处理
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序

                    //注意：
                    //该种交易状态只在一种情况下出现——开通了高级即时到账，买家付款成功后。
                }
                else
                {
                }

                //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                Response.Write("success");  //请不要修改或删除

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else//验证失败
            {
                Response.Write("fail");
            }
        }
        else
        {
            Response.Write("无通知参数");
        }
    }
    /// <summary>
    /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
    /// </summary>
    /// <returns>request回来的信息组成的数组</returns>
    public SortedDictionary<string, string> GetRequestPost()
    {
        int i = 0;
        SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;

        // Get names of all forms into a string array.
        String[] requestItem = coll.AllKeys;

        for (i = 0; i < requestItem.Length; i++)
        {
            sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
        }

        return sArray;
    }
}
