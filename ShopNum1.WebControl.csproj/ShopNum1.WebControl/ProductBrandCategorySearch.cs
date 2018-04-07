using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	public class ProductBrandCategorySearch : BaseWebControl
	{
		private string string_0 = "ProductBrandCategorySearch.ascx";
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private DropDownList dropDownList_3;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private Label label_0;
		private Label label_1;
		private TextBox textBox_0;
		private Button button_0;
		private int int_0 = 20;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public int PageCount
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public string ProcuctCategoryCode
		{
			get;
			set;
		}
		public string BrandGuid
		{
			get;
			set;
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterDataBrand");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterDataCategory");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListRegionCode1");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode1_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListRegionCode2");
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode2_SelectedIndexChanged);
			this.dropDownList_2 = (DropDownList)skin.FindControl("DropDownListRegionCode3");
			this.dropDownList_2.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode3_SelectedIndexChanged);
			this.dropDownList_3 = (DropDownList)skin.FindControl("DropDownListRegionCode4");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonFirst");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonLast");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonNext");
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonEnd");
			this.label_0 = (Label)skin.FindControl("LabelPageIndex");
			this.label_1 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxPageNum");
			this.button_0 = (Button)skin.FindControl("ButtonGo");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.IsPostBack)
			{
			}
			this.DropDownListRegionCode1Bind();
			if (this.Page.Request.QueryString["productCategoryCode"] != null)
			{
				this.ProcuctCategoryCode = this.Page.Request.QueryString["productCategoryCode"];
			}
			else
			{
				this.ProcuctCategoryCode = "-1";
			}
			if (this.Page.Request.QueryString["brandGuid"] != null)
			{
				this.BrandGuid = this.Page.Request.QueryString["brandGuid"];
			}
			else
			{
				this.BrandGuid = "-1";
			}
			this.BindData();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.label_0.Text = this.textBox_0.Text;
			this.BindData();
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.label_0.Text = this.label_1.Text;
			this.BindData();
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.label_0.Text = (int.Parse(this.label_0.Text) + 1).ToString();
			this.BindData();
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.label_0.Text = (int.Parse(this.label_0.Text) - 1).ToString();
			this.BindData();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.label_0.Text = "1";
			this.BindData();
		}
		protected void BindData()
		{
			string addresscode = this.SetShopRegionCode();
			string procuctCategoryCode = this.ProcuctCategoryCode;
			string brandGuid = this.BrandGuid;
			if (procuctCategoryCode.Length.ToString() == "6")
			{
				ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
				this.repeater_1.DataSource = shopNum1_Brand_Action.GetProductBrand(this.ProcuctCategoryCode);
				this.repeater_1.DataBind();
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				this.repeater_2.DataSource = shopNum1_ProductCategory_Action.GetProductCategoryCode(this.ProcuctCategoryCode);
				this.repeater_2.DataBind();
			}
			int num = int.Parse(this.label_0.Text);
			if (this.ViewState["PageData"] == null)
			{
				ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
				DataSet value = shopNum1_ProuductChecked_Action.SearchProductList(num.ToString(), this.int_0.ToString(), addresscode, procuctCategoryCode, "-1", "-1", "-1", brandGuid);
				this.ViewState["PageData"] = value;
			}
			else if ((num / 10).ToString() != ((DataSet)this.ViewState["PageData"]).Tables[1].Rows[0][0].ToString())
			{
				ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
				DataSet value = shopNum1_ProuductChecked_Action.SearchProductList(num.ToString(), this.int_0.ToString(), addresscode, procuctCategoryCode, "-1", "-1", "-1", brandGuid);
				this.ViewState["PageData"] = value;
			}
			this.label_1.Text = ((((DataSet)this.ViewState["PageData"]).Tables[2].Rows[0][0].ToString() == "0") ? "1" : ((DataSet)this.ViewState["PageData"]).Tables[2].Rows[0][0].ToString());
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = this.PageCount;
			pagedDataSource.DataSource = ((DataSet)this.ViewState["PageData"]).Tables[0].DefaultView;
			pagedDataSource.CurrentPageIndex = (num - 1) % 10;
			this.repeater_0.DataSource = pagedDataSource;
			this.repeater_0.DataBind();
			this.linkButton_0.Enabled = true;
			this.linkButton_1.Enabled = true;
			this.linkButton_2.Enabled = true;
			this.linkButton_3.Enabled = true;
			if (num == 1)
			{
				this.linkButton_0.Enabled = false;
				this.linkButton_1.Enabled = false;
			}
			if (num.ToString() == this.label_1.Text)
			{
				this.linkButton_2.Enabled = false;
				this.linkButton_3.Enabled = false;
			}
		}
		protected void DropDownListRegionCode1Bind()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("--省级--", "-1"));
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
			DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName("0");
			for (int i = 0; i < productCategoryName.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
			}
			this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_1.Items.Clear();
			this.dropDownList_1.Items.Add(new ListItem("—市级—", "-1"));
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_1.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
			this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Items.Clear();
			this.dropDownList_2.Items.Add(new ListItem("—县级—", "-1"));
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_2.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
			this.DropDownListRegionCode3_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_3.Items.Clear();
			this.dropDownList_3.Items.Add(new ListItem("—乡镇级—", "-1"));
			if (this.dropDownList_2.SelectedValue != "-1")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_3.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
		}
		public string SetShopRegionCode()
		{
			string result;
			if (this.dropDownList_3.SelectedValue != "-1")
			{
				result = this.dropDownList_3.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_2.SelectedValue != "-1")
			{
				result = this.dropDownList_2.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_1.SelectedValue != "-1")
			{
				result = this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_0.SelectedValue != "-1")
			{
				result = this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public static string GetSubstr(object title, int length, bool isEllipsis)
		{
			string text = title.ToString();
			if (text.Length > length)
			{
				text = text.Substring(0, length);
			}
			if (isEllipsis)
			{
				text += "...";
			}
			return text;
		}
	}
}
