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
using AlipayClass;

using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Interface;

public partial class PayReturn_Alipay_alipay1_receive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList sArrary = GetRequestGet();
        ///////////////////////以下参数是需要设置的相关配置参数，设置后不会更改的//////////////////////
        string partner = string.Empty;    //合作身份者ID
        string key = string.Empty;                   //安全检验码
        ShopNum1_Payment_Action paymentAction = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
        DataTable PaymentdataTable = paymentAction.GetPaymentKey("Alipay.aspx");//支付宝担保交易
        if (PaymentdataTable.Rows.Count > 0)
        {
            partner = PaymentdataTable.Rows[0]["MerchantCode"].ToString(); //ConfigurationManager.AppSettings["platSupplierID"];    //合作身份者ID
            key = PaymentdataTable.Rows[0]["SecretKey"].ToString(); //ConfigurationManager.AppSettings["key"];                   //安全检验码
        }
        string input_charset = "utf-8";                     //字符编码格式 目前支持 gb2312 或 utf-8
        string sign_type = "MD5";                           //加密方式 不需修改
        string transport = "https";                         //访问模式,根据自己的服务器是否支持ssl访问，若支持请选择https；若不支持请选择http
        //////////////////////////////////////////////////////////////////////////////////////////////
        if (sArrary.Count > 0)//判断是否有带返回参数
        {
            AlipayNotify aliNotify = new AlipayNotify(sArrary, Request.QueryString["notify_id"], partner, key, input_charset, sign_type, transport);
            string responseTxt = aliNotify.ResponseTxt; //获取远程服务器ATN结果，验证是否是支付宝服务器发来的请求
            string sign = Request.QueryString["sign"];  //获取支付宝反馈回来的sign结果
            string mysign = aliNotify.Mysign;           //获取通知返回后计算后（验证）的加密结果

            //写日志记录（若要调试，请取消下面两行注释）
            //string sWord = "responseTxt=" + responseTxt + "\n return_url_log:sign=" + Request.QueryString["sign"] + "&mysign=" + mysign + "\n return回来的参数：" + AlipayFunction.Create_linkstring(sArrary);
            //AlipayFunction.log_result(Server.MapPath("log/" + DateTime.Now.ToString().Replace(":", "")) + ".txt",sWord);

            //判断responsetTxt是否为ture，生成的签名结果mysign与获得的签名结果sign是否一致
            //responsetTxt的结果不是true，与服务器设置问题、合作身份者ID、notify_id一分钟失效有关
            //mysign与sign不等，与安全校验码、请求时的参数格式（如：带自定义参数等）、编码格式有关
            if (true)//验证成功
            {
                //获取支付宝的通知返回参数
                string trade_no = Request.QueryString["trade_no"];              //支付宝交易号
                string order_no = Request.QueryString["out_trade_no"];	        //获取订单号
                string total_fee = Request.QueryString["price"];	            //获取总金额
                string subject = Request.QueryString["subject"];                //商品名称、订单名称
                string body = Request.QueryString["body"];                      //商品描述、订单备注、描述
                string buyer_email = Request.QueryString["buyer_email"];        //买家支付宝账号
                string receive_name = Request.QueryString["receive_name"];      //收货人姓名
                string receive_address = Request.QueryString["receive_address"];//收货人地址
                string receive_zip = Request.QueryString["receive_zip"];        //收货人邮编
                string receive_phone = Request.QueryString["receive_phone"];    //收货人电话
                string receive_mobile = Request.QueryString["receive_mobile"];  //收货人手机
                string trade_status = Request.QueryString["trade_status"];      //交易状态
                int sOld_trade_status = 0;							            //获取商户数据库中查询得到该笔交易当前的交易状态
                //打印页面
                lbTrade_no.Text = trade_no;
                lbOut_trade_no.Text = order_no;
                lbTotal_fee.Text = total_fee;
                lbSubject.Text = subject;
                lbBody.Text = body;
                lbBuyer_email.Text = buyer_email;
                LbName.Text = receive_name;
                LbAddress.Text = receive_address;
                LbZip.Text = receive_zip;
                LbPhone.Text = receive_phone;
                LbMobile.Text = receive_mobile;
                lbTrade_status.Text = trade_status;
                lbVerify.Text = "验证成功";
                #region 更变订单状态
                ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
               
                if (Request.Form["trade_status"] == "WAIT_BUYER_PAY")
                {
                    //该判断表示买家已在支付宝交易管理中产生了交易记录，但没有付款
                    //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序
                    //判断该笔订单是否在商户网站中已经做过处理
                    //if (strOderStatus == "0" && strShipmentStatus == "0" && strPaymentStatus == "0")
                    //{
                    //}
                    //else
                    //{
                    //    int checkWaitBuyerPay = orderInfoAction.SetWaitBuyerPay("0", "0", "0", "");
                    //}
                }
                else if (Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS")
                {
                    #region
                    //该判断示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货
                    //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序
                    //判断该笔订单是否在商户网站中已经做过处理
                    //if (strOderStatus == "1" && strPaymentStatus == "1" && strShipmentStatus == "0")
                    //{

                    //}
                    //else
                    //{
                    if (Request.QueryString["body"].ToString().IndexOf("C") != -1)
                    {
                        ShopNum1_AdvancePaymentApplyLog_Action AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                        string strAdvancePayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
                        AdvancePaymentModifyLog(1, Convert.ToDecimal(strAdvancePayment), Convert.ToDecimal(Common.ReqStr("price")), "支付宝担保交易会员充值", GetMemLoginId(), Convert.ToDateTime(System.DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                        AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, Common.ReqStr("subject"));

                        #region 第三方支付记录创建
                        IShopNum1_Payment_Action action = new ShopNum1_Payment_Action();
                        action.InsertPayRecord(new ShopNum1_ThreePaymentRecord()
                        {
                            GUID = Guid.NewGuid(),
                            OrderNumber = order_no,
                            PayMoney = Convert.ToDecimal(total_fee),
                            PayTypeCode = "Alipay.aspx",
                            PayTypeName = "支付宝担保交易充值",
                            PayTypeGuid = Guid.NewGuid().ToString(),
                            HasPayTime = DateTime.Now,
                            CreateTime = DateTime.Now

                        });
                        #endregion
                        Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx"); return;
                    }
                    else
                    {
                        string strSql = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where tradeid='" + order_no + "'";
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
                                    OrderNumber = order_no,
                                    PayMoney = Convert.ToDecimal(strShouldPayPrice),
                                    PayTypeCode = "Alipay.aspx",
                                    PayTypeName = "支付宝担保交易购物",
                                    PayTypeGuid = Guid.NewGuid().ToString(),
                                    HasPayTime = DateTime.Now,
                                    CreateTime = DateTime.Now

                                });
                                #endregion

                                int check = 0;
                                //付款操作
                                //Common.UpdateInfo("oderstatus=1,paymentstatus=1,paytime=getdate()", "shopnum1_orderinfo", " and ordernumber='" + order_no + "'");
                                check = orderInfoAction.SetPaymentStatus2(
                                order_no, 1, 1, 0, DateTime.Now,
                                Convert.ToDecimal(total_fee),
                                Convert.ToDecimal(strShouldPayPrice), trade_no);

                                ShopNum1_OrderProduct_Action OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                                OrderProduct_Action.UpdateStock(strOrderGuid);
                                if (CheckMember(strMember) == 1)
                                {
                                    //更新会员表中的消费总金额CostMoney
                                    ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                    memberAction.UpdateCostMoney(strMember, Convert.ToDecimal(total_fee));
                                }
                                string strAdvancePayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
                                //AdvancePaymentModifyLog(3, Convert.ToDecimal(strAdvancePayment), Convert.ToDecimal(Common.ReqStr("price")), "支付宝担保交易会员购买商品", GetMemLoginId(), Convert.ToDateTime(System.DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 0);
                                OrderOperateLog("支付宝担保交易会员购买商品", "买家已付款", "等待卖家发货", strOrderGuid);
                            }
                        }
                    }
                    Response.Redirect("/main/Member/m_index.aspx");
                    //}
                }
                else if (Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
                {//该判断表示卖家已经发了货，但买家还没有做确认收货的操作

                    //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序
                    //if (strOderStatus == "2" && strPaymentStatus == "1" && strShipmentStatus == "1")
                    //{
                    //}
                    //else
                    //{
                    //    int check = 0;   //付款操作
                    //    Random random = new Random();
                    //    check = orderInfoAction.SetShipmentStatus1(
                    //       "", 2, 1, 1,
                    //        DateTime.Now, //发货时间(订单配送时间)
                    //        "XT_" + DateTime.Now.ToLongTimeString().Replace("-", "") + random.Next(0, 1000) //发货单号
                    //        );
                    //}
                }
                else if (Request.Form["trade_status"] == "TRADE_FINISHED")
                {
                    try
                    {
                        //该判断表示买家已经确认收货，这笔交易完成
                        //判断该笔订单是否在商户网站中已经做过处理（可参考“集成教程”中“3.4返回数据处理”）
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序
                        string strSql = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where OrderNumber='" + order_no + "'";
                        System.IO.File.AppendAllText(Server.MapPath("/log/" + System.DateTime.Now.ToString("yyyyMMdd") + "_Apay.txt"), strSql);
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
                            if (strOderStatus == "2" && strPaymentStatus == "1" && strShipmentStatus == "1")
                            {
                                int check = 0; //买家确认收货（订单基本完成）
                                check = orderInfoAction.SetShipmentStatus2(strOrderGuid, 3, 1, 2);
                            }
                        }
                    #endregion
                    }
                    catch (Exception ex) { System.IO.File.AppendAllText(Server.MapPath("/log/" + System.DateTime.Now.ToString("yyyyMMdd") + "_Apay.txt"), ex.Message); }
                }
                else
                {
                    Response.Write("trade_status=" + Request.QueryString["trade_status"]);
                }
                #endregion 更变订单状态
            }
            else//验证失败
            {
                lbVerify.Text = "验证失败";
            }
        }
        else
        {
            lbVerify.Text = "无返回参数";
        }
    }
    /// <summary>
    /// 订单操作日志
    /// </summary>
    /// <param name="memo"></param>
    protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId)
    {
        if (Request.QueryString["out_trade_no"]!=null)
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
    /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
    /// </summary>
    /// <returns>request回来的信息组成的数组</returns>
    public ArrayList GetRequestGet()
    {
        int i = 0;
        ArrayList sArray = new ArrayList();
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.QueryString;
        // Get names of all forms into a string array.
        String[] requestItem = coll.AllKeys;

        for (i = 0; i < requestItem.Length; i++)
        {
            sArray.Add(requestItem[i] + "=" + Request.QueryString[requestItem[i]]);
        }
        return sArray;
    }
    //判断是否为匿名用户
    protected int CheckMember(string strValue)
    {
        int intRtn = 0; //1表示为登录用户，0表示匿名用户
        try
        {
            Guid guid = new Guid(strValue);
        }
        catch
        {
            intRtn = 1;
        }
        return intRtn;
    }
}

