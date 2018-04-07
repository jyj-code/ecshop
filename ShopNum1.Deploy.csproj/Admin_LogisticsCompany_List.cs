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
public class Admin_LogisticsCompany_List : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.TextBox textBoxName;
	protected System.Web.UI.WebControls.Button ButtonSearch;
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
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridiewShow.DataBind();
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("LogisticsCompany_Operate.aspx?ID=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Logistic_Action shopNum1_Logistic_Action = (ShopNum1_Logistic_Action)LogicFactory.CreateShopNum1_Logistic_Action();
		int num = shopNum1_Logistic_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "LogisticsCompany_List.aspx",
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_Logistic_Action shopNum1_Logistic_Action = (ShopNum1_Logistic_Action)LogicFactory.CreateShopNum1_Logistic_Action();
		LinkButton linkButton = (LinkButton)sender;
		string string_ = "'" + linkButton.CommandArgument + "'";
		int num = shopNum1_Logistic_Action.Delete(string_);
		if (num > 0)
		{
			this.BindGrid();
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功!",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "LogisticsCompany_List.aspx",
				Date = DateTime.Now
			});
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
	public string GetRight(string isshow)
	{
		string result;
		if (isshow == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
}
