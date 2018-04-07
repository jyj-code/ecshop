using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopArticle_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxRepeat;
	protected System.Web.UI.WebControls.TextBox TextBoxPublisher;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxRepeat0;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.TextBox textBoxStartDate;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox textBoxEndDate;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonSearchDetails;
	protected System.Web.UI.WebControls.DropDownList DropDownListOperate;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonHidden;
	protected LinkButton ButtonBrowse;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
	protected ObjectDataSource ObjectDataSourceData;
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
		if (!base.IsPostBack)
		{
			this.method_5();
			this.method_6();
		}
	}
	public string GetShopName(string memloginId)
	{
		return Common.GetNameById("shopname", "shopnum1_shopinfo", " and memloginid='" + memloginId + "'");
	}
	private void method_5()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "正常";
		listItem.Value = "1";
		this.DropDownListIsAudit.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "禁止";
		listItem2.Value = "3";
		this.DropDownListIsAudit.Items.Add(listItem2);
	}
	private void method_6()
	{
		this.Num1GridViewShow.DataBind();
	}
	public string ChangeIsAudit(object strIsAudit)
	{
		string result;
		if (strIsAudit.ToString() == "0")
		{
			result = "未审核";
		}
		else if (strIsAudit.ToString() == "1")
		{
			result = "正常";
		}
		else if (strIsAudit.ToString() == "2")
		{
			result = "已审核";
		}
		else if (strIsAudit.ToString() == "3")
		{
			result = "禁止";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)LogicFactory.CreateShopNum1_ArticleCheck_Action();
		int num = shopNum1_ArticleCheck_Action.Delete(this.CheckGuid.Value.ToString());
		this.method_6();
		if (num > 0)
		{
			this.method_6();
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
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)LogicFactory.CreateShopNum1_ArticleCheck_Action();
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		int num = shopNum1_ArticleCheck_Action.Delete(guids);
		if (num > 0)
		{
			this.method_6();
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
		this.method_6();
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		if (this.DropDownListOperate.SelectedValue != "0")
		{
			ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)LogicFactory.CreateShopNum1_ArticleCheck_Action();
			if (shopNum1_ArticleCheck_Action.UpdateAudit(this.CheckGuid.Value.ToString(), int.Parse(this.DropDownListOperate.SelectedValue)) > 0)
			{
				this.method_6();
				this.MessageShow.ShowMessage("Audit2Yes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("Audit2No");
				this.MessageShow.Visible = true;
			}
		}
		else
		{
			this.MessageShow.ShowMessage("请选择操作");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonSearchDetails_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopArticle_Details.aspx?guid=" + this.CheckGuid.Value);
	}
}
