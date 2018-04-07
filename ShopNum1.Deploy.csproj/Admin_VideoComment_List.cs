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
public class Admin_VideoComment_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
	protected Label LabelSIsAudit0;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsAudit;
	protected Label LabelSIsAudit1;
	protected System.Web.UI.WebControls.TextBox TextBoxSVideoGuid;
	protected Label LabelSSendTime;
	protected System.Web.UI.WebControls.TextBox TextBoxSSendTime1;
	protected RegularExpressionValidator RegularExpressionValidatorSendTime1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSSendTime2;
	protected RegularExpressionValidator RegularExpressionValidatorSendTime2;
	protected CompareValidator CompareTextBoxSSendTime2;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonIsAudit1;
	protected LinkButton ButtonIsAudit0;
	protected LinkButton ButtonReply;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
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
		string a = (this.Page.Request.QueryString["IsAudit"] == null) ? "0" : this.Page.Request.QueryString["IsAudit"];
		if (!this.Page.IsPostBack)
		{
			this.CheckGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			if (this.CheckGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "【 相关视频评论 】";
			}
			this.BindGrid();
			if (a != "0")
			{
				this.DropDownListSIsAudit.SelectedValue = "0";
			}
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_VideoComment_Action shopNum1_VideoComment_Action = (ShopNum1_VideoComment_Action)LogicFactory.CreateShopNum1_VideoComment_Action();
		int num = shopNum1_VideoComment_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "VideoComment_List.aspx",
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
		ShopNum1_VideoComment_Action shopNum1_VideoComment_Action = (ShopNum1_VideoComment_Action)LogicFactory.CreateShopNum1_VideoComment_Action();
		DataTable dataTable = shopNum1_VideoComment_Action.SearchByGuid(this.CheckGuid.Value);
		this.Page.RegisterStartupScript("", "<script> window.open('" + GetPageName.RetUrl("VideoDetail", dataTable.Rows[0]["VideoGuid"]) + "')</script>");
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
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
	public string ChangeAudit(string strIsAudit)
	{
		string result;
		if (strIsAudit == "0")
		{
			result = "未审核";
		}
		else if (strIsAudit == "1")
		{
			result = "审核通过";
		}
		else if (strIsAudit == "2")
		{
			result = "审核未通过";
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
		this.DropDownListSIsAudit.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = LocalizationUtil.GetCommonMessage("NoAudit");
		listItem2.Value = "0";
		this.DropDownListSIsAudit.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = LocalizationUtil.GetCommonMessage("YesAudit");
		listItem3.Value = "1";
		this.DropDownListSIsAudit.Items.Add(listItem3);
	}
	protected void ButtonIsAudit1_Click(object sender, EventArgs e)
	{
		ShopNum1_VideoComment_Action shopNum1_VideoComment_Action = (ShopNum1_VideoComment_Action)LogicFactory.CreateShopNum1_VideoComment_Action();
		ShopNum1_ScoreModifyLog_Action arg_15_0 = (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
		ShopNum1_RankScoreModifyLog_Action arg_20_0 = (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
		ShopNum1_Common_Action arg_2B_0 = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
		int num = shopNum1_VideoComment_Action.UpdateAudit(this.CheckGuid.Value);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "审核成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "VideoComment_List.aspx",
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
		ShopNum1_VideoComment_Action shopNum1_VideoComment_Action = (ShopNum1_VideoComment_Action)LogicFactory.CreateShopNum1_VideoComment_Action();
		ShopNum1_ScoreModifyLog_Action arg_15_0 = (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
		ShopNum1_RankScoreModifyLog_Action arg_20_0 = (ShopNum1_RankScoreModifyLog_Action)LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
		ShopNum1_Common_Action arg_2B_0 = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
		int num = shopNum1_VideoComment_Action.UpdateAuditNot(this.CheckGuid.Value);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "取消审核成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "VideoComment_List.aspx",
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
}
