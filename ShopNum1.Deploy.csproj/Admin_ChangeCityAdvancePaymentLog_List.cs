using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Control;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ChangeCityAdvancePaymentLog_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label Label3;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
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
	protected Label Label4;
	protected System.Web.UI.WebControls.DropDownList DropdownListIsMainAdmin;
	protected System.Web.UI.WebControls.TextBox TextBoxOrderNumber;
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
			this.GetSubstationID();
			this.BindGrid();
		}
	}
	public string AgentType(string IsMainAdmin)
	{
		string result;
		if (IsMainAdmin == "1")
		{
			result = "主站";
		}
		else if (IsMainAdmin == "0")
		{
			result = "分站";
		}
		else
		{
			result = "";
		}
		return result;
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
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	public void GetSubstationID()
	{
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
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
}
