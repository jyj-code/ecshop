using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class AgentAdmin_ShopClick_Report : PageBase, IRequiresSessionState
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
				base.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
				base.Response.ContentType = "Application/ms-excel";
			}
			else
			{
				base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
			}
			base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
			{
				"attachment;filename=\"ShopClickReport_",
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
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		string startdate = (this.Page.Request.QueryString["DispatchTime1"].ToString() == "") ? "-1" : this.Page.Request.QueryString["DispatchTime1"].ToString();
		string enddate = (this.Page.Request.QueryString["DispatchTime2"].ToString() == "") ? "-1" : this.Page.Request.QueryString["DispatchTime2"].ToString();
		DataTable dataTable = shopNum1_ShopInfoList_Action.SearchShopClickCount(this.Page.Request.QueryString["hname"].ToString(), this.Page.Request.QueryString["sname"].ToString(), startdate, enddate, base.SubstationID);
		base.Response.Write("<table width=\"100%\" border=\"1\">");
		base.Response.Write("<tr bgcolor=\"#6699cc\">");
		base.Response.Write(" <td align=\"center\">店主</td>");
		base.Response.Write("<td align=\"center\">店铺名称</td>");
		base.Response.Write("<td align=\"center\">开店时间</td>");
		base.Response.Write("<td align=\"center\">访问次数</td>");
		base.Response.Write("</tr>");
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr>");
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {ShopName}</td>".Replace("{ShopName}", dataTable.Rows[i]["ShopName"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"150\" style=\"vnd.ms-excel.numberformat:@\"> {opentime}</td>".Replace("{opentime}", dataTable.Rows[i]["opentime"].ToString()));
				base.Response.Write("<td align=\"center\" width=\"100\" style=\"vnd.ms-excel.numberformat:@\"> {ClickCount}</td>".Replace("{ClickCount}", dataTable.Rows[i]["ClickCount"].ToString()));
				base.Response.Write("</tr>");
			}
		}
		base.Response.Write("</table> ");
		base.Response.Write("<br />  ");
	}
}
