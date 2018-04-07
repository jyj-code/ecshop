using ShopNum1.Common;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Tg_Settings : PageBase, IRequiresSessionState
{
	protected Label Label1;
	protected Label LabelUnionPostUrl;
	protected TextBox TextBoxUnionPostUrl;
	protected RegularExpressionValidator RegularExpressionValidatorLogoUnionPostUrl;
	protected Label LabelKey;
	protected TextBox TextBoxKey;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label LabelIsIntergration;
	protected CheckBox CheckBoxIsIntergration;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
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
			this.GetInfo();
		}
	}
	protected void GetInfo()
	{
		this.TextBoxUnionPostUrl.Text = ConfigurationManager.AppSettings["TgPostUrl"];
		this.TextBoxKey.Text = ConfigurationManager.AppSettings["TgSourceKey"];
		string a = ConfigurationManager.AppSettings["IsIntergrationTg"];
		if (a == "1")
		{
			this.CheckBoxIsIntergration.Checked = true;
		}
		else
		{
			this.CheckBoxIsIntergration.Checked = false;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		Configuration configuration = WebConfigurationManager.OpenWebConfiguration(base.Request.ApplicationPath);
		AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
		appSettingsSection.Settings["TgPostUrl"].Value = this.TextBoxUnionPostUrl.Text;
		appSettingsSection.Settings["TgSourceKey"].Value = this.TextBoxKey.Text;
		if (this.CheckBoxIsIntergration.Checked)
		{
			appSettingsSection.Settings["IsIntergrationTg"].Value = "1";
			string a = this.method_5(appSettingsSection.Settings["TgPostUrl"].Value + "IntergrationCheck.aspx?TgSourceKey=" + appSettingsSection.Settings["TgSourceKey"].Value);
			if (a == "0")
			{
				MessageBox.Show("团购系统的地址或是密钥不对！");
			}
			else if (a == "1")
			{
				MessageBox.Show("操作成功！");
				configuration.Save();
			}
			else
			{
				MessageBox.Show("团购系统的地址或是密钥不对！");
			}
		}
		else
		{
			appSettingsSection.Settings["IsIntergrationTg"].Value = "0";
			MessageBox.Show("操作成功！");
			configuration.Save();
		}
	}
	private string method_5(string string_5)
	{
		string result = string.Empty;
		Encoding encoding = Encoding.GetEncoding("utf-8");
		WebRequest webRequest = WebRequest.Create(string_5);
		try
		{
			webRequest.Timeout = 2000;
			WebResponse response = webRequest.GetResponse();
			StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
			result = streamReader.ReadToEnd();
		}
		catch (Exception)
		{
			result = "";
		}
		return result;
	}
}
