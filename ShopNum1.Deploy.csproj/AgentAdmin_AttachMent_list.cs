using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_AttachMent_list : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Localize LocalizeAssociatedCategoryGuid;
	protected System.Web.UI.WebControls.DropDownList DropDownListAssociatedCategoryGuid;
	protected System.Web.UI.WebControls.Button Button1;
	protected System.Web.UI.WebControls.Button Button2;
	protected System.Web.UI.WebControls.Button Button3;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
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
			this.AssociatedCategoryGuidBind();
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.num1GridViewShow.DataBind();
	}
	protected void AssociatedCategoryGuidBind()
	{
		this.DropDownListAssociatedCategoryGuid.Items.Add(new ListItem("-全部-", "-1"));
		ShopNum1_AttachMentCategory_Action shopNum1_AttachMentCategory_Action = (ShopNum1_AttachMentCategory_Action)LogicFactory.CreateShopNum1_AttachMentCategory_Action();
		DataTable dataTable = shopNum1_AttachMentCategory_Action.Search();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			this.DropDownListAssociatedCategoryGuid.Items.Add(new ListItem(dataTable.Rows[i]["CategoryName"].ToString(), dataTable.Rows[i]["Guid"].ToString()));
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("AttachMent_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_AttachMent_Action shopNum1_AttachMent_Action = (ShopNum1_AttachMent_Action)LogicFactory.CreateShopNum1_AttachMent_Action();
		int num = shopNum1_AttachMent_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AttachMent_list.aspx",
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
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		ShopNum1_AttachMent_Action shopNum1_AttachMent_Action = (ShopNum1_AttachMent_Action)LogicFactory.CreateShopNum1_AttachMent_Action();
		int num = shopNum1_AttachMent_Action.Delete(guid);
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
