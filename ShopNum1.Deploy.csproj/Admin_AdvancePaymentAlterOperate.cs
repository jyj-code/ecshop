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
public class Admin_AdvancePaymentAlterOperate : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
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
	protected Label LabelMemLoginID;
	protected Label LabelMemLoginIDValue;
	protected Label LabelRealName1;
	protected Label LabelRealNameValue;
	protected Label LabelCurrentAdvancePayment;
	protected Label LabelCurrentAdvancePaymentValue;
	protected Label LabelOperateMoney;
	protected System.Web.UI.WebControls.DropDownList DropDownListOperateType;
	protected Label Label3;
	protected System.Web.UI.WebControls.TextBox TextBoxOperateMoney;
	protected Label LabelColor;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label LabelMemo;
	protected System.Web.UI.WebControls.TextBox TextBoxMemo;
	protected RegularExpressionValidator RegularExpressionValidatorMemo;
	protected System.Web.UI.WebControls.Button ButtonConfirm;
	protected System.Web.UI.WebControls.Button ButtonBack;
	protected MessageShow MessageShow;
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		double num = 0.0;
		if (!double.TryParse(this.TextBoxOperateMoney.Text.Trim(), out num))
		{
			MessageBox.Show("输入金额格式有误！");
		}
		else if (Convert.ToDouble(this.TextBoxOperateMoney.Text.Trim()) <= 0.0)
		{
			MessageBox.Show("输入金额不能为0或者负数！");
		}
		else
		{
			ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
			shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
			if (this.DropDownListOperateType.SelectedValue == "1")
			{
				shopNum1_AdvancePaymentModifyLog.OperateType = 1;
			}
			else
			{
				shopNum1_AdvancePaymentModifyLog.OperateType = 2;
			}
			shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim());
			shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
			shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
			shopNum1_AdvancePaymentModifyLog.Memo = this.TextBoxMemo.Text.Trim();
			if (this.DropDownListOperateType.SelectedValue == "1")
			{
				shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim()) + Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
				if (string.IsNullOrEmpty(this.TextBoxMemo.Text))
				{
					shopNum1_AdvancePaymentModifyLog.Memo = "系统平台给会员充值￥" + this.TextBoxOperateMoney.Text.Trim();
				}
			}
			else if (this.DropDownListOperateType.SelectedValue == "0")
			{
				if (Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim()) < Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim()))
				{
					MessageBox.Show("当前预存款不足！");
					return;
				}
				shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim()) - Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim());
				if (string.IsNullOrEmpty(this.TextBoxMemo.Text))
				{
					shopNum1_AdvancePaymentModifyLog.Memo = "会员提取预存款，系统手动减少预存款￥" + this.TextBoxOperateMoney.Text.Trim();
				}
			}
			shopNum1_AdvancePaymentModifyLog.MemLoginID = this.LabelMemLoginIDValue.Text.Trim();
			shopNum1_AdvancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
			shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			int num2 = shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
			if (num2 > 0)
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
	}
	public string ChangeOperateType(string operateType)
	{
		string result;
		if (operateType == "0")
		{
			result = LocalizationUtil.GetChangeMessage("ChangeScoreModifyLog_List", "OperateType", "0");
		}
		else if (operateType == "1")
		{
			result = LocalizationUtil.GetChangeMessage("ChangeScoreModifyLog_List", "OperateType", "1");
		}
		else if (operateType == "2")
		{
			result = LocalizationUtil.GetChangeMessage("ChangeScoreModifyLog_List", "OperateType", "2");
		}
		else if (operateType == "3")
		{
			result = LocalizationUtil.GetChangeMessage("ChangeScoreModifyLog_List", "OperateType", "3");
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
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataTable dataTable = shopNum1_Member_Action.SearchInfoByGuid(this.hiddenGuid.Value);
		this.LabelMemLoginIDValue.Text = dataTable.Rows[0]["MemLoginID"].ToString();
		this.LabelRealNameValue.Text = dataTable.Rows[0]["Name"].ToString();
		this.LabelCurrentAdvancePaymentValue.Text = dataTable.Rows[0]["AdvancePayment"].ToString();
	}
	protected void ClearControl()
	{
		this.TextBoxMemo.Text = string.Empty;
		this.TextBoxOperateMoney.Text = string.Empty;
	}
}
