using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopType_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Localize Localize1;
	protected TextBox TextBoxName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Localize LocalizeFatherCateGory;
	protected DropDownList DropDownListFatherCateGory;
	protected CompareValidator CompareFatherCateGory;
	protected Localize Localize4;
	protected TextBox TextBoxOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected Localize Localize5;
	protected CheckBox CheckBoxIsShow;
	protected Localize Localize2;
	protected TextBox TextBoxKeywords;
	protected RegularExpressionValidator RegularExpressionValidatorKeywords;
	protected Localize Localize3;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected Button ButtonConfirm;
	protected MessageShow MessageShow;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!base.IsPostBack)
		{
			this.method_5();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.ButtonConfirm.Text = "更新";
				this.ButtonConfirm.ToolTip = "Update";
				this.DropDownListFatherCateGory.Enabled = false;
				this.method_8();
			}
			else
			{
				this.TextBoxOrderID.Text = Convert.ToString(this.method_7() + 1);
			}
		}
	}
	private void method_5()
	{
		this.DropDownListFatherCateGory.Items.Clear();
		ListItem listItem = new ListItem();
		listItem.Text = "顶级分类";
		listItem.Value = "0";
		this.DropDownListFatherCateGory.Items.Add(listItem);
		ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
		DataTable dataTable = shopNum1_ShopCategory_Action.SearchShopCategory(0, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString();
			listItem2.Value = dataRow["ID"].ToString();
			this.DropDownListFatherCateGory.Items.Add(listItem2);
			this.method_6(Convert.ToInt32(dataRow["ID"].ToString()));
		}
	}
	private void method_6(int int_0)
	{
		ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
		DataTable dataTable = shopNum1_ShopCategory_Action.SearchShopCategory(int_0, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			string str = string.Empty;
			for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
			{
				str += this.strSapce;
			}
			ListItem listItem = new ListItem();
			listItem.Text = str + dataRow["Name"].ToString();
			listItem.Value = dataRow["ID"].ToString();
			this.DropDownListFatherCateGory.Items.Add(listItem);
			this.method_6(Convert.ToInt32(dataRow["ID"].ToString()));
		}
	}
	private int method_7()
	{
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ShopCategory");
	}
	private void method_8()
	{
		if (base.Request.QueryString["op"].ToString() == "edit")
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable shopCategoryByID = shopNum1_ShopCategory_Action.GetShopCategoryByID(this.hiddenFieldGuid.Value.ToString());
			this.TextBoxName.Text = shopCategoryByID.Rows[0]["Name"].ToString();
			this.TextBoxKeywords.Text = shopCategoryByID.Rows[0]["Keywords"].ToString();
			this.TextBoxDescription.Text = shopCategoryByID.Rows[0]["Description"].ToString();
			this.TextBoxOrderID.Text = shopCategoryByID.Rows[0]["OrderID"].ToString();
			this.DropDownListFatherCateGory.Text = shopCategoryByID.Rows[0]["FatherID"].ToString();
			if (shopCategoryByID.Rows[0]["IsShow"].ToString() == "1")
			{
				this.CheckBoxIsShow.Checked = true;
			}
			else
			{
				this.CheckBoxIsShow.Checked = false;
			}
		}
		else
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable shopCategoryByID = shopNum1_ShopCategory_Action.GetShopCategoryByID(this.hiddenFieldGuid.Value.ToString());
			this.DropDownListFatherCateGory.Text = base.Request.QueryString["guid"].ToString();
			this.TextBoxOrderID.Text = shopCategoryByID.Rows[0]["OrderID"].ToString();
			this.ButtonConfirm.Text = "添加";
			this.ButtonConfirm.ToolTip = "Submit";
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Update")
		{
			this.method_11();
		}
		else if (this.ButtonConfirm.ToolTip == "Submit")
		{
			this.method_9();
		}
		this.method_5();
	}
	private void method_9()
	{
		ShopNum1_ShopCategory shopNum1_ShopCategory = new ShopNum1_ShopCategory();
		shopNum1_ShopCategory.Name = this.TextBoxName.Text.Trim();
		shopNum1_ShopCategory.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_ShopCategory.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_ShopCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_ShopCategory.IsShow = 1;
		}
		else
		{
			shopNum1_ShopCategory.IsShow = 0;
		}
		if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
		{
			shopNum1_ShopCategory.CategoryLevel = 1;
		}
		else
		{
			string[] array = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[]
			{
				this.charSapce
			});
			if (array.Length > 0)
			{
				shopNum1_ShopCategory.CategoryLevel = (array.Length + 1) / 2 + 1;
				if (shopNum1_ShopCategory.CategoryLevel >= 4)
				{
					MessageBox.Show("店铺分类为三级分类!");
					return;
				}
			}
			else
			{
				shopNum1_ShopCategory.CategoryLevel = 2;
			}
		}
		shopNum1_ShopCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
		shopNum1_ShopCategory.Family = string.Empty;
		shopNum1_ShopCategory.CreateUser = "admin";
		shopNum1_ShopCategory.CreateTime = DateTime.Now;
		shopNum1_ShopCategory.ModifyUser = "admin";
		shopNum1_ShopCategory.ModifyTime = DateTime.Now;
		shopNum1_ShopCategory.IsDeleted = "0";
		if (!Common.ReturnExist("name", "shopNum1_ShopCategory", " and name='" + shopNum1_ShopCategory.Name + "'"))
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
			if (shopNum1_ShopCategory_Action.Add(shopNum1_ShopCategory) > 0)
			{
				this.method_10();
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
		else
		{
			this.MessageShow.ShowMessage("添加失败，分类已经存在！");
			this.MessageShow.Visible = true;
		}
	}
	private void method_10()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxKeywords.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.TextBoxOrderID.Text = (int.Parse(this.TextBoxOrderID.Text) + 1).ToString();
		this.CheckBoxIsShow.Checked = true;
	}
	private void method_11()
	{
		ShopNum1_ShopCategory shopNum1_ShopCategory = new ShopNum1_ShopCategory();
		shopNum1_ShopCategory.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
		shopNum1_ShopCategory.Name = this.TextBoxName.Text.Trim();
		shopNum1_ShopCategory.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_ShopCategory.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_ShopCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_ShopCategory.IsShow = 1;
		}
		else
		{
			shopNum1_ShopCategory.IsShow = 0;
		}
		if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
		{
			shopNum1_ShopCategory.CategoryLevel = 1;
		}
		else
		{
			string[] array = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[]
			{
				this.charSapce
			});
			if (array.Length > 0)
			{
				shopNum1_ShopCategory.CategoryLevel = (array.Length + 1) / 2 + 1;
				if (shopNum1_ShopCategory.CategoryLevel >= 4)
				{
					MessageBox.Show("店铺分类为三级分类!");
					return;
				}
			}
			else
			{
				shopNum1_ShopCategory.CategoryLevel = 2;
			}
		}
		shopNum1_ShopCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
		shopNum1_ShopCategory.Family = string.Empty;
		shopNum1_ShopCategory.CreateUser = "";
		shopNum1_ShopCategory.CreateTime = DateTime.Now;
		shopNum1_ShopCategory.ModifyUser = "";
		shopNum1_ShopCategory.ModifyTime = DateTime.Now;
		shopNum1_ShopCategory.IsDeleted = "0";
		ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
		int num = shopNum1_ShopCategory_Action.Update(this.hiddenFieldGuid.Value.ToString(), shopNum1_ShopCategory);
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonReset_Click(object sender, EventArgs e)
	{
		this.method_10();
	}
}
