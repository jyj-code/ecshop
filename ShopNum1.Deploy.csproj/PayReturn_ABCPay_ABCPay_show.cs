using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class PayReturn_ABCPay_ABCPay_show : Page, IRequiresSessionState
{
	public string strOrderinfo = string.Empty;
	protected Label LabelTime;
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
		if (!base.IsPostBack)
		{
			string text = string.Format("{0}", base.Request["_result"]);
			string str = string.Format("{0}", base.Request["orderNO"]);
			string text2 = string.Empty;
			if (text.Equals("True"))
			{
				text2 = string.Format("尊敬的客户：您好，订单于：{0}", DateTime.Now.ToString() + "支付成功！");
			}
			else
			{
				text2 = string.Format("尊敬的客户：您好，订单于：{0}", DateTime.Now.ToString() + "支付失败！");
			}
			this.LabelTime.Text = text2;
			this.strOrderinfo = "商城订单号：<span class=\"span1\">" + str + "</span>";
		}
	}
}
