using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Payment;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class merchant_url : Page, IRequiresSessionState
{
	protected Label lbOrderID;
	protected Label lbMoney;
	protected Label lbDate;
	protected Label lbFlag;
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
		string text = base.Request.Params["MerchantID"];
		string text2 = base.Request.Params["TransID"];
		string text3 = base.Request.Params["Result"];
		string text4 = base.Request.Params["resultDesc"];
		string text5 = base.Request.Params["factMoney"];
		string text6 = base.Request.Params["additionalInfo"];
		string text7 = base.Request.Params["SuccTime"];
		string text8 = base.Request.Params["Md5Sign"].ToLower();
		ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
		DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Baofoo.aspx");
		if (paymentKey == null || paymentKey.Rows.Count <= 0)
		{
			this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
		}
		string text9 = paymentKey.Rows[0]["SecretKey"].ToString();
		string strToBeEncrypt = string.Concat(new string[]
		{
			text,
			text2,
			text3,
			text4,
			text5,
			text6,
			text7,
			text9
		});
		if (text8.ToLower() == Baofoo.Md5Encrypt(strToBeEncrypt).ToLower())
		{
			this.lbMoney.Text = ((double)int.Parse(text5) * 0.01).ToString() + " 元";
			this.lbDate.Text = text7;
			this.lbFlag.Text = Baofoo.GetErrorInfo(text3, text4);
			this.lbOrderID.Text = text2;
			base.Response.Redirect("/main/Member/m_index.aspx");
		}
		else
		{
			base.Response.Write("校验失败");
		}
	}
}
