using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopVedioCommentChecked_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxTitle;
	protected Label LabelWebSite;
	protected TextBox TextBoxTime;
	protected Label LabelOrderID;
	protected TextBox TextBoxUser;
	protected Label LabelLogo;
	protected TextBox TextBoxIP;
	protected Label LabelKeywords;
	protected TextBox TextBoxVideo;
	protected Label Label1;
	protected TextBox TextBoxMember;
	protected Label LabelRemark;
	protected TextBox TextBoxContent;
	protected Button ButtonBack;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_5;
	private string GoBack
	{
		get;
		set;
	}
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
		this.GoBack = ((base.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"]);
		ShopNum1_VedioCommentChecked_Action shopNum1_VedioCommentChecked_Action = (ShopNum1_VedioCommentChecked_Action)LogicFactory.CreateShopNum1_VedioCommentChecked_Action();
		DataTable dataTable = shopNum1_VedioCommentChecked_Action.SearchByGuid(this.hiddenFieldGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxContent.Text = dataTable.Rows[0]["Comment"].ToString();
			this.TextBoxTitle.Text = dataTable.Rows[0]["Title"].ToString();
			this.TextBoxTime.Text = dataTable.Rows[0]["CommentTime"].ToString();
			this.TextBoxUser.Text = dataTable.Rows[0]["MemLoginID"].ToString();
			this.TextBoxIP.Text = dataTable.Rows[0]["IPAddress"].ToString();
			this.TextBoxVideo.Text = dataTable.Rows[0]["Name"].ToString();
			this.TextBoxMember.Text = ShopSettings.GetValue("PersonShopUrl") + dataTable.Rows[0]["ShopID"].ToString();
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.GoBack == "List")
		{
			base.Response.Redirect("ShopVedioComment_List.aspx");
		}
		else
		{
			base.Response.Redirect("ShopVedioCommentChecked_List.aspx");
		}
	}
}
