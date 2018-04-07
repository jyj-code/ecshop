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
public class Admin_AdvancePaymentApplyLog_Operate : PageBase, IRequiresSessionState
{
	protected const string AdvancePaymentApplyLog_List = "AdvancePaymentMemApplyLog_List.aspx";
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
	protected Label Label3;
	protected Label LabelPaymentName;
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
	protected Button ResetGoBack;
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
			this.HiddenFieldOperateTypeValue.Value = ((base.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"]);
			if (this.hiddenGuid.Value != "0")
			{
				this.GetEditInfo();
				if (this.HiddenFieldOperateTypeValue.Value == "1")
				{
					this.Label2.Text = "充值确认";
				}
				else if (this.HiddenFieldOperateTypeValue.Value == "1")
				{
					this.Label2.Text = "提现审核";
				}
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
		this.LabelPaymentName.Text = dataTable.Rows[0]["PaymentName"].ToString();
		if (this.DropDownListOperateStatus.SelectedValue == "1" || this.DropDownListOperateStatus.SelectedValue == "2")
		{
			this.ButtonConfirm.Visible = false;
			this.DropDownListOperateStatus.Enabled = false;
			this.TextBoxUserMemo.Enabled = false;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		try
		{
			ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
			if (this.DropDownListOperateStatus.SelectedValue == "1")
			{
				if (this.TextBoxUserMemo.Text.Length > 50)
				{
					MessageBox.Show("管理员备注长度不能大于50");
				}
				else
				{
					ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
					shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
					if (this.HiddenFieldOperateTypeValue.Value == "0")
					{
						shopNum1_AdvancePaymentModifyLog.OperateType = 0;
					}
					else if (this.HiddenFieldOperateTypeValue.Value == "1")
					{
						shopNum1_AdvancePaymentModifyLog.OperateType = 1;
					}
					shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim());
					shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(this.LabelOperateMoneyValue.Text.Trim());
					shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
					shopNum1_AdvancePaymentModifyLog.Memo = this.TextBoxUserMemo.Text.Trim();
					if (this.DropDownListOperateStatus.SelectedValue == "1")
					{
						if (this.HiddenFieldOperateTypeValue.Value == "0")
						{
							shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim());
						}
						else if (this.HiddenFieldOperateTypeValue.Value == "1")
						{
							shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim()) + Convert.ToDecimal(this.LabelOperateMoneyValue.Text.Trim());
						}
					}
					else if (this.HiddenFieldOperateTypeValue.Value == "0")
					{
						shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim()) + Convert.ToDecimal(this.LabelOperateMoneyValue.Text.Trim());
					}
					else if (this.HiddenFieldOperateTypeValue.Value == "1")
					{
						shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(this.LabelCurrentAdvancePaymentValue.Text.Trim());
					}
					shopNum1_AdvancePaymentModifyLog.MemLoginID = this.LabelMemLoginIDValue.Text.Trim();
					shopNum1_AdvancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
					shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
					shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
					int num = shopNum1_AdvancePaymentApplyLog_Action.Update_Update(this.hiddenGuid.Value.Replace("'", ""), this.LabelMemLoginIDValue.Text, this.HiddenFieldOperateTypeValue.Value, Convert.ToDecimal(this.LabelOperateMoneyValue.Text.Trim()), Convert.ToInt32(this.DropDownListOperateStatus.SelectedValue), this.TextBoxUserMemo.Text.Trim(), shopNum1_AdvancePaymentModifyLog, base.ShopNum1LoginID);
					if (num > 0)
					{
						base.OperateLog(new ShopNum1_OperateLog
						{
							Record = "充值审核" + this.LabelMemLoginIDValue.Text + "成功",
							OperatorID = base.ShopNum1LoginID,
							IP = Globals.IPAddress,
							PageName = "AdvancePaymentApplyLog_Operate.aspx",
							Date = DateTime.Now
						});
						base.Response.Redirect("AdvancePaymentMemApplyLog_List.aspx");
					}
					else
					{
						this.MessageShow.ShowMessage("AddNo");
						this.MessageShow.Visible = true;
					}
				}
			}
			else if (this.DropDownListOperateStatus.SelectedValue == "2")
			{
				if (this.TextBoxUserMemo.Text.Length > 50)
				{
					MessageBox.Show("管理员备注长度不能大于50");
				}
				else
				{
					shopNum1_AdvancePaymentApplyLog_Action.ChangeLogStatusNew(2, this.hiddenGuid.Value.Replace("'", ""), this.TextBoxUserMemo.Text.Trim());
					base.Response.Redirect("AdvancePaymentMemApplyLog_List.aspx");
				}
			}
			else
			{
				MessageBox.Show("请选择操作！");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	protected void ResetGoBack_Click(object sender, EventArgs e)
	{
		if (this.HiddenFieldOperateTypeValue.Value == "1")
		{
			base.Response.Redirect("AdvancePaymentMemApplyLog_List.aspx");
		}
		else if (this.HiddenFieldOperateTypeValue.Value == "0")
		{
			base.Response.Redirect("AdvancePaymentApplyLog_List.aspx");
		}
	}
}
