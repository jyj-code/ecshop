using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_Help_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Localize Localize1;
	protected System.Web.UI.WebControls.DropDownList DropDownListType;
	protected Localize Localize2;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridView;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField HiddenFieldAgentLoginID;
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
			this.HelpTypeBind();
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridView.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Help_Operate.aspx");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
		int num = shopNum1_Help_Action.Delete(this.CheckGuid.Value);
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
		base.Response.Redirect("Help_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void HelpTypeBind()
	{
		ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
		DataTable list = shopNum1_HelpType_Action.GetList();
		this.DropDownListType.Items.Add(new ListItem("-全部-", "-1"));
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListType.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Guid"].ToString()));
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_Help_Action.Delete("'" + commandArgument + "'");
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
