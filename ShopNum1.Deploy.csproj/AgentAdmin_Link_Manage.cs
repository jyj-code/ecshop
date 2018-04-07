using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Link_Manage : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsShow;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView num1GridViewShow;
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
			this.BindIsShow();
			this.BindGrid();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("Link_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Link_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
		int num = shopNum1_Link_Action.Delete(this.CheckGuid.Value.ToString());
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
	protected void BindGrid()
	{
		this.num1GridViewShow.DataBind();
	}
	protected void BindIsShow()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListIsShow.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "不显示";
		listItem2.Value = "0";
		this.DropDownListIsShow.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "显示";
		listItem3.Value = "1";
		this.DropDownListIsShow.Items.Add(listItem3);
	}
	public string ChangeIsShow(string strIsShow)
	{
		string result;
		if (strIsShow == "0")
		{
			result = "不显示";
		}
		else if (strIsShow == "1")
		{
			result = "显示";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeImgType(string strImgType)
	{
		string result;
		if (strImgType == "0")
		{
			result = "本地图片";
		}
		else if (strImgType == "1")
		{
			result = "远程图片";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeLinkType(string strLinkType)
	{
		string result;
		if (strLinkType == "0")
		{
			result = "文字链接";
		}
		else if (strLinkType == "1")
		{
			result = "图片链接";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
		int num = shopNum1_Link_Action.Delete(guids);
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
