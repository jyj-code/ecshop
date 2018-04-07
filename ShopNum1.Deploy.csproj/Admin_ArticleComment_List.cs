using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
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
public class Admin_ArticleComment_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
	protected Label LabelSIsAudit1;
	protected System.Web.UI.WebControls.TextBox TextBoxSArticleGuid;
	protected Label LabelSIsReply0;
	protected System.Web.UI.WebControls.TextBox TextBoxSIPAddress;
	protected Label LabelSIsReply;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsReply;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsAudit;
	protected Label LabelSSendTime;
	protected System.Web.UI.WebControls.TextBox TextBoxSSendTime1;
	protected RegularExpressionValidator RegularExpressionValidatorSendTime1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSSendTime2;
	protected RegularExpressionValidator RegularExpressionValidatorSendTime2;
	protected CalendarExtender CalendarExtender2;
	protected Label LabelSReplyTime;
	protected System.Web.UI.WebControls.TextBox TextBoxSReplyTime1;
	protected RegularExpressionValidator RegularExpressionValidatorSReplyTime1;
	protected CalendarExtender CalendarExtender3;
	protected System.Web.UI.WebControls.TextBox TextBoxSReplyTime2;
	protected RegularExpressionValidator RegularExpressionValidatorSReplyTime2;
	protected CalendarExtender CalendarExtender4;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected System.Web.UI.WebControls.Button ButtonIsAudit1;
	protected System.Web.UI.WebControls.Button ButtonIsAudit0;
	protected System.Web.UI.WebControls.Button ButtonReply;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldArticle;
	protected System.Web.UI.WebControls.TextBox TextBoxSTitle;
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
			this.CheckGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			if (this.Page.Request.QueryString["ArticleGuid"] != null)
			{
				this.LabelPageTitle.Text = "相关资讯评论";
				this.HiddenFieldArticle.Value = this.Page.Request.QueryString["ArticleGuid"].ToString();
			}
			this.BindGrid();
			this.BindStatus();
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
		int num = shopNum1_ArticleComment_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ArticleComment_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonReply_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ArticleComment_Reply.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	public string ChangeIsReply(string strIsReply)
	{
		string result;
		if (strIsReply == "0")
		{
			result = LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsReply", "0");
		}
		else if (strIsReply == "1")
		{
			result = LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsReply", "1");
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
			result = LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "0");
		}
		else if (strIsAudit == "1")
		{
			result = LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "1");
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void BindStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("All");
		listItem.Value = "-1";
		this.DropDownListSIsReply.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = LocalizationUtil.GetCommonMessage("NoReply");
		listItem2.Value = "0";
		this.DropDownListSIsReply.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = LocalizationUtil.GetCommonMessage("IsReply");
		listItem3.Value = "1";
		this.DropDownListSIsReply.Items.Add(listItem3);
		ListItem listItem4 = new ListItem();
		listItem4.Text = LocalizationUtil.GetCommonMessage("YesAudit");
		listItem4.Value = "1";
		this.DropDownListSIsAudit.Items.Add(listItem4);
	}
	protected void ButtonIsAudit1_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
		DataTable articleCommentInfoByGuid = shopNum1_ArticleComment_Action.GetArticleCommentInfoByGuid(this.CheckGuid.Value);
		int num = shopNum1_ArticleComment_Action.UpdateAudit(this.CheckGuid.Value, 1);
		if (num > 0)
		{
			int num2 = 0;
			int num3 = 0;
			try
			{
				num2 = int.Parse(ShopSettings.GetValue("ArticleCommentRankSorce"));
			}
			catch
			{
				num2 = 0;
			}
			try
			{
				num3 = int.Parse(ShopSettings.GetValue("ArticleCommentSorce"));
			}
			catch
			{
				num2 = 0;
			}
			ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action2 = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
			for (int i = 0; i < articleCommentInfoByGuid.Rows.Count; i++)
			{
				if (!(articleCommentInfoByGuid.Rows[i]["IsAudit"].ToString() == "1"))
				{
					shopNum1_ArticleComment_Action2.UpdateScoreByCommentArticle(articleCommentInfoByGuid.Rows[i]["MemLoginID"].ToString(), num2.ToString(), num3.ToString());
				}
			}
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "审核成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ArticleComment_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonIsAudit0_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
		int num = shopNum1_ArticleComment_Action.UpdateAudit(this.CheckGuid.Value, 2);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "取消审核成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ArticleComment_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
		int num = shopNum1_ArticleComment_Action.Delete("'" + commandArgument + "'");
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
}
