using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_AdvancePaymentPreTransfer_List : PageBase, IRequiresSessionState
{
	protected const string AdvancePaymentApplyLog_Operate = "Admin_AdvancePaymentPreTransfer__Operate.aspx";
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.TextBox TextBoxOrderNumber;
	protected Label LabelSDate;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate1;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxSDate2;
	protected RegularExpressionValidator RegularExpressionValidatorEndDate;
	protected CalendarExtender CalendarExtender2;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
	protected Label LabelGetMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxGetMemLoginID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonDelete;
	protected LinkButton ButtonReportAll;
	protected MessageShow MessageShow1;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
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
		if (!this.Page.IsPostBack)
		{
			this.BindGrid();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	private HttpCookie method_5()
	{
		string text = this.TextBoxOrderNumber.Text;
		string text2 = this.TextBoxSMemLoginID.Text;
		string text3 = this.TextBoxGetMemLoginID.Text;
		string text4 = this.TextBoxSDate1.Text;
		string text5 = this.TextBoxSDate2.Text;
		return new HttpCookie("MoneyReportCookie")
		{
			Values = 
			{

				{
					"OrderNumber",
					text
				},

				{
					"MemLoginID",
					text2
				},

				{
					"ToMemLoginID",
					text3
				},

				{
					"State",
					"0"
				},

				{
					"Sdate",
					text4
				},

				{
					"Edate",
					text5
				}
			}
		};
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
				Record = "导出转账记录数据",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AdvancePaymentPreTransfer_List.aspx",
				Date = DateTime.Now
			});
			HttpCookie httpCookie = this.method_5();
			httpCookie.Values.Add("reportType", "3");
			httpCookie.Values.Add("Guids", "-1");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
		}
	}
	protected void BindGrid()
	{
		try
		{
			this.Num1GridViewShow.DataBind();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_PreTransfer_Action shopNum1_PreTransfer_Action = (ShopNum1_PreTransfer_Action)LogicFactory.CreateShopNum1_PreTransfer_Action();
		int num = shopNum1_PreTransfer_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AdvancePaymentApplyLog_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
}
