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
public class Main_Admin_CategoryComment_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Label LabelTitle;
	protected Localize LocalizeTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected Localize LocalizeCategoryName;
	protected System.Web.UI.WebControls.TextBox TextBoxCategoryName;
	protected Localize LocalizeCreateMember;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateMerber;
	protected Localize LocalizeCategoryGuid;
	protected System.Web.UI.WebControls.TextBox TextBoxCategoryGuid;
	protected Localize LocalizeCreateTime;
	protected System.Web.UI.WebControls.TextBox TextBoxTime1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender4;
	protected System.Web.UI.WebControls.TextBox TextBoxTime2;
	protected RegularExpressionValidator RegularExpressionValidatorEndDate;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.Button ButtonSearchDetail;
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
		listItem.Text = "已审核";
		listItem.Value = "1";
		this.DropDownListIsAudit.Items.Add(listItem);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryComment_Action shopNum1_CategoryComment_Action = (ShopNum1_CategoryComment_Action)LogicFactory.CreateShopNum1_CategoryComment_Action();
		if (shopNum1_CategoryComment_Action.DeleteCategoryComment(this.CheckGuid.Value.ToString()) > 0)
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
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_CategoryComment_Action shopNum1_CategoryComment_Action = (ShopNum1_CategoryComment_Action)LogicFactory.CreateShopNum1_CategoryComment_Action();
		int num = shopNum1_CategoryComment_Action.DeleteCategoryComment(guids);
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
		base.Response.Redirect("CategoryComment_Operate.aspx?guid=" + this.CheckGuid.Value + "&&type=list");
	}
}
