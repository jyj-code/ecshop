using com.yeepay;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
public class Callback : Page, IRequiresSessionState
{
	protected HtmlForm form1;
	private static string string_0;
	private static string string_1;
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
		if (!base.IsPostBack)
		{
			string nameById = Common.GetNameById("MerchantCode", "ShopNum1_Payment", "  AND  PaymentType='Yeepay.aspx'");
			string nameById2 = Common.GetNameById("SecretKey", "ShopNum1_Payment", "  AND  PaymentType='Yeepay.aspx'");
			Callback.string_0 = nameById;
			Callback.string_1 = nameById2;
			BuyCallbackResult buyCallbackResult = Buy.VerifyCallback(Callback.string_0, Callback.string_1, FormatQueryString.GetQueryString("r0_Cmd"), FormatQueryString.GetQueryString("r1_Code"), FormatQueryString.GetQueryString("r2_TrxId"), FormatQueryString.GetQueryString("r3_Amt"), FormatQueryString.GetQueryString("r4_Cur"), FormatQueryString.GetQueryString("r5_Pid"), FormatQueryString.GetQueryString("r6_Order"), FormatQueryString.GetQueryString("r7_Uid"), FormatQueryString.GetQueryString("r8_MP"), FormatQueryString.GetQueryString("r9_BType"), FormatQueryString.GetQueryString("rp_PayDate"), FormatQueryString.GetQueryString("hmac"));
			if (string.IsNullOrEmpty(buyCallbackResult.ErrMsg))
			{
				if (buyCallbackResult.R1_Code == "1")
				{
					if (buyCallbackResult.R9_BType == "1")
					{
						if (buyCallbackResult.R5_Pid.StartsWith("C"))
						{
							ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
							string nameById3 = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
							this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById3), Convert.ToDecimal(buyCallbackResult.R3_Amt), "易宝(YeePay)会员充值", this.method_0(), DateTime.Now.ToLocalTime(), 1);
							shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, buyCallbackResult.R5_Pid);
							base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayRecharge.aspx?type=1");
						}
						else
						{
							ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
							DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(buyCallbackResult.R6_Order);
							string text = dataTable.Rows[0]["MemLoginID"].ToString();
							string guid = dataTable.Rows[0]["Guid"].ToString();
							string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
							dataTable.Rows[0]["OrderNumber"].ToString();
							shopNum1_OrderInfo_Action.SetPaymentStatus2(guid, 1, 1, 0, DateTime.Now, Convert.ToDecimal(buyCallbackResult.R3_Amt), Convert.ToDecimal(value));
							if (this.CheckMember(text) == 1)
							{
								ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
								shopNum1_Member_Action.UpdateCostMoney(text, Convert.ToDecimal(buyCallbackResult.R3_Amt));
							}
							base.Response.Write(string.Concat(new string[]
							{
								"支付成功!<br>商品ID:",
								buyCallbackResult.R5_Pid,
								"<br>商户订单号:",
								buyCallbackResult.R6_Order,
								"<br>支付金额:",
								buyCallbackResult.R3_Amt,
								"<br>易宝支付交易流水号:",
								buyCallbackResult.R2_TrxId,
								"<BR>"
							}));
						}
					}
					else if (buyCallbackResult.R9_BType == "2")
					{
						base.Response.Write("SUCCESS");
					}
					else if (buyCallbackResult.R9_BType == "3")
					{
						base.Response.Write("SUCCESS");
					}
				}
				else
				{
					base.Response.Write("支付失败!");
				}
			}
			else
			{
				base.Response.Write("交易签名无效!");
			}
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
