using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class MainAdmin_City_List : PageBase, IRequiresSessionState
{
	public string strid = "-1";
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected TreeView TreeViewCategory;
	protected Button ButtonAdd;
	protected Button ButtonEdit;
	protected Button ButtonDelete;
	protected Button ButtonNodeOperate;
	protected MessageShow MessageShow;
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
			this.BindProductCategory();
			if (this.ButtonNodeOperate.ToolTip == "NoExpand")
			{
				this.TreeViewCategory.CollapseAll();
			}
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("City_Operate.aspx");
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		TreeNodeCollection nodes = this.TreeViewCategory.Nodes;
		this.GetNode(nodes);
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
				base.Response.Redirect("City_Operate.aspx?id=" + treeNode.Value.ToString());
			}
			this.GetNode(treeNode.ChildNodes);
		}
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
			ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
			if (shopNum1_City_Action.Search2(Convert.ToInt32(this.strid), 0).Rows.Count > 0)
			{
				MessageBox.Show("先删除子分类");
			}
			else
			{
				int num = shopNum1_City_Action.Delete(this.strid);
				if (num == -1)
				{
					this.MessageShow.ShowMessage("DelProductCategoryNo");
					this.MessageShow.Visible = true;
				}
				if (num == -2)
				{
					this.MessageShow.ShowMessage("DelProductCategoryNo2");
					this.MessageShow.Visible = true;
				}
				if (num == 1)
				{
					base.OperateLog(new ShopNum1_OperateLog
					{
						Record = "删除成功",
						OperatorID = base.ShopNum1LoginID,
						IP = Globals.IPAddress,
						PageName = "City_List.aspx",
						Date = DateTime.Now
					});
					this.BindProductCategory();
					this.MessageShow.ShowMessage("DelYes");
					this.MessageShow.Visible = true;
					this.TreeViewCategory.CollapseAll();
				}
				if (num == 0)
				{
					this.MessageShow.ShowMessage("DelNo");
					this.MessageShow.Visible = true;
				}
			}
		}
	}
	protected void BindProductCategory()
	{
		this.TreeViewCategory.Nodes.Clear();
		ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
		DataTable dataTable = shopNum1_City_Action.Search(0, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["CityName"].ToString();
			treeNode.Value = dataRow["ID"].ToString().Trim();
			treeNode.SelectAction = TreeNodeSelectAction.Select;
			treeNode.Expand();
			this.TreeViewCategory.Nodes.Add(treeNode);
			DataTable dataTable2 = shopNum1_City_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubProductCategory(treeNode, dataTable2);
			}
		}
	}
	protected void AddSubProductCategory(TreeNode fatherNode, DataTable dataTable)
	{
		ShopNum1_City_Action shopNum1_City_Action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["CityName"].ToString();
			treeNode.Value = dataRow["ID"].ToString().Trim();
			treeNode.SelectAction = TreeNodeSelectAction.Select;
			treeNode.Expand();
			fatherNode.ChildNodes.Add(treeNode);
			DataTable dataTable2 = shopNum1_City_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubProductCategory(treeNode, dataTable2);
			}
		}
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
			this.ButtonNodeOperate.Text = "全部折叠";
			this.ButtonNodeOperate.ToolTip = "Expand";
		}
		else
		{
			this.TreeViewCategory.CollapseAll();
			this.ButtonNodeOperate.Text = "全部展开";
			this.ButtonNodeOperate.ToolTip = "NoExpand";
		}
	}
}
