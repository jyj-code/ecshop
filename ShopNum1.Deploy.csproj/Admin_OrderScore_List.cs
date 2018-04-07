using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_OrderScore_List : PageBase, IRequiresSessionState
{
	protected const string Order_Operate = "Order_Operate.aspx";
	protected const string OrderList_Report = "OrderList_Report.aspx";
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected LinkButton LinkButtonAll;
	protected LinkButton LinkButtonOderStatusOk;
	protected LinkButton LinkButtonOderStatusNo;
	protected Label LabelOrderNumber;
	protected System.Web.UI.WebControls.TextBox TextBoxOrderNumber;
	protected Label LabelMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxPhone;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected Label LabelCreateTime;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateTime1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateTime2;
	protected CalendarExtender CalendarExtender2;
	protected Label LabelShouldPayPrice;
	protected System.Web.UI.WebControls.TextBox TextBoxShouldPayPrice1;
	protected RegularExpressionValidator RegularExpressionValidatorShouldPayPrice1;
	protected System.Web.UI.WebControls.TextBox TextBoxShouldPayPrice2;
	protected RegularExpressionValidator RegularExpressionValidatorShouldPayPrice2;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonReport;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected Label LabelOderStatus;
	protected System.Web.UI.WebControls.DropDownList DropDownListOderStatus;
	protected Label LabelAddress1;
	protected System.Web.UI.WebControls.TextBox TextBoxAddress;
	protected Label LabelPostalcode;
	protected System.Web.UI.WebControls.TextBox TextBoxPostalcode;
	protected Label LabelMobile;
	protected System.Web.UI.WebControls.TextBox TextBoxMobile;
	protected Label LabelEmail;
	protected System.Web.UI.WebControls.TextBox TextBoxEmail;
	protected Label LabelTel;
	protected System.Web.UI.WebControls.TextBox TextBoxTel;
	protected Label LabelName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.DropDownList DropDownListType;
	protected Label LabelPaymentState;
	protected System.Web.UI.WebControls.DropDownList DropDownListPaymentState;
	protected Label LabelShipmentState;
	protected System.Web.UI.WebControls.DropDownList DropDownListShipmentState;
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
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	public void GetSubstationID()
	{
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.GetSubstationID();
		}
		if (base.Request.QueryString["style"] != null && base.Request.QueryString["status"] != null)
		{
			string text = base.Request.QueryString["style"].ToString();
			base.Request.QueryString["status"].ToString();
			string text2 = text;
			if (text2 != null)
			{
				if (!(text2 == "1"))
				{
					if (!(text2 == "2"))
					{
						if (text2 == "3")
						{
							this.LinkButtonAll.CssClass = "";
							this.LinkButtonOderStatusOk.CssClass = "";
							this.LinkButtonOderStatusNo.CssClass = "cur";
						}
					}
					else
					{
						this.LinkButtonAll.CssClass = "";
						this.LinkButtonOderStatusOk.CssClass = "cur";
						this.LinkButtonOderStatusNo.CssClass = "";
					}
				}
				else
				{
					this.LinkButtonAll.CssClass = "cur";
					this.LinkButtonOderStatusOk.CssClass = "";
					this.LinkButtonOderStatusNo.CssClass = "";
				}
			}
		}
		this.BindData("CreateTime");
	}
	public string GetState(string state)
	{
		string result;
		if (state == "1")
		{
			result = "已处理";
		}
		else
		{
			result = "未处理";
		}
		return result;
	}
	private string method_5(string string_5)
	{
		string str = string.Empty;
		if (!string.IsNullOrEmpty(this.TextBoxOrderNumber.Text.Trim()))
		{
			str = str + "   and   OrderNumber='" + Operator.FilterString(this.TextBoxOrderNumber.Text.Trim()) + "'  ";
		}
		if (!string.IsNullOrEmpty(this.TextBoxMemLoginID.Text.Trim()))
		{
			str = str + "   and   Name like '%" + Operator.FilterString(this.TextBoxMemLoginID.Text.Trim()) + "%'  ";
		}
		if (!string.IsNullOrEmpty(this.TextBoxPhone.Text.Trim()))
		{
			str = str + "   and   Mobile = '" + Operator.FilterString(this.TextBoxPhone.Text.Trim()) + "'  ";
		}
		if (!string.IsNullOrEmpty(this.TextBoxShopID.Text.Trim()))
		{
			str = str + "   and   ShopMemLoginID = '" + Operator.FilterString(this.TextBoxShopID.Text.Trim()) + "'  ";
		}
		if (!string.IsNullOrEmpty(this.TextBoxCreateTime1.Text.Trim()))
		{
			str = str + "   and   CreateTime > '" + Operator.FilterString(this.TextBoxCreateTime1.Text.Trim()) + "'  ";
		}
		if (!string.IsNullOrEmpty(this.TextBoxCreateTime2.Text.Trim()))
		{
			str = str + "   and   CreateTime < '" + Operator.FilterString(this.TextBoxCreateTime2.Text.Trim()) + "'  ";
		}
		if (!string.IsNullOrEmpty(this.TextBoxShouldPayPrice1.Text.Trim()))
		{
			str = str + "   and   TotalScore > " + this.TextBoxShouldPayPrice1.Text.Trim() + "  ";
		}
		if (!string.IsNullOrEmpty(this.TextBoxShouldPayPrice2.Text.Trim()))
		{
			str = str + "   and   TotalScore < " + this.TextBoxShouldPayPrice2.Text.Trim() + "  ";
		}
		if (base.Request.QueryString["status"] != null && base.Request.QueryString["status"].ToString() != "-1")
		{
			str = str + "   and   OderStatus =" + base.Request.QueryString["status"].ToString() + "  ";
		}
		if (this.DropDownListSubstationID.SelectedValue != "-1")
		{
			str = str + "   and     SubstationID= '" + this.DropDownListSubstationID.SelectedValue + "'  ";
		}
		return str + "   order  by   " + string_5 + "   desc    ";
	}
	public void BindData(string orderString)
	{
		try
		{
			ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
			DataTable infoInManage = shopNum1_ScoreOrderInfo_Action.GetInfoInManage(this.method_5(orderString));
			if (infoInManage != null && infoInManage.Rows.Count > 0)
			{
				this.Num1GridViewShow.DataSource = infoInManage.DefaultView;
				this.Num1GridViewShow.DataBind();
			}
			else
			{
				this.Num1GridViewShow.DataSource = null;
				this.Num1GridViewShow.DataBind();
			}
		}
		catch (Exception ex)
		{
			this.Page.Response.Write(ex.Message);
		}
	}
	protected void LinkButtonAll_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderScore_List.aspx?style=1&status=-1");
	}
	protected void LinkButtonOderStatusOk_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderScore_List.aspx?style=2&status=1");
	}
	protected void LinkButtonOderStatusNo_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderScore_List.aspx?style=3&status=0");
	}
	protected void Num1GridViewShow_Sorting(object sender, GridViewSortEventArgs e)
	{
		string string_ = e.SortExpression.ToString();
		this.BindData(this.method_5(string_));
	}
	protected void Num1GridViewShow_Changing(object sender, GridViewPageEventArgs e)
	{
		this.Num1GridViewShow.PageIndex = e.NewPageIndex;
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindData("CreateTime");
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
		int num = shopNum1_ScoreOrderInfo_Action.Delete(this.CheckGuid.Value.Replace("'on',", ""));
		if (num > 0)
		{
			MessageBox.Show("批量删除成功！");
			this.BindData("CreateTime");
		}
	}
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		this.ReportData();
	}
	public void ReportData()
	{
		base.Response.Clear();
		string text = "xls";
		if (text == "xls")
		{
			base.Response.ContentType = "Application/ms-excel";
			base.Response.ContentEncoding = Encoding.UTF8;
		}
		base.Response.AppendHeader("Content-Disposition", string.Concat(new string[]
		{
			"attachment;filename=\"ScoreOrderInfo_",
			DateTime.Now.ToString("yyyymmddhhmm"),
			".",
			text,
			"\""
		}));
		this.method_6();
		base.Response.Flush();
		base.Response.Close();
		base.Response.End();
	}
	private void method_6()
	{
		try
		{
			ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
			DataTable infoInManage = shopNum1_ScoreOrderInfo_Action.GetInfoInManage(this.method_5("CreateTime"));
			if (infoInManage != null && infoInManage.Rows.Count > 0)
			{
				base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
				base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
				base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">订单号</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺ID</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >订单总积分</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >买家会员名</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >收货人</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >手机号码</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >电子邮件</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >邮政编码</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >下单时间</td>");
				base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >状态</td>");
				for (int i = 0; i < infoInManage.Rows.Count; i++)
				{
					base.Response.Write("<tr>");
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", infoInManage.Rows[i]["OrderNumber"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {ShopMemLoginID}</td>".Replace("{ShopMemLoginID}", infoInManage.Rows[i]["ShopMemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {TotalScore}</td>".Replace("{TotalScore}", infoInManage.Rows[i]["TotalScore"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {MemLoginID}</td>".Replace("{MemLoginID}", infoInManage.Rows[i]["MemLoginID"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Name}</td>".Replace("{Name}", infoInManage.Rows[i]["Name"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Mobile}</td>".Replace("{Mobile}", infoInManage.Rows[i]["Mobile"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Email}</td>".Replace("{Email}", infoInManage.Rows[i]["Email"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {Postalcode}</td>".Replace("{Postalcode}", infoInManage.Rows[i]["Postalcode"].ToString()));
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {CreateTime}</td>".Replace("{CreateTime}", infoInManage.Rows[i]["CreateTime"].ToString()));
					string newValue = string.Empty;
					if (infoInManage.Rows[i]["OderStatus"].ToString() == "1")
					{
						newValue = "已处理";
					}
					else
					{
						newValue = "未处理";
					}
					base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {OderStatus}</td>".Replace("{OderStatus}", newValue));
					base.Response.Write("</tr>");
				}
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
