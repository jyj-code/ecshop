using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class Main_Admin_ShopAmount_Report : PageBase, IRequiresSessionState
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
				"attachment;filename=\"ShopAmountReport_",
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
		string startdate = (this.Page.Request.QueryString["DispatchTime1"].ToString() == "") ? "-1" : this.Page.Request.QueryString["DispatchTime1"].ToString();
		string enddate = (this.Page.Request.QueryString["DispatchTime2"].ToString() == "") ? "-1" : this.Page.Request.QueryString["DispatchTime2"].ToString();
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable dataTable = shopNum1_ShopInfoList_Action.SearchShopAmount(startdate, enddate);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			base.Response.Write("<table width=\"100%\">");
			base.Response.Write("<tr bgcolor=\"#6699cc\">");
			base.Response.Write(" <td align=\"center\">店主</td>");
			base.Response.Write("<td align=\"center\">店铺名称</td>");
			base.Response.Write("<td align=\"center\">订单数</td>");
			base.Response.Write("<td align=\"center\">总金额</td>");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr>");
				base.Response.Write("<td align=\"center\" width=\"100\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\"> {ShopName}</td>".Replace("{ShopName}", dataTable.Rows[i]["ShopName"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\"> {OrderNum}</td>".Replace("{OrderNum}", dataTable.Rows[i]["OrderNum"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\"> {Amount}</td>".Replace("{Amount}", dataTable.Rows[i]["Amount"].ToString()));
				base.Response.Write("</tr>");
			}
			base.Response.Write("</table>");
		}
	}
}
