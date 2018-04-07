using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SensitiveWordsSeting_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeName;
	protected TextBox TextBoxName;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxName;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxName;
	protected Localize Localizereplacement;
	protected TextBox TextBoxreplacement;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Button ButtonConfirm;
	protected Button Button1;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	private string string_5 = string.Empty;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["ID"] == null) ? "0" : base.Request.QueryString["ID"].Replace("'", ""));
		this.string_5 = ((base.Request.QueryString["type"] == null) ? "0" : base.Request.QueryString["type"]);
		if (!base.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.LabelTitle.Text = "编辑敏感字";
			this.GetEditInfo();
			this.ButtonConfirm.Text = "更新";
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
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
		ShopNum1_BadWord_Action shopNum1_BadWord_Action = (ShopNum1_BadWord_Action)LogicFactory.CreateShopNum1_BadWord_Action();
		DataTable dataTable = shopNum1_BadWord_Action.Edit(int.Parse(this.hiddenFieldGuid.Value));
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxName.Text = dataTable.Rows[0]["find"].ToString();
			this.TextBoxreplacement.Text = dataTable.Rows[0]["replacement"].ToString();
		}
	}
	protected void Add()
	{
		ShopNum1_BadWords shopNum1_BadWords = new ShopNum1_BadWords();
		shopNum1_BadWords.CreateUser = "admin";
		shopNum1_BadWords.find = this.TextBoxName.Text;
		shopNum1_BadWords.replacement = this.TextBoxreplacement.Text;
		ShopNum1_BadWord_Action shopNum1_BadWord_Action = (ShopNum1_BadWord_Action)LogicFactory.CreateShopNum1_BadWord_Action();
		int num = shopNum1_BadWord_Action.Add(shopNum1_BadWords);
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
		ShopNum1_BadWords shopNum1_BadWords = new ShopNum1_BadWords();
		shopNum1_BadWords.CreateUser = "admin";
		shopNum1_BadWords.find = this.TextBoxName.Text;
		shopNum1_BadWords.id = int.Parse(this.hiddenFieldGuid.Value);
		shopNum1_BadWords.replacement = this.TextBoxreplacement.Text;
		ShopNum1_BadWord_Action shopNum1_BadWord_Action = (ShopNum1_BadWord_Action)LogicFactory.CreateShopNum1_BadWord_Action();
		int num = shopNum1_BadWord_Action.Updata(shopNum1_BadWords);
		if (num > 0)
		{
			base.Response.Redirect("SensitiveWordsSeting.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ClearControl()
	{
		this.TextBoxName.Text = "";
		this.TextBoxreplacement.Text = "";
	}
	protected void ButtonReset_Click(object sender, EventArgs e)
	{
		this.ClearControl();
	}
}
