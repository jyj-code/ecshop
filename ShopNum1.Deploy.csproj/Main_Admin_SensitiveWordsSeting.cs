using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_SensitiveWordsSeting : PageBase, IRequiresSessionState
{
	protected Label LabelName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonInsert;
	protected LinkButton ButtonUpdata;
	protected LinkButton ButtonDel;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
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
			this.BindData();
		}
	}
	public void BindData()
	{
		this.Num1GridViewShow.DataBind();
	}
	public void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindData();
	}
	protected void ButtonInsert_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("SensitiveWordsSeting_Operate.aspx?ID=" + this.CheckGuid.Value);
	}
	protected void ButtonUpdata_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SensitiveWordsSeting_Operate.aspx?ID=" + this.CheckGuid.Value + "&Type=1");
	}
	protected void ButtonDel_Click(object sender, EventArgs e)
	{
		ShopNum1_BadWord_Action shopNum1_BadWord_Action = (ShopNum1_BadWord_Action)LogicFactory.CreateShopNum1_BadWord_Action();
		int num = shopNum1_BadWord_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			this.BindData();
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
		ShopNum1_BadWord_Action shopNum1_BadWord_Action = (ShopNum1_BadWord_Action)LogicFactory.CreateShopNum1_BadWord_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_BadWord_Action.Delete("'" + commandArgument + "'");
		if (num > 0)
		{
			this.BindData();
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
