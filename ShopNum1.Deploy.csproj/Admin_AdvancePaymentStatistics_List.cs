using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_AdvancePaymentStatistics_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxSMemLoginID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected Label LabelMoney;
	protected Label LabelLockAdvancePayment;
	protected LinkButton ButtonReport;
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
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataTable allAdvancePayment = shopNum1_Member_Action.GetAllAdvancePayment(-1);
		if (allAdvancePayment != null && allAdvancePayment.Rows.Count > 0)
		{
			if (!string.IsNullOrEmpty(allAdvancePayment.Rows[0][0].ToString()))
			{
				this.LabelMoney.Text = allAdvancePayment.Rows[0][0].ToString();
			}
			else
			{
				this.LabelMoney.Text = "0";
			}
		}
		else
		{
			this.LabelMoney.Text = "0";
		}
		try
		{
			string nameById = Common.GetNameById("SUM(LockAdvancePayment)", "ShopNum1_Member", " AND 1=1");
			if (!string.IsNullOrEmpty(nameById))
			{
				this.LabelLockAdvancePayment.Text = nameById;
			}
			else
			{
				this.LabelLockAdvancePayment.Text = "0";
			}
		}
		catch (Exception)
		{
			this.LabelLockAdvancePayment.Text = "0";
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
