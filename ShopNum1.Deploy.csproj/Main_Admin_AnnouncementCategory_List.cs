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
public class Main_Admin_AnnouncementCategory_List : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabeTitle;
	protected TreeView TreeViewCategory;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonNodeOperate;
	protected MessageShow MessageShow;
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
			this.BindAnnouncementCategory();
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("AnnouncementCategory_Operate.aspx?id=" + this.CheckGuid.Value);
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
			this.strid = this.strid.Replace("-1", "");
			this.strid = this.strid.Substring(0, this.strid.Length - 1);
			try
			{
				string[] array = this.strid.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					string nameById = Common.GetNameById("Name", "ShopNum1_AnnouncementCategory", " and  ID='" + array[i].ToString() + "'");
					if (nameById == "店铺公告" || nameById == "会员公告")
					{
						MessageBox.Show("请不要删除特定的分类【店铺公告】和【会员公告】!");
						return;
					}
				}
			}
			catch (Exception)
			{
			}
			ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
			int num = shopNum1_AnnouncementCategory_Action.Delete(this.strid);
			if (num == -1)
			{
				this.MessageShow.ShowMessage("AnnouncementCategory");
				this.MessageShow.Visible = true;
			}
			if (num == 1)
			{
				this.BindAnnouncementCategory();
				this.MessageShow.ShowMessage("DelYes");
				this.MessageShow.Visible = true;
			}
			if (num == 0)
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
				base.Response.Redirect("AnnouncementCategory_Operate.aspx?id=" + treeNode.Value.ToString());
			}
			this.GetNode(treeNode.ChildNodes);
		}
	}
	protected void BindAnnouncementCategory()
	{
		this.TreeViewCategory.Nodes.Clear();
		ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
		DataTable dataTable = shopNum1_AnnouncementCategory_Action.Search(0, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["Name"].ToString();
			treeNode.Value = dataRow["ID"].ToString().Trim();
			treeNode.SelectAction = TreeNodeSelectAction.Select;
			treeNode.Expanded = new bool?(false);
			this.TreeViewCategory.Nodes.Add(treeNode);
			DataTable dataTable2 = shopNum1_AnnouncementCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubAnnouncementCategory(treeNode, dataTable2);
			}
		}
	}
	protected void AddSubAnnouncementCategory(TreeNode fatherNode, DataTable dataTable)
	{
		ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["Name"].ToString();
			treeNode.Value = dataRow["ID"].ToString().Trim();
			treeNode.SelectAction = TreeNodeSelectAction.Select;
			treeNode.Expanded = new bool?(false);
			fatherNode.ChildNodes.Add(treeNode);
			DataTable dataTable2 = shopNum1_AnnouncementCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubAnnouncementCategory(treeNode, dataTable2);
			}
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
