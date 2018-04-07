using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
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
public class Admin_Announcement_List : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateUser;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory;
	protected System.Web.UI.WebControls.TextBox TextBoxStartTime;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndTime;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
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
		if (!this.Page.IsPostBack)
		{
			this.method_5();
			this.BindGrid();
		}
	}
	public string GetCategryName(string strCode)
	{
		return Common.GetNameById("name", "ShopNum1_AnnouncementCategory", " and id='" + strCode + "'");
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	private void method_5()
	{
		this.DropDownListCategory.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListCategory.Items.Add(listItem);
		ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
		DataView defaultView = shopNum1_AnnouncementCategory_Action.Search(0, 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListCategory.Items.Add(listItem2);
			DataTable dataTable = shopNum1_AnnouncementCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	private void method_6(DataTable dt)
	{
		ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
		foreach (DataRow dataRow in dt.Rows)
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
			this.DropDownListCategory.Items.Add(listItem);
			DataTable dataTable = shopNum1_AnnouncementCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("Announcement_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Announcement_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)LogicFactory.CreateShopNum1_Announcement_Action();
		int num = shopNum1_Announcement_Action.Delete(this.CheckGuid.Value.ToString());
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
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)LogicFactory.CreateShopNum1_Announcement_Action();
		int num = shopNum1_Announcement_Action.Delete("'" + commandArgument + "'");
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
