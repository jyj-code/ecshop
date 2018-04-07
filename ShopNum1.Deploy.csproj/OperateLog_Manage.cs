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
public class OperateLog_Manage : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Label lblOperatorID;
	protected System.Web.UI.WebControls.TextBox textBoxOperatorID;
	protected Label lblIP;
	protected System.Web.UI.WebControls.TextBox textBoxIP;
	protected Label lbDate;
	protected System.Web.UI.WebControls.TextBox textBoxStartTime;
	protected CalendarExtender CalendarExtender2;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected System.Web.UI.WebControls.TextBox textEndTime;
	protected CalendarExtender CalendarExtender3;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Label Label1;
	protected System.Web.UI.WebControls.TextBox textBoxDeleteStartTime;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime2;
	protected System.Web.UI.WebControls.TextBox textDeleteEndTime;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.Button ButtonDeleteAll;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldAgentID;
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
			this.BindGrid();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindGrid()
	{
		this.num1GridViewShow.DataBind();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_OperateLog_Action shopNum1_OperateLog_Action = (ShopNum1_OperateLog_Action)LogicFactory.CreateShopNum1_OperateLog_Action();
		int num = shopNum1_OperateLog_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			this.BindGrid();
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_OperateLog_Action shopNum1_OperateLog_Action = (ShopNum1_OperateLog_Action)LogicFactory.CreateShopNum1_OperateLog_Action();
		int num = shopNum1_OperateLog_Action.Delete(guids);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			this.BindGrid();
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteAll_Click(object sender, EventArgs e)
	{
		ShopNum1_OperateLog_Action shopNum1_OperateLog_Action = new ShopNum1_OperateLog_Action();
		int num = shopNum1_OperateLog_Action.DeleteAll(this.textBoxDeleteStartTime.Text.Trim(), this.textDeleteEndTime.Text.Trim());
		if (num == -1)
		{
			MessageBox.Show("请选择要删除日志的时间！");
		}
		if (num > 0)
		{
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			this.BindGrid();
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
}
