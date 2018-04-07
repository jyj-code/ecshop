using ShopNum1.Common;
using ShopNum1.Second;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Third_loginOperate : PageBase, IRequiresSessionState
{
	private ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness_0 = new ShopNum1_SecondTypeBussiness();
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelID;
	protected TextBox TextBoxID;
	protected HtmlTableRow trID;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label LabelAppID;
	protected TextBox TextBoxAppID;
	protected Label Label8;
	protected RequiredFieldValidator RequiredFieldValidatorAppID;
	protected RegularExpressionValidator RegularExpressionValidatorAppID;
	protected Label LabelSecretKey;
	protected TextBox TextBoxSecretKey;
	protected RegularExpressionValidator RegularExpressionValidatorSecretKey;
	protected RequiredFieldValidator RequiredFieldValidatorSecretKey;
	protected Label LabelredirectURL;
	protected TextBox TextBoxRedirectURL;
	protected Label LabelMemo;
	protected TextBox TextBoxMemo;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxMemo;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label7;
	protected RegularExpressionValidator RegularExpressionValidatorOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected Label LabelAvailable;
	protected RadioButtonList RadioButtonListAvailable;
	protected Label LabelImg;
	protected FileUpload FileUploadImgSrc;
	protected Image ImageSrc;
	protected Button ButtonConfirm;
	protected Button Button3;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"]);
		if (!this.Page.IsPostBack)
		{
			this.GetOrderID();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑第三方账户";
				this.method_6();
				this.ButtonConfirm.ToolTip = "Update";
			}
			else
			{
				this.ButtonConfirm.ToolTip = "Submit";
			}
		}
	}
	protected void GetOrderID()
	{
		this.TextBoxOrderID.Text = this.shopNum1_SecondTypeBussiness_0.GetMaxOrderId().ToString();
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			ShopNum1_SecondType shopNum1_SecondType = new ShopNum1_SecondType();
			shopNum1_SecondType.TypeName = this.TextBoxName.Text.Trim();
			shopNum1_SecondType.AppID = this.TextBoxAppID.Text.Trim();
			shopNum1_SecondType.AppSecret = this.TextBoxSecretKey.Text.Trim();
			if (this.RadioButtonListAvailable.SelectedValue == "1")
			{
				shopNum1_SecondType.isAvabile = 1;
			}
			else
			{
				shopNum1_SecondType.isAvabile = 0;
			}
			shopNum1_SecondType.content = this.TextBoxMemo.Text.Trim();
			shopNum1_SecondType.redirectURL = this.TextBoxRedirectURL.Text.Trim();
			shopNum1_SecondType.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			if (this.FileUploadImgSrc.HasFile)
			{
				string empty = string.Empty;
				if (!ShopNum1UpLoad.ImageUpLoad(this.FileUploadImgSrc, "~/ImgUpload/", out empty, false))
				{
					MessageBox.Show(empty);
					return;
				}
				shopNum1_SecondType.ImgSrc = empty;
			}
			if (this.shopNum1_SecondTypeBussiness_0.Add(shopNum1_SecondType))
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "新增" + this.TextBoxName.Text.Trim() + "成功!",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "Third_loginOperate.aspx",
					Date = DateTime.Now
				});
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
				this.method_5();
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
		else if (this.ButtonConfirm.ToolTip == "Update")
		{
			ShopNum1_SecondType shopNum1_SecondType = new ShopNum1_SecondType();
			shopNum1_SecondType.ID = int.Parse(this.hiddenFieldGuid.Value.Trim());
			shopNum1_SecondType.TypeName = this.TextBoxName.Text.Trim();
			shopNum1_SecondType.AppID = this.TextBoxAppID.Text.Trim();
			shopNum1_SecondType.AppSecret = this.TextBoxSecretKey.Text.Trim();
			if (this.RadioButtonListAvailable.SelectedValue == "1")
			{
				shopNum1_SecondType.isAvabile = 1;
			}
			else
			{
				shopNum1_SecondType.isAvabile = 0;
			}
			shopNum1_SecondType.content = this.TextBoxMemo.Text.Trim();
			shopNum1_SecondType.redirectURL = this.TextBoxRedirectURL.Text.Trim();
			shopNum1_SecondType.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			shopNum1_SecondType.ImgSrc = this.ImageSrc.ImageUrl;
			if (this.FileUploadImgSrc.HasFile)
			{
				string empty = string.Empty;
				if (!ShopNum1UpLoad.ImageUpLoad(this.FileUploadImgSrc, "~/ImgUpload/", out empty, false))
				{
					MessageBox.Show(empty);
					return;
				}
				shopNum1_SecondType.ImgSrc = empty;
				if (File.Exists(this.Page.Server.MapPath(this.ImageSrc.ImageUrl)))
				{
					File.Delete(this.Page.Server.MapPath(this.ImageSrc.ImageUrl));
				}
			}
			if (this.shopNum1_SecondTypeBussiness_0.Update(shopNum1_SecondType))
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "编辑" + this.TextBoxName.Text.Trim() + "成功!",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "Third_loginOperate.aspx",
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
	private void method_5()
	{
		this.TextBoxName.Text = "";
	}
	private void method_6()
	{
		this.trID.Visible = true;
		DataTable model = this.shopNum1_SecondTypeBussiness_0.GetModel(int.Parse(this.hiddenFieldGuid.Value.Trim()));
		this.TextBoxName.Text = model.Rows[0]["TypeName"].ToString();
		this.TextBoxOrderID.Text = model.Rows[0]["OrderID"].ToString();
		this.TextBoxAppID.Text = model.Rows[0]["AppID"].ToString();
		this.TextBoxSecretKey.Text = model.Rows[0]["AppSecret"].ToString();
		this.TextBoxMemo.Text = model.Rows[0]["content"].ToString();
		this.TextBoxRedirectURL.Text = model.Rows[0]["redirectURL"].ToString();
		this.TextBoxID.Text = model.Rows[0]["ID"].ToString();
		this.RadioButtonListAvailable.SelectedValue = model.Rows[0]["isAvabile"].ToString();
		this.ImageSrc.ImageUrl = model.Rows[0]["ImgSrc"].ToString();
		this.ButtonConfirm.ToolTip = "Update";
		this.ButtonConfirm.Text = "更新";
	}
	private void method_7()
	{
	}
}
