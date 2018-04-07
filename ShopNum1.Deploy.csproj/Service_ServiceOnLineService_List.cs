using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Service_ServiceOnLineService_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTtitle;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldSubstationID;
	protected Num1GridView Num1GridViewShow;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!base.IsPostBack)
		{
			this.method_5();
		}
	}
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	public string ChangeIsShow(string strIsShow)
	{
		string result;
		if (strIsShow == "0")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else if (strIsShow == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("ServiceOnLineService_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdite_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ServiceOnLineService_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_OnLineService_Action shopNum1_OnLineService_Action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
		int num = shopNum1_OnLineService_Action.Delete(this.CheckGuid.Value.ToString());
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
		ShopNum1_OnLineService_Action shopNum1_OnLineService_Action = (ShopNum1_OnLineService_Action)LogicFactory.CreateShopNum1_OnLineService_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_OnLineService_Action.Delete("'" + commandArgument + "'");
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
