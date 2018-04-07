using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopActualAuthentication_Audit : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxshopID;
	protected System.Web.UI.WebControls.TextBox TextBoxshopName;
	protected System.Web.UI.WebControls.TextBox TextBoxlegalPerson;
	protected System.Web.UI.WebControls.TextBox TextBoxregistrationNum;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Num1GridView Num1GridViewShow;
	protected System.Web.UI.WebControls.Button ButtonSearchShop;
	protected System.Web.UI.WebControls.Button ButtonOperate;
	protected System.Web.UI.WebControls.Button ButtonOperate1;
	protected MessageShow MessageShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
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
		if (!base.IsPostBack)
		{
			this.method_5();
		}
	}
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	protected void ButtonSearchShop_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonOperate1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopActualAuthentication_Detai.aspx?guid=" + this.CheckGuid.Value);
	}
}
