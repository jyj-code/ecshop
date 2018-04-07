using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_AnnouncementCategory_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label Label1;
	protected TextBox TextBoxName;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelFatherID;
	protected DropDownList DropDownListFatherID;
	protected Label LabelKeywords;
	protected TextBox TextBoxKeywords;
	protected RegularExpressionValidator RegularExpressionValidatorTitle0;
	protected Label LabelDescription;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorTitle1;
	protected Label Label2;
	protected TextBox TextBoxOrderID;
	protected Label Label5;
	protected RegularExpressionValidator RegularExpressionValidatorOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected Label LabelIsShow;
	protected CheckBox CheckBoxIsShow;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected HiddenField hiddenFieldGuid;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"]);
		if (!this.Page.IsPostBack)
		{
			this.method_5();
			this.GetOrderID();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.GetEditInfo();
				this.DropDownListFatherID.Enabled = false;
			}
		}
	}
	protected void GetOrderID()
	{
		ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
		this.TextBoxOrderID.Text = Convert.ToString(1 + shopNum1_AnnouncementCategory_Action.GetMaxID());
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			ShopNum1_AnnouncementCategory shopNum1_AnnouncementCategory = new ShopNum1_AnnouncementCategory();
			shopNum1_AnnouncementCategory.Name = this.TextBoxName.Text.Trim();
			shopNum1_AnnouncementCategory.FatherID = Convert.ToInt32(this.DropDownListFatherID.SelectedValue);
			shopNum1_AnnouncementCategory.Keywords = this.TextBoxKeywords.Text.Trim();
			shopNum1_AnnouncementCategory.Description = this.TextBoxDescription.Text.Trim();
			shopNum1_AnnouncementCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_AnnouncementCategory.IsShow = 1;
			}
			else
			{
				shopNum1_AnnouncementCategory.IsShow = 0;
			}
			shopNum1_AnnouncementCategory.CreateUser = "admin";
			shopNum1_AnnouncementCategory.CreateTime = DateTime.Now;
			shopNum1_AnnouncementCategory.ModifyUser = "admin";
			shopNum1_AnnouncementCategory.ModifyTime = DateTime.Now;
			shopNum1_AnnouncementCategory.IsDeleted = 0;
			if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
			{
				shopNum1_AnnouncementCategory.CategoryLevel = 1;
			}
			else
			{
				string[] array = this.DropDownListFatherID.SelectedItem.Text.Split(new char[]
				{
					this.charSapce
				});
				if (array.Length > 0)
				{
					shopNum1_AnnouncementCategory.CategoryLevel = (array.Length + 1) / 2 + 1;
				}
				else
				{
					shopNum1_AnnouncementCategory.CategoryLevel = 2;
				}
			}
			ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
			int num = shopNum1_AnnouncementCategory_Action.Add(shopNum1_AnnouncementCategory);
			if (num > 0)
			{
				this.method_5();
				this.method_7();
			}
		}
		else if (this.ButtonConfirm.ToolTip == "Update")
		{
			ShopNum1_AnnouncementCategory shopNum1_AnnouncementCategory = new ShopNum1_AnnouncementCategory();
			shopNum1_AnnouncementCategory.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.Replace("'", ""));
			shopNum1_AnnouncementCategory.Name = this.TextBoxName.Text.Trim();
			shopNum1_AnnouncementCategory.FatherID = Convert.ToInt32(this.DropDownListFatherID.SelectedValue);
			shopNum1_AnnouncementCategory.Keywords = this.TextBoxKeywords.Text.Trim();
			shopNum1_AnnouncementCategory.Description = this.TextBoxDescription.Text.Trim();
			shopNum1_AnnouncementCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_AnnouncementCategory.IsShow = 1;
			}
			else
			{
				shopNum1_AnnouncementCategory.IsShow = 0;
			}
			shopNum1_AnnouncementCategory.ModifyUser = "admin";
			shopNum1_AnnouncementCategory.ModifyTime = DateTime.Now;
			shopNum1_AnnouncementCategory.IsDeleted = 0;
			if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
			{
				shopNum1_AnnouncementCategory.CategoryLevel = 1;
			}
			else
			{
				string[] array = this.DropDownListFatherID.SelectedItem.Text.Split(new char[]
				{
					this.charSapce
				});
				if (array.Length > 0)
				{
					shopNum1_AnnouncementCategory.CategoryLevel = (array.Length + 1) / 2 + 1;
				}
				else
				{
					shopNum1_AnnouncementCategory.CategoryLevel = 2;
				}
			}
			ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
			int num = shopNum1_AnnouncementCategory_Action.Update(shopNum1_AnnouncementCategory);
			if (num > 0)
			{
				base.Response.Redirect("AnnouncementCategory_List.aspx");
			}
		}
	}
	private void method_5()
	{
		this.DropDownListFatherID.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "顶级分类";
		listItem.Value = "0";
		this.DropDownListFatherID.Items.Add(listItem);
		ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
		DataView defaultView = shopNum1_AnnouncementCategory_Action.Search(0, 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
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
	private void method_7()
	{
		this.TextBoxName.Text = string.Empty;
		this.DropDownListFatherID.SelectedValue = "0";
		this.TextBoxKeywords.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.CheckBoxIsShow.Checked = true;
		this.GetOrderID();
	}
	protected void GetEditInfo()
	{
		ShopNum1_AnnouncementCategory_Action shopNum1_AnnouncementCategory_Action = (ShopNum1_AnnouncementCategory_Action)LogicFactory.CreateShopNum1_AnnouncementCategory_Action();
		DataTable editInfo = shopNum1_AnnouncementCategory_Action.GetEditInfo(this.hiddenFieldGuid.Value);
		this.TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
		this.DropDownListFatherID.SelectedValue = editInfo.Rows[0]["FatherID"].ToString();
		this.TextBoxKeywords.Text = editInfo.Rows[0]["Keywords"].ToString();
		this.TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
		this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		if (Convert.ToInt32(editInfo.Rows[0]["IsShow"].ToString()) == 1)
		{
			this.CheckBoxIsShow.Checked = true;
		}
		else
		{
			this.CheckBoxIsShow.Checked = false;
		}
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
		this.LabelPageTitle.Text = "编辑公告分类";
	}
}
