using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_WithdrawsCash : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTtitle;
	protected Label LabelMoney;
	protected TextBox TextBoxMoney;
	protected DropDownList DropDownListOperateType;
	protected TextBox TextBoxAccount;
	protected Panel PanelOne;
	protected TextBox TextBoxRealName;
	protected TextBox TextBoxBank;
	protected TextBox TextBoxConfirmBankID;
	protected Panel PanelOther;
	protected TextBox TextBoxPayPwd;
	protected TextBox TextBoxRemark;
	protected Button ButtonAdd;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField HiddenFieldXmlPath;
	protected HtmlForm form1;
	private ShopNum1_OnLineService_Action shopNum1_OnLineService_Action_0 = (ShopNum1_OnLineService_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OnLineService_Action();
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
		if (base.IsPostBack)
		{
		}
		this.BindData();
	}
	public void BindData()
	{
		try
		{
			decimal d = 0m;
			string text = string.Empty;
			text = Common.GetNameById("AdvancePayment", "ShopNum1_SubstationManage", "   AND SubstationID='" + base.SubstationID + "'  ");
			if (!string.IsNullOrEmpty(text))
			{
				d = Convert.ToDecimal(text);
				this.LabelMoney.Text = text;
			}
			if (d <= 0m)
			{
				this.ButtonAdd.Enabled = false;
			}
		}
		catch (Exception)
		{
			this.ButtonAdd.Enabled = false;
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		if (this.TextBoxMoney.Text == "")
		{
			MessageBox.Show("提现金额必填！");
		}
		else
		{
			decimal num = 0m;
			if (!decimal.TryParse(this.TextBoxMoney.Text.Trim(), out num))
			{
				MessageBox.Show("提现金额格式错误！");
			}
			else if (Convert.ToDecimal(this.TextBoxMoney.Text.Trim()) > Convert.ToDecimal(this.LabelMoney.Text))
			{
				MessageBox.Show("提现金额不能大于当前金额！");
			}
			else if (this.DropDownListOperateType.SelectedValue == "-1")
			{
				MessageBox.Show("提现方式必选！");
			}
			else
			{
				if (this.DropDownListOperateType.SelectedValue == "1")
				{
					if (this.TextBoxRealName.Text == "")
					{
						MessageBox.Show("收款人姓名不能为空！");
						return;
					}
					if (this.TextBoxBank.Text == "")
					{
						MessageBox.Show("收款银行名称不能为空！");
						return;
					}
					if (this.TextBoxConfirmBankID.Text == "")
					{
						MessageBox.Show("收款人银行账号不能为空！");
						return;
					}
				}
				else if (this.TextBoxAccount.Text == "")
				{
					MessageBox.Show("收款人账号不能为空！");
					return;
				}
				if (this.TextBoxPayPwd.Text == "")
				{
					MessageBox.Show("登录密码不能为空！");
				}
				else if (!this.CheckPwd())
				{
					MessageBox.Show("登录密码错误！");
				}
				else
				{
					this.method_5();
				}
			}
		}
	}
	private void method_5()
	{
		ShopNum1_AgentPaymentApplyLog shopNum1_AgentPaymentApplyLog = new ShopNum1_AgentPaymentApplyLog();
		if (this.DropDownListOperateType.SelectedValue == "1")
		{
			shopNum1_AgentPaymentApplyLog.Bank = this.TextBoxBank.Text.Trim();
			shopNum1_AgentPaymentApplyLog.Account = this.TextBoxConfirmBankID.Text.Trim();
		}
		else
		{
			shopNum1_AgentPaymentApplyLog.Bank = this.DropDownListOperateType.SelectedItem.Text;
			shopNum1_AgentPaymentApplyLog.Account = this.TextBoxAccount.Text.Trim();
		}
		shopNum1_AgentPaymentApplyLog.CurrentAdvancePayment = Convert.ToDecimal(this.LabelMoney.Text);
		shopNum1_AgentPaymentApplyLog.Date = DateTime.Now;
		shopNum1_AgentPaymentApplyLog.Guid = Guid.NewGuid();
		shopNum1_AgentPaymentApplyLog.ID = new int?(this.GetMaxID());
		shopNum1_AgentPaymentApplyLog.IsDeleted = 0;
		shopNum1_AgentPaymentApplyLog.MemLoginID = base.ShopNum1LoginID;
		shopNum1_AgentPaymentApplyLog.Memo = string.Empty;
		shopNum1_AgentPaymentApplyLog.OperateMoney = Convert.ToDecimal(this.TextBoxMoney.Text.Trim());
		shopNum1_AgentPaymentApplyLog.OperateStatus = 0;
		shopNum1_AgentPaymentApplyLog.OperateType = "0";
		Order order = new Order();
		shopNum1_AgentPaymentApplyLog.OrderNumber = order.CreateOrderNumber();
		shopNum1_AgentPaymentApplyLog.OrderStatus = new int?(0);
		shopNum1_AgentPaymentApplyLog.PaymentGuid = new Guid?(Guid.Empty);
		shopNum1_AgentPaymentApplyLog.PaymentName = string.Empty;
		shopNum1_AgentPaymentApplyLog.SubstationID = base.SubstationID;
		shopNum1_AgentPaymentApplyLog.TrueName = this.TextBoxRealName.Text.Trim();
		shopNum1_AgentPaymentApplyLog.UserMemo = this.TextBoxRemark.Text.Trim();
		ShopNum1_AgentPaymentApplyLog_Action shopNum1_AgentPaymentApplyLog_Action = (ShopNum1_AgentPaymentApplyLog_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_AgentPaymentApplyLog_Action();
		int num = shopNum1_AgentPaymentApplyLog_Action.Add(shopNum1_AgentPaymentApplyLog);
		if (num > 0)
		{
			shopNum1_AgentPaymentApplyLog_Action.UpdataCityAdvancePayment(Convert.ToDecimal(this.TextBoxMoney.Text.Trim()), base.SubstationID, 0);
			this.method_6(base.SubstationID, 0, Convert.ToDecimal(this.LabelMoney.Text), Convert.ToDecimal(this.TextBoxMoney.Text.Trim()), "提现扣除金额", 0);
			this.BindData();
			MessageBox.Show("申请提交成功，等待审核！");
		}
	}
	private void method_6(string string_5, int int_0, decimal decimal_0, decimal decimal_1, string string_6, int int_1)
	{
		ShopNum1_City_AdvancePaymentModifyLog_Action shopNum1_City_AdvancePaymentModifyLog_Action = (ShopNum1_City_AdvancePaymentModifyLog_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_City_AdvancePaymentModifyLog_Action();
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
		shopNum1_City_AdvancePaymentModifyLog.OperateType = 1;
		Order order = new Order();
		shopNum1_City_AdvancePaymentModifyLog.OrderNumber = order.CreateOrderNumber();
		shopNum1_City_AdvancePaymentModifyLog.SubstationID = string_5;
		shopNum1_City_AdvancePaymentModifyLog.UserMemo = "分站金额变更";
		shopNum1_City_AdvancePaymentModifyLog_Action.Add(shopNum1_City_AdvancePaymentModifyLog);
	}
	public int GetMaxID()
	{
		int result;
		try
		{
			string nameById = Common.GetNameById("max(ID)", "ShopNum1_AgentPaymentApplyLog", " and 1=1 ");
			if (!string.IsNullOrEmpty(nameById))
			{
				result = Convert.ToInt32(nameById) + 1;
			}
			else
			{
				result = 0;
			}
		}
		catch (Exception)
		{
			result = 0;
		}
		return result;
	}
	public bool CheckPwd()
	{
		bool result;
		try
		{
			string nameById = Common.GetNameById("Guid", "ShopNum1_User", string.Concat(new string[]
			{
				"   AND   LoginId='",
				base.ShopNum1LoginID,
				"' AND   Pwd='",
				Encryption.GetSHA1SecondHash(this.TextBoxPayPwd.Text),
				"'   and  SubstationID='",
				base.SubstationID,
				"'      "
			}));
			if (!string.IsNullOrEmpty(nameById))
			{
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}
	protected void DropDownListOperateType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListOperateType.SelectedValue == "1")
		{
			this.PanelOther.Visible = true;
			this.PanelOne.Visible = false;
		}
		else
		{
			this.PanelOther.Visible = false;
			this.PanelOne.Visible = true;
		}
	}
}
