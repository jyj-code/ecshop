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
public class AgentAdmin_ArticleComment_Reply : PageBase, IRequiresSessionState
{
	protected const string ArticleComment_List = "ArticleComment_List.aspx";
	protected Label LabelPageTitle;
	protected Label LabelTitle;
	protected TextBox TextBoxTitleValue;
	protected Label LabelArticleGuid;
	protected TextBox TextBoxArticleGuidValue;
	protected Label LabelRank;
	protected TextBox TextBoxRankValue;
	protected Label LabelMemLoginID;
	protected TextBox TextBoxMemLoginIDValue;
	protected Label LabelSendTime;
	protected TextBox TextBoxSendTimeValue;
	protected Label LabelIPAddress;
	protected TextBox TextBoxIPAddressValue;
	protected Label LabelReplyUser;
	protected TextBox TextBoxReplyUserValue;
	protected Label LabelReplyTime;
	protected TextBox TextBoxReplyTimeValue;
	protected Label LabelIsReply;
	protected TextBox TextBoxIsReplyValue;
	protected Label LabelIsAudit;
	protected TextBox TextBoxIsAuditValue;
	protected Label LabelContent;
	protected TextBox TextBoxContent;
	protected Label LabelReplyContent;
	protected TextBox TextBoxReplyContent;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected Button ButtonConfirm;
	protected HtmlInputReset inputReset;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
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
		if (!this.Page.IsPostBack)
		{
			this.hiddenGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			if (this.hiddenGuid.Value != "0")
			{
				this.GetEditInfo();
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.TextBoxReplyContent.Text.Length > 100)
		{
			MessageBox.Show("回复字数不得大于100！");
		}
		else
		{
			ShopNum1_ArticleComment shopNum1_ArticleComment = new ShopNum1_ArticleComment();
			ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
			shopNum1_ArticleComment.Guid = new Guid(this.hiddenGuid.Value.Replace("'", ""));
			shopNum1_ArticleComment.ReplyUser = base.ShopNum1LoginID;
			shopNum1_ArticleComment.ReplyTime = new DateTime?(DateTime.Now);
			shopNum1_ArticleComment.ReplyContent = this.TextBoxReplyContent.Text.Trim();
			shopNum1_ArticleComment.IsReply = 1;
			int num = shopNum1_ArticleComment_Action.Update(shopNum1_ArticleComment);
			if (num > 0)
			{
				this.MessageShow.ShowMessage("EditYes");
				this.MessageShow.Visible = true;
				this.ButtonConfirm.Visible = false;
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
		DataTable dataTable = shopNum1_ArticleComment_Action.SearchByGuid(this.hiddenGuid.Value);
		this.TextBoxArticleGuidValue.Text = dataTable.Rows[0]["ArticleTitle"].ToString();
		this.TextBoxTitleValue.Text = dataTable.Rows[0]["Title"].ToString();
		this.TextBoxMemLoginIDValue.Text = dataTable.Rows[0]["MemLoginID"].ToString();
		this.TextBoxSendTimeValue.Text = dataTable.Rows[0]["SendTime"].ToString();
		this.TextBoxIPAddressValue.Text = dataTable.Rows[0]["IPAddress"].ToString();
		this.TextBoxRankValue.Text = dataTable.Rows[0]["Rank"].ToString();
		this.TextBoxReplyUserValue.Text = dataTable.Rows[0]["ReplyUser"].ToString();
		this.TextBoxReplyTimeValue.Text = dataTable.Rows[0]["ReplyTime"].ToString();
		this.TextBoxContent.Text = dataTable.Rows[0]["Content"].ToString();
		this.TextBoxReplyContent.Text = dataTable.Rows[0]["ReplyContent"].ToString();
		if (dataTable.Rows[0]["IsReply"].ToString() == "1")
		{
			this.TextBoxIsReplyValue.Text = this.ChangeIsReply("1");
			this.TextBoxReplyContent.ReadOnly = true;
			this.ButtonConfirm.Enabled = false;
		}
		else
		{
			this.TextBoxIsReplyValue.Text = this.ChangeIsReply("0");
		}
		if (dataTable.Rows[0]["IsAudit"].ToString() == "1")
		{
			this.TextBoxIsAuditValue.Text = this.ChangeIsAudit("1");
		}
		else
		{
			this.TextBoxIsAuditValue.Text = this.ChangeIsAudit("0");
		}
	}
	public string ChangeIsReply(string strIsReply)
	{
		string result;
		if (strIsReply == "0")
		{
			result = "未回复";
		}
		else if (strIsReply == "1")
		{
			result = "已回复";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsAudit(string strIsAudit)
	{
		string result;
		if (strIsAudit == "0")
		{
			result = "未审核";
		}
		else if (strIsAudit == "1")
		{
			result = "已审核";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("ArticleComment_List.aspx");
	}
}
