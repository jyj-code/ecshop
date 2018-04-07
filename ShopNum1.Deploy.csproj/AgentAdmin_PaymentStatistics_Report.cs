using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class AgentAdmin_PaymentStatistics_Report : PageBase, IRequiresSessionState
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
		if (!this.Page.IsPostBack)
		{
			base.Response.Clear();
			string text = base.Request.QueryString["Type"].ToString();
			if (text == "xls")
			{
				base.Response.ContentEncoding = Encoding.Default;
				base.Response.ContentType = "Application/ms-excel";
			}
			else
			{
				base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
			}
			base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
			{
				"attachment;filename=\"PaymentStatistics_Report_",
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
		else
		{
			base.Response.Write("");
		}
	}
	private void method_5()
	{
		ShopNum1_ExtendOrderStatistics_Action shopNum1_ExtendOrderStatistics_Action = (ShopNum1_ExtendOrderStatistics_Action)LogicFactory.CreateShopNum1_ExtendOrderStatistics_Action();
		DataTable dataTable = shopNum1_ExtendOrderStatistics_Action.SearchPaymentStatistics(base.SubstationID);
		base.Response.Write("<table width=\"100%\" border=\"1\">");
		base.Response.Write("<tr bgcolor=\"#6699cc\">");
		base.Response.Write("<td align=\"center\">排行</td>");
		base.Response.Write("<td align=\"center\">支付方式名称</td>");
		base.Response.Write("<td align=\"center\">使用次数</td>");
		base.Response.Write("<td align=\"center\">使用百分比</td>");
		base.Response.Write("</tr>");
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr>");
				base.Response.Write("<td align=\"center\" width=\"50\" style=\"vnd.ms-excel.numberformat:@\"> {Top}</td>".Replace("{Top}", (i + 1).ToString()));
				base.Response.Write("<td align=\"center\" width=\"200\" style=\"vnd.ms-excel.numberformat:@\"> {PaymentName}</td>".Replace("{PaymentName}", dataTable.Rows[i]["PaymentName"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {PaymentCount}</td>".Replace("{PaymentCount}", dataTable.Rows[i]["PaymentCount"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {Percentage}</td>".Replace("{Percentage}", decimal.Round(decimal.Parse(dataTable.Rows[i]["PaymentCount"].ToString()) * 100m / decimal.Parse(dataTable.Rows[i]["AllCount"].ToString()), 2).ToString() + "%"));
				base.Response.Write("</tr>");
			}
		}
		base.Response.Write("</table>");
	}
}
