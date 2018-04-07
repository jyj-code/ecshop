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
using System.Collections.Generic;
using System.Collections.Specialized;
using Com.Alipay;
using ShopNum1.BusinessLogic;
using ShopNum1MultiEntity;
using ShopNum1.Factory;
using ShopNum1.Common;
using ShopNum1.Interface;


public partial class PayReturn_Alipay_alidirect_pay_receive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SortedDictionary<string, string> sPara = GetRequestGet();

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
            bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);

            if (verifyResult)//验证成功
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //请在这里加上商户的业务逻辑程序代码


                //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                //获取支付宝的通知返回参数，可参考技术文档中页面跳转同步通知参数列表

                //商户订单号

                string out_trade_no = Request.QueryString["out_trade_no"];

                //支付宝交易号

                string trade_no = Request.QueryString["trade_no"];

                //交易状态
                string trade_status = Request.QueryString["trade_status"];


                if (Request.QueryString["trade_status"] == "TRADE_FINISHED" || Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                {
                    //判断该笔订单是否在商户网站中已经做过处理
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序
                    ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    if (Request.QueryString["body"] == "Recharge")
                    {
                        ShopNum1_AdvancePaymentApplyLog_Action AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                        string strAdvancePayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
                        AdvancePaymentModifyLog(1, Convert.ToDecimal(strAdvancePayment), Convert.ToDecimal(Common.ReqStr("price")), "支付宝网银交易会员充值", GetMemLoginId(), Convert.ToDateTime(System.DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                        AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, Common.ReqStr("subject"));
                        Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx"); return;
                    }
                    else
                    {
                        string strSql = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where tradeid='" + out_trade_no + "'";
                        //DataTable dataTableOrderInfo = orderInfoAction.SearchOrderInfo(order_no);
                        DataTable dataTableOrderInfo = ShopNum1.DataAccess.DatabaseExcetue.ReturnDataTable(strSql);
                        if (dataTableOrderInfo.Rows.Count > 0)
                        {
                            string strMember = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                            string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                            string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                            string strOrderNumber = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
                            string strOderStatus = dataTableOrderInfo.Rows[0]["OderStatus"].ToString();
                            string strPaymentStatus = dataTableOrderInfo.Rows[0]["PaymentStatus"].ToString();
                            string strShipmentStatus = dataTableOrderInfo.Rows[0]["ShipmentStatus"].ToString();
                            if (Convert.ToInt32(strPaymentStatus) < 1)
                            {
                                #region 第三方支付记录创建
                                IShopNum1_Payment_Action action = new ShopNum1_Payment_Action();
                                action.InsertPayRecord(new ShopNum1_ThreePaymentRecord()
                                {
                                    GUID = Guid.NewGuid(),
                                    OrderNumber = out_trade_no,
                                    PayMoney = Convert.ToDecimal(strShouldPayPrice),
                                    PayTypeCode = "Alipay.aspx",
                                    PayTypeName = "支付宝网银交易",
                                    PayTypeGuid = Guid.NewGuid().ToString(),
                                    HasPayTime = DateTime.Now,
                                    CreateTime = DateTime.Now

                                });
                                #endregion
                                int check = 0;
                                //付款操作
                                //Common.UpdateInfo("oderstatus=1,paymentstatus=1,paytime=getdate()", "shopnum1_orderinfo", " and ordernumber='" + order_no + "'");
                                check = orderInfoAction.SetPaymentStatus2(
                                out_trade_no, 1, 1, 0, DateTime.Now,
                                Convert.ToDecimal(strShouldPayPrice),
                                Convert.ToDecimal(strShouldPayPrice), trade_no);

                                ShopNum1_OrderProduct_Action OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                                OrderProduct_Action.UpdateStock(strOrderGuid);
                               
                                string strAdvancePayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
                                //AdvancePaymentModifyLog(3, Convert.ToDecimal(strAdvancePayment), Convert.ToDecimal(Common.ReqStr("price")), "支付宝担保交易会员购买商品", GetMemLoginId(), Convert.ToDateTime(System.DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 0);
                                OrderOperateLog("支付宝网银交易会员购买商品", "买家已付款", "等待卖家发货", strOrderGuid);
                            }
                        }
                    }
                    Response.Redirect("/main/Member/m_index.aspx");
                }
                else
                {
                    Response.Write("trade_status=" + Request.QueryString["trade_status"]);
                }

                //打印页面
                Response.Write("验证成功<br />");

                //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else//验证失败
            {
                Response.Write("验证失败");
            }
        }
        else
        {
            Response.Write("无返回参数");
        }
    }
    /// <summary>
    /// 预存款修改日志
    /// </summary>
    /// <param name="OperateType">操作类型</param>
    /// <param name="AdvancePayments">当前预存款</param>
    /// <param name="payMoney">变更预存款</param>
    /// <param name="Memo">备注</param>
    /// <param name="shopMemloginID">会员ID</param>
    /// <param name="time">时间</param>
    /// <param name="type">0增加，1减少</param>
    public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type)
    {
        ShopNum1_AdvancePaymentModifyLog AdvancePayment = new ShopNum1_AdvancePaymentModifyLog();
        AdvancePayment.Guid = Guid.NewGuid();
        AdvancePayment.OperateType = OperateType;//0提现，1充值，2转账，3消费
        AdvancePayment.CurrentAdvancePayment = AdvancePayments;
        AdvancePayment.OperateMoney = payMoney;
        if (type == 1)
        {
            AdvancePayment.LastOperateMoney = AdvancePayments + payMoney;
        }
        else
        {
            AdvancePayment.LastOperateMoney = AdvancePayments - payMoney;
        }
        AdvancePayment.Date = time;
        AdvancePayment.Memo = Memo;
        AdvancePayment.MemLoginID = shopMemloginID;
        AdvancePayment.CreateUser = shopMemloginID;
        AdvancePayment.CreateTime = time;
        AdvancePayment.IsDeleted = 0;
        ShopNum1_AdvancePaymentModifyLog_Action AdvancePaymentModifyLog = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
        AdvancePaymentModifyLog.OperateMoney(AdvancePayment);
    }
    /// <summary>
    /// 订单操作日志
    /// </summary>
    /// <param name="memo"></param>
    protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId)
    {
        ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
        shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
        shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(OrderGuId);
        shopNum1_OrderOperateLog.OderStatus = 1;
        shopNum1_OrderOperateLog.ShipmentStatus = 0;
        shopNum1_OrderOperateLog.PaymentStatus = 1;
        shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
        shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
        shopNum1_OrderOperateLog.Memo = memo;
        shopNum1_OrderOperateLog.OperateDateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        shopNum1_OrderOperateLog.IsDeleted = 0;
        shopNum1_OrderOperateLog.CreateUser = GetMemLoginId();
        ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
        shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
    }
    //获取登录用户方法
    private string GetMemLoginId()
    {
        string name = "jely";
        if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
        {
            HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
            name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"].ToString();
        }
        return name;
    }
    /// <summary>
    /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
    /// </summary>
    /// <returns>request回来的信息组成的数组</returns>
    public SortedDictionary<string, string> GetRequestGet()
    {
        int i = 0;
        SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.QueryString;

        // Get names of all forms into a string array.
        String[] requestItem = coll.AllKeys;

        for (i = 0; i < requestItem.Length; i++)
        {
            sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
        }

        return sArray;
    }
}
