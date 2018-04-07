using AjaxControlToolkit;
using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ChangeCityAdvancePaymentLog_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.TextBox TextBoxOrderNumber;
	protected Label LabelSOperateType;
	protected System.Web.UI.WebControls.DropDownList DropDownListOperateType;
	protected Label LabelSDate;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate1;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxSDate1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate2;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxSDate2;
	protected CompareValidator CompareValidatorTextBoxSDate2;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField hiddenGuid;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField HiddenFieldSubstationID;
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
		if (!this.Page.IsPostBack)
		{
			this.BindGrid();
		}
	}
	public string OperateType(string OperateType)
	{
		string result;
		if (OperateType == "1")
		{
			result = "支出";
		}
		else if (OperateType == "0")
		{
			result = "收益";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
}
