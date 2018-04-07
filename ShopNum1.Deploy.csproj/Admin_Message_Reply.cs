using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Message_Reply : PageBase, IRequiresSessionState
{
	private string string_5 = string.Empty;
	protected Label LabelTitle;
	protected Localize LocalizeName;
	protected Label LabelMemLoginIDValue;
	protected Label LabelMeaageType;
	protected Label LabelMeaageTypeValue;
	protected Label Label1;
	protected Label LabelTitleValue;
	protected Label LabelSendTime;
	protected Label LabelSendTimeValue;
	protected Label LabelReplyUser;
	protected Label LabelReplyUserValue;
	protected Label LabelReplyTime;
	protected Label LabelReplyTimeValue;
	protected Label LabelIsReply;
	protected Label LabelIsReplyValue;
	protected Label LabelContent;
	protected TextBox TextBoxContent;
	protected Label LabelReplyContent;
	protected TextBox TextBoxReplyContent;
	protected Button ButtonConfirm;
	protected Button Button1;
	protected MessageShow MessageShow;
	protected HiddenField hiddenGuid;
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
		this.hiddenGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		this.string_5 = ((base.Request.QueryString["type"] == null) ? "0" : base.Request.QueryString["type"]);
		if (this.hiddenGuid.Value != "0")
		{
			this.TextBoxContent.Text = string.Empty;
			if (!this.Page.IsPostBack)
			{
				this.GetEditInfo();
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_MemberMessage shopNum1_MemberMessage = new ShopNum1_MemberMessage();
		shopNum1_MemberMessage.Guid = new Guid(this.hiddenGuid.Value.Replace("'", ""));
		shopNum1_MemberMessage.ReTime = new DateTime?(DateTime.Now);
		shopNum1_MemberMessage.ReContent = this.TextBoxReplyContent.Text.Trim();
		ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
		int num = shopNum1_MessageInfo_Action.Update(shopNum1_MemberMessage);
		if (num > 0)
		{
			this.TextBoxContent.Text = string.Empty;
			base.Response.Redirect("ReceiveMessage_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = new ShopNum1_MessageInfo_Action();
		DataTable dataTable = shopNum1_MessageInfo_Action.Search(this.hiddenGuid.Value.ToString());
		this.LabelMemLoginIDValue.Text = dataTable.Rows[0]["SendID"].ToString();
		this.LabelMeaageTypeValue.Text = ((dataTable.Rows[0]["Type"].ToString() == "0") ? "会员消息" : "系统消息");
		this.LabelTitleValue.Text = dataTable.Rows[0]["Title"].ToString();
		this.LabelSendTimeValue.Text = dataTable.Rows[0]["SendTime"].ToString();
		this.LabelReplyUserValue.Text = dataTable.Rows[0]["ReceiveID"].ToString();
		this.LabelReplyTimeValue.Text = dataTable.Rows[0]["ReplyTime"].ToString();
		if (Operator.FormatToEmpty(dataTable.Rows[0]["ReplyTime"].ToString()) == string.Empty)
		{
			this.LabelIsReplyValue.Text = LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "0");
		}
		else
		{
			this.LabelIsReplyValue.Text = LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "1");
		}
		this.TextBoxContent.Text = dataTable.Rows[0]["Content"].ToString();
		this.TextBoxReplyContent.Text = dataTable.Rows[0]["ReplyContent"].ToString();
		if (dataTable.Rows[0]["ReplyTime"].ToString() == null || dataTable.Rows[0]["ReplyTime"].ToString() == "")
		{
			this.TextBoxReplyContent.ReadOnly = false;
			this.ButtonConfirm.Enabled = true;
		}
		else
		{
			this.ButtonConfirm.Enabled = false;
			this.TextBoxReplyContent.ReadOnly = true;
		}
		if (this.string_5 == "2")
		{
			this.TextBoxReplyContent.ReadOnly = true;
			this.ButtonConfirm.Enabled = false;
		}
	}
	protected void Button1_Click(object sender, EventArgs e)
	{
		if (this.string_5 == "1")
		{
			base.Response.Redirect("ReceiveMessage_List.aspx");
		}
		if (this.string_5 == "2")
		{
			base.Response.Redirect("SendMessage_List.aspx");
		}
	}
}
