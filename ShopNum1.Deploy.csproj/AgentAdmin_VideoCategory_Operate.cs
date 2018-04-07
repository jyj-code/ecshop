using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_VideoCategory_Operate : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Label LabelFatherID;
	protected DropDownList DropDownListFatherID;
	protected Label LabelKeywords;
	protected TextBox TextBoxKeywords;
	protected RegularExpressionValidator RegularExpressionValidatorKeywords;
	protected Label LabelDescription;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected Label LabelBackgroundImage;
	protected TextBox TextBoxBackgroundImage;
	protected HtmlImage ImageBackgroundImage;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorOrderID;
	protected Label LabelIsShow;
	protected CheckBox CheckBoxIsShow;
	protected Button ButtonConfirm;
	protected HtmlInputReset inputReset;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField hiddenGuid;
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
		this.hiddenGuid.Value = ((base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"]);
		if (!this.Page.IsPostBack)
		{
			this.method_5();
			this.GetOrderID();
			if (this.hiddenGuid.Value != "0")
			{
				this.method_7();
			}
		}
	}
	protected void GetOrderID()
	{
		ShopNum1_Common_Action arg_0A_0 = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
		string columnName = "OrderID";
		string tableName = "ShopNum1_VideoCategory";
		this.TextBoxOrderID.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
			ShopNum1_VideoCategory shopNum1_VideoCategory = new ShopNum1_VideoCategory();
			shopNum1_VideoCategory.Name = this.TextBoxName.Text.Trim();
			shopNum1_VideoCategory.FatherID = new int?(Convert.ToInt32(this.DropDownListFatherID.SelectedValue));
			shopNum1_VideoCategory.Keywords = this.TextBoxKeywords.Text.Trim();
			shopNum1_VideoCategory.Description = this.TextBoxDescription.Text.Trim();
			shopNum1_VideoCategory.OrderID = new int?(Convert.ToInt32(this.TextBoxOrderID.Text.Trim()));
			shopNum1_VideoCategory.BackgroundImage = this.TextBoxBackgroundImage.Text.Trim();
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_VideoCategory.IsShow = new int?(1);
			}
			else
			{
				shopNum1_VideoCategory.IsShow = new int?(0);
			}
			shopNum1_VideoCategory.CreateUser = base.ShopNum1LoginID;
			shopNum1_VideoCategory.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_VideoCategory.ModifyUser = base.ShopNum1LoginID;
			shopNum1_VideoCategory.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_VideoCategory.IsDeleted = new int?(0);
			shopNum1_VideoCategory.ID = shopNum1_VideoCategory_Action.GetMaxID();
			if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
			{
				shopNum1_VideoCategory.CategoryLevel = new int?(1);
			}
			else
			{
				string[] array = this.DropDownListFatherID.SelectedItem.Text.Split(new char[]
				{
					this.charSapce
				});
				if (array.Length > 0)
				{
					shopNum1_VideoCategory.CategoryLevel = new int?((array.Length + 1) / 2 + 1);
				}
				else
				{
					shopNum1_VideoCategory.CategoryLevel = new int?(2);
				}
			}
			int num = shopNum1_VideoCategory_Action.Add(shopNum1_VideoCategory);
			if (num > 0)
			{
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
				this.method_5();
				this.method_8();
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
		else if (this.ButtonConfirm.ToolTip == "Update")
		{
			if (this.hiddenGuid.Value.ToString() == this.DropDownListFatherID.SelectedValue)
			{
				this.MessageShow.ShowMessage("EditError");
				this.MessageShow.Visible = true;
			}
			else
			{
				ShopNum1_VideoCategory shopNum1_VideoCategory = new ShopNum1_VideoCategory();
				shopNum1_VideoCategory.ID = Convert.ToInt32(this.hiddenGuid.Value.ToString());
				shopNum1_VideoCategory.Name = this.TextBoxName.Text.Trim();
				shopNum1_VideoCategory.FatherID = new int?(Convert.ToInt32(this.DropDownListFatherID.SelectedValue));
				shopNum1_VideoCategory.Keywords = this.TextBoxKeywords.Text.Trim();
				shopNum1_VideoCategory.Description = this.TextBoxDescription.Text.Trim();
				shopNum1_VideoCategory.OrderID = new int?(Convert.ToInt32(this.TextBoxOrderID.Text.Trim()));
				shopNum1_VideoCategory.BackgroundImage = this.TextBoxBackgroundImage.Text.Trim();
				if (this.CheckBoxIsShow.Checked)
				{
					shopNum1_VideoCategory.IsShow = new int?(1);
				}
				else
				{
					shopNum1_VideoCategory.IsShow = new int?(0);
				}
				shopNum1_VideoCategory.ModifyUser = base.ShopNum1LoginID;
				shopNum1_VideoCategory.ModifyTime = new DateTime?(DateTime.Now);
				shopNum1_VideoCategory.IsDeleted = new int?(0);
				if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
				{
					shopNum1_VideoCategory.CategoryLevel = new int?(1);
				}
				else
				{
					string[] array = this.DropDownListFatherID.SelectedItem.Text.Split(new char[]
					{
						this.charSapce
					});
					if (array.Length > 0)
					{
						shopNum1_VideoCategory.CategoryLevel = new int?((array.Length + 1) / 2 + 1);
					}
					else
					{
						shopNum1_VideoCategory.CategoryLevel = new int?(2);
					}
				}
				ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
				int num = shopNum1_VideoCategory_Action.Update(shopNum1_VideoCategory);
				if (num > 0)
				{
					base.Response.Redirect("VideoCategory_List.aspx");
				}
				else
				{
					this.MessageShow.ShowMessage("EditNo");
					this.MessageShow.Visible = true;
				}
			}
		}
	}
	private void method_5()
	{
		this.DropDownListFatherID.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = LocalizationUtil.GetCommonMessage("OneCategory");
		listItem.Value = "0";
		this.DropDownListFatherID.Items.Add(listItem);
		ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
		DataView defaultView = shopNum1_VideoCategory_Action.Search(0, 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListFatherID.Items.Add(listItem2);
			DataTable dataTable = shopNum1_VideoCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	private void method_6(DataTable dt)
	{
		ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
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
			DataTable dataTable = shopNum1_VideoCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.method_6(dataTable);
			}
		}
	}
	private void method_7()
	{
		ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = new ShopNum1_VideoCategory_Action();
		DataTable dataTable = shopNum1_VideoCategory_Action.SearchInfoByID(this.hiddenGuid.Value.ToString());
		this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
		this.DropDownListFatherID.SelectedValue = dataTable.Rows[0]["FatherID"].ToString();
		this.TextBoxKeywords.Text = dataTable.Rows[0]["Keywords"].ToString();
		this.TextBoxDescription.Text = dataTable.Rows[0]["Description"].ToString();
		this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
		this.TextBoxBackgroundImage.Text = dataTable.Rows[0]["BackgroundImage"].ToString();
		if (dataTable.Rows[0]["BackgroundImage"].ToString() != string.Empty)
		{
			this.ImageBackgroundImage.Src = dataTable.Rows[0]["BackgroundImage"].ToString();
		}
		else
		{
			this.ImageBackgroundImage.Src = "~/Images/noImage.gif";
		}
		if (dataTable.Rows[0]["IsShow"].ToString() == "0")
		{
			this.CheckBoxIsShow.Checked = false;
		}
		else
		{
			this.CheckBoxIsShow.Checked = true;
		}
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
		this.LabelPageTitle.Text = "编辑视频分类";
	}
	private void method_8()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxOrderID.Text = string.Empty;
		this.DropDownListFatherID.SelectedValue = "0";
		this.TextBoxKeywords.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.TextBoxBackgroundImage.Text = string.Empty;
		this.CheckBoxIsShow.Checked = true;
		this.GetOrderID();
	}
}
