using AjaxControlToolkit;
using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopSales : PageBase, IRequiresSessionState
{
	protected const string ShopClick_Report = "ShopSales_Report.aspx";
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox txtshophost;
	protected System.Web.UI.WebControls.TextBox txtshopname;
	protected System.Web.UI.WebControls.TextBox TextBoxStartDate;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndDate;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonReport;
	protected LinkButton ButtonHtml;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
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
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Concat(new string[]
		{
			"ShopSales_Report.aspx?Type=xls&shophost=",
			this.txtshophost.Text,
			"&shopname=",
			this.txtshopname.Text.ToString(),
			"&DispatchTime1=",
			this.TextBoxStartDate.Text.ToString(),
			"&DispatchTime2=",
			this.TextBoxEndDate.Text.ToString()
		}));
	}
	protected void ButtonHtml_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Concat(new string[]
		{
			"ShopSales_Report.aspx?Type=html&shophost=",
			this.txtshophost.Text.ToString(),
			"&shopname=",
			this.txtshopname.Text.ToString(),
			"&DispatchTime1=",
			this.TextBoxStartDate.Text.ToString(),
			"&DispatchTime2=",
			this.TextBoxEndDate.Text.ToString()
		}));
	}
	protected void Num1GridViewShow_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}
