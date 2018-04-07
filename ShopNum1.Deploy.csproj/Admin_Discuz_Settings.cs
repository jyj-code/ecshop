using ShopNum1.Common;
using ShopNum1.DiscuzHelper;
using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Discuz_Settings : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Label LabelUnionPostUrl;
	protected TextBox TextBoxDiscuzPostUrl;
	protected RegularExpressionValidator RegularExpressionValidatorLogoUnionPostUrl;
	protected Label LabelApiKey;
	protected TextBox TextBoxApiKey;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label LabelSecret;
	protected TextBox TextBoxSecret;
	protected RegularExpressionValidator RegularExpressionValidatorLogoKey;
	protected Label LabelDomain;
	protected TextBox TextBoxDomain;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Label LabelIsIntegration;
	protected CheckBox CheckBoxIsIntegration;
	protected Button ButtonConfirm;
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
		if (!base.IsPostBack)
		{
			this.GetInfo();
		}
	}
	protected void GetInfo()
	{
		this.TextBoxDiscuzPostUrl.Text = ConfigurationManager.AppSettings["DiscuzPostUrl"];
		this.TextBoxApiKey.Text = ConfigurationManager.AppSettings["DiscuzApiKey"];
		this.TextBoxSecret.Text = ConfigurationManager.AppSettings["DiscuzSecret"];
		this.TextBoxDomain.Text = ConfigurationManager.AppSettings["DiscuzCookieDomain"];
		string a = ConfigurationManager.AppSettings["IsIntegrationDiscuz"];
		if (a == "1")
		{
			this.CheckBoxIsIntegration.Checked = true;
		}
		else
		{
			this.CheckBoxIsIntegration.Checked = false;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		Configuration configuration = WebConfigurationManager.OpenWebConfiguration(base.Request.ApplicationPath);
		AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
		appSettingsSection.Settings["DiscuzPostUrl"].Value = this.TextBoxDiscuzPostUrl.Text;
		appSettingsSection.Settings["DiscuzApiKey"].Value = this.TextBoxApiKey.Text;
		appSettingsSection.Settings["DiscuzSecret"].Value = this.TextBoxSecret.Text;
		appSettingsSection.Settings["DiscuzCookieDomain"].Value = this.TextBoxDomain.Text;
		if (this.CheckBoxIsIntegration.Checked)
		{
			appSettingsSection.Settings["IsIntegrationDiscuz"].Value = "1";
		}
		else
		{
			appSettingsSection.Settings["IsIntegrationDiscuz"].Value = "0";
		}
		try
		{
			DiscuzSessionHelper.GetSession();
			configuration.Save();
			MessageBox.Show("修改成功");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	protected void CheckBoxIsIntegration_CheckedChanged(object sender, EventArgs e)
	{
		if (ConfigurationManager.AppSettings["IsIntergrationUCenter"] == "1")
		{
			this.CheckBoxIsIntegration.Checked = false;
			base.ClientScript.RegisterStartupScript(this.Page.GetType(), "MSG", "<script type='text/javascript'>alert('已集成UCenter，为了系统的稳定不要同时集成Discuz！')</script>", false);
		}
	}
}
