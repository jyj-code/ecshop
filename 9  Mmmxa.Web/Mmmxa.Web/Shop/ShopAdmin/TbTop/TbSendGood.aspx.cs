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
using System.Collections.Generic;
using ShopNum1.TbTopCommon;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Text;
using ShopNum1.TbBusinessEntity;

public partial class TbSendGood : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //验证会员中心的cookies
        if (Page.Request.Cookies["MemberLoginCookie"] == null)
        {      //退出
            GetUrl.RedirectTopLogin();
        }
        else
        {
            HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
            string MemberType = decodedCookieMemberLogin.Values["MemberType"].ToString();
            if (MemberType != "2")
            {
                //退出
                GetUrl.RedirectTopLogin();
                return;
            }
            //会员登录ID
           


        }

        this.hiddenFieldGuid.Value = Request.QueryString["tid"] == null ? "0" : Request.QueryString["tid"];
        
        if (!IsPostBack)
        {
            ProvinceBind();
            CitysBind();
            GetShipInfo(this.hiddenFieldGuid.Value.Replace("'",""));
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        SendGoods();
    }
    public void SendGoods()
    {
        List<TbTrade> trades = new List<TbTrade>();
        trades = GetTradeInfo(this.hiddenFieldGuid.Value);

        //卖家信息获取
        List<TbLocation> Location = new List<TbLocation>();
        Location = GetSellerInfo();

        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        if (RadioButtonorder_type.SelectedValue == "3")
        {
            param.Add("order_type", "virtual_goods");
            param.Add("tid", this.hiddenFieldGuid.Value);
        }
        else
        {
            param.Add("tid", this.hiddenFieldGuid.Value);
            param.Add("order_type", "delivery_needed");
            param.Add("out_sid", this.TextBoxout_sid.Text);
            param.Add("company_code", Getcompanycode());
            param.Add("seller_name", trades[0].seller_name);
            param.Add("seller_area_id", GetAreaid());//卖家所在地国家公布的标准地区码
            param.Add("seller_address", Location[0].address);
            param.Add("seller_zip", Location[0].zip);
            param.Add("seller_mobile", this.TextBoxseller_mobile.Text);
        }

        string strXml = TopAPI.Post("taobao.delivery.send", TopClient.AgentSession, param);
        ErrorRsp err = new ErrorRsp();
        List<TbShipping> Shipping = new List<TbShipping>();
        new Parser().XmlToObject2(strXml, "delivery_send", "Shipping", Shipping, err);
        if (err.IsError)//判断是否更新过程中发生错误
        {
            MessageBox.Show(err.msg);
           
        }
        
        try
        {
            if (Shipping[0].is_success == "true")
            {
                MessageBox.Show("发货成功");
            }
            else
            {
                MessageBox.Show("发货失败");
            }
        }
        catch
        {

        }
    }
    //获取卖家所在地国家公布的标准地区码
    public string GetAreaid()
    {
        //卖家信息获取
        List<TbLocation> Location = new List<TbLocation>();
        Location = GetSellerInfo();

        
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        List<TbArea> Area = new List<TbArea>();
        param.Add("fields", "id,type,name,parent_id,zip");
        string strXml = string.Empty;
        strXml = TopAPI.Post("taobao.areas.get", TopClient.AgentSession, param);
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2(strXml, "areas_get", "areas/area", Area, err);
        string Areaid = string.Empty;
        
        for (int i=0; i < Area.Count; i++)
        {
            if (Location[0].state == Area[i].name)
            {
                Areaid = Area[i].parent_id;
            }
        }
        return Areaid;
    }
    //获取物流公司编码
    public string Getcompanycode()
    {
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        List<TbLogistics_Companies> logistics_companies = new List<TbLogistics_Companies>();
        param.Add("fields", "id,code,name");
        string strXml = string.Empty;
        strXml = TopAPI.Post("taobao.logistics.companies.get", TopClient.AgentSession, param);
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2(strXml, "logistics_companies_get", "logistics_companies/logistics_company", logistics_companies, err);
        if (err.IsError)
            return null;
        string code="";
        for (int i = 0; i < logistics_companies.Count; i++)
        {
            if (this.DropDownListcompany_code.SelectedItem.Text == logistics_companies[i].name)
            {
                code = logistics_companies[i].code;
            }
        }
        return code;
    }
    protected void RadioButtonorder_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RadioButtonorder_type.SelectedValue == "3")
        {
            this.Panel1.Visible = false;
            this.nn.Visible = false;
        }
        else
        {
            this.nn.Visible = true;
            this.Panel1.Visible = true;
        }
        if (this.RadioButtonorder_type.SelectedValue == "2")
        {
            this.nn.Visible = false;
            this.mm.Visible = true;
        }
        else
        {
            //this.nn.Visible = true;
            this.mm.Visible = false;
        }
        if (this.RadioButtonorder_type.SelectedValue == "1")
        {
            this.date.Visible = true;
            this.dateTime.Visible = true;
        }
        else
        {
            this.date.Visible = false;
            this.dateTime.Visible = false;
        }
        if (this.RadioButtonorder_type.SelectedValue == "0")
        {
            this.Tr1.Visible = true;
        }
        else
        {
            this.Tr1.Visible = false;
        }
    }

    /// <summary>
    /// 省份绑定
    /// </summary>
    private void ProvinceBind()
    {
        //TbTbAddress_Action tbAddress = (TbTbAddress_Action)LogicTbFactory.CreateTbTbAddress_Action();
        //ddlProvince.DataSource = tbAddress.GetCitysByParent(1);
        //ddlProvince.DataTextField = "name";
        //ddlProvince.DataValueField = "Id";
        //ddlProvince.DataBind();
        //ddlProvince.SelectedIndex = 0;
    }


    /// <summary>
    /// 城市绑定
    /// </summary>
    /// <param name="Id"></param>
    private void CitysBind()
    {
        //int Id = Convert.ToInt32(ddlProvince.SelectedValue);
        //TbTbAddress_Action tbAddress = (TbTbAddress_Action)LogicTbFactory.CreateTbTbAddress_Action();
        //ddlCity.DataSource = tbAddress.GetCitysByParent(Id);
        //ddlCity.DataValueField = "Id";
        //ddlCity.DataTextField = "name";
        //ddlCity.DataBind();

    }


    /// <summary>
    /// 省份事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        CitysBind();
    }
    /// <summary>
    /// 更新发货信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        update();
    }
    //更新发货信息
    public void update()
    {
        List<TbTrade> trades = new List<TbTrade>();
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        param.Add("tid", this.hiddenFieldGuid.Value);
        param.Add("receiver_name", this.TextBoxeller_name.Text);
        param.Add("receiver_phone", this.TextBoxseller_phone.Text);
        param.Add("receiver_mobile", this.TextBoxseller_mobile.Text);
        param.Add("receiver_state", this.ddlProvince.SelectedItem.ToString());
        param.Add("receiver_city", this.ddlCity.SelectedItem.ToString());
        //param.Add("receiver_district", this.ddlCity.SelectedItem.ToString());
        param.Add("receiver_address", this.TextBoxseller_address.Text);
        param.Add("receiver_zip", this.TextBoxseller_zip.Text);
        string strXml = string.Empty;
        strXml = TopAPI.Post("taobao.trade.shippingaddress.update", TopClient.AgentSession, param);
        //MessageBox.Show(strXml);
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2(strXml, "trade_shippingaddress_update", "trade", trades, err);
        if (err.IsError)//判断是否更新过程中发生错误
        {
            if (err.code == "520")
            {
                ShopNum1.Common.MessageBox.Show("只能更新发货前的收获地址信息!");
                return;
            }
            //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加商品失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);

        }
            
    }
    /// <summary>
    /// 获取物流信息
    /// </summary>
    /// <returns></returns>
    public void GetShipInfo(string tid)
    {
        List<TbTrade> trades = new List<TbTrade>();
        trades = GetTradeInfo(this.hiddenFieldGuid.Value);
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        param.Add("fields", "seller_nick,buyer_nick,item_title,receiver_location,status,type,company_name,created,modified");
        param.Add("tid", tid);
        string strXml = TopAPI.Post("taobao.logistics.orders.detail.get", TopClient.AgentSession, param);
        List<TbLocation> Location = new List<TbLocation>();
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2<TbLocation>(strXml, "logistics_orders_detail_get", "shippings/shipping/location", Location, err);
        if (err.IsError)
            return;
        foreach (ListItem item in ddlProvince.Items)
        {
            if (item.Text == Location[0].state)
            {
                ddlProvince.SelectedValue =item.Value;
                CitysBind();
            }
                
        }
        TextBoxseller_zip.Text = Location[0].zip;
        TextBoxseller_address.Text = Location[0].address;
        TextBoxeller_name.Text = trades[0].receiver_name;
        TextBoxseller_phone.Text = trades[0].receiver_phone;
        TextBoxseller_mobile.Text = trades[0].receiver_mobile;
        TextBoxseller_mobile.Text = trades[0].receiver_mobile;
    }
    //获取
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
    public List<TbLocation> GetSellerInfo()
    {
        List<TbTrade> trades = new List<TbTrade>();
        trades = GetTradeInfo(this.hiddenFieldGuid.Value);
        List<TbLocation> Location = new List<TbLocation>();
        Dictionary<string, string> param = new Dictionary<string, string>();//定义 API应用级输入参数
        param.Add("fields", "user_id,nick,seller_credit,location");
        param.Add("nick", trades[0].seller_nick);

        string strXml = TopAPI.Post("taobao.user.get", TopClient.AgentSession, param);
        ErrorRsp err = new ErrorRsp();
        new Parser().XmlToObject2<TbLocation>(strXml, "user_get", "user/location", Location, err);
        if (err.IsError)
            return null;
        return Location;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("TbOrderView.aspx");
    }
}
