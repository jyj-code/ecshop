using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopArticleComment_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle1;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
	protected Label LabelSTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsAudit;
	protected Label LabelSIsAudit1;
	protected System.Web.UI.WebControls.TextBox TextBoxSArticleGuid;
	protected Label LabelSSendTime;
	protected System.Web.UI.WebControls.TextBox TextBoxSSendTime1;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate1;
	protected System.Web.UI.WebControls.TextBox TextBoxSSendTime2;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonReply;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldSubstationID;
	protected System.Web.UI.WebControls.TextBox TextBoxSTitle;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsReply;
	protected Label LabelSReplyTime;
	protected System.Web.UI.WebControls.TextBox TextBoxSReplyTime1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate3;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.TextBox TextBoxSReplyTime2;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate4;
	protected CalendarExtender CalendarExtender3;
	protected System.Web.UI.WebControls.TextBox TextBoxSIPAddress;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!this.Page.IsPostBack)
		{
			this.CheckGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			if (this.CheckGuid.Value != "0")
			{
				this.LabelPageTitle1.Text = "【 相关资讯评论 】";
			}
			this.BindStatus();
			this.BindGrid();
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopArticleComment_Action shopNum1_ShopArticleComment_Action = (ShopNum1_ShopArticleComment_Action)LogicFactory.CreateShopNum1_ShopArticleComment_Action();
		int num = shopNum1_ShopArticleComment_Action.Delete(this.CheckGuid.Value.ToString());
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
	protected void ButtonReply_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopArticleComment_Operate.aspx?guid=" + this.CheckGuid.Value + "&Type=List");
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindGrid()
	{
		try
		{
			this.Num1GridViewShow.DataBind();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
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
		if (strIsAudit == "1")
		{
			result = "已审核";
		}
		else if (strIsAudit == "0")
		{
			result = "未审核";
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
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListSIsReply.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "未回复";
		listItem2.Value = "0";
		this.DropDownListSIsReply.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "已回复";
		listItem3.Value = "1";
		this.DropDownListSIsReply.Items.Add(listItem3);
		ListItem listItem4 = new ListItem();
		listItem4.Text = "已审核";
		listItem4.Value = "1";
		this.DropDownListSIsAudit.Items.Add(listItem4);
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument.Replace("'", "") + "'";
		ShopNum1_ShopArticleComment_Action shopNum1_ShopArticleComment_Action = (ShopNum1_ShopArticleComment_Action)LogicFactory.CreateShopNum1_ShopArticleComment_Action();
		int num = shopNum1_ShopArticleComment_Action.Delete(guids);
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
