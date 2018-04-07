using ETSClient.com.allinpay.ets.client;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Payment;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
public class PayReturn_TLPay_TL_Recive : Page, IRequiresSessionState
{
	protected HtmlForm form1;
	[CompilerGenerated]
	private TL_recive tl_recive_0;
	[CompilerGenerated]
	private PaymentResult paymentResult_0;
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
	private TL_recive TL_recive_0
	{
		get;
		set;
	}
	private PaymentResult paymentResult
	{
		get;
		set;
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.method_0();
			this.method_2();
		}
	}
	private void method_0()
	{
		this.TL_recive_0 = new TL_recive();
		this.TL_recive_0.merchantID = base.Request["merchantId"];
		this.TL_recive_0.version = base.Request["version"];
		this.TL_recive_0.language = base.Request["language"];
		this.TL_recive_0.signType = base.Request["signType"];
		this.TL_recive_0.payType = base.Request["payType"];
		this.TL_recive_0.paymentOrderId = base.Request["paymentOrderId"];
		this.TL_recive_0.orderNo = base.Request["orderNo"];
		this.TL_recive_0.orderDatetime = base.Request["orderDatetime"];
		this.TL_recive_0.orderAmount = base.Request["orderAmount"];
		this.TL_recive_0.payDatetime = base.Request["payDatetime"];
		this.TL_recive_0.payAmount = base.Request["payAmount"];
		this.TL_recive_0.payResult = base.Request["payResult"];
		this.TL_recive_0.returnDatetime = base.Request["returnDatetime"];
		this.TL_recive_0.issuerId = base.Request["issuerId"];
		this.TL_recive_0.errorCode = base.Request["errorCode"];
		this.TL_recive_0.signMsg = base.Request["signMsg"];
		this.TL_recive_0.key=base.Request["ext1"];
	}
	private string method_1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(this.TL_recive_0.merchantID))
		{
			stringBuilder.AppendFormat("merchantId={0}&", this.TL_recive_0.merchantID);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.version))
		{
			stringBuilder.AppendFormat("version={0}&", this.TL_recive_0.version);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.signType))
		{
			stringBuilder.AppendFormat("signType={0}&", this.TL_recive_0.signType);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.payType))
		{
			stringBuilder.AppendFormat("payType={0}&", this.TL_recive_0.payType);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.paymentOrderId))
		{
			stringBuilder.AppendFormat("paymentOrderId={0}&", this.TL_recive_0.paymentOrderId);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.orderNo))
		{
			stringBuilder.AppendFormat("orderNo={0}&", this.TL_recive_0.orderNo);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.orderDatetime))
		{
			stringBuilder.AppendFormat("orderDatetime={0}&", this.TL_recive_0.orderDatetime);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.orderAmount))
		{
			stringBuilder.AppendFormat("orderAmount={0}&", this.TL_recive_0.orderAmount);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.payDatetime))
		{
			stringBuilder.AppendFormat("payDatetime={0}&", this.TL_recive_0.payDatetime);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.payAmount))
		{
			stringBuilder.AppendFormat("payAmount={0}&", this.TL_recive_0.payAmount);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.key))
		{
			stringBuilder.AppendFormat("ext1={0}&", this.TL_recive_0.key);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.payResult))
		{
			stringBuilder.AppendFormat("payResult={0}&", this.TL_recive_0.payResult);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.errorCode))
		{
			stringBuilder.AppendFormat("errorCode={0}&", this.TL_recive_0.errorCode);
		}
		if (!string.IsNullOrEmpty(this.TL_recive_0.returnDatetime))
		{
			stringBuilder.AppendFormat("returnDatetime={0}&", this.TL_recive_0.returnDatetime);
		}
		stringBuilder.Append("key=" + this.TL_recive_0.key);
		string text = stringBuilder.ToString();
		MD5 mD = new MD5CryptoServiceProvider();
		byte[] bytes = mD.ComputeHash(Encoding.Default.GetBytes(text), 0, text.Length);
		return this.byteToHexStr(bytes);
	}
	private void method_2()
	{
		if (this.TL_recive_0.signType == "0")
		{
			if (this.method_1() == this.TL_recive_0.signMsg)
			{
				if (this.TL_recive_0.payResult == "1")
				{
					this.method_3();
				}
				else
				{
					this.Page.Response.Write(string.Concat(new string[]
					{
						"<script>alert('支付失败,错误码:",
						this.TL_recive_0.errorCode,
						"!请重试!');window.location='",
						ShopSettings.GetValue("Domain"),
						"';</script>"
					}));
				}
			}
		}
		else if (this.TL_recive_0.signType == "1")
		{
			this.method_4();
			this.paymentResult.setCertPath(base.Server.MapPath("~/PayReturn/TLPay/cert/TLCert.cer"));
			if (this.paymentResult.verify())
			{
				this.method_3();
			}
			else
			{
				this.Page.Response.Write(string.Concat(new string[]
				{
					"<script>alert('支付失败,错误码:",
					this.TL_recive_0.errorCode,
					"!请重试!');window.location='",
					ShopSettings.GetValue("Domain"),
					"';</script>"
				}));
			}
		}
		else
		{
			base.Response.End();
		}
	}
	private void method_3()
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
		DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(this.TL_recive_0.orderNo);
		if (dataTable.Rows.Count > 0)
		{
			string memLoginID = dataTable.Rows[0]["MemLoginID"].ToString();
			string text = dataTable.Rows[0]["Guid"].ToString();
			string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
			string value2 = dataTable.Rows[0]["OderStatus"].ToString();
			if (Convert.ToInt32(value2) == 0)
			{
				shopNum1_OrderInfo_Action.SetPaymentStatus2(this.TL_recive_0.orderNo, 1, 1, 0, DateTime.Now, Convert.ToDecimal(this.TL_recive_0.payAmount), Convert.ToDecimal(value));
				ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
				shopNum1_OrderProduct_Action.UpdateStock(text);
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				shopNum1_Member_Action.UpdateCostMoney(memLoginID, Convert.ToDecimal(this.TL_recive_0.payAmount));
				this.OrderOperateLog("通联支付", "买家已付款", "等待卖家发货", text);
				base.Response.Redirect("/main/Member/m_index.aspx?order=" + this.TL_recive_0.orderNo);
			}
		}
	}
	private void method_4()
	{
		this.paymentResult = new PaymentResult();
		this.paymentResult.setMerchantId(this.TL_recive_0.merchantID);
		this.paymentResult.setVersion(this.TL_recive_0.version);
		this.paymentResult.setLanguage(this.TL_recive_0.language);
		this.paymentResult.setSignType(this.TL_recive_0.signType);
		this.paymentResult.setPayType(this.TL_recive_0.payType);
		this.paymentResult.setIssuerId(this.TL_recive_0.issuerId);
		this.paymentResult.setPaymentOrderId(this.TL_recive_0.paymentOrderId);
		this.paymentResult.setOrderNo(this.TL_recive_0.orderNo);
		this.paymentResult.setOrderDatetime(this.TL_recive_0.orderDatetime);
		this.paymentResult.setOrderAmount(this.TL_recive_0.orderAmount);
		if (!string.IsNullOrEmpty(this.TL_recive_0.key))
		{
			this.paymentResult.setKey(this.TL_recive_0.key);
			this.paymentResult.setExt1(this.TL_recive_0.key);
		}
		this.paymentResult.setPayDatetime(this.TL_recive_0.payDatetime);
		this.paymentResult.setPayAmount(this.TL_recive_0.payAmount);
		this.paymentResult.setPayResult(this.TL_recive_0.payResult);
		this.paymentResult.setErrorCode(this.TL_recive_0.errorCode);
		this.paymentResult.setReturnDatetime(this.TL_recive_0.returnDatetime);
		this.paymentResult.setSignMsg(this.TL_recive_0.signMsg);
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
		shopNum1_OrderOperateLog.CreateUser = this.method_5();
		ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
		shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
	}
	private string method_5()
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
	public string byteToHexStr(byte[] bytes)
	{
		string text = "";
		if (bytes != null)
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				text += bytes[i].ToString("X2");
			}
		}
		return text;
	}
}
