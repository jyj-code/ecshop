using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopNum1_CategoryType_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelCategoryName;
	protected System.Web.UI.WebControls.TextBox TextBoxCategoryName;
	protected Label LabelName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected Label LabelID;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsShow;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
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
			this.DropDownListIsShowBing();
			this.BindGrid();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		int num = shopNum1_ProductCategory_Action.DeleteTypeC(this.CheckGuid.Value);
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
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopNum1_CategoryType_Operate.aspx");
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopNum1_CategoryType_Operate.aspx?guid=" + this.CheckGuid.Value.Replace("'", ""));
	}
	protected void DropDownListIsShowBing()
	{
		this.DropDownListIsShow.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListIsShow.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "显示";
		listItem2.Value = "1";
		this.DropDownListIsShow.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "不显示";
		listItem3.Value = "0";
		this.DropDownListIsShow.Items.Add(listItem3);
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		int num = shopNum1_ProductCategory_Action.DeleteTypeC("'" + commandArgument + "'");
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
	protected string IsShow(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "不显示";
		}
		else if (object_0.ToString() == "1")
		{
			result = "显示";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
}
