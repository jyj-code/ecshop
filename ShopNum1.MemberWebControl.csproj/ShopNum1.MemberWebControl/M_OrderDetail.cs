using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.KuaiDi;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_OrderDetail : BaseMemberWebControl
	{
		private string string_0 = "M_OrderDetail.ascx";
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
		private Label label_24;
		private Label label_25;
		public static DataTable dt_OrderInfo = null;
		public static DataTable dt_OrderOperate = null;
		public static DataTable dt_PayMent = null;
		private DataTable dataTable_0 = null;
		private HtmlGenericControl htmlGenericControl_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private LinkButton linkButton_4;
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
		public M_OrderDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("LogisticInfo");
			this.label_19 = (Label)skin.FindControl("LabelInvoiceTypeValue");
			this.label_20 = (Label)skin.FindControl("LabelInvoiceTitleValue");
			this.label_21 = (Label)skin.FindControl("LabelInvoiceContentValue");
			this.label_23 = (Label)skin.FindControl("lblDispatch");
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
			this.label_22 = (Label)skin.FindControl("lblSureDays");
			this.label_18 = (Label)skin.FindControl("lblShouldPrice");
			this.label_24 = (Label)skin.FindControl("lblDelay");
			this.label_25 = (Label)skin.FindControl("lblCancleOrder");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidOrderGuId");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidOrderState");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidOrderProductId");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidOrderPay");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidPayMentInfo");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidPayMentName");
			this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("hidPayState");
			this.htmlInputHidden_8 = (HtmlInputHidden)skin.FindControl("hidShipState");
			this.htmlInputHidden_9 = (HtmlInputHidden)skin.FindControl("hidRefundstatus");
			this.htmlInputHidden_10 = (HtmlInputHidden)skin.FindControl("hidShouldPayPrice");
			this.htmlInputHidden_11 = (HtmlInputHidden)skin.FindControl("hidShopId");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidBuyNum");
			this.htmlInputHidden_12 = (HtmlInputHidden)skin.FindControl("hidDispatchPrice");
			this.htmlInputHidden_13 = (HtmlInputHidden)skin.FindControl("hidPaymentPrice");
			this.htmlInputHidden_14 = (HtmlInputHidden)skin.FindControl("hidExpiresTime");
			this.htmlInputHidden_15 = (HtmlInputHidden)skin.FindControl("hidlifetype");
			this.htmlInputHidden_16 = (HtmlInputHidden)skin.FindControl("hidEndTime");
			this.htmlInputHidden_17 = (HtmlInputHidden)skin.FindControl("hidCanleTime");
			this.htmlInputHidden_18 = (HtmlInputHidden)skin.FindControl("hidTotalDays");
			this.htmlInputHidden_19 = (HtmlInputHidden)skin.FindControl("hidShopPrice");
			this.linkButton_0 = (LinkButton)skin.FindControl("butSureConfirm");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("btnUpdatePayMent");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2 = (LinkButton)skin.FindControl("butPayMoney");
			this.linkButton_3 = (LinkButton)skin.FindControl("butCancelOrder");
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.linkButton_4 = (LinkButton)skin.FindControl("btnDelay");
			this.linkButton_4.Click += new EventHandler(this.linkButton_4_Click);
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
			string value = string.Concat(new string[]
			{
				"M_PayOp.aspx?pname=",
				this.label_9.Text,
				"&orderguid=",
				ShopNum1.Common.Common.ReqStr("guid"),
				"&mid=",
				this.MemLoginID,
				"&shopid=",
				this.label_4.Text,
				"&ordertype=",
				ShopNum1.Common.Common.ReqStr("ordertype"),
				"&sign=welcomeshopnum1"
			});
			this.linkButton_2.Attributes.Add("target", "_blank");
			this.linkButton_2.Attributes.Add("href", value);
		}
		private void linkButton_4_Click(object sender, EventArgs e)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
			if ((Convert.ToDateTime(this.htmlInputHidden_14.Value) - DateTime.Now).TotalDays > 3.0)
			{
				MessageBox.Show("您可以在离超时结束还剩最后3天时，申请延长确认收货时间！");
			}
			else
			{
				string orderguid = ShopNum1.Common.Common.ReqStr("guid");
				shopNum1_OrderInfo_Action.UpdataReceivedDays(orderguid, this.htmlInputHidden_11.Value, "1", "3");
				this.OrderOperateLog("", "买家延长确认收货时间", "等待买家确认收货");
				this.Page.Response.Redirect(this.Page.Request.Url.ToString());
			}
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable allStatus = shopNum1_OrderInfo_Action.GetAllStatus(ShopNum1.Common.Common.ReqStr("guid"));
			if (allStatus.Rows.Count > 0)
			{
				string a = allStatus.Rows[0]["OderStatus"].ToString();
				if (a != "2")
				{
					shopNum1_OrderInfo_Action.SetOderStatus1(this.Page.Request.QueryString["guid"], 6, 0, 0, DateTime.Now);
					if (ShopSettings.GetValue("CancelOrderIsEmail") == "1")
					{
						this.IsEmail("CancelOrderIsEmail");
					}
					if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
					{
						this.IsMMS("CancelOrderIsMMS");
					}
					this.OrderOperateLog("取消订单", "买家取消订单", "无");
					ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderProduct_Action();
					shopNum1_OrderProduct_Action.UpdateReduceStock(ShopNum1.Common.Common.ReqStr("guid"), "0");
					this.method_0();
				}
				else
				{
					MessageBox.Show("卖家已经发货！");
				}
			}
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
			string value = this.htmlInputHidden_5.Value;
			if (value != "")
			{
				string paymentGuid = string.Empty;
				string text = string.Empty;
				paymentGuid = value.Split(new char[]
				{
					'|'
				})[0];
				text = value.Split(new char[]
				{
					'|'
				})[1];
				string text2 = value.Split(new char[]
				{
					'|'
				})[2];
				int num = Convert.ToInt32(value.Split(new char[]
				{
					'|'
				})[3]);
				if (num != 0)
				{
					text2 = text2.Replace("%", "");
				}
				int num2 = shopNum1_OrderInfo_Action.UpdatePaymentInfo(ShopNum1.Common.Common.ReqStr("guid"), paymentGuid, text, Convert.ToDecimal(text2), num);
				if (num2 > 0)
				{
					this.OrderOperateLog("", "将" + this.htmlInputHidden_6.Value + "支付方式修改为" + text, "付款");
					this.Page.Response.Redirect("M_OrderDetail.aspx?guid=" + ShopNum1.Common.Common.ReqStr("guid") + "&ordertype=" + ShopNum1.Common.Common.ReqStr("ordertype"));
				}
			}
		}
		private void method_0()
		{
			this.strOrderGuId = ShopNum1.Common.Common.ReqStr("guid");
			this.htmlInputHidden_0.Value = this.strOrderGuId;
			this.strOrderType = ShopNum1.Common.Common.ReqStr("ordertype");
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataSet orderDetail = shopNum1_OrderInfo_Action.GetOrderDetail(this.strOrderGuId, this.MemLoginID, this.strOrderType, "2");
			if (orderDetail != null && orderDetail.Tables.Count == 4)
			{
				M_OrderDetail.dt_OrderInfo = orderDetail.Tables[0];
				if (M_OrderDetail.dt_OrderInfo.Rows.Count != 0)
				{
					int index = 0;
					int i = 0;
					while (i < M_OrderDetail.dt_OrderInfo.Rows.Count)
					{
						if (!(M_OrderDetail.dt_OrderInfo.Rows[i]["ordernumber"].ToString() != ""))
						{
							i++;
						}
						else
						{
							index = i;
							IL_FE:
							DataRow dataRow = M_OrderDetail.dt_OrderInfo.Rows[index];
							this.htmlInputHidden_1.Value = (this.strOderState = dataRow["oderstatus"].ToString());
							this.htmlInputHidden_7.Value = dataRow["paymentstatus"].ToString();
							this.htmlInputHidden_8.Value = dataRow["shipmentstatus"].ToString();
							this.htmlInputHidden_9.Value = dataRow["refundstatus"].ToString();
							this.htmlInputHidden_3.Value = dataRow["paymentmemloginid"].ToString();
							if (this.htmlInputHidden_1.Value == "0")
							{
								ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = (ShopNum1_ShopPayment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopPayment_Action();
								ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Payment_Action();
								if (dataRow["paymentmemloginid"].ToString() == "admin")
								{
									M_OrderDetail.dt_PayMent = shopNum1_Payment_Action.Search(0);
								}
								else
								{
									M_OrderDetail.dt_PayMent = shopNum1_ShopPayment_Action.Search(0, dataRow["paymentmemloginid"].ToString());
								}
							}
							this.strCreateTime = dataRow["createtime"].ToString();
							this.strPayTime = dataRow["paytime"].ToString();
							this.htmlInputHidden_6.Value = dataRow["paymentname"].ToString();
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
											this.label_22.Text = dataRow["receivedDays"].ToString();
											this.htmlInputHidden_16.Value = Convert.ToDateTime(this.label_2.Text).AddDays(double.Parse(this.label_22.Text)).ToString();
											this.htmlInputHidden_14.Value = Convert.ToDateTime(this.label_2.Text).AddDays(Convert.ToDouble(this.label_22.Text)).ToString().Replace("-", "/");
											if (Convert.ToDateTime(this.htmlInputHidden_16.Value) < DateTime.Now.ToLocalTime())
											{
												this.label_24.Text = "延迟已过期！";
												this.linkButton_4.Enabled = false;
											}
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
									this.label_25.Text = ShopSettings.GetValue("DefaultCancelOrderDays");
									this.htmlInputHidden_17.Value = Convert.ToDateTime(this.strCreateTime).AddDays(double.Parse(this.label_25.Text)).ToString();
								}
							}
							this.label_9.Text = dataRow["ordernumber"].ToString();
							this.label_11.Text = this.strCreateTime;
							if (this.strOderState == "2")
							{
								this.linkButton_4.Enabled = true;
							}
							if (dataRow["IsMemdelay"].ToString() == "1")
							{
								this.label_24.Text = "您已延迟过！";
								this.linkButton_4.Enabled = false;
							}
							string text = string.Empty;
							if (!string.IsNullOrEmpty(dataRow["name"].ToString()))
							{
								text += dataRow["name"].ToString();
							}
							if (!string.IsNullOrEmpty(dataRow["mobile"].ToString()))
							{
								text = text + "," + dataRow["mobile"].ToString();
							}
							if (!string.IsNullOrEmpty(dataRow["email"].ToString()))
							{
								text = text + "," + dataRow["email"].ToString();
							}
							if (!string.IsNullOrEmpty(dataRow["address"].ToString()))
							{
								text = text + "," + dataRow["address"].ToString();
							}
							if (!string.IsNullOrEmpty(dataRow["postalcode"].ToString()))
							{
								text = text + "," + dataRow["postalcode"].ToString();
							}
							this.label_12.Text = text;
							this.label_16.Text = dataRow["ClientToSellerMsg"].ToString();
							this.label_17.Text = dataRow["SellerToClientMsg"].ToString();
							this.label_18.Text = dataRow["shouldpayprice"].ToString();
							this.htmlInputHidden_10.Value = dataRow["shouldpayprice"].ToString();
							this.htmlInputHidden_13.Value = dataRow["paymentprice"].ToString();
							this.label_19.Text = dataRow["InvoiceType"].ToString();
							this.label_20.Text = dataRow["InvoiceTitle"].ToString();
							this.label_21.Text = dataRow["InvoiceContent"].ToString();
							this.htmlInputHidden_15.Value = dataRow["feetype"].ToString();
							this.label_10.Text = M_OrderDetail.setOrderState(this.strOderState);
							if (this.htmlInputHidden_15.Value == "2")
							{
								if (this.strOderState == "1")
								{
									this.label_10.Text = "等待买家消费";
								}
								if (Convert.ToInt32(this.strOderState) > 0)
								{
									this.label_23.Text = "消费码：" + dataRow["identifycode"].ToString();
								}
							}
							else
							{
								this.label_23.Text = "邮费：" + dataRow["dispatchprice"].ToString() + "元";
							}
							if (Convert.ToInt32(this.htmlInputHidden_1.Value) > 1)
							{
								this.label_13.Text = this.method_3(dataRow["DispatchType"]);
							}
							this.htmlInputHidden_12.Value = dataRow["dispatchprice"].ToString();
							this.label_14.Text = dataRow["LogisticsCompany"].ToString();
							this.label_15.Text = dataRow["ShipmentNumber"].ToString();
							if (dataRow["IsLogistics"].ToString() == "1")
							{
								string kuaicom = dataRow["LogisticsCompanyCode"].ToString();
								string text2 = dataRow["ShipmentNumber"].ToString();
								if (text2.Length > 5)
								{
									ShopNum1_KuaiDiRequest shopNum1_KuaiDiRequest = new ShopNum1_KuaiDiRequest();
									this.htmlGenericControl_0.InnerHtml = shopNum1_KuaiDiRequest.GetKuaidiInfo(kuaicom, text2, "");
									if (this.htmlGenericControl_0.InnerHtml.IndexOf("kuaidiresult") != -1)
									{
										this.htmlGenericControl_0.InnerHtml = "<iframe name=\"kuaidi100\" id=\"kuaidi100HtmlApi\" src=\"" + this.htmlGenericControl_0.InnerHtml + "\" width=\"600\" height=\"380\" marginwidth=\"0\" marginheight=\"0\" hspace=\"0\" vspace=\"0\" frameborder=\"0\" scrolling=\"no\"></iframe>";
									}
								}
							}
							if (this.htmlInputHidden_14.Value != "")
							{
								TimeSpan timeSpan = Convert.ToDateTime(this.htmlInputHidden_14.Value) - DateTime.Now;
								this.htmlInputHidden_18.Value = timeSpan.Days.ToString();
								goto IL_9D5;
							}
							goto IL_9D5;
						}
					}
                    //goto IL_FE;
				}
				M_OrderDetail.dt_OrderInfo = null;
				IL_9D5:
				this.dataTable_0 = orderDetail.Tables[1];
				if (this.dataTable_0.Rows.Count == 0)
				{
					this.dataTable_0 = null;
				}
				else
				{
					this.htmlInputHidden_11.Value = this.dataTable_0.Rows[0]["memloginId"].ToString();
					this.label_4.Text = this.dataTable_0.Rows[0]["memloginId"].ToString();
					this.label_5.Text = this.dataTable_0.Rows[0]["realname"].ToString();
					string text3 = this.dataTable_0.Rows[0]["addressvalue"].ToString();
					if (text3.IndexOf("|") != -1)
					{
						text3 = text3.Split(new char[]
						{
							'|'
						})[0].Replace(",", "");
					}
					this.label_6.Text = text3;
					this.label_7.Text = this.dataTable_0.Rows[0]["mobile"].ToString();
					this.label_8.Text = this.dataTable_0.Rows[0]["email"].ToString();
				}
				M_OrderDetail.dt_OrderOperate = orderDetail.Tables[2];
				if (M_OrderDetail.dt_OrderOperate.Rows.Count == 0)
				{
					M_OrderDetail.dt_OrderOperate = null;
				}
				if (this.strOderState == "0" && Convert.ToDateTime(this.strCreateTime).AddDays(double.Parse(this.label_25.Text)) <= DateTime.Now)
				{
					shopNum1_OrderInfo_Action.SetOderStatus1(this.Page.Request.QueryString["guid"], 4, 0, 0, DateTime.Now);
					if (ShopSettings.GetValue("CancelOrderIsEmail") == "1")
					{
						this.IsEmail("CancelOrderIsEmail");
					}
					if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
					{
						this.IsMMS("CancelOrderIsMMS");
					}
					this.OrderOperateLog("", "系统取消订单", "无");
					ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderProduct_Action();
					shopNum1_OrderProduct_Action.UpdateReduceStock(this.htmlInputHidden_0.Value);
				}
			}
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			if (this.htmlInputHidden_6.Value.IndexOf("担保交易") != -1)
			{
				MessageBox.Show("您必须到支付宝中进行确认收货！");
				Thread.Sleep(200);
				this.Page.Response.Redirect("https://my.alipay.com/portal/i.htm?src=yy_content_jygl");
			}
			else
			{
				string value = this.htmlInputHidden_2.Value;
				decimal d = 0m;
				decimal num = 0m;
                //0m;
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
				ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderProduct_Action();
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductCategory_Action();
				string value2 = this.htmlInputHidden_11.Value;
				decimal num2 = Convert.ToDecimal(this.htmlInputHidden_10.Value);
				decimal num3 = Convert.ToDecimal(num2);
				bool flag = true;
				bool flag2 = false;
				if (value != "")
				{
					string value3 = this.htmlInputHidden_4.Value;
					int num4 = 1;
					if (value.IndexOf(",") != -1)
					{
						num4 = value.Split(new char[]
						{
							','
						}).Length;
					}
					string text = this.htmlInputHidden_19.Value;
					for (int i = 0; i < num4; i++)
					{
						int value4;
						if (value3.IndexOf(",") != -1)
						{
							value4 = Convert.ToInt32(value3.Split(new char[]
							{
								','
							})[i]);
						}
						else
						{
							value4 = Convert.ToInt32(value3);
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
						if (ShopSettings.GetValue("IsShopProductFcRate") == "true")
						{
							flag2 = true;
							flag = false;
							if (text2 != "" && text2.IndexOf("|") != -1)
							{
								if (text2.Split(new char[]
								{
									'|'
								})[1] == "1")
								{
									decimal d2 = decimal.Parse(text2.Split(new char[]
									{
										'|'
									})[0]) / 100m;
									num += Convert.ToDecimal(text) * d2 * value4;
								}
								else
								{
									decimal d3 = Convert.ToDecimal(ShopSettings.GetValue("AdminProductFcRate")) / 100m;
									num += Convert.ToDecimal(text) * d3;
								}
							}
							else
							{
								decimal d3 = Convert.ToDecimal(ShopSettings.GetValue("AdminProductFcRate")) / 100m;
								num += Convert.ToDecimal(text) * d3;
							}
						}
					}
					if (flag2)
					{
						num += Convert.ToDecimal(this.htmlInputHidden_12.Value);
					}
				}
				string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='" + value2 + "'");
				if (nameById != "")
				{
					decimal advancePayments = Convert.ToDecimal(nameById);
					if (ShopSettings.GetValue("IsOrderCommission") == "true")
					{
						decimal d3 = Convert.ToDecimal(ShopSettings.GetValue("OrderCommission")) / 100m;
						if (!flag)
						{
							num += (num2 - Convert.ToDecimal(this.htmlInputHidden_13.Value)) * d3;
						}
						else
						{
							num += num2 * d3;
						}
					}
					string value5 = ShopSettings.GetValue("IsAgentOrderCommission");
					string value6 = ShopSettings.GetValue("AgentOrderCommission");
					decimal num5 = 0m;
					if (value5 == "true")
					{
						string nameById2 = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "  and MemLoginID='" + value2 + "'   ");
						ShopNum1_City_AdvancePaymentModifyLog_Action shopNum1_City_AdvancePaymentModifyLog_Action = (ShopNum1_City_AdvancePaymentModifyLog_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_City_AdvancePaymentModifyLog_Action();
						decimal decimal_ = shopNum1_City_AdvancePaymentModifyLog_Action.SearchAdvancePaymentBySubstationID(nameById2);
						decimal d4 = Convert.ToDecimal(value6) / Convert.ToDecimal(100);
						num5 = d4 * num2;
						this.method_1(nameById2, 1, decimal_, num5, "分站店铺订单销售收益", 0);
						shopNum1_City_AdvancePaymentModifyLog_Action.UpdateSubstationAdvancePayment(num5, nameById2, 1);
					}
					num3 = Convert.ToDecimal(num2 - Convert.ToDecimal(this.htmlInputHidden_13.Value) - (d + num) - num5);
					if (this.htmlInputHidden_3.Value == "admin")
					{
						if (this.htmlInputHidden_6.Value.IndexOf("线下") == -1 && this.htmlInputHidden_6.Value.IndexOf("货到付款") == -1 && shopNum1_Member_Action.UpdateAdvancePayment(0, value2, num3) > 0)
						{
							string str = string.Empty;
							try
							{
								str = ShopNum1.Common.Common.GetNameById("OrderNumber", "ShopNum1_OrderInfo", "   and  Guid='" + this.Page.Request.QueryString["guid"].ToString() + "'");
							}
							catch (Exception)
							{
							}
							this.AdvancePaymentModifyLog(4, advancePayments, num3, "订单" + str + "确认收货，增加店铺预存款", value2, DateTime.Now, 1);
						}
					}
					else if (this.htmlInputHidden_6.Value == "预存款支付")
					{
						string str = string.Empty;
						try
						{
							str = ShopNum1.Common.Common.GetNameById("OrderNumber", "ShopNum1_OrderInfo", "   and  Guid='" + this.Page.Request.QueryString["guid"].ToString() + "'");
						}
						catch (Exception)
						{
						}
						this.AdvancePaymentModifyLog(4, advancePayments, Convert.ToDecimal(this.htmlInputHidden_10.Value), "订单" + str + "确认收货，增加店铺预存款", value2, DateTime.Now, 1);
						shopNum1_Member_Action.UpdateAdvancePayment(0, value2, Convert.ToDecimal(this.htmlInputHidden_10.Value));
					}
					else if (num3 != num2)
					{
						num3 = Convert.ToDecimal(this.htmlInputHidden_10.Value) - num3;
						this.AdvancePaymentModifyLog(5, advancePayments, num3, "平台开启提成,会员确认收货,系统扣除店铺预存款", value2, DateTime.Now, 0);
					}
					shopNum1_OrderInfo_Action.SetOderStatus1(this.htmlInputHidden_0.Value, 3, 1, 2, DateTime.Now);
					int num6 = (ShopSettings.GetValue("BuyProductRankScore") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("BuyProductRankScore"));
					int num7 = (ShopSettings.GetValue("BuyProductScore") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("BuyProductScore"));
					int num8 = 0;
					int num9 = 0;
					if (num7 > 0)
					{
						double num10 = Convert.ToDouble(num7) / Convert.ToDouble(100);
						num8 = Convert.ToInt32(Convert.ToDouble(num2) * num10);
					}
					if (num6 > 0)
					{
						double num11 = Convert.ToDouble(num6) / Convert.ToDouble(100);
						num9 = Convert.ToInt32(Convert.ToDouble(num2) * num11);
					}
					string value7 = ShopSettings.GetValue("IsRecommendCommisionOpen");
					if (value7 == "true")
					{
						decimal num12 = 0m;
						string nameById3 = ShopNum1.Common.Common.GetNameById("RecommendCommision", "ShopNum1_OrderInfo", "  AND  Guid='" + ShopNum1.Common.Common.ReqStr("guid").Replace("'", "") + "'");
						if (!string.IsNullOrEmpty(nameById3))
						{
							num12 = Convert.ToDecimal(nameById3);
						}
						if (num12 > 0m)
						{
							string nameById4 = ShopNum1.Common.Common.GetNameById("PromotionMemLoginID", "ShopNum1_Member", "  AND  MemLoginID='" + this.MemLoginID + "'");
							if (!string.IsNullOrEmpty(nameById4))
							{
								string nameById5 = ShopNum1.Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", "   AND   MemLoginID='" + nameById4 + "'");
								decimal num13 = 0m;
								if (!string.IsNullOrEmpty(nameById5))
								{
									num13 = Convert.ToDecimal(nameById5);
								}
								ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
								shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
								shopNum1_AdvancePaymentModifyLog.OperateType = 5;
								shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num13;
								shopNum1_AdvancePaymentModifyLog.OperateMoney = num12;
								shopNum1_AdvancePaymentModifyLog.LastOperateMoney = num13 + num12;
								shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
								shopNum1_AdvancePaymentModifyLog.Memo = "推荐会员[" + this.MemLoginID + "]购买商品返利￥" + num12.ToString();
								shopNum1_AdvancePaymentModifyLog.MemLoginID = nameById4;
								shopNum1_AdvancePaymentModifyLog.CreateUser = nameById4;
								shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
								shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
								ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
								shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
							}
						}
					}
					shopNum1_Member_Action.UpdateMemberScore(this.MemLoginID, num9, num8);
					this.method_2(num8, num9);
					if (ShopSettings.GetValue("ShipmentOKIsEmail") == "1")
					{
						this.IsEmail("ShipmentOKIsEmail");
					}
					if (ShopSettings.GetValue("ShipmentOKIsMMS") == "1")
					{
						this.IsMMS("ShipmentOKIsMMS");
					}
					if (this.htmlInputHidden_6.Value == "线下支付" || this.htmlInputHidden_6.Value == "货到付款")
					{
						shopNum1_OrderProduct_Action.UpdateStock(this.htmlInputHidden_0.Value);
					}
					this.OrderOperateLog("", "交易完成", "等待买家评价");
					this.Page.Response.Redirect("M_ProductComment.aspx?orid=" + ShopNum1.Common.Common.ReqStr("guid") + "&");
				}
			}
		}
		private void method_1(string string_6, int int_0, decimal decimal_0, decimal decimal_1, string string_7, int int_1)
		{
			ShopNum1_City_AdvancePaymentModifyLog_Action shopNum1_City_AdvancePaymentModifyLog_Action = (ShopNum1_City_AdvancePaymentModifyLog_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_City_AdvancePaymentModifyLog_Action();
			ShopNum1_City_AdvancePaymentModifyLog shopNum1_City_AdvancePaymentModifyLog = new ShopNum1_City_AdvancePaymentModifyLog();
			shopNum1_City_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_City_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
			shopNum1_City_AdvancePaymentModifyLog.CurrentAdvancePayment = decimal_0;
			shopNum1_City_AdvancePaymentModifyLog.Date = DateTime.Now;
			shopNum1_City_AdvancePaymentModifyLog.Guid = Guid.NewGuid();
			shopNum1_City_AdvancePaymentModifyLog.IsDeleted = new int?(0);
			shopNum1_City_AdvancePaymentModifyLog.IsMainAdmin = new int?(int_1);
			if (int_0 == 0)
			{
				shopNum1_City_AdvancePaymentModifyLog.LastOperateMoney = decimal_0 - decimal_1;
			}
			else if (int_0 == 1)
			{
				shopNum1_City_AdvancePaymentModifyLog.LastOperateMoney = decimal_0 + decimal_1;
			}
			shopNum1_City_AdvancePaymentModifyLog.Memo = string_7;
			shopNum1_City_AdvancePaymentModifyLog.OperateMoney = decimal_1;
			shopNum1_City_AdvancePaymentModifyLog.OperateType = 0;
			Order order = new Order();
			shopNum1_City_AdvancePaymentModifyLog.OrderNumber = order.CreateOrderNumber();
			shopNum1_City_AdvancePaymentModifyLog.SubstationID = string_6;
			shopNum1_City_AdvancePaymentModifyLog.UserMemo = "分站金额变更";
			shopNum1_City_AdvancePaymentModifyLog_Action.Add(shopNum1_City_AdvancePaymentModifyLog);
		}
		private void method_2(int int_0, int int_1)
		{
			string nameById = ShopNum1.Common.Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)", "shopnum1_member", " and memloginid='" + this.MemLoginID + "'");
			int num = 0;
			int num2 = 0;
			if (nameById != "" && nameById.IndexOf("-") != -1)
			{
				num = Convert.ToInt32(nameById.Split(new char[]
				{
					'-'
				})[1]);
				num2 = Convert.ToInt32(nameById.Split(new char[]
				{
					'-'
				})[0]);
			}
			if (int_0 > 0)
			{
				ShopNum1_ScoreModifyLog shopNum1_ScoreModifyLog = new ShopNum1_ScoreModifyLog();
				shopNum1_ScoreModifyLog.Guid = Guid.NewGuid();
				shopNum1_ScoreModifyLog.OperateType = 1;
				shopNum1_ScoreModifyLog.CurrentScore = num - int_0;
				shopNum1_ScoreModifyLog.OperateScore = int_0;
				shopNum1_ScoreModifyLog.LastOperateScore = num;
				shopNum1_ScoreModifyLog.Date = DateTime.Now;
				shopNum1_ScoreModifyLog.Memo = "买家确认收货送消费积分";
				shopNum1_ScoreModifyLog.MemLoginID = this.MemLoginID;
				shopNum1_ScoreModifyLog.CreateUser = this.MemLoginID;
				shopNum1_ScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_ScoreModifyLog.IsDeleted = 0;
				ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog_Action = (ShopNum1_ScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
				shopNum1_ScoreModifyLog_Action.OperateScore(shopNum1_ScoreModifyLog);
			}
			if (int_1 > 0)
			{
				ShopNum1_RankScoreModifyLog shopNum1_RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
				shopNum1_RankScoreModifyLog.Guid = Guid.NewGuid();
				shopNum1_RankScoreModifyLog.OperateType = 1;
				shopNum1_RankScoreModifyLog.CurrentScore = num2 - int_1;
				shopNum1_RankScoreModifyLog.OperateScore = int_1;
				shopNum1_RankScoreModifyLog.LastOperateScore = num2;
				shopNum1_RankScoreModifyLog.Date = DateTime.Now;
				shopNum1_RankScoreModifyLog.Memo = "买家确认收货送等级积分";
				shopNum1_RankScoreModifyLog.MemLoginID = this.MemLoginID;
				shopNum1_RankScoreModifyLog.CreateUser = this.MemLoginID;
				shopNum1_RankScoreModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_RankScoreModifyLog.IsDeleted = 0;
				ShopNum1_RankScoreModifyLog_Action shopNum1_RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
				shopNum1_RankScoreModifyLog_Action.OperateScore(shopNum1_RankScoreModifyLog);
			}
		}
		protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg)
		{
			if (!string.IsNullOrEmpty(this.htmlInputHidden_0.Value))
			{
				ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
				shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
				shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(this.htmlInputHidden_0.Value);
				shopNum1_OrderOperateLog.OderStatus = 1;
				shopNum1_OrderOperateLog.ShipmentStatus = 0;
				shopNum1_OrderOperateLog.PaymentStatus = 0;
				shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
				shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
				shopNum1_OrderOperateLog.Memo = memo;
				shopNum1_OrderOperateLog.OperateDateTime = DateTime.Now;
				shopNum1_OrderOperateLog.IsDeleted = 0;
				shopNum1_OrderOperateLog.CreateUser = this.MemLoginID;
				ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderOperateLog_Action();
				shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
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
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
		}
		protected void IsMMS(string strflag)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(this.Page.Request.QueryString["guid"].ToString());
			ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
			string nameById = ShopNum1.Common.Common.GetNameById("Mobile", "ShopNum1_Member", " and MemLoginID='" + orderInfoByGuid.Rows[0]["ShopId"].ToString() + "'");
			if (!string.IsNullOrEmpty(nameById))
			{
				string value = ShopSettings.GetValue("Name");
				UpdateOrderStute updateOrderStute = new UpdateOrderStute();
				updateOrderStute.Name = orderInfoByGuid.Rows[0]["ShopId"].ToString();
				updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
				updateOrderStute.OrderStatus = M_OrderDetail.setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
				updateOrderStute.UpdateTime = DateTime.Now.ToString();
				updateOrderStute.SysSendTime = DateTime.Now.ToString();
				updateOrderStute.ShopName = value;
				string text = string.Empty;
				string text2;
				if (strflag == "CancelOrderIsMMS")
				{
					text2 = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
				}
				else
				{
					text2 = "e77e5311-e0d2-4b6e-b16d-65db7f4ace40";
				}
				ShopNum1_MMS_Action shopNum1_MMS_Action2 = (ShopNum1_MMS_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action2.GetEditInfo("'" + text2 + "'", 0);
				string mMsTitle = string.Empty;
				if (editInfo.Rows.Count > 0)
				{
					text = editInfo.Rows[0]["Remark"].ToString();
					mMsTitle = editInfo.Rows[0]["Title"].ToString();
				}
				text = text.Replace("{$Name}", updateOrderStute.Name);
				text = text.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
				text = text.Replace("{$ShopName}", updateOrderStute.ShopName);
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
				text = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text));
				string empty = string.Empty;
				SMS sMS = new SMS();
				sMS.Send(nameById.Trim(), text, out empty);
				if (empty.IndexOf("发送成功") != -1)
				{
					ShopNum1_MMSGroupSend mMSGroupSend = this.AddMMS(updateOrderStute.Name, nameById.Trim(), mMsTitle, text, 2, text2);
					shopNum1_MMS_Action.AddMMSGroupSend(mMSGroupSend);
				}
				else
				{
					ShopNum1_MMSGroupSend mMSGroupSend = this.AddMMS(updateOrderStute.Name, nameById.Trim(), mMsTitle, text, 0, text2);
					shopNum1_MMS_Action.AddMMSGroupSend(mMSGroupSend);
				}
			}
		}
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, string strContent, int state, string mmsGuid)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = DateTime.Now,
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = strContent.Trim(),
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
		}
		protected void IsEmail(string strflag)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(this.htmlInputHidden_0.Value);
			string nameById = ShopNum1.Common.Common.GetNameById("Email", "ShopNum1_Member", " and MemLoginID=(Select ShopID from ShopNum1_orderinfo where Guid='" + this.htmlInputHidden_0.Value + "')");
			if (!string.IsNullOrEmpty(nameById))
			{
				string value = ShopSettings.GetValue("Name");
				UpdateOrderStute updateOrderStute = new UpdateOrderStute();
				string memLoginID = updateOrderStute.Name = orderInfoByGuid.Rows[0]["shopid"].ToString();
				updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
				updateOrderStute.OrderStatus = M_OrderDetail.setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
				updateOrderStute.UpdateTime = DateTime.Now.ToString();
				updateOrderStute.SysSendTime = DateTime.Now.ToString();
				updateOrderStute.ShopName = value;
				string text = string.Empty;
				string emailTitle = string.Empty;
				string text2;
				if (strflag == "CancelOrderIsEmail")
				{
					text2 = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
				}
				else
				{
					text2 = "E77E5311-E0D2-4B6E-B16D-65DB7F4ACE40";
				}
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Email_Action();
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
				if (editInfo.Rows.Count > 0)
				{
					text = editInfo.Rows[0]["Remark"].ToString();
					emailTitle = editInfo.Rows[0]["Title"].ToString();
				}
				text = text.Replace("{$Name}", updateOrderStute.Name);
				text = text.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
				text = text.Replace("{$ShopName}", updateOrderStute.ShopName);
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
				string emailBody = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text));
				SendEmail sendEmail = new SendEmail();
				sendEmail.Emails(nameById, memLoginID, emailTitle, text2, emailBody);
			}
		}
		private string method_3(object object_0)
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
		private string method_4(string string_6)
		{
			string result;
			if (string_6 != null)
			{
				if (string_6 == "0")
				{
					result = "未发货";
					return result;
				}
				if (string_6 == "1")
				{
					result = "已发货";
					return result;
				}
				if (string_6 == "2")
				{
					result = "已收货";
					return result;
				}
				if (string_6 == "3")
				{
					result = "退货";
					return result;
				}
			}
			result = "非法状态";
			return result;
		}
		private string method_5(string string_6)
		{
			string result;
			if (string_6 != null)
			{
				if (string_6 == "0")
				{
					result = "未付款";
					return result;
				}
				if (string_6 == "1")
				{
					result = "已付款";
					return result;
				}
				if (string_6 == "2")
				{
					result = "退款成功";
					return result;
				}
				if (string_6 == "3")
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
