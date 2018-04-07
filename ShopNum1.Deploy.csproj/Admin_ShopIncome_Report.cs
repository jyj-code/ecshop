using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class Admin_ShopIncome_Report : PageBase, IRequiresSessionState
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
				base.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
				base.Response.ContentType = "Application/ms-excel";
			}
			else
			{
				base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
			}
			base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
			{
				"attachment;filename=\"ShopIncomeReport_",
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
		DataTable dataTable = shopNum1_Report_Action.SearchShopIncome(this.Page.Request.QueryString["hname"].ToString(), this.Page.Request.QueryString["sname"].ToString());
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
			base.Response.Write("<tr bgcolor=\"#6699cc\">");
			base.Response.Write(" <td align=\"center\">店主</td>");
			base.Response.Write("<td align=\"center\">店铺名称</td>");
			base.Response.Write("<td align=\"center\">店铺收入</td>");
			base.Response.Write("</tr>");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr bgcolor=\"#ffffff\">");
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {memloginid}</td>".Replace("{memloginid}", dataTable.Rows[i]["memloginid"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"180\" style=\"vnd.ms-excel.numberformat:@\"> {shopname}</td>".Replace("{shopname}", dataTable.Rows[i]["shopname"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {moneycount}</td>".Replace("{moneycount}", dataTable.Rows[i]["moneycount"].ToString()));
				base.Response.Write("</tr>");
			}
			base.Response.Write("<br />");
			base.Response.Write("</table>");
		}
	}
}
