using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SendMessage_List : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.TextBox textBoxSTitle;
	protected System.Web.UI.WebControls.TextBox textBoxSMemLoginID;
	protected System.Web.UI.WebControls.TextBox textBoxSLoginID;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsRead;
	protected System.Web.UI.WebControls.DropDownList DropDownListSType;
	protected System.Web.UI.WebControls.TextBox textBoxSSendTimeStart;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected RegularExpressionValidator RegularExpressionValidatorSSendTimeStart;
	protected CalendarExtender CalendarExtender1;
	protected Label LabelName2;
	protected System.Web.UI.WebControls.TextBox textBoxSSendTimeEnd;
	protected RegularExpressionValidator RegularExpressionValidatorSSendTimeEnd;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
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
			this.textBoxSMemLoginID.Text = base.ShopNum1LoginID;
		}
	}
	protected void BindGrid()
	{
		this.Num1GridiewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("Message_Operate.aspx?guid=" + this.CheckGuid.Value + "&type=2");
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Message_Reply.aspx?guid=" + this.CheckGuid.Value + "&type=2");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
		int num = shopNum1_MessageInfo_Action.DeleteSend(this.CheckGuid.Value.ToString());
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
		int num = shopNum1_MessageInfo_Action.DeleteSend(guids);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ReceiveMessage_List.aspx",
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("All");
		listItem.Value = "-1";
		this.DropDownListSIsRead.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = LocalizationUtil.GetCommonMessage("NoRead");
		listItem2.Value = "0";
		this.DropDownListSIsRead.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = LocalizationUtil.GetCommonMessage("IsRead");
		listItem3.Value = "1";
		this.DropDownListSIsRead.Items.Add(listItem3);
		ListItem listItem4 = new ListItem();
		listItem4.Text = LocalizationUtil.GetCommonMessage("All");
		listItem4.Value = "-1";
		this.DropDownListSType.Items.Add(listItem4);
		ListItem listItem5 = new ListItem();
		listItem5.Text = "系统消息";
		listItem5.Value = "1";
		this.DropDownListSType.Items.Add(listItem5);
		ListItem listItem6 = new ListItem();
		listItem6.Text = "会员消息";
		listItem6.Value = "0";
		this.DropDownListSType.Items.Add(listItem6);
	}
}
