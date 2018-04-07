using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ReceiveMessage_List : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.TextBox textBoxMemLoginID;
	protected System.Web.UI.WebControls.TextBox textBoxSTitle;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsRead;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsReply;
	protected System.Web.UI.WebControls.TextBox textBoxSSendTimeStart;
	protected RegularExpressionValidator RegularExpressionValidatorSSendTimeStart;
	protected ToolkitScriptManager ToolkitScriptManager2;
	protected CalendarExtender CalendarExtender5;
	protected Label LabelName2;
	protected System.Web.UI.WebControls.TextBox textBoxSSendTimeEnd;
	protected RegularExpressionValidator RegularExpressionValidatorSSendTimeEnd;
	protected CalendarExtender CalendarExtender6;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.TextBox textBoxLoginID;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonEdit;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridiewShow;
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
		if (!this.Page.IsPostBack)
		{
			this.BindStatus();
			this.BindGrid();
			this.textBoxLoginID.Text = base.ShopNum1LoginID;
		}
	}
	protected void BindGrid()
	{
		this.Num1GridiewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("Message_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Message_Reply.aspx?guid=" + this.CheckGuid.Value + "&Type=1");
	}
	protected void ButtonSearchBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string str = "'" + linkButton.CommandArgument + "'";
		base.Response.Redirect("Message_Reply.aspx?guid=" + str + "&type=1");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
		int num = shopNum1_MessageInfo_Action.DeleteReceive(this.CheckGuid.Value.ToString());
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		int num = shopNum1_MessageInfo_Action.DeleteReceive(guids);
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	public string ChangeIsRead(string strIsRead)
	{
		string result;
		if (strIsRead == "0")
		{
			result = LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsRead", "0");
		}
		else if (strIsRead == "1")
		{
			result = LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsRead", "1");
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
		this.DropDownListSIsRead.Items.Add(listItem);
		this.DropDownListSIsReply.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = LocalizationUtil.GetCommonMessage("NoRead");
		listItem2.Value = "0";
		this.DropDownListSIsRead.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = LocalizationUtil.GetCommonMessage("IsRead");
		listItem3.Value = "1";
		this.DropDownListSIsRead.Items.Add(listItem3);
		ListItem listItem4 = new ListItem();
		listItem4.Text = LocalizationUtil.GetCommonMessage("NoReply");
		listItem4.Value = "0";
		this.DropDownListSIsReply.Items.Add(listItem4);
		ListItem listItem5 = new ListItem();
		listItem5.Text = LocalizationUtil.GetCommonMessage("IsReply");
		listItem5.Value = "1";
		this.DropDownListSIsReply.Items.Add(listItem5);
	}
	protected void Num1GridiewShow_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			if (Operator.FormatToEmpty(e.Row.Cells[8].Text) == string.Empty)
			{
				e.Row.Cells[7].Text = LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "0");
			}
			else
			{
				e.Row.Cells[7].Text = LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "1");
			}
		}
	}
	public string ChangeIsReply(string strIsReply)
	{
		string result;
		if (strIsReply == "0")
		{
			result = LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "0");
		}
		else if (strIsReply == "1")
		{
			result = LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "1");
		}
		else
		{
			result = "";
		}
		return result;
	}
}
