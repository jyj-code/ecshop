using ShopNum1.Common;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Union_Settings : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelUnionPostUrl;
	protected TextBox TextBoxUnionPostUrl;
	protected RegularExpressionValidator RegularExpressionValidatorLogoUnionPostUrl;
	protected Label LabelKey;
	protected TextBox TextBoxKey;
	protected RegularExpressionValidator RegularExpressionValidatorLogoKey;
	protected Label LabelIsIntergration;
	protected CheckBox CheckBoxIsIntergration;
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
		if (!this.Page.IsPostBack)
		{
			this.GetInfo();
		}
	}
	protected void GetInfo()
	{
		this.TextBoxUnionPostUrl.Text = WebConfigOperate.GetAppSetConfigValue("UnionPostUrl");
		this.TextBoxKey.Text = WebConfigOperate.GetAppSetConfigValue("SourceKey");
		string appSetConfigValue = WebConfigOperate.GetAppSetConfigValue("IsIntergrationUnion");
		if (appSetConfigValue == "1")
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
		string[] array = new string[3];
		string[] array2 = new string[3];
		array[0] = "UnionPostUrl";
		array2[0] = this.TextBoxUnionPostUrl.Text;
		array[1] = "SourceKey";
		array2[1] = this.TextBoxKey.Text;
		array[2] = "IsIntergrationUnion";
		if (this.CheckBoxIsIntergration.Checked)
		{
			array2[2] = "1";
			string a = this.method_5(this.TextBoxUnionPostUrl.Text + "IntergrationCheck.aspx?SourceKey=" + this.TextBoxKey.Text);
			if (a == "0" || a == "")
			{
				MessageBox.Show("联盟系统的地址或是密钥不对！");
			}
			else if (a == "1")
			{
				WebConfigOperate.UpdateAppSetConfigValue(array, array2);
				MessageBox.Show("操作成功！");
			}
		}
		else
		{
			array2[2] = "0";
			WebConfigOperate.UpdateAppSetConfigValue(array, array2);
			MessageBox.Show("操作成功！");
		}
	}
	private string method_5(string string_5)
	{
		string result = string.Empty;
		Encoding encoding = Encoding.GetEncoding("utf-8");
		WebRequest webRequest = WebRequest.Create(string_5);
		webRequest.Timeout = 3000;
		try
		{
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
