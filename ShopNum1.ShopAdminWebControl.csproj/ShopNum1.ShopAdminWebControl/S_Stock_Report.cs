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
	public class S_Stock_Report : BaseShopWebControl
	{
		private string string_0 = "S_Stock_Report.ascx";
		public S_Stock_Report()
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
					return;
				}
			}
			if (!this.Page.IsPostBack && this.Page.Request["ProductCategoryCode"] != null && this.Page.Request["SaleNumber1"] != null && this.Page.Request["SaleNumber2"] != null && this.Page.Request["RepertoryCount1"] != null && this.Page.Request["RepertoryCount2"] != null)
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
					"attachment;filename=\"StockReport_",
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
			string saleNumber = this.Page.Request["SaleNumber1"].ToString();
			string saleNumber2 = this.Page.Request["SaleNumber2"].ToString();
			string repertoryCount = this.Page.Request["RepertoryCount1"].ToString();
			string repertoryCount2 = this.Page.Request["RepertoryCount2"].ToString();
			string productname = this.Page.Request["productname"].ToString();
			string memLoginID = this.Page.Request["MemLoginID"].ToString();
			Shop_Report_Action shop_Report_Action = (Shop_Report_Action)LogicFactory.CreateShop_Report_Action();
			DataTable dataTable = shop_Report_Action.Search(memLoginID, this.Page.Request["ProductCategoryCode"].ToString(), saleNumber, saleNumber2, repertoryCount, repertoryCount2, productname);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.Page.Response.Write("<table width=\"100%\">");
				this.Page.Response.Write("<tr bgcolor=\"#6699cc\" style=\"text-align:center;\">");
				this.Page.Response.Write(" <td  style=\"text-align:center;\">商品名称</td>");
				this.Page.Response.Write(" <td  style=\"text-align:center;\">所属分类</td>");
				this.Page.Response.Write("<td  style=\"text-align:center;\">货号</td>");
				this.Page.Response.Write("<td  style=\"text-align:center;\">已销售量</td>");
				this.Page.Response.Write("<td  style=\"text-align:center;\">剩余库存量</td>");
				this.Page.Response.Write("<tr  style=\"text-align:center;\">");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.Page.Response.Write("<tr>");
					this.Page.Response.Write("<td align=\"center\" width=\"300\"> {Name}</td>".Replace("{Name}", dataTable.Rows[i]["Name"].ToString()));
					this.Page.Response.Write("<td align=\"center\" width=\"150\"> {ProductSeriesName}</td>".Replace("{ProductSeriesName}", dataTable.Rows[i]["ProductSeriesName"].ToString()));
					if (dataTable.Rows[i]["ProductNum"].ToString().Trim() != "")
					{
						this.Page.Response.Write("<td align=\"center\" width=\"200\"> {ProductNum}</td>".Replace("{ProductNum}", "_" + dataTable.Rows[i]["ProductNum"].ToString()));
					}
					else
					{
						this.Page.Response.Write("<td align=\"center\" width=\"200\"> {ProductNum}</td>".Replace("{ProductNum}", dataTable.Rows[i]["ProductNum"].ToString() ?? ""));
					}
					this.Page.Response.Write("<td align=\"center\" width=\"100\"> {SaleNumber}</td>".Replace("{SaleNumber}", dataTable.Rows[i]["SaleNumber"].ToString()));
					this.Page.Response.Write("<td align=\"center\" width=\"100\"> {RepertoryCount}</td>".Replace("{RepertoryCount}", dataTable.Rows[i]["RepertoryCount"].ToString()));
					this.Page.Response.Write("</tr>");
				}
				this.Page.Response.Write("</table>");
			}
		}
	}
}
