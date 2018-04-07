using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class AgentAdmin_SellOrder_Report : PageBase, IRequiresSessionState
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
		if (!this.Page.IsPostBack && this.Page.Request["DispatchTime1"] != null && this.Page.Request["DispatchTime2"] != null)
		{
			base.Response.Clear();
			string text = base.Request.QueryString["Type"].ToString();
			if (text == "xls")
			{
				base.Response.Charset = "UTF-8";
				base.Response.ContentEncoding = Encoding.GetEncoding("gbk");
				base.Response.ContentType = "Application/ms-excel";
			}
			else
			{
				base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
			}
			base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
			{
				"attachment;filename=\"SellOrderReport_",
				DateTime.Now.ToString("yyyymmddhhmm"),
				".",
				text,
				"\""
			}));
			int num = this.method_5();
			if (num == 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\">");
				base.Response.Write("<tr bgcolor=\"#6699cc\">");
				base.Response.Write(" <td align=\"center\">当前没有数据导出！</td>");
				base.Response.Write("</tr>");
				base.Response.Write("</table>");
			}
			base.Response.Flush();
			base.Response.Close();
			base.Response.End();
		}
	}
	private int method_5()
	{
		ShopNum1_Report_Action shopNum1_Report_Action = (ShopNum1_Report_Action)LogicFactory.CreateShopNum1_Report_Action();
		DataTable dataTable = shopNum1_Report_Action.SearchSellOrder(this.Page.Request.QueryString["pname"].ToString(), this.Page.Request.QueryString["sname"].ToString(), this.Page.Request.QueryString["DispatchTime1"].ToString(), this.Page.Request.QueryString["DispatchTime2"].ToString(), base.SubstationID);
		int result = 1;
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			base.Response.Write("<table width=\"100%\" border=\"1\">");
			base.Response.Write("<tr bgcolor=\"#6699cc\">");
			base.Response.Write(" <td align=\"center\">商品名称</td>");
			base.Response.Write("<td align=\"center\">商铺名称</td>");
			base.Response.Write("<td align=\"center\">货号</td>");
			base.Response.Write("<td align=\"center\">销售数量</td>");
			base.Response.Write("<td align=\"center\">销售额</td>");
			base.Response.Write("<td align=\"center\">均价</td>");
			base.Response.Write("<td align=\"center\">邮费</td>");
			base.Response.Write("</tr>");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr>");
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {ProductName}</td>".Replace("{ProductName}", dataTable.Rows[i]["ProductName"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {ShopName}</td>".Replace("{ShopName}", dataTable.Rows[i]["ShopName"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {RepertoryNumber}</td>".Replace("{RepertoryNumber}", dataTable.Rows[i]["RepertoryNumber"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {BuyNumber}</td>".Replace("{BuyNumber}", dataTable.Rows[i]["BuyNumber"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {BuyPrice}</td>".Replace("{BuyPrice}", dataTable.Rows[i]["BuyPrice"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {AveragePrice}</td>".Replace("{AveragePrice}", dataTable.Rows[i]["AveragePrice"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {FeePay}</td>".Replace("{FeePay}", dataTable.Rows[i]["dispatchprice"].ToString()));
				base.Response.Write("</tr>");
			}
			base.Response.Write("</table>");
		}
		else
		{
			result = 0;
		}
		return result;
	}
}
