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
/// 功能：付完款后跳转的页面（返回页）
/// 版本：3.0
/// 日期：2010-06-30
/// 说明：
/// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
/// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
/// 
/// ///////////////////////页面功能说明///////////////////////
/// 该页面可在本机电脑测试
/// 该页面称作“返回页”，是由支付宝服务器同步调用，可当作是支付完成后的提示信息页，如“您的某某某订单，多少金额已支付成功”。
/// 可放入HTML等美化页面的代码和订单交易完成后的数据库更新程序代码
/// 该页面可以使用ASP.NET开发工具调试，也可以使用写文本函数Log_result进行调试，该函数已被默认关闭
/// WAIT_SELLER_SEND_GOODS(表示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货);
/// </summary>
public partial class PayReturn_Alipay_alitwo_show : System.Web.UI.Page
{
    public Boolean IsDoMain ;
    public string AgentHost=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList sArrary = GetRequestGet();
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
            string sign = Request.QueryString["sign"];  //获取支付宝反馈回来的sign结果
            string mysign = aliNotify.Mysign;           //获取通知返回后计算后（验证）的加密结果

            //写日志记录（若要调试，请取消下面两行注释）
            //string sWord = "responseTxt=" + responseTxt + "\n return_url_log:sign=" + Request.QueryString["sign"] + "&mysign=" + mysign + "\n return回来的参数：" + AlipayFunction.Create_linkstring(sArrary);
            //AlipayFunction.log_result(Server.MapPath("log/" + DateTime.Now.ToString().Replace(":", "")) + ".txt",sWord);

            //判断responsetTxt是否为ture，生成的签名结果mysign与获得的签名结果sign是否一致
            //responsetTxt的结果不是true，与服务器设置问题、合作身份者ID、notify_id一分钟失效有关
            //mysign与sign不等，与安全校验码、请求时的参数格式（如：带自定义参数等）、编码格式有关
            if (responseTxt == "true" && sign == mysign)//验证成功
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


                ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                DataTable dataTableOrderInfo = orderInfoAction.SearchOrderInfo(order_no);
                int sOld_trade_status = int.Parse(dataTableOrderInfo.Rows[0]["OderStatus"].ToString());	//获取商户数据库中查询得到该笔交易当前的交易状态


                string strMember = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                string strOrderNumber = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();


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

                //假设：
                //sOld_trade_status=0	表示订单未处理；
                //sOld_trade_status=1	表示买家已在支付宝交易管理中产生了交易记录，但没有付款
                //sOld_trade_status=2	表示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货
                //sOld_trade_status=3	表示卖家已经发了货，但买家还没有做确认收货的操作
                //sOld_trade_status=4	表示买家已经确认收货，这笔交易完成

                if (Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS" || Request.QueryString["trade_status"] == "TRADE_FINISHED")
                {
                    //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是订单未处理状态
                    if (sOld_trade_status < 1)
                    {
                        //当Request.QueryString["trade_status"] 为WAIT_SELLER_SEND_GOODS，则说明买家用的支付方式是担保交易付款
                        //当Request.QueryString["trade_status"] 为TRADE_FINISHED，则说明买家用的支付方式是即时到帐付款
                        //根据订单号更新订单，把订单状态处理成交易成功
                    }
                    #region 第三方支付记录创建
                    IShopNum1_Payment_Action action = new ShopNum1_Payment_Action();
                    action.InsertPayRecord(new ShopNum1_ThreePaymentRecord()
                    {
                        GUID = Guid.NewGuid(),
                        OrderNumber = trade_no,
                        PayMoney = Convert.ToDecimal(strShouldPayPrice),
                        PayTypeCode = "Alipay2.aspx",
                        PayTypeName = "支付宝双向接口交易",
                        PayTypeGuid = Guid.NewGuid().ToString(),
                        HasPayTime = DateTime.Now,
                        CreateTime = DateTime.Now

                    });
                    #endregion
                    #region 更变订单状态
                  
                    int check = 0;
                    //付款操作
                    check = orderInfoAction.SetPaymentStatus2(
                        strOrderGuid, 1, 1, 0, DateTime.Now,
                        Convert.ToDecimal(total_fee),
                        Convert.ToDecimal(strShouldPayPrice));


                    //if (CheckMember(strMember) == 1)
                    //{
                    //    //更新会员表中的消费总金额CostMoney
                    //    ShopNum1_Member_Action memberAction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    //    memberAction.UpdateCostMoney(strMember, Convert.ToDecimal(total_fee));
                    //}

                    #endregion
                   
                   
                        //跳转主站会员中心

                    Page.Response.Redirect("/main/Member/m_index.aspx");
                    return;
                    //订单详细
               
                    //
                }
                else if (Request.Form["trade_status"] == "TRADE_FINISHED")
                {
                    //表示买家已经确认收货，这笔交易完成
                    //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                    //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是WAIT_BUYER_CONFIRM_GOODS状态
                    Common.UpdateInfo("oderstatus=3,paymentstatus=1,ShipmentStatus=2", "ShopNum1_Orderinfo", " And tradeid='" + order_no + "'");
                }
                else
                {
                    Response.Write("trade_status=" + Request.QueryString["trade_status"]);
                }
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
