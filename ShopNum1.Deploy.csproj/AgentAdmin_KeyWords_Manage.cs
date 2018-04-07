using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_KeyWords_Manage : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.TextBox TextBoxQKeyWords;
	protected System.Web.UI.WebControls.DropDownList DropDownListQType;
	protected System.Web.UI.WebControls.TextBox TextBoxQCount;
	protected RegularExpressionValidator RegularExpressionValidatorQCount;
	protected System.Web.UI.WebControls.DropDownList DropDownListQIfShow;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldSubstationID;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!this.Page.IsPostBack)
		{
			this.BindStatus();
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
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("KeyWords_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("KeyWords_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_KeyWords_Action shopNum1_KeyWords_Action = (ShopNum1_KeyWords_Action)LogicFactory.CreateShopNum1_KeyWords_Action();
		int num = shopNum1_KeyWords_Action.Delete(this.CheckGuid.Value);
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
	protected void BindStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "2";
		this.DropDownListQIfShow.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "-请选择-";
		listItem2.Value = "-1";
		ListItem listItem3 = new ListItem();
		listItem3.Text = "商品";
		listItem3.Value = "0";
		ListItem listItem4 = new ListItem();
		listItem4.Text = "资讯";
		listItem4.Value = "1";
		ListItem listItem5 = new ListItem();
		listItem5.Text = "显示";
		listItem5.Value = "1";
		this.DropDownListQIfShow.Items.Add(listItem5);
		ListItem listItem6 = new ListItem();
		listItem6.Text = "不显示";
		listItem6.Value = "0";
		this.DropDownListQIfShow.Items.Add(listItem6);
	}
	public string ChangeType(string strType)
	{
		string result;
		if (strType == "1")
		{
			result = "商品";
		}
		else if (strType == "2")
		{
			result = "店铺";
		}
		else if (strType == "3")
		{
			result = "资讯";
		}
		else if (strType == "4")
		{
			result = "分类";
		}
		else if (strType == "5")
		{
			result = "供求";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIfShow(string strIfShow)
	{
		string result;
		if (strIfShow == "0")
		{
			result = "否";
		}
		else if (strIfShow == "1")
		{
			result = "是";
		}
		else
		{
			result = "";
		}
		return result;
	}
}
