using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ArticleListSearch : BaseWebControl
	{
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Label label_0;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private Button button_0;
		private Repeater repeater_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private Label label_1;
		private Label label_2;
		private TextBox textBox_4;
		private Button button_1;
		private string string_0 = "ArticleListSearch.ascx";
		private int int_0 = 20;
		private bool bool_0 = false;
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
		public ArticleListSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListArticleCategoryCf");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListArticleCategoryCs");
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.dropDownList_1_SelectedIndexChanged);
			this.dropDownList_2 = (DropDownList)skin.FindControl("DropDownListArticleCt");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxStartTime");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxEndTime");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxKeywords");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.label_0 = (Label)skin.FindControl("LabelArticleProductName");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonFirst");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonLast");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonNext");
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonEnd");
			this.label_1 = (Label)skin.FindControl("LabelPageIndex");
			this.label_2 = (Label)skin.FindControl("LabelPageCount");
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
			this.BindCategoryCf();
			if (this.Page.Request.QueryString["ID"] != null && this.Page.Request.QueryString["ID"].ToString() != "")
			{
				string text = this.Page.Request.QueryString["ID"].ToString();
				DataTable articleInfo = this.GetArticleInfo(text);
				if (articleInfo != null && articleInfo.Rows.Count > 0)
				{
					if (articleInfo.Rows[0]["CategoryLevel"].ToString() == "1")
					{
						this.dropDownList_0.SelectedValue = text;
					}
					else if (articleInfo.Rows[0]["CategoryLevel"].ToString() == "2")
					{
						this.dropDownList_0.SelectedValue = this.GetArticleInfo(articleInfo.Rows[0]["FatherID"].ToString()).Rows[0]["ID"].ToString();
						this.dropDownList_0_SelectedIndexChanged(null, null);
						this.dropDownList_1.SelectedValue = text;
					}
					else if (articleInfo.Rows[0]["CategoryLevel"].ToString() == "3")
					{
						DataTable articleInfo2 = this.GetArticleInfo(articleInfo.Rows[0]["FatherID"].ToString());
						this.dropDownList_0.SelectedValue = this.GetArticleInfo(articleInfo2.Rows[0]["FatherID"].ToString()).Rows[0]["ID"].ToString();
						this.dropDownList_0_SelectedIndexChanged(null, null);
						this.dropDownList_1.SelectedValue = this.GetArticleInfo(articleInfo.Rows[0]["FatherID"].ToString()).Rows[0]["ID"].ToString();
						this.dropDownList_1_SelectedIndexChanged(null, null);
						this.dropDownList_2.SelectedValue = text;
					}
				}
			}
			this.BindData();
			this.label_0.Text = ((this.GetArticleCategoryName() == "-1") ? "全部" : this.GetArticleCategoryName());
		}
		protected DataTable GetArticleInfo(string newid)
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			return shopNum1_ArticleCategory_Action.GetArticleInfoByID(newid);
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.label_1.Text = this.textBox_4.Text;
			this.BindData();
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.label_1.Text = this.label_2.Text;
			this.BindData();
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.label_1.Text = (int.Parse(this.label_1.Text) + 1).ToString();
			this.BindData();
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.label_1.Text = (int.Parse(this.label_1.Text) - 1).ToString();
			this.BindData();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.label_1.Text = "1";
			this.BindData();
		}
		public void BindCategoryCf()
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			DataTable articleCategory = shopNum1_ArticleCategory_Action.GetArticleCategory("0");
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
			for (int i = 0; i < articleCategory.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(articleCategory.Rows[i]["Name"].ToString(), articleCategory.Rows[i]["ID"].ToString()));
			}
			this.dropDownList_0_SelectedIndexChanged(null, null);
		}
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_1.Items.Clear();
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			this.dropDownList_1.Items.Add(new ListItem("-请选择-", "-1"));
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				DataTable articleCategory = shopNum1_ArticleCategory_Action.GetArticleCategory(this.dropDownList_0.SelectedValue);
				for (int i = 0; i < articleCategory.Rows.Count; i++)
				{
					this.dropDownList_1.Items.Add(new ListItem(articleCategory.Rows[i]["Name"].ToString(), articleCategory.Rows[i]["ID"].ToString()));
				}
			}
			this.dropDownList_1_SelectedIndexChanged(null, null);
		}
		private void dropDownList_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Items.Clear();
			this.dropDownList_2.Items.Add(new ListItem("-请选择-", "-1"));
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				DataTable articleCategory = shopNum1_ArticleCategory_Action.GetArticleCategory(this.dropDownList_1.SelectedValue);
				for (int i = 0; i < articleCategory.Rows.Count; i++)
				{
					this.dropDownList_2.Items.Add(new ListItem(articleCategory.Rows[i]["Name"].ToString(), articleCategory.Rows[i]["ID"].ToString()));
				}
			}
		}
		public void BindData()
		{
			string addresscode = "-1";
			string articlecategory;
			if (this.Page.Request.QueryString["ID"] != null && !this.bool_0)
			{
				articlecategory = this.Page.Request.QueryString["ID"];
			}
			else
			{
				articlecategory = this.method_0(this.dropDownList_0, this.dropDownList_1, this.dropDownList_2);
			}
			string text = (this.textBox_0.Text == "") ? "-1" : this.textBox_0.Text;
			string text2 = (this.textBox_1.Text == "") ? "-1" : this.textBox_1.Text;
			try
			{
				if (text != "-1")
				{
					Convert.ToDateTime(text);
				}
				if (text2 != "-1")
				{
					Convert.ToDateTime(text);
				}
			}
			catch
			{
				text = "-1";
				text2 = "-1";
			}
			string title = (this.textBox_2.Text == "") ? "-1" : this.textBox_2.Text;
			string keywords;
			if (this.Page.Request.QueryString["search"] != null && !this.bool_0)
			{
				keywords = Operator.FilterString(this.Page.Request.QueryString["search"]);
			}
			else
			{
				keywords = this.textBox_3.Text.Trim().ToString();
			}
			ShopNum1_ArticleCheck_Action shopNum1_ArticleCheck_Action = (ShopNum1_ArticleCheck_Action)LogicFactory.CreateShopNum1_ArticleCheck_Action();
			DataSet value = new DataSet();
			int num = int.Parse(this.label_1.Text);
			if (this.ViewState["PageData"] == null)
			{
				value = shopNum1_ArticleCheck_Action.Search(num.ToString(), this.int_0.ToString(), addresscode, articlecategory, text, text2, keywords, title);
				this.ViewState["PageData"] = value;
			}
			else if ((num / 10).ToString() != ((DataSet)this.ViewState["PageData"]).Tables[1].Rows[0][0].ToString())
			{
				value = shopNum1_ArticleCheck_Action.Search(num.ToString(), this.int_0.ToString(), addresscode, articlecategory, text, text2, keywords, title);
				this.ViewState["PageData"] = value;
			}
			this.label_2.Text = ((((DataSet)this.ViewState["PageData"]).Tables[2].Rows[0][0].ToString() == "0") ? "1" : ((DataSet)this.ViewState["PageData"]).Tables[2].Rows[0][0].ToString());
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
			if (num == int.Parse(this.label_2.Text))
			{
				this.linkButton_2.Enabled = false;
				this.linkButton_3.Enabled = false;
			}
		}
		private string method_0(DropDownList dropDownList_3, DropDownList dropDownList_4, DropDownList dropDownList_5)
		{
			string result;
			if (dropDownList_5.SelectedValue != "-1")
			{
				result = dropDownList_5.SelectedValue;
			}
			else if (dropDownList_4.SelectedValue != "-1")
			{
				result = dropDownList_4.SelectedValue;
			}
			else if (dropDownList_3.SelectedValue != "-1")
			{
				result = dropDownList_3.SelectedValue;
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		public string GetArticleCategoryName()
		{
			string result;
			if (this.dropDownList_2.SelectedValue != "-1")
			{
				result = this.dropDownList_2.SelectedItem.Text;
			}
			else if (this.dropDownList_1.SelectedValue != "-1")
			{
				result = this.dropDownList_1.SelectedItem.Text;
			}
			else if (this.dropDownList_0.SelectedValue != "-1")
			{
				result = this.dropDownList_0.SelectedItem.Text;
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
			this.label_0.Text = ((this.GetArticleCategoryName() == "-1") ? "全部" : this.GetArticleCategoryName());
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
