using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class PayReturn_ABCPay_MerchantFailure : Page, IRequiresSessionState
{
	protected Label lblReturnCode;
	protected Label lblErrorMessage;
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
		this.lblReturnCode.Text = ((base.Request["ReturnCode"] == null) ? "" : base.Request["ReturnCode"].ToString());
		this.lblErrorMessage.Text = ((base.Request["ErrorMessage"] == null) ? "" : base.Request["ErrorMessage"].ToString());
	}
}
