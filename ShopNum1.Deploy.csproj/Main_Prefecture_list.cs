using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Prefecture_list : PageBase, IRequiresSessionState
{
	public string strid = "-1";
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabeTitle;
	protected TreeView TreeViewData;
	protected UpdatePanel UpdatePanel1;
	protected LinkButton ButtonAdd;
	protected LinkButton Button2;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonNodeOperate;
	protected LinkButton btnCreateRegion;
	protected MessageShow MessageShow;
	protected MessageShow MessageShow1;
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
		if (!base.IsPostBack)
		{
			this.method_5();
			this.TreeViewData.Attributes.Add("onclick", "getcheck(event)");
		}
	}
	protected void btnCreateRegion_Click(object sender, EventArgs e)
	{
		string strSql = "select name,code from shopnum1_region where categorylevel=1";
		DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("//jely " + DateTime.Now.ToLocalTime() + " 新增区域 json \r\n");
		stringBuilder.Append("var Json_vj={\"province\":[");
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			stringBuilder.Append(string.Concat(new object[]
			{
				"{\"name\":\"",
				dataTable.Rows[i]["name"],
				"\", \"code\":\"",
				dataTable.Rows[i]["code"],
				"\"},"
			}));
		}
		stringBuilder.Remove(stringBuilder.Length - 1, 1);
		string strSql2 = "select name,code from shopnum1_region where categorylevel=2";
		DataTable dataTable2 = DatabaseExcetue.ReturnDataTable(strSql2);
		stringBuilder.Append("],\"city\":[");
		for (int i = 0; i < dataTable2.Rows.Count; i++)
		{
			stringBuilder.Append(string.Concat(new object[]
			{
				"{\"name\":\"",
				dataTable2.Rows[i]["name"],
				"\", \"code\":\"",
				dataTable2.Rows[i]["code"],
				"\"},"
			}));
		}
		stringBuilder.Remove(stringBuilder.Length - 1, 1);
		stringBuilder.Append("],\"district\":[");
		string strSql3 = "select name,code from shopnum1_region where categorylevel=3";
		DataTable dataTable3 = DatabaseExcetue.ReturnDataTable(strSql3);
		for (int i = 0; i < dataTable3.Rows.Count; i++)
		{
			stringBuilder.Append(string.Concat(new object[]
			{
				"{\"name\":\"",
				dataTable3.Rows[i]["name"],
				"\", \"code\":\"",
				dataTable3.Rows[i]["code"],
				"\"},"
			}));
		}
		stringBuilder.Remove(stringBuilder.Length - 1, 1);
		stringBuilder.Append("]}");
		FileStream stream = new FileStream(base.Server.MapPath("/Main/js/areas.js"), FileMode.Create);
		StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8);
		streamWriter.Write(stringBuilder.ToString());
		streamWriter.Dispose();
		streamWriter.Close();
		MessageBox.Show("恭喜您生成成功！");
	}
	private void method_5()
	{
		ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
		shopNum1_DispatchRegion_Action.TableName = "ShopNum1_Region";
		DataTable dataTable = shopNum1_DispatchRegion_Action.SearchtDispatchRegion(0, 0);
		if (dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Text = dataRow["Name"].ToString();
				treeNode.Value = dataRow["ID"].ToString();
				treeNode.Expanded = new bool?(false);
				if (this.method_9(Convert.ToInt32(treeNode.Value)))
				{
					treeNode.PopulateOnDemand = true;
				}
				else
				{
					treeNode.PopulateOnDemand = false;
				}
				this.TreeViewData.Nodes.Add(treeNode);
			}
		}
	}
	private void method_6(TreeNode treeNode_0, int int_0)
	{
		ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
		shopNum1_DispatchRegion_Action.TableName = "ShopNum1_Region";
		DataTable dataTable = shopNum1_DispatchRegion_Action.SearchtDispatchRegion(int_0, 0);
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
		base.Response.Redirect("ShopNum1Region_Operate.aspx?guid=" + this.CheckGuid.Value);
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
				base.Response.Redirect("ShopNum1Region_Operate.aspx?guid=" + treeNode.Value.ToString());
			}
			this.GetNode(treeNode.ChildNodes);
		}
	}
	private void method_7()
	{
		base.RegisterStartupScript("PAGE", "window.location.href=window.location.href;");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		TreeNodeCollection nodes = this.TreeViewData.Nodes;
		this.method_8(nodes);
		if (this.strid == "-1")
		{
			MessageBox.Show("请选择要删除的记录!");
		}
		else
		{
			ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
			shopNum1_DispatchRegion_Action.TableName = "ShopNum1_Region";
			int num = shopNum1_DispatchRegion_Action.Delete(this.strid);
			if (num == 2)
			{
				this.MessageShow.ShowMessage("Region");
				this.MessageShow.Visible = true;
			}
			if (num == 1)
			{
				this.TreeViewData.Nodes.Clear();
				this.method_5();
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
	private void method_8(TreeNodeCollection treeNodeCollection_0)
	{
		foreach (TreeNode treeNode in treeNodeCollection_0)
		{
			if (treeNode.Checked)
			{
				this.strid = treeNode.Value.ToString();
			}
			this.method_8(treeNode.ChildNodes);
		}
	}
	protected void TreeViewData_SelectedNodeChanged(object sender, EventArgs e)
	{
		TreeView treeView = sender as TreeView;
		TreeNode selectedNode = treeView.SelectedNode;
		this.CheckGuid.Value = selectedNode.Value.ToString();
		base.Response.Redirect("ShopNum1Region_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void TreeViewData_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
	{
		e.Node.ChildNodes.Clear();
		ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
		shopNum1_DispatchRegion_Action.TableName = "ShopNum1_Region";
		int fatherID = Convert.ToInt32(e.Node.Value);
		DataTable dataTable = shopNum1_DispatchRegion_Action.SearchtDispatchRegion(fatherID, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Value = dataRow["ID"].ToString();
			treeNode.Text = dataRow["Name"].ToString();
			treeNode.Expanded = new bool?(false);
			treeNode.NavigateUrl = "javascript:void(0);";
			if (this.method_9(Convert.ToInt32(dataRow["ID"])))
			{
				treeNode.PopulateOnDemand = true;
			}
			else
			{
				treeNode.PopulateOnDemand = false;
			}
			treeNode.Collapse();
			e.Node.ChildNodes.Add(treeNode);
		}
	}
	private bool method_9(int int_0)
	{
		ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
		shopNum1_DispatchRegion_Action.TableName = "ShopNum1_Region";
		int dispatchCount = shopNum1_DispatchRegion_Action.GetDispatchCount(int_0, 0);
		return dispatchCount != 0;
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
