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
	public class S_ShopSellOrder_Report : BaseShopWebControl
	{
		private string string_0 = "S_ShopSellOrder_Report.ascx";
		public S_ShopSellOrder_Report()
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
			if (!this.Page.IsPostBack && this.Page.Request["MemLoginID"] != null && this.Page.Request["textBoxTime1"] != null && this.Page.Request["textBoxTime2"] != null)
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
					"attachment;filename=\"ShopSellOrder_Report",
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
			string memLoginID = this.Page.Request["MemLoginID"].ToString();
			string dispatchTime = this.Page.Request["textBoxTime1"].ToString();
			string dispatchTime2 = this.Page.Request["textBoxTime2"].ToString();
			string productName = this.Page.Request["ProductName"].ToString();
			Shop_Report_Action shop_Report_Action = (Shop_Report_Action)LogicFactory.CreateShop_Report_Action();
			DataTable dataTable = shop_Report_Action.SearchShopSellOrder(memLoginID, dispatchTime, dispatchTime2, productName);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.Page.Response.Write("<table width=\"100%\">");
				this.Page.Response.Write("<tr bgcolor=\"#6699cc\">");
				this.Page.Response.Write(" <td>商品名称</td>");
				this.Page.Response.Write("<td>货号</td>");
				this.Page.Response.Write("<td>销售数量</td>");
				this.Page.Response.Write("<td>销售额</td>");
				this.Page.Response.Write("<td>均价</td>");
				this.Page.Response.Write("<tr>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.Page.Response.Write("<tr>");
					this.Page.Response.Write("<td width=\"100\" align=\"center\"> {ProductName}</td>".Replace("{ProductName}", dataTable.Rows[i]["ProductName"].ToString()));
					this.Page.Response.Write("<td width=\"100\" align=\"center\"> {RepertoryNumber}</td>".Replace("{RepertoryNumber}", dataTable.Rows[i]["RepertoryNumber"].ToString()));
					this.Page.Response.Write("<td width=\"100\" align=\"center\"> {BuyNumber}</td>".Replace("{BuyNumber}", dataTable.Rows[i]["BuyNumber"].ToString()));
					this.Page.Response.Write("<td width=\"100\" align=\"center\"> {BuyPrice}</td>".Replace("{BuyPrice}", dataTable.Rows[i]["BuyPrice"].ToString()));
					this.Page.Response.Write("<td width=\"100\" align=\"center\"> {AveragePrice}</td>".Replace("{AveragePrice}", dataTable.Rows[i]["AveragePrice"].ToString()));
					this.Page.Response.Write("</tr>");
				}
				this.Page.Response.Write("</table>");
			}
		}
	}
}
