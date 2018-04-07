using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Message_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label tab01;
	protected Label tab02;
	protected Label LabelTitle;
	protected TextBox TextBoxTitle;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTitle;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelContent;
	protected TextBox TextBoxContent;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorContent;
	protected HtmlGenericControl content1;
	protected Admin_UserControl_MemberSelect MemberSelect2;
	protected HtmlGenericControl content2;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
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
		if (this.Page.IsPostBack)
		{
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_MessageInfo shopNum1_MessageInfo = new ShopNum1_MessageInfo();
		shopNum1_MessageInfo.Guid = Guid.NewGuid();
		shopNum1_MessageInfo.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_MessageInfo.Type = "1";
		shopNum1_MessageInfo.Content = this.TextBoxContent.Text.Trim();
		shopNum1_MessageInfo.MemLoginID = "";
		shopNum1_MessageInfo.MemLoginID = base.ShopNum1LoginID;
		shopNum1_MessageInfo.SendTime = DateTime.Now;
		shopNum1_MessageInfo.IsDeleted = 0;
		List<string> list = new List<string>();
		ListBox listBox = (ListBox)this.MemberSelect2.FindControl("ListBoxRightMember");
		foreach (ListItem listItem in listBox.Items)
		{
			try
			{
				list.Add(listItem.Text.Split(new char[]
				{
					'-'
				})[0]);
			}
			catch
			{
				list.Add(listItem.Text);
			}
		}
		ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
		int num = shopNum1_MessageInfo_Action.Add(shopNum1_MessageInfo, list);
		if (num > 0)
		{
			this.ClearControl();
			this.MessageShow.ShowMessage("OperateYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ClearControl()
	{
		this.TextBoxContent.Text = string.Empty;
		this.TextBoxTitle.Text = string.Empty;
		ListBox listBox = (ListBox)this.MemberSelect2.FindControl("ListBoxRightMember");
		listBox.Items.Clear();
		ListBox listBox2 = (ListBox)this.MemberSelect2.FindControl("ListBoxLeftMember");
		listBox2.Items.Clear();
		DropDownList dropDownList = (DropDownList)this.MemberSelect2.FindControl("DropDownListSMemberRank");
		dropDownList.SelectedValue = "-1";
	}
}
