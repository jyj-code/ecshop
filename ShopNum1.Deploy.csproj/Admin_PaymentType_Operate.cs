using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_PaymentType_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label LabelPaymentType;
	protected TextBox TextBoxPaymentType;
	protected Label LabelImageUrl;
	protected Image ImageUrl;
	protected FileUpload FileUploadImage;
	protected Label LabelMemo;
	protected TextBox TextBoxMemo;
	protected Label LabelCharge;
	protected TextBox TextBoxOrderID;
	protected Label LabelIsShopUse;
	protected CheckBox CheckBoxIsShopUse;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldImage;
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
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.LabelPageTitle.Text = "编辑支付类型";
			this.method_5();
		}
	}
	protected string FileUpload(FileUpload ControlName, string ImageName)
	{
		string result;
		if (ControlName.HasFile)
		{
			string fileName = ControlName.PostedFile.FileName;
			FileInfo fileInfo = new FileInfo(fileName);
			string str = "~/ImgUpload/";
			string text = str + "/" + ImageName + fileInfo.Extension;
			string empty = string.Empty;
			if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, text, out empty))
			{
				result = text;
			}
			else
			{
				MessageBox.Show(empty);
				result = "0";
			}
		}
		else
		{
			result = "1";
		}
		return result;
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_PaymentType shopNum1_PaymentType = new ShopNum1_PaymentType();
		if (this.FileUploadImage.HasFile)
		{
			shopNum1_PaymentType.BakcImg = this.FileUpload(this.FileUploadImage, Guid.NewGuid().ToString());
		}
		else
		{
			shopNum1_PaymentType.BakcImg = this.hiddenFieldImage.Value;
		}
		shopNum1_PaymentType.Guid = new Guid(this.hiddenFieldGuid.Value);
		if (this.CheckBoxIsShopUse.Checked)
		{
			shopNum1_PaymentType.IsShopUse = new byte?(1);
		}
		else
		{
			shopNum1_PaymentType.IsShopUse = new byte?(0);
		}
		shopNum1_PaymentType.Memo = this.TextBoxMemo.Text.Trim();
		shopNum1_PaymentType.Name = this.TextBoxName.Text.Trim();
		shopNum1_PaymentType.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
		shopNum1_PaymentType.PaymentType = this.TextBoxPaymentType.Text.Trim();
		try
		{
			ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
			shopNum1_Payment_Action.UpDatePaymentType(shopNum1_PaymentType);
			base.Response.Redirect("PaymentType_List.aspx");
		}
		catch (Exception)
		{
		}
	}
	private void method_5()
	{
		ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
		DataTable dataTable = shopNum1_Payment_Action.SearchTypeByGuid(this.hiddenFieldGuid.Value.ToString());
		this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
		this.TextBoxPaymentType.Text = dataTable.Rows[0]["PaymentType"].ToString();
		this.ImageUrl.ImageUrl = dataTable.Rows[0]["BakcImg"].ToString();
		this.hiddenFieldImage.Value = dataTable.Rows[0]["BakcImg"].ToString();
		this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
		this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
		if (dataTable.Rows[0]["IsShopUse"].ToString() == "1")
		{
			this.CheckBoxIsShopUse.Checked = true;
		}
		else
		{
			this.CheckBoxIsShopUse.Checked = false;
		}
		this.ButtonConfirm.ToolTip = "Update";
		this.ButtonConfirm.Text = "更新";
	}
}
