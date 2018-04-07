using ShopNum1.Control;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopApplyRank_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeIsAudit;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Num1GridView Num1GridViewShow;
	protected System.Web.UI.WebControls.Button ButtonAudit;
	protected System.Web.UI.WebControls.Button ButtonCancelAudit;
	protected System.Web.UI.WebControls.Button ButtonDelete;
	protected MessageShow MessageShow;
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
			int num2 = shop_ShopApplyRank_Action.UpdataShopRank(this.CheckGuid.Value.Replace("'", ""));
			if (num2 > 0)
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
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)LogicFactory.CreateShop_ShopApplyRank_Action();
		int num = shop_ShopApplyRank_Action.Delete(this.CheckGuid.Value.Replace("'", ""));
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
}
