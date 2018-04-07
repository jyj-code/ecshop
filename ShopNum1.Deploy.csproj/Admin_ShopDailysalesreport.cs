using AjaxControlToolkit;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ShopDailysalesreport : PageBase, IRequiresSessionState
{
	protected System.Web.UI.WebControls.TextBox TextMemLoginIDValue;
	protected System.Web.UI.WebControls.TextBox txtshopname;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate1;
	protected RegularExpressionValidator RegularExpressionValidatorSDate1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate2;
	protected RegularExpressionValidator RegularExpressionValidatorSDate2;
	protected CompareValidator CompareValidatorTextBoxSDate2;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonReportAll;
	protected LinkButton ButtonReportAllHtml;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HtmlForm form1;
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
		if (!base.IsPostBack)
		{
			this.method_6();
		}
	}
	protected void ButtonReportAll_Click(object sender, EventArgs e)
	{
		if (this.Num1GridViewShow.Rows.Count < 1)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "店铺每日收入数据导出",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ShopDailysalesreport.aspx",
				Date = DateTime.Now
			});
			HttpCookie httpCookie = this.method_5();
			httpCookie.Values.Add("reportType", "6");
			httpCookie.Values.Add("Guids", "-1");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
		}
	}
	protected void ButtonReportAllHtml_Click(object sender, EventArgs e)
	{
		if (this.Num1GridViewShow.Rows.Count < 1)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "店铺每日收入数据导出",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "ShopDailysalesreport.aspx",
				Date = DateTime.Now
			});
			HttpCookie httpCookie = this.method_5();
			httpCookie.Values.Add("reportType", "6");
			httpCookie.Values.Add("Guids", "-1");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("Report_CheckV82.aspx?Type=html");
		}
	}
	private HttpCookie method_5()
	{
		string text = this.TextMemLoginIDValue.Text;
		string text2 = this.txtshopname.Text;
		string text3 = this.TextBoxSDate1.Text;
		string text4 = this.TextBoxSDate2.Text;
		return new HttpCookie("MoneyReportCookie")
		{
			Values = 
			{

				{
					"OrderNumber",
					""
				},

				{
					"MemLoginID",
					text
				},

				{
					"ShopName",
					text2
				},

				{
					"State",
					""
				},

				{
					"Sdate",
					text3
				},

				{
					"Edate",
					text4
				}
			}
		};
	}
	private void method_6()
	{
		this.Num1GridViewShow.DataBind();
	}
}
