using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
public class AgentAdmin_UserControl_MemberSelect : UserControl
{
	protected ScriptManager ScriptManager1;
	protected Label LabelSRelatedProductName;
	protected TextBox TextBoxSMemberID;
	protected Label LabelSRelatedProductCategoryID;
	protected TextBox TextBoxSMemberName;
	protected Label LabelSRelatedProductBrandGuid;
	protected DropDownList DropDownListSMemberRank;
	protected Button ButtonSearchRelatedProduct;
	protected Label LabelShowLeftRelatedProduct;
	protected Label LabelShowRightRelatedProduct;
	protected ListBox ListBoxLeftMember;
	protected Button ButtonAddAllMember;
	protected Button ButtonAddMember;
	protected Button ButtonDeleteMember;
	protected Button ButtonDeleteAllMember;
	protected ListBox ListBoxRightMember;
	protected UpdatePanel UpdatePanel1;
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
		if (!this.Page.IsPostBack)
		{
			this.BindMemberRank();
		}
	}
	protected void BindMemberRank()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListSMemberRank.Items.Add(listItem);
		ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
		DataView defaultView = shopNum1_MemberRank_Action.SearchGuidName(0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["Guid"].ToString().Trim();
			this.DropDownListSMemberRank.Items.Add(listItem2);
		}
	}
	protected void ButtonSearchRelatedProduct_Click(object sender, EventArgs e)
	{
		this.BindListBoxLeftMember();
	}
	private string method_0(object object_0)
	{
		string result;
		if (object_0 != null)
		{
			result = object_0.ToString();
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void BindListBoxLeftMember()
	{
		this.ListBoxLeftMember.Items.Clear();
		string memLoginID = this.TextBoxSMemberName.Text.Trim();
		string realName = this.TextBoxSMemberID.Text.Trim();
		string selectedValue = this.DropDownListSMemberRank.SelectedValue;
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataView defaultView = shopNum1_Member_Action.SearchMemberName(memLoginID, realName, selectedValue).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem = new ListItem();
			if (this.method_0(base.Request.QueryString["type"]) == "1")
			{
				listItem.Text = dataRow["MemLoginID"].ToString().Trim();
			}
			else
			{
				listItem.Text = dataRow["MemLoginID"].ToString().Trim();
			}
			listItem.Value = dataRow["Guid"].ToString().Trim();
			this.ListBoxLeftMember.Items.Add(listItem);
		}
	}
	private bool method_1(string string_0)
	{
		bool result = true;
		for (int i = 0; i < this.ListBoxRightMember.Items.Count; i++)
		{
			if (this.ListBoxRightMember.Items[i].Value == string_0.Trim())
			{
				result = false;
				return result;
			}
		}
		return result;
	}
	protected void ButtonAddAllMember_Click(object sender, EventArgs e)
	{
		foreach (ListItem listItem in this.ListBoxLeftMember.Items)
		{
			if (this.method_1(listItem.Value))
			{
				this.ListBoxRightMember.Items.Add(listItem);
			}
		}
	}
	protected void ButtonAddMember_Click(object sender, EventArgs e)
	{
		foreach (ListItem listItem in this.ListBoxLeftMember.Items)
		{
			if (listItem.Selected && this.method_1(listItem.Value))
			{
				this.ListBoxRightMember.Items.Add(listItem);
			}
		}
	}
	protected void ButtonDeleteMember_Click(object sender, EventArgs e)
	{
		int count = this.ListBoxRightMember.Items.Count;
		if (count != -1)
		{
			for (int i = this.ListBoxRightMember.Items.Count - 1; i >= 0; i--)
			{
				if (this.ListBoxRightMember.Items[i].Selected)
				{
					this.ListBoxRightMember.Items.Remove(this.ListBoxRightMember.Items[i]);
				}
			}
		}
	}
	protected void ButtonDeleteAllMember_Click(object sender, EventArgs e)
	{
		int count = this.ListBoxRightMember.Items.Count;
		if (count != -1)
		{
			for (int i = this.ListBoxRightMember.Items.Count - 1; i >= 0; i--)
			{
				this.ListBoxRightMember.Items.Remove(this.ListBoxRightMember.Items[i]);
			}
		}
	}
}
