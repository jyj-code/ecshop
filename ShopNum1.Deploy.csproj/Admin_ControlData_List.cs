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
public class Admin_ControlData_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.Button ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected System.Web.UI.WebControls.Button ButtonBack;
	protected MessageShow MessageShow;
	protected Num1GridView num1GridiewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField hiddenFieldGuid;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"].Replace("'", ""));
		if (!this.Page.IsPostBack)
		{
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.num1GridiewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("ControlData_Operate.aspx?guid=" + this.CheckGuid.Value + "&&ControlGuid=" + this.hiddenFieldGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ControlData_Operate.aspx?guid=" + this.CheckGuid.Value + "&&ControlGuid=" + this.hiddenFieldGuid.Value);
	}
	public string ChangeDataType(object strType)
	{
		string result;
		if (strType.ToString() == "1")
		{
			result = "文字";
		}
		else if (strType.ToString() == "2")
		{
			result = "图片";
		}
		else if (strType.ToString() == "3")
		{
			result = "商品";
		}
		else if (strType.ToString() == "4")
		{
			result = "Flash";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ControlData_Action shopNum1_ControlData_Action = (ShopNum1_ControlData_Action)LogicFactory.CreateShopNum1_ControlData_Action();
		int num = shopNum1_ControlData_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ControlData_List.aspx",
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
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("InfoControl_List.aspx");
	}
}
