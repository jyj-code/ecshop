using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Service_ServiceMessageBoard_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Localize LocalizeMemLoginID;
	protected Label LabelMemLoginID;
	protected Label Label2;
	protected Localize LocalizeSendTime;
	protected Label LabelSendTime;
	protected Localize LocalizeContent;
	protected TextBox TextBoxContent;
	protected HiddenField hiddenFieldGuid;
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
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.method_5();
			}
		}
	}
	private void method_5()
	{
		ShopNum1_MessageBoard_Action shopNum1_MessageBoard_Action = (ShopNum1_MessageBoard_Action)LogicFactory.CreateShopNum1_MessageBoard_Action();
		DataTable dataTable = shopNum1_MessageBoard_Action.Search(this.hiddenFieldGuid.Value);
		this.LabelMemLoginID.Text = ((string.Format("{0}", dataTable.Rows[0]["MemLoginID"]) == string.Empty) ? "匿名" : dataTable.Rows[0]["MemLoginID"].ToString());
		this.LabelSendTime.Text = dataTable.Rows[0]["SendTime"].ToString();
		this.Label2.Text = dataTable.Rows[0]["ReplyUser"].ToString();
		this.TextBoxContent.Text = dataTable.Rows[0]["Content"].ToString();
	}
}
