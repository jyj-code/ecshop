using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopNum1_SupplyDemandCategory_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabeTitle;
	protected TreeView TreeViewData;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonNodeOperate;
	protected AgentAdmin_MessageShow MessageShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HtmlForm form1;
	public string strid = "-1";
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
			this.method_5();
		}
	}
	private void method_5()
	{
		ShopNum1_SupplyDemandCategory_Action shopNum1_SupplyDemandCategory_Action = (ShopNum1_SupplyDemandCategory_Action)LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
		DataTable dataTable = shopNum1_SupplyDemandCategory_Action.SearchtSupplyDemandCategory(0, 0);
		if (dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Text = dataRow["Name"].ToString();
				treeNode.Value = dataRow["ID"].ToString();
				treeNode.Expanded = new bool?(false);
				this.method_6(treeNode, Convert.ToInt32(dataRow["ID"].ToString()));
				this.TreeViewData.Nodes.Add(treeNode);
			}
		}
	}
	private void method_6(TreeNode treeNode_0, int int_0)
	{
		ShopNum1_SupplyDemandCategory_Action shopNum1_SupplyDemandCategory_Action = (ShopNum1_SupplyDemandCategory_Action)LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
		DataTable dataTable = shopNum1_SupplyDemandCategory_Action.SearchtSupplyDemandCategory(int_0, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Value = dataRow["ID"].ToString();
			treeNode.Text = dataRow["Name"].ToString();
			treeNode.Expanded = new bool?(false);
			this.method_6(treeNode, Convert.ToInt32(dataRow["ID"].ToString()));
			treeNode_0.ChildNodes.Add(treeNode);
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("ShopNum1_SupplyDemandCategory_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		TreeNodeCollection nodes = this.TreeViewData.Nodes;
		this.GetNode(nodes);
	}
	public void GetNode(TreeNodeCollection treeNodeCollection_0)
	{
		foreach (TreeNode treeNode in treeNodeCollection_0)
		{
			if (treeNode.Checked)
			{
				base.Response.Redirect("ShopNum1_SupplyDemandCategory_Operate.aspx?guid=" + treeNode.Value.ToString());
			}
			this.GetNode(treeNode.ChildNodes);
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		TreeNodeCollection nodes = this.TreeViewData.Nodes;
		this.method_7(nodes);
		if (this.strid == "-1")
		{
			MessageBox.Show("请选择要删除的记录!");
		}
		else
		{
			ShopNum1_SupplyDemandCategory_Action shopNum1_SupplyDemandCategory_Action = (ShopNum1_SupplyDemandCategory_Action)LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
			int num = shopNum1_SupplyDemandCategory_Action.Delete(this.strid);
			if (num == 1)
			{
				ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
				this.MessageShow.ShowMessage("DelYes");
				this.MessageShow.Visible = true;
				this.TreeViewData.Nodes.Clear();
				this.method_5();
			}
			else if (num == 2)
			{
				this.MessageShow.ShowMessage("SupplyCategory");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("DelNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	private void method_7(TreeNodeCollection treeNodeCollection_0)
	{
		foreach (TreeNode treeNode in treeNodeCollection_0)
		{
			if (treeNode.Checked)
			{
				this.strid = treeNode.Value.ToString();
			}
			this.method_7(treeNode.ChildNodes);
		}
	}
	protected void TreeViewData_SelectedNodeChanged(object sender, EventArgs e)
	{
		TreeView treeView = sender as TreeView;
		TreeNode selectedNode = treeView.SelectedNode;
		this.CheckGuid.Value = selectedNode.Value.ToString();
		base.Response.Redirect("ShopNum1_SupplyDemandCategory_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonNodeOperate_Click(object sender, EventArgs e)
	{
		this.ExpendAll();
	}
	public void ExpendAll()
	{
		if (this.ButtonNodeOperate.ToolTip == "NoExpand")
		{
			this.TreeViewData.ExpandAll();
			this.ButtonNodeOperate.Text = "全部收缩";
			this.ButtonNodeOperate.ToolTip = "Expand";
			this.ButtonNodeOperate.CssClass = "shuoso picbtn";
		}
		else
		{
			this.TreeViewData.CollapseAll();
			this.ButtonNodeOperate.Text = "全部展开";
			this.ButtonNodeOperate.ToolTip = "NoExpand";
			this.ButtonNodeOperate.CssClass = "zhankai picbtn";
		}
	}
}
