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
public class AgentAdmin_ScoreProductCategory_Operate : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	private IShopNum1_SpecificationProudctCategory_Action ishopNum1_SpecificationProudctCategory_Action_0 = LogicFactory.CreateShopNum1_SpecificationProudctCategory_Action();
	protected char charSapce = '\u3000';
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
	protected Localize Localize7;
	protected Label LabelSalePro;
	protected HtmlTableRow trSale;
	protected Button ButtonConfirm;
	protected HtmlInputButton openSalePro;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldSpecification;
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
		if (!base.IsPostBack)
		{
			this.method_5();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelTitle.Text = "编辑积分商品分类";
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
		ListItem listItem = new ListItem();
		listItem.Text = "顶级分类";
		listItem.Value = "0";
		this.DropDownListFatherCateGory.Items.Add(listItem);
		ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
		DataTable dataTable = shopNum1_ScoreProductCategory_Action.SearchtProductCategory(0, 0);
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
		ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
		DataTable dataTable = shopNum1_ScoreProductCategory_Action.SearchtProductCategory(int_0, 0);
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
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ScoreProductCategory");
	}
	private void method_8()
	{
		ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
		DataTable productCategoryByID = shopNum1_ScoreProductCategory_Action.GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
		this.TextBoxName.Text = productCategoryByID.Rows[0]["Name"].ToString();
		this.TextBoxKeywords.Text = productCategoryByID.Rows[0]["Keywords"].ToString();
		this.TextBoxDescription.Text = productCategoryByID.Rows[0]["Description"].ToString();
		this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
		this.DropDownListFatherCateGory.Text = productCategoryByID.Rows[0]["FatherID"].ToString();
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
		}
	}
	private void method_9()
	{
		ShopNum1_ScoreProductCategory shopNum1_ScoreProductCategory = new ShopNum1_ScoreProductCategory();
		shopNum1_ScoreProductCategory.Name = this.TextBoxName.Text.Trim();
		shopNum1_ScoreProductCategory.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_ScoreProductCategory.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_ScoreProductCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_ScoreProductCategory.IsShow = 1;
		}
		else
		{
			shopNum1_ScoreProductCategory.IsShow = 0;
		}
		if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
		{
			shopNum1_ScoreProductCategory.CategoryLevel = new int?(1);
		}
		else
		{
			string[] array = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[]
			{
				this.charSapce
			});
			if (array.Length > 0)
			{
				shopNum1_ScoreProductCategory.CategoryLevel = new int?((array.Length + 1) / 2 + 1);
				if (shopNum1_ScoreProductCategory.CategoryLevel >= 4)
				{
					MessageBox.Show("商品分类为三级分类!");
					return;
				}
			}
			else
			{
				shopNum1_ScoreProductCategory.CategoryLevel = new int?(2);
			}
		}
		shopNum1_ScoreProductCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
		shopNum1_ScoreProductCategory.Family = string.Empty;
		shopNum1_ScoreProductCategory.CreateUser = "admin";
		shopNum1_ScoreProductCategory.CreateTime = DateTime.Now;
		shopNum1_ScoreProductCategory.ModifyUser = "admin";
		shopNum1_ScoreProductCategory.ModifyTime = DateTime.Now;
		shopNum1_ScoreProductCategory.IsDeleted = 0;
		ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
		if (shopNum1_ScoreProductCategory_Action.Add(shopNum1_ScoreProductCategory) > 0)
		{
			if (this.hiddenFieldSpecification.Value != "-1")
			{
				this.ishopNum1_SpecificationProudctCategory_Action_0.InsertMuch(this.hiddenFieldGuid.Value, "", this.hiddenFieldSpecification.Value);
			}
			this.method_10();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
			this.Page.Response.Redirect("ShopNum1_ScoreProductCategory_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
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
		ShopNum1_ScoreProductCategory shopNum1_ScoreProductCategory = new ShopNum1_ScoreProductCategory();
		shopNum1_ScoreProductCategory.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
		shopNum1_ScoreProductCategory.Name = this.TextBoxName.Text.Trim();
		shopNum1_ScoreProductCategory.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_ScoreProductCategory.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_ScoreProductCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		if (this.CheckBoxIsShow.Checked)
		{
			shopNum1_ScoreProductCategory.IsShow = 1;
		}
		else
		{
			shopNum1_ScoreProductCategory.IsShow = 0;
		}
		if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
		{
			shopNum1_ScoreProductCategory.CategoryLevel = new int?(1);
		}
		else
		{
			string[] array = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[]
			{
				this.charSapce
			});
			if (array.Length > 0)
			{
				shopNum1_ScoreProductCategory.CategoryLevel = new int?((array.Length + 1) / 2 + 1);
				if (shopNum1_ScoreProductCategory.CategoryLevel >= 4)
				{
					MessageBox.Show("商品分类为三级分类!");
					return;
				}
			}
			else
			{
				shopNum1_ScoreProductCategory.CategoryLevel = new int?(2);
			}
		}
		shopNum1_ScoreProductCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
		shopNum1_ScoreProductCategory.Family = string.Empty;
		shopNum1_ScoreProductCategory.CreateUser = "admin";
		shopNum1_ScoreProductCategory.CreateTime = DateTime.Now;
		shopNum1_ScoreProductCategory.ModifyUser = "admin";
		shopNum1_ScoreProductCategory.ModifyTime = DateTime.Now;
		shopNum1_ScoreProductCategory.IsDeleted = 0;
		shopNum1_ScoreProductCategory.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString());
		ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
		int num = shopNum1_ScoreProductCategory_Action.Update(shopNum1_ScoreProductCategory);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "编辑地区成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ShopNum1_ScoreProductCategory_Operate.aspx",
				Date = DateTime.Now
			});
			base.Response.Redirect("ShopNum1_ScoreProductCategory_List.aspx");
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
