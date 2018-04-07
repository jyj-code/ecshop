using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class LifeOrder_YueTao : BaseWebControl
	{
		private string string_0 = "LifeOrder_YueTao.ascx";
		private Button button_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputText htmlInputText_0;
		private Repeater repeater_0;
		public LifeOrder_YueTao()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.button_0 = (Button)skin.FindControl("btnSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("content");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidShopMemloginId");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidSuccesslifeorder");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidWaitlifeorder");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtLifeCode");
			this.repeater_0 = (Repeater)skin.FindControl("repOrderInfo");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				string a = httpCookie.Values["MemberType"].ToString();
				if (a != "2")
				{
					this.htmlGenericControl_0.Visible = false;
				}
				else
				{
					string text = httpCookie.Values["MemLoginID"].ToString();
					this.htmlInputHidden_0.Value = text;
					ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
					DataTable lifeOrderCount = shopNum1_OrderInfo_Action.GetLifeOrderCount(text);
					if (lifeOrderCount.Rows.Count > 0)
					{
						this.htmlInputHidden_1.Value = lifeOrderCount.Rows[0]["success"].ToString();
						this.htmlInputHidden_2.Value = lifeOrderCount.Rows[0]["wait"].ToString();
					}
				}
			}
			else
			{
				this.htmlGenericControl_0.Visible = false;
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			string value = this.htmlInputText_0.Value;
			DataTable orderInfoByCode = shopNum1_OrderInfo_Action.GetOrderInfoByCode(this.htmlInputHidden_0.Value, value);
			if (orderInfoByCode.Rows.Count == 0)
			{
				MessageBox.Show("该验证码不是当前商户的验证码!");
			}
			else if (orderInfoByCode.Rows[0]["oderstatus"].ToString() == "3")
			{
				MessageBox.Show("该验证码已在【" + orderInfoByCode.Rows[0]["receipttime"] + "】被使用了!");
			}
			else
			{
				ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
				string logisticsCompany = "";
				string shipmentNumber = "";
				string value2 = orderInfoByCode.Rows[0]["ShouldPayPrice"].ToString();
				string value3 = this.htmlInputHidden_0.Value;
				string text = orderInfoByCode.Rows[0]["PayMentName"].ToString();
				string text2 = orderInfoByCode.Rows[0]["GuID"].ToString();
				string partner = string.Empty;
				ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
				DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Alipay.aspx");
				if (paymentKey.Rows.Count > 0)
				{
					partner = paymentKey.Rows[0]["MerchantCode"].ToString();
					DataTable dataTable = shopNum1_OrderInfo_Action2.Search1(text2);
					if (dataTable != null && dataTable.Rows.Count > 0)
					{
						string trade_no = orderInfoByCode.Rows[0]["AlipayTradeId"].ToString();
						if (text == "支付宝担保交易")
						{
							PayUrlOperate payUrlOperate = new PayUrlOperate();
							string text3 = payUrlOperate.ConfimSendProduct(partner, trade_no, logisticsCompany, shipmentNumber);
							XmlDocument xmlDocument = new XmlDocument();
							try
							{
								xmlDocument.LoadXml(text3);
								string a = xmlDocument.SelectSingleNode("//is_success").InnerText.ToString();
								if (!(a == "T"))
								{
									MessageBox.Show("发货失败！");
									return;
								}
								MessageBox.Show("发货成功！");
							}
							catch (Exception)
							{
								this.Page.Response.Write(text3);
							}
						}
					}
				}
                //0m;
                //0m;
                //0m;
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
				ShopNum1_ProductCategory_Action arg_289_0 = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				decimal num = Convert.ToDecimal(value2);
				string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='" + value3 + "'");
				if (nameById != "")
				{
					decimal advancePayments = Convert.ToDecimal(nameById);
					if (text.IndexOf("线下") == -1 && text.IndexOf("货到付款") == -1 && shopNum1_Member_Action.UpdateAdvancePayment(0, value3, num) > 0)
					{
						this.AdvancePaymentModifyLog(4, advancePayments, num, "会员确认收货，增加店铺预存款", value3, DateTime.Now, 1);
					}
					int num2 = shopNum1_OrderInfo_Action.SetOderStatus1(text2, 3, 1, 2, DateTime.Now);
					string text4 = orderInfoByCode.Rows[0]["MemloginID"].ToString();
					string nameById2 = ShopNum1.Common.Common.GetNameById("Mobile", "shopnum1_member", " and memloginid='" + text4 + "'");
					this.IsMMS(text2, nameById2, text4, num.ToString());
					if (num2 > 0)
					{
						if (text == "线下支付" || text == "货到付款")
						{
							shopNum1_OrderProduct_Action.UpdateStock(text2);
						}
						ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
						shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
						{
							Guid = Guid.NewGuid(),
							OrderInfoGuid = new Guid(text2),
							CreateUser = value3,
							OderStatus = 3,
							ShipmentStatus = 2,
							PaymentStatus = 1,
							CurrentStateMsg = "买家已消费,交易完成",
							NextStateMsg = "等待买家评价",
							Memo = "",
							OperateDateTime = DateTime.Now,
							IsDeleted = 0
						});
					}
					this.method_0();
					MessageBox.Show("该验证码已被成功消费!");
					this.repeater_0.DataSource = orderInfoByCode.DefaultView;
					this.repeater_0.DataBind();
				}
			}
		}
		protected void IsMMS(string guid, string strMobile, string strMemLoginId, string strPayMoney)
		{
			ShopNum1_OrderInfo_Action arg_0A_0 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			string text = "'0610a526-229e-4075-b084-3b6a5b929759'";
			IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
			DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text, 0);
			if (editInfo.Rows.Count != 0)
			{
				string text2 = editInfo.Rows[0]["Remark"].ToString();
				string mMsTitle = editInfo.Rows[0]["Title"].ToString();
				text2 = text2.Replace("{$Name}", strMemLoginId);
				text2 = text2.Replace("{$PayMoney}", strPayMoney);
				text2 = text2.Replace("{$SysSendTime}", DateTime.Now.ToString("MM月dd日"));
				SMS sMS = new SMS();
				string text3 = "";
				sMS.Send(strMobile, text2, out text3);
				if (text3.IndexOf("发送成功") != -1)
				{
					ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(strMemLoginId, strMobile, mMsTitle, 2, text.Replace("'", ""));
					shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
				}
				else
				{
					ShopNum1_MMSGroupSend emailGroupSend = this.AddMMS(strMemLoginId, strMobile, mMsTitle, 0, text.Replace("'", ""));
					shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
				}
			}
		}
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state, string mmsGuid)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = DateTime.Now,
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = mobile,
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
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
	}
}
