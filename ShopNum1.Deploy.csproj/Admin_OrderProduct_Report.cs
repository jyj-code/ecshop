using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class Admin_OrderProduct_Report : PageBase, IRequiresSessionState
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
				base.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
				base.Response.ContentType = "Application/ms-excel";
			}
			else
			{
				base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
			}
			base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
			{
				"attachment;filename=\"OrderProductReport_",
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
		ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
		string startdate = (this.Page.Request.QueryString["DispatchTime1"].ToString() == "") ? "-1" : this.Page.Request.QueryString["DispatchTime1"].ToString();
		string enddate = (this.Page.Request.QueryString["DispatchTime2"].ToString() == "") ? "-1" : this.Page.Request.QueryString["DispatchTime2"].ToString();
		string shopname = (this.Page.Request.QueryString["ShopName"].ToString() == "") ? "-1" : this.Page.Request.QueryString["ShopName"].ToString();
		DataTable dataTable = shopNum1_OrderProduct_Action.SearchOrderProduct(this.Page.Request.QueryString["oname"].ToString(), this.Page.Request.QueryString["pname"].ToString(), shopname, startdate, enddate);
		base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" >");
		base.Response.Write("<tr bgcolor=\"#6699cc\">");
		base.Response.Write(" <td align=\"center\">订单号</td>");
		base.Response.Write(" <td align=\"center\">店主</td>");
		base.Response.Write("<td align=\"center\">店铺名称</td>");
		base.Response.Write("<td align=\"center\">商品名称</td>");
		base.Response.Write("<td align=\"center\">数量</td>");
		base.Response.Write("<td align=\"center\">交易金额</td>");
		base.Response.Write("<td align=\"center\">日期</td>");
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr>");
				base.Response.Write("<td align=\"center\" style=\"background-color:#FFF\" style=\"vnd.ms-excel.numberformat:@\" width=\"150\"> {OrderNumber}</td>".Replace("{OrderNumber}", dataTable.Rows[i]["OrderNumber"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"80\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {ShopName}</td>".Replace("{ShopName}", dataTable.Rows[i]["ShopName"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"280\" style=\"vnd.ms-excel.numberformat:@\"> {ProductName}</td>".Replace("{ProductName}", dataTable.Rows[i]["ProductName"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"60\"  style=\"vnd.ms-excel.numberformat:@\"> {BuyNumber}</td>".Replace("{BuyNumber}", dataTable.Rows[i]["BuyNumber"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"60\"  style=\"vnd.ms-excel.numberformat:@\"> {Amount}</td>".Replace("{Amount}", dataTable.Rows[i]["Amount"].ToString()));
				base.Response.Write("<td align=\"center\" style=\"vnd.ms-excel.numberformat:yyyy/mm/dd;background-color:#FFF\" width=\"60\"> {CreateTime}</td>".Replace("{CreateTime}", dataTable.Rows[i]["CreateTime"].ToString()));
				base.Response.Write("</tr>");
			}
		}
		base.Response.Write("</table>");
	}
}
