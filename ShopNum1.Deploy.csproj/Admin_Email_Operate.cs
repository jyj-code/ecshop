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
public class Admin_Email_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Localize LocalizeType;
	protected DropDownList DropDownListType;
	protected Localize LocalizeTitle;
	protected TextBox TextBoxTitle;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxTitle;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTitle;
	protected Localize LocalizeDescription;
	protected TextBox TextBoxDescription;
	protected Label Label7;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxDescription;
	protected Label Label2;
	protected Localize LocalizeRemark;
	protected HtmlTextArea FCKeditorRemark;
	protected Label Label6;
	protected Button ButtonConfirm;
	protected Button Button1;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldproduceMemLoginID;
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
			this.BindMenu();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑邮件模板";
				this.GetEditInfo();
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.FCKeditorRemark.Value == string.Empty)
		{
			MessageBox.Show("邮件内容不能为空!");
		}
		else if (this.FCKeditorRemark.Value.Length > 1000)
		{
			MessageBox.Show("你输入的邮件内容长度已经大于1000，<br/>请删减文字！");
		}
		else if (this.ButtonConfirm.ToolTip == "Update")
		{
			this.Edit();
		}
		else if (this.ButtonConfirm.ToolTip == "Submit")
		{
			this.Add();
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
		DataTable editInfo = shopNum1_Email_Action.GetEditInfo(this.hiddenFieldGuid.Value, 0);
		this.DropDownListType.Text = editInfo.Rows[0]["TypeName"].ToString();
		this.FCKeditorRemark.Value = base.Server.HtmlDecode(editInfo.Rows[0]["Remark"].ToString());
		this.TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
		this.TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
	}
	protected void Add()
	{
		ShopNum1_Email shopNum1_Email = new ShopNum1_Email();
		shopNum1_Email.Guid = Guid.NewGuid();
		shopNum1_Email.TypeName = this.DropDownListType.Text.ToString();
		shopNum1_Email.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_Email.Remark = this.FCKeditorRemark.Value;
		shopNum1_Email.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_Email.CreateUser = "admin";
		shopNum1_Email.CreateTime = DateTime.Now;
		shopNum1_Email.ModifyUser = "admin";
		shopNum1_Email.ModifyTime = DateTime.Now;
		shopNum1_Email.IsDeleted = 0;
		ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
		int num = shopNum1_Email_Action.Add(shopNum1_Email);
		if (num > 0)
		{
			this.ClearControl();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Edit()
	{
		ShopNum1_Email shopNum1_Email = new ShopNum1_Email();
		shopNum1_Email.TypeName = this.DropDownListType.Text.ToString();
		shopNum1_Email.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_Email.Remark = base.Server.HtmlEncode(this.FCKeditorRemark.Value.Replace("'", ""));
		shopNum1_Email.Description = base.Server.HtmlEncode(this.TextBoxDescription.Text.Trim());
		shopNum1_Email.ModifyUser = "admin";
		shopNum1_Email.ModifyTime = DateTime.Now;
		ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
		int num = shopNum1_Email_Action.Update(this.hiddenFieldGuid.Value, shopNum1_Email);
		if (num > 0)
		{
			base.Response.Redirect("Email_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ClearControl()
	{
		this.TextBoxTitle.Text = string.Empty;
		this.FCKeditorRemark.Value = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.DropDownListType.SelectedValue = "-1";
	}
	protected void BindMenu()
	{
	}
}
