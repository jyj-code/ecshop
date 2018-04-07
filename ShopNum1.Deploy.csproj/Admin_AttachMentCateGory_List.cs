using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_AttachMentCateGory_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label Label1;
	protected System.Web.UI.WebControls.Button ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView num1GridViewShow;
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
		this.num1GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("AttachMentCateGory_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_AttachMentCategory_Action shopNum1_AttachMentCategory_Action = (ShopNum1_AttachMentCategory_Action)LogicFactory.CreateShopNum1_AttachMentCategory_Action();
		string value = this.CheckGuid.Value;
		int num = 0;
		if (DatabaseExcetue.ReturnDataSet("select guid from ShopNum1_AttachMent where associatedcategoryguid in(" + value + ");").Tables[0].Rows.Count == 0)
		{
			num = shopNum1_AttachMentCategory_Action.Delete(value);
		}
		if (num == 1)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AttachMentCateGory_Operate.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("该类别包含附件数据，无法删除！");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("AttachMentCateGory_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		ShopNum1_AttachMentCategory_Action shopNum1_AttachMentCategory_Action = (ShopNum1_AttachMentCategory_Action)LogicFactory.CreateShopNum1_AttachMentCategory_Action();
		int num = shopNum1_AttachMentCategory_Action.Delete(guid);
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
