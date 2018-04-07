using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_CityPaymentMemApplyLog_Operate : PageBase, IRequiresSessionState
{
	protected const string AdvancePaymentApplyLog_List = "CityPaymentApplyLog_List.aspx";
	protected HtmlHead Head1;
	protected Label Label2;
	protected Label Label3;
	protected Label LabelSubstationID;
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
		ShopNum1_AgentPaymentApplyLog_Action shopNum1_AgentPaymentApplyLog_Action = (ShopNum1_AgentPaymentApplyLog_Action)LogicFactory.CreateShopNum1_AgentPaymentApplyLog_Action();
		DataTable dataTable = shopNum1_AgentPaymentApplyLog_Action.SearchByGuid(this.hiddenGuid.Value.Replace("'", ""));
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
		this.LabelSubstationID.Text = dataTable.Rows[0]["SubstationID"].ToString();
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
			ShopNum1_AgentPaymentApplyLog_Action shopNum1_AgentPaymentApplyLog_Action = (ShopNum1_AgentPaymentApplyLog_Action)LogicFactory.CreateShopNum1_AgentPaymentApplyLog_Action();
			if (this.DropDownListOperateStatus.SelectedValue == "1")
			{
				shopNum1_AgentPaymentApplyLog_Action.UpdataOperateStatus(1, this.hiddenGuid.Value.Replace("'", ""), this.TextBoxUserMemo.Text.Trim());
			}
			if (this.DropDownListOperateStatus.SelectedValue == "2")
			{
				shopNum1_AgentPaymentApplyLog_Action.UpdataOperateStatus(2, this.hiddenGuid.Value.Replace("'", ""), this.TextBoxUserMemo.Text.Trim());
				decimal decimal_ = 0m;
				string nameById = Common.GetNameById("AdvancePayment", "ShopNum1_SubstationManage", "  AND    SubstationID='" + this.LabelSubstationID.Text + "'");
				if (!string.IsNullOrEmpty(nameById))
				{
					decimal_ = Convert.ToDecimal(nameById);
				}
				ShopNum1_City_AdvancePaymentModifyLog_Action shopNum1_City_AdvancePaymentModifyLog_Action = (ShopNum1_City_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_City_AdvancePaymentModifyLog_Action();
				shopNum1_City_AdvancePaymentModifyLog_Action.UpdateSubstationAdvancePayment(Convert.ToDecimal(this.LabelOperateMoneyValue.Text), this.LabelSubstationID.Text, 1);
				this.method_5(this.LabelSubstationID.Text, 1, decimal_, Convert.ToDecimal(this.LabelOperateMoneyValue.Text), "主站拒绝提现申请，返回预存款￥" + this.LabelOperateMoneyValue.Text.Trim(), 0);
			}
			base.Response.Redirect("CityPaymentApplyLog_List.aspx");
		}
	}
	private void method_5(string string_5, int int_0, decimal decimal_0, decimal decimal_1, string string_6, int int_1)
	{
		ShopNum1_City_AdvancePaymentModifyLog_Action shopNum1_City_AdvancePaymentModifyLog_Action = (ShopNum1_City_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_City_AdvancePaymentModifyLog_Action();
		ShopNum1_City_AdvancePaymentModifyLog shopNum1_City_AdvancePaymentModifyLog = new ShopNum1_City_AdvancePaymentModifyLog();
		shopNum1_City_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
		shopNum1_City_AdvancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
		shopNum1_City_AdvancePaymentModifyLog.CurrentAdvancePayment = decimal_0;
		shopNum1_City_AdvancePaymentModifyLog.Date = DateTime.Now;
		shopNum1_City_AdvancePaymentModifyLog.Guid = Guid.NewGuid();
		shopNum1_City_AdvancePaymentModifyLog.IsDeleted = new int?(0);
		shopNum1_City_AdvancePaymentModifyLog.IsMainAdmin = new int?(int_1);
		if (int_0 == 0)
		{
			shopNum1_City_AdvancePaymentModifyLog.LastOperateMoney = decimal_0 - decimal_1;
		}
		else if (int_0 == 1)
		{
			shopNum1_City_AdvancePaymentModifyLog.LastOperateMoney = decimal_0 + decimal_1;
		}
		shopNum1_City_AdvancePaymentModifyLog.Memo = string_6;
		shopNum1_City_AdvancePaymentModifyLog.OperateMoney = decimal_1;
		shopNum1_City_AdvancePaymentModifyLog.OperateType = 0;
		Order order = new Order();
		shopNum1_City_AdvancePaymentModifyLog.OrderNumber = order.CreateOrderNumber();
		shopNum1_City_AdvancePaymentModifyLog.SubstationID = string_5;
		shopNum1_City_AdvancePaymentModifyLog.UserMemo = "分站金额变更";
		shopNum1_City_AdvancePaymentModifyLog_Action.Add(shopNum1_City_AdvancePaymentModifyLog);
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
	}
}
