using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_VideoCategory_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected TreeView TreeViewCategory;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonNodeOperate;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HtmlForm form1;
	public string strid = "";
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
		base.Response.Redirect("VideoCategory_Operate.aspx");
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
				this.strid = this.strid + treeNode.Value.ToString() + ",";
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
				base.Response.Redirect("VideoCategory_Operate.aspx?id=" + treeNode.Value.ToString());
			}
			this.GetNode(treeNode.ChildNodes);
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		try
		{
			TreeNodeCollection nodes = this.TreeViewCategory.Nodes;
			this.GetNodeDel(nodes);
			if (this.strid == "")
			{
				MessageBox.Show("请选择要删除的记录!");
			}
			else
			{
				this.strid = this.strid.Remove(this.strid.ToString().LastIndexOf(","), 1);
				ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = new ShopNum1_VideoCategory_Action();
				int num = shopNum1_VideoCategory_Action.Delete(this.strid);
				if (num == -1)
				{
					this.MessageShow.ShowMessage("此分类中含有相关视频,不能删除此分类!");
					this.MessageShow.Visible = true;
				}
				if (num == -2)
				{
					this.MessageShow.ShowMessage("有子分类不能删除");
					this.MessageShow.Visible = true;
				}
				if (num == 1)
				{
					base.OperateLog(new ShopNum1_OperateLog
					{
						Record = "删除成功",
						OperatorID = base.ShopNum1LoginID,
						IP = Globals.IPAddress,
						PageName = "VideoCategory_List.aspx",
						Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
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
				this.TreeViewCategory.CollapseAll();
				this.ButtonNodeOperate.Text = "<span>全部展开</span>";
				this.ButtonNodeOperate.ToolTip = "NoExpand";
			}
		}
		catch
		{
		}
	}
	protected void BindProductCategory()
	{
		this.TreeViewCategory.Nodes.Clear();
		ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
		DataTable dataTable = shopNum1_VideoCategory_Action.Search(0, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["Name"].ToString();
			treeNode.Value = dataRow["ID"].ToString().Trim();
			treeNode.SelectAction = TreeNodeSelectAction.Select;
			treeNode.Expand();
			this.TreeViewCategory.Nodes.Add(treeNode);
			DataTable dataTable2 = shopNum1_VideoCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubProductCategory(treeNode, dataTable2);
			}
		}
	}
	protected void AddSubProductCategory(TreeNode fatherNode, DataTable dataTable)
	{
		ShopNum1_VideoCategory_Action arg_0A_0 = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
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
