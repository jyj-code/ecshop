using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_SupplyDemandCommentAudit_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected Localize LocalizeIsAudit;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected Localize LocalizeTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected Localize LocalizeFavourTickitName;
	protected System.Web.UI.WebControls.TextBox TextBoxFavourTickitName;
	protected Localize LocalizeCreateMember;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateMerber;
	protected System.Web.UI.WebControls.TextBox TextBoxFavorableGuid;
	protected Localize LocalizeCreateTime;
	protected System.Web.UI.WebControls.TextBox TextBoxTime1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender4;
	protected System.Web.UI.WebControls.TextBox TextBoxTime2;
	protected RegularExpressionValidator RegularExpressionValidatorEndDate;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonSearchDetail;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
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
		if (!base.IsPostBack)
		{
			this.method_5();
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	private void method_5()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-2";
		this.DropDownListIsAudit.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "未审核";
		listItem2.Value = "0";
		this.DropDownListIsAudit.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "审核未通过";
		listItem3.Value = "2";
		this.DropDownListIsAudit.Items.Add(listItem3);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
		if (shopNum1_SupplyDemandComment_Action.DeleteSupplyDemandComment(this.CheckGuid.Value.ToString()) > 0)
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
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
		if (shopNum1_SupplyDemandComment_Action.UpdateSupplyDemandCommentAudit(this.CheckGuid.Value, "1") > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
		if (shopNum1_SupplyDemandComment_Action.UpdateSupplyDemandCommentAudit(this.CheckGuid.Value, "2") > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else
		{
			result = "审核未通过";
		}
		return result;
	}
	protected void ButtonSearchDetail_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SupplyDemandComment_Operate.aspx?guid=" + this.CheckGuid.Value + "&&type=audit");
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
		int num = shopNum1_SupplyDemandComment_Action.DeleteSupplyDemandComment("'" + commandArgument + "'");
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
