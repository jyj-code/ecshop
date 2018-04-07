using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_UserDefinedColumn_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldAgentID;
	protected ObjectDataSource ObjectDataSourceData;
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
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("UserDefinedColumn_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("UserDefinedColumn_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_UserDefinedColumn_Action shopNum1_UserDefinedColumn_Action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
		int num = shopNum1_UserDefinedColumn_Action.Delete(this.CheckGuid.Value.ToString());
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	public string ChangeIfShow(string strIfShow)
	{
		string result;
		if (strIfShow == "0")
		{
			result = "不显示";
		}
		else if (strIfShow == "1")
		{
			result = "显示";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsMember(string isMember)
	{
		string result;
		if (isMember == "0")
		{
			result = "不显示";
		}
		else if (isMember == "1")
		{
			result = "显示";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsShop(string isShop)
	{
		string result;
		if (isShop == "0")
		{
			result = "不显示";
		}
		else if (isShop == "1")
		{
			result = "显示";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIfOpen(string strIfOpen)
	{
		string result;
		if (strIfOpen == "0")
		{
			result = "本窗口打开";
		}
		else if (strIfOpen == "1")
		{
			result = "新窗口打开";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ShowLocation(string string_5)
	{
		string result;
		if (string_5.ToString() == "0")
		{
			result = "中部导航";
		}
		else if (string_5.ToString() == "1")
		{
			result = "底部导航";
		}
		else
		{
			result = "右上角导航";
		}
		return result;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guid = "'" + linkButton.CommandArgument + "'";
		ShopNum1_UserDefinedColumn_Action shopNum1_UserDefinedColumn_Action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
		int num = shopNum1_UserDefinedColumn_Action.Delete(guid);
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
