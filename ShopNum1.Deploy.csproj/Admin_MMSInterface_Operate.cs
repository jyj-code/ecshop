using ShopNum1.Common;
using ShopNum1.Standard;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_MMSInterface_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected DropDownList DropDownListType;
	protected Label Label1;
	protected CompareValidator CompareFatherCateGory;
	protected Label Label3;
	protected TextBox TextBoxCode;
	protected Label Label7;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Panel PanelType;
	protected Label Label4;
	protected TextBox TextBoxName;
	protected Label Label5;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label Label6;
	protected TextBox TextBoxPwd;
	protected Label Label2;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected TextBox txtTel;
	protected Button butTest;
	protected TextBox txtRc;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	public string StrPath = HttpContext.Current.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
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
		if (!base.IsPostBack)
		{
			this.BindSetting();
		}
	}
	protected void BindSetting()
	{
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(base.Server.MapPath("~/Settings/ShopSetting.xml"));
		DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
		this.DropDownListType.SelectedValue = dataRow["MMSType"].ToString();
		if (this.DropDownListType.SelectedValue == "0")
		{
			this.TextBoxCode.Text = dataRow["Ecode"].ToString();
			this.TextBoxName.Text = dataRow["UserName"].ToString();
			this.TextBoxPwd.Text = dataRow["PassWord"].ToString();
		}
		else if (this.DropDownListType.SelectedValue == "1")
		{
			this.PanelType.Visible = true;
			this.TextBoxCode.Text = dataRow["Ecode"].ToString();
			this.TextBoxName.Text = dataRow["UserName"].ToString();
			this.TextBoxPwd.Text = dataRow["PassWord"].ToString();
		}
		else if (this.DropDownListType.SelectedValue == "2")
		{
			this.PanelType.Visible = false;
			this.TextBoxName.Text = dataRow["SMSUser"].ToString();
			this.TextBoxPwd.Text = dataRow["SMSPass"].ToString();
		}
		else if (this.DropDownListType.SelectedValue == "3")
		{
			this.PanelType.Visible = false;
			this.TextBoxName.Text = dataRow["SmsbaoUser"].ToString();
			this.TextBoxPwd.Text = dataRow["SmsbaoPass"].ToString();
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/MMSType", this.DropDownListType.SelectedValue);
		if (this.DropDownListType.SelectedValue == "0")
		{
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/Ecode", this.TextBoxCode.Text);
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/UserName", this.TextBoxName.Text);
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/PassWord", Encryption.Encrypt(this.TextBoxPwd.Text));
		}
		else if (this.DropDownListType.SelectedValue == "1")
		{
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/Ecode", this.TextBoxCode.Text);
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/UserName", this.TextBoxName.Text);
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/PassWord", Encryption.Encrypt(this.TextBoxPwd.Text));
		}
		else if (this.DropDownListType.SelectedValue == "2")
		{
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/SMSUser", this.TextBoxName.Text);
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/SMSPass", Encryption.Encrypt(this.TextBoxPwd.Text));
		}
		else if (this.DropDownListType.SelectedValue == "3")
		{
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/SmsbaoUser", this.TextBoxName.Text);
			XmlOperator.XmlNodeReplace(this.StrPath, "ShopSetting/SmsbaoPass", Encryption.Encrypt(this.TextBoxPwd.Text));
		}
		this.BindSetting();
		this.MessageShow.ShowMessage("EditYes");
		this.MessageShow.Visible = true;
	}
	protected void butTest_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.txtTel.Text))
		{
			MessageBox.Show("手机号码不能为空！");
		}
		else
		{
			SMS sMS = new SMS();
			string empty = string.Empty;
			sMS.Send(this.txtTel.Text, Operator.FilterString(this.txtRc.Text), out empty);
			if (empty.IndexOf("发送成功") != -1)
			{
				this.MessageShow.ShowMessage("发送成功！");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage(empty);
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.PanelType.Visible = false;
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(base.Server.MapPath("~/Settings/ShopSetting.xml"));
		DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
		if (this.DropDownListType.SelectedValue == "0")
		{
			this.TextBoxName.Text = dataRow["UserName"].ToString();
			this.TextBoxPwd.Text = dataRow["PassWord"].ToString();
		}
		else if (this.DropDownListType.SelectedValue == "1")
		{
			this.PanelType.Visible = true;
			this.TextBoxCode.Text = dataRow["Ecode"].ToString();
			this.TextBoxName.Text = dataRow["UserName"].ToString();
			this.TextBoxPwd.Text = dataRow["PassWord"].ToString();
		}
		else if (this.DropDownListType.SelectedValue == "2")
		{
			this.TextBoxName.Text = dataRow["SMSUser"].ToString();
			this.TextBoxPwd.Text = dataRow["SMSPass"].ToString();
		}
		else if (this.DropDownListType.SelectedValue == "3")
		{
			this.TextBoxName.Text = dataRow["SmsbaoUser"].ToString();
			this.TextBoxPwd.Text = dataRow["SmsbaoPass"].ToString();
		}
	}
}
