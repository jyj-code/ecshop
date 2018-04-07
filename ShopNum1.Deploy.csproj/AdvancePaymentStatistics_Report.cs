using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
public class AdvancePaymentStatistics_Report : PageBase, IRequiresSessionState
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
		if (base.Request.Cookies["AdminLoginCookie"] == null)
		{
			base.Response.Write("<script type=\"text/javascript\">window.top.location.href='Login.aspx';</script>");
		}
		else if (!this.Page.IsPostBack)
		{
			base.Response.Clear();
			if (base.Request.QueryString["Type"] != null)
			{
				string text = base.Request.QueryString["Type"].ToString();
				if (text == "xls")
				{
					base.Response.ContentType = "Application/ms-excel";
					base.Response.ContentEncoding = Encoding.UTF8;
				}
				else
				{
					base.Response.ContentType = "text/HTML";
					base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
				}
				base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
				{
					"attachment;filename=\"会员预存款记录_",
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
		try
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable = shopNum1_Member_Action.SearchAdvancePayment("");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">会员ID</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >姓名</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >当前预存款</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >冻结预存款</td>");
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", dataTable.Rows[i]["MemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Name}</td>".Replace("{Name}", dataTable.Rows[i]["Name"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center;color:red\"> ￥{AdvancePayment}</td>".Replace("{AdvancePayment}", dataTable.Rows[i]["AdvancePayment"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center;color:red\"> ￥{LockAdvancePayment}</td>".Replace("{LockAdvancePayment}", dataTable.Rows[i]["LockAdvancePayment"].ToString()));
					base.Response.Write("</tr>");
				}
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				DataTable allAdvancePayment = shopNum1_Member_Action.GetAllAdvancePayment(-1);
				string text;
				if (allAdvancePayment != null && allAdvancePayment.Rows.Count > 0)
				{
					if (!string.IsNullOrEmpty(allAdvancePayment.Rows[0][0].ToString()))
					{
						text = allAdvancePayment.Rows[0][0].ToString();
					}
					else
					{
						text = "0";
					}
				}
				else
				{
					text = "0";
				}
				string nameById = Common.GetNameById("SUM(LockAdvancePayment)", "ShopNum1_Member", " AND 1=1");
				string text2;
				if (!string.IsNullOrEmpty(nameById))
				{
					text2 = nameById;
				}
				else
				{
					text2 = "0";
				}
				base.Response.Write(string.Concat(new string[]
				{
					"<td colspan=\"4\" style=\"color:red\">当前会员预存款累计金额【￥",
					text,
					"】, 会员冻结预存款累计金额【￥",
					text2,
					"】 </td>"
				}));
				base.Response.Write("</tr>");
				base.Response.Write("</table>");
			}
			HttpCookie httpCookie = base.Request.Cookies["OrderListReportCookie"];
			httpCookie.Expires = DateTime.Now.AddDays(-99.0);
			base.Response.Cookies.Add(httpCookie);
		}
		catch (Exception)
		{
		}
	}
}
