using ShopNum1.BusinessLogic;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_CouponType_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelOrderID;
	protected TextBox TextBoxOrderID;
	protected Label Label4;
	protected RegularExpressionValidator RegularExpressionValidatorOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected Label LabelIsShow;
	protected CheckBox CheckBoxIsShow;
	protected Label LabelDescription;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorTitle1;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"]);
		if (!this.Page.IsPostBack)
		{
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.GetEditInfo();
				this.ButtonConfirm.Text = "更新";
			}
			else
			{
				this.GetOrderID();
			}
		}
	}
	protected void GetOrderID()
	{
		string columnName = "OrderID";
		string tableName = "ShopNum1_Shop_CouponType";
		this.TextBoxOrderID.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			ShopNum1_Shop_CouponType shopNum1_Shop_CouponType = new ShopNum1_Shop_CouponType();
			shopNum1_Shop_CouponType.Name = this.TextBoxName.Text.Trim();
			shopNum1_Shop_CouponType.OrderID = int.Parse(this.TextBoxOrderID.Text.Trim());
			shopNum1_Shop_CouponType.Comment = this.TextBoxDescription.Text.Trim();
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_Shop_CouponType.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_CouponType.IsShow = 0;
			}
			shopNum1_Shop_CouponType.CreateUser = base.ShopNum1LoginID;
			shopNum1_Shop_CouponType.CreateTime = DateTime.Now;
			shopNum1_Shop_CouponType.IsDeleted = new int?(0);
			Shop_CouponType_Action shop_CouponType_Action = (Shop_CouponType_Action)LogicFactory.CreateShop_CouponType_Action();
			int num = shop_CouponType_Action.Add(shopNum1_Shop_CouponType);
			if (num > 0)
			{
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
				this.method_5();
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
		else if (this.ButtonConfirm.ToolTip == "Update")
		{
			ShopNum1_Shop_CouponType shopNum1_Shop_CouponType = new ShopNum1_Shop_CouponType();
			shopNum1_Shop_CouponType.Name = this.TextBoxName.Text.Trim();
			shopNum1_Shop_CouponType.OrderID = int.Parse(this.TextBoxOrderID.Text.Trim());
			shopNum1_Shop_CouponType.Comment = this.TextBoxDescription.Text.Trim();
			if (this.CheckBoxIsShow.Checked)
			{
				shopNum1_Shop_CouponType.IsShow = 1;
			}
			else
			{
				shopNum1_Shop_CouponType.IsShow = 0;
			}
			shopNum1_Shop_CouponType.ModifyUser = base.ShopNum1LoginID;
			shopNum1_Shop_CouponType.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_CouponType.id = int.Parse(this.hiddenFieldGuid.Value.Replace("'", ""));
			Shop_CouponType_Action shop_CouponType_Action = (Shop_CouponType_Action)LogicFactory.CreateShop_CouponType_Action();
			int num = shop_CouponType_Action.Update(shopNum1_Shop_CouponType);
			if (num > 0)
			{
				base.Response.Redirect("CouponType_List.aspx");
			}
			else
			{
				this.MessageShow.ShowMessage("EditNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	private void method_5()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxDescription.Text = string.Empty;
		this.CheckBoxIsShow.Checked = true;
		this.GetOrderID();
	}
	protected void GetEditInfo()
	{
		Shop_CouponType_Action shop_CouponType_Action = (Shop_CouponType_Action)LogicFactory.CreateShop_CouponType_Action();
		DataTable dataTable = shop_CouponType_Action.search(int.Parse(this.hiddenFieldGuid.Value.Replace("'", "")), -1);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
			this.TextBoxOrderID.Text = dataTable.Rows[0]["OrderID"].ToString();
			this.TextBoxDescription.Text = dataTable.Rows[0]["Comment"].ToString();
			if (dataTable.Rows[0]["IsShow"].ToString() == "1")
			{
				this.CheckBoxIsShow.Checked = true;
			}
			else
			{
				this.CheckBoxIsShow.Checked = false;
			}
		}
		this.ButtonConfirm.ToolTip = "Update";
		this.LabelPageTitle.Text = "编辑优惠券分类";
	}
}
