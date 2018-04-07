using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_AdvancePaymentMemApplyLog_Operate : PageBase, IRequiresSessionState
{
	protected const string AdvancePaymentApplyLog_List = "AdvancePaymentApplyLog_List.aspx";
	protected HtmlHead Head1;
	protected Label Label2;
	protected Label Label10;
	protected Label LabelMemLoginIDValue;
	protected Label LabelCurrentAdvancePayment;
	protected Label LabelCurrentAdvancePaymentValue;
	protected Label LabelDate;
	protected Label LabelDateValue;
	protected Label LabelOperateType;
	protected Label LabelOperateTypeValue;
	protected Label LabelOperateMoney;
	protected Label LabelOperateMoneyValue;
	protected Label Label1;
	protected TextBox TextBox_Bank;
	protected Label Label11;
	protected TextBox TextBoxTrueName;
	protected Label Label12;
	protected TextBox TextBoxAccount;
	protected Panel Panel1;
	protected Label LabelMemo;
	protected TextBox TextBoxMemo;
	protected Label LabelUserMemo;
	protected TextBox TextBoxUserMemo;
	protected RegularExpressionValidator RegularExpressionValidatorMemo;
	protected Label LabelOperateStatus;
	protected DropDownList DropDownListOperateStatus;
	protected Button ButtonConfirm;
	protected HtmlInputButton ResetGoBack;
	protected MessageShow MessageShow0;
	protected MessageShow MessageShow;
	protected HiddenField hiddenGuid;
	protected HiddenField HiddenFieldOperateTypeValue;
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
			if (this.hiddenGuid.Value != "0")
			{
				this.GetEditInfo();
			}
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
		DataTable dataTable = shopNum1_AdvancePaymentApplyLog_Action.Search(this.hiddenGuid.Value.Replace("'", ""));
		this.LabelMemLoginIDValue.Text = dataTable.Rows[0]["MemLoginID"].ToString();
		this.LabelCurrentAdvancePaymentValue.Text = dataTable.Rows[0]["CurrentAdvancePayment"].ToString();
		this.LabelDateValue.Text = dataTable.Rows[0]["Date"].ToString();
		this.HiddenFieldOperateTypeValue.Value = dataTable.Rows[0]["OperateType"].ToString();
		if (dataTable.Rows[0]["OperateType"].ToString() == "0")
		{
			this.LabelOperateTypeValue.Text = "提现";
			this.Panel1.Visible = true;
			this.TextBox_Bank.Text = dataTable.Rows[0]["Bank"].ToString();
			this.TextBoxTrueName.Text = dataTable.Rows[0]["TrueName"].ToString();
			this.TextBoxAccount.Text = dataTable.Rows[0]["Account"].ToString();
		}
		else if (dataTable.Rows[0]["OperateType"].ToString() == "1")
		{
			this.LabelOperateTypeValue.Text = "充值";
		}
		this.LabelOperateMoneyValue.Text = dataTable.Rows[0]["OperateMoney"].ToString();
		this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
		this.TextBoxUserMemo.Text = dataTable.Rows[0]["UserMemo"].ToString();
		this.DropDownListOperateStatus.SelectedValue = dataTable.Rows[0]["OperateStatus"].ToString();
		if (this.DropDownListOperateStatus.SelectedValue == "1" || this.DropDownListOperateStatus.SelectedValue == "2")
		{
			this.ButtonConfirm.Visible = false;
			this.DropDownListOperateStatus.Enabled = false;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.DropDownListOperateStatus.SelectedValue == "0")
		{
			MessageBox.Show("请选择到账状态！");
		}
		else
		{
			ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
			if (this.DropDownListOperateStatus.SelectedValue == "1")
			{
				shopNum1_AdvancePaymentApplyLog_Action.ChangeOperateStatus(this.TextBoxUserMemo.Text.Trim(), 1, this.hiddenGuid.Value.Replace("'", ""));
			}
			if (this.DropDownListOperateStatus.SelectedValue == "2")
			{
				shopNum1_AdvancePaymentApplyLog_Action.ChangeOperateStatus(this.TextBoxUserMemo.Text.Trim(), 2, this.hiddenGuid.Value.Replace("'", ""));
				decimal num = 0m;
				string nameById = Common.GetNameById("AdvancePayment", "ShopNum1_Member", "  AND  MemLoginID='" + this.LabelMemLoginIDValue.Text + "'");
				if (!string.IsNullOrEmpty(nameById))
				{
					num = Convert.ToDecimal(nameById);
				}
				ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
				shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
				shopNum1_AdvancePaymentModifyLog.OperateType = 5;
				shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num;
				shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(this.LabelOperateMoneyValue.Text);
				shopNum1_AdvancePaymentModifyLog.LastOperateMoney = num + Convert.ToDecimal(this.LabelOperateMoneyValue.Text);
				shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
				shopNum1_AdvancePaymentModifyLog.Memo = "系统拒绝会员提现申请，返回预存款￥" + this.LabelOperateMoneyValue.Text.Trim();
				shopNum1_AdvancePaymentModifyLog.MemLoginID = this.LabelMemLoginIDValue.Text;
				shopNum1_AdvancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
				shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
				ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
				shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
			}
			base.Response.Redirect("AdvancePaymentApplyLog_List.aspx");
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
	}
}
