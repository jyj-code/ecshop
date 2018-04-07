using ShopNum1.Control;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopApplyRankChecked_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeIsAudit;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected Localize Localize1;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
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
			this.BindProductIsAduit();
		}
	}
	protected void BindProductIsAduit()
	{
		this.DropDownListIsAudit.Items.Clear();
		this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)LogicFactory.CreateShop_ShopApplyRank_Action();
		int num = shop_ShopApplyRank_Action.Check(this.CheckGuid.Value.Replace("'", ""), "1");
		if (num > 0)
		{
			string[] array = this.CheckGuid.Value.Replace("'", "").Split(new char[]
			{
				','
			});
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				num2 += shop_ShopApplyRank_Action.UpdataShopRank(array[i]);
			}
			if (num2 == array.Length)
			{
				this.Num1GridViewShow.DataBind();
				this.MessageShow.Visible = true;
				this.MessageShow.ShowMessage("OperateYes");
			}
			else
			{
				this.MessageShow.Visible = true;
				this.MessageShow.ShowMessage("OperateNo");
			}
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("OperateNo");
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)LogicFactory.CreateShop_ShopApplyRank_Action();
		int num = shop_ShopApplyRank_Action.Check(this.CheckGuid.Value.Replace("'", ""), "2");
		if (num > 0)
		{
			this.Num1GridViewShow.DataBind();
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("OperateYes");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("OperateNo");
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)LogicFactory.CreateShop_ShopApplyRank_Action();
		int num = shop_ShopApplyRank_Action.Delete("'" + this.CheckGuid.Value.Replace("'", "") + "'");
		if (num > 0)
		{
			this.Num1GridViewShow.DataBind();
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("DelYes");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("DelNo");
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string iD = "'" + linkButton.CommandArgument + "'";
		Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)LogicFactory.CreateShop_ShopApplyRank_Action();
		int num = shop_ShopApplyRank_Action.Delete(iD);
		if (num > 0)
		{
			this.Num1GridViewShow.DataBind();
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("DelYes");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("DelNo");
		}
	}
	protected string IsAudit(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "1")
		{
			result = "已通过";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
}
