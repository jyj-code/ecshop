using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopLocalization;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_StockReport : BaseShopWebControl
	{
		protected const string Stock_Report = "S_Stock_Report.aspx";
		private string string_0 = "S_StockReport.ascx";
		protected string strSapce = "\u3000\u3000";
		private Repeater repeater_0;
		private DropDownList dropDownList_0;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private Button button_0;
		private Button button_1;
		private Button button_2;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		public int ShowCount
		{
			get;
			set;
		}
		public new string MemLoginID
		{
			get;
			set;
		}
		public S_StockReport()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectTopLogin();
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				string a = httpCookie.Values["MemberType"].ToString();
				if (a != "2")
				{
					GetUrl.RedirectTopLogin();
				}
				else
				{
					this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
					this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
					this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
					this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
					this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
					this.label_0 = (Label)skin.FindControl("LabelPageMessage");
					this.literal_0 = (Literal)skin.FindControl("lnkTo");
					this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
					if (this.Page.IsPostBack)
					{
					}
					this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListProductCategoryID");
					this.textBox_0 = (TextBox)skin.FindControl("TextBoxSaleNumber1");
					this.textBox_1 = (TextBox)skin.FindControl("TextBoxSaleNumber2");
					this.textBox_2 = (TextBox)skin.FindControl("TextBoxRepertoryCount1");
					this.textBox_3 = (TextBox)skin.FindControl("TextBoxRepertoryCount2");
					this.textBox_4 = (TextBox)skin.FindControl("TextBoxProductName");
					this.button_0 = (Button)skin.FindControl("ButtonSearch");
					this.button_0.Click += new EventHandler(this.button_0_Click);
					this.button_1 = (Button)skin.FindControl("ButtonReport");
					this.button_1.Click += new EventHandler(this.button_1_Click);
					this.button_2 = (Button)skin.FindControl("ButtonHtml");
					this.button_2.Click += new EventHandler(this.button_2_Click);
					this.BindProductCategory();
					this.BindData();
				}
			}
		}
		protected void BindProductCategory()
		{
			ListItem listItem = new ListItem();
			listItem.Text = LocalizationUtil.GetCommonMessage("All");
			listItem.Value = "-1";
			this.dropDownList_0.Items.Add(listItem);
			Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
			shop_ProductCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";
			DataView defaultView = shop_ProductCategory_Action.GetShopProductCategoryCode("0", this.MemLoginID).DefaultView;
			foreach (DataRow dataRow in defaultView.Table.Rows)
			{
				ListItem listItem2 = new ListItem();
				listItem2.Text = dataRow["Name"].ToString().Trim();
				listItem2.Value = dataRow["Code"].ToString().Trim();
				this.dropDownList_0.Items.Add(listItem2);
				DataTable dataTable = shop_ProductCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), this.MemLoginID);
				if (dataTable.Rows.Count > 0)
				{
					this.AddSubProductCategory(dataTable);
				}
			}
		}
		protected void AddSubProductCategory(DataTable dataTable)
		{
			Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
			foreach (DataRow dataRow in dataTable.Rows)
			{
				ListItem listItem = new ListItem();
				string text = string.Empty;
				for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
				{
					text += this.strSapce;
				}
				text += dataRow["Name"].ToString().Trim();
				listItem.Text = text;
				listItem.Value = dataRow["Code"].ToString().Trim();
				this.dropDownList_0.Items.Add(listItem);
				DataTable dataTable2 = shop_ProductCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), this.MemLoginID);
				if (dataTable2.Rows.Count > 0)
				{
					this.AddSubProductCategory(dataTable2);
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.BindData();
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			string text = this.dropDownList_0.SelectedItem.Value.Trim().ToString();
			string text2 = (this.textBox_0.Text.Trim().ToString() == "") ? "-1" : this.textBox_0.Text.Trim();
			string text3 = (this.textBox_1.Text.Trim().ToString() == "") ? "-1" : this.textBox_1.Text.Trim();
			string text4 = (this.textBox_2.Text.Trim().ToString() == "") ? "-1" : this.textBox_2.Text.Trim();
			string text5 = (this.textBox_3.Text.Trim().ToString() == "") ? "-1" : this.textBox_3.Text.Trim();
			string text6 = (this.textBox_4.Text.Trim() == "") ? "-1" : this.textBox_4.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"S_Stock_Report.aspx?Type=xls&MemLoginID=",
				this.MemLoginID,
				"&productCategoryCode=",
				text,
				"&SaleNumber1=",
				text2,
				"&SaleNumber2=",
				text3,
				"&RepertoryCount1=",
				text4,
				"&RepertoryCount2=",
				text5,
				"&productname=",
				text6
			}));
		}
		private void button_2_Click(object sender, EventArgs e)
		{
			string text = this.dropDownList_0.SelectedItem.Value.Trim().ToString();
			string text2 = (this.textBox_0.Text.Trim().ToString() == "") ? "-1" : this.textBox_0.Text.Trim();
			string text3 = (this.textBox_1.Text.Trim().ToString() == "") ? "-1" : this.textBox_1.Text.Trim();
			string text4 = (this.textBox_2.Text.Trim().ToString() == "") ? "-1" : this.textBox_2.Text.Trim();
			string text5 = (this.textBox_3.Text.Trim().ToString() == "") ? "-1" : this.textBox_3.Text.Trim();
			string text6 = (this.textBox_4.Text.Trim() == "") ? "-1" : this.textBox_4.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"S_Stock_Report.aspx?Type=html&MemLoginID=",
				this.MemLoginID,
				"&ProductCategoryCode=",
				text,
				"&SaleNumber1=",
				text2,
				"&SaleNumber2=",
				text3,
				"&RepertoryCount1=",
				text4,
				"&RepertoryCount2=",
				text5,
				"&productname=",
				text6
			}));
		}
		protected void BindData()
		{
			string productSeriesCode = this.dropDownList_0.SelectedItem.Value.Trim().ToString();
			string saleNumber = (this.textBox_0.Text.Trim().ToString() == "") ? "-1" : this.textBox_0.Text.Trim();
			string saleNumber2 = (this.textBox_1.Text.Trim().ToString() == "") ? "-1" : this.textBox_1.Text.Trim();
			string repertoryCount = (this.textBox_2.Text.Trim().ToString() == "") ? "-1" : this.textBox_2.Text.Trim();
			string repertoryCount2 = (this.textBox_3.Text.Trim().ToString() == "") ? "-1" : this.textBox_3.Text.Trim();
			string productname = (this.textBox_4.Text.Trim() == "") ? "-1" : this.textBox_4.Text.Trim();
			Shop_Report_Action shop_Report_Action = (Shop_Report_Action)LogicFactory.CreateShop_Report_Action();
			DataTable dataTable = shop_Report_Action.Search(this.MemLoginID, productSeriesCode, saleNumber, saleNumber2, repertoryCount, repertoryCount2, productname);
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			if (this.ShowCount < 1)
			{
				pagedDataSource.PageSize = 10;
			}
			else
			{
				pagedDataSource.PageSize = this.ShowCount;
			}
			int num;
			if (this.Page.Request.QueryString.Get("page") != null)
			{
				num = Convert.ToInt32(this.Page.Request.QueryString.Get("page"));
			}
			else
			{
				num = 1;
			}
			pagedDataSource.CurrentPageIndex = num - 1;
			Num1WebControlCommon num1WebControlCommon = new Num1WebControlCommon();
			this.label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num);
			this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num);
			this.hyperLink_0.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(num - 1);
			this.hyperLink_1.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=1";
			this.hyperLink_2.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(num + 1);
			this.hyperLink_3.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + pagedDataSource.PageCount;
			if (num <= 1 && pagedDataSource.PageCount <= 1)
			{
				this.hyperLink_1.NavigateUrl = "";
				this.hyperLink_0.NavigateUrl = "";
				this.hyperLink_2.NavigateUrl = "";
				this.hyperLink_3.NavigateUrl = "";
			}
			if (num <= 1 && pagedDataSource.PageCount > 1)
			{
				this.hyperLink_1.NavigateUrl = "";
				this.hyperLink_0.NavigateUrl = "";
			}
			if (num >= pagedDataSource.PageCount)
			{
				this.hyperLink_2.NavigateUrl = "";
				this.hyperLink_3.NavigateUrl = "";
			}
			this.repeater_0.DataSource = pagedDataSource;
			this.repeater_0.DataBind();
		}
	}
}
