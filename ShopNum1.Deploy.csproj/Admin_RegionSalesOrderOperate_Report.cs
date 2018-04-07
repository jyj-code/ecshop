using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class Admin_RegionSalesOrderOperate_Report : PageBase, IRequiresSessionState
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
		ShopNum1_Report_Action shopNum1_Report_Action = (ShopNum1_Report_Action)LogicFactory.CreateShopNum1_Report_Action();
		string startdate = (this.Page.Request.QueryString["DispatchTime1"].ToString() == "") ? "-1" : this.Page.Request.QueryString["DispatchTime1"].ToString();
		string enddate = (this.Page.Request.QueryString["DispatchTime2"].ToString() == "") ? "-1" : this.Page.Request.QueryString["DispatchTime2"].ToString();
		string shopname = (this.Page.Request.QueryString["ShopName"].ToString() == "") ? "-1" : this.Page.Request.QueryString["ShopName"].ToString();
		string regioncecode = (base.Request.QueryString["acode"].ToString() == "") ? "-1" : base.Request.QueryString["acode"].ToString();
		string ordernumber = (this.Page.Request.QueryString["oname"].ToString() == "") ? "-1" : this.Page.Request.QueryString["oname"].ToString();
		string productName = (this.Page.Request.QueryString["pname"].ToString() == "") ? "-1" : this.Page.Request.QueryString["pname"].ToString();
		string sPayPrice = (this.Page.Request.QueryString["sPayPrice"].ToString() == "") ? "-1" : this.Page.Request.QueryString["sPayPrice"].ToString();
		string ePayPrice = (this.Page.Request.QueryString["ePayPrice"].ToString() == "") ? "-1" : this.Page.Request.QueryString["ePayPrice"].ToString();
		string productCategoryCode = (this.Page.Request.QueryString["pcode"].ToString() == "") ? "-1" : this.Page.Request.QueryString["pcode"].ToString();
		DataTable dataTable = shopNum1_Report_Action.SearchRegionSalesDetail(ordernumber, productName, shopname, startdate, enddate, regioncecode, sPayPrice, ePayPrice, productCategoryCode);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			base.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html><head></head><body>");
			base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
			base.Response.Write("<tr bgcolor=\"#6699cc\">");
			base.Response.Write("<td align=\"center\">省份</td>");
			base.Response.Write("<td align=\"center\" style=\"vnd.ms-excel.numberformat:@\" >订单号</td>");
			base.Response.Write("<td align=\"center\">店铺名称</td>");
			base.Response.Write("<td align=\"center\">商品名称</td>");
			base.Response.Write("<td align=\"center\">商品类型</td>");
			base.Response.Write("<td align=\"center\">数量</td>");
			base.Response.Write("<td align=\"center\">订单金额</td>");
			base.Response.Write("<td align=\"center\">订单日期</td>");
			base.Response.Write("</tr>");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr bgcolor=\"#ffffff\">");
				base.Response.Write("<td align=\"center\" width=\"100\"> {AddressValue}</td>".Replace("{AddressValue}", this.rstring(dataTable.Rows[i]["AddressValue"], 1)));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\" > {ordernumber}</td>".Replace("{ordernumber}", dataTable.Rows[i]["ordernumber"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\"> {shopname}</td>".Replace("{shopname}", dataTable.Rows[i]["shopname"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"180\"> {ProductName}</td>".Replace("{ProductName}", dataTable.Rows[i]["ProductName"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"180\"> {productcategoryName}</td>".Replace("{productcategoryName}", this.rstring(dataTable.Rows[i]["productcategoryName"], 2)));
				base.Response.Write("<td align=\"center\" width=\"100\"> {BuyNumber}</td>".Replace("{BuyNumber}", dataTable.Rows[i]["BuyNumber"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\"> {BuyPrice}</td>".Replace("{BuyPrice}", dataTable.Rows[i]["BuyPrice"].ToString()));
				base.Response.Write("<td align=\"center\" style=\"vnd.ms-excel.numberformat:yyyy/mm/dd;background-color:#FFF\" width=\"100\"> {CreateTime}</td>".Replace("{CreateTime}", dataTable.Rows[i]["CreateTime"].ToString()));
				base.Response.Write("</tr>");
			}
			base.Response.Write("</table>");
		}
	}
	public string rstring(object object_0, int type)
	{
		string text = string.Empty;
		string result = string.Empty;
		text = object_0.ToString();
		try
		{
			if (type == 1)
			{
				result = text.Split(new char[]
				{
					','
				})[0].ToString();
			}
			else
			{
				result = text.Split(new char[]
				{
					'>'
				})[0].ToString();
			}
		}
		catch
		{
			result = text;
		}
		return result;
	}
}
