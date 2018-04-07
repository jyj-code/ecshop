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
public class AgentAdmin_ShopVedioComment_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
	protected Label LabelSTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxSTitle;
	protected Label LabelSIsReply;
	protected System.Web.UI.WebControls.DropDownList DropDownListSIsReply;
	protected Label LabelSIsReply0;
	protected System.Web.UI.WebControls.TextBox TextBoxSIPAddress;
	protected Label LabelSIsAudit1;
	protected System.Web.UI.WebControls.TextBox TextBoxSVideoGuid;
	protected Label LabelSIsAudit0;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected Label LabelSSendTime;
	protected System.Web.UI.WebControls.TextBox TextBoxSCommentTime1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate1;
	protected CalendarExtender CalendarExtender4;
	protected System.Web.UI.WebControls.TextBox TextBoxSCommentTime2;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate2;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSReplyTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxSReplyTime2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonReply;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldSubstationID;
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
		if (!base.IsPostBack)
		{
			this.method_5();
			this.BindGrid();
		}
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
	private void method_5()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "已审核";
		listItem.Value = "1";
		this.DropDownListIsAudit.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "-全部-";
		listItem2.Value = "-1";
		this.DropDownListSIsReply.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "未回复";
		listItem3.Value = "0";
		this.DropDownListSIsReply.Items.Add(listItem3);
		ListItem listItem4 = new ListItem();
		listItem4.Text = "已回复";
		listItem4.Value = "1";
		this.DropDownListSIsReply.Items.Add(listItem4);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_VedioCommentChecked_Action shopNum1_VedioCommentChecked_Action = (ShopNum1_VedioCommentChecked_Action)LogicFactory.CreateShopNum1_VedioCommentChecked_Action();
		int num = shopNum1_VedioCommentChecked_Action.Delete(this.CheckGuid.Value.ToString());
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
		base.Response.Redirect("ShopVedioCommentChecked_Operate.aspx?guid=" + this.CheckGuid.Value + "&Type=List");
	}
	public string ChangeIsAudit(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	public string ChangeIsReply(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "已回复";
		}
		else if (object_0.ToString() == "0")
		{
			result = "未回复";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_VedioCommentChecked_Action shopNum1_VedioCommentChecked_Action = (ShopNum1_VedioCommentChecked_Action)LogicFactory.CreateShopNum1_VedioCommentChecked_Action();
		int num = shopNum1_VedioCommentChecked_Action.Delete(guids);
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
