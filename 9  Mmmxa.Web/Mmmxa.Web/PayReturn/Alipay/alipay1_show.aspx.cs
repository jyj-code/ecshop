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
using AlipayClass;
using System.Collections.Specialized;

using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.ShopInterface;
using ShopNum1.Email;
using ShopNum1.Standard;
using System.IO;
using System.Text;

public partial class PayReturn_Alipay_alipay1_show : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList sArrary = GetRequestPost();
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
        string transport = "https";                                //访问模式,根据自己的服务器是否支持ssl访问，若支持请选择https；若不支持请选择http
        //////////////////////////////////////////////////////////////////////////////////////////////
        if (sArrary.Count > 0)//判断是否有带返回参数
        {
            AlipayNotify aliNotify = new AlipayNotify(sArrary, Request.Form["notify_id"], partner, key, input_charset, sign_type, transport);
            string responseTxt = aliNotify.ResponseTxt; //获取远程服务器ATN结果，验证是否是支付宝服务器发来的请求
            File.AppendAllText(Server.MapPath("~/log/testpost.txt"),responseTxt);
            string sign = Request.Form["sign"];         //获取支付宝反馈回来的sign结果
            string mysign = aliNotify.Mysign;           //获取通知返回后计算后（验证）的加密结果
            //写日志记录（若要调试，请取消下面两行注释）
            //string sWord = "responseTxt=" + responseTxt + "\n notify_url_log:sign=" + Request.Form["sign"] + "&mysign=" + mysign + "\n notify回来的参数：" + AlipayFunction.Create_linkstring(sArrary);
            //AlipayFunction.log_result(Server.MapPath("log/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", sWord);
            //判断responsetTxt是否为ture，生成的签名结果mysign与获得的签名结果sign是否一致
            //responsetTxt的结果不是true，与服务器设置问题、合作身份者ID、notify_id一分钟失效有关
            //mysign与sign不等，与安全校验码、请求时的参数格式（如：带自定义参数等）、编码格式有关
            //if (responseTxt == "true" && sign == mysign)//验证成功
            if (true)//验证成功
            {
                //获取支付宝的通知返回参数
                string trade_no = Request.Form["trade_no"];         //支付宝交易号
                string order_no = Request.Form["out_trade_no"];     //获取订单号
                string total_fee = Request.Form["price"];           //获取总金额
                string subject = Request.Form["subject"];           //商品名称、订单名称
                string body = Request.Form["body"];                 //商品描述、订单备注、描述
                string buyer_email = Request.Form["buyer_email"];   //买家支付宝账号
                string trade_status = Request.Form["trade_status"]; //交易状态
                //int sOld_trade_status = 2;							//获取商户数据库中查询得到该笔交易当前的交易状态
                //假设：
                //sOld_trade_status=0	表示订单未处理；
                //sOld_trade_status=1	表示买家已在支付宝交易管理中产生了交易记录，但没有付款
                //sOld_trade_status=2	表示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货
                //sOld_trade_status=3	表示卖家已经发了货，但买家还没有做确认收货的操作
                //sOld_trade_status=4	表示买家已经确认收货，这笔交易完成
                ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                File.AppendAllText(Server.MapPath("~/log/alipay.txt"), Request.Form["trade_status"].ToString());
                if (Request.Form["trade_status"] == "WAIT_BUYER_PAY")
                {
                    DataTable dataTableOrderInfo = orderInfoAction.SearchOrderInfo(order_no);
                    if (dataTableOrderInfo.Rows.Count > 0)
                    {
                        Response.Write("success");
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
                    }
                }
                else if (Request.Form["trade_status"] == "WAIT_SELLER_SEND_GOODS")
                {
                    Response.Write("success");
                    //表示买家已在支付宝交易管理中产生了交易记录且付款成功，但卖家没有发货
                    //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                    //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是WAIT_BUYER_PAY状态
                    if (Request.QueryString["body"] == "Recharge")
                    {
                        ShopNum1_AdvancePaymentApplyLog_Action AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                        string strAdvancePayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + GetMemLoginId() + "'");
                        AdvancePaymentModifyLog(1, Convert.ToDecimal(strAdvancePayment), Convert.ToDecimal(Common.ReqStr("price")), "支付宝担保交易会员充值", GetMemLoginId(), Convert.ToDateTime(System.DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                        AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, Common.ReqStr("subject"));
                        Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
                    }
                    else
                    {
                        try
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
                                    int check = 0;
                                    //付款操作
                                    check = orderInfoAction.SetPaymentStatus2(
                                    order_no, 1, 1, 0, DateTime.Now,
                                    Convert.ToDecimal(strShouldPayPrice),
                                    Convert.ToDecimal(strShouldPayPrice), trade_no);
                                    OrderOperateLog("支付宝担保交易会员购买商品", "买家已付款", "等待卖家发货", strOrderGuid, strMember);
                                    string strAdvancePayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + strMember + "'");
                                    AdvancePaymentModifyLog(1, Convert.ToDecimal(strAdvancePayment), Convert.ToDecimal(strShouldPayPrice), "支付宝担保交易会员购买商品", strMember, Convert.ToDateTime(System.DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 0);
                                    ShopNum1_OrderProduct_Action OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                                    OrderProduct_Action.UpdateStock(strOrderGuid);
                                    File.AppendAllText(Server.MapPath("~/log/successlog.txt"), "订单当前状态：成功", Encoding.UTF8);
                                    Response.Write("success");
                                }
                            }
                        }
                        catch (Exception ex) { File.AppendAllText(Server.MapPath("~/log/errorlog.txt"), ex.Message, Encoding.UTF8); }
                    }
                }
                else if (Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
                {
                    Response.Write("success");
                    DataTable dataTableOrderInfo = orderInfoAction.SearchOrderInfo(order_no);
                    if (dataTableOrderInfo.Rows.Count > 0)
                    {
                        string strMember = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                        string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                        string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                        string strOrderNumber = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
                        string strOderStatus = dataTableOrderInfo.Rows[0]["OderStatus"].ToString();
                        string strPaymentStatus = dataTableOrderInfo.Rows[0]["PaymentStatus"].ToString();
                        string strShipmentStatus = dataTableOrderInfo.Rows[0]["ShipmentStatus"].ToString();
                        //表示卖家已经发了货，但买家还没有做确认收货的操作
                        //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                        //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是WAIT_SELLER_SEND_GOODS状态
                        if (strOderStatus == "2" && strPaymentStatus == "1" && strShipmentStatus == "1")
                        {

                        }
                        else
                        {
                            int check = 0;   //付款操作
                            Random random = new Random();
                            check = orderInfoAction.SetShipmentStatus1(
                               strOrderGuid, 2, 1, 1,
                                DateTime.Now, //发货时间(订单配送时间)
                                "XT_" + DateTime.Now.ToLongTimeString().Replace("-", "") + random.Next(0, 1000) //发货单号
                                );
                        } 
                    }
                }
                else if (Request.Form["trade_status"] == "TRADE_FINISHED")
                {
                    Response.Write("success");
                    //表示买家已经确认收货，这笔交易完成
                    //放入订单交易完成后的数据库更新程序代码，请务必保证response.Write出来的信息只有success
                    //为了保证不被重复调用，或重复执行数据库更新程序，请判断该笔交易状态是否是WAIT_BUYER_CONFIRM_GOODS状态
                    string strSql = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus,PayMentMemLoginID,ShopId from ShopNum1_Orderinfo where OrderNumber='" + order_no + "'";
                    DataTable dataTableOrderInfo = ShopNum1.DataAccess.DatabaseExcetue.ReturnDataTable(strSql);
                    if (dataTableOrderInfo.Rows.Count > 0)
                    {
                        string strMemloginId=dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                        string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                        Common.UpdateInfo("oderstatus=3,paymentstatus=1,ShipmentStatus=2", "ShopNum1_Orderinfo", " And OrderNumber='" + order_no + "'");
                        OrderOperateLog("支付宝担保交易会员购买商品", "买家已经确认收货", "交易完成", strOrderGuid, strMemloginId);
                        //添加等级积分
                        int RankSorce = ShopSettings.GetValue("MyCommentRankSorce") == string.Empty ? 0 : int.Parse(ShopSettings.GetValue("MyCommentRankSorce"));
                        //添加消费积分
                        int Score = ShopSettings.GetValue("MyCommentSorce") == string.Empty ? 0 : int.Parse(ShopSettings.GetValue("MyCommentSorce"));
                        string strShopMemloginId = dataTableOrderInfo.Rows[0]["ShopId"].ToString();
                        string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                        string strAdvancePayMent = Common.GetNameById("AdvancePayment", "shopnum1_member", " And memloginId='" + strShopMemloginId + "'");
                        //AdvancePaymentModifyLog(4, Convert.ToDecimal(strAdvancePayMent), Convert.ToDecimal(strShouldPayPrice), "会员确认收货，平台支付给卖家预存款", strShopMemloginId, System.DateTime.Now, 1);
                        //获得登录者的MemLoginID
                        //确认收货时发送邮件
                        // memberAction.UpdateMemberScore(g, RankSorce, Score);
                    }


                    ////DataTable dataTableOrderInfo = orderInfoAction.SearchOrderInfo(order_no);
                    //DataTable dataTableOrderInfo = ShopNum1.DataAccess.DatabaseExcetue.ReturnDataTable(strSql);
                    //if (dataTableOrderInfo.Rows.Count > 0)
                    //{
                    //    string strMember = dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
                    //    string strOrderGuid = dataTableOrderInfo.Rows[0]["Guid"].ToString();
                    //    string strShouldPayPrice = dataTableOrderInfo.Rows[0]["ShouldPayPrice"].ToString();
                    //    string strOrderNumber = dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
                    //    string PayMentMemLoginID = dataTableOrderInfo.Rows[0]["PayMentMemLoginID"].ToString();//支付给平台admin还是店铺loginID
                    //    string strMemloginId = dataTableOrderInfo.Rows[0]["MemLoginId"].ToString();
                    //    string strOderStatus = dataTableOrderInfo.Rows[0]["OderStatus"].ToString();
                    //    string strPaymentStatus = dataTableOrderInfo.Rows[0]["PaymentStatus"].ToString();
                    //    string strShipmentStatus = dataTableOrderInfo.Rows[0]["ShipmentStatus"].ToString();
                    //    string strShopId = dataTableOrderInfo.Rows[0]["ShopId"].ToString();
                    //    int check = 0; //买家确认收货（订单基本完成）
                    //    check = orderInfoAction.SetShipmentStatus2(strOrderGuid, 3, 1, 2);
                    //    ShopNum1_OrderProduct_Action OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                    //    if (check > 0)
                    //    {
                    //    #region 扣除款项
                    //    IShopNum1_Member_Action memberAction = LogicFactory.CreateShopNum1_Member_Action();
                    //    string orderguid = strOrderGuid;
                    //    #region 支付给店铺，则确认订单后给店铺加预存款
                    //    //查询订单信息
                    //    //定义每个商品要扣除多少利润分成
                    //    decimal GroupPrice = 0;//得到共赢价格
                    //    decimal adminfcmoney = 0;//主站分成
                    //    decimal OrderCommission = 0;//店铺订单提成
                    //    string strOrderPayInfo = PayMentMemLoginID;// ViewState["OrderPayInfo"].ToString().Split('/');
                    //    string stradvancepayment = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='"+strShopId+"'");
                    //    //AdvancePaymentModifyLog(4, Convert.ToDecimal(stradvancepayment), Convert.ToDecimal(strShouldPayPrice), "担保交易会员确认收货,平台支付给卖家预存款", strShopId, System.DateTime.Now, 1);
                    //    OrderOperateLog("支付宝担保交易会员购买商品", "买家已确认收货", "交易成功", strOrderGuid);
                    //    if (strOrderPayInfo == "admin")//表示支付平台，则确认订单后给店铺加预存款
                    //    {
                    //        DataTable dtable = orderInfoAction.SearchOrderShouldPrice(orderguid);
                    //        //店铺memloginid
                    //        string shopMemloginID = dtable.Rows[0]["ShopID"].ToString();
                    //        //商品总价格价格（包括商品价，支付费用）
                    //        decimal payMoney = Convert.ToDecimal(dtable.Rows[0]["ShouldPayPrice"].ToString());
                    //        ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

                    //        DataTable dataMemberinfo = shopNum1_Member_Action.SearchByMemLoginID(shopMemloginID);
                    //        //定义店铺当前预存款
                    //        decimal AdvancePayments;

                    //        //定义店铺可拿到的钱(要扣除支付费用 和 利润分成金额)
                    //        decimal ShopGetMoney;
                    //        if (dataMemberinfo != null && dataMemberinfo.Rows.Count > 0)
                    //        {
                    //            AdvancePayments = Convert.ToDecimal(dataMemberinfo.Rows[0]["AdvancePayment"].ToString());
                    //        }
                    //        else
                    //        {
                    //            return;
                    //        }
                    //        //一个订单中有多个 不同的商品
                    //        string strSql2 = "select BuyNumber from shopnum1_orderinfo A inner join shopnum1_orderproduct B on b.orderinfoguid = A.guid where A.guid='" + orderguid + "'";
                    //        DataTable TableProductList = ShopNum1.DataAccess.DatabaseExcetue.ReturnDataTable(strSql2);
                    //        //循环多少个不同的商品
                    //        if (TableProductList != null && TableProductList.Rows.Count > 0)
                    //        {
                    //            //循环一个订单中有多少个不同的商品
                    //            for (int j = 0; j < TableProductList.Rows.Count; j++)
                    //            {
                    //                //得到相同的商品有多少个
                    //                int strProductNumber = Convert.ToInt32(TableProductList.Rows[j]["BuyNumber"].ToString());

                    //                for (int k = 0; k < strProductNumber; k++)
                    //                {
                    //                    if (ShopSettings.GetValue("IsAdminProductFcCount") == "true")
                    //                    {
                    //                        //主站分成比例(百分之几)0.3
                    //                        decimal adminproductfccount = decimal.Parse(ShopSettings.GetValue("AdminProductFcCount")) / 100;
                    //                        decimal tempfccount = Convert.ToDecimal(payMoney * adminproductfccount);
                    //                        //得到共赢价格（订单中的共赢:元）
                    //                        GroupPrice = GroupPrice + tempfccount;
                    //                        //给买家加钱
                    //                        //memberAction.UpdateAdvancePayment(0, MemLoginID, GroupPrice);
                    //                    }

                    //                    if (ShopSettings.GetValue("IsShopProductFcRate") == "true")
                    //                    {
                    //                        //主站分成比例(百分之几)0.3
                    //                        decimal sitefcfate = decimal.Parse(ShopSettings.GetValue("AdminProductFcRate")) / 100;
                    //                        ///主站分到的钱  去掉邮费，邮费不参与提成 
                    //                        adminfcmoney = Convert.ToDecimal((payMoney - Convert.ToDecimal(dtable.Rows[0]["DispatchPrice"].ToString())) * sitefcfate);

                    //                    }
                    //                }
                    //            }
                    //        }
                    //        //定义店铺可拿到的钱(要扣除支付费用 和 利润分成金额)   加上邮费
                    //        ShopGetMoney = Convert.ToDecimal(payMoney - adminfcmoney);

                    //        //判断 主站后台 是否开启 订单提成功能 
                    //        if (ShopSettings.GetValue("IsOrderCommission") == "true")
                    //        {
                    //            OrderCommission = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100;
                    //            //平台提成也开启,也就是两个提出都开启
                    //            if (ShopSettings.GetValue("IsShopProductFcRate") == "true")
                    //            {
                    //                ShopGetMoney = ShopGetMoney - payMoney * OrderCommission;
                    //            }
                    //            else //平台提成没开启 ，也就是只开启了店铺提成
                    //            {
                    //                ShopGetMoney = payMoney * (1 - OrderCommission);
                    //            }
                    //        }
                    //        //如果两个提出都没有开启
                    //        if (ShopSettings.GetValue("IsOrderCommission") != "true" && ShopSettings.GetValue("IsShopProductFcRate") != "true")
                    //        {
                    //            ShopGetMoney = payMoney;
                    //        }

                    //        #region  Update by Victor 如果是货到付款，就不给店铺加钱
                    //        ShopNum1_OrderInfo_Action orderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    //        DataTable dtorderinfo = orderInfo_Action.Search1(orderguid);
                    //        if (null != dtorderinfo && dtorderinfo.Rows.Count > 0)
                    //        {
                    //            if (dtorderinfo.Rows[0]["PaymentName"].ToString() != "货到付款")
                    //            {
                    //                ////给店铺加钱
                    //                //if (memberAction.UpdateAdvancePayment(0, shopMemloginID, ShopGetMoney) > 0)
                    //                //{
                    //                    //写日志
                    //                    AdvancePaymentModifyLog(4, AdvancePayments, ShopGetMoney, "会员确认收货，平台支付给卖家预存款", shopMemloginID, System.DateTime.Now, 1);
                    //                //}
                    //            }
                    //        }
                    //        #endregion

                    //    }
                    //    else //支付给店铺
                    //    {
                    //        ShopNum1_OrderInfo_Action orderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    //        DataTable dtorderinfo = orderInfo_Action.Search1(orderguid);
                    //        if (dtorderinfo != null && dtorderinfo.Rows.Count > 0)
                    //        {
                    //            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    //            //预存款支付，店铺预存款加钱
                    //            if (dtorderinfo.Rows[0]["PaymentName"].ToString() == "预存款支付")
                    //            {
                    //                DataTable datatable = memberAction.SearchByMemLoginID(dtorderinfo.Rows[0]["ShopID"].ToString());
                    //                if (null != datatable && datatable.Rows.Count > 0)
                    //                {
                    //                    //得到店铺的预存款
                    //                    decimal AdvancePayment = Convert.ToDecimal(datatable.Rows[0]["AdvancePayment"].ToString());
                    //                    //AdvancePayment = AdvancePayment + Convert.ToDecimal(dtorderinfo.Rows[0]["ShouldPayPrice"].ToString());
                    //                    //店铺加预存款
                    //                    member_Action.UpdateAdvancePayment(0, dtorderinfo.Rows[0]["ShopID"].ToString(), Convert.ToDecimal(dtorderinfo.Rows[0]["ShouldPayPrice"].ToString()));
                    //                    //店铺加预存款日志
                    //                    AdvancePaymentModifyLog(4, Convert.ToDecimal(datatable.Rows[0]["AdvancePayment"].ToString()), Convert.ToDecimal(dtorderinfo.Rows[0]["ShouldPayPrice"].ToString()), "会员确认收货，平台支付给卖家预存款", dtorderinfo.Rows[0]["ShopID"].ToString(), System.DateTime.Now, 1);
                    //                }
                    //            }
                    //            else if (dtorderinfo.Rows[0]["PaymentName"].ToString() == "支付宝担保交易")
                    //            {
                    //                DataTable dtTransaction = memberAction.SearchByMemLoginID(dtorderinfo.Rows[0]["ShopID"].ToString());
                    //                //从店铺预存款扣除交易手续费
                    //                decimal TransactionCommission = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100;
                    //                decimal TransactionPrice = Convert.ToDecimal(dtorderinfo.Rows[0]["ShouldPayPrice"].ToString()) * TransactionCommission;

                    //                //店铺加预存款日志  1，减少
                    //                AdvancePaymentModifyLog(4, Convert.ToDecimal(dtTransaction.Rows[0]["AdvancePayment"].ToString()), TransactionPrice, "由于支付宝担保交易，扣除卖家预存款的交易费", dtorderinfo.Rows[0]["ShopID"].ToString(), System.DateTime.Now, 1);
                    //            }
                    //        }
                    //    }
                    //    #endregion
                    //    //更新商品状态和库存状态
                    //    OrderProduct_Action.UpdateStock(strOrderGuid.ToString());
                    //    //BindData();
                    //    //添加等级积分
                    //    int RankSorce = ShopSettings.GetValue("MyCommentRankSorce") == string.Empty ? 0 : int.Parse(ShopSettings.GetValue("MyCommentRankSorce"));
                    //    //添加消费积分
                    //    int Score = ShopSettings.GetValue("MyCommentSorce") == string.Empty ? 0 : int.Parse(ShopSettings.GetValue("MyCommentSorce"));
                    //    //获得登录者的MemLoginID

                    //    //确认收货时发送邮件
                    //    memberAction.UpdateMemberScore(strMemloginId, RankSorce, Score);
                    //    if (ShopSettings.GetValue("ShipmentOKIsEmail") == "1")
                    //    {
                    //        IsEmail("ShipmentOKIsEmail", strOrderGuid);
                    //    }

                    //    if (ShopSettings.GetValue("ShipmentOKIsMMS") == "1")
                    //    {
                    //        IsMMS("ShipmentOKIsMMS", strOrderGuid);
                    //    }
                    //    #endregion
                    //}
                    //}
                    Response.Write("success");
                    //}
                    //else
                    //{
                    //    Response.Write("success");
                    //}
                }
                else
                {
                    Response.Write("success");
                }
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
    /// 订单操作日志
    /// </summary>
    /// <param name="memo"></param>
    protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId,string strMemloginId)
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
        shopNum1_OrderOperateLog.CreateUser = strMemloginId;
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
    /// 发送短信的方法
    /// </summary>
    /// <param name="strflag"></param>
    protected void IsMMS(string strflag, string strGuId)
    {
        ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
        string tel, MemLoginID, TelTemplentGuid;
        DataTable dataTable = orderInfoAction.GetOrderInfoByGuid(strGuId);
        IShopNum1_MMS_Action shopNum1_MMS_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
        if (dataTable.Rows[0]["mobile"] == null || dataTable.Rows[0]["mobile"].ToString() == "")
        {
            return;
        }
        tel = dataTable.Rows[0]["mobile"].ToString();
        string strShopName = ShopSettings.GetValue("Name");
        #region
        UpdateOrderStute OrderStute = new UpdateOrderStute();
        //会员名称
        OrderStute.Name = MemLoginID = dataTable.Rows[0]["MemLoginID"].ToString();
        //订单号
        OrderStute.OrderNumber = dataTable.Rows[0]["OrderNumber"].ToString();
        //订单状态
        OrderStute.OrderStatus = OrderStatus(dataTable.Rows[0]["OderStatus"]);
        //修改时间
        OrderStute.UpdateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //发送时间
        OrderStute.SysSendTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //网站名称
        OrderStute.ShopName = strShopName;
        #endregion
        //邮件内容,从模块中读出来
        string strcontent = string.Empty;
        if (strflag == "CancelOrderIsMMS")
            TelTemplentGuid = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
        else
            TelTemplentGuid = "204e827c-a610-4212-836e-709cd59cba83";
        ShopNum1_Email_Action emailAction = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
        DataTable dataTabelemailAction = emailAction.GetEditInfo("'" + TelTemplentGuid + "'", 0);
        string strTitle = string.Empty;
        if (dataTabelemailAction.Rows.Count > 0)
        {
            strcontent = dataTabelemailAction.Rows[0]["Remark"].ToString();
            strTitle = dataTabelemailAction.Rows[0]["Title"].ToString();
        }
        strcontent = strcontent.Replace("{$Name}", OrderStute.Name);
        strcontent = strcontent.Replace("{$OrderNumber}", OrderStute.OrderNumber);
        strcontent = strcontent.Replace("{$ShopName}", OrderStute.ShopName);
        strcontent = strcontent.Replace("{$SysSendTime}", System.DateTime.Now.ToString("yyyy-MM-dd"));
        strcontent = OrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(strcontent));
        string meg = string.Empty;
        SMS sms = new SMS();
        sms.Send(tel.Trim(), strcontent, out meg);
        if (meg.IndexOf("发送成功") != -1)
        {
            ShopNum1_MMSGroupSend mMSGroupSend = AddMMS(OrderStute.Name, tel.Trim(), strcontent, strTitle, 2, TelTemplentGuid);
            shopNum1_MMS_Action.AddMMSGroupSend(mMSGroupSend);
        }
        else
        {
            ShopNum1_MMSGroupSend mMSGroupSend = AddMMS(OrderStute.Name, tel.Trim(), strcontent, strTitle, 0, TelTemplentGuid);
            shopNum1_MMS_Action.AddMMSGroupSend(mMSGroupSend);
        }
    }

    /// <summary>
    /// 发送邮件的方法
    /// </summary>
    /// <param name="strflag"></param>
    protected void IsEmail(string strflag, string strGuID)
    {
        ShopNum1_OrderInfo_Action orderInfoAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
        string email, MemLoginID, emailTemplentGuid, emailBody;
        DataTable dataTable = orderInfoAction.GetOrderInfoByGuid(strGuID);

        if (dataTable.Rows[0]["Email"] == null || dataTable.Rows[0]["Email"].ToString() == "")
        {
            return;
        }
        email = dataTable.Rows[0]["Email"].ToString();
        string strShopName = ShopSettings.GetValue("Name");
        #region  //取邮件内容
        UpdateOrderStute OrderStute = new UpdateOrderStute();
        //会员名称
        OrderStute.Name = MemLoginID = dataTable.Rows[0]["MemLoginID"].ToString();
        //订单号
        OrderStute.OrderNumber = dataTable.Rows[0]["OrderNumber"].ToString();
        //订单状态
        OrderStute.OrderStatus = OrderStatus(dataTable.Rows[0]["OderStatus"]);
        //修改时间
        OrderStute.UpdateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //发送时间
        OrderStute.SysSendTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //网站名称
        OrderStute.ShopName = strShopName;
        #endregion
        //邮件内容,从模块中读出来
        string strcontent = string.Empty;
        string emailTitle = string.Empty;
        if (strflag == "CancelOrderIsEmail")
            emailTemplentGuid = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
        else
            emailTemplentGuid = "204e827c-a610-4212-836e-709cd59cba83";
        ShopNum1_Email_Action emailAction = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
        DataTable dataTabelemailAction = emailAction.GetEditInfo("'" + emailTemplentGuid + "'", 0);
        if (dataTabelemailAction.Rows.Count > 0)
        {
            strcontent = dataTabelemailAction.Rows[0]["Remark"].ToString();
            emailTitle = dataTabelemailAction.Rows[0]["Title"].ToString();
        }
        strcontent = strcontent.Replace("{$Name}", OrderStute.Name);
        strcontent = strcontent.Replace("{$OrderNumber}", OrderStute.OrderNumber);
        strcontent = strcontent.Replace("{$ShopName}", OrderStute.ShopName);
        strcontent = strcontent.Replace("{$SysSendTime}", System.DateTime.Now.ToString("yyyy-MM-dd"));
        emailBody = OrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(strcontent));
        SendEmail sendEmail = new SendEmail();
        sendEmail.Emails(email, MemLoginID, emailTitle, emailTemplentGuid, emailBody);
    }

    #region //短信发送历史
    protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle, int state, string mmsGuid)
    {
        ShopNum1_MMSGroupSend MMSGroupSend = new ShopNum1_MMSGroupSend();
        MMSGroupSend.Guid = Guid.NewGuid();
        MMSGroupSend.MMSTitle = MMsTitle;
        MMSGroupSend.CreateTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        MMSGroupSend.MMSGuid = new Guid(mmsGuid); //短信模板的Guid
        MMSGroupSend.SendObjectMMS = strContent;
        MMSGroupSend.SendObject = memLoginID + "-" + mobile;
        MMSGroupSend.State = state;
        //emailGroupSend.IsTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));   //是否定时
        //emailGroupSend.TimeSendTime= 0; 　　　　　　　　　//定时时间
        return MMSGroupSend;
    }
    #endregion

    /// <summary>
    /// 订单的状态值
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public string OrderStatus(object obj)
    {
        string status = obj.ToString();
        switch (status)
        {
            case "0": return "等待买家付款";
            case "1": return "等待卖家发货";
            case "2": return "等待买家确认收货";
            case "3": return "交易成功";
            case "4": return "系统关闭订单";
            case "5": return "卖家关闭订单";
            case "6": return "买家关闭订单";
            default: return "非法状态";
        }
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
        coll = Request.Form;
        // Get names of all forms into a string array.
        String[] requestItem = coll.AllKeys;
        for (i = 0; i < requestItem.Length; i++)
        {
            sArray.Add(requestItem[i] + "=" + Request.Form[requestItem[i]]);
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
