using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_PaymentStatistics_List : PageBase, IRequiresSessionState
{
	protected const string PaymentStatistics_Report = "PaymentStatistics_Report.aspx";
	protected ScriptManager ScriptManager1;
	protected LinkButton ButtonReport;
	protected LinkButton ButtonHtml;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HtmlForm form1;
	public static int int_0 = 0;
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
		Admin_PaymentStatistics_List.int_0 = 1;
		if (!this.Page.IsPostBack)
		{
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PaymentStatistics_Report.aspx?Type=xls");
	}
	protected void ButtonHtml_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PaymentStatistics_Report.aspx?Type=html");
	}
}
