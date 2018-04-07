using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_SeeBuyRate_Report : BaseShopWebControl
	{
		private string string_0 = "S_SeeBuyRate_Report.ascx";
		public S_SeeBuyRate_Report()
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
					return;
				}
			}
			if (!this.Page.IsPostBack && this.Page.Request["MemLoginID"] != null && this.Page.Request["SaleNumber1"] != null && this.Page.Request["SaleNumber1"] != null && this.Page.Request["ClickCount1"] != null && this.Page.Request["ClickCount1"] != null)
			{
				this.Page.Response.Clear();
				string text = this.Page.Request.QueryString["Type"].ToString();
				if (text == "xls")
				{
					this.Page.Response.Charset = "UTF-8";
					this.Page.Response.ContentEncoding = Encoding.GetEncoding("gbk");
					this.Page.Response.ContentType = "Application/ms-excel";
				}
				else
				{
					this.Page.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
				}
				this.Page.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
				{
					"attachment;filename=\"SellBuyRate_Report",
					DateTime.Now.ToString("yyyymmddhhmm"),
					".",
					text,
					"\""
				}));
				this.method_0();
				this.Page.Response.Flush();
				this.Page.Response.Close();
				this.Page.Response.End();
			}
		}
		private void method_0()
		{
			string shopID = this.Page.Request["MemLoginID"].ToString();
			string saleNumber = this.Page.Request["SaleNumber1"].ToString();
			string saleNumber2 = this.Page.Request["SaleNumber2"].ToString();
			string clickCount = this.Page.Request["ClickCount1"].ToString();
			string clickCount2 = this.Page.Request["ClickCount2"].ToString();
			string productName = this.Page.Request["ProductName"].ToString();
			Shop_Report_Action shop_Report_Action = (Shop_Report_Action)LogicFactory.CreateShop_Report_Action();
			DataTable dataTable = shop_Report_Action.SearchClickCount(shopID, saleNumber, saleNumber2, clickCount, clickCount2, productName);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.Page.Response.Write("<table width=\"100%\">");
				this.Page.Response.Write("<tr bgcolor=\"#6699cc\">");
				this.Page.Response.Write(" <td style=\"text-align:center;\">商品名称</td>");
				this.Page.Response.Write("<td style=\"text-align:center;\">货号</td>");
				this.Page.Response.Write("<td style=\"text-align:center;\">访问量</td>");
				this.Page.Response.Write("<td style=\"text-align:center;\">销售量</td>");
				this.Page.Response.Write("<td style=\"text-align:center;\">访问购买率</td>");
				this.Page.Response.Write("<tr>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.Page.Response.Write("<tr>");
					this.Page.Response.Write("<td align=\"center\" width=\"300\"> {Name}</td>".Replace("{Name}", dataTable.Rows[i]["Name"].ToString()));
					this.Page.Response.Write("<td width=\"150\" align=\"center\"> {ProductNum}</td>".Replace("{ProductNum}", "_" + dataTable.Rows[i]["ProductNum"].ToString()));
					this.Page.Response.Write("<td width=\"100\" align=\"center\"> {ClickCount}</td>".Replace("{ClickCount}", dataTable.Rows[i]["ClickCount"].ToString()));
					this.Page.Response.Write("<td width=\"100\" align=\"center\"> {SaleNumber}</td>".Replace("{SaleNumber}", dataTable.Rows[i]["SaleNumber"].ToString()));
					this.Page.Response.Write("<td width=\"100\" align=\"center\"> {BuyRate}</td>".Replace("{BuyRate}", dataTable.Rows[i]["BuyRate"].ToString()));
					this.Page.Response.Write("</tr>");
				}
				this.Page.Response.Write("</table>");
			}
		}
	}
}
