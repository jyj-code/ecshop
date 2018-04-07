using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Service_ServiceAdmin_ServiceMessageBoard_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected Localize Localize1;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxMemLoginID;
	protected Localize Localize4;
	protected System.Web.UI.WebControls.TextBox TextBoxSendTime1;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxSendTime1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSendTime2;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxSendTime2;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
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
			this.method_5();
		}
	}
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonEdite_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopNum1MessageBoard_Operate.aspx?Guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_MessageBoard_Action shopNum1_MessageBoard_Action = (ShopNum1_MessageBoard_Action)LogicFactory.CreateShopNum1_MessageBoard_Action();
		int num = shopNum1_MessageBoard_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			this.method_5();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_MessageBoard_Action shopNum1_MessageBoard_Action = (ShopNum1_MessageBoard_Action)LogicFactory.CreateShopNum1_MessageBoard_Action();
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		int num = shopNum1_MessageBoard_Action.Delete(guids);
		if (num > 0)
		{
			this.method_5();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
}
