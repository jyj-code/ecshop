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
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using Com.Alipay;
using System.Collections.Generic;

public partial class PayReturn_Alipay_alidirect_pay_send : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.ReqStr("aliorderId") != "" && Common.ReqStr("sign") == "alipaydirect" && Common.ReqStr("productname") != "" && Common.ReqStr("total_fee")!="")
        {
            string aliorderId = Common.ReqStr("aliorderId");
            string productname = Encryption.Decrypt(Common.ReqStr("productname"));
            string total_fee = Common.ReqStr("total_fee");
            DataTable dataTablePament = null;
            ShopNum1_Payment_Action shopNum1_Payment_Action = new ShopNum1_Payment_Action();
            dataTablePament = shopNum1_Payment_Action.GetPaymentKey("alidirectpay.aspx");
            ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = new ShopNum1_ShopPayment_Action();
            if (dataTablePament == null || dataTablePament.Rows.Count <= 0)
            {
                //dataTablePament = shopNum1_ShopPayment_Action.GetPaymentKey("alidirectpay.aspx");
                //if (dataTablePament == null || dataTablePament.Rows.Count <= 0)
                //{
                    MessageBox.Show("支付有异常！");
                    return;
                //}
            }

            ////////////////////////////////////////////请求参数////////////////////////////////////////////
            //支付类型
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径
            string notify_url ="http://" +ShopSettings.siteDomain+"/PayReturn/Alipay/alidirect_pay_show.aspx";
            //页面跳转同步通知页面路径
            string return_url ="http://" +ShopSettings.siteDomain+"/PayReturn/Alipay/alidirect_pay_receive.aspx";

            //卖家支付宝帐户
            string seller_email = dataTablePament.Rows[0]["Email"].ToString().Trim();
            //必填
            //商户订单号
            string out_trade_no = aliorderId;
            //商户网站订单系统中唯一订单号，必填
            //订单名称
            string subject = productname;
            //必填
            //付款金额
            //必填
            //订单描述
            string body = aliorderId;
            //默认支付方式
            string paymethod = "bankPay";
            //必填
            //默认网银
            string defaultbank ="CMB";
            //必填，银行简码请参考接口技术文档
            //商品展示地址
            string show_url = "http://www.groupfly.com/M_Index.aspx";
            string anti_phishing_key = "";
            //若要使用请调用类文件submit中的query_timestamp函数
            //客户端的IP地址
            string exter_invoke_ip = "";
            //非局域网的外网IP地址，如：221.0.0.1
            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", dataTablePament.Rows[0]["MerchantCode"].ToString());
            sParaTemp.Add("_input_charset","utf-8");
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("seller_email", seller_email);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("paymethod", paymethod);
            sParaTemp.Add("defaultbank", defaultbank);
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);
            //建立请求
            AliPayDirectConfig.Partner = dataTablePament.Rows[0]["MerchantCode"].ToString();
            AliPayDirectConfig.Key = dataTablePament.Rows[0]["SecretKey"].ToString();
            string sHtmlText =AliPayDirectSubmit.BuildRequest(sParaTemp, "get", "确认");
            Response.Write(sHtmlText);
        }
    }
}
