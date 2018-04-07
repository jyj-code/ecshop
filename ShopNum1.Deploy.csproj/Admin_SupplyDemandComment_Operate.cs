using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SupplyDemandComment_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label Label1;
	protected TextBox TextBoxMember;
	protected Label LabelKeywords;
	protected TextBox TextBoxSupplyTitle;
	protected Label Label2;
	protected TextBox FCKeditorDetail;
	protected Label LabelName;
	protected TextBox TextBoxTitle;
	protected Label LabelWebSite;
	protected TextBox TextBoxTime;
	protected Label LabelOrderID;
	protected TextBox TextBoxUser;
	protected Label LabelLogo;
	protected TextBox TextBoxIP;
	protected Label LabelRemark;
	protected TextBox TextBoxContent;
	protected Label Label3;
	protected TextBox TextBoxReplyContent;
	protected Button ButtonSubmit;
	protected Button ButtonAudit;
	protected Button ButtonCancelAudit;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
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
			this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			this.DataBind();
			if (base.Request.QueryString["goback"] != null && base.Request.QueryString["goback"].ToString() == "sh")
			{
				this.ButtonSubmit.Visible = false;
			}
		}
	}
	public new void DataBind()
	{
		ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
		DataTable dataTable = shopNum1_SupplyDemandComment_Action.SearchByGuid(this.hiddenFieldGuid.Value);
		this.TextBoxContent.Text = dataTable.Rows[0]["Content"].ToString();
		this.TextBoxTitle.Text = dataTable.Rows[0]["Title"].ToString();
		this.TextBoxTime.Text = dataTable.Rows[0]["CreateTime"].ToString();
		this.TextBoxUser.Text = dataTable.Rows[0]["CreateMerber"].ToString();
		this.TextBoxIP.Text = dataTable.Rows[0]["CreateIP"].ToString();
		this.TextBoxSupplyTitle.Text = dataTable.Rows[0]["CommentTitle"].ToString();
		this.FCKeditorDetail.Text = HttpContext.Current.Server.HtmlDecode(dataTable.Rows[0]["ConmetContent"].ToString());
		this.TextBoxMember.Text = dataTable.Rows[0]["AssociateMemberID"].ToString();
		this.TextBoxReplyContent.Text = dataTable.Rows[0]["Reply"].ToString();
		if (dataTable.Rows[0]["Reply"].ToString() != string.Empty)
		{
			this.TextBoxReplyContent.ReadOnly = true;
			this.ButtonSubmit.Enabled = false;
		}
		string a = (this.Page.Request.QueryString["type"] == null) ? "-1" : this.Page.Request.QueryString["type"];
		if (a == "audit")
		{
			this.TextBoxReplyContent.ReadOnly = true;
			this.ButtonSubmit.Visible = false;
		}
		this.ButtonSubmit.Text = "更新";
		if (dataTable.Rows[0]["isAudit"].ToString() == "1" || dataTable.Rows[0]["isAudit"].ToString() == "2")
		{
			this.ButtonAudit.Visible = false;
			this.ButtonCancelAudit.Visible = false;
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (base.Request.QueryString["goback"] != null && base.Request.QueryString["goback"].ToString() == "sh")
		{
			this.Page.Response.Redirect("SupplyDemandCommentAudit_List.aspx");
		}
		else
		{
			this.Page.Response.Redirect("SupplyDemandComment_List.aspx");
		}
	}
	protected void ButtonSubmit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
		int num = shopNum1_SupplyDemandComment_Action.ReplySupplyDemandComment(this.hiddenFieldGuid.Value.Replace("'", ""), this.TextBoxReplyContent.Text.Trim());
		if (num > 0)
		{
			this.Page.Response.Redirect("SupplyDemandComment_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
		if (shopNum1_SupplyDemandComment_Action.UpdateSupplyDemandCommentAudit(this.hiddenFieldGuid.Value, "1") > 0)
		{
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
		if (shopNum1_SupplyDemandComment_Action.UpdateSupplyDemandCommentAudit(this.hiddenFieldGuid.Value, "2") > 0)
		{
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
}
