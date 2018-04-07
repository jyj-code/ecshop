using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_Prefecture_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize Localize1;
	protected ShopNum1.Control.TextBox TextBoxName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Localize LocalizeFatherCateGory;
	protected System.Web.UI.WebControls.DropDownList DropDownListFatherCateGory;
	protected CompareValidator CompareFatherCateGory;
	protected Localize Localize4;
	protected System.Web.UI.WebControls.TextBox TextBoxOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxOrderID;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected System.Web.UI.WebControls.Button ButtonConfirm;
	protected System.Web.UI.WebControls.Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	private ShopNum1_Region_Action shopNum1_Region_Action_0 = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
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
				this.LabelTitle.Text = "编辑区域";
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
		DataTable dataTable = this.shopNum1_Region_Action_0.SearchtRegionCategory(0, 0);
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
		DataTable dataTable = this.shopNum1_Region_Action_0.SearchtRegionCategory(int_0, 0);
		foreach (DataRow dataRow in dataTable.Rows)
		{
			if (dataRow["CategoryLevel"].ToString() == "3")
			{
				break;
			}
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
		return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Region");
	}
	private void method_8()
	{
		DataTable regionCategoryByID = this.shopNum1_Region_Action_0.GetRegionCategoryByID(this.hiddenFieldGuid.Value.ToString());
		if (regionCategoryByID.Rows.Count > 0)
		{
			this.TextBoxName.Text = regionCategoryByID.Rows[0]["Name"].ToString();
			this.TextBoxOrderID.Text = regionCategoryByID.Rows[0]["OrderID"].ToString();
			this.DropDownListFatherCateGory.Text = regionCategoryByID.Rows[0]["FatherID"].ToString();
			this.ButtonConfirm.Text = "更新";
			this.ButtonConfirm.ToolTip = "Update";
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
		ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
		ShopNum1_Region shopNum1_Region = new ShopNum1_Region();
		shopNum1_Region.Name = this.TextBoxName.Text.Trim();
		shopNum1_Region.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
		{
			shopNum1_Region.CategoryLevel = 1;
		}
		else
		{
			string[] array = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[]
			{
				this.charSapce
			});
			if (array.Length > 0)
			{
				shopNum1_Region.CategoryLevel = (array.Length + 1) / 2 + 1;
				if (shopNum1_Region.CategoryLevel >= 4)
				{
					MessageBox.Show("区域分类为三级分类!");
					return;
				}
			}
			else
			{
				shopNum1_Region.CategoryLevel = 2;
			}
		}
		shopNum1_Region.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
		shopNum1_Region.Family = string.Empty;
		shopNum1_Region.CreateUser = "admin";
		shopNum1_Region.CreateTime = DateTime.Now;
		shopNum1_Region.ModifyUser = "admin";
		shopNum1_Region.ModifyTime = DateTime.Now;
		shopNum1_Region.IsDeleted = "0";
		if (shopNum1_Region_Action.Add(shopNum1_Region) > 0)
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
	private void method_10()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxOrderID.Text = (this.method_7() + 1).ToString();
	}
	private void method_11()
	{
		ShopNum1_Region shopNum1_Region = new ShopNum1_Region();
		shopNum1_Region.ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
		shopNum1_Region.Name = this.TextBoxName.Text.Trim();
		shopNum1_Region.OrderID = Convert.ToInt32(this.TextBoxOrderID.Text);
		if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
		{
			shopNum1_Region.CategoryLevel = 1;
		}
		else
		{
			string[] array = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[]
			{
				this.charSapce
			});
			if (array.Length > 0)
			{
				shopNum1_Region.CategoryLevel = (array.Length + 1) / 2 + 1;
				if (shopNum1_Region.CategoryLevel >= 4)
				{
					MessageBox.Show("区域分类为三级分类!");
					return;
				}
			}
			else
			{
				shopNum1_Region.CategoryLevel = 2;
			}
		}
		shopNum1_Region.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
		shopNum1_Region.Family = string.Empty;
		shopNum1_Region.CreateUser = "";
		shopNum1_Region.CreateTime = DateTime.Now;
		shopNum1_Region.ModifyUser = "";
		shopNum1_Region.ModifyTime = DateTime.Now;
		shopNum1_Region.IsDeleted = "0";
		int num = this.shopNum1_Region_Action_0.Update(this.hiddenFieldGuid.Value.ToString(), shopNum1_Region);
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
