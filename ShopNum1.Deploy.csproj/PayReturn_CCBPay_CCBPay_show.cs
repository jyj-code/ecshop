using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class PayReturn_CCBPay_CCBPay_show : Page, IRequiresSessionState
{
	protected Label LabelTime;
	protected HtmlForm form1;
	protected string strOrderinfo = string.Empty;
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
			this.LabelTime.Text = "订单于：" + DateTime.Now.ToString() + "支付成功！";
			if (this.Session["orderNum"] != null)
			{
				this.strOrderinfo = "商城订单号：<span class=\"span1\">" + this.Session["orderNum"].ToString() + "</span>";
				this.Session.Remove("orderNum");
			}
		}
	}
}
