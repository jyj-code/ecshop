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
public class Admin_Payment_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelPaymentType;
	protected DropDownList DropDownListPaymentType;
	protected Label Label1;
	protected CompareValidator CompareValidatorPaymentType;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label2;
	protected Label LabelnameErrorMessage;
	protected Label LabelEmail;
	protected TextBox TextBoxEmail;
	protected Label LabelEmailErrorMessage;
	protected Label LabelMerchantCode;
	protected TextBox TextBoxMerchantCode;
	protected Label Label8;
	protected Label LabelMerchantCodeErrorMessage;
	protected Label LabelSecretKey;
	protected TextBox TextBoxSecretKey;
	protected Label LabelMemo;
	protected TextBox TextBoxMemo;
	protected RegularExpressionValidator RegularExpressionValidatorTitle6;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label7;
	protected RadioButtonList RadioButtonListForredepositrecharge;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack)
		{
			this.RadioButtonListForredepositrecharge.RepeatLayout = RepeatLayout.Flow;
			this.RadioButtonListForredepositrecharge.RepeatDirection = RepeatDirection.Horizontal;
			this.method_5();
			this.RadioButtonListForredepositrecharge.SelectedValue = "1";
			this.method_8();
			this.GetOrderID();
			this.DropDownListPaymentType.SelectedValue = "-1";
			if (this.DropDownListPaymentType.SelectedValue != "-1")
			{
				this.TextBoxName.Text = this.DropDownListPaymentType.SelectedValue;
			}
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑支付方式";
				this.method_7();
			}
		}
	}
	private void method_5()
	{
		this.RadioButtonListForredepositrecharge.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "是";
		listItem.Value = "1";
		this.RadioButtonListForredepositrecharge.Items.Add(listItem);
		listItem = new ListItem();
		listItem.Text = "否";
		listItem.Value = "0";
		this.RadioButtonListForredepositrecharge.Items.Add(listItem);
	}
	protected void GetOrderID()
	{
		string columnName = "OrderID";
		string tableName = "ShopNum1_Payment";
		this.TextBoxOrderID.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		try
		{
			if (this.ButtonConfirm.ToolTip == "Submit")
			{
				ShopNum1_Payment shopNum1_Payment = new ShopNum1_Payment();
				shopNum1_Payment.Guid = Guid.NewGuid();
				shopNum1_Payment.PaymentType = this.DropDownListPaymentType.SelectedValue;
				shopNum1_Payment.Name = this.TextBoxName.Text.Trim();
				shopNum1_Payment.MerchantCode = this.TextBoxMerchantCode.Text.Trim();
				shopNum1_Payment.SecretKey = this.TextBoxSecretKey.Text.Trim();
				shopNum1_Payment.SecondKey = shopNum1_Payment.SecretKey;
				shopNum1_Payment.Pwd = shopNum1_Payment.SecretKey;
				shopNum1_Payment.Partner = "1";
				shopNum1_Payment.Charge = 0m;
				shopNum1_Payment.Email = this.TextBoxEmail.Text.Trim();
				shopNum1_Payment.IsPercent = 0;
				shopNum1_Payment.Memo = this.TextBoxMemo.Text.Trim();
				shopNum1_Payment.IsCOD = 0;
				shopNum1_Payment.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
				shopNum1_Payment.CreateUser = base.ShopNum1LoginID;
				shopNum1_Payment.CreateTime = DateTime.Now;
				shopNum1_Payment.ModifyUser = base.ShopNum1LoginID;
				shopNum1_Payment.ModifyTime = DateTime.Now;
				shopNum1_Payment.ForAdvancePayment = new int?(Convert.ToInt32(this.RadioButtonListForredepositrecharge.SelectedValue));
				shopNum1_Payment.IsDeleted = 0;
				ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
				int num = shopNum1_Payment_Action.Add(shopNum1_Payment);
				if (num > 0)
				{
					base.OperateLog(new ShopNum1_OperateLog
					{
						Record = "新增" + this.TextBoxName.Text.Trim() + "成功!",
						OperatorID = base.ShopNum1LoginID,
						IP = Globals.IPAddress,
						PageName = "Payment_Operate.aspx",
						Date = DateTime.Now
					});
					this.MessageShow.ShowMessage("AddYes");
					this.MessageShow.Visible = true;
					this.method_6();
				}
				else
				{
					this.MessageShow.ShowMessage("AddNo");
					this.MessageShow.Visible = true;
				}
			}
			else if (this.ButtonConfirm.ToolTip == "Update")
			{
				ShopNum1_Payment shopNum1_Payment = new ShopNum1_Payment();
				shopNum1_Payment.Guid = new Guid(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
				shopNum1_Payment.PaymentType = this.DropDownListPaymentType.SelectedValue;
				shopNum1_Payment.Name = this.TextBoxName.Text.Trim();
				shopNum1_Payment.MerchantCode = this.TextBoxMerchantCode.Text.Trim();
				shopNum1_Payment.SecretKey = this.TextBoxSecretKey.Text.Trim();
				shopNum1_Payment.SecondKey = shopNum1_Payment.SecretKey;
				shopNum1_Payment.Pwd = shopNum1_Payment.SecretKey;
				shopNum1_Payment.Partner = "1";
				shopNum1_Payment.Charge = 0m;
				shopNum1_Payment.Email = this.TextBoxEmail.Text.Trim();
				shopNum1_Payment.Memo = this.TextBoxMemo.Text.Trim();
				shopNum1_Payment.IsPercent = 0;
				shopNum1_Payment.IsCOD = 0;
				shopNum1_Payment.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
				shopNum1_Payment.ModifyUser = base.ShopNum1LoginID;
				shopNum1_Payment.ModifyTime = DateTime.Now;
				shopNum1_Payment.ForAdvancePayment = new int?(Convert.ToInt32(this.RadioButtonListForredepositrecharge.SelectedValue));
				ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
				int num = shopNum1_Payment_Action.Update(shopNum1_Payment, this.hiddenFieldGuid.Value, 0);
				if (num > 0)
				{
					base.OperateLog(new ShopNum1_OperateLog
					{
						Record = "编辑" + this.TextBoxName.Text.Trim() + "成功!",
						OperatorID = base.ShopNum1LoginID,
						IP = Globals.IPAddress,
						PageName = "Payment_Operate.aspx",
						Date = DateTime.Now
					});
					this.MessageShow.ShowMessage("EditYes");
					this.MessageShow.Visible = true;
				}
				else
				{
					this.MessageShow.ShowMessage("EditNo");
					this.MessageShow.Visible = true;
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show("所有带*的编辑框必须填写完整！");
		}
	}
	private void method_6()
	{
		this.TextBoxOrderID.Text = string.Empty;
		this.TextBoxEmail.Text = string.Empty;
		this.TextBoxMemo.Text = string.Empty;
		this.TextBoxMerchantCode.Text = string.Empty;
		this.TextBoxSecretKey.Text = string.Empty;
		this.TextBoxName.Text = string.Empty;
		this.TextBoxOrderID.Text = string.Empty;
	}
	private void method_7()
	{
		ShopNum1_Payment_Action shopNum1_Payment_Action = new ShopNum1_Payment_Action();
		DataTable dataTable = shopNum1_Payment_Action.SearchPayInfo(this.hiddenFieldGuid.Value.ToString(), 0);
		if (dataTable.Rows.Count > 0)
		{
			this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
			this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
			this.DropDownListPaymentType.SelectedValue = dataTable.Rows[0]["PaymentType"].ToString();
			this.TextBoxEmail.Text = dataTable.Rows[0]["Email"].ToString();
			this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
			this.TextBoxMerchantCode.Text = dataTable.Rows[0]["MerchantCode"].ToString();
			this.TextBoxSecretKey.Text = dataTable.Rows[0]["SecretKey"].ToString();
			this.RadioButtonListForredepositrecharge.SelectedValue = dataTable.Rows[0]["ForAdvancePayment"].ToString();
			this.ButtonConfirm.ToolTip = "Update";
			this.ButtonConfirm.Text = "更新";
		}
	}
	private void method_8()
	{
	}
}
