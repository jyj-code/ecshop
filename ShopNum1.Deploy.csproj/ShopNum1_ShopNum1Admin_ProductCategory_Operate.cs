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
public class ShopNum1_ShopNum1Admin_ProductCategory_Operate : PageBase, IRequiresSessionState
{
	protected string strSapce = "\u3000\u3000";
	private IShopNum1_SpecificationProudctCategory_Action ishopNum1_SpecificationProudctCategory_Action_0 = LogicFactory.CreateShopNum1_SpecificationProudctCategory_Action();
	protected char charSapce = '\u3000';
	private ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action_0 = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize Localize6;
	protected TextBox TextBoxId;
	protected HtmlTableRow trID;
	protected Localize Localize1;
	protected TextBox TextBoxName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Localize Localize7;
	protected DropDownList DropDownListCateType;
	protected Label Label2;
	protected CompareValidator CompareValidator1;
	protected Localize Localize8;
	protected TextBox TextBoxCode;
	protected HtmlTableRow trCode;
	protected Localize LocalizeFatherCateGory;
	protected DropDownList DropDownListFatherCateGory;
	protected Label Label3;
	protected CompareValidator CompareFatherCateGory;
	protected Localize Localize2;
	protected TextBox TextBoxKeywords;
	protected RegularExpressionValidator RegularExpressionValidatorKeywords;
	protected Localize Localize9;
	protected HiddenField HiddenFieldOriginalImge;
	protected HtmlImage ImageOriginalImge;
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
	protected MessageShow MessageShow;
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
		if (!this.Page.IsPostBack)
		{
			this.method_5();
		}
	}
	private void method_5()
	{
		this.method_7();
		this.method_6();
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.LabelTitle.Text = "编辑商品分类";
			this.method_10();
			this.trID.Visible = false;
			this.trCode.Visible = false;
			this.DropDownListFatherCateGory.Enabled = false;
			if (Common.ReqStr("op") == "add")
			{
				this.TextBoxOrderID.Text = Convert.ToString(this.method_9() + 1);
			}
		}
		else
		{
			this.TextBoxOrderID.Text = Convert.ToString(this.method_9() + 1);
			this.trID.Visible = false;
			this.trCode.Visible = false;
		}
	}
	private void method_6()
	{
		this.DropDownListFatherCateGory.Enabled = true;
		this.DropDownListCateType.Items.Clear();
		ShopNum1_CategoryType_Action shopNum1_CategoryType_Action = (ShopNum1_CategoryType_Action)LogicFactory.CreateShopNum1_CategoryType_Action();
		DataTable dataTable = shopNum1_CategoryType_Action.Select_ProductCategoryType();
		ListItem listItem = new ListItem();
		listItem.Text = "-请选择-";
		listItem.Value = "-1";
		this.DropDownListCateType.Items.Add(listItem);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString();
			listItem2.Value = dataRow["ID"].ToString();
			this.DropDownListCateType.Items.Add(listItem2);
		}
	}
	private void method_7()
	{
		this.DropDownListFatherCateGory.Items.Clear();
		if (Common.ReqStr("op") != "add")
		{
			ListItem listItem = new ListItem();
			listItem.Text = "顶级分类";
			listItem.Value = "0";
			this.DropDownListFatherCateGory.Items.Add(listItem);
			DataTable dataTable = this.shopNum1_ProductCategory_Action_0.SearchtTwoProductCategory(0, 0);
			foreach (DataRow dataRow in dataTable.Rows)
			{
				ListItem listItem2 = new ListItem();
				listItem2.Text = dataRow["Name"].ToString();
				listItem2.Value = dataRow["ID"].ToString();
				this.DropDownListFatherCateGory.Items.Add(listItem2);
				this.method_8(Convert.ToInt32(dataRow["ID"].ToString()));
			}
		}
	}
	private void method_8(int int_0)
	{
		DataTable dataTable = this.shopNum1_ProductCategory_Action_0.SearchtTwoProductCategory(int_0, 0);
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
			this.method_8(Convert.ToInt32(dataRow["ID"].ToString()));
		}
	}
	private int method_9()
	{
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ProductCategory");
	}
	private void method_10()
	{
		if (base.Request.QueryString["op"].ToString() == "edit")
		{
			DataTable productCategoryByID = this.shopNum1_ProductCategory_Action_0.GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
			this.TextBoxName.Text = productCategoryByID.Rows[0]["Name"].ToString();
			this.TextBoxKeywords.Text = productCategoryByID.Rows[0]["Keywords"].ToString();
			this.TextBoxDescription.Text = productCategoryByID.Rows[0]["Description"].ToString();
			this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
			this.DropDownListFatherCateGory.Text = productCategoryByID.Rows[0]["FatherID"].ToString();
			this.DropDownListCateType.Text = productCategoryByID.Rows[0]["CategoryType"].ToString();
			if (productCategoryByID.Rows[0]["IsShow"].ToString() == "1")
			{
				this.CheckBoxIsShow.Checked = true;
			}
			else
			{
				this.CheckBoxIsShow.Checked = false;
			}
			this.ImageOriginalImge.Src = productCategoryByID.Rows[0]["logoimg"].ToString();
			this.HiddenFieldOriginalImge.Value = this.ImageOriginalImge.Src;
			this.TextBoxId.Text = this.hiddenFieldGuid.Value.ToString();
			this.TextBoxCode.Text = productCategoryByID.Rows[0]["code"].ToString();
			this.ButtonConfirm.Text = "更新";
			this.ButtonConfirm.ToolTip = "Update";
		}
		else if (base.Request.QueryString["op"].ToString() == "add" && Common.ReqStr("guid") != "")
		{
			DataTable productCategoryByID = this.shopNum1_ProductCategory_Action_0.GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
			this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
			string nameById = Common.GetNameById("[Name]+','+cast(id as varchar(8))", "ShopNum1_ProductCategory", " and id='" + Common.ReqStr("guid") + "'");
			ListItem listItem = new ListItem();
			if (Common.ReqStr("level") == "1")
			{
				listItem.Text = this.charSapce + nameById.Split(new char[]
				{
					','
				})[0];
			}
			else if (Common.ReqStr("level") == "2")
			{
				listItem.Text = this.strSapce + nameById.Split(new char[]
				{
					','
				})[0];
			}
			listItem.Value = nameById.Split(new char[]
			{
				','
			})[1];
			this.DropDownListFatherCateGory.Items.Add(listItem);
			this.ButtonConfirm.Text = "添加";
			this.ButtonConfirm.ToolTip = "Submit";
		}
		else
		{
			DataTable productCategoryByID = this.shopNum1_ProductCategory_Action_0.GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
			this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
			this.DropDownListFatherCateGory.Text = base.Request.QueryString["guid"].ToString();
			this.ButtonConfirm.Text = "添加";
			this.ButtonConfirm.ToolTip = "Submit";
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Update")
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "更改商品分类",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "ShopNum1_ProductCategory_Operate.aspx",
				Date = DateTime.Now
			});
			this.method_13();
			this.method_5();
		}
		else if (this.ButtonConfirm.ToolTip == "Submit")
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "新增商品分类",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "ShopNum1_ProductCategory_Operate.aspx",
				Date = DateTime.Now
			});
			this.method_11();
			this.Page.RegisterClientScriptBlock("pop", "<script>window.parent.location.reload();</script>");
		}
	}
	private void method_11()
	{
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		ShopNum1_ProductCategory shopNum1_ProductCategory = new ShopNum1_ProductCategory();
		shopNum1_ProductCategory.Name = this.TextBoxName.Text.Trim();
		shopNum1_ProductCategory.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_ProductCategory.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_ProductCategory.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		this.ImageOriginalImge.Src = this.HiddenFieldOriginalImge.Value;
		shopNum1_ProductCategory.logoimg = this.ImageOriginalImge.Src;
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
					MessageBox.Show("商品分类为三级分类!");
					return;
				}
			}
			else
			{
				shopNum1_ProductCategory.CategoryLevel = 2;
			}
		}
		if (Common.ReqStr("op") == "add" && Common.ReqStr("guid") != "")
		{
			shopNum1_ProductCategory.FatherID = Convert.ToInt32(Common.ReqStr("guid"));
		}
		else
		{
			shopNum1_ProductCategory.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
		}
		shopNum1_ProductCategory.CreateUser = "admin";
		shopNum1_ProductCategory.CreateTime = DateTime.Now;
		shopNum1_ProductCategory.ModifyUser = "admin";
		shopNum1_ProductCategory.ModifyTime = DateTime.Now;
		shopNum1_ProductCategory.IsDeleted = 0;
		shopNum1_ProductCategory.CategoryType = new int?(Convert.ToInt32(this.DropDownListCateType.SelectedValue));
		shopNum1_ProductCategory.CategoryTypeName = this.DropDownListCateType.SelectedItem.Text;
		object obj = shopNum1_ProductCategory_Action.Add1(shopNum1_ProductCategory);
		if (obj != null)
		{
			string productcategoryid = Convert.ToString(obj);
			if (this.hiddenFieldSpecification.Value != "-1")
			{
				this.ishopNum1_SpecificationProudctCategory_Action_0.InsertMuch(productcategoryid, "", this.hiddenFieldSpecification.Value);
			}
			this.method_12();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	private void method_12()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxKeywords.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.TextBoxOrderID.Text = (int.Parse(this.TextBoxOrderID.Text) + 1).ToString();
		this.CheckBoxIsShow.Checked = true;
	}
	private void method_13()
	{
		ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
		ShopNum1_ProductCategory shopNum1_ProductCategory = new ShopNum1_ProductCategory();
		this.ImageOriginalImge.Src = this.HiddenFieldOriginalImge.Value;
		shopNum1_ProductCategory.logoimg = this.ImageOriginalImge.Src;
		shopNum1_ProductCategory.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
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
					MessageBox.Show("商品分类为三级分类!");
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
		shopNum1_ProductCategory.CategoryType = new int?(Convert.ToInt32(this.DropDownListCateType.SelectedValue));
		shopNum1_ProductCategory.CategoryTypeName = this.DropDownListCateType.SelectedItem.Text;
		int num = shopNum1_ProductCategory_Action.Update(this.hiddenFieldGuid.Value.ToString(), shopNum1_ProductCategory);
		if (num > 0)
		{
			if (this.hiddenFieldSpecification.Value != "-1")
			{
				this.ishopNum1_SpecificationProudctCategory_Action_0.InsertMuch(this.hiddenFieldGuid.Value, "", this.hiddenFieldSpecification.Value);
			}
			else
			{
				this.ishopNum1_SpecificationProudctCategory_Action_0.DeleteByProductCategoryID(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
			}
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
		this.method_12();
	}
}
