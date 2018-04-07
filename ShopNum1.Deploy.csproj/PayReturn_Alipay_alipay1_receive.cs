using AlipayClass;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class PayReturn_Alipay_alipay1_receive : Page, IRequiresSessionState
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
			string arg_CB_0 = alipayNotify.ResponseTxt;
			string arg_E1_0 = base.Request.QueryString["sign"];
			string arg_E9_0 = alipayNotify.Mysign;
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
			if (!(base.Request.Form["trade_status"] == "WAIT_BUYER_PAY"))
			{
				if (base.Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS")
				{
					if (base.Request.QueryString["body"] == "Recharge")
					{
						ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
						string nameById = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
						this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(Common.ReqStr("price")), "支付宝担保交易会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
						shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, Common.ReqStr("subject"));
						base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
					}
					else
					{
						string text13 = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where tradeid='" + text2 + "'";
						DataTable dataTable = DatabaseExcetue.ReturnDataTable(text13);
						if (dataTable.Rows.Count > 0)
						{
							string text14 = dataTable.Rows[0]["MemLoginID"].ToString();
							string text15 = dataTable.Rows[0]["Guid"].ToString();
							string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
							dataTable.Rows[0]["OrderNumber"].ToString();
							string a = dataTable.Rows[0]["OderStatus"].ToString();
							string text16 = dataTable.Rows[0]["PaymentStatus"].ToString();
							string a2 = dataTable.Rows[0]["ShipmentStatus"].ToString();
							if (Convert.ToInt32(text16) < 1)
							{
								shopNum1_OrderInfo_Action.SetPaymentStatus2(text2, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text3), Convert.ToDecimal(value), text);
								ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
								shopNum1_OrderProduct_Action.UpdateStock(text15);
								if (this.CheckMember(text14) == 1)
								{
									ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
									shopNum1_Member_Action.UpdateCostMoney(text14, Convert.ToDecimal(text3));
								}
								string nameById = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
								this.OrderOperateLog("支付宝担保交易会员购买商品", "买家已付款", "等待卖家发货", text15);
							}
						}
						base.Response.Redirect("/main/Member/m_index.aspx");
					}
				}
				else if (!(base.Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS"))
				{
					if (base.Request.Form["trade_status"] == "TRADE_FINISHED")
					{
						try
						{
							string text13 = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where OrderNumber='" + text2 + "'";
							File.AppendAllText(base.Server.MapPath("/log/" + DateTime.Now.ToString("yyyyMMdd") + "_Apay.txt"), text13);
							DataTable dataTable = DatabaseExcetue.ReturnDataTable(text13);
							if (dataTable.Rows.Count > 0)
							{
								string text14 = dataTable.Rows[0]["MemLoginID"].ToString();
								string text15 = dataTable.Rows[0]["Guid"].ToString();
								string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
								dataTable.Rows[0]["OrderNumber"].ToString();
								string a = dataTable.Rows[0]["OderStatus"].ToString();
								string text16 = dataTable.Rows[0]["PaymentStatus"].ToString();
								string a2 = dataTable.Rows[0]["ShipmentStatus"].ToString();
								if (a == "2" && text16 == "1" && a2 == "1")
								{
									shopNum1_OrderInfo_Action.SetShipmentStatus2(text15, 3, 1, 2);
								}
							}
							return;
						}
						catch (Exception ex)
						{
							File.AppendAllText(base.Server.MapPath("/log/" + DateTime.Now.ToString("yyyyMMdd") + "_Apay.txt"), ex.Message);
							return;
						}
					}
					base.Response.Write("trade_status=" + base.Request.QueryString["trade_status"]);
				}
			}
		}
		else
		{
			this.lbVerify.Text = "无返回参数";
		}
	}
	protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId)
	{
		if (base.Request.QueryString["out_trade_no"] != null)
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
			shopNum1_OrderOperateLog.OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			shopNum1_OrderOperateLog.IsDeleted = 0;
			shopNum1_OrderOperateLog.CreateUser = this.method_0();
			ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
			shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
		}
	}
	private string method_0()
	{
		string result = "jely";
		if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
		{
			HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			result = httpCookie.Values["MemLoginID"].ToString();
		}
		return result;
	}
	public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type)
	{
		ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
		shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
		shopNum1_AdvancePaymentModifyLog.OperateType = OperateType;
		shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = AdvancePayments;
		shopNum1_AdvancePaymentModifyLog.OperateMoney = payMoney;
		if (type == 1)
		{
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments + payMoney;
		}
		else
		{
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
		}
		shopNum1_AdvancePaymentModifyLog.Date = time;
		shopNum1_AdvancePaymentModifyLog.Memo = Memo;
		shopNum1_AdvancePaymentModifyLog.MemLoginID = shopMemloginID;
		shopNum1_AdvancePaymentModifyLog.CreateUser = shopMemloginID;
		shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(time);
		shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
		ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
		shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
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
