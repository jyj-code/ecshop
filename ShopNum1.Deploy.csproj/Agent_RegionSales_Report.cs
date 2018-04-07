using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class Agent_RegionSales_Report : PageBase, IRequiresSessionState
{
	[CompilerGenerated]
	private string string_5;
	[CompilerGenerated]
	private string string_6;
	[CompilerGenerated]
	private string string_7;
	public string starttime
	{
		get;
		set;
	}
	public string endtime
	{
		get;
		set;
	}
	public string regioncode
	{
		get;
		set;
	}
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
			this.starttime = ((base.Request.QueryString["DispatchTime1"].ToString() == "") ? "-1" : base.Request.QueryString["DispatchTime1"].ToString());
			this.endtime = ((base.Request.QueryString["DispatchTime2"].ToString() == "") ? "-1" : base.Request.QueryString["DispatchTime2"].ToString());
			this.regioncode = ((base.Request.QueryString["acode"].ToString() == "") ? "-1" : base.Request.QueryString["acode"].ToString());
			this.method_5(this.starttime, this.endtime, this.regioncode);
			base.Response.Flush();
			base.Response.Close();
			base.Response.End();
		}
		else
		{
			base.Response.Write("");
		}
	}
	private void method_5(string string_8, string string_9, string string_10)
	{
		ShopNum1_Report_Action shopNum1_Report_Action = (ShopNum1_Report_Action)LogicFactory.CreateShopNum1_Report_Action();
		DataTable dataTable = shopNum1_Report_Action.SearchRegionSales(string_8, string_9, string_10);
		base.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html><head></head><body>");
		base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
		base.Response.Write("<tr bgcolor=\"#6699cc\">");
		base.Response.Write("<td align=\"center\">省份</td>");
		base.Response.Write("<td align=\"center\">订单量</td>");
		base.Response.Write("<td align=\"center\">销售额</td>");
		base.Response.Write("</tr>");
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr bgcolor=\"#ffffff\">");
				base.Response.Write("<td align=\"center\" width=\"200\"> {AddressValue}</td>".Replace("{AddressValue}", dataTable.Rows[i]["AddressValue"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\"> {numCount}</td>".Replace("{numCount}", dataTable.Rows[i]["numCount"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\"> {moneyCount}</td>".Replace("{moneyCount}", dataTable.Rows[i]["moneyCount"].ToString()));
				base.Response.Write("</tr>");
			}
		}
		base.Response.Write("</table></body></html>");
	}
}
