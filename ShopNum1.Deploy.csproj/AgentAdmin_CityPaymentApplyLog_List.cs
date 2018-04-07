using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_CityPaymentApplyLog_List : PageBase, IRequiresSessionState
{
	protected const string AdvancePaymentApplyLog_Operate = "CityPaymentMemApplyLog_Operate.aspx";
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label Label1;
	protected System.Web.UI.WebControls.TextBox TextBoxOrderNumber;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
	protected Label LabelSOperateStatus;
	protected System.Web.UI.WebControls.DropDownList DropdownListSOperateStatus;
	protected Label LabelSDate;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate2;
	protected RegularExpressionValidator RegularExpressionValidatorEndDate;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Label LabelSOperateType;
	protected System.Web.UI.WebControls.DropDownList DropdownListSOperateType;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
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
			string a = (base.Request.QueryString["operateStatus"] == null) ? "-1" : base.Request.QueryString["operateStatus"];
			if (a == "1")
			{
				this.DropdownListSOperateStatus.SelectedValue = "0";
			}
			else
			{
				this.DropdownListSOperateStatus.SelectedValue = "-1";
			}
			this.BindGrid();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
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
	protected void BindGrid()
	{
		try
		{
			this.Num1GridViewShow.DataBind();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	public string ChangeOperateType(string operateType)
	{
		string result;
		if (operateType == "0")
		{
			result = "提现";
		}
		else if (operateType == "1")
		{
			result = "充值";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeOperateStatus(string operateStatus)
	{
		string result;
		if (operateStatus == "0")
		{
			result = LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "0");
		}
		else if (operateStatus == "1")
		{
			result = LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "1");
		}
		else
		{
			result = "已拒绝";
		}
		return result;
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CityPaymentMemApplyLog_Operate.aspx?guid='" + this.CheckGuid.Value + "'");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_AgentPaymentApplyLog_Action shopNum1_AgentPaymentApplyLog_Action = (ShopNum1_AgentPaymentApplyLog_Action)LogicFactory.CreateShopNum1_AgentPaymentApplyLog_Action();
		string[] array = this.CheckGuid.Value.ToString().Split(new char[]
		{
			','
		});
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			if (this.GetState(array[i].ToString()))
			{
				flag = true;
			}
		}
		if (flag)
		{
			MessageBox.Show("不能删除含有“未确认”状态的数据！");
		}
		else
		{
			int num = shopNum1_AgentPaymentApplyLog_Action.Delete(this.CheckGuid.Value.ToString());
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "删除成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "CityPaymentApplyLog_List.aspx",
					Date = DateTime.Now
				});
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
	public bool GetState(string strguid)
	{
		bool result = false;
		try
		{
			string nameById = Common.GetNameById("OperateStatus", "ShopNum1_AgentPaymentApplyLog", "    AND  Guid='" + strguid.Replace("'", "") + "'  ");
			if (nameById == "0")
			{
				result = true;
			}
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		ShopNum1_AgentPaymentApplyLog_Action shopNum1_AgentPaymentApplyLog_Action = (ShopNum1_AgentPaymentApplyLog_Action)LogicFactory.CreateShopNum1_AgentPaymentApplyLog_Action();
		int num = shopNum1_AgentPaymentApplyLog_Action.Delete(guid);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "CityPaymentApplyLog_List.aspx",
				Date = DateTime.Now
			});
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
