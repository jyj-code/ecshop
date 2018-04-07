using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopRank_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridviewShow;
	protected ObjectDataSource ObjectDataSourceDate;
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
	protected void BindGrid()
	{
		this.Num1GridviewShow.DataBind();
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopRank_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEditBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		MessageBox.Show(commandArgument);
		base.Response.Redirect("ShopRank_Operate.aspx?guid=" + commandArgument);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)LogicFactory.CreateShop_Rank_Action();
		int num = shop_Rank_Action.Delete(this.CheckGuid.Value);
		if (num == -1)
		{
			MessageBox.Show("默认等级不能删除！");
		}
		else if (num == -2)
		{
			MessageBox.Show("该等级下含有店铺，不允许删除！");
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
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)LogicFactory.CreateShop_Rank_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shop_Rank_Action.Delete("'" + commandArgument + "'");
		if (num == -1)
		{
			MessageBox.Show("默认等级不能删除！");
		}
		else if (num == -2)
		{
			MessageBox.Show("该等级下含有店铺，不允许删除！");
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
	protected string IsType(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "默认";
		}
		else if (object_0.ToString() == "0")
		{
			result = "非默认";
		}
		else
		{
			result = "非法类型";
		}
		return result;
	}
	protected string IsDoMain(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "不可以";
		}
		else if (object_0.ToString() == "1")
		{
			result = "可以";
		}
		else
		{
			result = "非法类型";
		}
		return result;
	}
	protected void DropDownListType_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	public string GetRight(string isshow, string strtype)
	{
		string result;
		if (strtype == "0")
		{
			if (isshow == "0")
			{
				result = "images/shopNum1Admin-right.gif";
			}
			else
			{
				result = "images/shopNum1Admin-wrong.gif";
			}
		}
		else if (isshow == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
}
