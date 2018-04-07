using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_SeeBuyRate : BaseShopWebControl
	{
		protected const string SeeBuyRate_Report = "S_SeeBuyRate_Report.aspx";
		private string string_0 = "S_SeeBuyRate.ascx";
		private Repeater repeater_0;
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
		public S_SeeBuyRate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
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
					this.textBox_0 = (TextBox)skin.FindControl("TextBoxSaleNumber1");
					this.textBox_1 = (TextBox)skin.FindControl("TextBoxSaleNumber2");
					this.textBox_2 = (TextBox)skin.FindControl("TextBoxClickCount1");
					this.textBox_3 = (TextBox)skin.FindControl("TextBoxClickCount2");
					this.textBox_4 = (TextBox)skin.FindControl("TextBoxProductName");
					if (this.Page.IsPostBack)
					{
					}
					this.button_0 = (Button)skin.FindControl("ButtonSearch");
					this.button_0.Click += new EventHandler(this.button_0_Click);
					this.button_1 = (Button)skin.FindControl("ButtonReport");
					this.button_1.Click += new EventHandler(this.button_1_Click);
					this.button_2 = (Button)skin.FindControl("ButtonHtml");
					this.button_2.Click += new EventHandler(this.button_2_Click);
					this.BindData();
				}
			}
		}
		protected void BindData()
		{
			string saleNumber = (this.textBox_0.Text.Trim() == "") ? "-1" : this.textBox_0.Text;
			string saleNumber2 = (this.textBox_1.Text.Trim() == "") ? "-1" : this.textBox_1.Text;
			string clickCount = (this.textBox_2.Text.Trim() == "") ? "-1" : this.textBox_2.Text;
			string clickCount2 = (this.textBox_3.Text.Trim() == "") ? "-1" : this.textBox_3.Text;
			string productName = (this.textBox_4.Text.Trim() == "") ? "-1" : this.textBox_4.Text;
			Shop_Report_Action shop_Report_Action = (Shop_Report_Action)LogicFactory.CreateShop_Report_Action();
			DataTable dataTable = shop_Report_Action.SearchClickCount(this.MemLoginID, saleNumber, saleNumber2, clickCount, clickCount2, productName);
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
		private void button_0_Click(object sender, EventArgs e)
		{
			this.BindData();
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			string text = (this.textBox_0.Text.Trim() == "") ? "-1" : this.textBox_0.Text;
			string text2 = (this.textBox_1.Text.Trim() == "") ? "-1" : this.textBox_1.Text;
			string text3 = (this.textBox_2.Text.Trim() == "") ? "-1" : this.textBox_2.Text;
			string text4 = (this.textBox_3.Text.Trim() == "") ? "-1" : this.textBox_3.Text;
			string text5 = (this.textBox_4.Text.Trim() == "") ? "-1" : this.textBox_4.Text;
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"S_SeeBuyRate_Report.aspx?Type=xls&MemLoginID=",
				this.MemLoginID,
				"&&SaleNumber1=",
				text,
				"&&SaleNumber2=",
				text2,
				"&&ClickCount1=",
				text3,
				"&&ClickCount2=",
				text4,
				"&&ProductName=",
				text5
			}));
		}
		private void button_2_Click(object sender, EventArgs e)
		{
			string text = (this.textBox_0.Text.Trim() == "") ? "-1" : this.textBox_0.Text;
			string text2 = (this.textBox_1.Text.Trim() == "") ? "-1" : this.textBox_1.Text;
			string text3 = (this.textBox_2.Text.Trim() == "") ? "-1" : this.textBox_2.Text;
			string text4 = (this.textBox_3.Text.Trim() == "") ? "-1" : this.textBox_3.Text;
			string text5 = (this.textBox_4.Text.Trim() == "") ? "-1" : this.textBox_4.Text;
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"S_SeeBuyRate_Report.aspx?Type=html&MemLoginID=",
				this.MemLoginID,
				"&&SaleNumber1=",
				text,
				"&&SaleNumber2=",
				text2,
				"&&ClickCount1=",
				text3,
				"&&ClickCount2=",
				text4,
				"&&ProductName=",
				text5
			}));
		}
	}
}
