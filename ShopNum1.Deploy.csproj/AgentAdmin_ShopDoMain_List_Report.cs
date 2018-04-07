using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Localization;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class AgentAdmin_ShopDoMain_List_Report : PageBase, IRequiresSessionState
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
			if (base.Request.QueryString["Type"] != null)
			{
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
					base.Response.ContentType = "text/HTML";
				}
				base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
				{
					"attachment;filename=\"ShopDomainReport_",
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
	}
	private void method_5()
	{
		HttpCookie cookie = base.Request.Cookies["ShopDoMainReportCookie"];
		HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
		string a = httpCookie.Values["PageCheck"].ToString();
		string string_ = httpCookie.Values["Guids"].ToString();
		string memLoginID = httpCookie.Values["MemLoginID"].ToString();
		string isAudit = httpCookie.Values["IsAudit"].ToString();
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = new ShopNum1_ShopURLManage_Action();
		DataTable dataTable;
		if (a == "1")
		{
			dataTable = shopNum1_ShopURLManage_Action.SearchByID(string_);
		}
		else
		{
			dataTable = shopNum1_ShopURLManage_Action.Search(memLoginID, isAudit);
		}
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			base.Response.Write("<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
			base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
			base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">域名</td>");
			base.Response.Write("<td align=\"center\"  style=\"background-color:#6699cc\">店铺URL</td>");
			base.Response.Write("<td  align=\"center\" style=\"background-color:#6699cc\">备案号</td>");
			base.Response.Write("<td align=\"center\" style=\"background-color:#6699cc\">店铺名</td>");
			base.Response.Write("<td  align=\"center\" style=\"background-color:#6699cc\">申请时间</td>");
			base.Response.Write("<td align=\"center\" style=\"background-color:#6699cc\">审核状态</td>");
			base.Response.Write("</tr>");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				base.Response.Write("<tr>");
				base.Response.Write("<td align=\"center\" style=\"background-color:#FFF\"> {DoMain}</td>".Replace("{DoMain}", dataTable.Rows[i]["DoMain"].ToString()));
				base.Response.Write("<td align=\"center\" style=\"background-color:#FFF\"> {GoUrl}</td>".Replace("{GoUrl}", dataTable.Rows[i]["GoUrl"].ToString()));
				base.Response.Write("<td  align=\"center\" style=\"background-color:#FFF\"> {SiteNumber}</td>".Replace("{SiteNumber}", dataTable.Rows[i]["SiteNumber"].ToString()));
				base.Response.Write("<td align=\"center\" style=\"background-color:#FFF\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
				base.Response.Write("<td align=\"center\" style=\"background-color:#FFF\"> {AddTime}</td>".Replace("{AddTime}", dataTable.Rows[i]["AddTime"].ToString()));
				string newValue = string.Empty;
				string text = dataTable.Rows[i]["IsAudit"].ToString();
				if (text != null)
				{
					if (!(text == "0"))
					{
						if (text == "1")
						{
							newValue = LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "1");
						}
					}
					else
					{
						newValue = LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "0");
					}
				}
				base.Response.Write("<td align=\"center\" style=\"background-color:#FFF\"> {IsAudit}</td>".Replace("{IsAudit}", newValue));
				base.Response.Write("</tr>");
			}
			base.Response.Write("</table>");
		}
	}
}
