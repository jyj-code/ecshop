using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_HelpType_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Localize LocalizeName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField HiddenFieldAgentLoginID;
	protected HiddenField CheckGuid;
	protected Num1GridView China315GridViewShow;
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
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.China315GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("HelpType_Operate.aspx");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
		int num = shopNum1_HelpType_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			this.BindGrid();
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("HelpType_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
		int num = shopNum1_HelpType_Action.Delete("'" + commandArgument + "'");
		if (num > 0)
		{
			this.BindGrid();
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
