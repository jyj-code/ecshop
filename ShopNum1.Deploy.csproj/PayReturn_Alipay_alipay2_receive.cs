using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Payment;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
public class PayReturn_Alipay_alipay2_receive : Page, IRequiresSessionState
{
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
		SortedDictionary<string, string> requestPost = this.GetRequestPost();
		string partner = string.Empty;
		string string_ = string.Empty;
		ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
		DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay3.aspx");
		if (paymentKey.Rows.Count > 0)
		{
			partner = paymentKey.Rows[0]["MerchantCode"].ToString();
			string_ = paymentKey.Rows[0]["SecretKey"].ToString();
		}
		string input_charset = "utf-8";
		string sign_type = "MD5";
		string transport = "http";
		if (requestPost.Count > 0)
		{
			Alipay3Notify alipay3Notify = new Alipay3Notify(requestPost, base.Request.QueryString["notify_id"], partner, string_, input_charset, sign_type, transport);
			string responseTxt = alipay3Notify.ResponseTxt;
			string a = base.Request.QueryString["sign"];
			string mysign = alipay3Notify.Mysign;
			if (responseTxt == "true" && a == mysign)
			{
				string text = base.Request.QueryString["trade_no"];
				string text2 = base.Request.QueryString["out_trade_no"];
				string value = base.Request.QueryString["total_fee"];
				string arg_169_0 = base.Request.QueryString["subject"];
				string arg_17F_0 = base.Request.QueryString["body"];
				string arg_195_0 = base.Request.QueryString["buyer_email"];
				string arg_1AB_0 = base.Request.QueryString["trade_status"];
				if (base.Request.QueryString["trade_status"] == "TRADE_FINISHED" || base.Request.QueryString["trade_status"] == "TRADE_SUCCESS")
				{
					if (text2.IndexOf("C") != -1)
					{
						ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
						string nameById = Common.GetNameById("OrderNumber", "ShopNum1_AdvancePaymentApplyLog", " And OrderNumber='" + text2 + "' And operatestatus=0");
						File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "\r\n\t" + text2 + "错误信息2：" + nameById, Encoding.UTF8);
						if (nameById != "" && nameById != "0")
						{
							string text3 = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
							this.AdvancePaymentModifyLog(1, Convert.ToDecimal(text3), Convert.ToDecimal(value), "支付宝及时到账会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
							shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, text2);
						}
						base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
					}
					else
					{
						ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
						DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text2);
						if (dataTable.Rows.Count > 0)
						{
							int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
							if (num < 1)
							{
								string text4 = dataTable.Rows[0]["MemLoginID"].ToString();
								string orderGuId = dataTable.Rows[0]["Guid"].ToString();
								string text5 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
								dataTable.Rows[0]["OrderNumber"].ToString();
								string strOrderGuId = dataTable.Rows[0]["GuID"].ToString();
								ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
								shopNum1_OrderProduct_Action.UpdateStock(strOrderGuId);
								shopNum1_OrderInfo_Action.SetPaymentStatus2(text2, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(text5), text);
								if (this.CheckMember(text4) == 1)
								{
									ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
									shopNum1_Member_Action.UpdateCostMoney(text4, Convert.ToDecimal(value));
								}
								string text3 = string.Empty;
								if (dataTable.Rows[0]["FeeType"].ToString() == "2")
								{
									this.IsMMS(dataTable.Rows[0]["ordernumber"].ToString(), dataTable.Rows[0]["IdentifyCode"].ToString(), dataTable.Rows[0]["MemloginId"].ToString(), dataTable.Rows[0]["Mobile"].ToString(), dataTable.Rows[0]["ProductName"].ToString(), dataTable.Rows[0]["BuyNumber"].ToString());
								}
								this.OrderOperateLog("已付款", "买家已付款", "等待卖家发货", orderGuId, text4);
								Thread.Sleep(60);
								base.Response.Redirect(string.Concat(new string[]
								{
									"/main/Member/m_index.aspx?orderv=",
									text2,
									"|",
									text5,
									"|",
									text3,
									"|",
									text
								}));
							}
							else
							{
								base.Response.Redirect("/main/Member/m_index.aspx?orders=" + text2 + "|" + dataTable.Rows[0]["Mobile"].ToString());
							}
						}
						else
						{
							base.Response.Write("success");
						}
					}
				}
			}
			else
			{
				base.Response.Write("fail");
			}
		}
		else
		{
			base.Response.Write("无通知参数");
		}
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
	protected void IsMMS(string OrderNumber, string strCode, string memloginID, string string_0, string strProductName, string strBuyNum)
	{
		if (!(string_0.Trim() == ""))
		{
			OrderInfo orderInfo = new OrderInfo();
			orderInfo.Name = memloginID;
			orderInfo.OrderNumber = OrderNumber;
			orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			orderInfo.ShopName = ShopSettings.GetValue("Name");
			string text = "73370552-efdb-47ec-9e0f-f813261375b8";
			ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
			DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("'" + text + "'", 0);
			if (editInfo != null && editInfo.Rows.Count > 0)
			{
				string text2 = editInfo.Rows[0]["Remark"].ToString();
				text2 = text2.Replace("{$Name}", orderInfo.Name);
				text2 = text2.Replace("{$IdentifyCode}", strCode);
				text2 = text2.Replace("{$OrderNumber}", orderInfo.OrderNumber);
				text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
				text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
				text2 = text2.Replace("{$ProductName}", strProductName);
				text2 = text2.Replace("{$BuyNum}", strBuyNum);
				string mMsTitle = editInfo.Rows[0]["Title"].ToString();
				SMS sMS = new SMS();
				ShopNum1_MMSGroupSend_Action shopNum1_MMSGroupSend_Action = (ShopNum1_MMSGroupSend_Action)LogicFactory.CreateShopNum1_MMSGroupSend_Action();
				string text3 = "";
				text2 = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text2));
				sMS.Send(string_0.Trim(), text2, out text3);
				if (text3.IndexOf("发送成功") != -1)
				{
					ShopNum1_MMSGroupSend mMSGroupSend = this.AddMMS(memloginID, string_0.Trim(), text2, mMsTitle, 2, text);
					shopNum1_MMSGroupSend_Action.Add(mMSGroupSend);
				}
				else
				{
					ShopNum1_MMSGroupSend mMSGroupSend = this.AddMMS(memloginID, string_0.Trim(), text2, mMsTitle, 0, text);
					shopNum1_MMSGroupSend_Action.Add(mMSGroupSend);
				}
			}
		}
	}
	protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string Content, string MMsTitle, int state, string mmsGuid)
	{
		return new ShopNum1_MMSGroupSend
		{
			Guid = Guid.NewGuid(),
			MMSTitle = MMsTitle,
			CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
			MMSGuid = new Guid(mmsGuid),
			SendObjectMMS = Content,
			SendObject = memLoginID + "-" + mobile,
			State = state
		};
	}
	protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId, string MemLoginID)
	{
		if (!string.IsNullOrEmpty(OrderGuId))
		{
			ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
			shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
			shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(OrderGuId);
			shopNum1_OrderOperateLog.OderStatus = 1;
			shopNum1_OrderOperateLog.ShipmentStatus = 0;
			shopNum1_OrderOperateLog.PaymentStatus = 0;
			shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
			shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
			shopNum1_OrderOperateLog.Memo = memo;
			shopNum1_OrderOperateLog.OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			shopNum1_OrderOperateLog.IsDeleted = 0;
			shopNum1_OrderOperateLog.CreateUser = MemLoginID;
			ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
			shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
		}
	}
	public SortedDictionary<string, string> GetRequestPost()
	{
		SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
		NameValueCollection queryString = base.Request.QueryString;
		string[] allKeys = queryString.AllKeys;
		for (int i = 0; i < allKeys.Length; i++)
		{
			sortedDictionary.Add(allKeys[i], base.Request.QueryString[allKeys[i]]);
		}
		return sortedDictionary;
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
