using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_SurveyTheme_Manage : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected System.Web.UI.WebControls.TextBox textBoxSurveyTitle;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected System.Web.UI.WebControls.Button ButtonAddOption;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView num1GridiewShow;
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
			this.BindGrid();
		}
	}
	protected void btnQuery_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindGrid()
	{
		this.num1GridiewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("SurveyTheme_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SurveyTheme_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_SurveyTheme_Action shopNum1_SurveyTheme_Action = (ShopNum1_SurveyTheme_Action)LogicFactory.CreateShopNum1_SurveyTheme_Action();
		int num = shopNum1_SurveyTheme_Action.Delete(this.CheckGuid.Value.ToString());
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
	protected void ButtonAddOption_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SurveyOption_Manage.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_SurveyTheme_Action shopNum1_SurveyTheme_Action = (ShopNum1_SurveyTheme_Action)LogicFactory.CreateShopNum1_SurveyTheme_Action();
		int num = shopNum1_SurveyTheme_Action.Delete("'" + commandArgument + "'");
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
