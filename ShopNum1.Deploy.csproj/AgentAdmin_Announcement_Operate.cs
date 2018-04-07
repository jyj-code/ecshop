using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Announcement_Operate : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Label LabelTitle;
	protected TextBox TextBoxTitle;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTitle;
	protected RegularExpressionValidator RegularExpressionValidatorT;
	protected Label Label4;
	protected DropDownList DropDownListFatherID;
	protected Label Label5;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected Label LabelRemark;
	protected TextBox FCKeditorReMark;
	protected Label LabelKeywords;
	protected TextBox TextBoxKeywords;
	protected Label LabelCreateTime;
	protected TextBox TextBoxCreateTime;
	protected RegularExpressionValidator RegularExpressionValidatorEndDate;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorCreateTime;
	protected CalendarExtender CalendarExtender2;
	protected Label Labeldescription;
	protected TextBox TextBoxdescription;
	protected Button BottonConfirm;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
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
		if (!this.Page.IsPostBack)
		{
			this.ClearControl();
			this.method_5();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "编辑公告";
				this.GetEditInfo();
			}
		}
	}
	private void method_5()
	{
		this.DropDownListFatherID.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "-请选择-";
		listItem.Value = "0";
		this.DropDownListFatherID.Items.Add(listItem);
		ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
		DataView defaultView = shopNum1_AnnouncementCategory_Action.Search(0, 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			if (dataRow["Name"].ToString() != "会员公告")
			{
				listItem2.Text = dataRow["Name"].ToString().Trim();
				listItem2.Value = dataRow["ID"].ToString().Trim();
				this.DropDownListFatherID.Items.Add(listItem2);
				DataTable dataTable = shopNum1_AnnouncementCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
				if (dataTable.Rows.Count > 0)
				{
					this.method_6(dataTable);
				}
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
			this.DropDownListFatherID.Items.Add(listItem);
			DataTable dataTable = shopNum1_AnnouncementCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.BottonConfirm.ToolTip == "Update")
		{
			this.Edit();
		}
		else if (this.BottonConfirm.ToolTip == "Submit")
		{
			this.Add();
		}
	}
	protected void Add()
	{
		ShopNum1_Announcement shopNum1_Announcement = new ShopNum1_Announcement();
		shopNum1_Announcement.Guid = Guid.NewGuid();
		shopNum1_Announcement.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_Announcement.Remark = base.Server.HtmlEncode(this.FCKeditorReMark.Text.Replace("'", "''"));
		shopNum1_Announcement.CreateTime = Convert.ToDateTime(this.TextBoxCreateTime.Text.Trim());
		shopNum1_Announcement.CreateUser = base.ShopNum1LoginID;
		shopNum1_Announcement.AnnouncementCategoryID = int.Parse(this.DropDownListFatherID.SelectedValue);
		shopNum1_Announcement.ModifyUser = base.ShopNum1LoginID;
		shopNum1_Announcement.ModifyTime = DateTime.Now;
		shopNum1_Announcement.IsDeleted = 0;
		shopNum1_Announcement.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_Announcement.Description = this.TextBoxdescription.Text.Trim();
		shopNum1_Announcement.SubstationID = base.SubstationID;
		ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)LogicFactory.CreateShopNum1_Announcement_Action();
		int num = shopNum1_Announcement_Action.Add(shopNum1_Announcement);
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
	protected void Edit()
	{
		ShopNum1_Announcement shopNum1_Announcement = new ShopNum1_Announcement();
		shopNum1_Announcement.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_Announcement.Remark = base.Server.HtmlEncode(this.FCKeditorReMark.Text.Replace("'", "''"));
		shopNum1_Announcement.CreateTime = Convert.ToDateTime(this.TextBoxCreateTime.Text.Trim());
		shopNum1_Announcement.ModifyUser = base.ShopNum1LoginID;
		shopNum1_Announcement.ModifyTime = DateTime.Now;
		shopNum1_Announcement.IsDeleted = 0;
		shopNum1_Announcement.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_Announcement.Description = this.TextBoxdescription.Text.Trim();
		shopNum1_Announcement.AnnouncementCategoryID = int.Parse(this.DropDownListFatherID.SelectedValue);
		ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)LogicFactory.CreateShopNum1_Announcement_Action();
		int num = shopNum1_Announcement_Action.Update(this.hiddenFieldGuid.Value, shopNum1_Announcement);
		if (num > 0)
		{
			base.Response.Redirect("Announcement_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)LogicFactory.CreateShopNum1_Announcement_Action();
		DataTable editInfo = shopNum1_Announcement_Action.GetEditInfo(this.hiddenFieldGuid.Value, 0);
		this.TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
		this.FCKeditorReMark.Text = base.Server.HtmlDecode(editInfo.Rows[0]["Remark"].ToString());
		this.TextBoxCreateTime.Text = editInfo.Rows[0]["CreateTime"].ToString();
		this.DropDownListFatherID.SelectedValue = editInfo.Rows[0]["AnnouncementCategoryID"].ToString();
		this.TextBoxKeywords.Text = editInfo.Rows[0]["Keywords"].ToString();
		this.TextBoxdescription.Text = editInfo.Rows[0]["Description"].ToString();
		this.BottonConfirm.Text = "更新";
		this.BottonConfirm.ToolTip = "Update";
	}
	protected void ClearControl()
	{
		this.TextBoxTitle.Text = string.Empty;
		this.FCKeditorReMark.Text = string.Empty;
		this.TextBoxCreateTime.Text = DateTime.Now.ToString();
	}
}
