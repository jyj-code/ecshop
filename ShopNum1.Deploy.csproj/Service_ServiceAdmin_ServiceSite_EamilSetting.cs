using ShopNum1.Common;
using ShopNum1.Email;
using System;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Service_ServiceAdmin_ServiceSite_EamilSetting : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Localize Localize1;
	protected DropDownList selectSendType;
	protected Localize Localize2;
	protected TextBox txtSmtpServer;
	protected Localize LocalizeEmailServer;
	protected TextBox TextBoxServerPort;
	protected Localize Localize3;
	protected CheckBox cbSSL;
	protected Localize LocalizeEmailAccount;
	protected TextBox TextBoxEmailAccount;
	protected Localize LocalizeEmailPassword;
	protected HtmlInputPassword TextBoxEmailPassword;
	protected Localize LocalizeRestoreEmail;
	protected TextBox TextBoxRestoreEmail;
	protected Localize LocalizeEmailCode;
	protected CheckBoxList CheckBoxListEmailCode;
	protected Localize LocalizeEmailAddress;
	protected HtmlInputText TextBoxEmailAddress;
	protected Button ButtonSend;
	protected Button ButtonEdit;
	protected MessageShow MessageShow;
	protected HiddenField HiddenFieldXmlPath;
	protected HiddenField HidPassword;
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
		if (!this.Page.IsPostBack)
		{
			this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
			this.BindEmailCode();
			this.BindSetting();
		}
	}
	protected void BindEmailCode()
	{
		this.CheckBoxListEmailCode.Items.Add(new ListItem("默认编码", "0"));
	}
	protected void BindSetting()
	{
		XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
		foreach (XmlNode xmlNode in xmlNodeList)
		{
			foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
			{
				string name = xmlNode2.Name;
				switch (name)
				{
				case "EmailServer":
					this.selectSendType.SelectedValue = xmlNode2.InnerText;
					break;
				case "SSL":
					if (xmlNode2.InnerText == "1")
					{
						this.cbSSL.Checked = true;
					}
					break;
				case "SMTP":
					this.txtSmtpServer.Text = xmlNode2.InnerText;
					break;
				case "ServerPort":
					this.TextBoxServerPort.Text = xmlNode2.InnerText;
					break;
				case "EmailAccount":
					this.TextBoxEmailAccount.Text = xmlNode2.InnerText;
					break;
				case "EmailPassword":
					this.HidPassword.Value = Encryption.Decrypt(xmlNode2.InnerText);
					this.TextBoxEmailPassword.Value = Encryption.Decrypt(xmlNode2.InnerText);
					break;
				case "RestoreEmail":
					this.TextBoxRestoreEmail.Text = xmlNode2.InnerText;
					break;
				case "EmailCode":
					this.CheckBoxListEmailCode.SelectedValue = xmlNode2.InnerText;
					break;
				}
			}
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		int num = 1;
		try
		{
			this.Updata();
		}
		catch (Exception)
		{
			num = 0;
		}
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
			ShopSettings.ResetShopSetting();
			this.TextBoxEmailAddress.Value = "";
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Updata()
	{
		this.HidPassword.Value = this.TextBoxEmailPassword.Value;
		if (!this.cbSSL.Checked)
		{
		}
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/EmailServer", this.selectSendType.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/SMTP", this.txtSmtpServer.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ServerPort", this.TextBoxServerPort.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/EmailAccount", this.TextBoxEmailAccount.Text);
		if (this.TextBoxEmailPassword.Value != "")
		{
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/EmailPassword", Encryption.Encrypt(this.TextBoxEmailPassword.Value));
		}
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/RestoreEmail", this.TextBoxRestoreEmail.Text);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/EmailCode", this.CheckBoxListEmailCode.SelectedValue);
		ShopSettings.ResetShopSetting();
	}
	protected bool FileUpload(FileUpload fileUpload, string filepath, out string strext)
	{
		new Random();
		string fileName = fileUpload.PostedFile.FileName;
		FileInfo fileInfo = new FileInfo(fileName);
		string text = "~/Upload/";
		fileName.Substring(fileName.LastIndexOf(".") + 1);
		string arg_3E_0 = fileUpload.PostedFile.ContentType;
		int contentLength = fileUpload.PostedFile.ContentLength;
		bool result;
		if (fileName != "")
		{
			if (contentLength < 1024000)
			{
				if (!Directory.Exists(base.Server.MapPath(text)))
				{
					Directory.CreateDirectory(base.Server.MapPath(text));
				}
				fileUpload.PostedFile.SaveAs(base.Server.MapPath(text + fileInfo.Name));
				strext = fileName;
				result = true;
			}
			else
			{
				strext = "文件不能大于1M！";
				result = false;
			}
		}
		else
		{
			strext = "upload 为空！";
			result = false;
		}
		return result;
	}
	protected void ButtonSend_Click(object sender, EventArgs e)
	{
		if (!new NetMail
		{
			RecipientEmail = this.TextBoxEmailAddress.Value.Trim(),
			Subject = "发送邮件测试",
			Body = "邮件发送成功！"
		}.Send())
		{
			MessageBox.Show("发送失败！请检查系统邮箱和测试邮箱配置是否正确！");
		}
		else
		{
			MessageBox.Show("发送成功!");
			this.TextBoxEmailAddress.Value = "";
		}
	}
}
