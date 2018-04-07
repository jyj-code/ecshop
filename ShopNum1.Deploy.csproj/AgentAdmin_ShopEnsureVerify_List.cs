using ShopNum1.Control;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopEnsureVerify_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.TextBox TextBoxMemberLoginID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
	protected ObjectDataSource ObjectDataSourceData;
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
		if (!this.Page.IsPostBack)
		{
			this.BandDropdownIsAudit();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.DelShopEnsureList(this.CheckGuid.Value);
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
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		int num = shop_Ensure_Action.DelShopEnsureList(guid);
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
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.UpdataIsAuditByGuid(this.CheckGuid.Value, 1);
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateYes");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.UpdataIsAuditByGuid(this.CheckGuid.Value, 0);
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateYes");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
	public void BandDropdownIsAudit()
	{
		this.DropDownListIsAudit.Items.Add(new ListItem("-已审核-", "1"));
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected string IsAudit(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
}
