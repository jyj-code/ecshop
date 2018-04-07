using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_AdvancePaymentApplyLog_List : PageBase, IRequiresSessionState
{
	protected const string AdvancePaymentApplyLog_Operate = "AdvancePaymentApplyLog_Operate.aspx";
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
	protected LinkButton ButtonReportAll;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
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
	private HttpCookie method_5()
	{
		string text = this.TextBoxOrderNumber.Text;
		string text2 = this.TextBoxSMemLoginID.Text;
		string selectedValue = this.DropdownListSOperateStatus.SelectedValue;
		string text3 = this.TextBoxSDate1.Text;
		string text4 = this.TextBoxSDate2.Text;
		return new HttpCookie("MoneyReportCookie")
		{
			Values = 
			{

				{
					"OrderNumber",
					text
				},

				{
					"MemLoginID",
					text2
				},

				{
					"State",
					selectedValue
				},

				{
					"Sdate",
					text3
				},

				{
					"Edate",
					text4
				}
			}
		};
	}
	protected void ButtonReportAll_Click(object sender, EventArgs e)
	{
		if (this.Num1GridViewShow.Rows.Count < 1)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "导出提现审核数据",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AdvancePaymentApplyLog_List.aspx",
				Date = DateTime.Now
			});
			HttpCookie httpCookie = this.method_5();
			httpCookie.Values.Add("reportType", "2");
			httpCookie.Values.Add("Guids", "-1");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
		}
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
		base.Response.Redirect("AdvancePaymentApplyLog_Operate.aspx?guid='" + this.CheckGuid.Value + "'");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
		int num = shopNum1_AdvancePaymentApplyLog_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AdvancePaymentApplyLog_List.aspx",
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
		int num = shopNum1_AdvancePaymentApplyLog_Action.Delete(guids);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AdvancePaymentApplyLog_List.aspx",
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
