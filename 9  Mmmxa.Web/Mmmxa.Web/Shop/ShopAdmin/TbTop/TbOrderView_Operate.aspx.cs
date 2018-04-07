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
using ShopNum1.Common;
using ShopNum1.Factory;
using System.Collections.Generic;
using ShopNum1.TbTopCommon;
using ShopNum1.TbBusinessEntity;

public partial class TbOrderView_Operate : System.Web.UI.Page
{
    public string memo;
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



        }


        if (Session["access_token"] == null)
        {
            Response.Redirect("TbAuthorization.aspx");
        }

        this.hiddenFieldGuid.Value = Request.QueryString["guid"] == null ? "0" : Request.QueryString["guid"];


        if (!IsPostBack)
        {
            if (this.hiddenFieldGuid.Value != "0")
            {
                //运送方式
                GetShippings();
                BindOrderData();
                GroupRows(Num1GridView1, 6);
                GroupRows(Num1GridView1, 7);
                List<TbTrade> trades1 = new List<TbTrade>();
                trades1 = GetTradeInfo(this.hiddenFieldGuid.Value.Replace("'", ""));
                if (trades1[0].seller_memo == string.Empty)
                {
                    this.ButtonConfirm.Text = "添加";
                }
                else
                {
                    this.ButtonConfirm.Text = "更新";
                }
            }
        }
    }
    protected void ButtonConfirm_Click(object sender, EventArgs e)
    {
        List<TbTrade> trades1 = new List<TbTrade>();
        trades1 = GetTradeInfo(this.hiddenFieldGuid.Value.Replace("'", ""));
        if (trades1[0].seller_memo == string.Empty)
        {
            #region //添加

            Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
            param.Add("tid", this.hiddenFieldGuid.Value.Replace("'", ""));
            param.Add("memo", this.TextBoxNote.Text);
            string strXml = string.Empty;
            strXml = TopAPI.Post("taobao.trade.memo.add", TopClient.AgentSession, param);
            ErrorRsp err = new ErrorRsp();
            TradeMemoRespons tradeMemoRespons = new TradeMemoRespons();
            new Parser().XmlToObject2(strXml, "trade_memo_add", "trade", tradeMemoRespons, err);
            if (err.IsError)//判断是否更新过程中发生错误
            {
                //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
                if (err.code == "520")
                {
                    ShopNum1.Common.MessageBox.Show("卖家交易备注已经存在!");
                    return;
                }
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加商品失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);

            }
            #endregion
        }
        else
        {
            Dictionary<string, string> param1 = new Dictionary<string, string>();//定义 API应用级输入参数
            param1.Add("tid", this.hiddenFieldGuid.Value.Replace("'", ""));
            param1.Add("memo", this.TextBoxNote.Text);
            string strXml1 = TopAPI.Post("taobao.trade.memo.update", TopClient.AgentSession, param1);

            TradeMemoRespons tradeMemoRespons1 = new TradeMemoRespons();
            ErrorRsp err = new ErrorRsp();
            new Parser().XmlToObject2(strXml1, "trade_memo_update", "trade", tradeMemoRespons1, err);

        }
    }
    public void BindOrderData()
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        ShopNum1.TbTopCommon.ErrorRsp err1 = new ShopNum1.TbTopCommon.ErrorRsp();

        //拿子订单信息
        List<TbOrder> Orders = new List<TbOrder>();
        Orders = GetChildOrders(this.hiddenFieldGuid.Value.Replace("'", ""));
        //拿父订单数据
        List<TbTrade> trades = new List<TbTrade>();
        trades = GetTradeInfo(this.hiddenFieldGuid.Value.Replace("'", ""));
        //拿物流信息
        List<TbLocation> Location = new List<TbLocation>();
        Location = GetShipInfo(hiddenFieldGuid.Value.Replace("'", ""));

        List<TbTrade> tradesShow = new List<TbTrade>(Orders.Count);

        for (int i = 0; i < Orders.Count; i++)
        {
            TbTrade TbTrade = new TbTrade();
            tradesShow.Add(TbTrade);
        }

        for (int i = 0; i < Orders.Count; i++)
        {
            tradesShow[i].tid = Orders[i].oid;
            tradesShow[i].pic_path = Orders[i].pic_path;
            tradesShow[i].title = Orders[i].title;
            tradesShow[i].status = trades[0].status;
            tradesShow[i].price = Orders[i].price;
            tradesShow[i].num = Orders[i].num;
            tradesShow[i].total_fee = trades[0].total_fee;
            // 计算优惠
            tradesShow[i].point_fee = Orders[i].total_fee;
            tradesShow[i].post_fee = trades[0].post_fee;
            this.LabelValueCreateTime.Text = trades[0].created;
            this.Labelvaluenick.Text = trades[0].buyer_nick;
            this.LabelValueName.Text = trades[0].receiver_name;
            this.LabelValueRegion.Text = trades[0].receiver_state + "&nbsp;&nbsp;" + trades[0].receiver_city;
            this.LabelValuePhone.Text = trades[0].receiver_phone;
            this.LabelValueOrderNum.Text = trades[0].tid;
            this.LabelValueZhifubao.Text = trades[0].buyer_alipay_no;
            this.LabelValueEmail.Text = trades[0].buyer_email;

            this.LabelValueZhifubaoNum.Text = trades[0].alipay_no;
            this.TextBoxNote.Text = trades[0].seller_memo;
            try
            {
                if (Location != null)
                {
                    this.LabelValueSAdress.Text = trades[0].receiver_name + "," + trades[0].receiver_mobile + "," + trades[0].receiver_phone + "," + Location[0].state + Location[0].city + Location[0].district + "," + Location[0].address + "," + Location[0].zip;
                }
                else
                {
                    this.LabelValueSAdress.Text = trades[0].receiver_state + "&nbsp;&nbsp;" + trades[0].receiver_city + "&nbsp;&nbsp;" + trades[0].receiver_district;

                }
            }
            catch
            {

            }
        }

        this.Num1GridView1.DataSource = tradesShow;
        this.Num1GridView1.DataBind();

    }
    #region //绑定数据源 暂时不用
    public void BindData()
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        ShopNum1.TbTopCommon.ErrorRsp err1 = new ShopNum1.TbTopCommon.ErrorRsp();
        List<TbTrade> trades = new List<TbTrade>();
        List<TbTrade> trades2 = new List<TbTrade>();
        //物流信息
        List<TbLocation> Location = new List<TbLocation>();
        Location = GetShipInfo(hiddenFieldGuid.Value.Replace("'", ""));

        List<TbTrade> trades1 = new List<TbTrade>();
        trades1 = GetTradeInfo(this.hiddenFieldGuid.Value.Replace("'", ""));

        List<TbOrder> Orders = new List<TbOrder>();
        Orders = GetChildOrders(this.hiddenFieldGuid.Value.Replace("'", ""));

        List<TbTrade> tradesData = new List<TbTrade>();
        string pagesize = "200";
        int total = 200;
        int check = 0;
        for (int i = 1; i < total / 200 + 1; i++)
        {
            string strXml = string.Empty;
            param.Clear();
            param.Add("fields", "buyer_nick,title, type,created,sid,tid, seller_rate,buyer_rate,buyer_alipay_no, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,orders");
            param.Add("pagesize", pagesize);
            //每一页评论条数
            param.Add("page_no", i.ToString());
            strXml = ShopNum1.TbTopCommon.TopAPI.Post("taobao.trades.sold.get", TopClient.AgentSession, param);
            new ShopNum1.TbTopCommon.Parser().XmlToObject2<TbTrade>(strXml, "trades_sold_get", "trades/trade", trades, err1);
            total = new ShopNum1.TbTopCommon.Parser().XmlToTotalResults(strXml, "trades_sold_get");
            if (err1.IsError == true)//判断是否更新过程中发生错误
            {
                return;
            }
            for (int k = 0; k < trades.Count; k++)
            {
                if (trades[k].tid == this.hiddenFieldGuid.Value.Replace("'", ""))
                {
                    trades2.Add(trades[k]);
                    tradesData = trades2;
                    for (int j = 0; j < tradesData.Count; j++)
                    {
                        tradesData[j].pic_path = Orders[0].pic_path;
                        tradesData[j].title = Orders[0].title;
                        tradesData[j].status = trades[k].status;
                        //tradesData[j].sid = trades[k].sid;

                        tradesData[j].price = trades[k].price;
                        tradesData[j].num = trades[k].num;
                        tradesData[j].total_fee = Orders[0].total_fee;
                        tradesData[j].buyer_nick = trades[k].buyer_nick;
                        tradesData[j].receiver_address = trades[k].receiver_address;
                        tradesData[j].receiver_zip = trades[k].receiver_zip;
                        tradesData[j].receiver_name = trades[k].receiver_name;
                        tradesData[j].receiver_mobile = trades[k].receiver_mobile;
                        tradesData[j].receiver_district = trades[k].receiver_district;
                        tradesData[j].receiver_city = trades[k].receiver_city;
                        tradesData[j].receiver_state = trades[k].receiver_state;
                        tradesData[j].receiver_phone = trades[k].receiver_phone;
                        tradesData[j].post_fee = trades[k].post_fee;
                        this.LabelValueCreateTime.Text = trades[k].created;
                        this.Labelvaluenick.Text = trades[k].buyer_nick;
                        this.LabelValueName.Text = trades[k].receiver_name;
                        this.LabelValueRegion.Text = trades[k].receiver_state + "&nbsp;&nbsp;" + trades[k].receiver_city;
                        this.LabelValuePhone.Text = trades[k].receiver_phone;
                        this.LabelValueOrderNum.Text = trades[k].tid;
                        this.LabelValueZhifubao.Text = trades1[0].buyer_alipay_no;
                        this.LabelValueEmail.Text = trades1[0].buyer_email;

                        this.LabelValueZhifubaoNum.Text = trades1[0].alipay_no;
                        this.TextBoxNote.Text = trades1[0].seller_memo;
                        //MessageBox.Show(trades[k].seller_memo);
                        //物流信息
                        try
                        {
                            if (Location != null)
                            {
                                this.LabelValueSAdress.Text = trades[k].receiver_name + "," + trades[k].receiver_mobile + "," + trades[k].receiver_phone + "," + Location[0].state + Location[0].city + Location[0].district + "," + Location[0].address + "," + Location[0].zip;
                            }
                            else
                            {
                                this.LabelValueSAdress.Text = trades[k].receiver_state + "&nbsp;&nbsp;" + trades[k].receiver_city + "&nbsp;&nbsp;" + trades[k].receiver_district;

                            }
                        }
                        catch
                        {

                        }
                        //this.Label1ValueTrade.Text = "卖家包邮";

                    }
                    //string promotion_details=trades[k].promotion_details;;

                }
            }
        }
        this.Num1GridView1.DataSource = tradesData;
        this.Num1GridView1.DataBind();
    }
    #endregion

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
    /// 获取优惠情况
    /// </summary>
    /// <param name="tid"></param>
    /// <returns></returns>
    private List<TbOrder> GetPromotionDetail(string tid)
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
    public string ChangePromotion(object Sprice, object total_fee)
    {
        decimal m = Convert.ToDecimal(Sprice) - Convert.ToDecimal(Convert.ToString(total_fee).Replace("-", ""));

        if (m != 0)
        {
            return "优惠了" + m.ToString() + "元";
        }
        else
        {
            return "无优惠";
        }

    }
    public static string Changestatus(object obj)
    {
        if (obj.ToString() == "TRADE_NO_CREATE_PAY")
        {
            return "没有创建支付宝交易";
        }
        else if (obj.ToString() == "WAIT_BUYER_PAY")
        {
            return "等待付款";
        }
        else if (obj.ToString() == "WAIT_SELLER_SEND_GOODS")
        {
            return "买家已付款";
        }
        else if (obj.ToString() == "WAIT_BUYER_CONFIRM_GOODS")
        {
            return "待确认收货";
        }
        else if (obj.ToString() == "TRADE_BUYER_SIGNED")
        {
            return "买家已签收";
        }
        else if (obj.ToString() == "TRADE_FINISHED")
        {
            return "交易成功";
        }
        else if (obj.ToString() == "TRADE_CLOSED")
        {
            return "交易关闭";
        }
        else if (obj.ToString() == "TRADE_CLOSED_BY_TAOBAO")
        {
            return "被淘宝关闭";
        }
        else if (obj.ToString() == "ALL_WAIT_PAY")
        {
            return "ALL等待付款";
        }
        else
        {
            return "ALL交易关闭";
        }
    }
    /// <summary>
    /// 获取物流信息
    /// </summary>
    /// <returns></returns>
    public List<TbLocation> GetShipInfo(string tid)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        param.Add("fields", "seller_nick,buyer_nick,item_title,receiver_location,status,type,company_name,created,modified");
        param.Add("tid", tid);
        string strXml = TopAPI.Post("taobao.logistics.orders.detail.get", TopClient.AgentSession, param);
        List<TbLocation> Location = new List<TbLocation>();
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2<TbLocation>(strXml, "logistics_orders_detail_get", "shippings/shipping/location", Location, err);
        if (err.IsError)
            return null;
        return Location;
    }
    public List<TbShipping> GetShipInfo1(string tid)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        param.Add("fields", "seller_nick,buyer_nick,item_title,receiver_location,status,type,company_name,created,modified");
        param.Add("tid", tid);
        string strXml = TopAPI.Post("taobao.logistics.orders.detail.get", TopClient.AgentSession, param);
        List<TbShipping> Shipings = new List<TbShipping>();
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2<TbShipping>(strXml, "logistics_orders_detail_get", "shippings/shipping", Shipings, err);
        if (err.IsError)
            return null;
        return Shipings;
    }
    public void GetShippings()
    {
        //物流信息
        List<TbShipping> Shippings = new List<TbShipping>();
        try
        {
            //物流信息
            Shippings = GetShipInfo1(hiddenFieldGuid.Value.Replace("'", ""));
            if (Shippings[0].type == "free")
            {
                this.Label1ValueTrade.Text = "卖家包邮";
            }
            else if (Shippings[0].type == "post")
            {
                this.Label1ValueTrade.Text = "平邮";
            }
            else if (Shippings[0].type == "express")
            {
                this.Label1ValueTrade.Text = "快递";
            }
            else if (Shippings[0].type == "ems")
            {
                this.Label1ValueTrade.Text = "EMS";
            }
            else
            {
                this.Label1ValueTrade.Text = "买家还没付款，等待中";
            }
        }
        catch
        {
        }
    }
    public List<TbTrade> GetTradeInfo(string tid)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        param.Add("fields", "seller_nick, buyer_nick, title, type, created, tid, seller_rate,buyer_flag, buyer_rate, status, payment, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, buyer_memo, seller_memo, alipay_no, buyer_message, pic_path, num_iid, num, price, buyer_alipay_no, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone, buyer_email,seller_flag, seller_alipay_no, seller_mobile, seller_phone, seller_name, seller_email, available_confirm_fee, has_post_fee, timeout_action_time, snapshot_url, cod_fee, cod_status, shipping_type, trade_memo, is_3D,buyer_memo,buyer_email");
        param.Add("tid", tid);
        string strXml = TopAPI.Post("taobao.trade.fullinfo.get", TopClient.AgentSession, param);

        List<TbTrade> trades = new List<TbTrade>();
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2<TbTrade>(strXml, "trade_fullinfo_get", "trade", trades, err);
        if (err.IsError)
            return null;
        return trades;
    }
    public string GetUrl(object tid)
    {
        return "http://trade.taobao.com/trade/detail/trade_snap.htm?" + "tradeID=" + tid.ToString() + "&&isArchive=false";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("TbOrderView.aspx");
    }

    /// <summary>

    /// 合并GridView中某列相同信息的行（单元格）

    /// </summary>

    /// <param name="GridView1">GridView</param>

    /// <param name="cellNum">第几列</param>

    public static void GroupRows(GridView GridView1, int cellNum)
    {

        int i = 0, rowSpanNum = 1;

        while (i < GridView1.Rows.Count - 1)
        {

            GridViewRow gvr = GridView1.Rows[i];

            for (++i; i < GridView1.Rows.Count; i++)
            {

                GridViewRow gvrNext = GridView1.Rows[i];

                if (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text)
                {

                    gvrNext.Cells[cellNum].Visible = false;

                    rowSpanNum++;

                }

                else
                {

                    gvr.Cells[cellNum].RowSpan = rowSpanNum;

                    rowSpanNum = 1;

                    break;

                }

                if (i == GridView1.Rows.Count - 1)
                {

                    gvr.Cells[cellNum].RowSpan = rowSpanNum;

                }

            }

        }

    }
}
