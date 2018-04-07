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
public class AgentAdmin_ShopVedio_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
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
	protected System.Web.UI.WebControls.Button Button1;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonSearchDetails;
	protected System.Web.UI.WebControls.DropDownList DropDownListOperate;
	protected LinkButton ButtonAudit;
	protected LinkButton ButtonHidden;
	protected LinkButton ButtonBrowse;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldSubstationID;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!base.IsPostBack)
		{
			this.method_5();
			this.method_6();
		}
	}
	private void method_5()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-3";
		this.DropDownListIsAudit.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "已审核";
		listItem2.Value = "1";
		this.DropDownListIsAudit.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "禁止";
		listItem3.Value = "3";
		this.DropDownListIsAudit.Items.Add(listItem3);
		ListItem listItem4 = new ListItem();
		listItem4.Text = "未通过";
		listItem4.Value = "2";
		this.DropDownListIsAudit.Items.Add(listItem4);
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
			result = "已审核";
		}
		else if (strIsAudit.ToString() == "2")
		{
			result = "未通过";
		}
		else if (strIsAudit.ToString() == "3")
		{
			result = "禁止";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Vedio_List_Action shopNum1_Vedio_List_Action = (ShopNum1_Vedio_List_Action)LogicFactory.CreateShopNum1_Vedio_List_Action();
		int num = shopNum1_Vedio_List_Action.Delete(this.CheckGuid.Value.ToString());
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
		ShopNum1_Vedio_List_Action shopNum1_Vedio_List_Action = (ShopNum1_Vedio_List_Action)LogicFactory.CreateShopNum1_Vedio_List_Action();
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		int num = shopNum1_Vedio_List_Action.Delete(guids);
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
			ShopNum1_Vedio_List_Action shopNum1_Vedio_List_Action = (ShopNum1_Vedio_List_Action)LogicFactory.CreateShopNum1_Vedio_List_Action();
			if (shopNum1_Vedio_List_Action.UpdateAudit(this.CheckGuid.Value.ToString(), int.Parse(this.DropDownListOperate.SelectedValue)) > 0)
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
		base.Response.Redirect("ShopVedio_Details.aspx?guid=" + this.CheckGuid.Value);
	}
}
