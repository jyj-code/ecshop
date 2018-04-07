using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
public class PayReturn_bankonline_BankReceive : Page, IRequiresSessionState
{
	protected HtmlForm form1;
	protected string v_oid;
	protected string v_pstatus;
	protected string v_pstring;
	protected string v_pmode;
	protected string v_amount;
	protected string v_moneytype;
	protected string remark1;
	protected string remark2;
	protected string v_md5str;
	protected string status_msg;
	protected string string_0;
	public bool IsDoMain;
	public string AgentHost = string.Empty;
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
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		string text = string.Empty;
		this.v_oid = base.Request["v_oid"];
		ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
		DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Send.aspx");
		text = paymentKey.Rows[0]["SecretKey"].ToString();
		this.v_pstatus = base.Request["v_pstatus"];
		this.v_pstring = base.Request["v_pstring"];
		this.v_pmode = base.Request["v_pmode"];
		this.v_md5str = base.Request["v_md5str"];
		this.v_amount = base.Request["v_amount"];
		this.v_moneytype = base.Request["v_moneytype"];
		this.remark1 = base.Request["remark1"];
		this.remark2 = base.Request["remark2"];
		string text2 = string.Concat(new string[]
		{
			this.v_oid,
			this.v_pstatus,
			this.v_amount,
			this.v_moneytype,
			text
		});
		text2 = FormsAuthentication.HashPasswordForStoringInConfigFile(text2, "md5").ToUpper();
		if (text2 == this.v_md5str)
		{
			if (this.v_pstatus.Equals("20"))
			{
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
				DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(this.v_oid);
				if (dataTable.Rows.Count > 0)
				{
					int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
					if (num == 1 || num == 0)
					{
						string text3 = dataTable.Rows[0]["MemLoginID"].ToString();
						string strOrderGuId = dataTable.Rows[0]["Guid"].ToString();
						string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
						string text4 = dataTable.Rows[0]["OrderNumber"].ToString();
						shopNum1_OrderInfo_Action.SetPaymentStatus2(text4, 1, 1, 0, DateTime.Now, Convert.ToDecimal(this.v_amount), Convert.ToDecimal(value));
						ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
						shopNum1_OrderProduct_Action.UpdateStock(strOrderGuId);
						if (this.CheckMember(text3) == 1)
						{
							shopNum1_Member_Action.UpdateCostMoney(text3, Convert.ToDecimal(this.v_amount));
						}
						base.Response.Redirect("/main/Member/m_index.aspx?order=" + text4);
					}
					else
					{
						File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "订单当前状态：" + this.v_pstatus.ToString(), Encoding.UTF8);
					}
				}
				else if (this.v_oid.IndexOf("C") != -1)
				{
					ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
					string nameById = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + this.method_0() + "'");
					this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(this.v_amount), "网银会员充值", this.method_0(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
					shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, this.v_oid);
					base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
				}
			}
			else
			{
				File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "返回状态：" + this.v_pstatus.ToString(), Encoding.UTF8);
			}
		}
		else
		{
			this.status_msg = "校验失败，数据可疑";
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
