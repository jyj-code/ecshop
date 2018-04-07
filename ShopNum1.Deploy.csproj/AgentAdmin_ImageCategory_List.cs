using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ImageCategory_List : PageBase, IRequiresSessionState
{
	public string strid = "-1";
	protected ScriptManager ScriptManager1;
	protected Label LabeTitle;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
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
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ImageCategory_Operate.aspx");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		int num = shopNum1_ImageCategory_Action.DeleteType(this.CheckGuid.Value);
		if (num > 0)
		{
			this.BindProductCategory();
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
		string b = "";
		if (base.Request.Cookies["AdminLoginCookie"] != null)
		{
			HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			b = httpCookie.Values["Guid"].ToString();
		}
		LinkButton linkButton = (LinkButton)sender;
		if (linkButton.CommandArgument == "1")
		{
			this.MessageShow.ShowMessage("默认分类禁止删除！");
			this.MessageShow.Visible = true;
		}
		else
		{
			string text = "'" + linkButton.CommandArgument + "'";
			if (text.Replace("'", " ").ToUpper() == b)
			{
				MessageBox.Show("自己不能删除自己!");
			}
			else
			{
				ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
				int num = shopNum1_ImageCategory_Action.Delete(text);
				if (num > 0)
				{
					this.BindProductCategory();
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
	protected void BindProductCategory()
	{
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		DataTable dataTable = shopNum1_ImageCategory_Action.Search(0);
		this.Num1GridViewShow.DataSource = dataTable.DefaultView;
		this.Num1GridViewShow.DataBind();
	}
	protected void AddSubProductCategory(TreeNode fatherNode, DataTable dataTable)
	{
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		foreach (DataRow dataRow in dataTable.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["Name"].ToString();
			treeNode.Value = dataRow["ID"].ToString().Trim();
			treeNode.SelectAction = TreeNodeSelectAction.Select;
			treeNode.Expand();
			fatherNode.ChildNodes.Add(treeNode);
			DataTable dataTable2 = shopNum1_ImageCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()));
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubProductCategory(treeNode, dataTable2);
			}
		}
	}
	protected void AddSubProductCategoryInData(int newId, DataTable dataTable, DataTable dataTableImg)
	{
		bool flag = false;
		ShopNum1_ImageCategory_Action shopNum1_ImageCategory_Action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			flag = false;
			foreach (DataRow dataRow in dataTableImg.Rows)
			{
				if (dataTable.Rows[i]["Name"].ToString() == dataRow["Name"].ToString())
				{
					flag = true;
					break;
				}
			}
			DataRow dataRow2 = dataTable.Rows[i];
			Convert.ToInt32(dataRow2["ID"]);
			string name = dataRow2["Name"].ToString();
			string description = dataRow2["Description"].ToString();
			string fatherID = dataRow2["FatherID"].ToString();
			int num = Convert.ToInt32(dataRow2["CategoryLevel"]);
			string shopNum1LoginID = base.ShopNum1LoginID;
			string text = shopNum1_ImageCategory_Action.GetMaxID().ToString();
			if (!flag)
			{
				shopNum1_ImageCategory_Action.Insert(name, description, num.ToString(), newId.ToString(), "null", shopNum1LoginID);
			}
			else
			{
				DataTable idByName = shopNum1_ImageCategory_Action.GetIdByName(name, fatherID);
				text = ((idByName == null || idByName.Rows.Count <= 0) ? text : idByName.Rows[0]["ID"].ToString());
			}
			DataTable dataTable2 = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(dataRow2["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				DataTable dataTableImg2 = shopNum1_ImageCategory_Action.Search(Convert.ToInt32(dataRow2["ID"].ToString().Trim()));
				this.AddSubProductCategoryInData(int.Parse(text), dataTable2, dataTableImg2);
			}
		}
	}
	protected void Page_Changing(object sender, GridViewPageEventArgs e)
	{
		this.Num1GridViewShow.PageIndex = e.NewPageIndex;
		this.BindProductCategory();
	}
}
