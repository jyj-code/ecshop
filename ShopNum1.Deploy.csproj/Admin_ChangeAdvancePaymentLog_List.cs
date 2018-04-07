using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ChangeAdvancePaymentLog_List : PageBase, IRequiresSessionState
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
	protected LinkButton ButtonReportAll;
	protected Num1GridView Num1GridViewShow;
	protected Label LabelPageTitle;
	protected Label LabelMemLoginID;
	protected Label LabelMemLoginIDValue;
	protected Label LabelRealName1;
	protected Label LabelRealNameValue;
	protected Label LabelCurrentAdvancePayment;
	protected Label LabelCurrentAdvancePaymentValue;
	protected Label LabelOperateMoney;
	protected System.Web.UI.WebControls.DropDownList DropDownListOperateType;
	protected System.Web.UI.WebControls.TextBox TextBoxOperateMoney;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorOperateMoney;
	protected RegularExpressionValidator RegularExpressionValidatorOperateMoney;
	protected Label LabelMemo;
	protected System.Web.UI.WebControls.TextBox TextBoxMemo;
	protected RegularExpressionValidator RegularExpressionValidatorMemo;
	protected System.Web.UI.WebControls.Button ButtonConfirm;
	protected System.Web.UI.WebControls.Button ButtonBack;
	protected MessageShow MessageShow;
	protected HtmlGenericControl divPage;
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
			this.GetMemberInfo();
			this.BindGrid();
		}
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
				Record = "导出预存款变更日志数据",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ChangeAdvancePaymentLog_List.aspx",
				Date = DateTime.Now
			});
			HttpCookie httpCookie = this.method_5();
			httpCookie.Values.Add("reportType", "4");
			httpCookie.Values.Add("Guids", "-1");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
		}
	}
	private HttpCookie method_5()
	{
		string text = this.TextMemLoginIDValue.Text;
		string selectedValue = this.DropdownListSOperateType.SelectedValue;
		string text2 = this.TextBoxSDate1.Text;
		string text3 = this.TextBoxSDate2.Text;
		return new HttpCookie("MoneyReportCookie")
		{
			Values = 
			{

				{
					"OrderNumber",
					""
				},

				{
					"MemLoginID",
					text
				},

				{
					"OperType",
					selectedValue
				},

				{
					"State",
					""
				},

				{
					"Sdate",
					text2
				},

				{
					"Edate",
					text3
				}
			}
		};
	}
	public string MoneyAddOrDel(object obj1, object obj2)
	{
		string str = Convert.ToString(Convert.ToDecimal(obj2) - Convert.ToDecimal(obj1));
		string result;
		if (Convert.ToDecimal(obj1) > Convert.ToDecimal(obj2))
		{
			result = "<font color=red>" + str + "</font>";
		}
		else
		{
			result = "<font color=green>+" + str + "</font>";
		}
		return result;
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
		shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
		shopNum1_AdvancePaymentModifyLog.OperateType = Convert.ToInt32(this.DropDownListOperateType.SelectedValue);
		shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim());
		shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
		shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
		shopNum1_AdvancePaymentModifyLog.Memo = this.TextBoxMemo.Text.Trim();
		if (this.DropDownListOperateType.SelectedValue == "1")
		{
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim()) + Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
		}
		else if (this.DropDownListOperateType.SelectedValue == "0")
		{
			if (Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim()) < Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim()))
			{
				MessageBox.Show("当前预存款不足！");
				return;
			}
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim()) - Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
		}
		shopNum1_AdvancePaymentModifyLog.MemLoginID = this.LabelMemLoginIDValue.Text.Trim();
		shopNum1_AdvancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
		shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
		shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
		ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
		int num = shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("OperateYes");
			this.MessageShow.Visible = true;
			this.GetMemberInfo();
			this.BindGrid();
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "变更预存款" + this.LabelMemLoginIDValue.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ChangeAdvancePaymentLog_List.aspx",
				Date = DateTime.Now
			});
			this.ClearControl();
		}
		else
		{
			this.MessageShow.ShowMessage("OperateNo");
			this.MessageShow.Visible = true;
		}
	}
	public string ChangeOperateType(string operateType)
	{
		string result;
		if (operateType == "1")
		{
			result = "充值";
		}
		else if (operateType == "2")
		{
			result = "提现";
		}
		else if (operateType == "3")
		{
			result = "消费";
		}
		else if (operateType == "4")
		{
			result = "收入";
		}
		else if (operateType == "5")
		{
			result = "系统";
		}
		else if (operateType == "6")
		{
			result = "转账";
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
	protected void GetMemberInfo()
	{
	}
	protected void ClearControl()
	{
		this.TextBoxMemo.Text = string.Empty;
		this.TextBoxOperateMoney.Text = string.Empty;
	}
}
