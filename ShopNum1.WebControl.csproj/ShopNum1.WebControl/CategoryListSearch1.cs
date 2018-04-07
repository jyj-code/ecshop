using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CategoryListSearch1 : BaseWebControl
	{
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private DropDownList dropDownList_3;
		private DropDownList dropDownList_4;
		private DropDownList dropDownList_5;
		private DropDownList dropDownList_6;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private Button button_0;
		private Repeater repeater_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private Label label_0;
		private Label label_1;
		private TextBox textBox_4;
		private Button button_1;
		private string string_0 = "CategoryListSearch.ascx";
		private bool bool_0 = false;
		[CompilerGenerated]
		private int int_0;
		public int PageCount
		{
			get;
			set;
		}
		public CategoryListSearch1()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListProvince");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.DropDownListProvince_SelectedIndexChanged);
			this.dropDownList_2 = (DropDownList)skin.FindControl("DropDownListCity");
			this.dropDownList_2.SelectedIndexChanged += new EventHandler(this.DropDownListCity_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListCounty");
			this.dropDownList_3 = (DropDownList)skin.FindControl("DropDownListCategoryCf");
			this.dropDownList_3.SelectedIndexChanged += new EventHandler(this.dropDownList_3_SelectedIndexChanged);
			this.dropDownList_4 = (DropDownList)skin.FindControl("DropDownListCategoryCs");
			this.dropDownList_4.SelectedIndexChanged += new EventHandler(this.dropDownList_4_SelectedIndexChanged);
			this.dropDownList_5 = (DropDownList)skin.FindControl("DropDownListCategoryCt");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxStartTime");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxEndTime");
			this.dropDownList_6 = (DropDownList)skin.FindControl("DropDownListType");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxKeywords");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxTitle");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonFirst");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonLast");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonNext");
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonEnd");
			this.label_0 = (Label)skin.FindControl("LabelPageIndex");
			this.label_1 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxPageNum");
			this.button_1 = (Button)skin.FindControl("ButtonGo");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.button_1.Click += new EventHandler(this.button_1_Click);
			if (this.Page.IsPostBack)
			{
			}
			this.Province();
			this.BindCategoryCf();
			if (this.Page.Request.QueryString["code"] != null && this.Page.Request.QueryString["code"].ToString() != "")
			{
				string text = this.Page.Request.QueryString["code"].ToString();
				if (text.Length >= 3)
				{
					for (int i = 0; i < this.dropDownList_3.Items.Count; i++)
					{
						if (this.dropDownList_3.Items[i].Value.ToString().StartsWith(text.Substring(0, 3) + "/"))
						{
							this.dropDownList_3.SelectedValue = this.dropDownList_3.Items[i].Value.ToString();
                            //IL_3C7:
							this.dropDownList_3_SelectedIndexChanged(null, null);
							goto IL_3CF;
						}
					}
                    //goto IL_3C7;
				}
				IL_3CF:
				if (text.Length >= 6)
				{
					for (int i = 0; i < this.dropDownList_4.Items.Count; i++)
					{
						if (this.dropDownList_4.Items[i].Value.ToString().StartsWith(text.Substring(0, 6) + "/"))
						{
							this.dropDownList_4.SelectedValue = this.dropDownList_4.Items[i].Value.ToString();
                            //IL_459:
							this.dropDownList_4_SelectedIndexChanged(null, null);
							goto IL_461;
						}
					}
                    //goto IL_459;
				}
				IL_461:
				if (text.Length >= 9)
				{
					for (int i = 0; i < this.dropDownList_5.Items.Count; i++)
					{
						if (this.dropDownList_5.Items[i].Value.ToString().StartsWith(text.Substring(0, 9) + "/"))
						{
							this.dropDownList_5.Items[i].Selected = true;
							break;
						}
					}
				}
			}
			this.BindData();
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.label_0.Text = this.textBox_4.Text;
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
		private string method_0(DropDownList dropDownList_7, DropDownList dropDownList_8, DropDownList dropDownList_9)
		{
			string result;
			if (dropDownList_9.SelectedValue != "-1")
			{
				result = dropDownList_9.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else if (dropDownList_8.SelectedValue != "-1")
			{
				result = dropDownList_8.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else if (dropDownList_7.SelectedValue != "-1")
			{
				result = dropDownList_7.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public void BindCategoryCf()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
			DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName("0");
			this.dropDownList_3.Items.Clear();
			this.dropDownList_3.Items.Add(new ListItem("-全部-", "-1"));
			for (int i = 0; i < productCategoryName.Rows.Count; i++)
			{
				this.dropDownList_3.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
			}
			this.dropDownList_3_SelectedIndexChanged(null, null);
		}
		private void dropDownList_3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_4.Items.Clear();
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
			this.dropDownList_4.Items.Add(new ListItem("-全部-", "-1"));
			if (this.dropDownList_3.SelectedValue != "-1")
			{
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_3.SelectedValue.Split(new char[]
				{
					'/'
				})[0]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_4.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
			this.dropDownList_4_SelectedIndexChanged(null, null);
		}
		private void dropDownList_4_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_5.Items.Clear();
			this.dropDownList_5.Items.Add(new ListItem("-全部-", "-1"));
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
			if (this.dropDownList_3.SelectedValue != "-1")
			{
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_4.SelectedValue.Split(new char[]
				{
					'/'
				})[0]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_5.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
		}
		protected void Province()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("--省级--", "-1"));
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
			DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName("0");
			for (int i = 0; i < productCategoryName.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["ID"].ToString() + "/" + productCategoryName.Rows[i]["Code"].ToString()));
			}
			this.DropDownListProvince_SelectedIndexChanged(null, null);
		}
		protected void DropDownListProvince_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Items.Clear();
			this.dropDownList_2.Items.Add(new ListItem("—市级—", "-1"));
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[0]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_2.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["ID"].ToString() + "/" + productCategoryName.Rows[i]["Code"].ToString()));
				}
			}
			this.DropDownListCity_SelectedIndexChanged(null, null);
		}
		protected void DropDownListCity_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_1.Items.Clear();
			this.dropDownList_1.Items.Add(new ListItem("—县级—", "-1"));
			if (this.dropDownList_2.SelectedValue != "-1")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_2.SelectedValue.Split(new char[]
				{
					'/'
				})[0]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_1.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["ID"].ToString() + "/" + productCategoryName.Rows[i]["Code"].ToString()));
				}
			}
		}
		public void BindData()
		{
			string addresscode = this.method_0(this.dropDownList_0, this.dropDownList_2, this.dropDownList_1);
			string associatedcategoryguid;
			if (this.Page.Request.QueryString["code"] != null && !this.bool_0)
			{
				associatedcategoryguid = this.Page.Request.QueryString["code"];
			}
			else
			{
				associatedcategoryguid = this.method_1(this.dropDownList_3, this.dropDownList_4, this.dropDownList_5);
			}
			string createtime = (this.textBox_0.Text == "") ? "-1" : this.textBox_0.Text;
			string createtime2 = (this.textBox_1.Text == "") ? "-1" : this.textBox_1.Text;
			string keywords;
			if (this.Page.Request.QueryString["search"] != null && !this.bool_0)
			{
				keywords = Operator.FilterString(this.Page.Request.QueryString["search"]);
			}
			else
			{
				keywords = Operator.FilterString((this.textBox_2.Text == "") ? "-1" : this.textBox_2.Text);
			}
			string title = (this.textBox_3.Text == "") ? "-1" : this.textBox_3.Text;
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataSet value = new DataSet();
			int num = int.Parse(this.label_0.Text);
			if (this.ViewState["PageData"] == null)
			{
				value = shopNum1_CategoryChecked_Action.Search(num.ToString(), this.PageCount.ToString(), addresscode, associatedcategoryguid, createtime, createtime2, keywords, title);
				this.ViewState["PageData"] = value;
			}
			else if ((num / 10).ToString() != ((DataSet)this.ViewState["PageData"]).Tables[1].Rows[0][0].ToString())
			{
				value = shopNum1_CategoryChecked_Action.Search(num.ToString(), this.PageCount.ToString(), addresscode, associatedcategoryguid, createtime, createtime2, keywords, title);
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
			if (num == int.Parse(this.label_1.Text))
			{
				this.linkButton_2.Enabled = false;
				this.linkButton_3.Enabled = false;
			}
		}
		private string method_1(DropDownList dropDownList_7, DropDownList dropDownList_8, DropDownList dropDownList_9)
		{
			string result;
			if (dropDownList_9.SelectedValue != "-1")
			{
				result = dropDownList_9.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else if (dropDownList_8.SelectedValue != "-1")
			{
				result = dropDownList_8.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else if (dropDownList_7.SelectedValue != "-1")
			{
				result = dropDownList_7.SelectedValue.Split(new char[]
				{
					'/'
				})[1];
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.bool_0 = true;
			this.ViewState["PageData"] = null;
			this.BindData();
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
