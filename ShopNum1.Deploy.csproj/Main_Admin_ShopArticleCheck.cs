using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopArticleCheck : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected System.Web.UI.WebControls.TextBox TextBoxPublisher;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxRepeat0;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxRepeat;
	protected System.Web.UI.WebControls.TextBox textBoxStartDate;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox textBoxEndDate;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate0;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonSearchDetails;
	protected LinkButton LinkButton1;
	protected LinkButton Button1;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonHidden;
	protected LinkButton ButtonBrowse;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
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
		if (!base.IsPostBack)
		{
			this.GetDropDownListSubstationID();
			this.method_5();
			this.method_6();
		}
	}
	public void GetDropDownListSubstationID()
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	public string GetSubstationIDNameBySubstationID(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	private void method_5()
	{
		this.DropDownListIsAudit.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-2";
		this.DropDownListIsAudit.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "审核未通过";
		listItem2.Value = "2";
		this.DropDownListIsAudit.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "未审核";
		listItem3.Value = "0";
		this.DropDownListIsAudit.Items.Add(listItem3);
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
			result = "已通过";
		}
		else if (strIsAudit.ToString() == "2")
		{
			result = "审核未通过";
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
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ArticleCheck_Action();
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
		LinkButton linkButton = (LinkButton)sender;
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ArticleCheck_Action();
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
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ArticleCheck_Action();
		if (shopNum1_ArticleCheck_Action.UpdateAudit(this.CheckGuid.Value.ToString(), 1) > 0)
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
	protected void ButtonSearchDetails_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopArticle_Details.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ArticleCheck_Action();
		if (shopNum1_ArticleCheck_Action.UpdateAudit(this.CheckGuid.Value.ToString(), 2) > 0)
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
}
