using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ArticleCategory_List : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabeTitle;
	protected TreeView TreeViewCategory;
	protected Button ButtonAdd;
	protected Button Button2;
	protected Button ButtonDelete;
	protected Button ButtonNodeOperate;
	protected MessageShow MessageShow;
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
		if (!this.Page.IsPostBack)
		{
			this.BindArticleCategory();
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("ArticleCategory_Operate.aspx");
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		TreeNodeCollection nodes = this.TreeViewCategory.Nodes;
		this.GetNode(nodes);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		TreeNodeCollection nodes = this.TreeViewCategory.Nodes;
		this.GetNodeDel(nodes);
		if (this.strid == "-1")
		{
			MessageBox.Show("请选择要删除的记录!");
		}
		else
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			int num = shopNum1_ArticleCategory_Action.Delete(this.strid);
			if (num == -1)
			{
				this.MessageShow.ShowMessage("AnnouncementCategory");
				this.MessageShow.Visible = true;
			}
			else if (num == 2)
			{
				this.MessageShow.ShowMessage("SupplyCategory");
				this.MessageShow.Visible = true;
			}
			else if (num == 1)
			{
				this.BindArticleCategory();
				this.MessageShow.ShowMessage("DelYes");
				this.MessageShow.Visible = true;
			}
			else if (num == 0)
			{
				this.MessageShow.ShowMessage("DelNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	public void GetNodeDel(TreeNodeCollection treeNodeCollection_0)
	{
		foreach (TreeNode treeNode in treeNodeCollection_0)
		{
			if (treeNode.Checked)
			{
				this.strid = treeNode.Value.ToString();
			}
			this.GetNodeDel(treeNode.ChildNodes);
		}
	}
	public void GetNode(TreeNodeCollection treeNodeCollection_0)
	{
		foreach (TreeNode treeNode in treeNodeCollection_0)
		{
			if (treeNode.Checked)
			{
				base.Response.Redirect("ArticleCategory_Operate.aspx?id=" + treeNode.Value.ToString());
			}
			this.GetNode(treeNode.ChildNodes);
		}
	}
	protected void BindArticleCategory()
	{
		this.TreeViewCategory.Nodes.Clear();
		ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
		DataTable dataTable = shopNum1_ArticleCategory_Action.Search(0, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["Name"].ToString();
			treeNode.Value = dataRow["ID"].ToString().Trim();
			treeNode.SelectAction = TreeNodeSelectAction.Select;
			treeNode.Expanded = new bool?(false);
			this.TreeViewCategory.Nodes.Add(treeNode);
			DataTable dataTable2 = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubArticleCategory(treeNode, dataTable2);
			}
		}
	}
	protected void AddSubArticleCategory(TreeNode fatherNode, DataTable dataTable)
	{
		ShopNum1_ArticleCategory_Action arg_0A_0 = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["Name"].ToString();
			treeNode.Value = dataRow["ID"].ToString().Trim();
			treeNode.SelectAction = TreeNodeSelectAction.Select;
			treeNode.Expand();
			fatherNode.ChildNodes.Add(treeNode);
		}
	}
	protected void TreeViewCategory_SelectedNodeChanged(object sender, EventArgs e)
	{
	}
	protected void ButtonNodeOperate_Click(object sender, EventArgs e)
	{
		this.ExpendAll();
	}
	public void ExpendAll()
	{
		if (this.ButtonNodeOperate.ToolTip == "NoExpand")
		{
			this.TreeViewCategory.ExpandAll();
			this.ButtonNodeOperate.Text = "全部收缩";
			this.ButtonNodeOperate.ToolTip = "Expand";
			this.ButtonNodeOperate.CssClass = "shuoso picbtn";
		}
		else
		{
			this.TreeViewCategory.CollapseAll();
			this.ButtonNodeOperate.Text = "全部展开";
			this.ButtonNodeOperate.ToolTip = "NoExpand";
			this.ButtonNodeOperate.CssClass = "zhankai picbtn";
		}
	}
}
