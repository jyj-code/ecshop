using AjaxControlToolkit;
using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ChangeScoreLog_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label Label3;
	protected System.Web.UI.WebControls.TextBox TextMemLoginIDValue;
	protected Label LabelSOperateType;
	protected System.Web.UI.WebControls.DropDownList DropdownListSOperateType;
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
			this.hiddenGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			this.BindGrid();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	public string ChangeOperateType(string operateType)
	{
		string result;
		if (operateType == "1")
		{
			result = "赠送积分";
		}
		else if (operateType == "2")
		{
			result = "转账积分";
		}
		else if (operateType == "3")
		{
			result = "兑换商品";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
}
