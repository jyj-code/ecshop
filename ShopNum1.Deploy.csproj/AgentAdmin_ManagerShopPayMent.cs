using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ManagerShopPayMent : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	protected Label LabelPageTitle;
	protected RadioButtonList RadioButtonListShopPayMent;
	protected Button ButtonUpdata;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField CheckGuid;
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
			this.CheckGuid.Value = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"]);
			ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
			string shopPayMentByGuid = shopNum1_Payment_Action.GetShopPayMentByGuid(this.CheckGuid.Value.Replace("'", ""));
			this.RadioButtonListShopPayMent.SelectedValue = shopPayMentByGuid;
		}
	}
	protected void ButtonUpdata_Click(object sender, EventArgs e)
	{
		ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
		int num = shopNum1_Payment_Action.UpdataShopPayMentByGuid(this.CheckGuid.Value.Replace("'", ""), this.RadioButtonListShopPayMent.SelectedValue);
		if (num > 0)
		{
			base.Response.Redirect("ShopInfoList_Manage.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopInfoList_Manage.aspx");
	}
}
