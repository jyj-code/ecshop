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
public class Admin_Brand_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorLogoName;
	protected TextBox txtCategoryName;
	protected Label LabelWebSite;
	protected TextBox TextBoxWebSite;
	protected RegularExpressionValidator RegularExpressionValidatorLogoWebSite;
	protected Label LabelKeywords;
	protected TextBox TextBoxKeywords;
	protected RegularExpressionValidator RegularExpressionValidatorLogoKeywords;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label5;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorLogoOrderID;
	protected Label LabelIsShow;
	protected DropDownList DropDownListIsShow;
	protected Label Label4;
	protected CheckBox CheckBoxIsCommend;
	protected Label LabelLogo;
	protected TextBox TextBoxLogo;
	protected RegularExpressionValidator RegularExpressionValidatorLogo;
	protected HtmlImage ImageOriginalImge;
	protected Label LabelRemark;
	protected TextBox TextBoxRemark;
	protected Label Label1Description;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorLogoDescription;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldBrandName;
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
			this.GetOrderID();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.GetEditInfo();
				this.ButtonConfirm.Text = "更新";
			}
			else
			{
				this.TextBoxOrderID.Text = Convert.ToString(this.GetOrderID() + 1);
			}
		}
	}
	protected int GetOrderID()
	{
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Brand");
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
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		DataTable dataTable = shopNum1_Brand_Action.CheckBrand(this.TextBoxName.Text);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			MessageBox.Show("此商品品牌已存在!");
		}
		else
		{
			ShopNum1_Brand shopNum1_Brand = new ShopNum1_Brand();
			shopNum1_Brand.Guid = Guid.NewGuid();
			shopNum1_Brand.Name = this.TextBoxName.Text.Trim();
			shopNum1_Brand.Logo = this.TextBoxLogo.Text.Trim();
			shopNum1_Brand.WebSite = this.TextBoxWebSite.Text.Trim().Replace("http://", "");
			shopNum1_Brand.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
			shopNum1_Brand.Keywords = this.TextBoxKeywords.Text.Trim();
			shopNum1_Brand.IsShow = Convert.ToInt32(this.DropDownListIsShow.SelectedValue.ToString());
			shopNum1_Brand.Remark = this.TextBoxRemark.Text.Trim();
			shopNum1_Brand.Description = this.TextBoxDescription.Text.Trim();
			shopNum1_Brand.CreateUser = "admin";
			shopNum1_Brand.CreateTime = DateTime.Now;
			shopNum1_Brand.ModifyUser = "admin";
			shopNum1_Brand.ModifyTime = DateTime.Now;
			shopNum1_Brand.IsDeleted = 0;
			shopNum1_Brand.CategoryName = this.txtCategoryName.Text;
			if (this.CheckBoxIsCommend.Checked)
			{
				shopNum1_Brand.IsCommend = 1;
			}
			else
			{
				shopNum1_Brand.IsCommend = 0;
			}
			ShopNum1_Brand_Action shopNum1_Brand_Action2 = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
			int num = shopNum1_Brand_Action2.Add(shopNum1_Brand);
			if (num > 0)
			{
				this.ClearControl();
				this.GetOrderID();
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void Edit()
	{
		ShopNum1_Brand_Action arg_0A_0 = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		ShopNum1_Brand shopNum1_Brand = new ShopNum1_Brand();
		shopNum1_Brand.Name = this.TextBoxName.Text.Trim();
		shopNum1_Brand.Logo = this.TextBoxLogo.Text.Trim();
		shopNum1_Brand.WebSite = this.TextBoxWebSite.Text.Trim().Replace("http://", "").Replace("https://", "");
		shopNum1_Brand.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim());
		shopNum1_Brand.Keywords = this.TextBoxKeywords.Text.Trim();
		shopNum1_Brand.IsShow = Convert.ToInt32(this.DropDownListIsShow.SelectedValue.ToString());
		shopNum1_Brand.Remark = this.TextBoxRemark.Text.Trim();
		shopNum1_Brand.Description = this.TextBoxDescription.Text.Trim();
		shopNum1_Brand.ModifyUser = "admin";
		shopNum1_Brand.ModifyTime = DateTime.Now;
		shopNum1_Brand.IsDeleted = 0;
		shopNum1_Brand.CategoryName = this.txtCategoryName.Text;
		if (this.CheckBoxIsCommend.Checked)
		{
			shopNum1_Brand.IsCommend = 1;
		}
		else
		{
			shopNum1_Brand.IsCommend = 0;
		}
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		int num = shopNum1_Brand_Action.Update(this.hiddenFieldGuid.Value, shopNum1_Brand);
		if (num > 0)
		{
			base.Response.Redirect("Brand_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		DataTable editInfo = shopNum1_Brand_Action.GetEditInfo(this.hiddenFieldGuid.Value);
		this.TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
		this.ViewState["BrandName"] = this.TextBoxName.Text;
		this.TextBoxLogo.Text = editInfo.Rows[0]["Logo"].ToString();
		if (editInfo.Rows[0]["Logo"].ToString() != string.Empty)
		{
			this.ImageOriginalImge.Src = editInfo.Rows[0]["Logo"].ToString();
		}
		else
		{
			this.ImageOriginalImge.Src = Globals.ApplicationPath + "/Images/noImage.gif";
		}
		this.txtCategoryName.Text = editInfo.Rows[0]["categoryName"].ToString();
		this.TextBoxWebSite.Text = editInfo.Rows[0]["WebSite"].ToString();
		this.TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
		this.TextBoxKeywords.Text = editInfo.Rows[0]["Keywords"].ToString();
		this.TextBoxRemark.Text = editInfo.Rows[0]["Remark"].ToString();
		this.TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
		this.DropDownListIsShow.SelectedValue = editInfo.Rows[0]["IsShow"].ToString();
		if (editInfo.Rows[0]["IsCommend"].ToString() == "1")
		{
			this.CheckBoxIsCommend.Checked = true;
		}
		this.ButtonConfirm.Text = "更新";
		this.LabelPageTitle.Text = "编辑商品品牌";
	}
	protected void ClearControl()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxLogo.Text = string.Empty;
		this.TextBoxWebSite.Text = string.Empty;
		this.TextBoxOrderID.Text = (int.Parse(this.TextBoxOrderID.Text) + 1).ToString();
		this.TextBoxRemark.Text = string.Empty;
		this.TextBoxKeywords.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.DropDownListIsShow.SelectedValue = "-1";
		this.CheckBoxIsCommend.Checked = false;
	}
}
