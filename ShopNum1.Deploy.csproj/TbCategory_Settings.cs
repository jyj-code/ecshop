using ShopNum1.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class TbCategory_Settings : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelUnionPostUrl;
	protected TextBox TextBoxKey;
	protected Label LabelKey;
	protected TextBox TextBoxUnionPostUrl;
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
		this.TextBoxUnionPostUrl.Text = WebConfigOperate.GetAppSetConfigValue("AdminAppSecret");
		this.TextBoxKey.Text = WebConfigOperate.GetAppSetConfigValue("AdminAppKey");
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		string[] array = new string[2];
		string[] array2 = new string[2];
		array[0] = "AdminAppKey";
		array2[0] = this.TextBoxKey.Text;
		array[1] = "AdminAppSecret";
		array2[1] = this.TextBoxUnionPostUrl.Text;
		WebConfigOperate.UpdateAppSetConfigValue(array, array2);
		MessageBox.Show("操作成功！");
	}
}
