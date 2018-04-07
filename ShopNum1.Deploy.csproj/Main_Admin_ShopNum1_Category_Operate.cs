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
public class Main_Admin_ShopNum1_Category_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize Localize1;
	protected TextBox TextBoxName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Localize LocalizeFatherCateGory;
	protected DropDownList DropDownListFatherCateGory;
	protected CompareValidator CompareFatherCateGory;
	protected Localize Localize2;
	protected TextBox TextBoxKeywords;
	protected RegularExpressionValidator RegularExpressionValidatorKeywords;
	protected Localize Localize4;
	protected TextBox TextBoxOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected Localize Localize5;
	protected CheckBox CheckBoxIsShow;
	protected Localize Localize3;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
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
				this.LabelTitle.Text = "编辑分类信息分类";
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
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
		DataTable dataTable = shopNum1_ProductCategory_Action.SearchtProductCategory(0, 0);
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
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
		DataTable dataTable = shopNum1_ProductCategory_Action.SearchtProductCategory(int_0, 0);
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
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Category");
	}
	private void method_8()
	{
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
		DataTable productCategoryByID = shopNum1_ProductCategory_Action.GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
		this.TextBoxName.Text = productCategoryByID.Rows[0]["Name"].ToString();
		this.TextBoxKeywords.Text = productCategoryByID.Rows[0]["Keywords"].ToString();
		this.TextBoxDescription.Text = productCategoryByID.Rows[0]["Description"].ToString();
		this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
		this.DropDownListFatherCateGory.Text = productCategoryByID.Rows[0]["FatherID"].ToString();
		this.DropDownListFatherCateGory.Enabled = false;
		if (productCategoryByID.Rows[0]["IsShow"].ToString() == "1")
		{
			this.CheckBoxIsShow.Checked = true;
		}
		else
		{
			this.CheckBoxIsShow.Checked = false;
		}
		this.ButtonConfirm.Text = "更新";
		this.ButtonConfirm.ToolTip = "Update";
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
			this.method_5();
		}
	}
	private void method_9()
	{
		ShopNum1_ProductCategory shopNum1_ProductCategory = new ShopNum1_ProductCategory();
		shopNum1_ProductCategory.Name = this.TextBoxName.Text.Trim();
		shopNum1_ProductCategory.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_ProductCategory.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_ProductCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_ProductCategory.IsShow = 1;
		}
		else
		{
			shopNum1_ProductCategory.IsShow = 0;
		}
		if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
		{
			shopNum1_ProductCategory.CategoryLevel = 1;
		}
		else
		{
			string[] array = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[]
			{
				this.charSapce
			});
			if (array.Length > 0)
			{
				shopNum1_ProductCategory.CategoryLevel = (array.Length + 1) / 2 + 1;
				if (shopNum1_ProductCategory.CategoryLevel >= 4)
				{
					MessageBox.Show("分类为三级分类!");
					return;
				}
			}
			else
			{
				shopNum1_ProductCategory.CategoryLevel = 2;
			}
		}
		shopNum1_ProductCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
		shopNum1_ProductCategory.CreateUser = "admin";
		shopNum1_ProductCategory.CreateTime = DateTime.Now;
		shopNum1_ProductCategory.ModifyUser = "admin";
		shopNum1_ProductCategory.ModifyTime = DateTime.Now;
		shopNum1_ProductCategory.IsDeleted = 0;
		if (!Common.ReturnExist("name", "shopNum1_Category", " and name='" + shopNum1_ProductCategory.Name + "'"))
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
			if (shopNum1_ProductCategory_Action.Add(shopNum1_ProductCategory) > 0)
			{
				ShopNum1_CategoryChecked_Action.CategoryTable = null;
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
		this.TextBoxOrderID.Text = (this.method_7() + 1).ToString();
		this.CheckBoxIsShow.Checked = true;
	}
	private void method_11()
	{
		ShopNum1_Category shopNum1_Category = new ShopNum1_Category();
		shopNum1_Category.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
		shopNum1_Category.Name = this.TextBoxName.Text.Trim();
		shopNum1_Category.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_Category.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		shopNum1_Category.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_Category.ModifyUser = "admin";
		shopNum1_Category.ModifyTime = DateTime.Now;
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_Category.IsShow = 1;
		}
		else
		{
			shopNum1_Category.IsShow = 0;
		}
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		int num = shopNum1_ProductCategory_Action.UpdateCatrgoryInfoCategory(shopNum1_Category);
		if (num > 0)
		{
			ShopNum1_CategoryChecked_Action.CategoryTable = null;
			base.Response.Redirect("ShopNum1_Category_List.aspx");
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
