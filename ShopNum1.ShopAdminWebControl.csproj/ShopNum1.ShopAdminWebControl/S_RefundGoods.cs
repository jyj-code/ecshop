using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_RefundGoods : BaseShopWebControl
	{
		private string string_0 = "S_RefundGoods.ascx";
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
		private HtmlImage htmlImage_0;
		private Button button_0;
		private HtmlTextArea htmlTextArea_0;
		private HtmlTextArea htmlTextArea_1;
		private Label label_0;
		private Label label_1;
		public S_RefundGoods()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidShouldPayprice");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidPaymentmemLoginid");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidAdvancePayment");
			this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("hidPayMentName");
			this.htmlInputHidden_8 = (HtmlInputHidden)skin.FindControl("hidShopPayment");
			this.htmlInputHidden_9 = (HtmlInputHidden)skin.FindControl("hidShopId");
			this.htmlInputHidden_10 = (HtmlInputHidden)skin.FindControl("hidMemloginId");
			this.label_0 = (Label)skin.FindControl("lblExit");
			this.label_1 = (Label)skin.FindControl("lblExitMoney");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidSureState");
			this.htmlTextArea_1 = (HtmlTextArea)skin.FindControl("txtIntroduce");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txtReason");
			this.button_0 = (Button)skin.FindControl("btnSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidIsReceive");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidProductGuID");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidRefundReason");
			this.htmlImage_0 = (HtmlImage)skin.FindControl("showimg");
			if (ShopNum1.Common.Common.ReqStr("view").IndexOf("|") != -1)
			{
				string text = ShopNum1.Common.Common.ReqStr("view");
				ShopNum1_Refund_Action shopNum1_Refund_Action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
				DataTable dataTable = shopNum1_Refund_Action.SelectRefundInfo(text.Split(new char[]
				{
					'|'
				})[2], this.MemLoginID, "1");
				if (text.Split(new char[]
				{
					'|'
				})[0] == "exitgoods")
				{
					this.label_0.Text = "退货";
				}
				this.htmlInputHidden_1.Value = text.Split(new char[]
				{
					'|'
				})[2];
				if (dataTable.Rows.Count > 0)
				{
					this.htmlInputHidden_4.Value = dataTable.Rows[0]["shouldpayprice"].ToString();
					this.htmlInputHidden_5.Value = dataTable.Rows[0]["paymentmemloginid"].ToString();
					this.htmlInputHidden_6.Value = dataTable.Rows[0]["advancepayment"].ToString();
					this.htmlInputHidden_8.Value = dataTable.Rows[0]["shoppayment"].ToString();
					this.htmlInputHidden_7.Value = dataTable.Rows[0]["paymentname"].ToString();
					this.htmlInputHidden_9.Value = dataTable.Rows[0]["shopid"].ToString();
					this.htmlInputHidden_10.Value = dataTable.Rows[0]["memloginid"].ToString();
					this.htmlInputHidden_2.Value = dataTable.Rows[0]["refundreason"].ToString();
					this.label_1.Text = dataTable.Rows[0]["RefundMoney"].ToString();
					this.htmlTextArea_1.Value = dataTable.Rows[0]["RefundContent"].ToString();
					this.htmlImage_0.Src = dataTable.Rows[0]["RefundImg"].ToString();
					this.htmlInputHidden_0.Value = dataTable.Rows[0]["IsReceive"].ToString();
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Refund_Action shopNum1_Refund_Action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
			if (this.label_0.Text != "退货")
			{
				string status = "1";
				string strPayState = "3";
				if (this.htmlInputHidden_3.Value == "0")
				{
					status = "2";
					strPayState = "4";
					shopNum1_OrderInfo_Action.UpdateOrderState(this.htmlInputHidden_1.Value, this.MemLoginID, "", "", strPayState, "2", "1");
					ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
					shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
					{
						Guid = Guid.NewGuid(),
						OrderInfoGuid = new Guid(this.htmlInputHidden_1.Value),
						CreateUser = this.MemLoginID,
						OderStatus = 2,
						ShipmentStatus = 1,
						PaymentStatus = 1,
						CurrentStateMsg = "卖家不同意退款",
						NextStateMsg = "等待卖家发货",
						Memo = "",
						OperateDateTime = DateTime.Now,
						IsDeleted = 0
					});
				}
				else
				{
					this.method_0();
					shopNum1_OrderInfo_Action.UpdateOrderState(this.htmlInputHidden_1.Value, this.MemLoginID, "5", "", strPayState, "2", "1");
					ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
					shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
					{
						Guid = Guid.NewGuid(),
						OrderInfoGuid = new Guid(this.htmlInputHidden_1.Value),
						CreateUser = this.MemLoginID,
						OderStatus = 2,
						ShipmentStatus = 1,
						PaymentStatus = 1,
						CurrentStateMsg = "卖家同意退款",
						NextStateMsg = "无",
						Memo = "",
						OperateDateTime = DateTime.Now,
						IsDeleted = 0
					});
					shopNum1_OrderProduct_Action.UpdateReduceStock(this.htmlInputHidden_1.Value);
				}
				shopNum1_Refund_Action.UpdateRefundStatus(this.MemLoginID, this.htmlTextArea_0.Value, this.htmlInputHidden_1.Value, status);
				if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
				{
					this.IsMMS(this.htmlInputHidden_1.Value, this.htmlInputHidden_10.Value, "退款");
				}
			}
			else
			{
				string status = "1";
				string strShipState = "4";
				if (this.htmlInputHidden_3.Value == "0")
				{
					status = "2";
					strShipState = "5";
					shopNum1_OrderInfo_Action.UpdateOrderState(this.htmlInputHidden_1.Value, this.MemLoginID, "", strShipState, "", "2", "1");
					ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
					shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
					{
						Guid = Guid.NewGuid(),
						OrderInfoGuid = new Guid(this.htmlInputHidden_1.Value),
						CreateUser = this.MemLoginID,
						OderStatus = 2,
						ShipmentStatus = 1,
						PaymentStatus = 1,
						CurrentStateMsg = "卖家不同意退货",
						NextStateMsg = "等待买家确认收货",
						Memo = "",
						OperateDateTime = DateTime.Now,
						IsDeleted = 0
					});
				}
				else
				{
					this.method_0();
					shopNum1_OrderInfo_Action.UpdateOrderState(this.htmlInputHidden_1.Value, this.MemLoginID, "5", strShipState, "", "2", "1");
					ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
					shopNum1_OrderOperateLog_Action.Add(new ShopNum1_OrderOperateLog
					{
						Guid = Guid.NewGuid(),
						OrderInfoGuid = new Guid(this.htmlInputHidden_1.Value),
						CreateUser = this.MemLoginID,
						OderStatus = 2,
						ShipmentStatus = 1,
						PaymentStatus = 1,
						CurrentStateMsg = "卖家同意退货",
						NextStateMsg = "无",
						Memo = "",
						OperateDateTime = DateTime.Now,
						IsDeleted = 0
					});
					shopNum1_OrderProduct_Action.UpdateReduceStock(this.htmlInputHidden_1.Value);
					if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
					{
						this.IsMMS(this.htmlInputHidden_1.Value, this.htmlInputHidden_10.Value, "退货");
					}
				}
				shopNum1_Refund_Action.UpdateRefundStatus(this.MemLoginID, this.htmlTextArea_0.Value, this.htmlInputHidden_1.Value, status);
			}
			if (ShopNum1.Common.Common.ReqStr("totype") == "lifeorder")
			{
				this.Page.Response.Redirect("S_LifeOrder_List.aspx");
			}
			else
			{
				this.Page.Response.Redirect("S_Order_List.aspx");
			}
		}
		protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state, string mmsGuid, string string_1)
		{
			return new ShopNum1_MMSGroupSend
			{
				Guid = Guid.NewGuid(),
				MMSTitle = MMsTitle,
				CreateTime = DateTime.Now,
				MMSGuid = new Guid(mmsGuid),
				SendObjectMMS = string_1,
				SendObject = memLoginID + "-" + mobile,
				State = state
			};
		}
		protected void IsMMS(string orderinfoGuId, string MemLoginID, string strStateTxt)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(orderinfoGuId);
			string text = orderInfoByGuid.Rows[0]["mobile"].ToString().Trim();
			if (!(text == ""))
			{
				string text2 = string.Empty;
				UpdateOrderStute updateOrderStute = new UpdateOrderStute();
				updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
				updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
				updateOrderStute.ShopName = ShopSettings.GetValue("Name");
				updateOrderStute.UpdateTime = DateTime.Now.ToString();
				updateOrderStute.SysSendTime = DateTime.Now.ToString();
				text2 = "'3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2'";
				ShopNum1_MMS_Action shopNum1_MMS_Action = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
				DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text2, 0);
				string text3 = string.Empty;
				string mMsTitle = string.Empty;
				if (editInfo.Rows.Count > 0)
				{
					text3 = editInfo.Rows[0]["Remark"].ToString();
					mMsTitle = editInfo.Rows[0]["Title"].ToString();
				}
				text3 = text3.Replace("{$Name}", updateOrderStute.Name);
				text3 = text3.Replace("{$OrderStatus}", strStateTxt);
				text3 = text3.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
				text3 = text3.Replace("{$ShopName} ", updateOrderStute.ShopName);
				text3 = text3.Replace("{$SysSendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
				SMS sMS = new SMS();
				string text4 = "";
				text3 = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text3));
				sMS.Send(text, text3, out text4);
				if (text4.IndexOf("发送成功") != -1)
				{
					ShopNum1_MMSGroupSend mMSGroupSend = this.AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(), text, mMsTitle, 2, text2.Replace("'", ""), text3);
					shopNum1_MMS_Action.AddMMSGroupSend(mMSGroupSend);
				}
				else
				{
					ShopNum1_MMSGroupSend mMSGroupSend = this.AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(), text, mMsTitle, 0, text2.Replace("'", ""), text3);
					shopNum1_MMS_Action.AddMMSGroupSend(mMSGroupSend);
				}
			}
		}
		private void method_0()
		{
			string value = this.htmlInputHidden_10.Value;
			string value2 = this.htmlInputHidden_9.Value;
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			decimal num = Convert.ToDecimal(this.label_1.Text);
			decimal num2 = Convert.ToDecimal(this.htmlInputHidden_8.Value);
			decimal d = Convert.ToDecimal(this.htmlInputHidden_4.Value);
			decimal num3 = Convert.ToDecimal(this.htmlInputHidden_6.Value);
			if (this.htmlInputHidden_5.Value == "admin")
			{
				if (this.htmlInputHidden_7.Value.IndexOf("货到付款") != -1 || this.htmlInputHidden_7.Value.IndexOf("线下支付") != -1)
				{
					if (num3 >= num)
					{
						shopNum1_Member_Action.RefundUpdateAdvancePayment(value, value2, num, num2, this.htmlInputHidden_1.Value, this.htmlInputHidden_1.Value, 3);
						this.AdvancePaymentModifyLog(5, num3, num, "退款成功增加买家预存款", value, 1);
						this.AdvancePaymentModifyLog(5, num2, num, "会员退款扣除卖家预存款", value2, 0);
					}
					else
					{
						MessageBox.Show("预存款不足，请充值后再同意退款！");
					}
				}
				else
				{
					this.AdvancePaymentModify(value, num);
					this.AdvancePaymentModifyLog(5, num3, num, "退款成功增加买家预存款", value, 1);
					if (d >= num)
					{
						decimal payMoney = d - num;
						this.AdvancePaymentModifyLog(5, num2, payMoney, "买家退款时订单剩余金额打给卖家", value2, 1);
					}
				}
			}
			else if (this.htmlInputHidden_7.Value == "预存款支付")
			{
				this.AdvancePaymentModify(value, num);
				this.AdvancePaymentModifyLog(5, num3, num, "退款成功增加预存款", value, 1);
				if (d >= num)
				{
					decimal payMoney = d - num;
					this.AdvancePaymentModifyLog(5, num2, payMoney, "买家退款时订单剩余金额打给卖家", value2, 1);
				}
			}
			else if (num2 >= num)
			{
				shopNum1_Member_Action.RefundUpdateAdvancePayment(value, this.MemLoginID, num, num2, this.htmlInputHidden_1.Value, this.htmlInputHidden_1.Value, 3);
				this.AdvancePaymentModifyLog(5, num3, num, "退款成功增加买家预存款", value, 1);
				this.AdvancePaymentModifyLog(5, num2, num, "会员退款扣除卖家预存款", value2, 0);
			}
			else
			{
				MessageBox.Show("预存款不足，请充值后再同意退款！");
			}
		}
		public void AdvancePaymentModify(string MemLoginID, decimal AddPrice)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			int num = shopNum1_Member_Action.RefundUpdateAdvancePaymentMem(MemLoginID, AddPrice);
			if (num > 0)
			{
				MessageBox.Show("退款成功！");
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
			if (!(payMoney.ToString() == "0.00") && !(payMoney.ToString() == "0"))
			{
				if (type == 1)
				{
					shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments + payMoney;
					shopNum1_AdvancePaymentModifyLog.OperateType = 1;
				}
				else
				{
					shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
					shopNum1_AdvancePaymentModifyLog.OperateType = 6;
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
		}
	}
}
