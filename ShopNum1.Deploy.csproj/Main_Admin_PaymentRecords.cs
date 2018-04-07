using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_PaymentRecords : Page, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected LinkButton ButtonReportAll;
	protected LinkButton ButtonReportAllHtml;
	protected Repeater repeaList;
	protected HtmlGenericControl mydivpage;
	protected HtmlForm form1;
	private List<ShopNum1_ThreePaymentRecord> list_0 = new List<ShopNum1_ThreePaymentRecord>();
	private List<ShopNum1_ThreePaymentRecord> list_1 = null;
	[CompilerGenerated]
	private static Func<ShopNum1_ThreePaymentRecord, DateTime?> func_0;
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
		DataClassesDataContext dataClassesDataContext = new DataClassesDataContext(DatabaseExcetue.GetConnstring());
		this.list_0 = dataClassesDataContext.ShopNum1_ThreePaymentRecord.ToList<ShopNum1_ThreePaymentRecord>();
		this.method_0();
	}
	private void method_0()
	{
		string value = "1";
		if (!string.IsNullOrEmpty(Common.ReqStr("pageid")))
		{
			value = Common.ReqStr("pageid");
		}
		string text = "10";
		PageListBll pageListBll = new PageListBll("Main/Admin/PaymentRecords.aspx", true);
		PageList1 pageList = new PageList1();
		pageList.PageSize = Convert.ToInt32(text);
		pageList.PageID = Convert.ToInt32(value);
		pageList.RecordCount = this.list_0.Count;
		pageList.PageCount = pageList.RecordCount / pageList.PageSize;
		if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
		{
			pageList.PageCount++;
		}
		if (pageList.PageID > pageList.PageCount)
		{
			pageList.PageID = pageList.PageCount;
		}
		this.mydivpage.InnerHtml = pageListBll.GetPageListNewManage(pageList);
		this.list_1 = this.method_1(text, pageList.PageID.ToString(), null);
		this.repeaList.DataSource = this.list_1;
		this.repeaList.DataBind();
	}
	private List<ShopNum1_ThreePaymentRecord> method_1(string string_0, string string_1, object object_0)
	{
		IEnumerable<ShopNum1_ThreePaymentRecord> arg_24_0 = this.list_0;
		if (Main_Admin_PaymentRecords.func_0 == null)
		{
			Main_Admin_PaymentRecords.func_0 = new Func<ShopNum1_ThreePaymentRecord, DateTime?>(Main_Admin_PaymentRecords.smethod_0);
		}
		this.list_0 = arg_24_0.OrderByDescending(Main_Admin_PaymentRecords.func_0).ToList<ShopNum1_ThreePaymentRecord>();
		List<ShopNum1_ThreePaymentRecord> list = new List<ShopNum1_ThreePaymentRecord>();
		if (Convert.ToInt32(string_1) > 0)
		{
			int num = Convert.ToInt32(string_0) * (Convert.ToInt32(string_1) - 1) + 1;
			int num2 = Convert.ToInt32(string_0) * Convert.ToInt32(string_1) - 1;
			for (int i = num - 1; i <= num2; i++)
			{
				if (i < this.list_0.Count)
				{
					list.Add(this.list_0[i]);
				}
			}
		}
		return list;
	}
	protected void ButtonReportAll_Click(object sender, EventArgs e)
	{
		if (this.list_1.Count == 0)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			HttpCookie httpCookie = this.method_2();
			httpCookie.Values.Add("reportType", "7");
			httpCookie.Values.Add("Guids", "-1");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
		}
	}
	protected void ButtonReportAllHtml_Click(object sender, EventArgs e)
	{
		if (this.list_1.Count == 0)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			HttpCookie httpCookie = this.method_2();
			httpCookie.Values.Add("reportType", "7");
			httpCookie.Values.Add("Guids", "-1");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("Report_CheckV82.aspx?Type=html");
		}
	}
	private HttpCookie method_2()
	{
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
					""
				},

				{
					"ShopName",
					""
				},

				{
					"State",
					""
				},

				{
					"Sdate",
					""
				},

				{
					"Edate",
					""
				}
			}
		};
	}
	[CompilerGenerated]
	private static DateTime? smethod_0(ShopNum1_ThreePaymentRecord shopNum1_ThreePaymentRecord_0)
	{
		return shopNum1_ThreePaymentRecord_0.CreateTime;
	}
}
