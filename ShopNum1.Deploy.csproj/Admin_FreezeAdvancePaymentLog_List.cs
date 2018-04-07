using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_FreezeAdvancePaymentLog_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label Label3;
	protected System.Web.UI.WebControls.TextBox TextMemLoginIDValue;
	protected Label LabelSOperateType;
	protected System.Web.UI.WebControls.DropDownList DropdownListSOperateType;
	protected Label LabelSDate;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate1;
	protected RegularExpressionValidator RegularExpressionValidatorSDate1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate2;
	protected RegularExpressionValidator RegularExpressionValidatorSDate2;
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
	protected Label LabelAdvancePayment_;
	protected Label LabelAdvancePayment;
	protected Label LabelLockAdvancePayment_;
	protected Label LabelLockAdvancePayment;
	protected Label LabelOperateMoney;
	protected System.Web.UI.WebControls.DropDownList DropDownListOperateType;
	protected System.Web.UI.WebControls.TextBox TextBoxOperateMoney;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorOperateMoney;
	protected RegularExpressionValidator RegularExpressionValidatorOperateMoney;
	protected Label LabelMemo;
	protected System.Web.UI.WebControls.TextBox TextBoxMemo;
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
				Record = "导出预存款解/冻日志数据",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "FreezeAdvancePaymentLog_List.aspx",
				Date = DateTime.Now
			});
			HttpCookie httpCookie = this.method_5();
			httpCookie.Values.Add("reportType", "5");
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		decimal lastAdvancePayment = 0m;
		ShopNum1_AdvancePaymentFreezeLog shopNum1_AdvancePaymentFreezeLog = new ShopNum1_AdvancePaymentFreezeLog();
		shopNum1_AdvancePaymentFreezeLog.Guid = Guid.NewGuid();
		shopNum1_AdvancePaymentFreezeLog.OperateType = Convert.ToInt32(this.DropDownListOperateType.SelectedValue);
		shopNum1_AdvancePaymentFreezeLog.CurrentAdvancePayment = Convert.ToDecimal(this.LabelLockAdvancePayment.Text.Trim());
		shopNum1_AdvancePaymentFreezeLog.OperateMoney = Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
		shopNum1_AdvancePaymentFreezeLog.Date = DateTime.Now;
		shopNum1_AdvancePaymentFreezeLog.Memo = this.TextBoxMemo.Text.Trim();
		if (this.DropDownListOperateType.SelectedValue == "1")
		{
			if (Convert.ToDecimal(this.LabelLockAdvancePayment.Text.Trim()) < Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim()))
			{
				MessageBox.Show("当前冻结预存款不足！");
				return;
			}
			shopNum1_AdvancePaymentFreezeLog.LastOperateMoney = Convert.ToDecimal(this.LabelLockAdvancePayment.Text.Trim()) - Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
			lastAdvancePayment = Convert.ToDecimal(this.LabelAdvancePayment.Text) + Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
		}
		else if (this.DropDownListOperateType.SelectedValue == "0")
		{
			if (Convert.ToDecimal(this.LabelAdvancePayment.Text.Trim()) < Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim()))
			{
				MessageBox.Show("当前预存款不足！");
				return;
			}
			shopNum1_AdvancePaymentFreezeLog.LastOperateMoney = Convert.ToDecimal(this.LabelLockAdvancePayment.Text.Trim()) + Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
			lastAdvancePayment = Convert.ToDecimal(this.LabelAdvancePayment.Text) - Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
		}
		shopNum1_AdvancePaymentFreezeLog.MemLoginID = this.LabelMemLoginIDValue.Text.Trim();
		shopNum1_AdvancePaymentFreezeLog.CreateUser = base.ShopNum1LoginID;
		shopNum1_AdvancePaymentFreezeLog.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		shopNum1_AdvancePaymentFreezeLog.IsDeleted = new int?(0);
		ShopNum1_AdvancePaymentFreezeLog_Action shopNum1_AdvancePaymentFreezeLog_Action = (ShopNum1_AdvancePaymentFreezeLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentFreezeLog_Action();
		int num = shopNum1_AdvancePaymentFreezeLog_Action.OperateMoney(shopNum1_AdvancePaymentFreezeLog, lastAdvancePayment);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("OperateYes");
			this.MessageShow.Visible = true;
			this.GetMemberInfo();
			this.BindGrid();
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "冻结预存款" + this.LabelMemLoginIDValue.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "FreezeAdvancePaymentLog_List.aspx",
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
		if (operateType == "0")
		{
			result = LocalizationUtil.GetChangeMessage("FreezeScoreLog_List", "OperateType", "0");
		}
		else if (operateType == "1")
		{
			result = LocalizationUtil.GetChangeMessage("FreezeScoreLog_List", "OperateType", "1");
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
		try
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable = shopNum1_Member_Action.SearchInfoByGuid(this.hiddenGuid.Value);
			this.LabelMemLoginIDValue.Text = dataTable.Rows[0]["MemLoginID"].ToString();
			this.LabelRealNameValue.Text = dataTable.Rows[0]["Name"].ToString();
			this.LabelLockAdvancePayment.Text = dataTable.Rows[0]["LockAdvancePayment"].ToString();
			this.LabelAdvancePayment.Text = dataTable.Rows[0]["AdvancePayment"].ToString();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	protected void ClearControl()
	{
		this.TextBoxMemo.Text = string.Empty;
		this.TextBoxOperateMoney.Text = string.Empty;
	}
}
