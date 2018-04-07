using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class SeeBuyRate_Report : PageBase, IRequiresSessionState
{
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
		if (!this.Page.IsPostBack && this.Page.Request["ProductCategoryCode1"] != null && this.Page.Request["BrandGuid"] != null)
		{
			base.Response.Clear();
			string text = base.Request.QueryString["Type"].ToString();
			if (text == "xls")
			{
				base.Response.Charset = "UTF-8";
				this.Page.Response.ContentEncoding = Encoding.GetEncoding("gbk");
				this.Page.Response.ContentType = "Application/ms-excel";
			}
			else
			{
				base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
			}
			base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
			{
				"attachment;filename=\"SeeBuyRateReport_",
				DateTime.Now.ToString("yyyymmddhhmm"),
				".",
				text,
				"\""
			}));
			this.method_5();
			base.Response.Flush();
			base.Response.Close();
			base.Response.End();
		}
	}
	private void method_5()
	{
		string text = this.Page.Request["ShopPrice1"].ToString();
		string text2 = this.Page.Request["ShopPrice2"].ToString();
		string text3 = this.Page.Request["MarketPrice1"].ToString();
		string text4 = this.Page.Request["MarketPrice2"].ToString();
		ShopNum1_Report_Action shopNum1_Report_Action = (ShopNum1_Report_Action)LogicFactory.CreateShopNum1_Report_Action();
		if (text == "")
		{
			text = "0";
		}
		if (text2 == "")
		{
			text2 = "0";
		}
		if (text3 == "")
		{
			text3 = "0";
		}
		if (text4 == "")
		{
			text4 = "0";
		}
		DataTable dataTable = shopNum1_Report_Action.SearchSeeBuyRate(this.Page.Request["name"].ToString(), this.Page.Request["ProductCategoryCode1"].ToString().Trim(), this.Page.Request["ProductCategoryCode2"].ToString().Trim(), this.Page.Request["ProductCategoryCode3"].ToString().Trim(), this.Page.Request["BrandGuid"].ToString(), Convert.ToDecimal(text), Convert.ToDecimal(text2), Convert.ToDecimal(text3), Convert.ToDecimal(text4));
		base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
		base.Response.Write("<tr bgcolor=\"#6699cc\">");
		base.Response.Write(" <td align=\"center\">商品名称</td>");
		base.Response.Write("<td align=\"center\">商品分类</td>");
		base.Response.Write("<td align=\"center\">品牌分类</td>");
		base.Response.Write("<td align=\"center\">访问量</td>");
		base.Response.Write("<td align=\"center\">销售量</td>");
		base.Response.Write("<td align=\"center\">访问购买率</td>");
		base.Response.Write("</tr>");
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr bgcolor=\"#ffffff\">");
				base.Response.Write("<td align=\"center\" width=\"500\" style=\"vnd.ms-excel.numberformat:@\"> {Name}</td>".Replace("{Name}", dataTable.Rows[i]["Name"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"200\" style=\"vnd.ms-excel.numberformat:@\"> {Ptype}</td>".Replace("{Ptype}", dataTable.Rows[i]["productcategoryname"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {Btype}</td>".Replace("{Btype}", dataTable.Rows[i]["brandname"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"80\"  style=\"vnd.ms-excel.numberformat:@\"> {ClickCount}</td>".Replace("{ClickCount}", dataTable.Rows[i]["ClickCount"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"80\"  style=\"vnd.ms-excel.numberformat:@\"> {SaleNumber}</td>".Replace("{SaleNumber}", dataTable.Rows[i]["SaleNumber"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {BuyRate}</td>".Replace("{BuyRate}", dataTable.Rows[i]["BuyRate"].ToString()));
				base.Response.Write("</tr>");
			}
		}
		base.Response.Write("</table>");
	}
}
