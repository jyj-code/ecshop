using AlipayClass;
using ShopNum1.BusinessLogic;
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
public class return_url : Page, IRequiresSessionState
{
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
		DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay.aspx");
		if (paymentKey.Rows.Count > 0)
		{
			partner = paymentKey.Rows[0]["MerchantCode"].ToString();
			key = paymentKey.Rows[0]["SecretKey"].ToString();
		}
		string input_charset = "utf-8";
		string sign_type = "MD5";
		string transport = "https";
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
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
				DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text2);
				string text13 = dataTable.Rows[0]["MemLoginID"].ToString();
				string text14 = dataTable.Rows[0]["Guid"].ToString();
				string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
				dataTable.Rows[0]["OrderNumber"].ToString();
				string a2 = dataTable.Rows[0]["OderStatus"].ToString();
				string a3 = dataTable.Rows[0]["PaymentStatus"].ToString();
				string a4 = dataTable.Rows[0]["ShipmentStatus"].ToString();
				if (base.Request.Form["trade_status"] == "WAIT_BUYER_PAY")
				{
					if (!(a2 == "0") || !(a4 == "0") || !(a3 == "0"))
					{
						shopNum1_OrderInfo_Action.SetWaitBuyerPay("0", "0", "0", text14);
					}
				}
				else if (base.Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS")
				{
					if (!(a2 == "1") || !(a3 == "1") || !(a4 == "0"))
					{
						shopNum1_OrderInfo_Action.SetPaymentStatus2(text14, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text3), Convert.ToDecimal(value));
						if (this.CheckMember(text13) == 1)
						{
							ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
							shopNum1_Member_Action.UpdateCostMoney(text13, Convert.ToDecimal(text3));
						}
					}
				}
				else if (base.Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
				{
					if (!(a2 == "2") || !(a3 == "1") || !(a4 == "1"))
					{
						Random random = new Random();
						shopNum1_OrderInfo_Action.SetShipmentStatus1(text14, 2, 1, 1, DateTime.Now, "XT_" + DateTime.Now.ToLongTimeString().Replace("-", "") + random.Next(0, 1000));
					}
				}
				else if (base.Request.Form["trade_status"] == "TRADE_FINISHED")
				{
					if (!(a2 == "3") || !(a3 == "1") || !(a4 == "2"))
					{
						shopNum1_OrderInfo_Action.SetShipmentStatus2(text14, 3, 1, 2);
					}
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
