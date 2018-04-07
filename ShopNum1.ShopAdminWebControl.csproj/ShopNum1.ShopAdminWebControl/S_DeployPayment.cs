using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_DeployPayment : BaseShopWebControl
	{
		private string string_0 = "S_DeployPayment.ascx";
		private HiddenField hiddenField_0;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private CheckBox checkBox_0;
		private TextBox textBox_5;
		private TextBox textBox_6;
		private Button button_0;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private HtmlTableRow htmlTableRow_0;
		private HtmlTableRow htmlTableRow_1;
		private HtmlTableRow htmlTableRow_2;
		public S_DeployPayment()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldType");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxAlipay");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxMerchantCode");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxSecretKey");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxCharge");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckBoxIsPercent");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxMemo");
			this.textBox_6 = (TextBox)skin.FindControl("TextBoxOrderID");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.label_0 = (Label)skin.FindControl("LabelAlipay");
			this.label_1 = (Label)skin.FindControl("LabelMerchantCode");
			this.label_2 = (Label)skin.FindControl("LabelSecretKey");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("tr1");
			this.htmlTableRow_1 = (HtmlTableRow)skin.FindControl("tr2");
			this.htmlTableRow_2 = (HtmlTableRow)skin.FindControl("tr3");
			this.GetOrderID();
			this.HiddleControl();
			if (this.Page.Request.QueryString["type"] != null)
			{
				this.hiddenField_0.Value = this.Page.Request.QueryString["type"].ToString();
				this.GetPaymentData();
			}
			if (this.Page.Request.QueryString["run"] != null)
			{
				if (this.Page.Request.QueryString["run"].ToString() == "edit")
				{
					this.GetAllPaymentData();
					this.button_0.Text = "编辑";
				}
				else if (this.Page.Request.QueryString["run"].ToString() == "add")
				{
					this.button_0.Text = "添加";
				}
			}
		}
		public void GetAllPaymentData()
		{
			ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = (ShopNum1_ShopPayment_Action)LogicFactory.CreateShopNum1_ShopPayment_Action();
			DataTable dataInfo = shopNum1_ShopPayment_Action.GetDataInfo(this.Page.Request.QueryString["type"].ToString(), this.MemLoginID);
			if (dataInfo != null && dataInfo.Rows.Count > 0)
			{
				this.textBox_0.Text = dataInfo.Rows[0]["Name"].ToString();
				this.textBox_1.Text = dataInfo.Rows[0]["Email"].ToString();
				this.textBox_2.Text = dataInfo.Rows[0]["MerchantCode"].ToString();
				this.textBox_3.Text = dataInfo.Rows[0]["SecretKey"].ToString();
				this.textBox_4.Text = dataInfo.Rows[0]["Charge"].ToString();
				if (dataInfo.Rows[0]["IsPercent"].ToString() == "0")
				{
					this.checkBox_0.Checked = false;
				}
				else
				{
					this.checkBox_0.Checked = true;
				}
				this.textBox_5.Text = dataInfo.Rows[0]["Memo"].ToString();
				this.textBox_6.Text = dataInfo.Rows[0]["OrderID"].ToString();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			double num = 0.0;
			if (!double.TryParse(this.textBox_4.Text.Trim(), out num))
			{
				MessageBox.Show("手续费格式错误！");
			}
			else if (this.Page.Request.QueryString["run"] != null)
			{
				if (this.Page.Request.QueryString["run"].ToString() == "add")
				{
					this.Add();
				}
				else if (this.Page.Request.QueryString["run"].ToString() == "edit")
				{
					this.Edit();
				}
			}
			else
			{
				MessageBox.Show("操作错误！");
			}
		}
		public void Edit()
		{
			ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = (ShopNum1_ShopPayment_Action)LogicFactory.CreateShopNum1_ShopPayment_Action();
			DataTable dataInfo = shopNum1_ShopPayment_Action.GetDataInfo(this.Page.Request.QueryString["type"].ToString(), this.MemLoginID);
			Guid guid = Guid.NewGuid();
			if (dataInfo != null && dataInfo.Rows.Count > 0)
			{
				guid = new Guid(dataInfo.Rows[0]["Guid"].ToString());
			}
			ShopNum1_ShopPayment shopNum1_ShopPayment = new ShopNum1_ShopPayment();
			shopNum1_ShopPayment.Guid = guid;
			shopNum1_ShopPayment.PaymentType = this.Page.Request.QueryString["type"].ToString().Replace("'", "");
			shopNum1_ShopPayment.Name = this.textBox_0.Text.Trim();
			shopNum1_ShopPayment.MerchantCode = this.textBox_2.Text.Trim();
			shopNum1_ShopPayment.SecretKey = this.textBox_3.Text.Trim();
			shopNum1_ShopPayment.SecondKey = shopNum1_ShopPayment.SecretKey;
			shopNum1_ShopPayment.Pwd = shopNum1_ShopPayment.SecretKey;
			shopNum1_ShopPayment.Partner = "1";
			if (this.textBox_4.Text.Trim() == string.Empty)
			{
				shopNum1_ShopPayment.Charge = 0m;
			}
			else
			{
				shopNum1_ShopPayment.Charge = Convert.ToDecimal(this.textBox_4.Text.Trim());
			}
			shopNum1_ShopPayment.Email = this.textBox_1.Text.Trim();
			shopNum1_ShopPayment.Memo = this.textBox_5.Text.Trim();
			if (this.checkBox_0.Checked)
			{
				shopNum1_ShopPayment.IsPercent = 1;
			}
			else
			{
				shopNum1_ShopPayment.IsPercent = 0;
			}
			shopNum1_ShopPayment.IsCOD = 0;
			shopNum1_ShopPayment.OrderID = Convert.ToInt32(this.textBox_6.Text.Trim());
			int num = shopNum1_ShopPayment_Action.Update(shopNum1_ShopPayment, guid.ToString(), 0);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_ShowPaymentType.aspx");
			}
			else
			{
				MessageBox.Show("编辑失败！");
			}
		}
		protected void GetOrderID()
		{
			ShopNum1_Common_Action arg_0A_0 = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
			string columnName = "OrderID";
			string tableName = "ShopNum1_ShopPayment";
			this.textBox_6.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
		}
		public void Add()
		{
			ShopNum1_ShopPayment shopNum1_ShopPayment = new ShopNum1_ShopPayment();
			shopNum1_ShopPayment.Guid = Guid.NewGuid();
			shopNum1_ShopPayment.PaymentType = this.Page.Request.QueryString["type"].ToString();
			shopNum1_ShopPayment.Name = this.textBox_0.Text.Trim();
			shopNum1_ShopPayment.MerchantCode = this.textBox_2.Text.Trim();
			shopNum1_ShopPayment.SecretKey = this.textBox_3.Text.Trim();
			shopNum1_ShopPayment.SecondKey = shopNum1_ShopPayment.SecretKey;
			shopNum1_ShopPayment.Pwd = shopNum1_ShopPayment.SecretKey;
			shopNum1_ShopPayment.Partner = "1";
			if (this.textBox_4.Text.Trim() == string.Empty)
			{
				shopNum1_ShopPayment.Charge = 0m;
			}
			else
			{
				shopNum1_ShopPayment.Charge = Convert.ToDecimal(this.textBox_4.Text.Trim());
			}
			shopNum1_ShopPayment.Email = this.textBox_1.Text.Trim();
			shopNum1_ShopPayment.memloginID = this.MemLoginID;
			if (this.checkBox_0.Checked)
			{
				shopNum1_ShopPayment.IsPercent = 1;
			}
			else
			{
				shopNum1_ShopPayment.IsPercent = 0;
			}
			shopNum1_ShopPayment.Memo = this.textBox_5.Text.Trim();
			shopNum1_ShopPayment.IsCOD = 0;
			shopNum1_ShopPayment.OrderID = Convert.ToInt32(this.textBox_6.Text.Trim());
			shopNum1_ShopPayment.IsDeleted = 0;
			ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = (ShopNum1_ShopPayment_Action)LogicFactory.CreateShopNum1_ShopPayment_Action();
			int num = shopNum1_ShopPayment_Action.Add(shopNum1_ShopPayment);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_ShowPaymentType.aspx");
			}
			else
			{
				MessageBox.Show("添加失败！");
			}
		}
		public void GetPaymentData()
		{
			ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
			DataTable dataTable = shopNum1_Payment_Action.PaymentTypeName(this.Page.Request.QueryString["type"].ToString().ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.textBox_0.Text = dataTable.Rows[0]["Name"].ToString();
			}
		}
		public void HiddleControl()
		{
			string text = this.Page.Request.QueryString["type"].ToString();
			string text2 = text;
			switch (text2)
			{
			case "BankTransfer.aspx":
				this.htmlTableRow_0.Visible = false;
				this.htmlTableRow_1.Visible = false;
				this.htmlTableRow_2.Visible = false;
				break;
			case "Alipay2.aspx":
				this.label_1.Text = "合作者身份(PID)：";
				this.label_2.Text = "安全校验码(Key)：";
				break;
			case "Alipay3.aspx":
				this.label_1.Text = "合作者身份(PID)：";
				this.label_2.Text = "安全校验码(Key)：";
				break;
			case "Alipay.aspx":
				this.label_1.Text = "合作者身份(PID)：";
				this.label_2.Text = "安全校验码(Key)：";
				break;
			case "DeliveryPay.aspx":
				this.htmlTableRow_0.Visible = false;
				this.htmlTableRow_1.Visible = false;
				this.htmlTableRow_2.Visible = false;
				break;
			case "Tenpay.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			case "TenpayMed.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			case "YeepaySZX.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			case "Yeepay.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			case "Allbuy.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			case "PreDeposits.aspx":
				this.htmlTableRow_0.Visible = false;
				this.htmlTableRow_1.Visible = false;
				this.htmlTableRow_2.Visible = false;
				break;
			case "PayPal.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			case "Send.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			case "NetPayClient.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			case "IcardPay.aspx":
				this.htmlTableRow_0.Visible = false;
				break;
			}
		}
	}
}
