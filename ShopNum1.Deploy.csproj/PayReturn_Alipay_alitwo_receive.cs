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
public class PayReturn_Alipay_alitwo_receive : Page, IRequiresSessionState
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
		DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay2.aspx");
		if (paymentKey.Rows.Count > 0)
		{
			partner = paymentKey.Rows[0]["MerchantCode"].ToString();
			key = paymentKey.Rows[0]["SecretKey"].ToString();
		}
		string input_charset = "utf-8";
		string sign_type = "MD5";
		string transport = "http";
		if (requestPost.Count > 0)
		{
			AlipayNotify alipayNotify = new AlipayNotify(requestPost, base.Request.QueryString["notify_id"], partner, key, input_charset, sign_type, transport);
			string responseTxt = alipayNotify.ResponseTxt;
			string a = base.Request.QueryString["sign"];
			string mysign = alipayNotify.Mysign;
			if (responseTxt == "true" && a == mysign)
			{
				string strTrade_no = base.Request.QueryString["trade_no"];
				string text = base.Request.QueryString["out_trade_no"];
				string value = base.Request.QueryString["price"];
				string arg_169_0 = base.Request.QueryString["subject"];
				string arg_17F_0 = base.Request.QueryString["body"];
				string arg_195_0 = base.Request.QueryString["buyer_email"];
				string arg_1AB_0 = base.Request.QueryString["trade_status"];
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
				DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text);
				int num = int.Parse(dataTable.Rows[0]["OderStatus"].ToString());
				if (base.Request.QueryString["trade_status"] == "WAIT_BUYER_PAY")
				{
					if (num != 0)
					{
					}
					base.Response.Redirect("/main/Member/m_index.aspx?go=");
				}
				else if (base.Request.QueryString["trade_status"] == "WAIT_SELLER_SEND_GOODS")
				{
					if (num != 1 && num != 0)
					{
					}
					string text2 = dataTable.Rows[0]["MemLoginID"].ToString();
					dataTable.Rows[0]["Guid"].ToString();
					string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
					dataTable.Rows[0]["OrderNumber"].ToString();
					shopNum1_OrderInfo_Action.SetPaymentStatus2(text, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2), strTrade_no);
					if (this.CheckMember(text2) == 1)
					{
						ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
						shopNum1_Member_Action.UpdateCostMoney(text2, Convert.ToDecimal(value));
					}
					base.Response.Redirect("/main/Member/m_index.aspx");
				}
				else if (base.Request.QueryString["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")
				{
					if (num == 2)
					{
						string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
						dataTable.Rows[0]["Guid"].ToString();
						shopNum1_OrderInfo_Action.SetPaymentStatus2(text, 2, 2, 1, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2));
					}
					base.Response.Redirect("/main/Member/m_index.aspx?ok=");
				}
				else if (base.Request.QueryString["trade_status"] == "TRADE_FINISHED")
				{
					if (num != 3 && num >= 2)
					{
					}
					string text2 = dataTable.Rows[0]["MemLoginID"].ToString();
					dataTable.Rows[0]["Guid"].ToString();
					string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
					dataTable.Rows[0]["OrderNumber"].ToString();
					shopNum1_OrderInfo_Action.SetPaymentStatus2(text, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2));
					if (this.CheckMember(text2) == 1)
					{
						ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
						shopNum1_Member_Action.UpdateCostMoney(text2, Convert.ToDecimal(value));
					}
				}
				else
				{
					base.Response.Redirect("/main/Member/m_index.aspx?error=");
				}
			}
			else
			{
				base.Response.Write("验证失败");
			}
		}
		else
		{
			base.Response.Write("无通知参数");
		}
	}
	public ArrayList GetRequestPost()
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
