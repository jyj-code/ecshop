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
public class Main_Admin_MobilePayment_Operate : PageBase, IRequiresSessionState
{
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
	protected Label Label3;
	protected TextBox txtPrivateKey;
	protected Label Label5;
	protected TextBox txtPublicKey;
	protected Label LabelCharge;
	protected TextBox TextBoxCharge;
	protected Label Label4;
	protected CheckBox CheckBoxIsPercent;
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
				ShopNum1_MobilePayment shopNum1_MobilePayment = new ShopNum1_MobilePayment();
				shopNum1_MobilePayment.Guid = Guid.NewGuid();
				shopNum1_MobilePayment.PaymentType = this.DropDownListPaymentType.SelectedValue;
				shopNum1_MobilePayment.Name = this.TextBoxName.Text.Trim();
				shopNum1_MobilePayment.MerchantCode = this.TextBoxMerchantCode.Text.Trim();
				shopNum1_MobilePayment.SecretKey = this.TextBoxSecretKey.Text.Trim();
				shopNum1_MobilePayment.SecondKey = shopNum1_MobilePayment.SecretKey;
				shopNum1_MobilePayment.Pwd = shopNum1_MobilePayment.SecretKey;
				shopNum1_MobilePayment.public_key = this.txtPublicKey.Text;
				shopNum1_MobilePayment.private_key = this.txtPrivateKey.Text;
				shopNum1_MobilePayment.paytype = "0";
				shopNum1_MobilePayment.Partner = "1";
				shopNum1_MobilePayment.Charge = 0m;
				shopNum1_MobilePayment.Email = this.TextBoxEmail.Text.Trim();
				if (this.CheckBoxIsPercent.Checked)
				{
					shopNum1_MobilePayment.IsPercent = 1;
				}
				else
				{
					shopNum1_MobilePayment.IsPercent = 0;
				}
				shopNum1_MobilePayment.Memo = this.TextBoxMemo.Text.Trim();
				shopNum1_MobilePayment.IsCOD = 0;
				shopNum1_MobilePayment.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
				shopNum1_MobilePayment.CreateUser = base.ShopNum1LoginID;
				shopNum1_MobilePayment.CreateTime = DateTime.Now;
				shopNum1_MobilePayment.ModifyUser = base.ShopNum1LoginID;
				shopNum1_MobilePayment.ModifyTime = DateTime.Now;
				shopNum1_MobilePayment.ForAdvancePayment = new int?(Convert.ToInt32(this.RadioButtonListForredepositrecharge.SelectedValue));
				shopNum1_MobilePayment.IsDeleted = 0;
				ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
				int num = shopNum1_Payment_Action.AddMobile(shopNum1_MobilePayment);
				if (num > 0)
				{
					base.OperateLog(new ShopNum1_OperateLog
					{
						Record = "新增" + this.TextBoxName.Text.Trim() + "成功!",
						OperatorID = base.ShopNum1LoginID,
						IP = Globals.IPAddress,
						PageName = "MobilePayment_Operate.aspx",
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
				ShopNum1_MobilePayment shopNum1_MobilePayment = new ShopNum1_MobilePayment();
				shopNum1_MobilePayment.Guid = new Guid(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
				shopNum1_MobilePayment.PaymentType = this.DropDownListPaymentType.SelectedValue;
				shopNum1_MobilePayment.Name = this.TextBoxName.Text.Trim();
				shopNum1_MobilePayment.MerchantCode = this.TextBoxMerchantCode.Text.Trim();
				shopNum1_MobilePayment.SecretKey = this.TextBoxSecretKey.Text.Trim();
				shopNum1_MobilePayment.SecondKey = shopNum1_MobilePayment.SecretKey;
				shopNum1_MobilePayment.Pwd = shopNum1_MobilePayment.SecretKey;
				shopNum1_MobilePayment.Partner = "1";
				shopNum1_MobilePayment.Charge = 0m;
				shopNum1_MobilePayment.Email = this.TextBoxEmail.Text.Trim();
				shopNum1_MobilePayment.Memo = this.TextBoxMemo.Text.Trim();
				if (this.CheckBoxIsPercent.Checked)
				{
					shopNum1_MobilePayment.IsPercent = 1;
				}
				else
				{
					shopNum1_MobilePayment.IsPercent = 0;
				}
				shopNum1_MobilePayment.IsCOD = 0;
				shopNum1_MobilePayment.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
				shopNum1_MobilePayment.ModifyUser = base.ShopNum1LoginID;
				shopNum1_MobilePayment.ModifyTime = DateTime.Now;
				shopNum1_MobilePayment.private_key = this.txtPrivateKey.Text;
				shopNum1_MobilePayment.public_key = this.txtPublicKey.Text;
				shopNum1_MobilePayment.paytype = "0";
				shopNum1_MobilePayment.ForAdvancePayment = new int?(Convert.ToInt32(this.RadioButtonListForredepositrecharge.SelectedValue));
				ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
				int num = shopNum1_Payment_Action.UpdateMobile(shopNum1_MobilePayment, this.hiddenFieldGuid.Value, 0);
				if (num > 0)
				{
					base.OperateLog(new ShopNum1_OperateLog
					{
						Record = "编辑" + this.TextBoxName.Text.Trim() + "成功!",
						OperatorID = base.ShopNum1LoginID,
						IP = Globals.IPAddress,
						PageName = "MobilePayment_Operate.aspx",
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
		this.TextBoxCharge.Text = string.Empty;
		this.TextBoxMemo.Text = string.Empty;
		this.TextBoxMerchantCode.Text = string.Empty;
		this.TextBoxSecretKey.Text = string.Empty;
		this.TextBoxName.Text = string.Empty;
		this.TextBoxOrderID.Text = string.Empty;
		this.CheckBoxIsPercent.Checked = false;
	}
	private void method_7()
	{
		ShopNum1_Payment_Action shopNum1_Payment_Action = new ShopNum1_Payment_Action();
		DataTable dataTable = shopNum1_Payment_Action.SearchPayInfoMobile(this.hiddenFieldGuid.Value.ToString(), 0);
		this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
		this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
		this.DropDownListPaymentType.SelectedValue = dataTable.Rows[0]["PaymentType"].ToString();
		this.TextBoxEmail.Text = dataTable.Rows[0]["Email"].ToString();
		this.TextBoxCharge.Text = dataTable.Rows[0]["Charge"].ToString();
		this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
		this.TextBoxMerchantCode.Text = dataTable.Rows[0]["MerchantCode"].ToString();
		this.txtPrivateKey.Text = dataTable.Rows[0]["private_key"].ToString();
		this.txtPublicKey.Text = dataTable.Rows[0]["public_key"].ToString();
		this.TextBoxSecretKey.Text = dataTable.Rows[0]["public_key"].ToString();
		this.RadioButtonListForredepositrecharge.SelectedValue = dataTable.Rows[0]["ForAdvancePayment"].ToString();
		if (dataTable.Rows[0]["IsPercent"].ToString() == "0")
		{
			this.CheckBoxIsPercent.Checked = false;
		}
		else
		{
			this.CheckBoxIsPercent.Checked = true;
		}
		this.ButtonConfirm.ToolTip = "Update";
		this.ButtonConfirm.Text = "更新";
	}
	private void method_8()
	{
	}
}
