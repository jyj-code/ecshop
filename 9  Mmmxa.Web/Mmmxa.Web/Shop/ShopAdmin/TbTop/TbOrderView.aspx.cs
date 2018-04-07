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
using ShopNum1.BusinessLogic;
using System.Xml;
using ShopNum1.Common;
using ShopNum1.TbTopCommon;
using ShopNum1.TbBusinessEntity;
using ShopNum1.Factory;

public partial class TbOrderView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //验证会员中心的cookies
        if (Page.Request.Cookies["MemberLoginCookie"] == null)
        {      //退出
            ShopNum1.Common.GetUrl.RedirectTopLogin();
        }
        else
        {
            HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
            string MemberType = decodedCookieMemberLogin.Values["MemberType"].ToString();

            if (MemberType != "2")
            {
                //退出

                ShopNum1.Common.GetUrl.RedirectTopLogin();
                return;
            }
            //会员登录ID
            MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"].ToString();

        }

        if (Session["access_token"] == null)
        {
            Response.Redirect("TbAuthorization.aspx");
        }
        if (!IsPostBack)
        {
            BindOrderList("0");
        }
        else
        {

            if (Page.Request.Form["pageid"] != null && Page.Request.Form["pageid"] != "0")
            {
                ///页数
                string pageid = Page.Request.Form["pageid"].ToString();
                BindOrderList(pageid);
            }
        }


    }

    private bool CheckMemberID(string MemLoginID)
    {
        try
        {
            ShopName = HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"].ToString());
        }
        catch
        {
            ShopName = "";
        }


        ShopNum1_TbSystem_Action tbSystem = (ShopNum1_TbSystem_Action)LogicTbFactory.CreateShopNum1_TbSystem_Action();
        if (tbSystem.GetTbSysem(MemLoginID, ShopName) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnSerch_Click(object sender, EventArgs e)
    {
        BindOrderList("0");

    }

    private void BindOrderList(string pageid)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        string strXml = string.Empty;
        ShopNum1.TbTopCommon.ErrorRsp err = new ShopNum1.TbTopCommon.ErrorRsp();
        List<TbOrder> orders = new List<TbOrder>();
        List<TbTrade> trades = new List<TbTrade>();
        ///订单号不为空的时候
        if (txtOrderID.Text.Trim() != "")
        {
            param.Add("fields", "seller_nick, buyer_nick, title, type, created, tid, seller_rate, buyer_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,orders");
            param.Add("tid", txtOrderID.Text.Trim());
            strXml = ShopNum1.TbTopCommon.TopAPI.Post("taobao.trade.get", TopClient.AgentSession, param);
            new ShopNum1.TbTopCommon.Parser().XmlToObject2<TbTrade>(strXml, "trade_get", "trade", trades, err);
            if (err.IsError)
                return;
            RepeaterOrder.DataSource = trades;
            //RepeaterOrder.DataKeyField = "tid";
            RepeaterOrder.DataBind();
            return;
        }
        PageList pagelist = new PageList();
        pagelist.PageSize = 10;
        pagelist.PageID = int.Parse(pageid);

        //paglist.RecordCount
        //需返回的字段列表。
        param.Clear();
        param.Add("fields", "buyer_nick, type,created,sid,tid, seller_rate, buyer_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,orders");
        if (txtbuyer.Text.Trim() != "")
        {
            param.Add("buyer_nick", txtbuyer.Text.Trim());
        }

        DateTime time1 = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        DateTime time2 = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        if (txtStartTime.Text.Trim() != "")
        {
            try
            {
                time1 = Convert.ToDateTime(txtStartTime.Text.Trim());
            }

            catch
            {
                ShopNum1.Common.MessageBox.Show("开始时间格式不对");

                txtStartTime.Focus();
                return;
            }
        }
        if (txtEndTime.Text.Trim() != "")
        {
            try
            {
                time2 = Convert.ToDateTime(txtEndTime.Text.Trim());
            }

            catch
            {
                ShopNum1.Common.MessageBox.Show("结束时间格式不对");

                txtEndTime.Focus();
                return;
            }

        }
        if (txtStartTime.Text.Trim() != "" && txtEndTime.Text.Trim() != "")
        {
            if (time1 > time2)
            {
                ShopNum1.Common.MessageBox.Show("开始时间应该比结束时间早!");
                txtStartTime.Focus();
                return;

            }
            param.Add("start_created", time1.ToString("yyyy-MM-dd"));
            param.Add("end_created", time2.ToString("yyyy-MM-dd"));

        }
        if (ddlOrderState.SelectedValue != "0")
        {
            param.Add("status", ddlOrderState.SelectedValue);
        }
        if (ddlRateState.SelectedValue != "0")
        {
            param.Add("rate_status", ddlRateState.SelectedValue);

        }
        if (ddlistdelivery.SelectedValue != "0")
        {
            param.Add("type", ddlistdelivery.SelectedValue);
        }

        //每页条数。取值范围:大于零的整数;最大值：200；默认值：40。 
        param.Add("page_size", pagelist.PageSize.ToString());
        //页码。取值范围:大于零的整数;默认值为1，即返回第一页数据。 
        param.Add("page_no", pagelist.PageID.ToString());
        strXml = ShopNum1.TbTopCommon.TopAPI.Post("taobao.trades.sold.get", TopClient.AgentSession, param);

        new ShopNum1.TbTopCommon.Parser().XmlToObject2<TbTrade>(strXml, "trades_sold_get", "trades/trade", trades, err);


        int total = new ShopNum1.TbTopCommon.Parser().XmlToTotalResults(strXml, "trades_sold_get");
        pagelist.RecordCount = total;
        if (err.IsError == true)//判断是否更新过程中发生错误
        {

            if (err.code == "41")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "msg", "alert(\"请重新选择时间范围,前后三个月\");", true);
                txtEndTime.Text = "";
                txtStartTime.Text = "";
                txtStartTime.Focus();
                return;
            }

        }

        RepeaterOrder.DataSource = trades;
        //RepeaterOrder.DataKeyField = "tid";
        RepeaterOrder.DataBind();
        ShopNum1.TbTopCommon.PageListBll pagelistHtmlCreate = new ShopNum1.TbTopCommon.PageListBll();
        pagelistHtmlCreate.ShowRecordCount = true;
        pagelistDiv.InnerHtml = pagelistHtmlCreate.GetPageList(pagelist);
    }
    protected void RepOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "close")
        {
            System.Web.UI.HtmlControls.HtmlGenericControl divReason = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("divReason");
            divReason.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else if (e.CommandName == "closeOk")
        {
            TextBox txtCloseReason = (TextBox)e.Item.FindControl("txtCloseReason");
            string tid = "";
            string reason = txtCloseReason.Text.Trim();
            if (CloseTrade(tid, reason))
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "msg", "alert('关闭成功')", true);
                return;

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "msg", "alert('关闭失败')", true);
            }

        }
    }

    /// <summary>
    /// 卖家发货
    /// </summary>
    /// <param name="tid"></param>
    /// <param name="company_code"></param>
    /// <param name="out_sid"></param>
    /// <param name="seller_name"></param>
    /// <param name="seller_area_id"></param>
    /// <param name="sell_address"></param>
    /// <param name="sell_zip"></param>
    /// <param name="seller_phone"></param>
    /// <param name="sell_mobile"></param>
    /// <param name="order_type"></param>
    /// <param name="memo"></param>
    /// <returns></returns>
    private bool SendOrder
     (
       decimal tid,
       string company_code,
       string out_sid,
       string seller_name,
       string seller_area_id,
       string sell_address,
       string sell_zip,
        string seller_phone,
        string sell_mobile,
        string order_type,
        string memo

     )
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        //需返回的字段列表。
        param.Add("fields", "pid,modified");
        param.Add("tid", tid.ToString());
        param.Add("company_code", company_code);
        param.Add("out_sid", out_sid);
        param.Add("seller_name", seller_name);
        param.Add("seller_area_id", seller_area_id);
        param.Add("sell_address", sell_address);
        param.Add("sell_zip", company_code);
        param.Add("seller_phone", seller_phone);
        param.Add("sell_mobile", sell_mobile);
        param.Add("order_type", order_type);
        param.Add("memo", memo);

        string strXml = ShopNum1.TbTopCommon.TopAPI.Post("taobao.delivery.send", TopClient.AgentSession, param);
        ShopNum1.TbTopCommon.ErrorRsp err = new ShopNum1.TbTopCommon.ErrorRsp();
        DeliveryResponse delivery = new DeliveryResponse();
        new Parser().XmlToObject2(strXml, "delivery_send", delivery, err);
        if (err.IsError == true)//判断是否更新过程中发生错误
        {
            //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"操作失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
            return false;
        }
        return true;

    }

    /// <summary>
    /// 获取子订单
    /// </summary>
    /// <param name="tid"></param>
    /// <returns></returns>
    private List<TbOrder> GetChildOrders(string tid)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        param.Add("fields", "orders");
        param.Add("tid", tid);
        string strXml = TopAPI.Post("taobao.trade.get", TopClient.AgentSession, param);
        List<TbOrder> orders = new List<TbOrder>();
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2<TbOrder>(strXml, "trade_get", "trade/orders/order", orders, err);
        if (err.IsError)
            return null;
        return orders;
    }

    /// <summary>
    /// 关闭一笔交易，只能关闭主订单并且是未付款的交易
    /// </summary>
    /// <param name="tid"></param>
    /// <param name="close_reason"></param>
    /// <returns></returns>
    private bool CloseTrade
        (
          string tid,
          string close_reason

        )
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        //需返回的字段列表。
        param.Add("tid", tid);
        param.Add("close_reason", close_reason);
        ErrorRsp err = new ErrorRsp();
        string strXml = TopAPI.Post("taobao.trade.close", TopClient.AgentSession, param);
        //ShopNum1.Common.MessageBox.Show(strXml);
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(strXml);
        try
        {
            new Parser().XmlErrorToObject2(xml, err);
            return !err.IsError;
        }
        catch
        {
            return false;
        }

    }


    protected void RepOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {



        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater RepeaterChildOrder = (Repeater)e.Item.FindControl("RepeaterChildOrder");
            LinkButton LinkButton_Tid = (LinkButton)e.Item.FindControl("LinkButton_Tid");
            string tid = LinkButton_Tid.CommandArgument;
            RepeaterChildOrder.DataSource = GetChildOrders(tid);
            RepeaterChildOrder.DataBind();
            LinkButton LinkButtonClose = (LinkButton)e.Item.FindControl("LinkButtonClose");
            LinkButton LinkButtonSend = (LinkButton)e.Item.FindControl("LinkButtonSend");
            if (LinkButtonSend.CommandArgument.ToString() == " WAIT_SELLER_SEND_GOODS")
            {
                LinkButtonSend.Visible = true;
            }
            else
            {
                LinkButtonSend.Visible = false;
            }
            if (LinkButtonClose.CommandArgument.ToString() == "WAIT_BUYER_PAY")
            {
                LinkButtonClose.Visible = true;

            }
            else
            {
                LinkButtonClose.Visible = false;

            }

        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("TbOrderView_Operate.aspx?guid=" + this.CheckGuid.Value);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (CloseTrade(this.CheckGuid.Value.Replace("'", ""), this.DropDownListReasons.SelectedItem.ToString()))
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "msg", "alert('关闭成功')", true);
            return;

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "msg", "alert('关闭失败')", true);
        }
        BindOrderList("0");
    }
    public string GetUrl(object oid)
    {
        return "http://trade.taobao.com/trade/detail/trade_snap.htm?" + "tradeID=" + oid.ToString() + "&&isArchive=false";
    }
    protected void btnSendProduct_Click(object sender, EventArgs e)
    {
        List<TbTrade> trades = new List<TbTrade>();
        trades = GetTrade(CheckGuid.Value.Replace("'", ""));

        if (trades[0].status != "WAIT_SELLER_SEND_GOODS")
        {
            ShopNum1.Common.MessageBox.Show("请选择买家已付款的订单");
        }
        else
        {
            Page.Response.Redirect("TbSendGood.aspx?tid=" + this.CheckGuid.Value.Replace("'", ""));
        }

    }
    public List<TbTrade> GetTrade(string tid)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        string strXml = string.Empty;
        ShopNum1.TbTopCommon.ErrorRsp err = new ShopNum1.TbTopCommon.ErrorRsp();
        List<TbTrade> trades = new List<TbTrade>();
        param.Add("fields", "seller_nick, buyer_nick, title, type, created, tid, seller_rate, buyer_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,orders");
        param.Add("tid", tid);
        strXml = ShopNum1.TbTopCommon.TopAPI.Post("taobao.trade.get", TopClient.AgentSession, param);

        new ShopNum1.TbTopCommon.Parser().XmlToObject2<TbTrade>(strXml, "trade_get", "trade", trades, err);
        if (err.IsError)
            return null;
        return trades;
    }




    public string MemLoginID { get; set; }


    private string ShopName; //店铺名称
}
