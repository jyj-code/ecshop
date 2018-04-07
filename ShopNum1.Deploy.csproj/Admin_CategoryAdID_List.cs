using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_CategoryAdID_List : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.DropDownList DropDownListAdPageName;
	protected System.Web.UI.WebControls.TextBox TextBoxAdID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonSearchDetail;
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
			this.BindGrid();
		}
	}
	public string PageName(object object_0)
	{
		string a = object_0.ToString();
		string result;
		if (a == "1")
		{
			result = "商品分类";
		}
		else if (a == "2")
		{
			result = "分类信息分类";
		}
		else if (a == "3")
		{
			result = "供求分类";
		}
		else if (a == "4")
		{
			result = "店铺分类";
		}
		else if (a == "5")
		{
			result = "资讯分类";
		}
		else if (a == "6")
		{
			result = "品牌分类";
		}
		else
		{
			result = "非法页面";
		}
		return result;
	}
	public void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("CategoryAdID_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryAdID_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryAdID_Action shopNum1_CategoryAdID_Action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
		int num = shopNum1_CategoryAdID_Action.Delete(this.CheckGuid.Value);
		if (num == -2)
		{
			MessageBox.Show("广告位下面有广告，请先删除广告后再删除广告位!");
		}
		else if (num > 0)
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonSearchDetail_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryAdID_SearchDetail.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryAdID_Action shopNum1_CategoryAdID_Action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_CategoryAdID_Action.Delete(commandArgument);
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
