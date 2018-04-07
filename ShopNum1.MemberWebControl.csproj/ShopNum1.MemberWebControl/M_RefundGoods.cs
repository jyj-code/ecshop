using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_RefundGoods : BaseMemberWebControl
	{
		private string string_0 = "M_RefundGoods.ascx";
		private HtmlSelect htmlSelect_0;
		private HtmlSelect htmlSelect_1;
		private HtmlTextArea htmlTextArea_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		private HtmlInputHidden htmlInputHidden_5;
		private Button button_0;
		private Button button_1;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private HtmlImage htmlImage_0;
		private HtmlTableRow htmlTableRow_0;
		private HtmlInputHidden htmlInputHidden_6;
		public M_RefundGoods()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_2 = (Label)skin.FindControl("lblState");
			this.htmlTableRow_0 = (HtmlTableRow)skin.FindControl("trstate");
			this.htmlImage_0 = (HtmlImage)skin.FindControl("showimg");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidRefundReason");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidIsReceive");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidProductGuID");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidRefundType");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidShopId");
			this.label_1 = (Label)skin.FindControl("lblmoney");
			this.label_0 = (Label)skin.FindControl("lblExit");
			this.htmlSelect_0 = (HtmlSelect)skin.FindControl("selisreceive");
			this.htmlSelect_1 = (HtmlSelect)skin.FindControl("selrefundCase");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txtIntroduce");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtmoney");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidImgPath");
			this.button_0 = (Button)skin.FindControl("btnSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("btnReturnDetail");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidorderstatus");
			this.method_0();
		}
		private void method_0()
		{
			if (ShopNum1.Common.Common.ReqStr("op").IndexOf("|") != -1)
			{
				string text = ShopNum1.Common.Common.ReqStr("op");
				this.htmlInputHidden_6.Value = text.Split(new char[]
				{
					'@'
				})[1];
				this.htmlInputHidden_3.Value = text.Split(new char[]
				{
					'|'
				})[2];
				if (text.Split(new char[]
				{
					'|'
				})[0] == "exitgoods")
				{
					this.label_0.Text = "退货";
				}
				this.htmlInputHidden_5.Value = ShopNum1.Common.Common.GetNameById("shopid", "shopnum1_orderinfo", string.Concat(new string[]
				{
					" and memloginId='",
					this.MemLoginID,
					"' and guid='",
					text.Split(new char[]
					{
						'|'
					})[2],
					"'"
				}));
				this.label_1.Text = ShopNum1.Common.Common.GetNameById("shouldpayprice", "shopnum1_orderinfo", string.Concat(new string[]
				{
					" and memloginId='",
					this.MemLoginID,
					"' and guid='",
					text.Split(new char[]
					{
						'|'
					})[2],
					"'"
				}));
			}
			if (ShopNum1.Common.Common.ReqStr("view").IndexOf("|") != -1)
			{
				this.button_0.Text = "编辑";
				this.htmlTableRow_0.Visible = true;
				string text2 = ShopNum1.Common.Common.ReqStr("view");
				this.htmlInputHidden_6.Value = text2.Split(new char[]
				{
					'@'
				})[1];
				ShopNum1_Refund_Action shopNum1_Refund_Action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
				DataTable dataTable = shopNum1_Refund_Action.SelectRefundInfo(text2.Split(new char[]
				{
					'|'
				})[2], this.MemLoginID, "0");
				if (text2.Split(new char[]
				{
					'|'
				})[0] == "exitgoods")
				{
					this.label_0.Text = "退货";
				}
				this.label_1.Text = ShopNum1.Common.Common.GetNameById("shouldpayprice", "shopnum1_orderinfo", string.Concat(new string[]
				{
					" and memloginId='",
					this.MemLoginID,
					"' and guid='",
					text2.Split(new char[]
					{
						'|'
					})[2],
					"'"
				}));
				this.htmlInputHidden_3.Value = text2.Split(new char[]
				{
					'|'
				})[2];
				if (dataTable.Rows.Count > 0)
				{
					this.label_2.Text = this.RefundStatus(dataTable.Rows[0]["RefundStatus"].ToString(), dataTable.Rows[0]["RefundType"].ToString());
					if (dataTable.Rows[0]["RefundStatus"].ToString() == "1")
					{
						this.button_0.Visible = false;
					}
					this.htmlInputHidden_4.Value = dataTable.Rows[0]["RefundType"].ToString();
					this.htmlInputHidden_1.Value = dataTable.Rows[0]["refundreason"].ToString();
					this.htmlInputText_0.Value = dataTable.Rows[0]["RefundMoney"].ToString();
					this.htmlTextArea_0.Value = dataTable.Rows[0]["RefundContent"].ToString();
					this.htmlImage_0.Src = dataTable.Rows[0]["RefundImg"].ToString();
					this.htmlInputHidden_0.Value = dataTable.Rows[0]["RefundImg"].ToString();
					this.htmlInputHidden_2.Value = dataTable.Rows[0]["IsReceive"].ToString();
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Refund shopNum1_Refund = new ShopNum1_Refund();
			shopNum1_Refund.ApplyTime = DateTime.Now;
			shopNum1_Refund.MemLoginID = this.MemLoginID;
			shopNum1_Refund.OrderID = this.htmlInputHidden_3.Value;
			shopNum1_Refund.ProductGuid = new Guid(this.htmlInputHidden_3.Value);
			shopNum1_Refund.ShopID = this.htmlInputHidden_5.Value;
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			shopNum1_Refund.IsReceive = int.Parse(this.htmlInputHidden_2.Value);
			if (shopNum1_OrderInfo_Action.SearchOrderInfoByOrderId(this.htmlInputHidden_3.Value, "shipmentstatus") == "0")
			{
				shopNum1_Refund.IsReceive = 0;
			}
			shopNum1_Refund.RefundMoney = Convert.ToDecimal(this.htmlInputText_0.Value);
			shopNum1_Refund.RefundID = DateTime.Now.ToString("yyyyMMddHHmmss");
			shopNum1_Refund.RefundReason = this.htmlInputHidden_1.Value;
			if (ShopNum1.Common.Common.ReqStr("op") != "")
			{
				if (ShopNum1.Common.Common.ReqStr("op").IndexOf("exitmoney") != -1)
				{
					shopNum1_Refund.RefundType = 0;
				}
				else
				{
					shopNum1_Refund.RefundType = 1;
				}
			}
			shopNum1_Refund.RefundStatus = 0;
			shopNum1_Refund.RefundContent = this.htmlTextArea_0.Value;
			shopNum1_Refund.RefundImg = this.htmlInputHidden_0.Value;
			ShopNum1_Refund_Action shopNum1_Refund_Action = (ShopNum1_Refund_Action)LogicFactory.CreateShopNum1_Refund_Action();
			int num;
			if (this.button_0.Text == "编辑")
			{
				num = shopNum1_Refund_Action.Update(shopNum1_Refund);
			}
			else
			{
				shopNum1_Refund_Action.DeleteRefundByOrId(shopNum1_Refund.OrderID);
				num = shopNum1_Refund_Action.Add(shopNum1_Refund);
			}
			if (num > 0)
			{
				if (shopNum1_Refund.RefundType == 0)
				{
					ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
					this.OrderOperateLog("", "买家申请退款", "等待卖家处理");
					shopNum1_OrderInfo_Action2.UpdateOrderState(this.htmlInputHidden_3.Value, this.MemLoginID, "", "", "2", "1", "0");
				}
				else
				{
					ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
					shopNum1_OrderInfo_Action2.UpdateOrderState(this.htmlInputHidden_3.Value, this.MemLoginID, "", "3", "", "1", "0");
					this.OrderOperateLog("", "买家申请退货", "等待卖家处理");
				}
				if (!(ShopSettings.GetValue("CancelOrderIsEmail") == "1"))
				{
				}
			}
			string str = "M_OrderList.aspx";
			if (this.Page.Request.Url.ToString().IndexOf("lifeorder") != -1)
			{
				str = "M_LifeOrderList.aspx";
			}
			this.Page.RegisterClientScriptBlock("tip", "<script>alert('操作成功！');location.href='" + str + "';</script>");
		}
		protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg)
		{
			if (!string.IsNullOrEmpty(this.htmlInputHidden_3.Value))
			{
				ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
				shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
				shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(this.htmlInputHidden_3.Value);
				shopNum1_OrderOperateLog.OderStatus = 1;
				shopNum1_OrderOperateLog.ShipmentStatus = 0;
				shopNum1_OrderOperateLog.PaymentStatus = 0;
				shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
				shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
				shopNum1_OrderOperateLog.Memo = memo;
				shopNum1_OrderOperateLog.OperateDateTime = DateTime.Now;
				shopNum1_OrderOperateLog.IsDeleted = 0;
				shopNum1_OrderOperateLog.CreateUser = this.MemLoginID;
				ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
				shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
			}
		}
		protected void IsEmail(string ordernum, string MemLoginID)
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(this.htmlInputHidden_3.Value);
			string nameById = ShopNum1.Common.Common.GetNameById("Email", "ShopNum1_Member", " and MemLoginID=(Select ShopID from ShopNum1_orderinfo where Guid='" + this.htmlInputHidden_3.Value + "')");
			if (!string.IsNullOrEmpty(nameById))
			{
				string value = ShopSettings.GetValue("Name");
				UpdateOrderStute updateOrderStute = new UpdateOrderStute();
				MemLoginID = (updateOrderStute.Name = orderInfoByGuid.Rows[0]["shopid"].ToString());
				updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
				updateOrderStute.UpdateTime = DateTime.Now.ToString();
				updateOrderStute.SysSendTime = DateTime.Now.ToString();
				updateOrderStute.ShopName = value;
				string text = string.Empty;
				string emailTitle = string.Empty;
				string text2 = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
				ShopNum1_Email_Action shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
				DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
				if (editInfo.Rows.Count > 0)
				{
					text = editInfo.Rows[0]["Remark"].ToString();
					emailTitle = editInfo.Rows[0]["Title"].ToString();
				}
				text = text.Replace("{$Name}", updateOrderStute.Name);
				text = text.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
				text = text.Replace("{$ShopName}", updateOrderStute.ShopName);
				text = text.Replace("{$SysSendTime}", DateTime.Now.ToString());
				string emailBody = updateOrderStute.ChangeUpdateOrderStute(this.Page.Server.HtmlDecode(text));
				SendEmail sendEmail = new SendEmail();
				sendEmail.Emails(nameById, MemLoginID, emailTitle, text2, emailBody);
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
	}
}
