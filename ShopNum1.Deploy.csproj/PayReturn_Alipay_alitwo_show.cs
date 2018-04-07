using AlipayClass;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class PayReturn_Alipay_alitwo_show : Page, IRequiresSessionState
{
	public bool IsDoMain;
	public string AgentHost = string.Empty;
	protected Label lbTrade_no;
	protected Label lbOut_trade_no;
	protected Label lbTotal_fee;
	protected Label lbSubject;
	protected Label lbBody;
	protected Label lbBuyer_email;
	protected Label LbName;
	protected Label LbAddress;
	protected Label LbZip;
	protected Label LbPhone;
	protected Label LbMobile;
	protected Label lbTrade_status;
	protected Label lbVerify;
	protected HtmlForm form1;
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		ArrayList requestGet = this.GetRequestGet();
		string partner = string.Empty;
		string key = string.Empty;
		ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
		DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay2.aspx");
		if (paymentKey.Rows.Count > 0)
		{
			partner = paymentKey.Rows[0]["MerchantCode"].ToString();
			key = paymentKey.Rows[0]["SecretKey"].ToString();
		}
		string input_charset = "utf-8";
		string sign_type = "MD5";
		string transport = "http";
		if (requestGet.Count > 0)
		{
			AlipayNotify alipayNotify = new AlipayNotify(requestGet, base.Request.QueryString["notify_id"], partner, key, input_charset, sign_type, transport);
			string responseTxt = alipayNotify.ResponseTxt;
			string a = base.Request.QueryString["sign"];
			string mysign = alipayNotify.Mysign;
			if (responseTxt == "true" && a == mysign)
			{
				string text = base.Request.QueryString["trade_no"];
				string text2 = base.Request.QueryString["out_trade_no"];
				string text3 = base.Request.QueryString["price"];
				string text4 = base.Request.QueryString["subject"];
				string text5 = base.Request.QueryString["body"];
				string text6 = base.Request.QueryString["buyer_email"];
				string text7 = base.Request.QueryString["receive_name"];
				string text8 = base.Request.QueryString["receive_address"];
				string text9 = base.Request.QueryString["receive_zip"];
				string text10 = base.Request.QueryString["receive_phone"];
				string text11 = base.Request.QueryString["receive_mobile"];
				string text12 = base.Request.QueryString["trade_status"];
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
				DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text2);
				int num = int.Parse(dataTable.Rows[0]["OderStatus"].ToString());
				this.lbTrade_no.Text = text;
				this.lbOut_trade_no.Text = text2;
				this.lbTotal_fee.Text = text3;
				this.lbSubject.Text = text4;
				this.lbBody.Text = text5;
				this.lbBuyer_email.Text = text6;
				this.LbName.Text = text7;
				this.LbAddress.Text = text8;
				this.LbZip.Text = text9;
				this.LbPhone.Text = text10;
				this.LbMobile.Text = text11;
				this.lbTrade_status.Text = text12;
				this.lbVerify.Text = "验证成功";
				if (base.Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS" || base.Request.QueryString["trade_status"] == "TRADE_FINISHED")
				{
					if (num >= 1)
					{
					}
					dataTable.Rows[0]["MemLoginID"].ToString();
					string guid = dataTable.Rows[0]["Guid"].ToString();
					string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
					dataTable.Rows[0]["OrderNumber"].ToString();
					shopNum1_OrderInfo_Action.SetPaymentStatus2(guid, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text3), Convert.ToDecimal(value));
					this.Page.Response.Redirect("/main/Member/m_index.aspx");
				}
				else if (base.Request.Form["trade_status"] == "TRADE_FINISHED")
				{
					Common.UpdateInfo("oderstatus=3,paymentstatus=1,ShipmentStatus=2", "ShopNum1_Orderinfo", " And tradeid='" + text2 + "'");
				}
				else
				{
					base.Response.Write("trade_status=" + base.Request.QueryString["trade_status"]);
				}
			}
			else
			{
				this.lbVerify.Text = "验证失败";
			}
		}
		else
		{
			this.lbVerify.Text = "无返回参数";
		}
	}
	public ArrayList GetRequestGet()
	{
		ArrayList arrayList = new ArrayList();
		NameValueCollection queryString = base.Request.QueryString;
		string[] allKeys = queryString.AllKeys;
		for (int i = 0; i < allKeys.Length; i++)
		{
			arrayList.Add(allKeys[i] + "=" + base.Request.QueryString[allKeys[i]]);
		}
		return arrayList;
	}
	protected int CheckMember(string strValue)
	{
		int result = 0;
		try
		{
			Guid guid = new Guid(strValue);
		}
		catch
		{
			result = 1;
		}
		return result;
	}
}
