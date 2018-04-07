using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Video_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected Localize LocalizeTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategoryID;
	protected Localize LocalizePublisher;
	protected System.Web.UI.WebControls.TextBox TextBoxPublisher;
	protected Localize LocalizeIsRecommend;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsRecommend;
	protected System.Web.UI.WebControls.TextBox TextBoxStartTime;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected ToolkitScriptManager ToolkitScriptManager2;
	protected CalendarExtender CalendarExtender3;
	protected System.Web.UI.WebControls.TextBox TextBoxEndTime;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected CompareValidator CompareTextBoxEndTime;
	protected CalendarExtender CalendarExtender4;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonSearchComment;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HtmlForm form1;
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
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
			this.BindCategory();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("Video_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
		int num = shopNum1_Video_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			this.method_5();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonSearchComment_Click(object sender, EventArgs e)
	{
		this.Page.RegisterStartupScript("", "<script> window.open('" + GetPageName.RetUrl("VideoDetail", this.CheckGuid.Value.Replace("'", "")) + "')</script>");
	}
	protected void BindCategory()
	{
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("All");
		listItem.Value = "-1";
		this.DropDownListCategoryID.Items.Add(listItem);
		ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
		DataView defaultView = shopNum1_VideoCategory_Action.Search(0, 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListCategoryID.Items.Add(listItem2);
			DataTable dataTable = shopNum1_VideoCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.AddSubCategory(dataTable);
			}
		}
	}
	protected void AddSubCategory(DataTable dataTable)
	{
		ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
		foreach (DataRow dataRow in dataTable.Rows)
		{
			ListItem listItem = new ListItem();
			string text = string.Empty;
			for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
			{
				text += this.strSapce;
			}
			text += dataRow["Name"].ToString().Trim();
			listItem.Text = text;
			listItem.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListCategoryID.Items.Add(listItem);
			DataTable dataTable2 = shopNum1_VideoCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubCategory(dataTable2);
			}
		}
	}
	public string GetUrl(object strguid)
	{
		return GetPageName.RetUrl("VideoDetail", strguid);
	}
}
