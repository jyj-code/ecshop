using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_MemberGroup_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label tab01;
	protected Label tab02;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label LabelDescription;
	protected TextBox TextBoxDescription;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorDescription;
	protected RegularExpressionValidator RegularExpressionValidatorName0;
	protected HtmlGenericControl content1;
	protected Admin_UserControl_MemberSelect MemberSelect1;
	protected HtmlGenericControl content2;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.GetEditInfo();
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
	protected void Add()
	{
		ShopNum1_MemberGroup shopNum1_MemberGroup = new ShopNum1_MemberGroup();
		shopNum1_MemberGroup.Guid = Guid.NewGuid();
		shopNum1_MemberGroup.Name = this.TextBoxName.Text.Trim();
		shopNum1_MemberGroup.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_MemberGroup.CreateUser = "admin";
		shopNum1_MemberGroup.CreateTime = DateTime.Now;
		shopNum1_MemberGroup.ModifyUser = "admin";
		shopNum1_MemberGroup.ModifyTime = DateTime.Now;
		shopNum1_MemberGroup.IsDeleted = 0;
		List<string> list = new List<string>();
		ListBox listBox = (ListBox)this.MemberSelect1.FindControl("ListBoxRightMember");
		foreach (ListItem listItem in listBox.Items)
		{
			string[] array = listItem.Text.Split(new char[]
			{
				'-'
			});
			list.Add(array[0]);
		}
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		int num = shopNum1_Member_Action.Add(shopNum1_MemberGroup, list);
		if (num > 0)
		{
			this.ClearControl();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataTable dataTable = shopNum1_Member_Action.SearchMemberGroup(this.hiddenFieldGuid.Value);
		this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
		this.TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
		DataTable dataTable2 = shopNum1_Member_Action.SearchMemberAssignGroup(this.hiddenFieldGuid.Value.Replace("'", ""));
		ListBox listBox = (ListBox)this.MemberSelect1.FindControl("ListBoxRightMember");
		for (int i = 0; i < dataTable2.Rows.Count; i++)
		{
			ListItem listItem = new ListItem();
			listItem.Text = dataTable2.Rows[i]["MemLoginID"].ToString() + "-" + dataTable2.Rows[i]["Name"].ToString();
			DataTable dataTable3 = shopNum1_Member_Action.SearchByMemLoginID(dataTable2.Rows[i]["MemLoginID"].ToString());
			listItem.Value = dataTable3.Rows[0]["Guid"].ToString();
			listBox.Items.Add(listItem);
		}
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
	}
	protected void Edit()
	{
		ShopNum1_MemberGroup shopNum1_MemberGroup = new ShopNum1_MemberGroup();
		shopNum1_MemberGroup.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
		shopNum1_MemberGroup.Name = this.TextBoxName.Text.Trim();
		shopNum1_MemberGroup.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_MemberGroup.ModifyUser = "admin";
		shopNum1_MemberGroup.ModifyTime = DateTime.Now;
		shopNum1_MemberGroup.IsDeleted = 0;
		List<string> list = new List<string>();
		ListBox listBox = (ListBox)this.MemberSelect1.FindControl("ListBoxRightMember");
		foreach (ListItem listItem in listBox.Items)
		{
			string[] array = listItem.Text.Split(new char[]
			{
				'-'
			});
			list.Add(array[0]);
		}
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		int num = shopNum1_Member_Action.UpdateMemberAssignGroup(shopNum1_MemberGroup, list);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
			base.Response.Redirect("MemberGroup_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ClearControl()
	{
		this.TextBoxDescription.Text = string.Empty;
		this.TextBoxName.Text = string.Empty;
	}
}
