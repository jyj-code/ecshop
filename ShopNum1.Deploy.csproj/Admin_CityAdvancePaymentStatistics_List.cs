using ShopNum1.Common;
using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_CityAdvancePaymentStatistics_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelMoney;
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
		try
		{
			string text = string.Empty;
			text = Common.GetNameById("SUM(AdvancePayment)", "ShopNum1_SubstationManage", "   AND  IsDeleted=0   ");
			if (!string.IsNullOrEmpty(text))
			{
				this.LabelMoney.Text = text;
			}
			else
			{
				this.LabelMoney.Text = "0";
			}
		}
		catch (Exception)
		{
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("AdvancePaymentStatistics_Report.aspx?Type=xls");
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
}
