using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ShopIncomeReport : PageBase, IRequiresSessionState
{
	protected const string ShopIncome_Report = "ShopIncome_Report.aspx";
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.TextBox txtshophost;
	protected System.Web.UI.WebControls.TextBox txtshopname;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonReport;
	protected LinkButton ButtonHtml;
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
			this.method_5();
		}
	}
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		base.OperateLog(new ShopNum1_OperateLog
		{
			Record = "导出店铺收入Excel数据",
			OperatorID = base.ShopNum1LoginID,
			IP = Globals.IPAddress,
			PageName = "ShopClickreport.aspx",
			Date = DateTime.Now
		});
		base.Response.Redirect("ShopIncome_Report.aspx?Type=xls&hname=" + this.txtshophost.Text + "&sname=" + this.txtshopname.Text.ToString());
	}
	protected void ButtonHtml_Click(object sender, EventArgs e)
	{
		base.OperateLog(new ShopNum1_OperateLog
		{
			Record = "导出店铺收入Html数据",
			OperatorID = base.ShopNum1LoginID,
			IP = Globals.IPAddress,
			PageName = "ShopClickreport.aspx",
			Date = DateTime.Now
		});
		base.Response.Redirect("ShopIncome_Report.aspx?Type=html&hname=" + this.txtshophost.Text.ToString() + "&sname=" + this.txtshopname.Text.ToString());
	}
}
