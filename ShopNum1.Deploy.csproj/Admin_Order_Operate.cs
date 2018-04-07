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
public class Admin_Order_Operate : PageBase, IRequiresSessionState
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
	protected Label LabelOrderRefundStatus;
	protected Label LabelOrderRefundStatusValue;
	protected Label LabelShopNotAgreedRefund;
	protected Label LabelShopNotAgreedRefundValue;
	protected HtmlImage imgRefund;
	protected Label LabelAdminoperation;
	protected Button ButtonAdminAgreed;
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
	protected Label Label9;
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
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldAllWeight;
	protected HiddenField HiddenFieldBuyType;
	protected HiddenField hiddenFieldType;
	protected HiddenField HiddenFieldDeposit;
	protected HiddenField HiddenFieldIsPayDeposit;
	protected HiddenField HiddenFieldActivityGuid;
	protected HtmlInputHidden hidRefundMoney;
	protected HtmlInputHidden hidProductGuId;
	protected HtmlInputHidden hidOnPassReason;
	protected HtmlInputHidden hidRefundImg;
	protected HtmlInputHidden hidrefundstatus;
	protected HtmlInputHidden hidRefundType;
	protected HtmlForm form1;
	private string string_5 = string.Empty;
	private string string_6 = string.Empty;
	private string string_7 = string.Empty;
	private string string_8 = string.Empty;
	private string string_9 = string.Empty;
	private string string_10 = string.Empty;
	private string string_11 = string.Empty;
	private string string_12 = string.Empty;
	public DataTable dataTableOrderInfo = null;
	public DataTable dt_OrderOperate = null;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		this.hiddenFieldType.Value = ((this.Page.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"]);
		this.GetOrderInfo();
		this.GetOrderProduct();
		this.GetOrderProductRepeter();
	}
	protected void GetOrderInfo()
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
		DataSet orderDetail = shopNum1_OrderInfo_Action.GetOrderDetail(this.hiddenFieldGuid.Value, "0", "0", "0");
		if (orderDetail != null && orderDetail.Tables.Count == 4)
		{
			this.dataTableOrderInfo = orderDetail.Tables[0];
			if (this.dataTableOrderInfo.Rows.Count == 0)
			{
				this.dataTableOrderInfo = null;
			}
			else
			{
				this.dt_OrderOperate = orderDetail.Tables[2];
				if (this.dt_OrderOperate.Rows.Count == 0)
				{
					this.dt_OrderOperate = null;
				}
				this.LabelOrderNumberValue.Text = this.dataTableOrderInfo.Rows[0]["OrderNumber"].ToString();
				string text = string.Empty;
				text = this.ChangeOderStatus(this.dataTableOrderInfo.Rows[0]["OderStatus"].ToString());
				this.LabelOderStatusValue.Text = text;
				this.LabelCreateTimeValue.Text = this.dataTableOrderInfo.Rows[0]["CreateTime"].ToString();
				this.LabelPaymentNameValue.Text = this.dataTableOrderInfo.Rows[0]["PaymentName"].ToString();
				this.LabelPayTimeValue.Text = this.dataTableOrderInfo.Rows[0]["PayTime"].ToString();
				if (Convert.ToInt32(this.dataTableOrderInfo.Rows[0]["OderStatus"].ToString()) > 1)
				{
					if (this.dataTableOrderInfo.Rows[0]["DispatchType"].ToString() == "1")
					{
						this.LabelDispatchModeNameValue.Text = "平邮";
					}
					else if (this.dataTableOrderInfo.Rows[0]["DispatchType"].ToString() == "2")
					{
						this.LabelDispatchModeNameValue.Text = "快递";
					}
					else
					{
						this.LabelDispatchModeNameValue.Text = "买家自提货";
					}
				}
				this.LabelDispatchTimeValue.Text = this.dataTableOrderInfo.Rows[0]["DispatchTime"].ToString();
				this.LabelShipmentNumberValue.Text = this.dataTableOrderInfo.Rows[0]["ShipmentNumber"].ToString();
				this.LabelFromUrlValue.Text = this.dataTableOrderInfo.Rows[0]["FromUrl"].ToString();
				this.LabelInvoiceTypeValue.Text = this.dataTableOrderInfo.Rows[0]["InvoiceType"].ToString();
				this.LabelInvoiceTitleValue.Text = this.dataTableOrderInfo.Rows[0]["InvoiceTitle"].ToString();
				this.LabelInvoiceContentValue.Text = this.dataTableOrderInfo.Rows[0]["InvoiceContent"].ToString();
				this.LabelClientToSellerMsgValue.Text = this.dataTableOrderInfo.Rows[0]["ClientToSellerMsg"].ToString();
				this.LabelOutOfStockOperateValue.Text = this.dataTableOrderInfo.Rows[0]["OutOfStockOperate"].ToString();
				this.LabelSellerToClientMsgValue.Text = this.dataTableOrderInfo.Rows[0]["SellerToClientMsg"].ToString();
				this.LabelNameValue.Text = this.dataTableOrderInfo.Rows[0]["Name"].ToString();
				this.LabelEmailValue.Text = this.dataTableOrderInfo.Rows[0]["Email"].ToString();
				this.LabelAddressValue.Text = this.dataTableOrderInfo.Rows[0]["Address"].ToString();
				this.LabelPostalcodeValue.Text = this.dataTableOrderInfo.Rows[0]["Postalcode"].ToString();
				this.LabelTelValue.Text = this.dataTableOrderInfo.Rows[0]["Tel"].ToString();
				this.LabelMobileValue.Text = this.dataTableOrderInfo.Rows[0]["Mobile"].ToString();
				this.LabelProductPriceValue.Text = this.dataTableOrderInfo.Rows[0]["ProductPrice"].ToString();
				this.LabelDiscountValue.Text = this.dataTableOrderInfo.Rows[0]["Discount"].ToString();
				this.LabelInvoiceTaxValue.Text = this.dataTableOrderInfo.Rows[0]["InvoiceTax"].ToString();
				this.LabelDispatchPriceValue.Text = this.dataTableOrderInfo.Rows[0]["DispatchPrice"].ToString();
				this.LabelPaymentPriceValue.Text = this.dataTableOrderInfo.Rows[0]["PaymentPrice"].ToString();
				string a = this.dataTableOrderInfo.Rows[0]["paymentmemloginid"].ToString();
				if (a == "admin")
				{
					this.LabelPaymentPriceValue.Text = this.dataTableOrderInfo.Rows[0]["PaymentPrice"].ToString();
				}
				else
				{
					this.LabelPaymentPriceValue.Text = ((Convert.ToDecimal(this.LabelProductPriceValue.Text) + Convert.ToDecimal(this.LabelDiscountValue.Text) + Convert.ToDecimal(this.LabelInvoiceTaxValue.Text) + Convert.ToDecimal(this.LabelDispatchPriceValue.Text)) * Convert.ToDecimal(this.dataTableOrderInfo.Rows[0]["PaymentPrice"].ToString()) / 100m).ToString();
				}
				this.LabelShopIDValue.Text = this.dataTableOrderInfo.Rows[0]["ShopID"].ToString();
				this.LabelShopNameValue.Text = this.dataTableOrderInfo.Rows[0]["ShopName"].ToString();
				this.LabelMemLoginIDValueShow.Text = this.dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
				this.LabelMemLoginIDValue.Text = this.dataTableOrderInfo.Rows[0]["MemLoginID"].ToString();
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
				this.LabelUseScoreValue.Text = this.dataTableOrderInfo.Rows[0]["UseScore"].ToString();
				this.HiddenFieldDeposit.Value = this.dataTableOrderInfo.Rows[0]["Deposit"].ToString();
				this.HiddenFieldBuyType.Value = this.dataTableOrderInfo.Rows[0]["BuyType"].ToString();
				this.HiddenFieldActivityGuid.Value = this.dataTableOrderInfo.Rows[0]["ActivityGuid"].ToString();
				if (this.HiddenFieldBuyType.Value == "0" || !(this.HiddenFieldBuyType.Value == "1"))
				{
				}
				ShopNum1_Refund_Action shopNum1_Refund_Action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
				DataTable refund = shopNum1_Refund_Action.GetRefund(this.hiddenFieldGuid.Value);
				if (refund != null && refund.Rows.Count > 0)
				{
					this.hidRefundMoney.Value = refund.Rows[0]["RefundMoney"].ToString();
					this.hidProductGuId.Value = refund.Rows[0]["ProductGuid"].ToString();
					this.hidOnPassReason.Value = refund.Rows[0]["OnPassReason"].ToString();
					this.hidRefundImg.Value = refund.Rows[0]["OnPassImg"].ToString();
					this.hidrefundstatus.Value = refund.Rows[0]["refundstatus"].ToString();
					this.hidRefundType.Value = refund.Rows[0]["RefundType"].ToString();
					this.LabelShopNotAgreedRefundValue.Text = this.hidOnPassReason.Value;
					this.LabelOrderRefundStatusValue.Text = this.RefundStatus(this.hidrefundstatus.Value, this.hidRefundType.Value);
					this.imgRefund.Visible = true;
					this.imgRefund.Src = this.hidRefundImg.Value;
				}
			}
		}
	}
	protected string RefundStatus(string status, string rtype)
	{
		string text = "退款";
		if (rtype == "1")
		{
			text = "退货";
		}
		string result;
		if (status != null)
		{
			if (status == "0")
			{
				this.ButtonAdminAgreed.Visible = true;
				result = text + "申请等待卖家确认中";
				return result;
			}
			if (status == "1")
			{
				result = text + "成功";
				return result;
			}
			if (status == "2")
			{
				this.ButtonAdminAgreed.Visible = true;
				result = "卖家拒绝" + text;
				return result;
			}
			if (status == "3")
			{
				result = "平台介入" + text + "成功";
				return result;
			}
		}
		result = "";
		return result;
	}
	protected void ButtonAdminAgreed_Click(object sender, EventArgs e)
	{
		ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
		DataTable dataTable = shopNum1_OrderInfo_Action.Search(this.hiddenFieldGuid.Value);
		if (dataTable.Rows.Count > 0)
		{
			string value = this.hidRefundMoney.Value;
			string value2 = this.hidProductGuId.Value;
			string text = dataTable.Rows[0]["MemLoginID"].ToString();
			string text2 = dataTable.Rows[0]["ShopID"].ToString();
			if (dataTable.Rows[0]["OderStatus"].ToString() == "4" || dataTable.Rows[0]["OderStatus"].ToString() == "5")
			{
				MessageBox.Show("订单已经关闭，请勿重复操作！");
				return;
			}
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			shopNum1_OrderInfo_Action2.SetWaitBuyerPay("4", "0", "1", this.hiddenFieldGuid.Value);
			string nameById = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='" + text + "'");
			string nameById2 = Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='" + text2 + "'");
			this.AdvancePaymentModify(text, text2, Convert.ToDecimal(value), this.hiddenFieldGuid.Value, value2);
			decimal d = Convert.ToDecimal(this.LabelOrderPriceValue.Text);
			if (!string.IsNullOrEmpty(nameById))
			{
				this.AdvancePaymentModifyLog(5, Convert.ToDecimal(nameById), Convert.ToDecimal(value), "平台介入退款成功增加买家预存款", text, 1);
				if (d > Convert.ToDecimal(value))
				{
					decimal payMoney = d - Convert.ToDecimal(value);
					this.AdvancePaymentModifyLog(5, Convert.ToDecimal(nameById2), payMoney, "平台介入退款成功剩余金额打给卖家", text2, 1);
				}
			}
			ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
			shopNum1_OrderProduct_Action.UpdateReduceStock(this.hiddenFieldGuid.Value, "1");
			ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
			shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
			{
				Guid = Guid.NewGuid(),
				OrderInfoGuid = new Guid(this.hiddenFieldGuid.Value),
				CreateUser = text,
				OderStatus = 2,
				ShipmentStatus = 1,
				PaymentStatus = 1,
				CurrentStateMsg = "平台介入同意退款",
				NextStateMsg = "无",
				Memo = "",
				OperateDateTime = DateTime.Now,
				IsDeleted = 0
			});
		}
		this.Page.Response.Redirect("Order_Operate.aspx?guid=" + this.hiddenFieldGuid.Value);
	}
	public void AdvancePaymentModify(string MemLoginID, string shopid, decimal AddPrice, string orderguid, string productguid)
	{
		ShopNum1_Refund_Action shopNum1_Refund_Action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
		int num = shopNum1_Refund_Action.RefundUpdateAdvancePaymentMem(MemLoginID, shopid, AddPrice, orderguid, productguid, 3);
		if (num > 0)
		{
			MessageBox.Show("退款成功！");
			this.GetOrderInfo();
		}
		else
		{
			MessageBox.Show("退款失败！");
		}
	}
	public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, int type)
	{
		ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
		shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
		shopNum1_AdvancePaymentModifyLog.OperateType = OperateType;
		shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = AdvancePayments;
		shopNum1_AdvancePaymentModifyLog.OperateMoney = payMoney;
		if (type == 1)
		{
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments + payMoney;
		}
		else
		{
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
		}
		shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
		shopNum1_AdvancePaymentModifyLog.Memo = Memo;
		shopNum1_AdvancePaymentModifyLog.MemLoginID = shopMemloginID;
		shopNum1_AdvancePaymentModifyLog.CreateUser = shopMemloginID;
		shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
		shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
		ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
		shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
	}
	protected void GetOrderProduct()
	{
		if (this.dataTableOrderInfo != null)
		{
			this.Num1GridViewShowOrderProduct.DataSource = this.dataTableOrderInfo.DefaultView;
			this.Num1GridViewShowOrderProduct.DataBind();
		}
	}
	protected void GetOrderProductRepeter()
	{
		if (this.dataTableOrderInfo != null)
		{
			this.RepeaterData.DataSource = this.dataTableOrderInfo.DefaultView;
			this.RepeaterData.DataBind();
		}
	}
	private void method_5(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldIsImage");
			Image image = (Image)e.Item.FindControl("ImageUrl");
			Label label = (Label)e.Item.FindControl("LabelValue");
			if (hiddenField.Value == "True")
			{
				label.Visible = false;
			}
			else
			{
				image.Visible = false;
			}
		}
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
			e.Row.Cells[5].Text = "1000";
		}
		if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
		{
			e.Row.Cells[9].Visible = false;
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
	private string method_6(string string_14)
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
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldType.Value == "1")
		{
			base.Response.Redirect("Order_List.aspx");
		}
		else if (this.hiddenFieldType.Value == "2")
		{
			base.Response.Redirect("OrderSpell_List.aspx");
		}
		else if (this.hiddenFieldType.Value == "3")
		{
			base.Response.Redirect("OrderPanic_List.aspx");
		}
		else
		{
			base.Response.Redirect("Order_List.aspx");
		}
	}
}
