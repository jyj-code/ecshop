using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_PageAdID_List : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.TextBox TextBoxPageName;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
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
	public void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("PageAdID_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PageAdID_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value.Split(new char[]
		{
			','
		});
		ShopNum1_PageAdID_Action shopNum1_PageAdID_Action = (ShopNum1_PageAdID_Action)LogicFactory.CreateShopNum1_PageAdID_Action();
		ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
		DataTable dataTable = shopNum1_PageAdID_Action.SelectByID(this.CheckGuid.Value);
		DataTable dataTable2 = shopNum1_Advertisement_Action.ShowADByDivID(dataTable.Rows[0]["divid"].ToString());
		if (dataTable2 != null && dataTable2.Rows.Count != 0)
		{
			MessageBox.Show("广告位下面还有广告，请先删除广告后再删除广告位!");
		}
		else
		{
			int num = shopNum1_PageAdID_Action.Delete(this.CheckGuid.Value);
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_PageAdID_Action shopNum1_PageAdID_Action = (ShopNum1_PageAdID_Action)LogicFactory.CreateShopNum1_PageAdID_Action();
		ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
		DataTable dataTable = shopNum1_PageAdID_Action.SelectByID(commandArgument);
		dataTable.Rows[0]["divid"].ToString();
		DataTable dataTable2 = shopNum1_Advertisement_Action.ShowADByDivID(dataTable.Rows[0]["divid"].ToString());
		if (dataTable2 != null && dataTable2.Rows.Count != 0)
		{
			MessageBox.Show("广告位下面还有广告，请先删除广告后再删除广告位!");
		}
		else
		{
			int num = shopNum1_PageAdID_Action.Delete(commandArgument);
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
}
