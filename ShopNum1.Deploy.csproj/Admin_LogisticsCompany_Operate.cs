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
public class Admin_LogisticsCompany_Operate : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeName;
	protected TextBox TextBoxName;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxName;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxName;
	protected Localize Localizereplacement;
	protected TextBox TextBoxValueCode;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Localize Localize2;
	protected CheckBox CheckBoxIsShow;
	protected Localize Localize1;
	protected TextBox TextBoxContent;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldCode;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["ID"] == null) ? "0" : base.Request.QueryString["ID"].Replace("'", ""));
		if (!base.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.LabelTitle.Text = "编辑物流公司";
			this.GetEditInfo();
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Logistic_Action shopNum1_Logistic_Action = (ShopNum1_Logistic_Action)LogicFactory.CreateShopNum1_Logistic_Action();
		DataTable logistic = shopNum1_Logistic_Action.GetLogistic(int.Parse(this.hiddenFieldGuid.Value));
		if (logistic != null && logistic.Rows.Count > 0)
		{
			this.TextBoxName.Text = logistic.Rows[0]["Name"].ToString();
			this.HiddenFieldCode.Value = logistic.Rows[0]["ValueCode"].ToString();
			this.TextBoxValueCode.Text = logistic.Rows[0]["ValueCode"].ToString();
			this.TextBoxContent.Text = logistic.Rows[0]["Description"].ToString();
			if (logistic.Rows[0]["IsShow"].ToString() == "1")
			{
				this.CheckBoxIsShow.Checked = true;
			}
			else
			{
				this.CheckBoxIsShow.Checked = false;
			}
		}
	}
	protected void Add()
	{
		ShopNum1_Logistic_Action shopNum1_Logistic_Action = (ShopNum1_Logistic_Action)LogicFactory.CreateShopNum1_Logistic_Action();
		if (!shopNum1_Logistic_Action.Exists(this.TextBoxValueCode.Text.Trim()))
		{
			MessageBox.Show("该物流公司已存在！");
		}
		else
		{
			ShopNum1_Logistic shopNum1_Logistic = new ShopNum1_Logistic();
			shopNum1_Logistic.Name = this.TextBoxName.Text.Trim();
			shopNum1_Logistic.ValueCode = this.TextBoxValueCode.Text.Trim();
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_Logistic.IsShow = 1;
			}
			else
			{
				shopNum1_Logistic.IsShow = 0;
			}
			shopNum1_Logistic.Description = this.TextBoxContent.Text.Trim();
			int num = shopNum1_Logistic_Action.Add(shopNum1_Logistic);
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
	}
	protected void Edit()
	{
		ShopNum1_Logistic_Action shopNum1_Logistic_Action = (ShopNum1_Logistic_Action)LogicFactory.CreateShopNum1_Logistic_Action();
		if (this.HiddenFieldCode.Value != this.TextBoxValueCode.Text.Trim() && !shopNum1_Logistic_Action.Exists(this.TextBoxValueCode.Text.Trim()))
		{
			MessageBox.Show("该物流公司已存在！");
		}
		else
		{
			ShopNum1_Logistic shopNum1_Logistic = new ShopNum1_Logistic();
			shopNum1_Logistic.Name = this.TextBoxName.Text.Trim();
			shopNum1_Logistic.ValueCode = this.TextBoxValueCode.Text.Trim();
			shopNum1_Logistic.Description = this.TextBoxContent.Text.Trim();
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_Logistic.IsShow = 1;
			}
			else
			{
				shopNum1_Logistic.IsShow = 0;
			}
			shopNum1_Logistic.ID = int.Parse(this.hiddenFieldGuid.Value);
			int num = shopNum1_Logistic_Action.Update(shopNum1_Logistic);
			if (num > 0)
			{
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
	protected void ClearControl()
	{
		this.TextBoxName.Text = "";
		this.TextBoxValueCode.Text = "";
		this.TextBoxContent.Text = "";
	}
}
