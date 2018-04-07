using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_InfoControl_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelPageName;
	protected System.Web.UI.WebControls.TextBox TextBoxPageName;
	protected System.Web.UI.WebControls.Button Button2;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonSeeData;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridviewShow;
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
		if (!base.IsPostBack)
		{
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridviewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("InfoControl_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("InfoControl_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonSeeData_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ControlData_List.aspx?guid=" + this.CheckGuid.Value.Replace("'", ""));
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Control_Action shopNum1_Control_Action = (ShopNum1_Control_Action)LogicFactory.CreateShopNum1_Control_Action();
		int num = shopNum1_Control_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "InfoControl_List.aspx",
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_Control_Action shopNum1_Control_Action = (ShopNum1_Control_Action)LogicFactory.CreateShopNum1_Control_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_Control_Action.Delete("'" + commandArgument + "'");
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
