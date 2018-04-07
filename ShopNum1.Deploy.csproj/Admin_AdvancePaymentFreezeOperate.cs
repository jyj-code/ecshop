using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_AdvancePaymentFreezeOperate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelSDate;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate1;
	protected RegularExpressionValidator RegularExpressionValidatorSDate1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate2;
	protected RegularExpressionValidator RegularExpressionValidatorSDate2;
	protected CompareValidator CompareValidatorTextBoxSDate2;
	protected CalendarExtender CalendarExtender2;
	protected Label LabelSOperateType;
	protected System.Web.UI.WebControls.DropDownList DropdownListSOperateType;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Num1GridView Num1GridViewShow;
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
	protected Label Label3;
	protected System.Web.UI.WebControls.TextBox TextBoxOperateMoney;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorOperateMoney;
	protected RegularExpressionValidator RegularExpressionValidatorOperateMoney;
	protected Label LabelMemo;
	protected System.Web.UI.WebControls.TextBox TextBoxMemo;
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
	public void Notice(string istate)
	{
		try
		{
			ShopNum1_MessageInfo shopNum1_MessageInfo = new ShopNum1_MessageInfo();
			shopNum1_MessageInfo.Guid = Guid.NewGuid();
			shopNum1_MessageInfo.Title = "平台冻结/解冻预存款通知";
			shopNum1_MessageInfo.Type = "1";
			string content = string.Empty;
			if (istate == "1")
			{
				content = string.Concat(new string[]
				{
					"平台于",
					DateTime.Now.ToString().Replace("/", "-"),
					"解冻了您的预存款<span style=\"color:red\">【￥",
					this.TextBoxOperateMoney.Text,
					"】</span>，您解冻后账户余额为：￥",
					(Convert.ToDecimal(this.LabelAdvancePayment.Text) + Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim())).ToString()
				});
			}
			else if (istate == "0")
			{
				content = string.Concat(new string[]
				{
					"平台于",
					DateTime.Now.ToString().Replace("/", "-"),
					"冻结了您的预存款<span style=\"color:red\">【￥",
					this.TextBoxOperateMoney.Text,
					"】</span>，您冻结后账户余额为：￥",
					(Convert.ToDecimal(this.LabelAdvancePayment.Text) - Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim())).ToString()
				});
			}
			shopNum1_MessageInfo.Content = content;
			shopNum1_MessageInfo.MemLoginID = "";
			shopNum1_MessageInfo.MemLoginID = base.ShopNum1LoginID;
			shopNum1_MessageInfo.SendTime = DateTime.Now;
			shopNum1_MessageInfo.IsDeleted = 0;
			List<string> list = new List<string>();
			list.Add(this.LabelMemLoginIDValue.Text);
			ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
			shopNum1_MessageInfo_Action.Add(shopNum1_MessageInfo, list);
		}
		catch (Exception)
		{
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void addAdvancePaymentModifyLog(decimal CurrentAdvancePayment, decimal OperateMoney, int OperateType)
	{
		ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
		shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
		if (OperateType == 1)
		{
			shopNum1_AdvancePaymentModifyLog.OperateType = 5;
		}
		else
		{
			shopNum1_AdvancePaymentModifyLog.OperateType = 5;
		}
		shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = CurrentAdvancePayment;
		shopNum1_AdvancePaymentModifyLog.OperateMoney = OperateMoney;
		shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
		shopNum1_AdvancePaymentModifyLog.Memo = this.TextBoxMemo.Text.Trim();
		if (OperateType == 1)
		{
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = CurrentAdvancePayment + OperateMoney;
			if (string.IsNullOrEmpty(this.TextBoxMemo.Text))
			{
				shopNum1_AdvancePaymentModifyLog.Memo = "解冻预存款";
			}
		}
		else if (OperateType == 0)
		{
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = CurrentAdvancePayment - OperateMoney;
			if (string.IsNullOrEmpty(this.TextBoxMemo.Text))
			{
				shopNum1_AdvancePaymentModifyLog.Memo = "冻结预存款";
			}
		}
		shopNum1_AdvancePaymentModifyLog.MemLoginID = this.LabelMemLoginIDValue.Text.Trim();
		shopNum1_AdvancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
		shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
		shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
		ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
		shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
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
		shopNum1_AdvancePaymentFreezeLog.CreateTime = DateTime.Now.ToString();
		shopNum1_AdvancePaymentFreezeLog.IsDeleted = new int?(0);
		ShopNum1_AdvancePaymentFreezeLog_Action shopNum1_AdvancePaymentFreezeLog_Action = (ShopNum1_AdvancePaymentFreezeLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentFreezeLog_Action();
		int num = shopNum1_AdvancePaymentFreezeLog_Action.OperateMoney(shopNum1_AdvancePaymentFreezeLog, lastAdvancePayment);
		if (num > 0)
		{
			if (this.DropDownListOperateType.SelectedValue == "1")
			{
				this.addAdvancePaymentModifyLog(Convert.ToDecimal(this.LabelAdvancePayment.Text), Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim()), 1);
				this.Notice("1");
			}
			else if (this.DropDownListOperateType.SelectedValue == "0")
			{
				this.addAdvancePaymentModifyLog(Convert.ToDecimal(this.LabelAdvancePayment.Text), Convert.ToDecimal(this.TextBoxOperateMoney.Text.Trim()), 0);
				this.Notice("0");
			}
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
