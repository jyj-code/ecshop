using AjaxControlToolkit;
using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SellOrder : PageBase, IRequiresSessionState
{
	protected const string SellOrder_Report = "SellOrder_Report.aspx";
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.TextBox txtPName;
	protected System.Web.UI.WebControls.TextBox txtSName;
	protected System.Web.UI.WebControls.TextBox TextBoxSDispatchTime1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender imgCalendarStartTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxSDispatchTime2;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonReport;
	protected LinkButton ButtonHtml;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid1;
	protected HiddenField CheckGuid2;
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Concat(new string[]
		{
			"SellOrder_Report.aspx?Type=xls&pname=",
			this.txtPName.Text,
			"&sname=",
			this.txtSName.Text.ToString(),
			"&DispatchTime1=",
			this.TextBoxSDispatchTime1.Text.ToString(),
			"&DispatchTime2=",
			this.TextBoxSDispatchTime1.Text.ToString()
		}));
	}
	protected void ButtonHtml_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Concat(new string[]
		{
			"SellOrder_Report.aspx?Type=html&pname=",
			this.txtPName.Text.ToString(),
			"&sname=",
			this.txtSName.Text.ToString(),
			"&DispatchTime1=",
			this.TextBoxSDispatchTime1.Text.ToString(),
			"&DispatchTime2=",
			this.TextBoxSDispatchTime1.Text.ToString()
		}));
	}
}
