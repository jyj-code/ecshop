using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using tenpay;
public class Tenpayreturn_url : Page, IRequiresSessionState
{
	protected HtmlForm Form1;
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
	private void method_0(object sender, EventArgs e)
	{
		string key = string.Empty;
		ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
		DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("TenpayMed.aspx");
		if (paymentKey != null && paymentKey.Rows.Count > 0)
		{
			key = paymentKey.Rows[0]["SecretKey"].ToString();
		}
		MediPayResponse mediPayResponse = new MediPayResponse(this.Context);
		mediPayResponse.setKey(key);
		if (mediPayResponse.isTenpaySign())
		{
			string parameter = mediPayResponse.getParameter("retcode");
			string parameter2 = mediPayResponse.getParameter("status");
			string parameter3 = mediPayResponse.getParameter("mch_vno");
			if ("0".Equals(parameter))
			{
				switch (int.Parse(parameter2))
				{
				case 3:
				{
					ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
					DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(parameter3);
					string text = dataTable.Rows[0]["MemLoginID"].ToString();
					string guid = dataTable.Rows[0]["Guid"].ToString();
					string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
					dataTable.Rows[0]["OrderNumber"].ToString();
					shopNum1_OrderInfo_Action.SetPaymentStatus2(guid, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value));
					if (this.CheckMember(text) == 1)
					{
						ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
						shopNum1_Member_Action.UpdateCostMoney(text, Convert.ToDecimal(value));
					}
					break;
				}
				}
				mediPayResponse.doShow();
			}
			else
			{
				base.Response.Write("支付失败");
			}
		}
		else
		{
			base.Response.Write("认证签名失败");
		}
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
