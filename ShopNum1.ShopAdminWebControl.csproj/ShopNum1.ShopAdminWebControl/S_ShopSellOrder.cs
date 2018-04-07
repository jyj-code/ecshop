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
	public class S_ShopSellOrder : BaseShopWebControl
	{
		protected const string ShopSellOrder_Report = "S_ShopSellOrder_Report.aspx";
		private string string_0 = "S_ShopSellOrder.ascx";
		private Repeater repeater_0;
		private Button button_0;
		private Button button_1;
		private string string_1;
		private string string_2;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_3;
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
		public S_ShopSellOrder()
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
					if (this.Page.IsPostBack)
					{
					}
					this.button_0 = (Button)skin.FindControl("ButtonReport");
					this.button_0.Click += new EventHandler(this.button_0_Click);
					this.button_1 = (Button)skin.FindControl("ButtonHtml");
					this.button_1.Click += new EventHandler(this.button_1_Click);
					this.BindData();
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = ShopNum1.Common.Common.ReqStr("sd");
			string text2 = ShopNum1.Common.Common.ReqStr("ed");
			string text3 = ShopNum1.Common.Common.ReqStr("pn");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"S_ShopSellOrder_Report.aspx?Type=xls&MemLoginID=",
				this.MemLoginID,
				"&&textBoxTime1=",
				text,
				"&&textBoxTime2=",
				text2,
				"&&ProductName=",
				text3
			}));
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			string text = ShopNum1.Common.Common.ReqStr("sd");
			string text2 = ShopNum1.Common.Common.ReqStr("ed");
			string text3 = ShopNum1.Common.Common.ReqStr("pn");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"S_ShopSellOrder_Report.aspx?Type=html&MemLoginID=",
				this.MemLoginID,
				"&&textBoxTime1=",
				text,
				"&&textBoxTime2=",
				text2,
				"&&ProductName=",
				text3
			}));
		}
		protected void BindData()
		{
			string dispatchTime = ShopNum1.Common.Common.ReqStr("sd");
			string dispatchTime2 = ShopNum1.Common.Common.ReqStr("ed");
			string productName = ShopNum1.Common.Common.ReqStr("pn");
			Shop_Report_Action shop_Report_Action = (Shop_Report_Action)LogicFactory.CreateShop_Report_Action();
			DataTable dataTable = shop_Report_Action.SearchShopSellOrder(this.MemLoginID, dispatchTime, dispatchTime2, productName);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
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
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataSource = pagedDataSource;
				this.repeater_0.DataBind();
			}
		}
		public string returnTextvalue(TextBox textBox)
		{
			string result;
			if (string.IsNullOrEmpty(textBox.Text))
			{
				result = "-1";
			}
			else
			{
				result = Operator.FilterString(textBox.Text);
			}
			return result;
		}
	}
}
