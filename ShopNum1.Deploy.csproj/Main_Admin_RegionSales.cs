using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_RegionSales : PageBase, IRequiresSessionState
{
	protected const string ShopClick_Report = "RegionSales_Report.aspx";
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegion;
	protected HiddenField HiddenFieldRegionCode;
	protected System.Web.UI.WebControls.TextBox txtshophost;
	protected System.Web.UI.WebControls.TextBox txtshopname;
	protected System.Web.UI.WebControls.TextBox TextBoxStartDate;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndDate;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected CalendarExtender CalendarExtender2;
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
			this.DropDownListRegionCode1Bind();
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
			Record = "导出地区销售额Excel数据",
			OperatorID = base.ShopNum1LoginID,
			IP = Globals.IPAddress,
			PageName = "RegionSales.aspx",
			Date = DateTime.Now
		});
		base.Response.Redirect(string.Concat(new string[]
		{
			"RegionSales_Report.aspx?Type=xls&DispatchTime1=",
			this.TextBoxStartDate.Text.ToString(),
			"&DispatchTime2=",
			this.TextBoxEndDate.Text.ToString(),
			"&acode=",
			this.HiddenFieldRegionCode.Value
		}));
	}
	protected void ButtonHtml_Click(object sender, EventArgs e)
	{
		base.OperateLog(new ShopNum1_OperateLog
		{
			Record = "导出地区销售额Html数据",
			OperatorID = base.ShopNum1LoginID,
			IP = Globals.IPAddress,
			PageName = "RegionSales.aspx",
			Date = DateTime.Now
		});
		base.Response.Redirect(string.Concat(new string[]
		{
			"RegionSales_Report.aspx?Type=html&DispatchTime1=",
			this.TextBoxStartDate.Text.ToString(),
			"&DispatchTime2=",
			this.TextBoxEndDate.Text.ToString(),
			"&acode=",
			this.HiddenFieldRegionCode.Value
		}));
	}
	protected void LinkDetail_Click(object sender, EventArgs e)
	{
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		this.Page.Response.Redirect(string.Concat(new string[]
		{
			"RegionSalesOrderOperate.aspx?acode=",
			commandArgument,
			"&DispatchTime1=",
			this.TextBoxStartDate.Text,
			"&DispatchTime2=",
			this.TextBoxEndDate.Text
		}));
	}
	public void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	protected void DropDownListRegionCode1Bind()
	{
		this.DropDownListRegion.Items.Clear();
		ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
		shopNum1_DispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
		DataTable dataTable = shopNum1_DispatchRegion_Action.SearchtDispatchRegion(0, 0);
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			this.DropDownListRegion.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
		}
	}
	public void DropDownListRegionSelectedIndexChanged(object sender, EventArgs e)
	{
		this.HiddenFieldRegionCode.Value = this.DropDownListRegion.SelectedValue.Split(new char[]
		{
			'/'
		})[0];
		if (this.DropDownListRegion.SelectedValue.Split(new char[]
		{
			'/'
		})[0] == "000")
		{
			this.HiddenFieldRegionCode.Value = "-1";
		}
		this.method_5();
	}
	public string rstring(object object_0, int type)
	{
		string text = string.Empty;
		string result = string.Empty;
		text = object_0.ToString();
		try
		{
			if (type == 1)
			{
				result = text.Split(new char[]
				{
					','
				})[0].ToString();
			}
			else
			{
				result = text.Split(new char[]
				{
					'>'
				})[0].ToString();
			}
		}
		catch
		{
			result = text;
		}
		return result;
	}
}
