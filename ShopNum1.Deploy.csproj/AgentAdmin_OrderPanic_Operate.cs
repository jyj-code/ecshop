using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_OrderPanic_Operate : PageBase, IRequiresSessionState
{
	protected const string Order_Operate_10 = "Order_Operate_10.aspx";
	protected const string Order_List = "Order_List.aspx";
	protected const string Order_Operate_2 = "Order_Operate_2.aspx";
	protected const string OrderInfo_Report = "OrderInfo_Report.aspx";
	protected const string Order_Operate_4 = "Order_Operate_4.aspx";
	protected const string Order_Operate_8 = "Order_Operate_8.aspx";
	protected const string Order_Operate_5 = "Order_Operate_5.aspx";
	protected const string Order_Operate_6 = "Order_Operate_6.aspx";
	protected const string Order_Operate_9 = "Order_Operate_9.aspx";
	protected HtmlHead Head1;
	protected Label Label18;
	protected Repeater RepeaterData;
	protected GridView Num1GridViewShowOrderProduct;
	protected Label LabelPageTitle;
	protected Label LabelShopID;
	protected Label LabelShopIDValue;
	protected Label LabelShopName;
	protected Label LabelShopNameValue;
	protected Label LabelOrderNumber;
	protected Label LabelOrderNumberValue;
	protected Label LabelNameMemLoginID;
	protected Label LabelMemLoginIDValue;
	protected Label LabelMemLoginIDValueShow;
	protected Label LabelOderStatus;
	protected Label LabelOderStatusValue;
	protected Label LabelCreateTime;
	protected Label LabelCreateTimeValue;
	protected Label LabelNamePaymentName;
	protected Label LabelPaymentNameValue;
	protected Label LabelNameShipmentNumber;
	protected Label LabelShipmentNumberValue;
	protected Label LabelPayTime;
	protected Label LabelPayTimeValue;
	protected Label LabelNameDispatchModeName;
	protected Label LabelDispatchModeNameValue;
	protected Label LabelNameFromUrl;
	protected Label LabelFromUrlValue;
	protected Label LabelNameDispatchTime;
	protected Label LabelDispatchTimeValue;
	protected Label Label13;
	protected Label LabelInvoiceType;
	protected Label LabelInvoiceTypeValue;
	protected Label LabelInvoiceTitle;
	protected Label LabelInvoiceTitleValue;
	protected Label LabelNameInvoiceContent;
	protected Label LabelInvoiceContentValue;
	protected Label LabelOutOfStockOperate;
	protected Label LabelOutOfStockOperateValue;
	protected Label LabelClientToSellerMsg;
	protected Label LabelClientToSellerMsgValue;
	protected Label LabelSellerToClientMsg;
	protected Label LabelSellerToClientMsgValue;
	protected Label LabelUseScore;
	protected Label LabelUseScoreValue;
	protected Label Label31;
	protected Label LabelProductPrice;
	protected Label LabelProductPriceValue;
	protected Label LabelNameDiscount;
	protected Label LabelDiscountValue;
	protected Label LabelInvoiceTax;
	protected Label LabelInvoiceTaxValue;
	protected Label LabelDispatchPrice;
	protected Label LabelDispatchPriceValue;
	protected Label LabelPaymentPrice;
	protected Label LabelPaymentPriceValue;
	protected Label LabelOrderPrice;
	protected Label LabelOrderPriceValue;
	protected Label LabelAlreadPayPrice;
	protected Label LabelAlreadPayPriceValue;
	protected Label LabelSurplusPrice;
	protected Label LabelSurplusPriceValue;
	protected Label LabelScorePrice;
	protected Label LabelScorePriceValue;
	protected Label LabelShouldPayPrice;
	protected Label LabelShouldPayPriceValue;
	protected Button ButtonReport;
	protected Label Label14;
	protected Label LabelName;
	protected Label LabelNameValue;
	protected Label LabelEmail;
	protected Label LabelEmailValue;
	protected Label LabelAddress;
	protected Label LabelAddressValue;
	protected Label LabelPostalcode;
	protected Label LabelPostalcodeValue;
	protected Label LabelTel;
	protected Label LabelTelValue;
	protected Label LabelMobile;
	protected Label LabelMobileValue;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldAllWeight;
	protected HiddenField HiddenFieldBuyType;
	protected HiddenField HiddenFieldDeposit;
	protected HiddenField HiddenFieldIsPayDeposit;
	protected HiddenField HiddenFieldActivityGuid;
	protected HtmlForm form1;
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	private string string_12 = string.Empty;
	[CompilerGenerated]
	private string string_13;
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
	public string OrganizGuid
	{
		get;
		set;
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			this.GetOrderInfo();
			this.GetOrderProduct();
			this.GetOrderProductRepeter();
		}
	}
	protected void GetOrderInfo()
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
		DataTable dataTable = shopNum1_OrderInfo_Action.Search(this.hiddenFieldGuid.Value);
		this.LabelOrderNumberValue.Text = dataTable.Rows[0]["OrderNumber"].ToString();
		string text = string.Empty;
		text = this.ChangeOderStatus(dataTable.Rows[0]["OderStatus"].ToString());
		this.LabelOderStatusValue.Text = text;
		this.LabelCreateTimeValue.Text = dataTable.Rows[0]["CreateTime"].ToString();
		this.LabelPaymentNameValue.Text = dataTable.Rows[0]["PaymentName"].ToString();
		this.LabelPayTimeValue.Text = dataTable.Rows[0]["PayTime"].ToString();
		if (dataTable.Rows[0]["DispatchType"].ToString() == "1")
		{
			this.LabelDispatchModeNameValue.Text = "平邮";
		}
		else if (dataTable.Rows[0]["DispatchType"].ToString() == "2")
		{
			this.LabelDispatchModeNameValue.Text = "快递";
		}
		else
		{
			this.LabelDispatchModeNameValue.Text = "Ems";
		}
		this.LabelDispatchTimeValue.Text = dataTable.Rows[0]["DispatchTime"].ToString();
		this.LabelShipmentNumberValue.Text = dataTable.Rows[0]["ShipmentNumber"].ToString();
		this.LabelFromUrlValue.Text = dataTable.Rows[0]["FromUrl"].ToString();
		this.LabelInvoiceTypeValue.Text = dataTable.Rows[0]["InvoiceType"].ToString();
		this.LabelInvoiceTitleValue.Text = dataTable.Rows[0]["InvoiceTitle"].ToString();
		this.LabelInvoiceContentValue.Text = dataTable.Rows[0]["InvoiceContent"].ToString();
		this.LabelClientToSellerMsgValue.Text = dataTable.Rows[0]["ClientToSellerMsg"].ToString();
		this.LabelOutOfStockOperateValue.Text = dataTable.Rows[0]["OutOfStockOperate"].ToString();
		this.LabelSellerToClientMsgValue.Text = dataTable.Rows[0]["SellerToClientMsg"].ToString();
		this.LabelNameValue.Text = dataTable.Rows[0]["Name"].ToString();
		this.LabelEmailValue.Text = dataTable.Rows[0]["Email"].ToString();
		this.LabelAddressValue.Text = dataTable.Rows[0]["Address"].ToString();
		this.LabelPostalcodeValue.Text = dataTable.Rows[0]["Postalcode"].ToString();
		this.LabelTelValue.Text = dataTable.Rows[0]["Tel"].ToString();
		this.LabelMobileValue.Text = dataTable.Rows[0]["Mobile"].ToString();
		this.LabelProductPriceValue.Text = dataTable.Rows[0]["ProductPrice"].ToString();
		this.LabelDiscountValue.Text = dataTable.Rows[0]["Discount"].ToString();
		this.LabelInvoiceTaxValue.Text = dataTable.Rows[0]["InvoiceTax"].ToString();
		this.LabelDispatchPriceValue.Text = dataTable.Rows[0]["DispatchPrice"].ToString();
		string a = dataTable.Rows[0]["IsPercent"].ToString();
		if (a == "0")
		{
			this.LabelPaymentPriceValue.Text = dataTable.Rows[0]["PaymentPrice"].ToString();
		}
		else
		{
			this.LabelPaymentPriceValue.Text = ((Convert.ToDecimal(this.LabelProductPriceValue.Text) + Convert.ToDecimal(this.LabelDiscountValue.Text) + Convert.ToDecimal(this.LabelInvoiceTaxValue.Text) + Convert.ToDecimal(this.LabelDispatchPriceValue.Text)) * Convert.ToDecimal(dataTable.Rows[0]["PaymentPrice"].ToString()) / 100m).ToString();
		}
		this.LabelShopIDValue.Text = dataTable.Rows[0]["ShopID"].ToString();
		this.LabelShopNameValue.Text = dataTable.Rows[0]["ShopName"].ToString();
		this.LabelMemLoginIDValueShow.Text = dataTable.Rows[0]["MemLoginID"].ToString();
		this.LabelMemLoginIDValue.Text = dataTable.Rows[0]["MemLoginID"].ToString();
		string orderPrice = string.Concat(new string[]
		{
			this.LabelProductPriceValue.Text,
			"-",
			this.LabelDiscountValue.Text,
			"+",
			this.LabelInvoiceTaxValue.Text,
			"+",
			this.LabelDispatchPriceValue.Text,
			"+",
			this.LabelPaymentPriceValue.Text
		});
		ShopNum1_Common_Action shopNum1_Common_Action = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
		this.LabelOrderPriceValue.Text = shopNum1_Common_Action.ComputeOderPrice(orderPrice);
		this.LabelAlreadPayPriceValue.Text = dataTable.Rows[0]["AlreadPayPrice"].ToString();
		this.LabelSurplusPriceValue.Text = dataTable.Rows[0]["SurplusPrice"].ToString();
		this.LabelScorePriceValue.Text = dataTable.Rows[0]["ScorePrice"].ToString();
		this.LabelShouldPayPriceValue.Text = dataTable.Rows[0]["ShouldPayPrice"].ToString();
		this.LabelUseScoreValue.Text = dataTable.Rows[0]["UseScore"].ToString();
		this.HiddenFieldDeposit.Value = dataTable.Rows[0]["Deposit"].ToString();
		this.HiddenFieldBuyType.Value = dataTable.Rows[0]["BuyType"].ToString();
		this.HiddenFieldActivityGuid.Value = dataTable.Rows[0]["ActivityGuid"].ToString();
		if (this.HiddenFieldBuyType.Value == "0" || !(this.HiddenFieldBuyType.Value == "1"))
		{
		}
	}
	protected void GetOrderProduct()
	{
		ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
		DataTable dataTable = shopNum1_OrderProduct_Action.Search(this.hiddenFieldGuid.Value);
		this.Num1GridViewShowOrderProduct.DataSource = dataTable.DefaultView;
		this.Num1GridViewShowOrderProduct.DataBind();
	}
	protected void GetOrderProductRepeter()
	{
		ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
		DataTable dataTable = shopNum1_OrderProduct_Action.Search(this.hiddenFieldGuid.Value);
		this.RepeaterData.DataSource = dataTable.DefaultView;
		this.RepeaterData.DataBind();
	}
	protected void GetEmailSetting()
	{
		ShopSettings shopSettings = new ShopSettings();
		this.string_5 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailServer"));
		this.string_6 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "SMTP"));
		this.string_8 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ServerPort"));
		this.string_7 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailAccount"));
		this.string_9 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailPassword"));
		this.string_10 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "RestoreEmail"));
		this.string_11 = this.Page.Server.HtmlDecode(shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "EmailCode"));
	}
	protected ShopNum1_EmailGroupSend Add(string memLoginID, string email, int state)
	{
		return new ShopNum1_EmailGroupSend
		{
			Guid = Guid.NewGuid(),
			EmailTitle = this.string_12,
			CreateTime = DateTime.Now,
			EmailGuid = new Guid("7C367402-4219-46B7-BC48-72CF48F6A836"),
			SendObjectEmail = email,
			SendObject = memLoginID + "-" + email,
			State = state
		};
	}
	public string ChangeOderStatus(string oderStatus)
	{
		string result;
		if (oderStatus == "0")
		{
			result = "等待买家付款";
		}
		else if (oderStatus == "1")
		{
			result = "等待卖家发货";
		}
		else if (oderStatus == "2")
		{
			result = "等待买家确认收货";
		}
		else if (oderStatus == "3")
		{
			result = "交易成功";
		}
		else if (oderStatus == "4")
		{
			result = "系统关闭订单";
		}
		else if (oderStatus == "5")
		{
			result = "卖家关闭订单";
		}
		else if (oderStatus == "6")
		{
			result = "买家关闭订单";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	public string ChangePaymentStatus(string paymentStatus)
	{
		string result;
		if (paymentStatus == "0")
		{
			result = "未付款";
		}
		else if (paymentStatus == "1")
		{
			result = "已付款";
		}
		else if (paymentStatus == "2")
		{
			result = "退款成功";
		}
		else if (paymentStatus == "3")
		{
			result = "卖家拒绝退款";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	public string ChangeShipmentStatus(string shipmentStatus)
	{
		string result;
		if (shipmentStatus == "0")
		{
			result = "未发货";
		}
		else if (shipmentStatus == "1")
		{
			result = "已发货";
		}
		else if (shipmentStatus == "2")
		{
			result = "已收货";
		}
		else if (shipmentStatus == "3")
		{
			result = "退货";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected void Num1GridViewShowOrderProduct_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[8].Text = (Convert.ToDecimal(e.Row.Cells[6].Text) * Convert.ToInt32(e.Row.Cells[7].Text)).ToString();
		}
		if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
		{
			e.Row.Cells[9].Visible = false;
			e.Row.Cells[10].Visible = false;
		}
	}
	protected void ButtonReport_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OrderInfo_Report.aspx?OrderNumber=" + this.LabelOrderNumberValue.Text);
	}
	protected void GetAllProductWeight()
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
		DataTable orderProductGuidAndByNumber = shopNum1_OrderInfo_Action.GetOrderProductGuidAndByNumber(this.LabelOrderNumberValue.Text);
		ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
		this.HiddenFieldAllWeight.Value = "0.00";
		for (int i = 0; i < orderProductGuidAndByNumber.Rows.Count; i++)
		{
			string guid = orderProductGuidAndByNumber.Rows[i]["ProductGuid"].ToString();
			string value = orderProductGuidAndByNumber.Rows[i]["BuyNumber"].ToString();
			string weight = shopNum1_OrderProduct_Action.GetWeight(guid);
			this.HiddenFieldAllWeight.Value = Convert.ToString(Convert.ToDecimal(this.HiddenFieldAllWeight.Value) + Convert.ToDecimal(value) * Convert.ToDecimal(weight));
		}
	}
	protected int CheckMember()
	{
		int result = 0;
		try
		{
			Guid guid = new Guid(this.LabelMemLoginIDValue.Text);
		}
		catch
		{
			result = 1;
		}
		return result;
	}
	private string method_5(string string_14)
	{
		string result = string.Empty;
		Encoding encoding = Encoding.GetEncoding("utf-8");
		WebRequest webRequest = WebRequest.Create(string_14);
		try
		{
			WebResponse response = webRequest.GetResponse();
			StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
			result = streamReader.ReadToEnd();
		}
		catch (Exception)
		{
			result = "";
		}
		return result;
	}
}
