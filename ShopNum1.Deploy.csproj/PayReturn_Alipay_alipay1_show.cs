using AlipayClass;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
public class PayReturn_Alipay_alipay1_show : Page, IRequiresSessionState
{
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
		ArrayList requestPost = this.GetRequestPost();
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
		if (requestPost.Count > 0)
		{
			AlipayNotify alipayNotify = new AlipayNotify(requestPost, base.Request.Form["notify_id"], partner, key, input_charset, sign_type, transport);
			string arg_CB_0 = alipayNotify.ResponseTxt;
			string arg_E1_0 = base.Request.Form["sign"];
			string arg_E9_0 = alipayNotify.Mysign;
			string strTrade_no = base.Request.Form["trade_no"];
			string text = base.Request.Form["out_trade_no"];
			string value = base.Request.Form["price"];
			string guid = base.Request.Form["subject"];
			string arg_15B_0 = base.Request.Form["body"];
			string arg_171_0 = base.Request.Form["buyer_email"];
			string arg_187_0 = base.Request.Form["trade_status"];
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			if (base.Request.Form["trade_status"] == "WAIT_BUYER_PAY")
			{
				DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text);
				if (dataTable.Rows.Count > 0)
				{
					dataTable.Rows[0]["MemLoginID"].ToString();
					string text2 = dataTable.Rows[0]["Guid"].ToString();
					string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
					dataTable.Rows[0]["OrderNumber"].ToString();
					string a = dataTable.Rows[0]["OderStatus"].ToString();
					string text3 = dataTable.Rows[0]["PaymentStatus"].ToString();
					string a2 = dataTable.Rows[0]["ShipmentStatus"].ToString();
					if (!(a == "0") || !(a2 == "0") || !(text3 == "0"))
					{
						shopNum1_OrderInfo_Action.SetWaitBuyerPay("1", "0", "1", text2);
					}
					base.Response.Write("success");
				}
			}
			else if (base.Request.Form["trade_status"] == "WAIT_SELLER_SEND_GOODS")
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
					string strSql = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus from ShopNum1_Orderinfo where tradeid='" + text + "'";
					DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
					if (dataTable.Rows.Count > 0)
					{
						dataTable.Rows[0]["MemLoginID"].ToString();
						string text2 = dataTable.Rows[0]["Guid"].ToString();
						string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
						dataTable.Rows[0]["OrderNumber"].ToString();
						string a = dataTable.Rows[0]["OderStatus"].ToString();
						string text3 = dataTable.Rows[0]["PaymentStatus"].ToString();
						string a2 = dataTable.Rows[0]["ShipmentStatus"].ToString();
						if (Convert.ToInt32(text3) < 1)
						{
							shopNum1_OrderInfo_Action.SetPaymentStatus2(guid, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2), strTrade_no);
							this.OrderOperateLog("支付宝担保交易会员购买商品", "买家已付款", "等待卖家发货", text2);
							string nameById = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
							try
							{
								this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(Common.ReqStr("price")), "支付宝担保交易会员购买商品", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 0);
							}
							catch
							{
							}
							ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
							shopNum1_OrderProduct_Action.UpdateStock(text2);
							File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "订单当前状态：成功", Encoding.UTF8);
							base.Response.Write("success");
						}
					}
				}
			}
			else if (base.Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
			{
				DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text);
				if (dataTable.Rows.Count > 0)
				{
					dataTable.Rows[0]["MemLoginID"].ToString();
					string text2 = dataTable.Rows[0]["Guid"].ToString();
					string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
					dataTable.Rows[0]["OrderNumber"].ToString();
					string a = dataTable.Rows[0]["OderStatus"].ToString();
					string text3 = dataTable.Rows[0]["PaymentStatus"].ToString();
					string a2 = dataTable.Rows[0]["ShipmentStatus"].ToString();
					if (!(a == "2") || !(text3 == "1") || !(a2 == "1"))
					{
						Random random = new Random();
						shopNum1_OrderInfo_Action.SetShipmentStatus1(text2, 2, 1, 1, DateTime.Now, "XT_" + DateTime.Now.ToLongTimeString().Replace("-", "") + random.Next(0, 1000));
					}
					base.Response.Write("success");
				}
			}
			else if (base.Request.Form["trade_status"] == "TRADE_FINISHED")
			{
				base.Response.Write("success");
				File.AppendAllText(base.Server.MapPath("~/log/logx.txt"), "订单当前状态：成功TRADE_FINISHED", Encoding.UTF8);
				string strSql = "Select MemLoginID,Guid,ShouldPayPrice,OrderNumber,OderStatus,PaymentStatus,ShipmentStatus,PayMentMemLoginID,ShopId from ShopNum1_Orderinfo where OrderNumber='" + text + "'";
				DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
				if (dataTable.Rows.Count > 0)
				{
					string text2 = dataTable.Rows[0]["Guid"].ToString();
					Common.UpdateInfo("oderstatus=3,paymentstatus=1,ShipmentStatus=2", "ShopNum1_Orderinfo", " And OrderNumber='" + text + "'");
					this.OrderOperateLog("支付宝担保交易会员购买商品", "买家已付款", "等待卖家发货", text2);
					if (!(ShopSettings.GetValue("MyCommentRankSorce") == string.Empty))
					{
						int.Parse(ShopSettings.GetValue("MyCommentRankSorce"));
					}
					if (!(ShopSettings.GetValue("MyCommentSorce") == string.Empty))
					{
						int.Parse(ShopSettings.GetValue("MyCommentSorce"));
					}
				}
				base.Response.Write("success");
			}
			else
			{
				base.Response.Write("success");
			}
		}
		else
		{
			base.Response.Write("无通知参数");
		}
	}
	protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId)
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
	protected void IsMMS(string strflag, string strGuId)
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
		DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(strGuId);
		IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
		if (orderInfoByGuid.Rows[0]["mobile"] != null && !(orderInfoByGuid.Rows[0]["mobile"].ToString() == ""))
		{
			string text = orderInfoByGuid.Rows[0]["mobile"].ToString();
			string value = ShopSettings.GetValue("Name");
			UpdateOrderStute updateOrderStute = new UpdateOrderStute();
			updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
			updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
			updateOrderStute.OrderStatus = this.OrderStatus(orderInfoByGuid.Rows[0]["OderStatus"]);
			updateOrderStute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			updateOrderStute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			updateOrderStute.ShopName = value;
			string text2 = string.Empty;
			string text3;
			if (strflag == "CancelOrderIsMMS")
			{
				text3 = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
			}
			else
			{
				text3 = "204e827c-a610-4212-836e-709cd59cba83";
			}
			ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
			DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text3 + "'", 0);
			string mMsTitle = string.Empty;
			if (editInfo.Rows.Count > 0)
			{
				text2 = editInfo.Rows[0]["Remark"].ToString();
				mMsTitle = editInfo.Rows[0]["Title"].ToString();
			}
			text2 = text2.Replace("{$Name}", updateOrderStute.Name);
			text2 = text2.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
			text2 = text2.Replace("{$ShopName}", updateOrderStute.ShopName);
			text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
			text2 = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text2));
			string empty = string.Empty;
			SMS sMS = new SMS();
			sMS.Send(text.Trim(), text2, out empty);
			if (empty.IndexOf("发送成功") != -1)
			{
				ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(updateOrderStute.Name, text.Trim(), text2, mMsTitle, 2, text3);
				shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
			}
			else
			{
				ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(updateOrderStute.Name, text.Trim(), text2, mMsTitle, 0, text3);
				shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
			}
		}
	}
	protected void IsEmail(string strflag, string strGuID)
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
		DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(strGuID);
		if (orderInfoByGuid.Rows[0]["Email"] != null && !(orderInfoByGuid.Rows[0]["Email"].ToString() == ""))
		{
			string email = orderInfoByGuid.Rows[0]["Email"].ToString();
			string value = ShopSettings.GetValue("Name");
			UpdateOrderStute updateOrderStute = new UpdateOrderStute();
			string memLoginID = updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
			updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
			updateOrderStute.OrderStatus = this.OrderStatus(orderInfoByGuid.Rows[0]["OderStatus"]);
			updateOrderStute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			updateOrderStute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			updateOrderStute.ShopName = value;
			string text = string.Empty;
			string emailTitle = string.Empty;
			string text2;
			if (strflag == "CancelOrderIsEmail")
			{
				text2 = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
			}
			else
			{
				text2 = "204e827c-a610-4212-836e-709cd59cba83";
			}
			ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
			DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
			if (editInfo.Rows.Count > 0)
			{
				text = editInfo.Rows[0]["Remark"].ToString();
				emailTitle = editInfo.Rows[0]["Title"].ToString();
			}
			text = text.Replace("{$Name}", updateOrderStute.Name);
			text = text.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
			text = text.Replace("{$ShopName}", updateOrderStute.ShopName);
			text = text.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
			string emailBody = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text));
			SendEmail sendEmail = new SendEmail();
			sendEmail.Emails(email, memLoginID, emailTitle, text2, emailBody);
		}
	}
	protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle, int state, string mmsGuid)
	{
		return new ShopNum1_MMSGroupSend
		{
			Guid = Guid.NewGuid(),
			MMSTitle = MMsTitle,
			CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
			MMSGuid = new Guid(mmsGuid),
			SendObjectMMS = strContent,
			SendObject = memLoginID + "-" + mobile,
			State = state
		};
	}
	public string OrderStatus(object object_0)
	{
		string text = object_0.ToString();
		string text2 = text;
		string result;
		switch (text2)
		{
		case "0":
			result = "等待买家付款";
			return result;
		case "1":
			result = "等待卖家发货";
			return result;
		case "2":
			result = "等待买家确认收货";
			return result;
		case "3":
			result = "交易成功";
			return result;
		case "4":
			result = "系统关闭订单";
			return result;
		case "5":
			result = "卖家关闭订单";
			return result;
		case "6":
			result = "买家关闭订单";
			return result;
		}
		result = "非法状态";
		return result;
	}
	public ArrayList GetRequestPost()
	{
		ArrayList arrayList = new ArrayList();
		NameValueCollection form = base.Request.Form;
		string[] allKeys = form.AllKeys;
		for (int i = 0; i < allKeys.Length; i++)
		{
			arrayList.Add(allKeys[i] + "=" + base.Request.Form[allKeys[i]]);
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
