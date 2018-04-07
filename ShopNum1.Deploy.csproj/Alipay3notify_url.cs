using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Payment;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
public class Alipay3notify_url : Page, IRequiresSessionState
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
			Alipay3Notify alipay3Notify = new Alipay3Notify(requestPost, base.Request.Form["notify_id"], partner, string_, input_charset, sign_type, transport);
			string responseTxt = alipay3Notify.ResponseTxt;
			string a = base.Request.Form["sign"];
			string mysign = alipay3Notify.Mysign;
			if (responseTxt == "true" && a == mysign)
			{
				string arg_124_0 = base.Request.Form["trade_no"];
				string orderNumber = base.Request.Form["out_trade_no"];
				string value = base.Request.Form["total_fee"];
				string arg_168_0 = base.Request.Form["subject"];
				string arg_17E_0 = base.Request.Form["body"];
				string arg_194_0 = base.Request.Form["buyer_email"];
				string arg_1AA_0 = base.Request.Form["trade_status"];
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
				DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(orderNumber);
				int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
				if (base.Request.Form["trade_status"] == "TRADE_FINISHED" || base.Request.Form["trade_status"] == "TRADE_SUCCESS")
				{
					if (num < 1)
					{
						string text = dataTable.Rows[0]["MemLoginID"].ToString();
						string guid = dataTable.Rows[0]["Guid"].ToString();
						string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
						dataTable.Rows[0]["OrderNumber"].ToString();
						shopNum1_OrderInfo_Action.SetPaymentStatus2(guid, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value2));
						if (this.CheckMember(text) == 1)
						{
							ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
							shopNum1_Member_Action.UpdateCostMoney(text, Convert.ToDecimal(value));
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
				base.Response.Write("fail");
			}
		}
		else
		{
			base.Response.Write("无通知参数");
		}
	}
	public SortedDictionary<string, string> GetRequestPost()
	{
		SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
		NameValueCollection form = base.Request.Form;
		string[] allKeys = form.AllKeys;
		for (int i = 0; i < allKeys.Length; i++)
		{
			sortedDictionary.Add(allKeys[i], base.Request.Form[allKeys[i]]);
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
