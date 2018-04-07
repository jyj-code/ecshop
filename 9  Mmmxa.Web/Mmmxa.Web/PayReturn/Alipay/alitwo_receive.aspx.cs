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
using ShopNum1.Interface;
using ShopNum1MultiEntity;

/// <summary>
/// 功能：支付宝主动通知调用的页面（通知页）
/// 版本：3.0
/// 日期：2010-06-30
/// 说明：
/// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
/// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
/// 
/// ///////////////////页面功能说明///////////////////
/// 创建该页面文件时，请留心该页面文件中无任何HTML代码及空格。
/// 该页面不能在本机电脑测试，请到服务器上做测试。请确保外部可以访问该页面。
/// 该页面调试工具请使用写文本函数log_result，该函数已被默认开启
/// WAIT_BUYER_PAY(表示买家已在支付宝交易管理中产生了交易记录，但没有付款);
/// WAIT_SELLER_SEND_GOODS(表示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货);
/// WAIT_BUYER_CONFIRM_GOODS(表示卖家已经发了货，但买家还没有做确认收货的操作);
/// TRADE_FINISHED(表示买家已经确认收货，这笔交易完成);
/// 该通知页面主要功能是：对于返回页面（return_url.aspx）做补单处理。如果没有收到该页面返回的 success 信息，支付宝会在24小时内按一定的时间策略重发通知
/// </summary>
public partial class PayReturn_Alipay_alitwo_receive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList sArrary = GetRequestPost();
        ///////////////////////以下参数是需要设置的相关配置参数，设置后不会更改的//////////////////////
        string partner = string.Empty;    //合作身份者ID
        string key = string.Empty;                   //安全检验码
        ShopNum1_Payment_Action paymentAction = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
        DataTable PaymentdataTable = paymentAction.GetPaymentKey("Alipay2.aspx");//支付宝标准双接口
        if (PaymentdataTable.Rows.Count > 0)
        {
            partner = PaymentdataTable.Rows[0]["MerchantCode"].ToString(); //ConfigurationManager.AppSettings["platSupplierID"];    //合作身份者ID
            key = PaymentdataTable.Rows[0]["SecretKey"].ToString(); //ConfigurationManager.AppSettings["key"];                   //安全检验码
        }
        string input_charset = "utf-8";                     //字符编码格式 目前支持 gb2312 或 utf-8
        string sign_type = "MD5";                           //加密方式 不需修改
        string transport = "http";                         //访问模式,根据自己的服务器是否支持ssl访问，若支持请选择https；若不支持请选择http
        //////////////////////////////////////////////////////////////////////////////////////////////
        if (sArrary.Count > 0)//判断是否有带返回参数
        {
            AlipayNotify aliNotify = new AlipayNotify(sArrary, Request.QueryString["notify_id"], partner, key, input_charset, sign_type, transport);
            string responseTxt = aliNotify.ResponseTxt; //获取远程服务器ATN结果，验证是否是支付宝服务器发来的请求
            string sign = Request.QueryString["sign"];         //获取支付宝反馈回来的sign结果
            string mysign = aliNotify.Mysign;           //获取通知返回后计算后（验证）的加密结果

            //写日志记录（若要调试，请取消下面两行注释）
            //string sWord = "responseTxt=" + responseTxt + "\n notify_url_log:sign=" + Request.QueryString["sign"] + "&mysign=" + mysign + "\n notify回来的参数：" + AlipayFunction.Create_linkstring(sArrary);
            //AlipayFunction.log_result(Server.MapPath("/log/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", sWord);

            //判断responsetTxt是否为ture，生成的签名结果mysign与获得的签名结果sign是否一致
            //responsetTxt的结果不是true，与服务器设置问题、合作身份者ID、notify_id一分钟失效有关
            //mysign与sign不等，与安全校验码、请求时的参数格式（如：带自定义参数等）、编码格式有关
            if (responseTxt == "true" && sign == mysign)//验证成功
            {
                //获取支付宝的通知返回参数
                string trade_no = Request.QueryString["trade_no"];         //支付宝交易号
                string order_no = Request.QueryString["out_trade_no"];     //获取订单号
                string total_fee = Request.QueryString["price"];           //获取总金额
                string subject = Request.QueryString["subject"];           //商品名称、订单名称
                string body = Request.QueryString["body"];                 //商品描述、订单备注、描述
                string buyer_email = Request.QueryString["buyer_email"];   //买家支付宝账号
                string trade_status = Request.QueryString["trade_status"]; //交易状态


                ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                DataTable dataTableOrderInfo = orderInfoAction.SearchOrderInfo(order_no);

                //假设：
                //sOld_trade_status=0	表示订单未处理；
                //sOld_trade_status=1	表示买家已在支付宝交易管理中产生了交易记录，但没有付款
                //sOld_trade_status=2	表示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货
                //sOld_trade_status=3	表示卖家已经发了货，但买家还没有做确认收货的操作
                //sOld_trade_status=4	表示买家已经确认收货，这笔交易完成

                if (Request.QueryString["trade_status"] == "WAIT_BUYER_PAY")
                {
                    //表示买家已在支付宝交易管理中产生了交易记录，但没有付款
                    //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                    //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是订单未处理状态
                    //注：该交易状态下，也可不做数据库更新程序，此时，建议把该状态的通知信息记录到商户通知日志数据库表中。
                    //if (sOld_trade_status == 0)
                    //{
                    //    //根据订单号更新订单，把订单状态处理成交易成功
                    //}

                    Response.Redirect("/main/Member/m_index.aspx?go=");
                }
                else if (Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS")
                {
                    if (order_no.IndexOf("C") != -1)
                    {
                        ShopNum1_AdvancePaymentApplyLog_Action AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                        string strAdvancePayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
                        AdvancePaymentModifyLog(1, Convert.ToDecimal(strAdvancePayment), Convert.ToDecimal(Common.ReqStr("price")), "支付宝双向接口充值", GetMemLoginId(), Convert.ToDateTime(System.DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                        AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, subject);
                        #region 第三方支付记录创建
                        IShopNum1_Payment_Action action = new ShopNum1_Payment_Action();
                        action.InsertPayRecord(new ShopNum1_ThreePaymentRecord()
                        {
                            GUID = Guid.NewGuid(),
                            OrderNumber = order_no,
                            PayMoney = Convert.ToDecimal(Common.ReqStr("price")),
                            PayTypeCode = "Alipay2.aspx",
                            PayTypeName = "支付宝双向接口充值",
                            PayTypeGuid = Guid.NewGuid().ToString(),
                            HasPayTime = DateTime.Now,
                            CreateTime = DateTime.Now

                        });
                        #endregion
                        Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx"); return;
                    }
                    else
                    {
                        int sOld_trade_status = int.Parse(dataTableOrderInfo.Rows[0]["OderStatus"].ToString());	//获取商户数据库中查询得到该笔交易当前的交易状态
                        string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                        string strMember = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                        string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                        string strOrderNumber = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
                        //表示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货
                        //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                        //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是WAIT_BUYER_PAY状态
                        if (sOld_trade_status == 1 || sOld_trade_status == 0)
                        {
                            //根据订单号更新订单，把订单状态处理成交易成功
                        }
                        #region 更变订单状态
                        // ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                        //dataTableOrderInfo = orderInfoAction.SearchOrderInfo(order_no);
                        #region 第三方支付记录创建
                        IShopNum1_Payment_Action action = new ShopNum1_Payment_Action();
                        action.InsertPayRecord(new ShopNum1_ThreePaymentRecord()
                        {
                            GUID = Guid.NewGuid(),
                            OrderNumber = order_no,
                            PayMoney = Convert.ToDecimal(strShouldPayPrice),
                            PayTypeCode = "Alipay2.aspx",
                            PayTypeName = "支付宝双向接口购物",
                            PayTypeGuid = Guid.NewGuid().ToString(),
                            HasPayTime = DateTime.Now,
                            CreateTime = DateTime.Now

                        });
                        #endregion
                        int check = 0;
                        //付款操作
                        check = orderInfoAction.SetPaymentStatus2(
                            order_no, 1, 1, 0, DateTime.Now,
                            Convert.ToDecimal(total_fee),
                            Convert.ToDecimal(strShouldPayPrice), trade_no);


                        if (CheckMember(strMember) == 1)
                        {
                            //更新会员表中的消费总金额CostMoney
                            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                            memberAction.UpdateCostMoney(strMember, Convert.ToDecimal(total_fee));
                        }

                        #endregion
                        Response.Redirect("/main/Member/m_index.aspx");
                    }
                }
                else if (Request.QueryString["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
                {
                    int sOld_trade_status = int.Parse(dataTableOrderInfo.Rows[0]["OderStatus"].ToString());	//获取商户数据库中查询得到该笔交易当前的交易状态
                    string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                    string strMember = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                    string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                    string strOrderNumber = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
                    //表示卖家已经发了货，但买家还没有做确认收货的操作
                    //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                    //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是WAIT_SELLER_SEND_GOODS状态
                    if (sOld_trade_status == 2)
                    {
                        //根据订单号更新订单，把订单状态处理成交易成功
                        int check = 0;
                        //付款操作
                        check = orderInfoAction.SetPaymentStatus2(
                            order_no, 2, 2, 1, DateTime.Now,
                            Convert.ToDecimal(total_fee),
                            Convert.ToDecimal(strShouldPayPrice));
                    }


                    Response.Redirect("/main/Member/m_index.aspx?ok=");
                }
                else if (Request.QueryString["trade_status"] == "TRADE_FINISHED")
                {
                    if (order_no.IndexOf("C") != -1)
                    {
                        ShopNum1_AdvancePaymentApplyLog_Action AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                        string strAdvancePayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
                        AdvancePaymentModifyLog(1, Convert.ToDecimal(strAdvancePayment), Convert.ToDecimal(Common.ReqStr("total_fee")), "支付宝双向接口充值", GetMemLoginId(), Convert.ToDateTime(System.DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                        AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, subject);
                        #region 第三方支付记录创建
                        IShopNum1_Payment_Action action = new ShopNum1_Payment_Action();
                        action.InsertPayRecord(new ShopNum1_ThreePaymentRecord()
                        {
                            GUID = Guid.NewGuid(),
                            OrderNumber = order_no,
                            PayMoney = Convert.ToDecimal(Common.ReqStr("total_fee")),
                            PayTypeCode = "Alipay2.aspx",
                            PayTypeName = "支付宝双向接口充值",
                            PayTypeGuid = Guid.NewGuid().ToString(),
                            HasPayTime = DateTime.Now,
                            CreateTime = DateTime.Now

                        });
                        #endregion
                        Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx"); return;
                    }
                    else
                    {
                        int sOld_trade_status = int.Parse(dataTableOrderInfo.Rows[0]["OderStatus"].ToString());	//获取商户数据库中查询得到该笔交易当前的交易状态
                        string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                        string strMember = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                        string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                        string strOrderNumber = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
                        //表示买家已经确认收货，这笔交易完成
                        //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                        //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是WAIT_BUYER_CONFIRM_GOODS状态
                        if (sOld_trade_status == 3 || sOld_trade_status < 2)
                        {
                            //当sOld_trade_status=3，则说明买家用的支付方式是担保交易付款
                            //当sOld_trade_status<2，则说明买家用的支付方式是即时到帐付款
                            //根据订单号更新订单，把订单状态处理成交易成功
                        }

                        #region 更变订单状态
                        // ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                        // dataTableOrderInfo = orderInfoAction.SearchOrderInfo(order_no);

                        #region 第三方支付记录创建
                        IShopNum1_Payment_Action action = new ShopNum1_Payment_Action();
                        action.InsertPayRecord(new ShopNum1_ThreePaymentRecord()
                        {
                            GUID = Guid.NewGuid(),
                            OrderNumber = order_no,
                            PayMoney = Convert.ToDecimal(strShouldPayPrice),
                            PayTypeCode = "Alipay2.aspx",
                            PayTypeName = "支付宝双向接口交易",
                            PayTypeGuid = Guid.NewGuid().ToString(),
                            HasPayTime = DateTime.Now,
                            CreateTime = DateTime.Now

                        });
                        #endregion

                        int check = 0;
                        //付款操作
                        check = orderInfoAction.SetPaymentStatus2(
                            order_no, 1, 1, 0, DateTime.Now,
                            Convert.ToDecimal(total_fee),
                            Convert.ToDecimal(strShouldPayPrice));

                        if (CheckMember(strMember) == 1)
                        {
                            //更新会员表中的消费总金额CostMoney
                            ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                            memberAction.UpdateCostMoney(strMember, Convert.ToDecimal(total_fee));
                        }
                        Response.Redirect("/main/Member/m_index.aspx?ok=");
                        #endregion
                    }
                }
                else
                {
                    //Response.Write("success");  //其它状态判断。普通即时到帐中，其它状态不用判断，直接打印success。
                    Response.Redirect("/main/Member/m_index.aspx?error=");
                }
            }
            else//验证失败
            {
                Response.Write("验证失败");
            }
        }
        else
        {
            Response.Write("无通知参数");
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
    /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
    /// </summary>
    /// <returns>request回来的信息组成的数组</returns>
    public ArrayList GetRequestPost()
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
