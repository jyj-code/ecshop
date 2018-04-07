using ShopNum1.Common;
using System;
using System.Configuration;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Admin_UCDiscuz_Settings : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelUnionPostUrl;
	protected TextBox TextBoxDiscuzPostUrl;
	protected RegularExpressionValidator RegularExpressionValidatorLogoUnionPostUrl;
	protected Label LabelApiKey;
	protected TextBox TextBoxUCenterUrl;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label LabelSecret;
	protected TextBox TextBoxSecret;
	protected RegularExpressionValidator RegularExpressionValidatorLogoKey;
	protected Label LabelID;
	protected TextBox TextBoxIDValue;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTextBox;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected Label LabelDomain;
	protected TextBox TextBoxCharset;
	protected RequiredFieldValidator RequiredFieldValidator1;
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
		this.TextBoxDiscuzPostUrl.Text = ConfigurationManager.AppSettings["UC_IP"];
		this.TextBoxUCenterUrl.Text = ConfigurationManager.AppSettings["UC_API"];
		this.TextBoxSecret.Text = ConfigurationManager.AppSettings["UC_KEY"];
		this.TextBoxCharset.Text = ConfigurationManager.AppSettings["UC_CHARSET"];
		this.TextBoxIDValue.Text = ConfigurationManager.AppSettings["UC_APPID"];
		string a = ConfigurationManager.AppSettings["IsIntergrationUCenter"];
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
		XmlDocument xmlDocument = this.method_5();
		string filename = HttpContext.Current.Request.PhysicalApplicationPath + "WebConfig\\AppSettings.config";
		string text = "/appSettings/add[@key='?']";
		XmlNode xmlNode = xmlDocument.SelectSingleNode(text.Replace("?", "UC_IP"));
		XmlNode xmlNode2 = xmlDocument.SelectSingleNode(text.Replace("?", "UC_API"));
		XmlNode xmlNode3 = xmlDocument.SelectSingleNode(text.Replace("?", "UC_KEY"));
		XmlNode xmlNode4 = xmlDocument.SelectSingleNode(text.Replace("?", "UC_CHARSET"));
		XmlNode xmlNode5 = xmlDocument.SelectSingleNode(text.Replace("?", "UC_APPID"));
		XmlNode xmlNode6 = xmlDocument.SelectSingleNode(text.Replace("?", "IsIntergrationUCenter"));
		xmlNode.Attributes["value"].InnerText = this.TextBoxDiscuzPostUrl.Text.Trim();
		xmlNode2.Attributes["value"].InnerText = this.TextBoxUCenterUrl.Text.Trim();
		xmlNode3.Attributes["value"].InnerText = this.TextBoxSecret.Text.Trim();
		xmlNode4.Attributes["value"].InnerText = this.TextBoxCharset.Text.Trim();
		xmlNode5.Attributes["value"].InnerText = this.TextBoxIDValue.Text.Trim();
		if (this.CheckBoxIsIntegration.Checked)
		{
			xmlNode6.Attributes["value"].InnerText = "1";
		}
		else
		{
			xmlNode6.Attributes["value"].InnerText = "0";
		}
		try
		{
			xmlDocument.Save(filename);
			MessageBox.Show("修改成功");
		}
		catch
		{
			MessageBox.Show("修改失败,检查是否有修改权限");
		}
	}
	private XmlDocument method_5()
	{
		XmlDocument xmlDocument = new XmlDocument();
		string filename = HttpContext.Current.Request.PhysicalApplicationPath + "WebConfig\\AppSettings.config";
		xmlDocument.Load(filename);
		return xmlDocument;
	}
	protected void CheckBoxIsIntegration_CheckedChanged(object sender, EventArgs e)
	{
		if (ConfigurationManager.AppSettings["IsIntegrationDiscuz"] == "1")
		{
			this.CheckBoxIsIntegration.Checked = false;
			base.ClientScript.RegisterStartupScript(this.Page.GetType(), "MSG", "<script type='text/javascript'>alert('已集成Discuz，为了系统稳定不能集成UCenter！')</script>", false);
		}
	}
}
