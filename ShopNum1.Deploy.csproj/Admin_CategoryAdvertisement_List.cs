using ShopNum1.BusinessLogic;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_CategoryAdvertisement_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.TextBox TextBoxPageName;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsBuy;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsShow;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory1;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory2;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategory3;
	protected System.Web.UI.WebControls.DropDownList DropDownListAdPageName;
	protected System.Web.UI.WebControls.DropDownList DropDownListAdID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.Button ButtonSearchDetail;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCategoryCode;
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
		if (this.Page.IsPostBack)
		{
		}
		this.BindGrid();
	}
	public void BindGrid()
	{
		this.returnCategoryCode();
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("CategoryAdvertisement_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryAdvertisement_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryAdvertisement_Action shopNum1_CategoryAdvertisement_Action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
		int num = shopNum1_CategoryAdvertisement_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void DropDownListCategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListCategory1.SelectedValue == "-1")
		{
			this.DropDownListCategory2.Items.Clear();
			this.DropDownListCategory3.Items.Clear();
			this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
			this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
		}
		else if (this.DropDownListAdPageName.SelectedValue != "5")
		{
			this.method_5(this.DropDownListCategory1.SelectedValue.Split(new char[]
			{
				'/'
			})[1], this.DropDownListCategory2);
		}
		else
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			DataTable dataTable = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(this.DropDownListCategory1.SelectedValue), 0);
			this.DropDownListCategory2.Items.Clear();
			this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
			foreach (DataRow dataRow in dataTable.Rows)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString();
				listItem.Value = dataRow["ID"].ToString().Trim();
				this.DropDownListCategory2.Items.Add(listItem);
			}
		}
	}
	protected void DropDownListCategory2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListCategory2.SelectedValue == "-1")
		{
			this.DropDownListCategory3.Items.Clear();
			this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
		}
		else if (this.DropDownListAdPageName.SelectedValue != "5")
		{
			this.method_5(this.DropDownListCategory2.SelectedValue.Split(new char[]
			{
				'/'
			})[1], this.DropDownListCategory3);
		}
		else
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			DataTable dataTable = shopNum1_ArticleCategory_Action.Search(Convert.ToInt32(this.DropDownListCategory2.SelectedValue), 0);
			this.DropDownListCategory3.Items.Clear();
			this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
			foreach (DataRow dataRow in dataTable.Rows)
			{
				ListItem listItem = new ListItem();
				listItem.Text = dataRow["Name"].ToString();
				listItem.Value = dataRow["ID"].ToString().Trim();
				this.DropDownListCategory3.Items.Add(listItem);
			}
		}
	}
	protected void DropDownListAdPageName_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListAdID.Items.Clear();
		this.DropDownListAdID.Items.Add(new ListItem("-请选择-", "-1"));
		this.DropDownListCategory1.Items.Clear();
		this.DropDownListCategory2.Items.Clear();
		this.DropDownListCategory3.Items.Clear();
		this.DropDownListCategory1.Items.Add(new ListItem("-请选择-", "-1"));
		this.DropDownListCategory2.Items.Add(new ListItem("-请选择-", "-1"));
		this.DropDownListCategory3.Items.Add(new ListItem("-请选择-", "-1"));
		if (!(this.DropDownListAdPageName.SelectedValue == "-1"))
		{
			ShopNum1_CategoryAdID_Action shopNum1_CategoryAdID_Action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
			DataTable dataTable = shopNum1_CategoryAdID_Action.Search(this.DropDownListAdPageName.SelectedValue, "-1");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.DropDownListAdID.Items.Clear();
				this.DropDownListAdID.Items.Add(new ListItem("-请选择-", "-1"));
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					ListItem listItem = new ListItem();
					listItem.Text = dataTable.Rows[i]["CategoryAdName"].ToString();
					listItem.Value = dataTable.Rows[i]["ID"].ToString();
					this.DropDownListAdID.Items.Add(listItem);
				}
			}
			ShopNum1_CategoryAdvertisement_Action arg_1D3_0 = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
			if (this.DropDownListAdPageName.SelectedValue == "1")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "2")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "3")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "4")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "6")
			{
				this.method_5("0", this.DropDownListCategory1);
			}
			if (this.DropDownListAdPageName.SelectedValue == "5")
			{
				this.DropDownListCategory1.Items.Clear();
				this.DropDownListCategory1.Items.Clear();
				this.DropDownListCategory1.Items.Add(new ListItem("-请选择-", "-1"));
				ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
				DataTable dataTable2 = shopNum1_ArticleCategory_Action.Search(0, 0);
				if (dataTable2 != null && dataTable2.Rows.Count > 0)
				{
					foreach (DataRow dataRow in dataTable2.Rows)
					{
						ListItem listItem2 = new ListItem();
						listItem2.Text = dataRow["Name"].ToString();
						listItem2.Value = dataRow["ID"].ToString();
						this.DropDownListCategory1.Items.Add(listItem2);
					}
				}
			}
		}
	}
	public string CategoryType(object object_0)
	{
		string a = object_0.ToString();
		string result;
		if (a == "1")
		{
			result = "商品分类";
		}
		else if (a == "2")
		{
			result = "分类信息分类";
		}
		else if (a == "3")
		{
			result = "供求分类";
		}
		else if (a == "4")
		{
			result = "店铺分类";
		}
		else if (a == "5")
		{
			result = "资讯分类";
		}
		else if (a == "6")
		{
			result = "品牌分类";
		}
		else
		{
			result = "非法页面";
		}
		return result;
	}
	private void method_5(string string_5, System.Web.UI.WebControls.DropDownList dropDownList_0)
	{
		string tableName = string.Empty;
		if (this.DropDownListAdPageName.SelectedValue == "1")
		{
			tableName = "ShopNum1_ProductCategory";
		}
		if (this.DropDownListAdPageName.SelectedValue == "2")
		{
			tableName = "ShopNum1_Category";
		}
		if (this.DropDownListAdPageName.SelectedValue == "3")
		{
			tableName = "ShopNum1_SupplyDemandCategory";
		}
		if (this.DropDownListAdPageName.SelectedValue == "4")
		{
			tableName = "ShopNum1_ShopCategory";
		}
		if (this.DropDownListAdPageName.SelectedValue == "6")
		{
			tableName = "ShopNum1_ProductCategory";
		}
		ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		shopNum1_Brand_Action.TableName = tableName;
		DataTable productCategoryCode = shopNum1_Brand_Action.GetProductCategoryCode(string_5);
		dropDownList_0.Items.Clear();
		dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
		if (productCategoryCode != null && productCategoryCode.Rows.Count > 0)
		{
			for (int i = 0; i < productCategoryCode.Rows.Count; i++)
			{
				dropDownList_0.Items.Add(new ListItem(productCategoryCode.Rows[i]["Name"].ToString(), productCategoryCode.Rows[i]["Code"].ToString() + "/" + productCategoryCode.Rows[i]["ID"].ToString()));
			}
		}
	}
	public void returnCategoryCode()
	{
		if (this.DropDownListAdPageName.SelectedValue != "5")
		{
			if (this.DropDownListCategory3.SelectedValue != "-1")
			{
				this.HiddenFieldCategoryCode.Value = this.DropDownListCategory3.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.DropDownListCategory2.SelectedValue != "-1")
			{
				this.HiddenFieldCategoryCode.Value = this.DropDownListCategory2.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.DropDownListCategory1.SelectedValue != "-1")
			{
				this.HiddenFieldCategoryCode.Value = this.DropDownListCategory1.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else
			{
				this.HiddenFieldCategoryCode.Value = "-1";
			}
		}
		else if (this.DropDownListCategory3.SelectedValue != "-1")
		{
			this.HiddenFieldCategoryCode.Value = this.DropDownListCategory3.SelectedValue;
		}
		else if (this.DropDownListCategory2.SelectedValue != "-1")
		{
			this.HiddenFieldCategoryCode.Value = this.DropDownListCategory2.SelectedValue;
		}
		else if (this.DropDownListCategory1.SelectedValue != "-1")
		{
			this.HiddenFieldCategoryCode.Value = this.DropDownListCategory1.SelectedValue;
		}
		else
		{
			this.HiddenFieldCategoryCode.Value = "-1";
		}
	}
	public string IsBuy(object object_0)
	{
		string a = object_0.ToString();
		string result;
		if (a == "0")
		{
			result = "未购买";
		}
		else
		{
			result = "已购买";
		}
		return result;
	}
	public string IsShow(object object_0)
	{
		string a = object_0.ToString();
		string result;
		if (a == "0")
		{
			result = "不显示";
		}
		else
		{
			result = "显示";
		}
		return result;
	}
	protected void ButtonSearchDetail_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryAdvertisement_SearchDetail.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryAdvertisement_Action shopNum1_CategoryAdvertisement_Action = (ShopNum1_CategoryAdvertisement_Action)LogicFactory.CreateShopNum1_CategoryAdvertisement_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_CategoryAdvertisement_Action.Delete(commandArgument);
		if (num > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
}
