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
public class Main_Admin_RegionSalesOrderOperate : PageBase, IRequiresSessionState
{
	protected const string strOrderProductReport = "RegionSalesOrderOperate_Report.aspx";
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected System.Web.UI.WebControls.TextBox txtOrderNumber;
	protected System.Web.UI.WebControls.DropDownList DropDownListRegion;
	protected HiddenField HiddenFieldRegionCode;
	protected System.Web.UI.WebControls.TextBox TextBoxSPayPrice;
	protected System.Web.UI.WebControls.TextBox TextBoxEPayPrice;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected System.Web.UI.WebControls.TextBox txtProductName;
	protected System.Web.UI.WebControls.TextBox TextBoxStartDate;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxEndDate;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate0;
	protected CalendarExtender CalendarExtender2;
	protected System.Web.UI.WebControls.DropDownList DropDownListCategoryName;
	protected HiddenField HiddenFieldCategoryCode;
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
		this.HiddenFieldRegionCode.Value = ((Common.ReqStr("acode").ToString() == "") ? "-1" : Common.ReqStr("acode").ToString());
		this.TextBoxStartDate.Text = ((Common.ReqStr("DispatchTime1").ToString() == "") ? "" : Common.ReqStr("DispatchTime1").ToString());
		this.TextBoxEndDate.Text = ((Common.ReqStr("DispatchTime2").ToString() == "") ? "" : Common.ReqStr("DispatchTime2").ToString());
		if (!base.IsPostBack)
		{
			this.DropDownListRegionCode1Bind();
			this.DropDownListProductGuidBind();
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
			Record = "导出商品销售明细Excel数据",
			OperatorID = base.ShopNum1LoginID,
			IP = Globals.IPAddress,
			PageName = "RegionSalesOrderOperate.aspx",
			Date = DateTime.Now
		});
		base.Response.Redirect(string.Concat(new string[]
		{
			"RegionSalesOrderOperate_Report.aspx?Type=xls&pname=",
			this.txtProductName.Text,
			"&oname=",
			this.txtOrderNumber.Text.ToString(),
			"&DispatchTime1=",
			this.TextBoxStartDate.Text.ToString(),
			"&DispatchTime2=",
			this.TextBoxEndDate.Text.ToString(),
			"&ShopName=",
			this.TextBoxShopName.Text.ToString(),
			"&sPayPrice=",
			this.TextBoxSPayPrice.Text,
			"&ePayPrice=",
			this.TextBoxEPayPrice.Text,
			"&acode=",
			this.HiddenFieldRegionCode.Value,
			"&pcode=",
			this.HiddenFieldCategoryCode.Value
		}));
	}
	protected void ButtonHtml_Click(object sender, EventArgs e)
	{
		base.OperateLog(new ShopNum1_OperateLog
		{
			Record = "导出商品销售明细Html数据",
			OperatorID = base.ShopNum1LoginID,
			IP = Globals.IPAddress,
			PageName = "OrderProductReport.aspx",
			Date = DateTime.Now
		});
		base.Response.Redirect(string.Concat(new string[]
		{
			"RegionSalesOrderOperate_Report.aspx?Type=html&pname=",
			this.txtProductName.Text,
			"&oname=",
			this.txtOrderNumber.Text.ToString(),
			"&DispatchTime1=",
			this.TextBoxStartDate.Text.ToString(),
			"&DispatchTime2=",
			this.TextBoxEndDate.Text.ToString(),
			"&ShopName=",
			this.TextBoxShopName.Text.ToString(),
			"&sPayPrice=",
			this.TextBoxSPayPrice.Text,
			"&ePayPrice=",
			this.TextBoxEPayPrice.Text,
			"&acode=",
			this.HiddenFieldRegionCode.Value,
			"&pcode=",
			this.HiddenFieldCategoryCode.Value
		}));
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.Num1GridViewShow.DataBind();
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
	protected void DropDownListProductGuidBind()
	{
		this.DropDownListCategoryName.Items.Clear();
		this.DropDownListCategoryName.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
		DataTable list = shopNum1_ProuductChecked_Action.GetList("0");
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListCategoryName.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
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
	public void DropDownListProductCategoryIndexChanged(object sender, EventArgs e)
	{
		this.HiddenFieldCategoryCode.Value = this.DropDownListCategoryName.SelectedValue.Split(new char[]
		{
			'/'
		})[0];
		if (this.DropDownListCategoryName.SelectedValue.Split(new char[]
		{
			'/'
		})[0] == "000")
		{
			this.HiddenFieldCategoryCode.Value = "-1";
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
