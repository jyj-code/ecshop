using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_OrderSpell_List : PageBase, IRequiresSessionState
{
	protected const string OrderPanic_Operate = "OrderPanic_Operate.aspx";
	protected const string OrderList_Report = "OrderList_Report.aspx";
	private int int_0 = 10;
	private string string_5 = string.Empty;
	public DataTable dt_OrderList = null;
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected LinkButton LinkButtonAll;
	protected LinkButton LinkButtonNopayment;
	protected LinkButton LinkButtonPayment;
	protected LinkButton LinkButtonSend;
	protected LinkButton LinkButtonComplete;
	protected LinkButton LinkButtonRefund;
	protected LinkButton LinkButtonReturnGoods;
	protected LinkButton LinkButtonCancel;
	protected Label LabelOrderNumber;
	protected Label LabelMemLoginID;
	protected Label LabelCreateTime;
	protected TextBox TextBoxCreateTime1;
	protected ToolkitScriptManager ToolkitScriptManager1;
	protected CalendarExtender CalendarExtender1;
	protected TextBox TextBoxCreateTime2;
	protected CalendarExtender CalendarExtender2;
	protected Label LabelShouldPayPrice;
	protected DropDownList DropDownListSubstationID;
	protected Label Label3;
	protected LinkButton ButtonReport;
	protected LinkButton ButtonReportx;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected HtmlGenericControl pageDiv;
	protected HtmlGenericControl showPage;
	protected Label LabelOderStatus;
	protected DropDownList DropDownListOderStatus;
	protected Label LabelAddress1;
	protected TextBox TextBoxAddress;
	protected Label LabelPostalcode;
	protected TextBox TextBoxPostalcode;
	protected Label LabelMobile;
	protected TextBox TextBoxMobile;
	protected Label LabelEmail;
	protected TextBox TextBoxEmail;
	protected Label LabelTel;
	protected TextBox TextBoxTel;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected DropDownList DropDownListType;
	protected Label LabelPaymentState;
	protected DropDownList DropDownListPaymentState;
	protected Label LabelShipmentState;
	protected DropDownList DropDownListShipmentState;
	protected Button ButtonHtml;
	protected RadioButtonList RadioButtonListOutPage;
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
		string text = (this.Page.Request.QueryString["style"] == null) ? "1" : this.Page.Request.QueryString["style"].ToString();
		string text2 = text;
		switch (text2)
		{
		case "1":
			this.method_6(this.LinkButtonAll);
			break;
		case "2":
			this.method_6(this.LinkButtonNopayment);
			break;
		case "3":
			this.method_6(this.LinkButtonPayment);
			break;
		case "4":
			this.method_6(this.LinkButtonSend);
			break;
		case "5":
			this.method_6(this.LinkButtonComplete);
			break;
		case "6":
			this.method_6(this.LinkButtonRefund);
			break;
		case "7":
			this.method_6(this.LinkButtonReturnGoods);
			break;
		case "8":
			this.method_6(this.LinkButtonCancel);
			break;
		}
		if (Common.ReqStr("pagesize") != "")
		{
			this.int_0 = Convert.ToInt32(Common.ReqStr("pagesize"));
		}
		this.GetSubstationID();
		this.BindDropDownListOderStatus();
		this.BindGrid(this.method_5("OrderNumber", "desc"));
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
	private string method_5(string string_6, string string_7)
	{
		string text = Common.ReqStr("trdeid");
		string text2 = Common.ReqStr("orid");
		string text3 = Common.ReqStr("mid");
		string text4 = Common.ReqStr("ct");
		string text5 = Common.ReqStr("et");
		string text6 = Common.ReqStr("sp1");
		string text7 = Common.ReqStr("sp2");
		string text8 = Common.ReqStr("shopid");
		string text9 = HttpUtility.HtmlDecode(Common.ReqStr("sn"));
		string text10 = Common.ReqStr("status");
		string text11 = Common.ReqStr("fz");
		this.TextBoxCreateTime1.Text = text4;
		this.TextBoxCreateTime2.Text = text5;
		string text12 = string.Empty;
		text12 += " and orderType=1 ";
		if (Operator.FormatToEmpty(text) != string.Empty)
		{
			text12 = text12 + " AND tradeid LIKE '%" + text + "%'";
		}
		if (Operator.FormatToEmpty(text2) != string.Empty)
		{
			text12 = text12 + " AND OrderNumber LIKE '%" + text2 + "%'";
		}
		if (Operator.FormatToEmpty(text3) != string.Empty)
		{
			text12 = text12 + " AND MemLoginID LIKE '%" + Operator.FilterString(text3) + "%'";
		}
		if (Operator.FormatToEmpty(text4) != string.Empty)
		{
			text12 = text12 + " AND CreateTime>='" + text4 + "' ";
		}
		if (Operator.FormatToEmpty(text5) != string.Empty)
		{
			text12 = text12 + " AND CreateTime<='" + text5 + "' ";
		}
		if (Operator.FormatToEmpty(text6) != string.Empty)
		{
			text12 = text12 + " AND ShouldPayPrice>='" + text6 + "' ";
		}
		if (Operator.FormatToEmpty(text7) != string.Empty)
		{
			text12 = text12 + " AND ShouldPayPrice<='" + text7 + "' ";
		}
		if (Operator.FormatToEmpty(text8) != string.Empty)
		{
			text12 = text12 + " AND ShopID  Like '%" + text8 + "%' ";
		}
		if (Operator.FormatToEmpty(text9) != string.Empty)
		{
			text12 = text12 + " AND ShopName  Like '%" + text9 + "%' ";
		}
		if (Operator.FormatToEmpty(text10) != string.Empty)
		{
			text12 = text12 + " and oderstatus= " + text10;
		}
		if (!string.IsNullOrEmpty(text11) && text11 != "-1")
		{
			text12 = text12 + " and  SubstationID= '" + text11 + "' ";
		}
		return text12;
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.DropDownListType.SelectedValue = "0";
		this.BindGrid(this.method_5("OrderNumber", "desc"));
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderPanic_Operate.aspx?guid=" + this.CheckGuid.Value.Replace("'", ""));
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
		int num = shopNum1_OrderInfo_Action.Delete(this.CheckGuid.Value);
		if (num > 0)
		{
			this.BindGrid(this.method_5("OrderNumber", "desc"));
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		int num = shopNum1_OrderInfo_Action.Delete("'" + commandArgument + "'");
		if (num > 0)
		{
			this.BindGrid(this.method_5("OrderNumber", "desc"));
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void BindGrid(string strcondition)
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
		string text = base.Request.RawUrl;
		if (text.IndexOf("?") != -1)
		{
			text = text.Split(new char[]
			{
				'?'
			})[0];
		}
		this.string_5 = Common.ReqStr("PageID");
		if (this.string_5 == "")
		{
			this.string_5 = "1";
		}
		DataTable dataTable = shopNum1_OrderInfo_Action.SelectOrderListNew(this.int_0.ToString(), this.string_5, strcondition, "3", "CreateTime");
		PageList1 pageList = new PageList1();
		pageList.PageSize = this.int_0;
		pageList.PageID = Convert.ToInt32(this.string_5.ToString());
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
		}
		else
		{
			pageList.RecordCount = 0;
		}
		pageList.PageCount = pageList.RecordCount / pageList.PageSize;
		if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
		{
			pageList.PageCount++;
		}
		if (pageList.PageID > pageList.PageCount)
		{
			pageList.PageID = pageList.PageCount;
		}
		if (pageList.PageSize > pageList.RecordCount || pageList.PageCount == 1)
		{
			this.showPage.Visible = false;
		}
		else
		{
			this.showPage.Visible = true;
		}
		PageListBll pageListBll = new PageListBll(text, true);
		this.pageDiv.InnerHtml = pageListBll.GetPageListNewManage(pageList);
		this.dt_OrderList = shopNum1_OrderInfo_Action.SelectOrderListNew(this.int_0.ToString(), this.string_5, strcondition, "2", "CreateTime");
		if (this.dt_OrderList.Rows.Count == 0)
		{
			this.dt_OrderList = null;
		}
	}
	protected void BindDropDownListOderStatus()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-全部-";
		listItem.Value = "-1";
		this.DropDownListOderStatus.Items.Add(listItem);
		ListItem listItem2 = new ListItem();
		listItem2.Text = "等待买家付款";
		listItem2.Value = "0";
		this.DropDownListOderStatus.Items.Add(listItem2);
		ListItem listItem3 = new ListItem();
		listItem3.Text = "等待卖家发货";
		listItem3.Value = "1";
		this.DropDownListOderStatus.Items.Add(listItem3);
		ListItem listItem4 = new ListItem();
		listItem4.Text = "等待买家确认收货";
		listItem4.Value = "2";
		this.DropDownListOderStatus.Items.Add(listItem4);
		ListItem listItem5 = new ListItem();
		listItem5.Text = "交易成功";
		listItem5.Value = "3";
		this.DropDownListOderStatus.Items.Add(listItem5);
		ListItem listItem6 = new ListItem();
		listItem6.Text = "系统关闭订单";
		listItem6.Value = "4";
		this.DropDownListOderStatus.Items.Add(listItem6);
		ListItem listItem7 = new ListItem();
		listItem7.Text = "卖家关闭订单";
		listItem7.Value = "5";
		this.DropDownListOderStatus.Items.Add(listItem7);
		ListItem listItem8 = new ListItem();
		listItem8.Text = "买家关闭订单";
		listItem8.Value = "6";
		this.DropDownListOderStatus.Items.Add(listItem8);
	}
	public string ChangeOderStatus(string oderStatus)
	{
		string result;
		switch (oderStatus)
		{
		case "0":
			result = "等待买家付款";
			return result;
		case "1":
			result = "等待卖家发货";
			return result;
		case "2":
			result = "等待买家确认收货";
			return result;
		case "3":
			result = "交易成功";
			return result;
		case "4":
			result = "系统关闭订单";
			return result;
		case "5":
			result = "卖家关闭订单";
			return result;
		case "6":
			result = "买家关闭订单";
			return result;
		}
		result = "非法状态";
		return result;
	}
	protected void ButtonReportx_Click(object sender, EventArgs e)
	{
		if (this.dt_OrderList.Rows.Count < 1)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			HttpCookie httpCookie = this.method_7();
			httpCookie.Values.Add("PageCheck", "1");
			httpCookie.Values.Add("Guids", "-1");
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("OrderList_Report.aspx?Type=xls");
		}
	}
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		if (this.dt_OrderList.Rows.Count < 1)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			HttpCookie httpCookie = this.method_7();
			httpCookie.Values.Add("PageCheck", "1");
			httpCookie.Values.Add("Guids", this.CheckGuid.Value);
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("OrderList_Report.aspx?Type=xls");
			this.CheckGuid.Value = "0";
		}
	}
	protected void ButtonHtml_Click(object sender, EventArgs e)
	{
		if (this.dt_OrderList.Rows.Count < 1)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			HttpCookie httpCookie = this.method_7();
			if (this.RadioButtonListOutPage.SelectedValue == "0")
			{
				httpCookie.Values.Add("PageCheck", "1");
				httpCookie.Values.Add("Guids", this.CheckGuid.Value);
			}
			else
			{
				httpCookie.Values.Add("PageCheck", "0");
				httpCookie.Values.Add("Guids", "0");
			}
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("OrderList_Report.aspx?Type=html");
		}
	}
	protected void LinkButtonAll_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderSpell_List.aspx?style=1");
	}
	protected void LinkButtonPayment_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderSpell_List.aspx?style=3&status=1");
	}
	protected void LinkButtonNopayment_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderSpell_List.aspx?style=2&status=0");
	}
	protected void LinkButtonSend_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderSpell_List.aspx?style=4&status=2");
	}
	protected void LinkButtonComplete_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderSpell_List.aspx?style=5&status=3");
	}
	protected void LinkButtonRefund_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderSpell_List.aspx?style=6&status=6");
	}
	protected void LinkButtonReturnGoods_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderSpell_List.aspx?style=7&status=5");
	}
	protected void LinkButtonCanel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderSpell_List.aspx?style=8&status=4");
	}
	protected void ClearControl()
	{
		this.DropDownListOderStatus.SelectedValue = "-1";
		this.DropDownListShipmentState.SelectedValue = "-1";
	}
	private void method_6(LinkButton linkButton_0)
	{
		this.LinkButtonAll.CssClass = "";
		this.LinkButtonNopayment.CssClass = "";
		this.LinkButtonPayment.CssClass = "";
		this.LinkButtonSend.CssClass = "";
		this.LinkButtonComplete.CssClass = "";
		this.LinkButtonRefund.CssClass = "";
		this.LinkButtonReturnGoods.CssClass = "";
		this.LinkButtonCancel.CssClass = "";
		linkButton_0.CssClass = "cur";
	}
	private HttpCookie method_7()
	{
		Common.ReqStr("trdeid");
		string value = Common.ReqStr("orid");
		string value2 = Common.ReqStr("mid");
		string value3 = Common.ReqStr("ct");
		string value4 = Common.ReqStr("et");
		string value5 = Common.ReqStr("sp1");
		string value6 = Common.ReqStr("sp2");
		string value7 = Common.ReqStr("shopid");
		string value8 = HttpUtility.HtmlDecode(Common.ReqStr("sn"));
		string value9 = Common.ReqStr("status");
		return new HttpCookie("OrderListReportCookie")
		{
			Values = 
			{

				{
					"OrderNumber",
					value
				},

				{
					"MemLoginID",
					value2
				},

				{
					"Address",
					""
				},

				{
					"Postalcode",
					""
				},

				{
					"Mobile",
					""
				},

				{
					"Email",
					""
				},

				{
					"Tel",
					""
				},

				{
					"Name",
					""
				},

				{
					"ShouldPayPrice1",
					value5
				},

				{
					"ShouldPayPrice2",
					value6
				},

				{
					"CreateTime1",
					value3
				},

				{
					"CreateTime2",
					value4
				},

				{
					"ShopID",
					value7
				},

				{
					"ShopName",
					value8
				},

				{
					"OrderType",
					"1"
				},

				{
					"orderStatus",
					value9
				}
			}
		};
	}
	public string ChangeOrderType(object IsPanicBuy, object isSpellBuy)
	{
		string result;
		if (IsPanicBuy.ToString() == "1")
		{
			result = "抢购订单";
		}
		else if (isSpellBuy.ToString() == "1")
		{
			result = "团购订单";
		}
		else if (IsPanicBuy.ToString() == "0" && isSpellBuy.ToString() == "0")
		{
			result = "普通订单";
		}
		else
		{
			result = "非法订单";
		}
		return result;
	}
}
