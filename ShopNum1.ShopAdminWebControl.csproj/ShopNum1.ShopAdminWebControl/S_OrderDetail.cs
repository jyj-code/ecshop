using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.KuaiDi;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_OrderDetail : BaseShopWebControl
	{
		private string string_0 = "S_OrderDetail.ascx";
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		private HtmlInputHidden htmlInputHidden_5;
		private HtmlInputHidden htmlInputHidden_6;
		private HtmlInputHidden htmlInputHidden_7;
		private HtmlInputHidden htmlInputHidden_8;
		private HtmlInputHidden htmlInputHidden_9;
		private HtmlInputHidden htmlInputHidden_10;
		private HtmlInputHidden htmlInputHidden_11;
		private HtmlInputHidden htmlInputHidden_12;
		private HtmlInputHidden htmlInputHidden_13;
		private HtmlInputHidden htmlInputHidden_14;
		private HtmlInputHidden htmlInputHidden_15;
		private HtmlInputHidden htmlInputHidden_16;
		private HtmlInputHidden htmlInputHidden_17;
		private HtmlInputHidden htmlInputHidden_18;
		private HtmlInputHidden htmlInputHidden_19;
		private HtmlInputText htmlInputText_0;
		private HtmlInputHidden htmlInputHidden_20;
		private HtmlInputHidden htmlInputHidden_21;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private Label label_9;
		private Label label_10;
		private Label label_11;
		private Label label_12;
		private Label label_13;
		private Label label_14;
		private Label label_15;
		private Label label_16;
		private Label label_17;
		private Label label_18;
		private Label label_19;
		private Label label_20;
		private Label label_21;
		private Label label_22;
		private Label label_23;
		public static DataTable dt_OrderInfo = null;
		public static DataTable dt_OrderOperate = null;
		private DataTable dataTable_0 = null;
		private HtmlGenericControl htmlGenericControl_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		public string strOrderGuId
		{
			get;
			set;
		}
		public string strOderState
		{
			get;
			set;
		}
		public string strOrderType
		{
			get;
			set;
		}
		public string strCreateTime
		{
			get;
			set;
		}
		public string strPayTime
		{
			get;
			set;
		}
		public S_OrderDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_20 = (Label)skin.FindControl("LabelInvoiceTypeValue");
			this.label_21 = (Label)skin.FindControl("LabelInvoiceTitleValue");
			this.label_22 = (Label)skin.FindControl("LabelInvoiceContentValue");
			this.linkButton_0 = (LinkButton)skin.FindControl("butFahuo");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("btnSureConfirm");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("LogisticInfo");
			this.label_0 = (Label)skin.FindControl("lblSetOrderTime");
			this.label_1 = (Label)skin.FindControl("lblPayMentTime");
			this.label_2 = (Label)skin.FindControl("lblSendGoodsTime");
			this.label_3 = (Label)skin.FindControl("lblConfirmOrderTime");
			this.label_4 = (Label)skin.FindControl("lblMemLoginId");
			this.label_5 = (Label)skin.FindControl("lblTrueName");
			this.label_6 = (Label)skin.FindControl("lblAreaName");
			this.label_7 = (Label)skin.FindControl("lblMoible");
			this.label_8 = (Label)skin.FindControl("lblEmail");
			this.label_9 = (Label)skin.FindControl("lblOrderNumber");
			this.label_10 = (Label)skin.FindControl("lblOrderStateTxt");
			this.label_11 = (Label)skin.FindControl("lblOrderDate");
			this.label_12 = (Label)skin.FindControl("lblReceiveAddress");
			this.label_13 = (Label)skin.FindControl("lbllogisticType");
			this.label_14 = (Label)skin.FindControl("lblLogisticsCompany");
			this.label_15 = (Label)skin.FindControl("lblShipmentNumber");
			this.label_16 = (Label)skin.FindControl("lblBuyerMsg");
			this.label_17 = (Label)skin.FindControl("lblSellerMsg");
			this.label_19 = (Label)skin.FindControl("lblDispatch");
			this.label_18 = (Label)skin.FindControl("lblShouldPrice");
			this.label_23 = (Label)skin.FindControl("lblSureDays");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtlifeCode");
			this.linkButton_2 = (LinkButton)skin.FindControl("btnLifeFahuo");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidOrderGuId");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidOrderState");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidislogistic");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidlogisitcnumber");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidlogisticCompany");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidPayState");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidShipState");
			this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("hidRefundstatus");
			this.htmlInputHidden_9 = (HtmlInputHidden)skin.FindControl("hidOrderProductId");
			this.htmlInputHidden_8 = (HtmlInputHidden)skin.FindControl("hidShouldPayPrice");
			this.htmlInputHidden_10 = (HtmlInputHidden)skin.FindControl("hidPaymentPrice");
			this.htmlInputHidden_11 = (HtmlInputHidden)skin.FindControl("hidMemloginId");
			this.htmlInputHidden_12 = (HtmlInputHidden)skin.FindControl("hidDispatchPrice");
			this.htmlInputHidden_13 = (HtmlInputHidden)skin.FindControl("hidOrderPay");
			this.htmlInputHidden_14 = (HtmlInputHidden)skin.FindControl("hidPayMentName");
			this.htmlInputHidden_15 = (HtmlInputHidden)skin.FindControl("hidExpiresTime");
			this.htmlInputHidden_16 = (HtmlInputHidden)skin.FindControl("hidlifetype");
			this.htmlInputHidden_17 = (HtmlInputHidden)skin.FindControl("hidEndTime");
			this.htmlInputHidden_18 = (HtmlInputHidden)skin.FindControl("hidCheckCode");
			this.htmlInputHidden_20 = (HtmlInputHidden)skin.FindControl("hidBuyNum");
			this.htmlInputHidden_21 = (HtmlInputHidden)skin.FindControl("hidShopPrice");
			this.htmlInputHidden_19 = (HtmlInputHidden)skin.FindControl("hidRefundType");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			string arg_16_0 = this.htmlInputHidden_0.Value;
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			string a;
			string text;
			string text2;
			string text3;
			if (this.htmlInputHidden_2.Value == "1")
			{
				a = "1";
				text = this.htmlInputHidden_4.Value.Split(new char[]
				{
					'|'
				})[0];
				text2 = this.htmlInputHidden_4.Value.Split(new char[]
				{
					'|'
				})[1];
				text3 = this.htmlInputHidden_3.Value;
			}
			else
			{
				a = "0";
				text = "";
				text2 = "";
				text3 = "";
			}
			this.label_14.Text = text;
			this.label_15.Text = text3;
			if (a == "1" && text != "其它")
			{
				string kuaicom = text2;
				string kuainum = text3;
				ShopNum1_KuaiDiRequest shopNum1_KuaiDiRequest = new ShopNum1_KuaiDiRequest();
				string kuaidiInfo = shopNum1_KuaiDiRequest.GetKuaidiInfo(kuaicom, kuainum, "");
				if (kuaidiInfo.IndexOf("不正确") != -1 || kuaidiInfo.IndexOf("错误") != -1)
				{
					MessageBox.Show("快递单号无法匹配对应的快递信息！");
					this.method_0();
					return;
				}
			}
			string partner = string.Empty;
			ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
			DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay.aspx");
			if (paymentKey.Rows.Count > 0)
			{
				partner = paymentKey.Rows[0]["MerchantCode"].ToString();
				DataTable dataTable = shopNum1_OrderInfo_Action2.Search1(ShopNum1.Common.Common.ReqStr("guid"));
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					string trade_no = dataTable.Rows[0]["AlipayTradeId"].ToString();
					if (dataTable.Rows[0]["paymentname"].ToString() == "支付宝担保交易")
					{
						PayUrlOperate payUrlOperate = new PayUrlOperate();
						string text4 = payUrlOperate.ConfimSendProduct(partner, trade_no, text, text3);
						XmlDocument xmlDocument = new XmlDocument();
						try
						{
							xmlDocument.LoadXml(text4);
							string a2 = xmlDocument.SelectSingleNode("//is_success").InnerText.ToString();
							if (a2 == "T")
							{
								MessageBox.Show("发货成功！");
							}
						}
						catch (Exception)
						{
							this.Page.Response.Write(text4);
						}
					}
				}
			}
			string value = this.htmlInputHidden_9.Value;
			decimal d = 0m;
			decimal num = 0m;
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			string memLoginID = this.MemLoginID;
			decimal num2 = Convert.ToDecimal(this.htmlInputHidden_8.Value);
			decimal num3 = Convert.ToDecimal(num2);
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			if (value != "")
			{
				string value2 = this.htmlInputHidden_20.Value;
				int num4 = 1;
				if (value.IndexOf(",") != -1)
				{
					num4 = value.Split(new char[]
					{
						','
					}).Length;
				}
				string text5 = this.htmlInputHidden_21.Value;
				for (int i = 0; i < num4; i++)
				{
					int value3;
					if (value2.IndexOf(",") != -1)
					{
						value3 = Convert.ToInt32(value2.Split(new char[]
						{
							','
						})[i]);
					}
					else
					{
						value3 = Convert.ToInt32(value2);
					}
					if (text5.IndexOf(",") != -1)
					{
						text5 = text5.Split(new char[]
						{
							','
						})[i];
					}
					string text6 = shopNum1_ProductCategory_Action.strVScale(value.Split(new char[]
					{
						','
					})[i].ToString());
					if (ShopSettings.GetValue("IsShopProductFcRate") == "true" && Convert.ToDecimal(text5) < num2)
					{
						flag3 = false;
						if (text6 != "" && text6.IndexOf("|") != -1 && text6.Split(new char[]
						{
							'|'
						})[1] == "1")
						{
							decimal d2 = decimal.Parse(text6.Split(new char[]
							{
								'|'
							})[0]) / 100m;
							num += Convert.ToDecimal(text5) * d2 * value3;
							flag = false;
							flag2 = false;
						}
					}
				}
				if (flag2 && ShopSettings.GetValue("IsShopProductFcRate") == "true" && !flag3)
				{
					decimal d2 = decimal.Parse(ShopSettings.GetValue("AdminProductFcRate")) / 100m;
					num = Convert.ToDecimal((num2 - Convert.ToDecimal(this.htmlInputHidden_12.Value) - Convert.ToDecimal(this.htmlInputHidden_10.Value)) * d2);
				}
			}
			string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='" + memLoginID + "'");
			if (nameById != "")
			{
				decimal advancePayments = Convert.ToDecimal(nameById);
				if (ShopSettings.GetValue("IsOrderCommission") == "true")
				{
					decimal d3 = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100m;
					if (ShopSettings.GetValue("IsShopProductFcRate") == "true" && flag && !flag3)
					{
						num += (num2 - Convert.ToDecimal(this.htmlInputHidden_10.Value)) * d3;
					}
					else if (!flag3)
					{
						num = (num2 - Convert.ToDecimal(this.htmlInputHidden_10.Value)) * d3;
					}
				}
				num3 = Convert.ToDecimal(num2 - (d + num)) - Convert.ToDecimal(this.htmlInputHidden_10.Value);
				if (ShopSettings.GetValue("IsOrderCommission") != "true" && ShopSettings.GetValue("IsShopProductFcRate") != "true")
				{
					num3 = num2;
				}
				if (this.htmlInputHidden_14.Value.IndexOf("线下") == -1 && this.htmlInputHidden_14.Value.IndexOf("货到付款") == -1 && shopNum1_Member_Action.UpdateAdvancePayment(0, memLoginID, num3) > 0)
				{
					this.AdvancePaymentModifyLog(4, advancePayments, num3, "会员确认收货，增加店铺预存款", memLoginID, DateTime.Now, 1);
				}
				int num5 = shopNum1_OrderInfo_Action.SetOderStatus1(this.htmlInputHidden_0.Value, 3, 1, 2, DateTime.Now);
				if (num5 > 0)
				{
					if (this.htmlInputHidden_14.Value == "线下支付" || this.htmlInputHidden_14.Value == "货到付款")
					{
						shopNum1_OrderProduct_Action.UpdateStock(this.htmlInputHidden_0.Value);
					}
					ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
					shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
					{
						Guid = Guid.NewGuid(),
						OrderInfoGuid = new Guid(this.htmlInputHidden_0.Value),
						CreateUser = this.MemLoginID,
						OderStatus = 3,
						ShipmentStatus = 2,
						PaymentStatus = 1,
						CurrentStateMsg = "买家已消费,交易完成",
						NextStateMsg = "等待买家评价",
						Memo = "",
						OperateDateTime = DateTime.Now,
						IsDeleted = 0
					});
					this.method_0();
				}
				else
				{
					MessageBox.Show("发货失败！");
				}
			}
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			string value = this.htmlInputHidden_9.Value;
			decimal d = 0m;
			decimal num = 0m;
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			string memLoginID = this.MemLoginID;
			decimal num2 = Convert.ToDecimal(this.htmlInputHidden_8.Value);
			decimal num3 = Convert.ToDecimal(num2);
			bool flag = true;
			bool flag2 = true;
			if (value != "")
			{
				string value2 = this.htmlInputHidden_20.Value;
				int num4 = 1;
				if (value.IndexOf(",") != -1)
				{
					num4 = value.Split(new char[]
					{
						','
					}).Length;
				}
				string text = this.htmlInputHidden_21.Value;
				for (int i = 0; i < num4; i++)
				{
					int value3;
					if (value2.IndexOf(",") != -1)
					{
						value3 = Convert.ToInt32(value2.Split(new char[]
						{
							','
						})[i]);
					}
					else
					{
						value3 = Convert.ToInt32(value2);
					}
					if (text.IndexOf(",") != -1)
					{
						text = text.Split(new char[]
						{
							','
						})[i];
					}
					string text2 = shopNum1_ProductCategory_Action.strVScale(value.Split(new char[]
					{
						','
					})[i].ToString());
					if (ShopSettings.GetValue("IsShopProductFcRate") == "true" && text2 != "" && text2.IndexOf("|") != -1 && text2.Split(new char[]
					{
						'|'
					})[1] == "1")
					{
						decimal d2 = decimal.Parse(text2.Split(new char[]
						{
							'|'
						})[0]) / 100m;
						num += Convert.ToDecimal(text) * d2 * value3;
						flag = false;
						flag2 = false;
					}
				}
				if (flag2 && ShopSettings.GetValue("IsShopProductFcRate") == "true")
				{
					decimal d2 = decimal.Parse(ShopSettings.GetValue("AdminProductFcRate")) / 100m;
					num = Convert.ToDecimal((num2 - Convert.ToDecimal(this.htmlInputHidden_12.Value) - Convert.ToDecimal(this.htmlInputHidden_10.Value)) * d2);
				}
			}
			string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='" + memLoginID + "'");
			if (nameById != "")
			{
				decimal advancePayments = Convert.ToDecimal(nameById);
				if (ShopSettings.GetValue("IsOrderCommission") == "true")
				{
					decimal d3 = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100m;
					if (ShopSettings.GetValue("IsShopProductFcRate") == "true" && flag)
					{
						num += (num2 - Convert.ToDecimal(this.htmlInputHidden_10.Value)) * d3;
					}
					else
					{
						num = (num2 - Convert.ToDecimal(this.htmlInputHidden_10.Value)) * d3;
					}
				}
				num3 = Convert.ToDecimal(num2 - (d + num)) - Convert.ToDecimal(this.htmlInputHidden_10.Value);
				if (ShopSettings.GetValue("IsOrderCommission") != "true" && ShopSettings.GetValue("IsShopProductFcRate") != "true")
				{
					num3 = num2;
				}
				if (this.htmlInputHidden_14.Value.IndexOf("线下") == -1 && this.htmlInputHidden_14.Value.IndexOf("货到付款") == -1 && shopNum1_Member_Action.UpdateAdvancePayment(0, memLoginID, num3) > 0)
				{
					this.AdvancePaymentModifyLog(4, advancePayments, num3, "会员确认收货，增加店铺预存款", memLoginID, DateTime.Now, 1);
				}
				if (this.htmlInputHidden_14.Value == "线下支付" || this.htmlInputHidden_14.Value == "货到付款")
				{
					shopNum1_OrderProduct_Action.UpdateStock(this.htmlInputHidden_0.Value);
				}
				shopNum1_OrderInfo_Action.SetOderStatus1(this.htmlInputHidden_0.Value, 3, 1, 2, DateTime.Now);
				ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
				shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
				{
					Guid = Guid.NewGuid(),
					OrderInfoGuid = new Guid(this.htmlInputHidden_0.Value),
					CreateUser = this.MemLoginID,
					OderStatus = 3,
					ShipmentStatus = 2,
					PaymentStatus = 1,
					CurrentStateMsg = "买家收货超时,卖家已经确认收货",
					NextStateMsg = "等待买家评价",
					Memo = "",
					OperateDateTime = DateTime.Now,
					IsDeleted = 0
				});
				this.method_0();
			}
		}
		public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type)
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
			shopNum1_AdvancePaymentModifyLog.Date = time;
			shopNum1_AdvancePaymentModifyLog.Memo = Memo;
			shopNum1_AdvancePaymentModifyLog.MemLoginID = shopMemloginID;
			shopNum1_AdvancePaymentModifyLog.CreateUser = shopMemloginID;
			shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(time);
			shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			string text;
			string text2;
			string text3;
			string text4;
			if (this.htmlInputHidden_2.Value == "1")
			{
				text = "1";
				text2 = this.htmlInputHidden_4.Value.Split(new char[]
				{
					'|'
				})[0];
				text3 = this.htmlInputHidden_4.Value.Split(new char[]
				{
					'|'
				})[1];
				text4 = this.htmlInputHidden_3.Value;
			}
			else
			{
				text = "0";
				text2 = "000";
				text3 = "000";
				text4 = "000";
			}
			if (text == "1" && text2 != "其它")
			{
				string kuaicom = text3;
				string kuainum = text4;
				ShopNum1_KuaiDiRequest shopNum1_KuaiDiRequest = new ShopNum1_KuaiDiRequest();
				string kuaidiInfo = shopNum1_KuaiDiRequest.GetKuaidiInfo(kuaicom, kuainum, "");
				if (kuaidiInfo.IndexOf("不正确") != -1 || kuaidiInfo.IndexOf("错误") != -1)
				{
					MessageBox.Show("快递单号无法匹配对应的快递信息！");
					this.method_0();
					return;
				}
			}
			string partner = string.Empty;
			ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
			DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay.aspx");
			if (paymentKey.Rows.Count > 0)
			{
				partner = paymentKey.Rows[0]["MerchantCode"].ToString();
				DataTable dataTable = shopNum1_OrderInfo_Action.Search1(ShopNum1.Common.Common.ReqStr("guid"));
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					string trade_no = dataTable.Rows[0]["AlipayTradeId"].ToString();
					if (dataTable.Rows[0]["paymentname"].ToString() == "支付宝担保交易")
					{
						PayUrlOperate payUrlOperate = new PayUrlOperate();
						string text5 = payUrlOperate.ConfimSendProduct(partner, trade_no, text2, text4);
						XmlDocument xmlDocument = new XmlDocument();
						try
						{
							xmlDocument.LoadXml(text5);
							string a = xmlDocument.SelectSingleNode("//is_success").InnerText.ToString();
							if (a == "T")
							{
								MessageBox.Show("发货成功！");
							}
						}
						catch (Exception)
						{
							this.Page.Response.Write(text5);
						}
					}
				}
			}
			int num = shopNum1_OrderInfo_Action.OrderInfoLogistics(this.htmlInputHidden_0.Value, text, text2, text3, text4);
			if (num > 0)
			{
				ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
				shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
				{
					Guid = Guid.NewGuid(),
					OrderInfoGuid = new Guid(this.htmlInputHidden_0.Value),
					CreateUser = this.MemLoginID,
					OderStatus = 2,
					ShipmentStatus = 1,
					PaymentStatus = 1,
					CurrentStateMsg = "卖家已经发货",
					NextStateMsg = "等待买家确认收货",
					Memo = "",
					OperateDateTime = DateTime.Now,
					IsDeleted = 0
				});
				try
				{
					if (ShopSettings.GetValue("ShipmentOKIsEmail") == "1")
					{
						this.IsEmail(this.htmlInputHidden_0.Value, "ShipmentOKIsEmail");
					}
					if (ShopSettings.GetValue("ShipmentIsMMS") == "1")
					{
						this.IsMMS(this.htmlInputHidden_0.Value, "ShipmentIsMMS");
					}
				}
				catch
				{
				}
				this.method_0();
			}
			else
			{
				MessageBox.Show("发货失败！");
			}
		}
		private void method_0()
		{
			this.strOrderGuId = ShopNum1.Common.Common.ReqStr("guid");
			this.htmlInputHidden_0.Value = this.strOrderGuId;
			this.strOrderType = ShopNum1.Common.Common.ReqStr("ordertype");
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataSet orderDetail = shopNum1_OrderInfo_Action.GetOrderDetail(this.strOrderGuId, this.MemLoginID, this.strOrderType, "1");
			if (orderDetail != null && orderDetail.Tables.Count == 4)
			{
				S_OrderDetail.dt_OrderInfo = orderDetail.Tables[0];
				if (S_OrderDetail.dt_OrderInfo.Rows.Count != 0)
				{
					int index = 0;
					int i = 0;
					while (i < S_OrderDetail.dt_OrderInfo.Rows.Count)
					{
						if (!(S_OrderDetail.dt_OrderInfo.Rows[i]["ordernumber"].ToString() != ""))
						{
							i++;
						}
						else
						{
							index = i;
							IL_FE:
							DataRow dataRow = S_OrderDetail.dt_OrderInfo.Rows[index];
							this.htmlInputHidden_14.Value = dataRow["paymentname"].ToString();
							this.htmlInputHidden_13.Value = dataRow["paymentmemloginid"].ToString();
							this.htmlInputHidden_1.Value = (this.strOderState = dataRow["oderstatus"].ToString());
							this.htmlInputHidden_5.Value = dataRow["paymentstatus"].ToString();
							this.htmlInputHidden_6.Value = dataRow["shipmentstatus"].ToString();
							this.htmlInputHidden_7.Value = dataRow["refundstatus"].ToString();
							this.htmlInputHidden_19.Value = dataRow["refundtype"].ToString();
							this.strCreateTime = dataRow["createtime"].ToString();
							this.strPayTime = dataRow["paytime"].ToString();
							this.htmlInputHidden_10.Value = dataRow["paymentprice"].ToString();
							string strOderState = this.strOderState;
							if (strOderState != null)
							{
								if (!(strOderState == "0"))
								{
									if (!(strOderState == "1"))
									{
										if (!(strOderState == "2"))
										{
											if (strOderState == "3")
											{
												this.label_1.Text = this.strPayTime;
												this.label_0.Text = this.strCreateTime;
												this.label_2.Text = dataRow["dispatchtime"].ToString();
												this.label_3.Text = dataRow["receipttime"].ToString();
											}
										}
										else
										{
											this.label_1.Text = this.strPayTime;
											this.label_0.Text = this.strCreateTime;
											this.label_2.Text = dataRow["dispatchtime"].ToString();
											this.label_23.Text = dataRow["receivedDays"].ToString();
											this.htmlInputHidden_15.Value = Convert.ToDateTime(this.label_2.Text).AddDays(Convert.ToDouble(this.label_23.Text)).ToString().Replace("-", "/");
											this.htmlInputHidden_17.Value = Convert.ToDateTime(this.label_2.Text).AddDays(double.Parse(this.label_23.Text)).ToString();
										}
									}
									else
									{
										this.label_1.Text = this.strPayTime;
										this.label_0.Text = this.strCreateTime;
									}
								}
								else
								{
									this.label_0.Text = this.strCreateTime;
								}
							}
							this.label_9.Text = dataRow["ordernumber"].ToString();
							this.label_10.Text = S_OrderDetail.setOrderState(this.strOderState);
							this.label_11.Text = this.strCreateTime;
							this.label_12.Text = string.Concat(new object[]
							{
								dataRow["name"],
								",",
								dataRow["mobile"],
								",",
								dataRow["email"],
								",",
								dataRow["address"],
								",",
								dataRow["postalcode"]
							});
							this.label_16.Text = dataRow["ClientToSellerMsg"].ToString();
							this.label_17.Text = dataRow["SellerToClientMsg"].ToString();
							this.label_18.Text = dataRow["shouldpayprice"].ToString();
							this.htmlInputHidden_8.Value = this.label_18.Text;
							this.label_20.Text = dataRow["InvoiceType"].ToString();
							this.label_21.Text = dataRow["InvoiceTitle"].ToString();
							this.label_22.Text = dataRow["InvoiceContent"].ToString();
							this.htmlInputHidden_16.Value = dataRow["feetype"].ToString();
							this.htmlInputHidden_18.Value = dataRow["identifycode"].ToString();
							if (this.htmlInputHidden_16.Value != "2")
							{
								this.label_19.Text = "邮费：" + dataRow["dispatchprice"].ToString() + "元";
							}
							if (Convert.ToInt32(this.htmlInputHidden_1.Value) > 1)
							{
								this.label_13.Text = this.method_1(dataRow["DispatchType"]);
							}
							this.htmlInputHidden_12.Value = dataRow["dispatchprice"].ToString();
							this.label_14.Text = dataRow["LogisticsCompany"].ToString();
							this.label_15.Text = dataRow["ShipmentNumber"].ToString();
							if (!(dataRow["IsLogistics"].ToString() == "1"))
							{
								goto IL_750;
							}
							string kuaicom = dataRow["LogisticsCompanyCode"].ToString();
							string text = dataRow["ShipmentNumber"].ToString();
							if (text.Length > 5)
							{
								try
								{
									ShopNum1_KuaiDiRequest shopNum1_KuaiDiRequest = new ShopNum1_KuaiDiRequest();
									this.htmlGenericControl_0.InnerHtml = shopNum1_KuaiDiRequest.GetKuaidiInfo(kuaicom, text, "");
									if (this.htmlGenericControl_0.InnerHtml.IndexOf("kuaidiresult") != -1)
									{
										this.htmlGenericControl_0.InnerHtml = "<iframe name=\"kuaidi100\" id=\"kuaidi100HtmlApi\" src=\"" + this.htmlGenericControl_0.InnerHtml + "\" width=\"600\" height=\"380\" marginwidth=\"0\" marginheight=\"0\" hspace=\"0\" vspace=\"0\" frameborder=\"0\" scrolling=\"no\"></iframe>";
									}
								}
								catch (Exception)
								{
								}
								goto IL_750;
							}
							goto IL_750;
						}
					}
                    //goto IL_FE;
				}
				S_OrderDetail.dt_OrderInfo = null;
				IL_750:
				this.dataTable_0 = orderDetail.Tables[1];
				if (this.dataTable_0.Rows.Count == 0)
				{
					this.dataTable_0 = null;
				}
				else
				{
					this.label_4.Text = this.dataTable_0.Rows[0]["memloginId"].ToString();
					this.htmlInputHidden_11.Value = this.label_4.Text;
					this.label_5.Text = this.dataTable_0.Rows[0]["realname"].ToString();
					string text2 = this.dataTable_0.Rows[0]["addressvalue"].ToString();
					if (text2.IndexOf("|") != -1)
					{
						text2 = text2.Split(new char[]
						{
							'|'
						})[0].ToString().Replace(",", "");
					}
					this.label_6.Text = text2;
					this.label_7.Text = this.dataTable_0.Rows[0]["mobile"].ToString();
					this.label_8.Text = this.dataTable_0.Rows[0]["email"].ToString();
				}
				S_OrderDetail.dt_OrderOperate = orderDetail.Tables[2];
				if (S_OrderDetail.dt_OrderOperate.Rows.Count == 0)
				{
					S_OrderDetail.dt_OrderOperate = null;
				}
			}
		}
		protected void IsEmail(string guid, string Type)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(guid);
			string value = ShopSettings.GetValue("Name");
			UpdateOrderStute updateOrderStute = new UpdateOrderStute();
			SendProductAnnoucement sendProductAnnoucement = new SendProductAnnoucement();
			string text3 = string.Empty;
			string text4;
			if (Type == "CancelOrderIsEmail")
			{
				text = (updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString());
				text3 = ShopNum1.Common.Common.GetNameById("email", "shopnum1_member", " and memloginid='" + text + "'");
				if (string.IsNullOrEmpty(text3))
				{
					return;
				}
				updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
				updateOrderStute.OrderStatus = S_OrderDetail.setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
				updateOrderStute.UpdateTime = DateTime.Now.ToString();
				updateOrderStute.SysSendTime = DateTime.Now.ToString();
				updateOrderStute.ShopName = value;
				text4 = "b195a8ab-8b12-4df2-b719-c9cc8e6e5226";
			}
			else
			{
				text = (sendProductAnnoucement.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString());
				text3 = ShopNum1.Common.Common.GetNameById("email", "shopnum1_member", " and memloginid='" + text + "'");
				if (string.IsNullOrEmpty(text3))
				{
					return;
				}
				sendProductAnnoucement.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
				sendProductAnnoucement.Memo = orderInfoByGuid.Rows[0]["SellerToClientMsg"].ToString();
				sendProductAnnoucement.SendTime = DateTime.Now.ToString();
				sendProductAnnoucement.ShopName = value;
				sendProductAnnoucement.ShopDoMain = string.Concat(new string[]
				{
					"<a href=\"http://",
					ShopSettings.siteDomain,
					"/\" target=\"_blank\">",
					ShopSettings.siteDomain,
					"</a>"
				});
				text4 = "7c367402-4219-46b7-bc48-72cf48f6a836";
			}
			string emailTitle = string.Empty;
			ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
			DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text4 + "'", 0);
			if (editInfo.Rows.Count > 0)
			{
				text2 = editInfo.Rows[0]["Remark"].ToString();
				emailTitle = editInfo.Rows[0]["Title"].ToString();
			}
			if (Type == "CancelOrderIsEmail")
			{
				text2 = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text2));
			}
			else
			{
				text2 = sendProductAnnoucement.ChangeSendProductAnnoucement(this.Page.Server.HtmlDecode(text2));
			}
			text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString());
			SendEmail sendEmail = new SendEmail();
			sendEmail.Emails(text3, text, emailTitle, text4, text2);
		}
		protected void IsMMS(string guid, string type)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(guid);
			if (!(orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim() == ""))
			{
				string text = string.Empty;
				UpdateOrderStute updateOrderStute = new UpdateOrderStute();
				SendProductAnnoucement sendProductAnnoucement = new SendProductAnnoucement();
				if (type == "CancelOrderIsMMS")
				{
					updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
					updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
					updateOrderStute.OrderStatus = S_OrderDetail.setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
					updateOrderStute.ShopName = ShopSettings.GetValue("Name");
					updateOrderStute.UpdateTime = DateTime.Now.ToString();
					updateOrderStute.SysSendTime = DateTime.Now.ToString();
					text = "'3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2'";
				}
				else
				{
					sendProductAnnoucement.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
					sendProductAnnoucement.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
					sendProductAnnoucement.ShopDoMain = ShopSettings.siteDomain;
					sendProductAnnoucement.ShopName = ShopSettings.GetValue("Name");
					sendProductAnnoucement.SendTime = DateTime.Now.ToString();
					sendProductAnnoucement.Memo = orderInfoByGuid.Rows[0]["SellerToClientMsg"].ToString();
					text = "'7c367402-4219-46b7-bc48-72cf48f6a836'";
				}
				IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text, 0);
				string text2 = editInfo.Rows[0]["Remark"].ToString();
				string mMsTitle = editInfo.Rows[0]["Title"].ToString();
				SMS sMS = new SMS();
				string text3 = "";
				if (type == "CancelOrderIsMMS")
				{
					text2 = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text2));
				}
				else
				{
					text2 = sendProductAnnoucement.ChangeSendProductAnnoucement(this.Page.Server.HtmlDecode(text2));
					text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString());
				}
				sMS.Send(orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim(), text2, out text3);
				if (text3.IndexOf("发送成功") != -1)
				{
					ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(), orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim(), text2, mMsTitle, 2, text.Replace("'", ""));
					shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
				}
				else
				{
					ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(), orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim(), text2, mMsTitle, 0, text.Replace("'", ""));
					shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
				}
			}
		}
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle, int state, string mmsGuid)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = strContent,
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
		}
		private string method_1(object object_0)
		{
			string result;
			if (object_0.ToString() == "1")
			{
				result = "平邮";
			}
			else if (object_0.ToString() == "2")
			{
				result = "快递";
			}
			else if (object_0.ToString() == "3")
			{
				result = "EMS";
			}
			else if (object_0.ToString() == "-1")
			{
				result = "买家自提货";
			}
			else if (object_0.ToString() == "0")
			{
				result = "不需要物流";
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string setOrderState(string strState)
		{
			string result;
			switch (strState)
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
				result = "订单关闭";
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
		public static string setShipmentState(string strState)
		{
			string result;
			switch (strState)
			{
			case "0":
				result = "未发货";
				return result;
			case "1":
				result = "已发货";
				return result;
			case "2":
				result = "已收货";
				return result;
			case "3":
				result = "已退货";
				return result;
			case "4":
				result = "退货成功";
				return result;
			case "5":
				result = "卖家拒绝退货";
				return result;
			}
			result = "非法状态";
			return result;
		}
		public static string setPaymentState(string strState)
		{
			string result;
			if (strState != null)
			{
				if (strState == "0")
				{
					result = "未付款";
					return result;
				}
				if (strState == "1")
				{
					result = "已付款";
					return result;
				}
				if (strState == "2")
				{
					result = "已退款";
					return result;
				}
				if (strState == "3")
				{
					result = "退款成功";
					return result;
				}
				if (strState == "4")
				{
					result = "卖家拒绝退款";
					return result;
				}
			}
			result = "非法状态";
			return result;
		}
	}
}
